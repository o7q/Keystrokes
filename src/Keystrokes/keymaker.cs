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
    public partial class keymaker : Form
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

        public keymaker()
        {
            InitializeComponent();
        }

        System.Timers.Timer controllerPing = new System.Timers.Timer();

        private void keymaker_Load(object sender, EventArgs e)
        {
            // load presets into preset browser
            presetNameCombobox.Items.Clear();
            foreach (string file in Directory.GetDirectories("Keystrokes\\presets"))
                presetNameCombobox.Items.Add(Path.GetFileName(file));

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

            keyBorderCombobox.SelectedIndex = 0;

            // configure key preview windows

            // preview 1
            keyPreviewTextLabel.Font = new Font(keyPreviewTextLabel.Font.Name, 20);

            keyPreviewPanel.Width = 60;
            keyPreviewPanel.Height = 60;

            keyPreviewPanel.BackColor = Color.FromArgb(255, 0, 0, 0);
            keyPreviewTextLabel.ForeColor = Color.FromArgb(255, 255, 255, 255);
            counterLabel.ForeColor = Color.FromArgb(255, 255, 255, 255);
            counterLabel.Text = "";

            // preview 2
            keyPreview2TextLabel.Font = new Font(keyPreview2TextLabel.Font.Name, 20);

            keyPreview2Panel.Width = 60;
            keyPreview2Panel.Height = 60;

            keyPreview2Panel.BackColor = Color.FromArgb(255, 0, 0, 0);
            keyPreview2TextLabel.ForeColor = Color.FromArgb(255, 255, 255, 255);
            counter2Label.ForeColor = Color.FromArgb(255, 255, 255, 255);
            counter2Label.Text = "";

            FormatKeyPreview();
            ResizeForm();

            #region tooltipDictionary
            // bind tooltips
            string[] tooltipMap =
            {
                "closeButton", "Close",
                "presetNameCombobox", "Name of preset to edit/create",
                "keyWidthTextbox", "Key width in pixels",
                "keyHeightTextbox", "Key height in pixels",
                "keyTextTextbox", "Custom key text",
                "fontButton", "Change the font settings",
                "showTextCheckbox", "Display key text",

                "keyColorButton", "Key background color",
                "keyTextColorButton", "Key text color",
                "imageButton", "Display an image as the key background",
                "imageDisposeButton", "Remove image",
                "soundButton", "Play a sound effect",
                "soundVolumeTextbox", "Volume for sound effect",
                "soundDisposeButton", "Remove sound effect",

                "keyColorPressedButton", "Key background color when pressed",
                "keyTextColorPressedButton", "Key text color when pressed",
                "imagePressedButton", "Display an image as the key background when pressed",
                "imagePressedDisposeButton", "Remove image",
                "soundPressedButton", "Play a sound effect when pressed",
                "soundPressedVolumeTextbox", "Volume for sound effect",
                "soundPressedDisposeButton", "Remove sound effect",

                "keyColorPressedInvertCheckbox", "Invert key color when pressed",
                "keyTextColorPressedInvertCheckbox", "Invert text color when pressed",

                "keyOpacityTextbox", "Opacity of key",
                "useTransparentBackgroundCheckbox", "Make the background completely transparent",

                "useKeyCountCheckbox", "Display counter that counts up when the key is pressed",
                "keyBorderCombobox", "Border style of key",
                "createKeyButton", "Create a new key with specified settings"
            };
            #endregion

            // configure tooltips
            for (int i = 0; i < tooltipMap.Length; i += 2)
                keymakerTooltip.SetToolTip(Controls.Find(tooltipMap[i], true)[0], tooltipMap[i + 1]);

            // configure tooltip draw
            keymakerTooltip.AutoPopDelay = 10000;
            keymakerTooltip.OwnerDraw = true;
            keymakerTooltip.BackColor = Color.FromArgb(20, 22, 20);
            keymakerTooltip.ForeColor = Color.FromArgb(150, 152, 150);
        }

        private void keymakerTooltip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        bool allowKeyCreation = false;
        private void createKeyButton_Click(object sender, EventArgs e)
        {
            // ask user to input key
            createKeyButton.Font = new Font(createKeyButton.Font.Name, 10, FontStyle.Bold);
            createKeyButton.Text = "Press a key...";

            allowKeyCreation = true;

            // configure and start ControllerRefresh timer
            controllerPing.Elapsed += new ElapsedEventHandler(ControllerRefresh);
            controllerPing.Interval = 1;
            controllerPing.Enabled = true;
        }

        private void ControllerRefresh(object source, ElapsedEventArgs e)
        {
            // return if keys are not allowed to be created
            if (allowKeyCreation == false)
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

            Invoke((MethodInvoker)delegate
            {
                // create key
                FinalizeKeyFields();
                keyData_.fontSize = fontSize + controller_detect.Item3;
                Directory.CreateDirectory("Keystrokes\\presets\\" + keyData_.presetName + "\\assets");

                // display key with keyData_ settings
                key newKey = new key(keyData_);
                newKey.Show();
                // add key to child list
                keys.Add(newKey);
            });

            // lock create button
            allowKeyCreation = false;
        }

        private void createKeyButton_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // prevent user from making a new key if the create button was not pressed
            if (allowKeyCreation == false)
                return;

            // get and process key code
            Keys keyCode = e.KeyCode;
            KeysConverter converter = new KeysConverter();
            Keys key = (Keys)converter.ConvertFrom(keyCode.ToString());
            string hexValue = ((int)key).ToString("X2");

            // configure key text
            keyData_.keyText = keyTextTextbox.Text == "" ? keyCode.ToString() : keyTextTextbox.Text;

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
            key newKey = new key(keyData_);
            newKey.Show();
            // add key to child list
            keys.Add(newKey);

            // lock create button
            allowKeyCreation = false;
        }

        private void FinalizeKeyFields()
        {
            // restore create button text
            createKeyButton.Text = "Create Key";
            createKeyButton.Font = new Font(createKeyButton.Font.Name, 16, FontStyle.Bold);

            // are user options valid? if not, assign them the default values
            if (IsNumber(keyWidthTextbox.Text, "int") == false) keyWidthTextbox.Text = "60";
            if (IsNumber(keyHeightTextbox.Text, "int") == false) keyHeightTextbox.Text = "60";
            if (IsNumber(keyOpacityTextbox.Text, "float") == false) keyOpacityTextbox.Text = "0.8";
            if (IsNumber(wiggleAmountTextbox.Text, "int") == false) keyWidthTextbox.Text = "2";
            if (IsNumber(wiggleBiasUpTextbox.Text, "int") == false) wiggleBiasUpTextbox.Text = "0";
            if (IsNumber(wiggleBiasDownTextbox.Text, "int") == false) wiggleBiasDownTextbox.Text = "0";
            if (IsNumber(wiggleBiasLeftTextbox.Text, "int") == false) wiggleBiasLeftTextbox.Text = "0";
            if (IsNumber(wiggleBiasRightTextbox.Text, "int") == false) wiggleBiasRightTextbox.Text = "0";

            // send user data to keyData_
            keyData_.presetName = presetNameCombobox.Text;

            keyData_.keySizeX = int.Parse(keyWidthTextbox.Text);
            keyData_.keySizeY = int.Parse(keyHeightTextbox.Text);

            // configure controller font size
            keyData_.keyFont = keyData_.keyFont == null ? "Microsoft Sans Serif" : keyData_.keyFont;
            keyData_.fontSize = keyData_.isControllerKey == true ? keyData_.fontSize : fontSize;
            keyData_.fontStyle = keyData_.fontStyle == FontStyle.Regular ? FontStyle.Regular : keyData_.fontStyle;
            keyData_.showText = showTextCheckbox.Checked;

            keyData_.keyColorPressedInvert = keyColorPressedInvertCheckbox.Checked;
            keyData_.keyTextColorPressedInvert = keyTextColorPressedInvertCheckbox.Checked;

            keyData_.keyOpacity = float.Parse(keyOpacityTextbox.Text) / 100;

            keyData_.soundVolume = float.Parse(soundVolumeTextbox.Text) / 100;
            keyData_.soundPressedVolume = float.Parse(soundPressedVolumeTextbox.Text) / 100;

            // configure border style
            switch (keyBorderCombobox.Text)
            {
                case "Solid": keyData_.keyBorder = ButtonBorderStyle.Solid; break;
                case "Inset": keyData_.keyBorder = ButtonBorderStyle.Inset; break;
                case "Outset": keyData_.keyBorder = ButtonBorderStyle.Outset; break;
                case "Dashed": keyData_.keyBorder = ButtonBorderStyle.Dashed; break;
                case "None": keyData_.keyBorder = ButtonBorderStyle.None; break;
            }

            if (keyData_.useTransparentBackground == true)
                keyData_.keyBorder = ButtonBorderStyle.None;

            keyData_.USE_KEY_COUNT = useKeyCountCheckbox.Checked;

            keyData_.wiggleMode = wiggleModeCheckbox.Checked == true ? true : false;
            keyData_.wiggleMode_wiggleAmount = int.Parse(wiggleAmountTextbox.Text);
            keyData_.wiggleMode_biasUp = int.Parse(wiggleBiasUpTextbox.Text);
            keyData_.wiggleMode_biasDown = int.Parse(wiggleBiasDownTextbox.Text);
            keyData_.wiggleMode_biasLeft = int.Parse(wiggleBiasLeftTextbox.Text);
            keyData_.wiggleMode_biasRight = int.Parse(wiggleBiasRightTextbox.Text);
        }

        private void keyWidthTextbox_TextChanged(object sender, EventArgs e)
        {
            // is data a number? if not, return
            if (IsNumber(keyWidthTextbox.Text, "int") == false)
                return;

            // update key preview
            keyPreviewPanel.Width = int.Parse(keyWidthTextbox.Text);
            keyPreview2Panel.Width = int.Parse(keyWidthTextbox.Text);
            FormatKeyPreview();

            // resize form to fit key preview
            ResizeForm();
        }

        private void keyHeightTextbox_TextChanged(object sender, EventArgs e)
        {
            // is data a number? if not, return
            if (IsNumber(keyHeightTextbox.Text, "int") == false)
                return;

            // update key preview
            keyPreviewPanel.Height = int.Parse(keyHeightTextbox.Text);
            keyPreview2Panel.Height = int.Parse(keyHeightTextbox.Text);
            FormatKeyPreview();

            // resize form to fit key preview
            ResizeForm();
        }

        private void keyTextTextbox_TextChanged(object sender, EventArgs e)
        {
            keyPreviewTextLabel.Text = keyTextTextbox.Text;
            if (keyTextTextbox.Text == "")
                keyPreviewTextLabel.Text = "A";

            keyPreview2TextLabel.Text = keyTextTextbox.Text;
            if (keyTextTextbox.Text == "")
                keyPreview2TextLabel.Text = "A";

            FormatKeyPreview();
        }

        private void fontButton_Click(object sender, EventArgs e)
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
                keyData_.fontStyle = fontStyle;

                // update key previews
                keyPreviewTextLabel.Font = new Font(selectedFont.Name, selectedFont.Size, fontStyle);
                keyPreview2TextLabel.Font = new Font(selectedFont.Name, selectedFont.Size, fontStyle);

                FormatKeyPreview();
            }
        }

        private void useKeyCountCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            counterLabel.Text = useKeyCountCheckbox.Checked == true ? "0" : "";
            counter2Label.Text = useKeyCountCheckbox.Checked == true ? "0" : "";
        }

        private void showTextCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            keyPreviewTextLabel.Text = showTextCheckbox.Checked == true ? (keyTextTextbox.Text == "" ? "A" : keyTextTextbox.Text) : "";
            keyPreview2TextLabel.Text = showTextCheckbox.Checked == true ? (keyTextTextbox.Text == "" ? "A" : keyTextTextbox.Text) : "";
        }

        private void keyColorButton_Click(object sender, EventArgs e)
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
            keyColorButton.FlatAppearance.BorderColor = Color.FromArgb(255, keyData_.keyColorR, keyData_.keyColorG, keyData_.keyColorB);

            FormatKeyPreview();
        }

        private void keyTextColorButton_Click(object sender, EventArgs e)
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
            keyTextColorButton.FlatAppearance.BorderColor = Color.FromArgb(255, keyData_.keyTextColorR, keyData_.keyTextColorG, keyData_.keyTextColorB);

            FormatKeyPreview();
        }

        private void keyColorPressedButton_Click(object sender, EventArgs e)
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
            keyColorPressedButton.FlatAppearance.BorderColor = Color.FromArgb(255, keyData_.keyColorPressedR, keyData_.keyColorPressedG, keyData_.keyColorPressedB);

            FormatKeyPreview();
        }

        private void keyTextColorPressedButton_Click(object sender, EventArgs e)
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
            keyTextColorPressedButton.FlatAppearance.BorderColor = Color.FromArgb(255, keyData_.keyTextColorPressedR, keyData_.keyTextColorPressedG, keyData_.keyTextColorPressedB);

            FormatKeyPreview();
        }

        private void imageButton_Click(object sender, EventArgs e)
        {
            keyData_.keyBackgroundImage = PrepareImageDialog();

            if (keyData_.keyBackgroundImage == "" || presetNameCombobox.Text == "")
                return;

            Image backgroundImage = Image.FromFile(keyData_.keyBackgroundImage);
            keyPreviewPanel.BackgroundImage = backgroundImage;
            keyPreviewPanel.BackgroundImageLayout = ImageLayout.Stretch;

            imageDisposeButton.ForeColor = Color.FromArgb(255, 250, 220, 220);
        }

        private void imageDisposeButton_Click(object sender, EventArgs e)
        {
            keyData_.keyBackgroundImage = "";

            keyPreviewPanel.BackgroundImage = null;

            imageDisposeButton.ForeColor = Color.FromArgb(255, 150, 150, 150);
        }

        private void imagePressedButton_Click(object sender, EventArgs e)
        {
            keyData_.keyBackgroundImagePressed = PrepareImageDialog();

            if (keyData_.keyBackgroundImagePressed == "")
                return;

            Image backgroundImage = Image.FromFile(keyData_.keyBackgroundImagePressed);
            keyPreview2Panel.BackgroundImage = backgroundImage;
            keyPreview2Panel.BackgroundImageLayout = ImageLayout.Stretch;

            imagePressedDisposeButton.ForeColor = Color.FromArgb(255, 250, 220, 220);
        }

        private void imagePressedDisposeButton_Click(object sender, EventArgs e)
        {
            keyData_.keyBackgroundImage = "";

            keyPreview2Panel.BackgroundImage = null;

            imagePressedDisposeButton.ForeColor = Color.FromArgb(255, 150, 150, 150);
        }

        private void soundButton_Click(object sender, EventArgs e)
        {
            keyData_.sound = PrepareAudioDialog();

            if (keyData_.sound == "")
                return;
            soundDisposeButton.ForeColor = Color.FromArgb(255, 250, 220, 220);
        }

        private void soundDisposeButton_Click(object sender, EventArgs e)
        {
            keyData_.sound = "";

            soundDisposeButton.ForeColor = Color.FromArgb(255, 150, 150, 150);
        }

        private void soundPressedButton_Click(object sender, EventArgs e)
        {
            keyData_.soundPressed = PrepareAudioDialog();

            if (keyData_.soundPressed == "")
                return;
            soundPressedDisposeButton.ForeColor = Color.FromArgb(255, 250, 220, 220);
        }

        private void soundPressedDisposeButton_Click(object sender, EventArgs e)
        {
            keyData_.soundPressed = "";

            soundPressedDisposeButton.ForeColor = Color.FromArgb(255, 150, 150, 150);
        }

        private void keyColorPressedInvertCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            FormatKeyPreview();
        }

        private void keyTextColorPressedInvertCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            FormatKeyPreview();
        }

        private void closeButton_Click(object sender, EventArgs e)
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
                if (presetNameCombobox.Text == "") presetNameCombobox.Text = "Default";

                Directory.CreateDirectory("Keystrokes\\presets\\" + presetNameCombobox.Text + "\\assets");

                Image image = Image.FromFile(fileDialog.FileName);
                ImageCodecInfo codec = ImageCodecInfo.GetImageDecoders().FirstOrDefault(c => c.FormatID == ImageFormat.Jpeg.Guid);

                EncoderParameters parameters = new EncoderParameters(1);
                parameters.Param[0] = new EncoderParameter(Encoder.Quality, 90L);

                string output = "Keystrokes\\presets\\" + presetNameCombobox.Text + "\\assets\\" + GenerateID(8) + ".jpg";
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
                if (presetNameCombobox.Text == "") presetNameCombobox.Text = "Default";

                Directory.CreateDirectory("Keystrokes\\presets\\" + presetNameCombobox.Text + "\\assets");

                string output = "Keystrokes\\presets\\" + presetNameCombobox.Text + "\\assets\\" + GenerateID(8) + ".wav";
                File.Copy(fileDialog.FileName, output);

                return output;
            }

            return "";
        }

        private void FormatKeyPreview()
        {
            keyPreviewTextLabel.Location = new Point((keyPreviewPanel.Width / 2) - (keyPreviewTextLabel.Width / 2), (keyPreviewPanel.Height / 2) - (keyPreviewTextLabel.Height / 2));
            counterLabel.Location = new Point(counterLabel.Location.X, keyPreviewPanel.Height - 16);

            keyPreview2Panel.Location = new Point(keyPreviewPanel.Width + 12, keyPreviewPanel.Location.Y);
            keyPreview2TextLabel.Location = new Point((keyPreview2Panel.Width / 2) - (keyPreview2TextLabel.Width / 2), (keyPreview2Panel.Height / 2) - (keyPreview2TextLabel.Height / 2));
            counter2Label.Location = new Point(counter2Label.Location.X, keyPreview2Panel.Height - 16);

            keyPreviewPressedLabel.Location = new Point(keyPreview2Panel.Location.X - 4, keyPreviewPressedLabel.Location.Y);

            keyPreviewPanel.BackColor = Color.FromArgb(255, keyData_.keyColorR, keyData_.keyColorG, keyData_.keyColorB);
            keyPreviewTextLabel.ForeColor = Color.FromArgb(255, keyData_.keyTextColorR, keyData_.keyTextColorG, keyData_.keyTextColorB);
            counterLabel.ForeColor = Color.FromArgb(255, keyData_.keyTextColorR, keyData_.keyTextColorG, keyData_.keyTextColorB);

            if (keyColorPressedInvertCheckbox.Checked == true)
                keyPreview2Panel.BackColor = Color.FromArgb(255, (byte)~keyData_.keyColorR, (byte)~keyData_.keyColorG, (byte)~keyData_.keyColorB);
            else
                keyPreview2Panel.BackColor = Color.FromArgb(255, keyData_.keyColorPressedR, keyData_.keyColorPressedG, keyData_.keyColorPressedB);

            if (keyTextColorPressedInvertCheckbox.Checked == true)
            {
                keyPreview2TextLabel.ForeColor = Color.FromArgb(255, (byte)~keyData_.keyTextColorR, (byte)~keyData_.keyTextColorG, (byte)~keyData_.keyTextColorB);
                counter2Label.ForeColor = Color.FromArgb(255, (byte)~keyData_.keyTextColorR, (byte)~keyData_.keyTextColorG, (byte)~keyData_.keyTextColorB);
            }
            else
            {
                keyPreview2TextLabel.ForeColor = Color.FromArgb(255, keyData_.keyTextColorPressedR, keyData_.keyTextColorPressedG, keyData_.keyTextColorPressedB);
                counter2Label.ForeColor = Color.FromArgb(255, keyData_.keyTextColorPressedR, keyData_.keyTextColorPressedG, keyData_.keyTextColorPressedB);
            }
        }

        private void ResizeForm()
        {
            if (form_SizeX + keyPreviewPanel.Width - 60 < form_SizeX)
                return;
            if (form_SizeY + keyPreviewPanel.Height - 60 < form_SizeY)
                return;

            // scale and move form and components
            Size = new Size(form_SizeX + keyPreviewPanel.Width * 2 - 120, form_SizeY + keyPreviewPanel.Height - 60);
            titlebarPanel.Size = new Size(titlebarPanel_SizeX + keyPreviewPanel.Width * 2 - 120, titlebarPanel_SizeY);
            closeButton.Location = new Point(closeButton_LocationX + keyPreviewPanel.Width * 2 - 120, closeButton_LocationY);
        }

        private void titlebarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void bannerPicture_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void useTransparentBackgroundCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            keyData_.useTransparentBackground = useTransparentBackgroundCheckbox.Checked;
        }
    }
}