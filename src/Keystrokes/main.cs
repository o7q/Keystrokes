using System;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Keystrokes.obj;
using static Keystrokes.obj.keyTools;


namespace Keystrokes
{
    public partial class main : Form
    {
        // configure mouse window events
        public const int HT_CAPTION = 0x2;
        public const int WM_NCLBUTTONDOWN = 0xA1;

        // grab dlls for mousedown
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            // initialize presets
            Directory.CreateDirectory("Keystrokes\\presets");
            refreshPresetList();

            // display keystrokes credit text
            creditLabel.Text = "Keystrokes " + VERSION;
            credit2Label.Left = creditLabel.Width + 12;
        }

        private void loadPresetButton_Click(object sender, EventArgs e)
        {
            // load keys into array
            string[] files = Directory.GetFiles("Keystrokes\\presets\\" + presetListbox.SelectedItem, "*.key");
            foreach (string file in files)
            {
                var name = new FileInfo(file).Name;

                // load data from file
                string keyFilePath = "Keystrokes\\presets\\" + presetListbox.SelectedItem + "\\" + name;
                string keyFile = File.ReadAllText(keyFilePath);

                string[] keySetting = keyFile.Split('|');
                keyInfo keyData_;

                // load all settings into keyData_
                keyData_.presetName = keySetting[0];

                keyData_.keyId = keySetting[1];

                keyData_.keyText = keySetting[2];
                keyData_.keyCode = Int32.Parse(keySetting[3]);

                keyData_.keySizeX = Int32.Parse(keySetting[4]);
                keyData_.keySizeY = Int32.Parse(keySetting[5]);

                keyData_.fontSize = Int32.Parse(keySetting[6]);

                keyData_.keyColorR = Int32.Parse(keySetting[7]);
                keyData_.keyColorG = Int32.Parse(keySetting[8]);
                keyData_.keyColorB = Int32.Parse(keySetting[9]);

                keyData_.keyTextColorR = Int32.Parse(keySetting[10]);
                keyData_.keyTextColorG = Int32.Parse(keySetting[11]);
                keyData_.keyTextColorB = Int32.Parse(keySetting[12]);

                keyData_.keyColorPressedR = Int32.Parse(keySetting[13]);
                keyData_.keyColorPressedG = Int32.Parse(keySetting[14]);
                keyData_.keyColorPressedB = Int32.Parse(keySetting[15]);
                keyData_.keyColorPressedInvert = bool.Parse(keySetting[16]);

                keyData_.keyTextColorPressedR = Int32.Parse(keySetting[17]);
                keyData_.keyTextColorPressedG = Int32.Parse(keySetting[18]);
                keyData_.keyTextColorPressedB = Int32.Parse(keySetting[19]);
                keyData_.keyTextColorPressedInvert = bool.Parse(keySetting[20]);
                keyData_.keyOpacity = float.Parse(keySetting[21]);

                keyData_.keyBorder = (ButtonBorderStyle)Enum.Parse(typeof(ButtonBorderStyle), keySetting[22]);

                keyData_.KEY_LOCATION_X = Int32.Parse(keySetting[23]);
                keyData_.KEY_LOCATION_Y = Int32.Parse(keySetting[24]);

                // display key with keyData_ settings
                key newKey = new key(keyData_);
                newKey.Show();
                keys.Add(newKey);
            }
        }

        private void clearKeysButton_Click(object sender, EventArgs e)
        {
            // dispose of all child forms
            foreach (Form childForm in keys)
                childForm.Close();
            keys.Clear();
        }

        private void deletePresetButton_Click(object sender, EventArgs e)
        {
            // do any presets exist? if not, return
            if (Directory.GetDirectories("Keystrokes\\presets").Length == 0) return;

            // delete selected preset
            Directory.Delete("Keystrokes\\presets\\" + presetListbox.SelectedItem, true);
            refreshPresetList();
        }

        private void addKeyButton_Click(object sender, EventArgs e)
        {
            // open key editor
            keymaker keyEditor = new keymaker();
            keyEditor.FormClosed += keymakerFormClosed;
            keyEditor.ShowDialog();
        }

        private void refreshPresetsButton_Click(object sender, EventArgs e)
        {
            refreshPresetList();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void refreshPresetList()
        {
            // load all presets into combobox
            presetListbox.Items.Clear();
            foreach (string file in Directory.GetDirectories("Keystrokes\\presets"))
                presetListbox.Items.Add(Path.GetFileName(file));

            // set selectedindex to 0 if there is at least 1 preset
            if (presetListbox.Items.Count < 1 == false) presetListbox.SelectedIndex = 0;
        }

        private void keymakerFormClosed(object sender, FormClosedEventArgs e)
        {
            refreshPresetList();
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