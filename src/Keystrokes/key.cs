using System;
using System.IO;
using System.Timers;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Keystrokes.obj;
using static Keystrokes.obj.keyTools;

namespace Keystrokes
{
    public partial class key : Form
    {
        // configure mouse window events
        public const int HT_CAPTION = 0x2;
        public const int WM_NCLBUTTONDOWN = 0xA1;

        // grab dlls for mousedown
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        keyInfo keyData;

        System.Timers.Timer keyPing = new System.Timers.Timer();

        public key(keyInfo keyData_)
        {
            InitializeComponent();

            // load keyData_ into keyData
            keyData.presetName = keyData_.presetName;

            keyData.keyId = keyData_.keyId;

            keyData.keyText = keyData_.keyText;
            keyData.keyCode = keyData_.keyCode;

            keyData.keySizeX = keyData_.keySizeX;
            keyData.keySizeY = keyData_.keySizeY;

            keyData.fontSize = keyData_.fontSize;

            keyData.keyColorR = keyData_.keyColorR;
            keyData.keyColorG = keyData_.keyColorG;
            keyData.keyColorB = keyData_.keyColorB;

            keyData.keyTextColorR = keyData_.keyTextColorR;
            keyData.keyTextColorG = keyData_.keyTextColorG;
            keyData.keyTextColorB = keyData_.keyTextColorB;

            keyData.keyColorPressedR = keyData_.keyColorPressedR;
            keyData.keyColorPressedG = keyData_.keyColorPressedG;
            keyData.keyColorPressedB = keyData_.keyColorPressedB;
            keyData.keyColorPressedInvert = keyData_.keyColorPressedInvert;

            keyData.keyTextColorPressedR = keyData_.keyTextColorPressedR;
            keyData.keyTextColorPressedG = keyData_.keyTextColorPressedG;
            keyData.keyTextColorPressedB = keyData_.keyTextColorPressedB;
            keyData.keyTextColorPressedInvert = keyData_.keyTextColorPressedInvert;

            keyData.keyOpacity = keyData_.keyOpacity;

            keyData.keyBorder = keyData_.keyBorder;

            keyData.KEY_LOCATION_X = keyData_.KEY_LOCATION_X;
            keyData.KEY_LOCATION_Y = keyData_.KEY_LOCATION_Y;

            keyData.KEY_SNAP_X = keyData_.KEY_SNAP_X;
            keyData.KEY_SNAP_Y = keyData_.KEY_SNAP_Y;
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
            keyLabel.Text = keyData.keyText;
            keyLabel.Location = new Point((Width / 2) - (keyLabel.Width / 2), (Height / 2) - (keyLabel.Height / 2));

            // update snap textboxes
            snapXTextbox.Text = keyData.KEY_SNAP_X.ToString();
            snapYTextbox.Text = keyData.KEY_SNAP_Y.ToString();

            // hide components
            closeButton.Visible = false;
            snapXTextbox.Visible = false;
            snapYTextbox.Visible = false;

            // configure form color and opacity
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.FromArgb(255, keyData.keyColorR, keyData.keyColorG, keyData.keyColorB);
            keyLabel.ForeColor = Color.FromArgb(255, keyData.keyTextColorR, keyData.keyTextColorG, keyData.keyTextColorB);
            Opacity = keyData.keyOpacity;

            // draw over everything
            TopMost = true;

            // generate id for key if it doesn't have one
            if (keyData.keyId == null)
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var stringChars = new char[8];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                    stringChars[i] = chars[random.Next(chars.Length)];

                var finalString = new String(stringChars);

                keyData.keyId = keyData.keyText + "_" + finalString;
            }

            #region tooltipDictionary
            // bind tooltips
            string[] tooltipMap =
            {
                "closeButton", "Close",
                "snapXTextbox", "Snap X threshold (100 = one key width snap size)",
                "snapYTextbox", "Snap Y threshold (100 = one key height snap size)",
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
        }

        private void keyTooltip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        // do tick
        private void keyRefresh(object source, ElapsedEventArgs e)
        {
            // check for user key input
            if (keyDetect(keyData.keyCode) == true)
            {
                try
                {
                    Invoke((MethodInvoker)delegate
                    {
                        // update key colors
                        if (keyData.keyColorPressedInvert == true)
                            BackColor = Color.FromArgb(255, (byte)~keyData.keyColorR, (byte)~keyData.keyColorG, (byte)~keyData.keyColorB);
                        else
                            BackColor = Color.FromArgb(255, keyData.keyColorPressedR, keyData.keyColorPressedG, keyData.keyColorPressedB);

                        if (keyData.keyTextColorPressedInvert == true)
                            keyLabel.ForeColor = Color.FromArgb(255, (byte)~keyData.keyTextColorR, (byte)~keyData.keyTextColorG, (byte)~keyData.keyTextColorB);
                        else
                            keyLabel.ForeColor = Color.FromArgb(255, keyData.keyTextColorPressedR, keyData.keyTextColorPressedG, keyData.keyTextColorPressedB);
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
                        // restore key colors
                        BackColor = Color.FromArgb(255, keyData.keyColorR, keyData.keyColorG, keyData.keyColorB);
                        keyLabel.ForeColor = Color.FromArgb(255, keyData.keyTextColorR, keyData.keyTextColorG, keyData.keyTextColorB);
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

        private void key_Paint(object sender, PaintEventArgs e)
        {
            // draw custom key border
            int r = keyData.keyColorR - 50 < 0 ? 0 : keyData.keyColorR - 50;
            int g = keyData.keyColorG - 50 < 0 ? 0 : keyData.keyColorG - 50;
            int b = keyData.keyColorB - 50 < 0 ? 0 : keyData.keyColorB - 50;
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(255, r, g, b), keyData.keyBorder);
        }

        private void writeConfig()
        {
            // does the preset exist? if not, return
            if (Directory.Exists("Keystrokes\\presets\\" + keyData.presetName) == false) return;

            // write keyData to a designated key file
            string config = keyData.presetName + "|" +

                          keyData.keyId + "|" +

                          keyData.keyText + "|" +
                          keyData.keyCode.ToString() + "|" +

                          keyData.keySizeX.ToString() + "|" +
                          keyData.keySizeY.ToString() + "|" +

                          keyData.fontSize.ToString() + "|" +

                          keyData.keyColorR.ToString() + "|" +
                          keyData.keyColorG.ToString() + "|" +
                          keyData.keyColorB.ToString() + "|" +

                          keyData.keyTextColorR.ToString() + "|" +
                          keyData.keyTextColorG.ToString() + "|" +
                          keyData.keyTextColorB.ToString() + "|" +

                          keyData.keyColorPressedR.ToString() + "|" +
                          keyData.keyColorPressedG.ToString() + "|" +
                          keyData.keyColorPressedB.ToString() + "|" +
                          keyData.keyColorPressedInvert.ToString() + "|" +

                          keyData.keyTextColorPressedR.ToString() + "|" +
                          keyData.keyTextColorPressedG.ToString() + "|" +
                          keyData.keyTextColorPressedB.ToString() + "|" +
                          keyData.keyTextColorPressedInvert.ToString() + "|" +

                          keyData.keyOpacity.ToString() + "|" +

                          keyData.keyBorder.ToString() + "|" +

                          Location.X.ToString() + "|" +
                          Location.Y.ToString() + "|" +

                          snapXTextbox.Text + "|" +
                          snapYTextbox.Text;

            File.WriteAllText("Keystrokes\\presets\\" + keyData.presetName + "\\" + keyData.keyId + ".key", config);
        }

        private void moveKey(MouseEventArgs e)
        {
            // move form
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }

            // show and hide the key options when double-clicked
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (closeButton.Visible == false)
                    closeButton.Visible = true;
                else
                    closeButton.Visible = false;

                if (snapXTextbox.Visible == false)
                    snapXTextbox.Visible = true;
                else
                    snapXTextbox.Visible = false;

                if (snapYTextbox.Visible == false)
                    snapYTextbox.Visible = true;
                else
                    snapYTextbox.Visible = false;
            }

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

            // write changes to config
            writeConfig();
        }

        private void key_FormClosing(object sender, FormClosingEventArgs e)
        {
            handleClose();
        }

        private void handleClose()
        {
            keyPing.Enabled = false;
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
    }
}