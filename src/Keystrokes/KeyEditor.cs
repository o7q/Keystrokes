using System;
using System.IO;
using System.Linq;
using System.Timers;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Keystrokes.Data;
using static Keystrokes.Data.Fixes;
using static Keystrokes.Data.Storage;
using static Keystrokes.Tools.Numbers;
using static Keystrokes.Tools.Input.ControllerInput;

namespace Keystrokes
{
    public partial class KeyEditor : Form
    {
        // configure mouse window events
        public const int HT_CAPTION = 0x2;
        public const int WM_NCLBUTTONDOWN = 0xA1;

        // grab dlls for mousedown
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        KeyInfo keyData_ = new KeyInfo();

        // form settings
        const int form_SizeX = 236;
        const int form_SizeY = 418;
        const int titlebarPanel_SizeX = 303;
        const int titlebarPanel_SizeY = 31;
        const int closeButton_LocationX = 216;
        const int closeButton_LocationY = 6;

        float fontSize = 20.25f;

        public KeyEditor()
        {
            InitializeComponent();
        }

        readonly System.Timers.Timer controllerPing = new System.Timers.Timer();

        private void KeyEditor_Load(object sender, EventArgs e)
        {
            // load presets into preset browser
            PresetNameCombobox.Items.Clear();
            foreach (string file in Directory.GetDirectories("Keystrokes\\presets"))
                PresetNameCombobox.Items.Add(Path.GetFileName(file));

            // default settings
            keyData_.keyColorR = 0;
            keyData_.keyColorG = 0;
            keyData_.keyColorB = 0;
            keyData_.keyTextColorR = 255;
            keyData_.keyTextColorG = 255;
            keyData_.keyTextColorB = 255;

            keyData_.keyColorPressedR = 192;
            keyData_.keyColorPressedG = 0;
            keyData_.keyColorPressedB = 0;
            keyData_.keyTextColorPressedR = 0;
            keyData_.keyTextColorPressedG = 0;
            keyData_.keyTextColorPressedB = 0;

            keyData_.KEY_SNAP_X = 50;
            keyData_.KEY_SNAP_Y = 50;

            keyData_.KEY_LOCKED = false;

            KeyBorderCombobox.SelectedIndex = 0;

            // configure key preview windows

            // preview 1
            KeyPreviewTextLabel.Font = new Font(KeyPreviewTextLabel.Font.Name, 20);

            KeyPreviewPanel.Width = 60;
            KeyPreviewPanel.Height = 60;

            KeyPreviewPanel.BackColor = Color.FromArgb(255, 0, 0, 0);
            KeyPreviewTextLabel.ForeColor = Color.FromArgb(255, 255, 255, 255);

            // preview 2
            KeyPreview2TextLabel.Font = new Font(KeyPreview2TextLabel.Font.Name, 20);

            KeyPreview2Panel.Width = 60;
            KeyPreview2Panel.Height = 60;

            KeyPreview2Panel.BackColor = Color.FromArgb(255, 0, 0, 0);
            KeyPreview2TextLabel.ForeColor = Color.FromArgb(255, 255, 255, 255);

            FormatKeyPreview();
            ResizeForm();

            #region tooltipDictionary
            // bind tooltips
            string[] tooltipMap =
            {
                "CloseButton", "Close",
                "PresetNameCombobox", "Name of preset to edit/create",
                "KeyWidthTextbox", "Key width in pixels",
                "KeyHeightTextbox", "Key height in pixels",
                "KeyTextTextbox", "Custom key text",
                "FontButton", "Change the font settings",
                "ShowTextCheckbox", "Display key text",

                "KeyColorButton", "Key background color",
                "KeyTextColorButton", "Key text color",
                "ImageButton", "Display an image as the key background",
                "ImageDisposeButton", "Remove image",
                "SoundButton", "Play a sound effect",
                "SoundVolumeTextbox", "Volume for sound effect",
                "SoundDisposeButton", "Remove sound effect",

                "KeyColorPressedButton", "Key background color when pressed",
                "KeyTextColorPressedButton", "Key text color when pressed",
                "ImagePressedButton", "Display an image as the key background when pressed",
                "ImagePressedDisposeButton", "Remove image",
                "SoundPressedButton", "Play a sound effect when pressed",
                "SoundPressedVolumeTextbox", "Volume for sound effect",
                "SoundPressedDisposeButton", "Remove sound effect",

                "KeyColorPressedInvertCheckbox", "Invert key color when pressed",
                "KeyTextColorPressedInvertCheckbox", "Invert text color when pressed",

                "KeyOpacityTextbox", "Opacity of key",
                "UseTransparentBackgroundCheckbox", "Make the background completely transparent",

                "KeyBorderCombobox", "Border style of key",
                "CreateKeyButton", "Create a new key with specified settings"
            };
            #endregion

            // configure tooltips
            for (int i = 0; i < tooltipMap.Length; i += 2)
                KeyEditorToolTip.SetToolTip(Controls.Find(tooltipMap[i], true)[0], tooltipMap[i + 1]);

            // configure tooltip draw
            KeyEditorToolTip.AutoPopDelay = 10000;
            KeyEditorToolTip.OwnerDraw = true;
            KeyEditorToolTip.BackColor = Color.FromArgb(20, 22, 20);
            KeyEditorToolTip.ForeColor = Color.FromArgb(150, 152, 150);
        }

        private void KeyEditorTooltip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        bool allowKeyCreation = false;
        private void CreateKeyButton_Click(object sender, EventArgs e)
        {
            // ask user to input key
            CreateKeyButton.Font = new Font(CreateKeyButton.Font.Name, 10, FontStyle.Bold);
            CreateKeyButton.Text = "Press a key...";

            allowKeyCreation = true;
            allowControllerCreation = true;

            // configure and start ControllerRefresh timer
            controllerPing.Elapsed += new ElapsedEventHandler(ControllerRefresh);
            controllerPing.Interval = 1;
            controllerPing.Enabled = true;
        }

        private void CreateKeyButton_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            allowControllerCreation = false;

            // prevent user from making a new key if the create button was not pressed
            if (allowKeyCreation == false)
                return;

            // get and process key code
            Keys keyCode = e.KeyCode;
            KeysConverter converter = new KeysConverter();
            Keys key = (Keys)converter.ConvertFrom(keyCode.ToString());
            string hexValue = ((int)key).ToString("X2");

            // configure key text
            keyData_.keyText = KeyTextTextbox.Text == "" ? keyCode.ToString() : KeyTextTextbox.Text;

            // fix keytext with proper keys
            for (int i = 0; i < keyTextFixes.Length; i += 2)
                if (keyData_.keyText == keyTextFixes[i + 1])
                    keyData_.keyText = keyTextFixes[i];

            // configure key code identities
            keyData_.keyCode = hexValue;
            keyData_.isControllerKey = false;

            // finalize
            FinalizeKeyFields();
            Directory.CreateDirectory("Keystrokes\\presets\\" + keyData_.presetName + "\\assets");

            // display key with keyData_ settings
            Key newKey = new Key(keyData_);
            newKey.Show();
            // add key to child list
            keys.Add(newKey);

            // lock create button
            allowKeyCreation = false;
        }

        bool allowControllerCreation = false;
        private void ControllerRefresh(object source, ElapsedEventArgs e)
        {
            // return if keys are not allowed to be created
            if (allowKeyCreation == false || allowControllerCreation == false)
                return;

            // get pressed controller button information
            var controller_detect = ControllerDetect();
            keyData_.keyCode = controller_detect.Item1;
            keyData_.keyText = controller_detect.Item2;

            // get pressed controller trigger information
            var trigger_detect = TriggerDetect();
            if (trigger_detect.Item1 == true)
                keyData_.keyCode = trigger_detect.Item2;

            // return if no controller button was pressed
            if (keyData_.keyCode == "")
                return;

            // enable controller key
            keyData_.isControllerKey = true;

            // disable ControllerRefresh
            controllerPing.Enabled = false;
            allowControllerCreation = false;

            Invoke((MethodInvoker)delegate
            {
                // create key
                FinalizeKeyFields();
                keyData_.keyFontSize = fontSize + controller_detect.Item3;
                Directory.CreateDirectory("Keystrokes\\presets\\" + keyData_.presetName + "\\assets");

                // display key with keyData_ settings
                Key newKey = new Key(keyData_);
                newKey.Show();
                // add key to child list
                keys.Add(newKey);
            });
        }

        private void FinalizeKeyFields()
        {
            // restore create button text
            CreateKeyButton.Text = "Create Key";
            CreateKeyButton.Font = new Font(CreateKeyButton.Font.Name, 16, FontStyle.Bold);

            // are user options valid? if not, assign them the default values
            if (IsNumber(KeyWidthTextbox.Text, "int") == false) KeyWidthTextbox.Text = "60";
            if (IsNumber(KeyHeightTextbox.Text, "int") == false) KeyHeightTextbox.Text = "60";
            if (IsNumber(KeyOpacityTextbox.Text, "float") == false) KeyOpacityTextbox.Text = "0.8";
            if (IsNumber(WiggleAmountTextbox.Text, "int") == false) KeyWidthTextbox.Text = "2";
            if (IsNumber(WiggleBiasUpTextbox.Text, "int") == false) WiggleBiasUpTextbox.Text = "0";
            if (IsNumber(WiggleBiasDownTextbox.Text, "int") == false) WiggleBiasDownTextbox.Text = "0";
            if (IsNumber(WiggleBiasLeftTextbox.Text, "int") == false) WiggleBiasLeftTextbox.Text = "0";
            if (IsNumber(WiggleBiasRightTextbox.Text, "int") == false) WiggleBiasRightTextbox.Text = "0";

            // send user data to keyData_
            keyData_.presetName = PresetNameCombobox.Text;

            keyData_.keySizeX = int.Parse(KeyWidthTextbox.Text);
            keyData_.keySizeY = int.Parse(KeyHeightTextbox.Text);

            // configure controller font size
            keyData_.keyFont = keyData_.keyFont == null ? "Microsoft Sans Serif" : keyData_.keyFont;
            keyData_.keyFontSize = keyData_.isControllerKey == true ? keyData_.keyFontSize : fontSize;
            keyData_.keyFontStyle = keyData_.keyFontStyle == FontStyle.Regular ? FontStyle.Regular : keyData_.keyFontStyle;
            keyData_.showText = ShowTextCheckbox.Checked;

            keyData_.keyColorPressedInvert = KeyColorPressedInvertCheckbox.Checked;
            keyData_.keyTextColorPressedInvert = KeyTextColorPressedInvertCheckbox.Checked;

            keyData_.keyOpacity = float.Parse(KeyOpacityTextbox.Text) / 100;

            keyData_.keySoundVolume = float.Parse(SoundVolumeTextbox.Text) / 100;
            keyData_.keySoundPressedVolume = float.Parse(SoundPressedVolumeTextbox.Text) / 100;

            // configure border style
            switch (KeyBorderCombobox.Text)
            {
                case "Solid": keyData_.keyBorder = ButtonBorderStyle.Solid; break;
                case "Inset": keyData_.keyBorder = ButtonBorderStyle.Inset; break;
                case "Outset": keyData_.keyBorder = ButtonBorderStyle.Outset; break;
                case "Dashed": keyData_.keyBorder = ButtonBorderStyle.Dashed; break;
                case "None": keyData_.keyBorder = ButtonBorderStyle.None; break;
            }

            if (keyData_.useTransparentBackground == true)
                keyData_.keyBorder = ButtonBorderStyle.None;

            keyData_.KEY_CREATION_DATE = DateTime.Now.ToString("M/d/y h:m:s");

            keyData_.wiggleMode = WiggleModeCheckbox.Checked == true ? true : false;
            keyData_.wiggleMode_wiggleAmount = int.Parse(WiggleAmountTextbox.Text);
            keyData_.wiggleMode_biasUp = int.Parse(WiggleBiasUpTextbox.Text);
            keyData_.wiggleMode_biasDown = int.Parse(WiggleBiasDownTextbox.Text);
            keyData_.wiggleMode_biasLeft = int.Parse(WiggleBiasLeftTextbox.Text);
            keyData_.wiggleMode_biasRight = int.Parse(WiggleBiasRightTextbox.Text);
        }

        private void KeyWidthTextbox_TextChanged(object sender, EventArgs e)
        {
            // is data a number? if not, return
            if (IsNumber(KeyWidthTextbox.Text, "int") == false)
                return;

            // update key preview
            KeyPreviewPanel.Width = int.Parse(KeyWidthTextbox.Text);
            KeyPreview2Panel.Width = int.Parse(KeyWidthTextbox.Text);
            FormatKeyPreview();

            // resize form to fit key preview
            ResizeForm();
        }

        private void KeyHeightTextbox_TextChanged(object sender, EventArgs e)
        {
            // is data a number? if not, return
            if (IsNumber(KeyHeightTextbox.Text, "int") == false)
                return;

            // update key preview
            KeyPreviewPanel.Height = int.Parse(KeyHeightTextbox.Text);
            KeyPreview2Panel.Height = int.Parse(KeyHeightTextbox.Text);
            FormatKeyPreview();

            // resize form to fit key preview
            ResizeForm();
        }

        private void KeyTextTextbox_TextChanged(object sender, EventArgs e)
        {
            KeyPreviewTextLabel.Text = KeyTextTextbox.Text;
            if (KeyTextTextbox.Text == "")
                KeyPreviewTextLabel.Text = "A";

            KeyPreview2TextLabel.Text = KeyTextTextbox.Text;
            if (KeyTextTextbox.Text == "")
                KeyPreview2TextLabel.Text = "A";

            FormatKeyPreview();
        }

        private void FontButton_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowEffects = false;
            fontDialog.Font = new Font("Microsoft Sans Serif", 20f);
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Font selectedFont = fontDialog.Font;
                keyData_.keyFont = selectedFont.Name;
                fontSize = selectedFont.Size;

                FontStyle fontStyle = new FontStyle();
                if (selectedFont.Bold == true) fontStyle = FontStyle.Bold;
                if (selectedFont.Italic == true) fontStyle = FontStyle.Italic;
                if (selectedFont.Strikeout == true) fontStyle = FontStyle.Strikeout;
                if (selectedFont.Underline == true) fontStyle = FontStyle.Underline;
                keyData_.keyFontStyle = fontStyle;

                // update key previews
                KeyPreviewTextLabel.Font = new Font(selectedFont.Name, selectedFont.Size, fontStyle);
                KeyPreview2TextLabel.Font = new Font(selectedFont.Name, selectedFont.Size, fontStyle);

                FormatKeyPreview();
            }
        }

        private void ShowTextCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            KeyPreviewTextLabel.Text = ShowTextCheckbox.Checked == true ? (KeyTextTextbox.Text == "" ? "A" : KeyTextTextbox.Text) : "";
            KeyPreview2TextLabel.Text = ShowTextCheckbox.Checked == true ? (KeyTextTextbox.Text == "" ? "A" : KeyTextTextbox.Text) : "";
        }

        private void KeyColorButton_Click(object sender, EventArgs e)
        {
            // open new color dialog
            var rgb = OpenColorDialog();
            if (rgb == null)
                return;

            // split r, g, b values
            keyData_.keyColorR = rgb.Item1;
            keyData_.keyColorG = rgb.Item2;
            keyData_.keyColorB = rgb.Item3;

            // update component visuals
            KeyColorButton.FlatAppearance.BorderColor = Color.FromArgb(255, keyData_.keyColorR, keyData_.keyColorG, keyData_.keyColorB);

            FormatKeyPreview();
        }

        private void KeyTextColorButton_Click(object sender, EventArgs e)
        {
            // open new color dialog
            var rgb = OpenColorDialog();
            if (rgb == null)
                return;

            // split r, g, b values
            keyData_.keyTextColorR = rgb.Item1;
            keyData_.keyTextColorG = rgb.Item2;
            keyData_.keyTextColorB = rgb.Item3;

            // update component visuals
            KeyTextColorButton.FlatAppearance.BorderColor = Color.FromArgb(255, keyData_.keyTextColorR, keyData_.keyTextColorG, keyData_.keyTextColorB);

            FormatKeyPreview();
        }

        private void KeyColorPressedButton_Click(object sender, EventArgs e)
        {
            // open new color dialog
            var rgb = OpenColorDialog();
            if (rgb == null)
                return;

            // split r, g, b values
            keyData_.keyColorPressedR = rgb.Item1;
            keyData_.keyColorPressedG = rgb.Item2;
            keyData_.keyColorPressedB = rgb.Item3;

            // update component visuals
            KeyColorPressedButton.FlatAppearance.BorderColor = Color.FromArgb(255, keyData_.keyColorPressedR, keyData_.keyColorPressedG, keyData_.keyColorPressedB);

            FormatKeyPreview();
        }

        private void KeyTextColorPressedButton_Click(object sender, EventArgs e)
        {
            // open new color dialog
            var rgb = OpenColorDialog();
            if (rgb == null)
                return;

            // split r, g, b values
            keyData_.keyTextColorPressedR = rgb.Item1;
            keyData_.keyTextColorPressedG = rgb.Item2;
            keyData_.keyTextColorPressedB = rgb.Item3;

            // update component visuals
            KeyTextColorPressedButton.FlatAppearance.BorderColor = Color.FromArgb(255, keyData_.keyTextColorPressedR, keyData_.keyTextColorPressedG, keyData_.keyTextColorPressedB);

            FormatKeyPreview();
        }

        private void ImageButton_Click(object sender, EventArgs e)
        {
            keyData_.keyBackgroundImage = PrepareImageDialog();

            if (keyData_.keyBackgroundImage == "" || PresetNameCombobox.Text == "")
                return;

            Image backgroundImage = Image.FromFile(keyData_.keyBackgroundImage);
            KeyPreviewPanel.BackgroundImage = backgroundImage;
            KeyPreviewPanel.BackgroundImageLayout = ImageLayout.Stretch;

            ImageDisposeButton.ForeColor = Color.FromArgb(255, 250, 220, 220);
        }

        private void ImageDisposeButton_Click(object sender, EventArgs e)
        {
            keyData_.keyBackgroundImage = "";

            KeyPreviewPanel.BackgroundImage = null;

            ImageDisposeButton.ForeColor = Color.FromArgb(255, 150, 150, 150);
        }

        private void ImagePressedButton_Click(object sender, EventArgs e)
        {
            keyData_.keyBackgroundImagePressed = PrepareImageDialog();

            if (keyData_.keyBackgroundImagePressed == "")
                return;

            Image backgroundImage = Image.FromFile(keyData_.keyBackgroundImagePressed);
            KeyPreview2Panel.BackgroundImage = backgroundImage;
            KeyPreview2Panel.BackgroundImageLayout = ImageLayout.Stretch;

            ImagePressedDisposeButton.ForeColor = Color.FromArgb(255, 250, 220, 220);
        }

        private void ImagePressedDisposeButton_Click(object sender, EventArgs e)
        {
            keyData_.keyBackgroundImage = "";

            KeyPreview2Panel.BackgroundImage = null;

            ImagePressedDisposeButton.ForeColor = Color.FromArgb(255, 150, 150, 150);
        }

        private void SoundButton_Click(object sender, EventArgs e)
        {
            keyData_.keySound = PrepareAudioDialog();

            if (keyData_.keySound == "")
                return;
            SoundDisposeButton.ForeColor = Color.FromArgb(255, 250, 220, 220);
        }

        private void SoundDisposeButton_Click(object sender, EventArgs e)
        {
            keyData_.keySound = "";

            SoundDisposeButton.ForeColor = Color.FromArgb(255, 150, 150, 150);
        }

        private void SoundPressedButton_Click(object sender, EventArgs e)
        {
            keyData_.keySoundPressed = PrepareAudioDialog();

            if (keyData_.keySoundPressed == "")
                return;
            SoundPressedDisposeButton.ForeColor = Color.FromArgb(255, 250, 220, 220);
        }

        private void SoundPressedDisposeButton_Click(object sender, EventArgs e)
        {
            keyData_.keySoundPressed = "";

            SoundPressedDisposeButton.ForeColor = Color.FromArgb(255, 150, 150, 150);
        }

        private void KeyColorPressedInvertCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            FormatKeyPreview();
        }

        private void KeyTextColorPressedInvertCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            FormatKeyPreview();
        }

        private void UseTransparentBackgroundCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            keyData_.useTransparentBackground = UseTransparentBackgroundCheckbox.Checked;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private Tuple<int, int, int> OpenColorDialog()
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AnyColor = true;

            int r;
            int g;
            int b;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                r = Convert.ToInt32(colorDialog.Color.R);
                g = Convert.ToInt32(colorDialog.Color.G);
                b = Convert.ToInt32(colorDialog.Color.B);
                return Tuple.Create(r, g, b);
            }

            return null;
        }

        private string PrepareImageDialog()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "All Files (*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (PresetNameCombobox.Text == "")
                    PresetNameCombobox.Text = "Default";

                Directory.CreateDirectory("Keystrokes\\presets\\" + PresetNameCombobox.Text + "\\assets");

                Image image = Image.FromFile(fileDialog.FileName);

                // resize image
                int x_size = (IsNumber(KeyWidthTextbox.Text, "int") || KeyWidthTextbox.Text != "0") == true ? int.Parse(KeyWidthTextbox.Text) : 60;
                int y_size = (IsNumber(KeyHeightTextbox.Text, "int") || KeyHeightTextbox.Text != "0") == true ? int.Parse(KeyHeightTextbox.Text) : 60;
                image = new Bitmap(image, new Size(x_size, y_size));

                ImageCodecInfo codec = ImageCodecInfo.GetImageDecoders().FirstOrDefault(c => c.FormatID == ImageFormat.Jpeg.Guid);

                EncoderParameters parameters = new EncoderParameters(1);
                parameters.Param[0] = new EncoderParameter(Encoder.Quality, 90L);

                string output = "Keystrokes\\presets\\" + PresetNameCombobox.Text + "\\assets\\" + GenerateID(8) + ".jpg";
                image.Save(output, codec, parameters);
                image.Dispose();

                return output;
            }

            return "";
        }

        private string PrepareAudioDialog()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Wave File (*.wav)|*.wav";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (PresetNameCombobox.Text == "") PresetNameCombobox.Text = "Default";

                Directory.CreateDirectory("Keystrokes\\presets\\" + PresetNameCombobox.Text + "\\assets");

                string output = "Keystrokes\\presets\\" + PresetNameCombobox.Text + "\\assets\\" + GenerateID(8) + ".wav";
                File.Copy(fileDialog.FileName, output);

                return output;
            }

            return "";
        }

        private void FormatKeyPreview()
        {
            KeyPreviewTextLabel.Location = new Point((KeyPreviewPanel.Width / 2) - (KeyPreviewTextLabel.Width / 2), (KeyPreviewPanel.Height / 2) - (KeyPreviewTextLabel.Height / 2));

            KeyPreview2Panel.Location = new Point(KeyPreviewPanel.Width + 12, KeyPreviewPanel.Location.Y);
            KeyPreview2TextLabel.Location = new Point((KeyPreview2Panel.Width / 2) - (KeyPreview2TextLabel.Width / 2), (KeyPreview2Panel.Height / 2) - (KeyPreview2TextLabel.Height / 2));

            KeyPreviewPressedLabel.Location = new Point(KeyPreview2Panel.Location.X - 4, KeyPreviewPressedLabel.Location.Y);

            KeyPreviewPanel.BackColor = Color.FromArgb(255, keyData_.keyColorR, keyData_.keyColorG, keyData_.keyColorB);
            KeyPreviewTextLabel.ForeColor = Color.FromArgb(255, keyData_.keyTextColorR, keyData_.keyTextColorG, keyData_.keyTextColorB);

            if (KeyColorPressedInvertCheckbox.Checked == true)
                KeyPreview2Panel.BackColor = Color.FromArgb(255, (byte)~keyData_.keyColorR, (byte)~keyData_.keyColorG, (byte)~keyData_.keyColorB);
            else
                KeyPreview2Panel.BackColor = Color.FromArgb(255, keyData_.keyColorPressedR, keyData_.keyColorPressedG, keyData_.keyColorPressedB);

            if (KeyTextColorPressedInvertCheckbox.Checked == true)
                KeyPreview2TextLabel.ForeColor = Color.FromArgb(255, (byte)~keyData_.keyTextColorR, (byte)~keyData_.keyTextColorG, (byte)~keyData_.keyTextColorB);
            else
                KeyPreview2TextLabel.ForeColor = Color.FromArgb(255, keyData_.keyTextColorPressedR, keyData_.keyTextColorPressedG, keyData_.keyTextColorPressedB);
        }

        private void ResizeForm()
        {
            // scale and move form and components
            Size = new Size(form_SizeX + KeyPreviewPanel.Width * 2 - 120, form_SizeY + KeyPreviewPanel.Height - 60);
            TitlebarPanel.Size = new Size(titlebarPanel_SizeX + KeyPreviewPanel.Width * 2 - 120, titlebarPanel_SizeY);
            CloseButton.Location = new Point(closeButton_LocationX + KeyPreviewPanel.Width * 2 - 120, closeButton_LocationY);

            if (Width < form_SizeX)
            {
                Size = new Size(form_SizeX, Height);
                TitlebarPanel.Size = new Size(titlebarPanel_SizeX, TitlebarPanel.Height);
                CloseButton.Location = new Point(closeButton_LocationX, CloseButton.Location.Y);
            }
            if (Height < form_SizeY)
            {
                Size = new Size(Width, form_SizeY);
                TitlebarPanel.Size = new Size(TitlebarPanel.Width, titlebarPanel_SizeY);
                CloseButton.Location = new Point(CloseButton.Location.X, closeButton_LocationY);
            }
        }

        private void MoveForm(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void TitlebarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm(e);
        }

        private void BannerPicture_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm(e);
        }
    }
}