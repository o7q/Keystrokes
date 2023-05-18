using System;
using System.IO;
using System.Text;
using System.Timers;
using System.Drawing;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using Media = System.Windows.Media;
using Keystrokes.Data;
using Keystrokes.Tools.CustomMessageBox;
using static Keystrokes.Tools.Forms;
using static Keystrokes.Data.Storage;
using static Keystrokes.Tools.Numbers;
using static Keystrokes.Tools.Input.KeyInput;
using static Keystrokes.Tools.Input.ControllerInput;

namespace Keystrokes
{
    public partial class Key : Form
    {
        KeyInfo keyData = new KeyInfo();

        readonly System.Timers.Timer inputPing = new System.Timers.Timer();
        readonly System.Timers.Timer secPing = new System.Timers.Timer();

        Image backgroundImage;
        Image backgroundImagePressed;
        bool useBackgroundImage = false;
        bool useBackgroundImagePressed = false;

        readonly Media.MediaPlayer sound = new Media.MediaPlayer();
        readonly Media.MediaPlayer soundPressed = new Media.MediaPlayer();

        bool useSound = false;
        bool useSoundPressed = false;

        int wiggleModeLocationX_temp = 0;
        int wiggleModeLocationY_temp = 0;

        public Key(KeyInfo keyData_)
        {
            InitializeComponent();

            // load keyData_ into keyData
            keyData = keyData_;
            keyData.VERSION = VERSION;
        }

        private void Key_Load(object sender, EventArgs e)
        {
            #region guiConfig
            // format key with keyData
            Left = keyData.KEY_LOCATION_X;
            Top = keyData.KEY_LOCATION_Y;
            wiggleModeLocationX_temp = Left;
            wiggleModeLocationY_temp = Top;
            mouseLocationX_previous = Cursor.Position.X;
            mouseLocationY_previous = Cursor.Position.Y;

            // set form and font size
            Size = new Size(keyData.keySizeX, keyData.keySizeY);
            try
            {
                KeyLabel.Font = new Font(KeyLabel.Font.Name, keyData.keyFontSize);
            } catch { }

            // update text
            Text = keyData.keyText;
            KeyLabel.Text = keyData.displayText == true ? keyData.keyText : "";
            KeyLabel.Font = new Font(keyData.keyFont, keyData.keyFontSize, keyData.keyFontStyle);
            KeyLabel.Location = new Point((Width / 2) - (KeyLabel.Width / 2), (Height / 2) - (KeyLabel.Height / 2));
            // update snap textboxes
            SnapXTextbox.Text = keyData.KEY_SNAP_X.ToString();
            SnapYTextbox.Text = keyData.KEY_SNAP_Y.ToString();

            // configure form color and opacity
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.FromArgb(255, keyData.keyColorR, keyData.keyColorG, keyData.keyColorB);
            KeyLabel.ForeColor = Color.FromArgb(255, keyData.keyTextColorR, keyData.keyTextColorG, keyData.keyTextColorB);
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

            if (keyData.keySound != null && keyData.keySound != "")
                useSound = true;
            if (keyData.keySoundPressed != null && keyData.keySoundPressed != "")
                useSoundPressed = true;

            // generate id for key if it doesn't have one
            if (keyData.keyId == null)
                keyData.keyId = keyData.keyCode + "_" + GenerateID(8);

            Random random_nickname = new Random();
            int index = random_nickname.Next(key_names.Length);
            keyData.KEY_NICKNAME = (keyData.KEY_NICKNAME == null || keyData.KEY_NICKNAME == "") ? key_names[index] : keyData.KEY_NICKNAME;

            #region configureComponents
            // hide components
            CloseButton.Visible = false;
            LockButton.Visible = false;
            StatsButton.Visible = false;
            SnapXTextbox.Visible = false;
            SnapYTextbox.Visible = false;
            ControllerDebugLabel.Visible = false;
            ControllerPanel.Visible = keyData.isControllerKey == true ? true : false;

            CloseButton.Width = 20 * Width / 60;
            CloseButton.Height = 20 * Height / 60;

            LockButton.Width = 20 * Width / 60;
            LockButton.Height = 20 * Height / 60;
            LockButton.Location = new Point(LockButton.Left, CloseButton.Height);

            StatsButton.Width = 20 * Width / 60;
            StatsButton.Height = 20 * Height / 60;
            StatsButton.Location = new Point(StatsButton.Left, CloseButton.Height + LockButton.Height);

            SnapXTextbox.Location = new Point(CloseButton.Width, SnapXTextbox.Top);
            SnapYTextbox.Location = new Point(CloseButton.Width, SnapYTextbox.Top);

            CpsLabel.Location = new Point(CpsLabel.Location.X, Height - 16);
            CpsLabel.ForeColor = Color.FromArgb(255, keyData.keyTextColorR, keyData.keyTextColorG, keyData.keyTextColorB);
            if (keyData.displayCps == true)
                CpsLabel.Visible = true;
            else
                CpsLabel.Visible = false;

            // configure controller panel
            ControllerPanel.Width = Width;
            ControllerPanel.Height = Height;
            ControllerPanel.Location = new Point((Width / 2) - (ControllerPanel.Width / 2), (Height / 2) - (ControllerPanel.Height / 2));
            ControllerPanel.BackColor = Color.Transparent;
            ControllerPanel.BackgroundImageLayout = ImageLayout.None;
            ControllerPanel.SendToBack();
            #endregion

            #region configureTransparencyKey
            Random random_rgb = new Random();
            keyData.keyTransparencyKeyR = keyData.keyTransparencyKeyR == 0 ? random_rgb.Next(256) / 5 : keyData.keyTransparencyKeyR;
            keyData.keyTransparencyKeyG = keyData.keyTransparencyKeyG == 0 ? random_rgb.Next(256) / 5 : keyData.keyTransparencyKeyG;
            keyData.keyTransparencyKeyB = keyData.keyTransparencyKeyB == 0 ? random_rgb.Next(256) / 5 : keyData.keyTransparencyKeyB;

            // update key colors
            if (keyData.useTransparentBackground == true)
            {
                BackColor = Color.FromArgb(255, keyData.keyTransparencyKeyR, keyData.keyTransparencyKeyG, keyData.keyTransparencyKeyB);
                TransparencyKey = Color.FromArgb(255, keyData.keyTransparencyKeyR, keyData.keyTransparencyKeyG, keyData.keyTransparencyKeyB);
            }
            #endregion

            // fix flickering issue
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, ControllerPanel, new object[] { true });

            // draw over everything
            TopMost = true;

            #region tooltipDictionary
            // bind tooltips
            string[] tooltipMap =
            {
                "CloseButton", "Close",
                "LockButton", "Lock the key and prevent mouse interaction",
                "StatsButton", "Open the key stats window",
                "SnapXTextbox", "Snap X threshold (50 = one half key width snap size)",
                "SnapYTextbox", "Snap Y threshold (50 = one half key height snap size)",
            };
            #endregion

            // configure tooltips
            for (int i = 0; i < tooltipMap.Length; i += 2)
                KeyToolTip.SetToolTip(Controls.Find(tooltipMap[i], true)[0], tooltipMap[i + 1]);

            // configure tooltip draw
            KeyToolTip.AutoPopDelay = 10000;
            KeyToolTip.OwnerDraw = true;
            KeyToolTip.BackColor = Color.FromArgb(0, 0, 0);
            KeyToolTip.ForeColor = Color.FromArgb(255, 255, 255);
            #endregion

            WriteConfig();

            // configure and start inputPing
            inputPing.Elapsed += new ElapsedEventHandler(InputRefresh);
            inputPing.Interval = keyData.keyRefreshRate;
            inputPing.Enabled = true;

            // configure and start secPing
            secPing.Elapsed += new ElapsedEventHandler(secRefresh);
            secPing.Interval = 1000;
            secPing.Enabled = true;
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

        private void KeyTooltip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void Key_Paint(object sender, PaintEventArgs e)
        {
            // draw custom key border
            int r = keyData.keyColorR / 5;
            int g = keyData.keyColorG / 5;
            int b = keyData.keyColorB / 5;
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(255, r, g, b), keyData.keyBorder);
        }

        float rotate_previous;
        bool keyPressed = false;

        int mouseLocationX_previous;
        int mouseLocationY_previous;

        string dpadState_previous = "";
        private void InputRefresh(object source, ElapsedEventArgs e)
        {
            if ((Math.Abs(Cursor.Position.X - mouseLocationX_previous) + Math.Abs(Cursor.Position.Y - mouseLocationY_previous)) != 0)
            {
                keyData.MOUSE_PIXEL_DISTANCE += Math.Abs(Cursor.Position.X - mouseLocationX_previous) + Math.Abs(Cursor.Position.Y - mouseLocationY_previous);
                mouseLocationX_previous = Cursor.Position.X;
                mouseLocationY_previous = Cursor.Position.Y;
            }

            #region CONTROLLER_JOYSTICK
            if (keyData.keyCode == "CONTROLLER_LEFT_JOYSTICK" || keyData.keyCode == "CONTROLLER_RIGHT_JOYSTICK")
            {
                var joystick_state = CalculateJoystick(keyData.keyCode);
                int x = (int)(ControllerPanel.Width / 5 * joystick_state.Item1);
                int y = (int)(ControllerPanel.Height / 5 * joystick_state.Item2);
                float rotate = joystick_state.Item3;

                if (Math.Abs(rotate_previous - rotate) > 10)
                {
                    keyData.JOYSTICK_ANGLE_SUM += 10;
                    rotate_previous = rotate;
                }

                try
                {
                    Invoke((MethodInvoker)delegate
                    {
                        ControllerDebugLabel.Text = rotate.ToString();
                        ControllerDebugLabel.Location = new Point(Width - ControllerDebugLabel.Width, Height - ControllerDebugLabel.Height);
                    });
                } catch { }

                int r = keyData.keyTextColorR;
                int g = keyData.keyTextColorG;
                int b = keyData.keyTextColorB;

                if (KeyDetect(keyData.keyCode, keyData.isControllerKey) == true)
                {
                    if (keyPressed == false)
                    {
                        clicks++;
                        clicks_total++;
                        keyData.KEY_PRESSED_AMOUNT++;
                    }

                    keyPressed = true;

                    // update key colors
                    if (keyData.useTransparentBackground == true)
                    {
                        BackColor = Color.FromArgb(255, keyData.keyTransparencyKeyR, keyData.keyTransparencyKeyG, keyData.keyTransparencyKeyB);
                        try
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                TransparencyKey = Color.FromArgb(255, keyData.keyTransparencyKeyR, keyData.keyTransparencyKeyG, keyData.keyTransparencyKeyB);
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
                        CpsLabel.ForeColor = Color.FromArgb(255, (byte)~keyData.keyTextColorR, (byte)~keyData.keyTextColorG, (byte)~keyData.keyTextColorB);
                    }
                    else
                    {
                        r = keyData.keyTextColorPressedR;
                        g = keyData.keyTextColorPressedG;
                        b = keyData.keyTextColorPressedB;
                        CpsLabel.ForeColor = Color.FromArgb(255, keyData.keyTextColorPressedR, keyData.keyTextColorPressedG, keyData.keyTextColorPressedB);
                    }
                }
                else
                {
                    // restore key colors
                    if (keyData.useTransparentBackground == true)
                    {
                        BackColor = Color.FromArgb(255, keyData.keyTransparencyKeyR, keyData.keyTransparencyKeyG, keyData.keyTransparencyKeyB);
                        try
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                TransparencyKey = Color.FromArgb(255, keyData.keyTransparencyKeyR, keyData.keyTransparencyKeyG, keyData.keyTransparencyKeyB);
                            });
                        } catch { }
                    }
                    else
                        BackColor = Color.FromArgb(255, keyData.keyColorR, keyData.keyColorG, keyData.keyColorB);

                    r = keyData.keyTextColorR;
                    g = keyData.keyTextColorG;
                    b = keyData.keyTextColorB;
                    CpsLabel.ForeColor = Color.FromArgb(255, keyData.keyTextColorR, keyData.keyTextColorG, keyData.keyTextColorB);

                    keyPressed = false;
                }

                float size = 2.5f;
                float size_background = 1.25f;

                Bitmap joystick_image = new Bitmap(ControllerPanel.Width, ControllerPanel.Height);
                using (Graphics graphics = Graphics.FromImage(joystick_image))
                {
                    SolidBrush joystick_background = new SolidBrush(Color.FromArgb(255, r / 2 + 15, g / 2 + 15, b / 2 + 15));
                    int x_loc = (ControllerPanel.Width / 2) - (int)(ControllerPanel.Width / (size_background * 2));
                    int y_loc = (ControllerPanel.Height / 2) - (int)(ControllerPanel.Height / (size_background * 2));
                    graphics.FillEllipse(joystick_background, new Rectangle(x_loc, y_loc, (int)(ControllerPanel.Width / size_background), (int)(ControllerPanel.Height / size_background)));

                    SolidBrush joystick = new SolidBrush(Color.FromArgb(255, r, g, b));
                    x_loc = x + ControllerPanel.Width / 2 - (int)(ControllerPanel.Width / (size * 2));
                    y_loc = y + ControllerPanel.Height / 2 - (int)(ControllerPanel.Height / (size * 2));
                    graphics.FillEllipse(joystick, new Rectangle(x_loc, y_loc, (int)(ControllerPanel.Width / size), (int)(ControllerPanel.Height / size)));
                }

                try
                {
                    Invoke((MethodInvoker)delegate
                    {
                        ControllerPanel.BackgroundImage = joystick_image;
                    });
                } catch { }

                return;
            }
            #endregion

            #region CONTROLLER_TRIGGER
            if (keyData.keyCode == "CONTROLLER_LEFT_TRIGGER" || keyData.keyCode == "CONTROLLER_RIGHT_TRIGGER")
            {
                float trigger_state = CalculateTrigger(keyData.keyCode);

                if (trigger_state > 0.5 && keyPressed == false)
                {
                    clicks++;
                    clicks_total++;
                    keyData.KEY_PRESSED_AMOUNT++;

                    keyPressed = true;
                }
                if (trigger_state < 0.5)
                    keyPressed = false;

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

                int x_size = ControllerPanel.Width;
                int y_size = ControllerPanel.Height;

                Bitmap trigger_image = new Bitmap(ControllerPanel.Width, ControllerPanel.Height);
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
                        ControllerPanel.BackgroundImage = trigger_image;
                    });
                } catch { }

                return;
            }
            #endregion

            #region CONTROLLER_DPAD
            if (keyData.keyCode == "CONTROLLER_DPAD")
            {
                string dpadState = CalculateDpad();

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

                if (dpadState_previous != dpadState && dpadState_previous != "")
                {
                    clicks++;
                    clicks_total++;
                    keyData.KEY_PRESSED_AMOUNT++;
                }
                dpadState_previous = dpadState;

                if (keyData.keyTextColorPressedInvert == true)
                {
                    switch (dpadState)
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
                    switch (dpadState)
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

                int x_size = ControllerPanel.Width / 2;
                int y_size = ControllerPanel.Height / 2;

                Bitmap dpad_image = new Bitmap(ControllerPanel.Width, ControllerPanel.Height);
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
                        ControllerPanel.BackgroundImage = dpad_image;
                    });
                } catch { }

                return;
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

                clicks++;
                clicks_total++;
                keyData.KEY_PRESSED_AMOUNT++;

                if (useBackgroundImagePressed == true)
                    BackgroundImage = backgroundImagePressed;

                if (useSoundPressed == true)
                {
                    try
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            soundPressed.Open(new Uri(keyData.keySoundPressed, UriKind.RelativeOrAbsolute));
                            soundPressed.Volume = keyData.keySoundPressedVolume;
                            soundPressed.Play();
                        });
                    } catch { }
                }

                // update key colors
                if (keyData.useTransparentBackground == true)
                {
                    BackColor = Color.FromArgb(255, keyData.keyTransparencyKeyR, keyData.keyTransparencyKeyG, keyData.keyTransparencyKeyB);
                    try
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            TransparencyKey = Color.FromArgb(255, keyData.keyTransparencyKeyR, keyData.keyTransparencyKeyG, keyData.keyTransparencyKeyB);
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
                    KeyLabel.ForeColor = Color.FromArgb(255, (byte)~keyData.keyTextColorR, (byte)~keyData.keyTextColorG, (byte)~keyData.keyTextColorB);
                    CpsLabel.ForeColor = Color.FromArgb(255, (byte)~keyData.keyTextColorR, (byte)~keyData.keyTextColorG, (byte)~keyData.keyTextColorB);
                }
                else
                {
                    KeyLabel.ForeColor = Color.FromArgb(255, keyData.keyTextColorPressedR, keyData.keyTextColorPressedG, keyData.keyTextColorPressedB);
                    CpsLabel.ForeColor = Color.FromArgb(255, keyData.keyTextColorPressedR, keyData.keyTextColorPressedG, keyData.keyTextColorPressedB);
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
                    try
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            sound.Open(new Uri(keyData.keySound, UriKind.RelativeOrAbsolute));
                            sound.Volume = keyData.keySoundVolume;
                            sound.Play();
                        });
                    } catch { }
                }

                // restore key colors
                if (keyData.useTransparentBackground == true)
                {
                    BackColor = Color.FromArgb(255, keyData.keyTransparencyKeyR, keyData.keyTransparencyKeyG, keyData.keyTransparencyKeyB);
                    try
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            TransparencyKey = Color.FromArgb(255, keyData.keyTransparencyKeyR, keyData.keyTransparencyKeyG, keyData.keyTransparencyKeyB);
                        });
                    } catch { }
                }
                else
                    BackColor = Color.FromArgb(255, keyData.keyColorR, keyData.keyColorG, keyData.keyColorB);

                KeyLabel.ForeColor = Color.FromArgb(255, keyData.keyTextColorR, keyData.keyTextColorG, keyData.keyTextColorB);
                CpsLabel.ForeColor = Color.FromArgb(255, keyData.keyTextColorR, keyData.keyTextColorG, keyData.keyTextColorB);

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
                            case 0:
                                Top -= keyData.wiggleMode_wiggleAmount + keyData.wiggleMode_biasUp;
                                keyData.KEY_PIXEL_DISTANCE += keyData.wiggleMode_wiggleAmount + keyData.wiggleMode_biasUp;
                                break;
                            case 1:
                                Top += keyData.wiggleMode_wiggleAmount + keyData.wiggleMode_biasDown;
                                keyData.KEY_PIXEL_DISTANCE += keyData.wiggleMode_wiggleAmount + keyData.wiggleMode_biasDown;
                                break;
                            case 2:
                                Left -= keyData.wiggleMode_wiggleAmount + keyData.wiggleMode_biasLeft;
                                keyData.KEY_PIXEL_DISTANCE += keyData.wiggleMode_wiggleAmount + keyData.wiggleMode_biasLeft;
                                break;
                            case 3:
                                Left += keyData.wiggleMode_wiggleAmount + keyData.wiggleMode_biasRight;
                                keyData.KEY_PIXEL_DISTANCE += keyData.wiggleMode_wiggleAmount + keyData.wiggleMode_biasRight;
                                break;
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
                        int endX = wiggleModeLocationX_temp;
                        int endY = wiggleModeLocationY_temp;
                        int steps = 25;
                        double delay = 0.0025;

                        for (int i = 0; i < steps; i++)
                        {
                            int x = startX + (endX - startX) * i / steps;
                            int y = startY + (endY - startY) * i / steps;
                            Location = new Point(x, y);

                            keyData.KEY_PIXEL_DISTANCE++;

                            var sw = Stopwatch.StartNew();
                            while (sw.ElapsedTicks < Math.Round(delay * Stopwatch.Frequency)) { }
                        }

                        Left = wiggleModeLocationX_temp;
                        Top = wiggleModeLocationY_temp;
                    }
                });
            } catch { }
        }

        int clicks = 0;
        int clicks_total = 0;
        int click_seconds = 0;

        int autosave_timer = 0;
        private void secRefresh(object source, ElapsedEventArgs e)
        {
            #region cpsCounter
            click_seconds++;
            int cps = clicks_total / click_seconds;
            keyData.KEY_HIGHEST_CPS = keyData.KEY_HIGHEST_CPS < cps ? cps : keyData.KEY_HIGHEST_CPS;
            try
            {
                Invoke((MethodInvoker)delegate
                {
                    CpsLabel.Text = cps.ToString();
                });
            } catch { }
            if (clicks == 0)
            {
                clicks_total = 0;
                click_seconds = 0;
            }
            clicks = 0;
            #endregion

            keyData.KEY_AGE_SECONDS++;

            autosave_timer++;
            if (autosave_timer == 60)
            {
                WriteConfig();
                autosave_timer = 0;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            HandleClose(true);
        }

        private void LockButton_Click(object sender, EventArgs e)
        {
            if (keyData.KEY_LOCKED == false)
                keyData.KEY_LOCKED = true;
            else
                keyData.KEY_LOCKED = false;

            ToggleControls();
        }

        private void StatsButton_Click(object sender, EventArgs e)
        {
            float key_distance = (keyData.KEY_PIXEL_DISTANCE / (float)96) / (float)12;
            float mouse_distance = (keyData.MOUSE_PIXEL_DISTANCE / (float)96) / (float)63360;
            float joystick_odometer = (float)(((2.1 * Math.PI) * (keyData.JOYSTICK_ANGLE_SUM / (float)360)) / (float)160900);

            int days = keyData.KEY_AGE_SECONDS / (24 * 60 * 60);
            int hours = (keyData.KEY_AGE_SECONDS % (24 * 60 * 60)) / (60 * 60);
            int minutes = (keyData.KEY_AGE_SECONDS % (60 * 60)) / 60;
            int seconds = keyData.KEY_AGE_SECONDS % 60;
            string formattedTime = string.Format("{0:00}:{1:00}:{2:00}:{3:00}", days, hours, minutes, seconds);

            string keyStats = "Key Stats:\n\n" + 

                              "Times Pressed: " + keyData.KEY_PRESSED_AMOUNT + "\n" +
                              "Times Clicked On: " + keyData.KEY_CLICKED_AMOUNT + "\n" +
                              "Highest CPS: " + keyData.KEY_HIGHEST_CPS + "\n\n" +

                              "Key Distance Travelled: " + key_distance + " feet \n" +
                              "Mouse Distance Travelled: " + mouse_distance + " miles \n" +
                              "Joystick Odometer: " + joystick_odometer + " miles \n\n" +

                              "Nickname: " + keyData.KEY_NICKNAME + "\n" +
                              "Key Age: " + formattedTime + "\n" +
                              "Creation Date: " + keyData.KEY_CREATION_DATE;
            CustomMessageBox statsWindow = new CustomMessageBox();
            statsWindow.MessageText = keyStats;
            statsWindow.ShowDialog();
        }

        private void SnapXTextbox_TextChanged(object sender, EventArgs e)
        {
            if (IsNumber(SnapXTextbox.Text, "int") == false)
                return;
            keyData.KEY_SNAP_X = int.Parse(SnapXTextbox.Text);
        }

        private void SnapYTextbox_TextChanged(object sender, EventArgs e)
        {
            if (IsNumber(SnapYTextbox.Text, "int") == false)
                return;
            keyData.KEY_SNAP_Y = int.Parse(SnapYTextbox.Text);
        }

        private void WriteConfig()
        {
            // set default snap values if SnapXTextbox or SnapYTextbox input is invalid or empty
            if (IsNumber(SnapXTextbox.Text, "int") == false || SnapXTextbox.Text == "")
                keyData.KEY_SNAP_X = 50;
            if (IsNumber(SnapYTextbox.Text, "int") == false || SnapYTextbox.Text == "")
                keyData.KEY_SNAP_Y = 50;

            // check if the preset directory exists, if not, return
            if (Directory.Exists("Keystrokes\\presets\\" + keyData.presetName) == false)
                return;

            // format keyData for exporting
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

            // save the keyData configuration to a file
            File.WriteAllText("Keystrokes\\presets\\" + keyData.presetName + "\\" + keyData.keyId + ".key", config);
        }

        private void MoveKey(MouseEventArgs e)
        {
            int x_location_current = Location.X;
            int y_location_current = Location.Y;

            keyData.KEY_CLICKED_AMOUNT++;

            // move the form when the left mouse button is clicked, and the key is not locked
            if (e.Button == MouseButtons.Left && keyData.KEY_LOCKED == false)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }

            // show and hide the key options when double-clicked
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
                ToggleControls();

            // set default snap settings to 50% of key
            keyData.KEY_SNAP_X = 50;
            keyData.KEY_SNAP_Y = 50;

            // load snap textboxes into keyData if they are valid integers and not empty or zero
            if (IsNumber(SnapXTextbox.Text, "int") == true && SnapXTextbox.Text != "" && SnapXTextbox.Text != "0")
                keyData.KEY_SNAP_X = int.Parse(SnapXTextbox.Text);
            if (IsNumber(SnapYTextbox.Text, "int") == true && SnapYTextbox.Text != "" && SnapYTextbox.Text != "0")
                keyData.KEY_SNAP_Y = int.Parse(SnapYTextbox.Text);

            // calculate snap grid based on snap percentages
            double x_snap = Width * ((double)keyData.KEY_SNAP_X / 100);
            double y_snap = Height * ((double)keyData.KEY_SNAP_Y / 100);

            // calculate snap threshold based on current form position
            double x_snap_location = Left * (1 / x_snap);
            double y_snap_location = Top * (1 / y_snap);

            // calculate floored snap location
            int x_location_new = (int)(Math.Floor(x_snap_location) * x_snap);
            int y_location_new = (int)(Math.Floor(y_snap_location) * y_snap);

            // snap the form to the new location
            Left = x_location_new;
            Top = y_location_new;

            // store the temporary location for wiggle mode
            wiggleModeLocationX_temp = Left;
            wiggleModeLocationY_temp = Top;

            // update key location in keyData
            keyData.KEY_LOCATION_X = Location.X;
            keyData.KEY_LOCATION_Y = Location.Y;

            // update pixel distance in keyData
            keyData.KEY_PIXEL_DISTANCE += Math.Abs(Location.X - x_location_current) + Math.Abs(Location.Y - y_location_current);
        }

        private void ToggleControls()
        {
            if (CloseButton.Visible == false)
                CloseButton.Visible = true;
            else
                CloseButton.Visible = false;

            if (LockButton.Visible == false)
                LockButton.Visible = true;
            else
                LockButton.Visible = false;

            if (StatsButton.Visible == false)
            {
                StatsButton.Visible = true;
                CpsLabel.SendToBack();
            }
            else
            {
                StatsButton.Visible = false;
                CpsLabel.BringToFront();
            }

            if (SnapXTextbox.Visible == false)
                SnapXTextbox.Visible = true;
            else
                SnapXTextbox.Visible = false;

            if (SnapYTextbox.Visible == false)
                SnapYTextbox.Visible = true;
            else
                SnapYTextbox.Visible = false;

            if (ControllerDebugLabel.Visible == false)
                ControllerDebugLabel.Visible = true;
            else
                ControllerDebugLabel.Visible = false;
        }

        private void Key_FormClosing(object sender, FormClosingEventArgs e)
        {
            HandleClose(false);
        }

        private void HandleClose(bool deleteKey)
        {
            // save the configuration settings
            WriteConfig();

            // check if the preset exists and delete the key file if deleteKey is true
            if (deleteKey == true && Directory.Exists("Keystrokes\\presets\\" + keyData.presetName) == true)
                File.Delete("Keystrokes\\presets\\" + keyData.presetName + "\\" + keyData.keyId + ".key");

            // disable the input ping
            inputPing.Enabled = false;

            // dispose the background images if they are being used
            if (useBackgroundImage == true)
                backgroundImage.Dispose();
            if (useBackgroundImagePressed == true)
                backgroundImagePressed.Dispose();

            // dispose the current key
            Dispose();
        }

        private void Key_MouseDown(object sender, MouseEventArgs e)
        {
            MoveKey(e);
        }

        private void KeyLabel_MouseDown(object sender, MouseEventArgs e)
        {
            MoveKey(e);
        }

        private void CpsLabel_MouseDown(object sender, MouseEventArgs e)
        {
            MoveKey(e);
        }

        private void ControllerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            MoveKey(e);
        }

        private void ControllerDebugLabel_MouseDown(object sender, MouseEventArgs e)
        {
            MoveKey(e);
        }
    }
}