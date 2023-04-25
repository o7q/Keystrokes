using System;
using System.IO;
using System.Text;
using System.Timers;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Media = System.Windows.Media;
using Keystrokes.Data;
using static Keystrokes.Tools.Input;
using static Keystrokes.Tools.Numbers;

namespace Keystrokes
{
    public partial class key : Form
    {
        int tempLocX = 0;
        int tempLocY = 0;

        // configure mouse window events
        public const int HT_CAPTION = 0x2;
        public const int WM_NCLBUTTONDOWN = 0xA1;

        // grab dlls for mousedown
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        KeyInfo keyData = new KeyInfo();

        System.Timers.Timer keyPing = new System.Timers.Timer();

        Image backgroundImage;
        Image backgroundImagePressed;
        bool useBackgroundImage = false;
        bool useBackgroundImagePressed = false;

        bool useSound = false;
        bool useSoundPressed = false;

        public key(KeyInfo keyData_)
        {
            InitializeComponent();

            // load keyData_ into keyData
            keyData = keyData_;
        }

        private void key_Load(object sender, EventArgs e)
        {
            // format key with keyData
            Left = keyData.KEY_LOCATION_X;
            Top = keyData.KEY_LOCATION_Y;

            // set form and font size
            Size = new Size(keyData.keySizeX, keyData.keySizeY);
            keyLabel.Font = new Font(keyLabel.Font.Name, keyData.fontSize);

            // update text
            Text = keyData.keyText;
            keyLabel.Text = keyData.showText == true ? keyData.keyText : "";
            keyLabel.Location = new Point((Width / 2) - (keyLabel.Width / 2), (Height / 2) - (keyLabel.Height / 2));

            // configure form color and opacity
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.FromArgb(255, keyData.keyColorR, keyData.keyColorG, keyData.keyColorB);
            keyLabel.ForeColor = Color.FromArgb(255, keyData.keyTextColorR, keyData.keyTextColorG, keyData.keyTextColorB);
            Opacity = keyData.keyOpacity;

            if (keyData.keyBackgroundImage != null && keyData.keyBackgroundImage != "")
            {
                backgroundImage = Image.FromFile(keyData.keyBackgroundImage);

                BackgroundImage = backgroundImage;
                BackgroundImageLayout = ImageLayout.Stretch;

                useBackgroundImage = true;
            }
            if (keyData.keyBackgroundImagePressed != null && keyData.keyBackgroundImagePressed != "")
            {
                backgroundImagePressed = Image.FromFile(keyData.keyBackgroundImagePressed);

                useBackgroundImagePressed = true;
            }

            if (keyData.sound != null && keyData.sound != "")
                useSound = true;
            if (keyData.soundPressed != null && keyData.soundPressed != "")
                useSoundPressed = true;


            // update snap textboxes
            snapXTextbox.Text = keyData.KEY_SNAP_X.ToString();
            snapYTextbox.Text = keyData.KEY_SNAP_Y.ToString();

            // hide components
            closeButton.Visible = false;
            lockButton.Visible = false;
            snapXTextbox.Visible = false;
            snapYTextbox.Visible = false;

            // draw over everything
            TopMost = true;

            // generate id for key if it doesn't have one
            if (keyData.keyId == null)
                keyData.keyId = keyData.keyCode + "_" + generateID(8);

            #region tooltipDictionary
            // bind tooltips
            string[] tooltipMap =
            {
                "closeButton", "Close",
                "lockButton", "Lock the key and prevent mouse interaction",
                "snapXTextbox", "Snap X threshold (50 = one half key width snap size)",
                "snapYTextbox", "Snap Y threshold (50 = one half key height snap size)",
            };
            #endregion

            // configure tooltips
            for (int i = 0; i < tooltipMap.Length; i += 2)
                keyTooltip.SetToolTip(Controls.Find(tooltipMap[i], true)[0], tooltipMap[i + 1]);

            // configure tooltip draw
            keyTooltip.AutoPopDelay = 10000;
            keyTooltip.OwnerDraw = true;
            keyTooltip.BackColor = Color.FromArgb(0, 0, 0);
            keyTooltip.ForeColor = Color.FromArgb(255, 255, 255);

            writeConfig();

            // configure and start keyPing
            keyPing.Elapsed += new ElapsedEventHandler(keyRefresh);
            keyPing.Interval = 1;
            keyPing.Enabled = true;

            tempLocX = Left;
            tempLocY = Top;

            closeButton.Width = 26 * Width / 60;
            closeButton.Height = 26 * Height / 60;

            lockButton.Width = 26 * Width / 60;
            lockButton.Height = 26 * Height / 60;

            lockButton.Location = new Point(lockButton.Left, closeButton.Height);

            countLabel.Location = new Point(countLabel.Location.X, Height - 16);
            countLabel.ForeColor = Color.FromArgb(255, keyData.keyTextColorR, keyData.keyTextColorG, keyData.keyTextColorB);
            if (keyData.USE_KEY_COUNT == true)
            {
                countLabel.Visible = true;
                countLabel.Text = keyData.KEY_COUNT.ToString();
            }
            else
                countLabel.Visible = false;

            snapXTextbox.Location = new Point(closeButton.Width, snapXTextbox.Top);
            snapYTextbox.Location = new Point(closeButton.Width, snapYTextbox.Top);
        }
        // hide in task manager
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x80;  // turn on WS_EX_TOOLWINDOW
                return cp;
            }
        }

        private void keyTooltip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void key_Paint(object sender, PaintEventArgs e)
        {
            // draw custom key border
            int r = keyData.keyColorR - 50 < 0 ? 0 : keyData.keyColorR - 50;
            int g = keyData.keyColorG - 50 < 0 ? 0 : keyData.keyColorG - 50;
            int b = keyData.keyColorB - 50 < 0 ? 0 : keyData.keyColorB - 50;
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(255, r, g, b), keyData.keyBorder);
        }

        // do tick
        bool keyPressed = false;
        private void keyRefresh(object source, ElapsedEventArgs e)
        {
            // check for user key input
            if (keyDetect(keyData.keyCode, keyData.isControllerKey) == true)
            {
                try
                {
                    Invoke((MethodInvoker)delegate
                    {
                        if (keyData.wiggleMode == true)
                        {
                            Random random = new Random(Guid.NewGuid().GetHashCode());
                            int direction = random.Next(0, 4);

                            switch (direction)
                            {
                                case 0: Top -= 1 + keyData.wiggleMode_biasUp; break;
                                case 1: Top += 1 + keyData.wiggleMode_biasDown; break;
                                case 2: Left += 1 + keyData.wiggleMode_biasRight; break;
                                case 3: Left -= 1 + keyData.wiggleMode_biasLeft; break;
                            }
                        }

                        if (keyPressed == true) return;
                        keyPressed = true;

                        if (keyData.USE_KEY_COUNT == true)
                        {
                            keyData.KEY_COUNT++;
                            countLabel.Text = keyData.KEY_COUNT.ToString();
                            writeConfig();
                        }

                        if (useBackgroundImagePressed == true)
                            BackgroundImage = backgroundImagePressed;

                        if (useSoundPressed == true)
                        {
                            var mediaPlayer = new Media.MediaPlayer();
                            mediaPlayer.Open(new Uri(keyData.soundPressed, UriKind.RelativeOrAbsolute));
                            mediaPlayer.Volume = keyData.soundPressedVolume;
                            mediaPlayer.Play();
                        }

                        // update key colors
                        if (keyData.keyColorPressedInvert == true)
                            BackColor = Color.FromArgb(255, (byte)~keyData.keyColorR, (byte)~keyData.keyColorG, (byte)~keyData.keyColorB);
                        else
                            BackColor = Color.FromArgb(255, keyData.keyColorPressedR, keyData.keyColorPressedG, keyData.keyColorPressedB);

                        if (keyData.keyTextColorPressedInvert == true)
                        {
                            keyLabel.ForeColor = Color.FromArgb(255, (byte)~keyData.keyTextColorR, (byte)~keyData.keyTextColorG, (byte)~keyData.keyTextColorB);
                            countLabel.ForeColor = Color.FromArgb(255, (byte)~keyData.keyTextColorR, (byte)~keyData.keyTextColorG, (byte)~keyData.keyTextColorB);
                        }
                        else
                        {
                            keyLabel.ForeColor = Color.FromArgb(255, keyData.keyTextColorPressedR, keyData.keyTextColorPressedG, keyData.keyTextColorPressedB);
                            countLabel.ForeColor = Color.FromArgb(255, keyData.keyTextColorPressedR, keyData.keyTextColorPressedG, keyData.keyTextColorPressedB);
                        }
                    });
                }
                catch { }
            }
            else
            {
                try
                {
                    Invoke((MethodInvoker)delegate
                    {
                        if (keyPressed == false) return;
                        keyPressed = false;

                        if (useBackgroundImage == true)
                            BackgroundImage = backgroundImage;

                        if (useSound == true)
                        {
                            var mediaPlayer = new Media.MediaPlayer();
                            mediaPlayer.Open(new Uri(keyData.sound, UriKind.RelativeOrAbsolute));
                            mediaPlayer.Volume = keyData.soundVolume;
                            mediaPlayer.Play();
                        }

                        // restore key colors
                        BackColor = Color.FromArgb(255, keyData.keyColorR, keyData.keyColorG, keyData.keyColorB);
                        keyLabel.ForeColor = Color.FromArgb(255, keyData.keyTextColorR, keyData.keyTextColorG, keyData.keyTextColorB);
                        countLabel.ForeColor = Color.FromArgb(255, keyData.keyTextColorR, keyData.keyTextColorG, keyData.keyTextColorB);

                        if (keyData.wiggleMode == true && keyPressed == false)
                        {
                            keyPressed = false;
                            int startX = Location.X;
                            int startY = Location.Y;
                            int endX = tempLocX;
                            int endY = tempLocY;
                            int steps = 25;
                            double delay = 0.0025;

                            for (int i = 0; i < steps; i++)
                            {
                                int x = startX + (endX - startX) * i / steps;
                                int y = startY + (endY - startY) * i / steps;
                                Location = new Point(x, y);

                                var sw = Stopwatch.StartNew();
                                while (sw.ElapsedTicks < Math.Round(delay * Stopwatch.Frequency)) { }
                            }

                            Left = tempLocX;
                            Top = tempLocY;
                        }
                    });
                }
                catch { }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            // does preset exist? if yes, delete the key file
            if (Directory.Exists("Keystrokes\\presets\\" + keyData.presetName) == true)
                File.Delete("Keystrokes\\presets\\" + keyData.presetName + "\\" + keyData.keyId + ".key");
            handleClose();
        }

        private void lockButton_Click(object sender, EventArgs e)
        {
            if (keyData.KEY_LOCKED == false)
                keyData.KEY_LOCKED = true;
            else
                keyData.KEY_LOCKED = false;

            toggleControls();
            writeConfig();
        }

        private void snapXTextbox_TextChanged(object sender, EventArgs e)
        {
            keyData.KEY_SNAP_X = Int32.Parse(snapXTextbox.Text);
        }

        private void snapYTextbox_TextChanged(object sender, EventArgs e)
        {
            keyData.KEY_SNAP_Y = Int32.Parse(snapYTextbox.Text);
        }

        private void writeConfig()
        {
            if (isNumber(snapXTextbox.Text, "int") == false || snapXTextbox.Text == "")
                snapXTextbox.Text = "50";
            if (isNumber(snapYTextbox.Text, "int") == false || snapYTextbox.Text == "")
                snapYTextbox.Text = "50";

            // does the preset exist? if not, return
            if (Directory.Exists("Keystrokes\\presets\\" + keyData.presetName) == false) return;
            
            // write keyData to a designated key file
            var sb = new StringBuilder();
            foreach (var field in typeof(KeyInfo).GetFields())
            {
                object value = field.GetValue(keyData);
                if (value != null)
                    sb.Append(field.Name + "=" + value.ToString());
                sb.Append("\n");
            }
            sb.Length--;
            string config = sb.ToString();

            File.WriteAllText("Keystrokes\\presets\\" + keyData.presetName + "\\" + keyData.keyId + ".key", config);
        }

        private void moveKey(MouseEventArgs e)
        {
            // move form
            if (e.Button == MouseButtons.Left && keyData.KEY_LOCKED == false)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }

            // show and hide the key options when double-clicked
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
                toggleControls();

            // default snap settings (50% of key)
            keyData.KEY_SNAP_X = 50;
            keyData.KEY_SNAP_Y = 50;

            // load snap textboxes into keyData
            if (isNumber(snapXTextbox.Text, "int") == true && snapXTextbox.Text != "")
                keyData.KEY_SNAP_X = Int32.Parse(snapXTextbox.Text);
            if (isNumber(snapYTextbox.Text, "int") == true && snapYTextbox.Text != "")
                keyData.KEY_SNAP_Y = Int32.Parse(snapYTextbox.Text);

            // calculate snap grid
            double x_snap = Width * ((double)keyData.KEY_SNAP_X / 100);
            double y_snap = Height * ((double)keyData.KEY_SNAP_Y / 100);

            // calculate snap threshold
            double x_snap_location = Left * (1 / x_snap);
            double y_snap_location = Top * (1 / y_snap);

            // calculate floored snap location
            int x_location_new = (int)(Math.Floor(x_snap_location) * x_snap);
            int y_location_new = (int)(Math.Floor(y_snap_location) * y_snap);

            // snap form to new location
            Left = x_location_new;
            Top = y_location_new;

            tempLocX = Left;
            tempLocY = Top;

            keyData.KEY_LOCATION_X = Location.X;
            keyData.KEY_LOCATION_Y = Location.Y;

            // write changes to config
            writeConfig();
        }

        private void toggleControls()
        {
            if (closeButton.Visible == false)
                closeButton.Visible = true;
            else
                closeButton.Visible = false;

            if (lockButton.Visible == false)
                lockButton.Visible = true;
            else
                lockButton.Visible = false;

            if (snapXTextbox.Visible == false)
                snapXTextbox.Visible = true;
            else
                snapXTextbox.Visible = false;

            if (snapYTextbox.Visible == false)
                snapYTextbox.Visible = true;
            else
                snapYTextbox.Visible = false;
        }

        private void key_FormClosing(object sender, FormClosingEventArgs e)
        {
            handleClose();
        }

        private void handleClose()
        {
            keyPing.Enabled = false;

            if (useBackgroundImage == true)
                backgroundImage.Dispose();
            if (useBackgroundImagePressed == true)
                backgroundImagePressed.Dispose();

            Dispose();
        }

        private void key_MouseDown(object sender, MouseEventArgs e)
        {
            moveKey(e);
        }

        private void keyLabel_MouseDown(object sender, MouseEventArgs e)
        {
            moveKey(e);
        }

        private void countLabel_MouseDown(object sender, MouseEventArgs e)
        {
            moveKey(e);
        }
    }
}