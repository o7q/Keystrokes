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
        }

        private void key_Load(object sender, EventArgs e)
        {
            // format key with keyData
            Left = keyData.KEY_LOCATION_X;
            Top = keyData.KEY_LOCATION_Y;

            Size = new Size(keyData.keySizeX, keyData.keySizeY);
            keyLabel.Font = new Font(keyLabel.Font.Name, keyData.fontSize);

            Text = keyData.keyText;
            keyLabel.Text = keyData.keyText;
            keyLabel.Location = new Point((Width / 2) - (keyLabel.Width / 2), (Height / 2) - (keyLabel.Height / 2));

            closeButton.Visible = false;

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.FromArgb(255, keyData.keyColorR, keyData.keyColorG, keyData.keyColorB);
            keyLabel.ForeColor = Color.FromArgb(255, keyData.keyTextColorR, keyData.keyTextColorG, keyData.keyTextColorB);
            Opacity = keyData.keyOpacity;

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

                keyData.keyId = finalString;
            }

            writeConfig();

            // configure and start keyPing
            keyPing.Elapsed += new ElapsedEventHandler(keyRefresh);
            keyPing.Interval = 1;
            keyPing.Enabled = true;
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
                        // restore key color
                        BackColor = Color.FromArgb(255, keyData.keyColorR, keyData.keyColorG, keyData.keyColorB);
                        keyLabel.ForeColor = Color.FromArgb(255, keyData.keyTextColorR, keyData.keyTextColorG, keyData.keyTextColorB);
                    });
                }
                catch { }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("Keystrokes\\presets\\" + keyData.presetName) == true)
                File.Delete("Keystrokes\\presets\\" + keyData.presetName + "\\" + keyData.keyId + ".key");
            handleClose();
        }

        private void key_Paint(object sender, PaintEventArgs e)
        {
            int r = keyData.keyColorR - 50 < 0 ? 0 : keyData.keyColorR - 50;
            int g = keyData.keyColorG - 50 < 0 ? 0 : keyData.keyColorG - 50;
            int b = keyData.keyColorB - 50 < 0 ? 0 : keyData.keyColorB - 50;
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(255, r, g, b), keyData.keyBorder);
        }

        private void writeConfig()
        {
            // does the preset exist? if not, return
            if (Directory.Exists("Keystrokes\\presets\\" + keyData.presetName) == false) return;

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
                          Location.Y.ToString();

            File.WriteAllText("Keystrokes\\presets\\" + keyData.presetName + "\\" + keyData.keyId + ".key", config);
        }

        private void moveKey(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (closeButton.Visible == false)
                    closeButton.Visible = true;
                else
                    closeButton.Visible = false;
            }

            int x_snap_size = 50;
            int y_snap_size = 50;
            int x_snap_threshold = Width;
            int y_snap_threshold = Height;

            double x_snap = x_snap_threshold * ((double)x_snap_size / 100);
            double y_snap = y_snap_threshold * ((double)y_snap_size / 100);

            double x_snap_location = (Left - (x_snap_threshold / 2)) * (1 / x_snap);
            double y_snap_location = (Top - (y_snap_threshold / 2)) * (1 / y_snap);

            int x_location_new = (int)(Math.Floor(x_snap_location) * x_snap) + x_snap_threshold / 2;
            int y_location_new = (int)(Math.Floor(y_snap_location) * y_snap) + y_snap_threshold / 2;

            Left = x_location_new;
            Top = y_location_new;

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