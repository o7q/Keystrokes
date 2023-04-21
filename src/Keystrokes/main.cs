using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Keystrokes.Structure;
using static Keystrokes.Tools.keyTools;


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

            #region tooltipDictionary
            // bind tooltips
            string[] tooltipMap =
            {
                "minimizeButton", "Minimize",
                "closeButton", "Close",
                "presetListbox", "List of user presets",
                "creditLabel", "Keystrokes " + VERSION + " by o7q",
                "credit2Label", "Keystrokes " + VERSION + " by o7q",
                "refreshPresetsButton", "Refresh presets list",
                "loadPresetButton", "Load selected preset",
                "clearKeysButton", "Unload all presets",
                "deletePresetButton", "Delete selected preset",
                "addKeyButton", "Open key editor"
            };
            #endregion

            // configure tooltips
            for (int i = 0; i < tooltipMap.Length; i += 2)
                mainTooltip.SetToolTip(Controls.Find(tooltipMap[i], true)[0], tooltipMap[i + 1]);

            // configure tooltip draw
            mainTooltip.AutoPopDelay = 10000;
            mainTooltip.OwnerDraw = true;
            mainTooltip.BackColor = Color.FromArgb(20, 20, 20);
            mainTooltip.ForeColor = Color.FromArgb(150, 150, 150);
        }

        private void mainTooltip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
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

                try
                {
                    // load all settings into keyData_
                    keyData_.presetName = keySetting[0];

                    keyData_.keyId = keySetting[1];

                    keyData_.keyText = keySetting[2];
                    keyData_.keyCode = Int32.Parse(keySetting[3]);

                    keyData_.keySizeX = Int32.Parse(keySetting[4]);
                    keyData_.keySizeY = Int32.Parse(keySetting[5]);

                    keyData_.fontSize = Int32.Parse(keySetting[6]);
                    keyData_.showText = bool.Parse(keySetting[7]);

                    keyData_.keyColorR = Int32.Parse(keySetting[8]);
                    keyData_.keyColorG = Int32.Parse(keySetting[9]);
                    keyData_.keyColorB = Int32.Parse(keySetting[10]);

                    keyData_.keyTextColorR = Int32.Parse(keySetting[11]);
                    keyData_.keyTextColorG = Int32.Parse(keySetting[12]);
                    keyData_.keyTextColorB = Int32.Parse(keySetting[13]);

                    keyData_.keyColorPressedR = Int32.Parse(keySetting[14]);
                    keyData_.keyColorPressedG = Int32.Parse(keySetting[15]);
                    keyData_.keyColorPressedB = Int32.Parse(keySetting[16]);
                    keyData_.keyColorPressedInvert = bool.Parse(keySetting[17]);

                    keyData_.keyTextColorPressedR = Int32.Parse(keySetting[18]);
                    keyData_.keyTextColorPressedG = Int32.Parse(keySetting[19]);
                    keyData_.keyTextColorPressedB = Int32.Parse(keySetting[20]);
                    keyData_.keyTextColorPressedInvert = bool.Parse(keySetting[21]);
                    keyData_.keyOpacity = float.Parse(keySetting[22]);

                    keyData_.keyBackgroundImage = keySetting[23];
                    keyData_.keyBackgroundImagePressed = keySetting[24];

                    keyData_.sound = keySetting[25];
                    keyData_.soundPressed = keySetting[26];

                    keyData_.keyBorder = (ButtonBorderStyle)Enum.Parse(typeof(ButtonBorderStyle), keySetting[27]);

                    // dynamic
                    keyData_.KEY_LOCATION_X = Int32.Parse(keySetting[28]);
                    keyData_.KEY_LOCATION_Y = Int32.Parse(keySetting[29]);

                    keyData_.KEY_SNAP_X = Int32.Parse(keySetting[30]);
                    keyData_.KEY_SNAP_Y = Int32.Parse(keySetting[31]);

                    keyData_.KEY_LOCKED = bool.Parse(keySetting[32]);

                    keyData_.USE_KEY_COUNT = bool.Parse(keySetting[33]);
                    keyData_.KEY_COUNT = Int32.Parse(keySetting[34]);

                    // secret
                    keyData_.wiggleMode = bool.Parse(keySetting[35]);
                    keyData_.wiggleMode_wiggleAmount = Int32.Parse(keySetting[36]);
                    keyData_.wiggleMode_biasUp = Int32.Parse(keySetting[37]);
                    keyData_.wiggleMode_biasDown = Int32.Parse(keySetting[38]);
                    keyData_.wiggleMode_biasRight = Int32.Parse(keySetting[39]);
                    keyData_.wiggleMode_biasLeft = Int32.Parse(keySetting[40]);
                }
                catch (Exception ex)
                {
                    DialogResult prompt = MessageBox.Show("Unable to load key: " + (keySetting[1] == null ? "NULL" : keySetting[1]) + "\nWas it created in an older version?\n\nPress OK to attempt farther loading\nPress CANCEL to abort\n\n" + ex, "", MessageBoxButtons.OKCancel);
                    if (prompt == DialogResult.Cancel) return;
                    continue;
                }

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
            try { Directory.Delete("Keystrokes\\presets\\" + presetListbox.SelectedItem, true); } catch { }
            refreshPresetList();
        }

        private void addKeyButton_Click(object sender, EventArgs e)
        {
            // prevent multiple editors from being opened
            FormCollection allForms = Application.OpenForms;
            foreach (Form form in allForms)
                if (form.Name == "keymaker") return;

            // open key editor
            keymaker keyEditor = new keymaker();
            keyEditor.FormClosed += keymakerFormClosed;
            keyEditor.Show();
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
            if (presetListbox.Items.Count >= 1 == true) presetListbox.SelectedIndex = 0;
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