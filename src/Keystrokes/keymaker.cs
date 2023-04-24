using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Keystrokes.Structure;
using static Keystrokes.Tools.keyTools;
using static Keystrokes.Fixes.keyFixes;

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
        const int form_SizeY = 351;
        const int titlebarPanel_SizeX = 303;
        const int titlebarPanel_SizeY = 31;
        const int closeButton_LocationX = 216;
        const int closeButton_LocationY = 6;

        public keymaker()
        {
            InitializeComponent();
        }

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

            // configure key preview window
            keyPreviewTextLabel.Font = new Font(keyPreviewTextLabel.Font.Name, 20);

            keyPreviewPanel.Width = 60;
            keyPreviewPanel.Height = 60;

            keyPreviewPanel.BackColor = Color.FromArgb(255, 0, 0, 0);
            keyPreviewTextLabel.ForeColor = Color.FromArgb(255, 255, 255, 255);
            counterLabel.ForeColor = Color.FromArgb(255, 255, 255, 255);
            counterLabel.Text = "";

            formatKeyPreview();
            resizeForm();

            #region tooltipDictionary
            // bind tooltips
            string[] tooltipMap =
            {
                "closeButton", "Close",
                "presetNameCombobox", "Name of preset to edit/create",
                "keyWidthTextbox", "Key width in pixels",
                "keyHeightTextbox", "Key height in pixels",
                "keyTextTextbox", "Custom key text",
                "fontSizeTextbox", "Text font size",
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
        }

        private void createKeyButton_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // prevent user from making a new key if the create button was not pressed
            if (allowKeyCreation == false) return;

            Keys keyCode = e.KeyCode;
            KeysConverter converter = new KeysConverter();
            Keys key = (Keys)converter.ConvertFrom(keyCode.ToString());
            string hexValue = ((int)key).ToString("X2");

            // restore create button text
            createKeyButton.Text = "Create Key";
            createKeyButton.Font = new Font(createKeyButton.Font.Name, 16, FontStyle.Bold);

            // are user options valid? if not, assign them the default values
            if (isNumber(keyWidthTextbox.Text, "int") == false) keyWidthTextbox.Text = "60";
            if (isNumber(keyHeightTextbox.Text, "int") == false) keyHeightTextbox.Text = "60";
            if (isNumber(fontSizeTextbox.Text, "int") == false) fontSizeTextbox.Text = "20";
            if (isNumber(keyOpacityTextbox.Text, "float") == false) keyOpacityTextbox.Text = "0.8";
            if (isNumber(wiggleAmountTextbox.Text, "int") == false) keyWidthTextbox.Text = "2";
            if (isNumber(wiggleBiasUpTextbox.Text, "int") == false) wiggleBiasUpTextbox.Text = "0";
            if (isNumber(wiggleBiasDownTextbox.Text, "int") == false) wiggleBiasDownTextbox.Text = "0";
            if (isNumber(wiggleBiasRightTextbox.Text, "int") == false) wiggleBiasRightTextbox.Text = "0";
            if (isNumber(wiggleBiasLeftTextbox.Text, "int") == false) wiggleBiasLeftTextbox.Text = "0";

            // send user data to keyData_
            keyData_.presetName = presetNameCombobox.Text;

            keyData_.keyText = keyTextTextbox.Text == "" ? keyCode.ToString() : keyTextTextbox.Text;

            // fix keytext with proper keys
            for (int i = 0; i < keyTextFixes.Length; i += 2)
                if (keyData_.keyText == keyTextFixes[i + 1]) keyData_.keyText = keyTextFixes[i];

            keyData_.keyCode = Convert.ToInt32(hexValue, 16);

            keyData_.keySizeX = Int32.Parse(keyWidthTextbox.Text);
            keyData_.keySizeY = Int32.Parse(keyHeightTextbox.Text);

            keyData_.fontSize = Int32.Parse(fontSizeTextbox.Text);
            keyData_.showText = showTextCheckbox.Checked;

            keyData_.keyColorPressedInvert = keyColorPressedInvertCheckbox.Checked;
            keyData_.keyTextColorPressedInvert = keyTextColorPressedInvertCheckbox.Checked;

            keyData_.keyOpacity = float.Parse(keyOpacityTextbox.Text) / 100;

            keyData_.soundVolume = float.Parse(soundVolumeTextbox.Text) / 100;
            keyData_.soundPressedVolume = float.Parse(soundPressedVolumeTextbox.Text) / 100;

            switch (keyBorderCombobox.SelectedIndex)
            {
                case 0: keyData_.keyBorder = ButtonBorderStyle.Solid; break;
                case 1: keyData_.keyBorder = ButtonBorderStyle.Inset; break;
                case 2: keyData_.keyBorder = ButtonBorderStyle.Outset; break;
                case 3: keyData_.keyBorder = ButtonBorderStyle.Dashed; break;
                case 4: keyData_.keyBorder = ButtonBorderStyle.None; break;
            }

            keyData_.USE_KEY_COUNT = useKeyCountCheckbox.Checked;

            keyData_.wiggleMode = wiggleModeCheckbox.Checked == true ? true : false;
            keyData_.wiggleMode_wiggleAmount = Int32.Parse(wiggleAmountTextbox.Text);
            keyData_.wiggleMode_biasUp = Int32.Parse(wiggleBiasUpTextbox.Text);
            keyData_.wiggleMode_biasDown = Int32.Parse(wiggleBiasDownTextbox.Text);
            keyData_.wiggleMode_biasRight = Int32.Parse(wiggleBiasRightTextbox.Text);
            keyData_.wiggleMode_biasLeft = Int32.Parse(wiggleBiasLeftTextbox.Text);

            Directory.CreateDirectory("Keystrokes\\presets\\" + keyData_.presetName + "\\assets");

            // display key with keyData_ settings
            key newKey = new key(keyData_);
            newKey.Show();
            // add key to child list
            keys.Add(newKey);

            // lock create button
            allowKeyCreation = false;
        }

        private void keyWidthTextbox_TextChanged(object sender, EventArgs e)
        {
            // is data a number? if not, return
            if (isNumber(keyWidthTextbox.Text, "int") == false) return;

            // update key preview
            keyPreviewPanel.Width = Int32.Parse(keyWidthTextbox.Text);
            formatKeyPreview();

            // resize form to fit key preview
            resizeForm();
        }

        private void keyHeightTextbox_TextChanged(object sender, EventArgs e)
        {
            // is data a number? if not, return
            if (isNumber(keyHeightTextbox.Text, "int") == false) return;

            // update key preview
            keyPreviewPanel.Height = Int32.Parse(keyHeightTextbox.Text);
            formatKeyPreview();

            // resize form to fit key preview
            resizeForm();
        }

        private void fontSizeTextbox_TextChanged(object sender, EventArgs e)
        {
            // is data a number? if not, return
            if (isNumber(fontSizeTextbox.Text, "int") == false) return;

            // update key preview
            keyPreviewTextLabel.Font = new Font(keyPreviewTextLabel.Font.Name, Int32.Parse(fontSizeTextbox.Text));
            formatKeyPreview();
        }

        private void showTextCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            keyPreviewTextLabel.Text = showTextCheckbox.Checked == true ? (keyTextTextbox.Text == "" ? "A" : keyTextTextbox.Text) : "";
        }

        private void keyColorButton_Click(object sender, EventArgs e)
        {
            // open new color dialog
            var rgb = openColorDialog();
            if (rgb == null) return;

            // split r, g, b values
            keyData_.keyColorR = rgb.Item1;
            keyData_.keyColorG = rgb.Item2;
            keyData_.keyColorB = rgb.Item3;

            // update component visuals
            keyPreviewPanel.BackColor = Color.FromArgb(255, keyData_.keyColorR, keyData_.keyColorG, keyData_.keyColorB);
            keyColorButton.FlatAppearance.BorderColor = Color.FromArgb(255, keyData_.keyColorR, keyData_.keyColorG, keyData_.keyColorB);
        }

        private void keyTextColorButton_Click(object sender, EventArgs e)
        {
            // open new color dialog
            var rgb = openColorDialog();
            if (rgb == null) return;

            // split r, g, b values
            keyData_.keyTextColorR = rgb.Item1;
            keyData_.keyTextColorG = rgb.Item2;
            keyData_.keyTextColorB = rgb.Item3;

            // update component visuals
            keyPreviewTextLabel.ForeColor = Color.FromArgb(255, keyData_.keyTextColorR, keyData_.keyTextColorG, keyData_.keyTextColorB);
            counterLabel.ForeColor = Color.FromArgb(255, keyData_.keyTextColorR, keyData_.keyTextColorG, keyData_.keyTextColorB);
            keyTextColorButton.FlatAppearance.BorderColor = Color.FromArgb(255, keyData_.keyTextColorR, keyData_.keyTextColorG, keyData_.keyTextColorB);
        }

        private void keyColorPressedButton_Click(object sender, EventArgs e)
        {
            // open new color dialog
            var rgb = openColorDialog();
            if (rgb == null) return;

            // split r, g, b values
            keyData_.keyColorPressedR = rgb.Item1;
            keyData_.keyColorPressedG = rgb.Item2;
            keyData_.keyColorPressedB = rgb.Item3;

            // update component visuals
            keyColorPressedButton.FlatAppearance.BorderColor = Color.FromArgb(255, keyData_.keyColorPressedR, keyData_.keyColorPressedG, keyData_.keyColorPressedB);
        }

        private void keyTextColorPressedButton_Click(object sender, EventArgs e)
        {
            // open new color dialog
            var rgb = openColorDialog();
            if (rgb == null) return;

            // split r, g, b values
            keyData_.keyTextColorPressedR = rgb.Item1;
            keyData_.keyTextColorPressedG = rgb.Item2;
            keyData_.keyTextColorPressedB = rgb.Item3;

            // update component visuals
            keyTextColorPressedButton.FlatAppearance.BorderColor = Color.FromArgb(255, keyData_.keyTextColorPressedR, keyData_.keyTextColorPressedG, keyData_.keyTextColorPressedB);
        }

        private void imageButton_Click(object sender, EventArgs e)
        {
            keyData_.keyBackgroundImage = prepareImageDialog();

            if (keyData_.keyBackgroundImage == "" || presetNameCombobox.Text == "") return;

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
            keyData_.keyBackgroundImagePressed = prepareImageDialog();

            if (keyData_.keyBackgroundImagePressed == "") return;
            imagePressedDisposeButton.ForeColor = Color.FromArgb(255, 250, 220, 220);
        }

        private void imagePressedDisposeButton_Click(object sender, EventArgs e)
        {
            keyData_.keyBackgroundImage = "";

            imagePressedDisposeButton.ForeColor = Color.FromArgb(255, 150, 150, 150);
        }

        private void soundButton_Click(object sender, EventArgs e)
        {
            keyData_.sound = prepareAudioDialog();

            if (keyData_.sound == "") return;
            soundDisposeButton.ForeColor = Color.FromArgb(255, 250, 220, 220);
        }

        private void soundDisposeButton_Click(object sender, EventArgs e)
        {
            keyData_.sound = "";

            soundDisposeButton.ForeColor = Color.FromArgb(255, 150, 150, 150);
        }

        private void soundPressedButton_Click(object sender, EventArgs e)
        {
            keyData_.soundPressed = prepareAudioDialog();

            if (keyData_.soundPressed == "") return;
            soundPressedDisposeButton.ForeColor = Color.FromArgb(255, 250, 220, 220);
        }

        private void soundPressedDisposeButton_Click(object sender, EventArgs e)
        {
            keyData_.soundPressed = "";

            soundPressedDisposeButton.ForeColor = Color.FromArgb(255, 150, 150, 150);
        }

        private void useKeyCountCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            counterLabel.Text = useKeyCountCheckbox.Checked == true ? "0" : "";
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void keyPreviewPanel_Paint(object sender, PaintEventArgs e)
        {
            // draw custom key preview border
            int r = keyData_.keyColorR - 50 < 0 ? 0 : keyData_.keyColorR - 50;
            int g = keyData_.keyColorG - 50 < 0 ? 0 : keyData_.keyColorG - 50;
            int b = keyData_.keyColorB - 50 < 0 ? 0 : keyData_.keyColorB - 50;
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(255, r, g, b), ButtonBorderStyle.Solid);
        }

        private Tuple<int, int, int> openColorDialog()
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AnyColor = true;

            int r = 0;
            int g = 0;
            int b = 0;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                r = Convert.ToInt32(colorDialog.Color.R);
                g = Convert.ToInt32(colorDialog.Color.G);
                b = Convert.ToInt32(colorDialog.Color.B);
                return Tuple.Create(r, g, b);
            }

            return null;
        }

        private string prepareImageDialog()
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

                string output = "Keystrokes\\presets\\" + presetNameCombobox.Text + "\\assets\\" + generateID(8) + ".jpg";
                image.Save(output, codec, parameters);
                image.Dispose();

                return output;
            }

            return "";
        }

        private string prepareAudioDialog()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Wave File (*.wav)|*.wav";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (presetNameCombobox.Text == "") presetNameCombobox.Text = "Default";

                Directory.CreateDirectory("Keystrokes\\presets\\" + presetNameCombobox.Text + "\\assets");

                string output = "Keystrokes\\presets\\" + presetNameCombobox.Text + "\\assets\\" + generateID(8) + ".wav";
                File.Copy(fileDialog.FileName, output);

                return output;
            }

            return "";
        }

        private void formatKeyPreview()
        {
            keyPreviewTextLabel.Location = new Point((keyPreviewPanel.Width / 2) - (keyPreviewTextLabel.Width / 2), (keyPreviewPanel.Height / 2) - (keyPreviewTextLabel.Height / 2));
            counterLabel.Location = new Point(counterLabel.Location.X, keyPreviewPanel.Height - 16);
        }

        private void resizeForm()
        {
            if (form_SizeX + keyPreviewPanel.Width - 60 < form_SizeX) return;
            if (form_SizeY + keyPreviewPanel.Height - 60 < form_SizeY) return;

            Size = new Size(form_SizeX + keyPreviewPanel.Width - 60, form_SizeY + keyPreviewPanel.Height - 60);
            titlebarPanel.Size = new Size(titlebarPanel_SizeX + keyPreviewPanel.Width - 60, titlebarPanel_SizeY);
            closeButton.Location = new Point(closeButton_LocationX + keyPreviewPanel.Width - 60, closeButton_LocationY);
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

        private void keyTextTextbox_TextChanged(object sender, EventArgs e)
        {
            keyPreviewTextLabel.Text = keyTextTextbox.Text;
            if (keyTextTextbox.Text == "") keyPreviewTextLabel.Text = "A";
            formatKeyPreview();
        }
    }
}