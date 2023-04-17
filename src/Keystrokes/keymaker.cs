using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Keystrokes.obj;
using static Keystrokes.obj.keyTools;

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

        keyInfo keyData_;

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

            keyBorderCombobox.SelectedIndex = 2;

            // configure key preview window
            keyPreviewTextLabel.Font = new Font(keyPreviewTextLabel.Font.Name, 20);

            keyPreviewPanel.Width = 60;
            keyPreviewPanel.Height = 60;

            keyPreviewPanel.BackColor = Color.FromArgb(255, 0, 0, 0);
            keyPreviewTextLabel.ForeColor = Color.FromArgb(255, 255, 255, 255);

            formatKeyPreview();
        }

        private void keyWidthTextbox_TextChanged(object sender, EventArgs e)
        {
            // is data a number? if not, return
            if (isNumber(keyWidthTextbox.Text, "int") == false) return;

            // update key preview
            keyPreviewPanel.Width = Int32.Parse(keyWidthTextbox.Text);
            formatKeyPreview();

            resizeForm();
        }

        private void keyHeightTextbox_TextChanged(object sender, EventArgs e)
        {
            // is data a number? if not, return
            if (isNumber(keyHeightTextbox.Text, "int") == false) return;

            // update key preview
            keyPreviewPanel.Height = Int32.Parse(keyHeightTextbox.Text);
            formatKeyPreview();

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

        private void keyColorButton_Click(object sender, EventArgs e)
        {
            var rgb = openColorDialog();

            keyData_.keyColorR = rgb.Item1;
            keyData_.keyColorG = rgb.Item2;
            keyData_.keyColorB = rgb.Item3;

            // update component visuals
            keyPreviewPanel.BackColor = Color.FromArgb(255, keyData_.keyColorR, keyData_.keyColorG, keyData_.keyColorB);
            keyColorButton.FlatAppearance.BorderColor = Color.FromArgb(255, keyData_.keyColorR, keyData_.keyColorG, keyData_.keyColorB);
        }

        private void keyTextColorButton_Click(object sender, EventArgs e)
        {
            var rgb = openColorDialog();

            keyData_.keyTextColorR = rgb.Item1;
            keyData_.keyTextColorG = rgb.Item2;
            keyData_.keyTextColorB = rgb.Item3;

            // update component visuals
            keyPreviewTextLabel.ForeColor = Color.FromArgb(255, keyData_.keyTextColorR, keyData_.keyTextColorG, keyData_.keyTextColorB);
            keyTextColorButton.FlatAppearance.BorderColor = Color.FromArgb(255, keyData_.keyTextColorR, keyData_.keyTextColorG, keyData_.keyTextColorB);
        }

        private void keyColorPressedButton_Click(object sender, EventArgs e)
        {
            var rgb = openColorDialog();

            keyData_.keyColorPressedR = rgb.Item1;
            keyData_.keyColorPressedG = rgb.Item2;
            keyData_.keyColorPressedB = rgb.Item3;

            // update component visuals
            keyColorPressedButton.FlatAppearance.BorderColor = Color.FromArgb(255, keyData_.keyColorPressedR, keyData_.keyColorPressedG, keyData_.keyColorPressedB);
        }

        private void keyTextColorPressedButton_Click(object sender, EventArgs e)
        {
            var rgb = openColorDialog();

            keyData_.keyTextColorPressedR = rgb.Item1;
            keyData_.keyTextColorPressedG = rgb.Item2;
            keyData_.keyTextColorPressedB = rgb.Item3;

            // update component visuals
            keyTextColorPressedButton.FlatAppearance.BorderColor = Color.FromArgb(255, keyData_.keyTextColorPressedR, keyData_.keyTextColorPressedG, keyData_.keyTextColorPressedB);
        }

        bool allowKeyCreation = false;

        private void createKeyButton_Click(object sender, EventArgs e)
        {
            // ask user to input key
            createKeyButton.Font = new Font(createKeyButton.Font.Name, 10, FontStyle.Bold);
            createKeyButton.Text = "Press a key...";
            allowKeyCreation = true;
        }

        private void createKeyButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (allowKeyCreation == false) return;

            Keys keyCode = e.KeyCode;
            KeysConverter converter = new KeysConverter();
            Keys key = (Keys)converter.ConvertFrom(keyCode.ToString());
            string hexValue = ((int)key).ToString("X2");

            createKeyButton.Text = "Create Key";
            createKeyButton.Font = new Font(createKeyButton.Font.Name, 16, FontStyle.Bold);

            // are user options valid? if not, assign them the default values
            if (isNumber(keyWidthTextbox.Text, "int") == false) keyWidthTextbox.Text = "60";
            if (isNumber(keyHeightTextbox.Text, "int") == false) keyHeightTextbox.Text = "60";
            if (isNumber(fontSizeTextbox.Text, "int") == false) fontSizeTextbox.Text = "20";
            if (isNumber(keyOpacityTextbox.Text, "float") == false) keyOpacityTextbox.Text = "0.8";

            // send user data to keyData_
            keyData_.presetName = presetNameCombobox.Text;

            keyData_.keyText = keyCode.ToString();

            // fix keytext with proper keys
            for (int i = 0; i < keyTextFixes.Length; i += 2)
                if (keyData_.keyText == keyTextFixes[i + 1]) keyData_.keyText = keyTextFixes[i];

            keyData_.keyCode = Convert.ToInt32(hexValue, 16);

            keyData_.keySizeX = Int32.Parse(keyWidthTextbox.Text);
            keyData_.keySizeY = Int32.Parse(keyHeightTextbox.Text);

            keyData_.fontSize = Int32.Parse(fontSizeTextbox.Text);

            keyData_.keyColorPressedInvert = keyColorPressedInvertCheckbox.Checked;
            keyData_.keyTextColorPressedInvert = keyTextColorPressedInvertCheckbox.Checked;

            keyData_.keyOpacity = float.Parse(keyOpacityTextbox.Text);

            switch (keyBorderCombobox.SelectedIndex)
            {
                case 0: keyData_.keyBorder = ButtonBorderStyle.Solid; break;
                case 1: keyData_.keyBorder = ButtonBorderStyle.Inset; break;
                case 2: keyData_.keyBorder = ButtonBorderStyle.Outset; break;
                case 3: keyData_.keyBorder = ButtonBorderStyle.Dashed; break;
                case 4: keyData_.keyBorder = ButtonBorderStyle.None; break;
            }

            Directory.CreateDirectory("Keystrokes\\presets\\" + keyData_.presetName);

            // display key with keyData_ settings
            key newKey = new key(keyData_);
            newKey.Show();
            keys.Add(newKey);

            allowKeyCreation = false;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void keyPreviewPanel_Paint(object sender, PaintEventArgs e)
        {
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
            }

            return Tuple.Create(r, g, b);
        }

        private void formatKeyPreview()
        {
            keyPreviewTextLabel.Location = new Point((keyPreviewPanel.Width / 2) - (keyPreviewTextLabel.Width / 2), (keyPreviewPanel.Height / 2) - (keyPreviewTextLabel.Height / 2));
        }

        private void resizeForm()
        {
            int form_SizeX = 236;
            int form_SizeY = 280;
            int titlebarPanel_SizeX = 303;
            int titlebarPanel_SizeY = 31;
            int closeButton_LocationX = 216;
            int closeButton_LocationY = 6;

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
    }
}