using System;
using System.IO;
using System.Text;
using System.Timers;
using System.Drawing;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Media = System.Windows.Media;
using Keystrokes.Data;
using static Keystrokes.Tools.Numbers;
using static Keystrokes.Tools.Input.KeyInput;
using static Keystrokes.Tools.Input.ControllerInput;

namespace Keystrokes
{
    public partial class key : Form
    {
        // configure mouse window events
        public const int HT_CAPTION = 0x2;
        public const int WM_NCLBUTTONDOWN = 0xA1;

        // grab dlls for mousedown
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        KeyInfo keyData = new KeyInfo();

        System.Timers.Timer inputPing = new System.Timers.Timer();

        Image backgroundImage;
        Image backgroundImagePressed;
        bool useBackgroundImage = false;
        bool useBackgroundImagePressed = false;

        bool useSound = false;
        bool useSoundPressed = false;

        int wiggleModeTempLocX = 0;
        int wiggleModeTempLocY = 0;

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
            keyLabel.Font = new Font(keyData.keyFont, keyData.fontSize, keyData.fontStyle);
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
            controllerDebugLabel.Visible = false;
            controllerPanel.Visible = keyData.isControllerKey == true ? true : false;

            // draw over everything
            TopMost = true;

            // generate id for key if it doesn't have one
            if (keyData.keyId == null)
                keyData.keyId = keyData.keyCode + "_" + GenerateID(8);

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

            WriteConfig();

            // configure and start inputPing
            inputPing.Elapsed += new ElapsedEventHandler(InputRefresh);
            inputPing.Interval = 1;
            inputPing.Enabled = true;

            wiggleModeTempLocX = Left;
            wiggleModeTempLocY = Top;

            closeButton.Width = 26 * Width / 60;
            closeButton.Height = 26 * Height / 60;

            lockButton.Width = 26 * Width / 60;
            lockButton.Height = 26 * Height / 60;
            lockButton.Location = new Point(lockButton.Left, closeButton.Height);

            snapXTextbox.Location = new Point(closeButton.Width, snapXTextbox.Top);
            snapYTextbox.Location = new Point(closeButton.Width, snapYTextbox.Top);

            countLabel.Location = new Point(countLabel.Location.X, Height - 16);
            countLabel.ForeColor = Color.FromArgb(255, keyData.keyTextColorR, keyData.keyTextColorG, keyData.keyTextColorB);
            if (keyData.USE_KEY_COUNT == true)
            {
                countLabel.Visible = true;
                countLabel.Text = keyData.KEY_COUNT.ToString();
            }
            else
                countLabel.Visible = false;

            // configure controller panel
            controllerPanel.Width = Width;
            controllerPanel.Height = Height;
            controllerPanel.Location = new Point((Width / 2) - (controllerPanel.Width / 2), (Height / 2) - (controllerPanel.Height / 2));
            controllerPanel.BackColor = Color.Transparent;
            controllerPanel.BackgroundImageLayout = ImageLayout.None;
            controllerPanel.SendToBack();

            Random random_rgb = new Random();
            keyData.transparencyKeyR = keyData.transparencyKeyR == 0 ? random_rgb.Next(256) / 5 : keyData.transparencyKeyR;
            keyData.transparencyKeyG = keyData.transparencyKeyG == 0 ? random_rgb.Next(256) / 5 : keyData.transparencyKeyG;
            keyData.transparencyKeyB = keyData.transparencyKeyB == 0 ? random_rgb.Next(256) / 5 : keyData.transparencyKeyB;

            // update key colors
            if (keyData.useTransparentBackground == true)
            {
                BackColor = Color.FromArgb(255, keyData.transparencyKeyR, keyData.transparencyKeyG, keyData.transparencyKeyB);
                TransparencyKey = Color.FromArgb(255, keyData.transparencyKeyR, keyData.transparencyKeyG, keyData.transparencyKeyB);
            }

            // fix flickering issue
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, controllerPanel, new object[] { true });
        }
        // hide in task manager
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x80; // turn on WS_EX_TOOLWINDOW
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
            int r = keyData.keyColorR / 5;
            int g = keyData.keyColorG / 5;
            int b = keyData.keyColorB / 5;
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(255, r, g, b), keyData.keyBorder);
        }

        bool keyPressed = false;
        private void InputRefresh(object source, ElapsedEventArgs e)
        {
            #region CONTROLLER_JOYSTICK
            if (keyData.keyCode == "CONTROLLER_LEFT_JOYSTICK" || keyData.keyCode == "CONTROLLER_RIGHT_JOYSTICK")
            {
                var joystick_state = CalculateJoystick(keyData.keyCode);
                int x = (int)(controllerPanel.Width / 5 * joystick_state.Item1);
                int y = (int)(controllerPanel.Height / 5 * joystick_state.Item2);
                float rotate = joystick_state.Item3;

                try
                {
                    Invoke((MethodInvoker)delegate
                    {
                        controllerDebugLabel.Text = rotate.ToString();
                        controllerDebugLabel.Location = new Point(Width - controllerDebugLabel.Width, Height - controllerDebugLabel.Height);
                    });
                }
                catch { }

                int r = keyData.keyTextColorR;
                int g = keyData.keyTextColorG;
                int b = keyData.keyTextColorB;

                if (KeyDetect(keyData.keyCode, keyData.isControllerKey) == true)
                {
                    if (keyData.USE_KEY_COUNT == true && keyPressed == false)
                    {
                        keyData.KEY_COUNT++;
                        try
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                countLabel.Text = keyData.KEY_COUNT.ToString();
                            });
                        } catch { }
                        WriteConfig();
                    }

                    keyPressed = true;

                    // update key colors
                    if (keyData.useTransparentBackground == true)
                    {
                        BackColor = Color.FromArgb(255, keyData.transparencyKeyR, keyData.transparencyKeyG, keyData.transparencyKeyB);
                        try
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                TransparencyKey = Color.FromArgb(255, keyData.transparencyKeyR, keyData.transparencyKeyG, keyData.transparencyKeyB);
                            });
                        } catch { }
                    }
                    else
                    {
                        if (keyData.keyColorPressedInvert == true)
                            BackColor = Color.FromArgb(255, (byte)~keyData.keyColorR, (byte)~keyData.keyColorG, (byte)~keyData.keyColorB);
                        else
                            BackColor = Color.FromArgb(255, keyData.keyColorPressedR, keyData.keyColorPressedG, keyData.keyColorPressedB);
                    }

                    if (keyData.keyTextColorPressedInvert == true)
                    {
                        r = (byte)~keyData.keyTextColorR;
                        g = (byte)~keyData.keyTextColorG;
                        b = (byte)~keyData.keyTextColorB;
                        countLabel.ForeColor = Color.FromArgb(255, (byte)~keyData.keyTextColorR, (byte)~keyData.keyTextColorG, (byte)~keyData.keyTextColorB);
                    }
                    else
                    {
                        r = keyData.keyTextColorPressedR;
                        g = keyData.keyTextColorPressedG;
                        b = keyData.keyTextColorPressedB;
                        countLabel.ForeColor = Color.FromArgb(255, keyData.keyTextColorPressedR, keyData.keyTextColorPressedG, keyData.keyTextColorPressedB);
                    }
                }
                else
                {
                    // restore key colors
                    if (keyData.useTransparentBackground == true)
                    {
                        BackColor = Color.FromArgb(255, keyData.transparencyKeyR, keyData.transparencyKeyG, keyData.transparencyKeyB);
                        try
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                TransparencyKey = Color.FromArgb(255, keyData.transparencyKeyR, keyData.transparencyKeyG, keyData.transparencyKeyB);
                            });
                        }
                        catch { }
                    }
                    else
                        BackColor = Color.FromArgb(255, keyData.keyColorR, keyData.keyColorG, keyData.keyColorB);

                    r = keyData.keyTextColorR;
                    g = keyData.keyTextColorG;
                    b = keyData.keyTextColorB;
                    countLabel.ForeColor = Color.FromArgb(255, keyData.keyTextColorR, keyData.keyTextColorG, keyData.keyTextColorB);

                    keyPressed = false;
                }

                float size = 1.25f;
                float size_background = 2.5f;

                Bitmap joystick_image = new Bitmap(controllerPanel.Width, controllerPanel.Height);
                using (Graphics graphics = Graphics.FromImage(joystick_image))
                {
                    SolidBrush joystick_background = new SolidBrush(Color.FromArgb(255, r / 2 + 15, g / 2 + 15, b / 2 + 15));
                    int x_loc = (controllerPanel.Width / 2) - (int)(controllerPanel.Width / (size * 2));
                    int y_loc = (controllerPanel.Height / 2) - (int)(controllerPanel.Height / (size * 2));
                    graphics.FillEllipse(joystick_background, new Rectangle(x_loc, y_loc, (int)(controllerPanel.Width / size), (int)(controllerPanel.Height / size)));

                    SolidBrush joystick = new SolidBrush(Color.FromArgb(255, r, g, b));
                    x_loc = x + controllerPanel.Width / 2 - (int)(controllerPanel.Width / (size_background * 2));
                    y_loc = y + controllerPanel.Height / 2 - (int)(controllerPanel.Height / (size_background * 2));
                    graphics.FillEllipse(joystick, new Rectangle(x_loc, y_loc, (int)(controllerPanel.Width / size_background), (int)(controllerPanel.Height / size_background)));
                }

                try
                {
                    Invoke((MethodInvoker)delegate
                    {
                        controllerPanel.BackgroundImage = joystick_image;
                    });
                }
                catch { }

                return;
            }
            #endregion

            #region CONTROLLER_TRIGGER
            if (keyData.keyCode == "CONTROLLER_LEFT_TRIGGER" || keyData.keyCode == "CONTROLLER_RIGHT_TRIGGER")
            {
                float trigger_state = CalculateTrigger(keyData.keyCode);

                int r = keyData.keyTextColorR;
                int g = keyData.keyTextColorG;
                int b = keyData.keyTextColorB;

                if (keyData.keyTextColorPressedInvert == true)
                {
                    r = (byte)~keyData.keyTextColorR;
                    g = (byte)~keyData.keyTextColorG;
                    b = (byte)~keyData.keyTextColorB;
                }
                else
                {
                    r = keyData.keyTextColorPressedR;
                    g = keyData.keyTextColorPressedG;
                    b = keyData.keyTextColorPressedB;
                }

                int x_size = controllerPanel.Width;
                int y_size = controllerPanel.Height;

                Bitmap trigger_image = new Bitmap(controllerPanel.Width, controllerPanel.Height);
                using (Graphics graphics = Graphics.FromImage(trigger_image))
                {
                    SolidBrush trigger_top = new SolidBrush(Color.FromArgb(255, (int)(r * trigger_state), (int)(g * trigger_state), (int)(b * trigger_state)));
                    int x_loc = x_size / 2 - x_size / 4;
                    int y_loc = y_size / 2 - y_size / 4 - y_size / 8;
                    graphics.FillEllipse(trigger_top, new Rectangle(x_loc, y_loc, x_size / 2, y_size / 2));

                    SolidBrush trigger_bottom = new SolidBrush(Color.FromArgb(255, (int)(r * trigger_state), (int)(g * trigger_state), (int)(b * trigger_state)));
                    x_loc = x_size / 2 - x_size / 4;
                    y_loc = y_size / 2 - y_size / 4 + y_size / 8;
                    graphics.FillRectangle(trigger_bottom, new Rectangle(x_loc, y_loc, x_size / 2, y_size / 2));
                }
                try
                {
                    Invoke((MethodInvoker)delegate
                    {
                        controllerPanel.BackgroundImage = trigger_image;
                    });
                } catch { }
            }
            #endregion

            #region CONTROLLER_DPAD
            if (keyData.keyCode == "CONTROLLER_DPAD")
            {
                string dpad_state = CalculateDpad();

                int r_up = keyData.keyTextColorR;
                int g_up = keyData.keyTextColorG;
                int b_up = keyData.keyTextColorB;
                int r_down = keyData.keyTextColorR;
                int g_down = keyData.keyTextColorG;
                int b_down = keyData.keyTextColorB;
                int r_left = keyData.keyTextColorR;
                int g_left = keyData.keyTextColorG;
                int b_left = keyData.keyTextColorB;
                int r_right = keyData.keyTextColorR;
                int g_right = keyData.keyTextColorG;
                int b_right = keyData.keyTextColorB;

                if (keyData.keyTextColorPressedInvert == true)
                {
                    switch (dpad_state)
                    {
                        case "up":
                            r_up = (byte)~keyData.keyTextColorR;
                            g_up = (byte)~keyData.keyTextColorG;
                            b_up = (byte)~keyData.keyTextColorB;
                            break;
                        case "down":
                            r_down = (byte)~keyData.keyTextColorR;
                            g_down = (byte)~keyData.keyTextColorG;
                            b_down = (byte)~keyData.keyTextColorB;
                            break;
                        case "left":
                            r_left = (byte)~keyData.keyTextColorR;
                            g_left = (byte)~keyData.keyTextColorG;
                            b_left = (byte)~keyData.keyTextColorB;
                            break;
                        case "right":
                            r_right = (byte)~keyData.keyTextColorR;
                            g_right = (byte)~keyData.keyTextColorG;
                            b_right = (byte)~keyData.keyTextColorB;
                            break;
                    }
                }
                else
                {
                    switch (dpad_state)
                    {
                        case "up":
                            r_up = keyData.keyTextColorPressedR;
                            g_up = keyData.keyTextColorPressedG;
                            b_up = keyData.keyTextColorPressedB;
                            break;
                        case "down":
                            r_down = keyData.keyTextColorPressedR;
                            g_down = keyData.keyTextColorPressedG;
                            b_down = keyData.keyTextColorPressedB;
                            break;
                        case "left":
                            r_left = keyData.keyTextColorPressedR;
                            g_left = keyData.keyTextColorPressedG;
                            b_left = keyData.keyTextColorPressedB;
                            break;
                        case "right":
                            r_right = keyData.keyTextColorPressedR;
                            g_right = keyData.keyTextColorPressedG;
                            b_right = keyData.keyTextColorPressedB;
                            break;
                    }
                }

                int x_size = controllerPanel.Width / 2;
                int y_size = controllerPanel.Height / 2;

                Bitmap dpad_image = new Bitmap(controllerPanel.Width, controllerPanel.Height);
                using (Graphics graphics = Graphics.FromImage(dpad_image))
                {
                    SolidBrush dpad_up = new SolidBrush(Color.FromArgb(255, r_up, g_up, b_up));
                    int x_loc = x_size / 2 + x_size / 4;
                    int y_loc = y_size / 2 + y_size / 4 - y_size / 2;
                    graphics.FillRectangle(dpad_up, new Rectangle(x_loc, y_loc, x_size / 2, y_size / 2));

                    SolidBrush dpad_down = new SolidBrush(Color.FromArgb(255, r_down, g_down, b_down));
                    x_loc = x_size / 2 + x_size / 4;
                    y_loc = y_size / 2 + y_size / 4 + y_size / 2;
                    graphics.FillRectangle(dpad_down, new Rectangle(x_loc, y_loc, x_size / 2, y_size / 2));

                    SolidBrush dpad_left = new SolidBrush(Color.FromArgb(255, r_left, g_left, b_left));
                    x_loc = x_size / 2 + x_size / 4 - x_size / 2;
                    y_loc = y_size / 2 + y_size / 4;
                    graphics.FillRectangle(dpad_left, new Rectangle(x_loc, y_loc, x_size / 2, y_size / 2));

                    SolidBrush dpad_right = new SolidBrush(Color.FromArgb(255, r_right, g_right, b_right));
                    x_loc = x_size / 2 + x_size / 4 + x_size / 2;
                    y_loc = y_size / 2 + y_size / 4;
                    graphics.FillRectangle(dpad_right, new Rectangle(x_loc, y_loc, x_size / 2, y_size / 2));

                    SolidBrush dpad_center = new SolidBrush(Color.FromArgb(255, keyData.keyColorR, keyData.keyColorG, keyData.keyColorB));
                    x_loc = x_size / 2 + x_size / 4;
                    y_loc = y_size / 2 + y_size / 4;
                    graphics.FillRectangle(dpad_center, new Rectangle(x_loc, y_loc, x_size / 2, y_size / 2));
                }

                try
                {
                    Invoke((MethodInvoker)delegate
                    {
                        controllerPanel.BackgroundImage = dpad_image;
                    });
                }
                catch { }
            }
            #endregion

            #region SIMPLE_INPUT
            // check for user key input
            if (KeyDetect(keyData.keyCode, keyData.isControllerKey) == true)
            {
                WiggleMode_wiggle();

                if (keyPressed == true)
                    return;
                keyPressed = true;

                if (keyData.USE_KEY_COUNT == true)
                {
                    keyData.KEY_COUNT++;
                    try
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            countLabel.Text = keyData.KEY_COUNT.ToString();
                        });
                    }
                    catch { }
                    WriteConfig();
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
                if (keyData.useTransparentBackground == true)
                {
                    BackColor = Color.FromArgb(255, keyData.transparencyKeyR, keyData.transparencyKeyG, keyData.transparencyKeyB);
                    try
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            TransparencyKey = Color.FromArgb(255, keyData.transparencyKeyR, keyData.transparencyKeyG, keyData.transparencyKeyB);
                        });
                    } catch { }
                }
                else
                {
                    if (keyData.keyColorPressedInvert == true)
                        BackColor = Color.FromArgb(255, (byte)~keyData.keyColorR, (byte)~keyData.keyColorG, (byte)~keyData.keyColorB);
                    else
                        BackColor = Color.FromArgb(255, keyData.keyColorPressedR, keyData.keyColorPressedG, keyData.keyColorPressedB);
                }

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
            }
            else
            {
                if (keyPressed == false)
                    return;
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
                if (keyData.useTransparentBackground == true)
                {
                    BackColor = Color.FromArgb(255, keyData.transparencyKeyR, keyData.transparencyKeyG, keyData.transparencyKeyB);
                    try
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            TransparencyKey = Color.FromArgb(255, keyData.transparencyKeyR, keyData.transparencyKeyG, keyData.transparencyKeyB);
                        });
                    } catch { }
                }
                else
                    BackColor = Color.FromArgb(255, keyData.keyColorR, keyData.keyColorG, keyData.keyColorB);

                keyLabel.ForeColor = Color.FromArgb(255, keyData.keyTextColorR, keyData.keyTextColorG, keyData.keyTextColorB);
                countLabel.ForeColor = Color.FromArgb(255, keyData.keyTextColorR, keyData.keyTextColorG, keyData.keyTextColorB);

                WiggleMode_return();
            }
            #endregion
        }
        private void WiggleMode_wiggle()
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
                            case 2: Left -= 1 + keyData.wiggleMode_biasLeft; break;
                            case 3: Left += 1 + keyData.wiggleMode_biasRight; break;
                        }
                    }
                });
            } catch { }
        }
        private void WiggleMode_return()
        {
            try
            {
                Invoke((MethodInvoker)delegate
                {
                    if (keyData.wiggleMode == true && keyPressed == false)
                    {
                        keyPressed = false;
                        int startX = Location.X;
                        int startY = Location.Y;
                        int endX = wiggleModeTempLocX;
                        int endY = wiggleModeTempLocY;
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

                        Left = wiggleModeTempLocX;
                        Top = wiggleModeTempLocY;
                    }
                });
            } catch { }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            // does preset exist? if yes, delete the key file
            if (Directory.Exists("Keystrokes\\presets\\" + keyData.presetName) == true)
                File.Delete("Keystrokes\\presets\\" + keyData.presetName + "\\" + keyData.keyId + ".key");
            HandleClose();
        }

        private void lockButton_Click(object sender, EventArgs e)
        {
            if (keyData.KEY_LOCKED == false)
                keyData.KEY_LOCKED = true;
            else
                keyData.KEY_LOCKED = false;

            ToggleControls();
            WriteConfig();
        }

        private void snapXTextbox_TextChanged(object sender, EventArgs e)
        {
            if (IsNumber(snapXTextbox.Text, "int") == false)
                return;
            keyData.KEY_SNAP_X = int.Parse(snapXTextbox.Text);
        }

        private void snapYTextbox_TextChanged(object sender, EventArgs e)
        {
            if (IsNumber(snapYTextbox.Text, "int") == false)
                return;
            keyData.KEY_SNAP_Y = int.Parse(snapYTextbox.Text);
        }

        private void WriteConfig()
        {
            if (IsNumber(snapXTextbox.Text, "int") == false || snapXTextbox.Text == "")
                snapXTextbox.Text = "50";
            if (IsNumber(snapYTextbox.Text, "int") == false || snapYTextbox.Text == "")
                snapYTextbox.Text = "50";

            // does the preset exist? if not, return
            if (Directory.Exists("Keystrokes\\presets\\" + keyData.presetName) == false)
                return;
            
            // write keyData to a designated key file
            var sb = new StringBuilder();
            foreach (var field in typeof(KeyInfo).GetFields())
            {
                object value = field.GetValue(keyData);
                if (value != null)
                    sb.Append(field.Name + "¶" + value.ToString());
                sb.Append("\n");
            }
            sb.Length--;
            string config = sb.ToString();

            File.WriteAllText("Keystrokes\\presets\\" + keyData.presetName + "\\" + keyData.keyId + ".key", config);
        }

        private void MoveKey(MouseEventArgs e)
        {
            // move form
            if (e.Button == MouseButtons.Left && keyData.KEY_LOCKED == false)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }

            // show and hide the key options when double-clicked
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
                ToggleControls();

            // default snap settings (50% of key)
            keyData.KEY_SNAP_X = 50;
            keyData.KEY_SNAP_Y = 50;

            // load snap textboxes into keyData
            if (IsNumber(snapXTextbox.Text, "int") == true && snapXTextbox.Text != "")
                keyData.KEY_SNAP_X = int.Parse(snapXTextbox.Text);
            if (IsNumber(snapYTextbox.Text, "int") == true && snapYTextbox.Text != "")
                keyData.KEY_SNAP_Y = int.Parse(snapYTextbox.Text);

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

            wiggleModeTempLocX = Left;
            wiggleModeTempLocY = Top;

            keyData.KEY_LOCATION_X = Location.X;
            keyData.KEY_LOCATION_Y = Location.Y;

            // write changes to config
            WriteConfig();
        }

        private void ToggleControls()
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

            if (controllerDebugLabel.Visible == false)
                controllerDebugLabel.Visible = true;
            else
                controllerDebugLabel.Visible = false;
        }

        private void key_FormClosing(object sender, FormClosingEventArgs e)
        {
            HandleClose();
        }

        private void HandleClose()
        {
            inputPing.Enabled = false;

            if (useBackgroundImage == true)
                backgroundImage.Dispose();
            if (useBackgroundImagePressed == true)
                backgroundImagePressed.Dispose();

            Dispose();
        }

        private void key_MouseDown(object sender, MouseEventArgs e)
        {
            MoveKey(e);
        }

        private void keyLabel_MouseDown(object sender, MouseEventArgs e)
        {
            MoveKey(e);
        }

        private void countLabel_MouseDown(object sender, MouseEventArgs e)
        {
            MoveKey(e);
        }

        private void controllerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            MoveKey(e);
        }

        private void controllerDebugLabel_MouseDown(object sender, MouseEventArgs e)
        {
            MoveKey(e);
        }
    }
}