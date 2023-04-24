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
            KeyInfo keyData_ = new KeyInfo();

            // load keys into array
            string[] files = Directory.GetFiles("Keystrokes\\presets\\" + presetListbox.SelectedItem, "*.key");
            foreach (string file in files)
            {
                var name = new FileInfo(file).Name;

                // load data from file
                string keyFile = File.ReadAllText("Keystrokes\\presets\\" + presetListbox.SelectedItem + "\\" + name);
                string[] keySetting = keyFile.Split('\n');

                for (int i = 0; i < keySetting.Length; i++)
                {
                    string[] keySettingPair = keySetting[i].Split('=');

                    try
                    {
                        if (keySettingPair[0] == "presetName") keyData_.presetName = keySettingPair[1];

                        if (keySettingPair[0] == "keyId") keyData_.keyId = keySettingPair[1];

                        if (keySettingPair[0] == "keyText") keyData_.keyText = keySettingPair[1];
                        if (keySettingPair[0] == "keyCode") keyData_.keyCode = int.Parse(keySettingPair[1]);

                        if (keySettingPair[0] == "keySizeX") keyData_.keySizeX = int.Parse(keySettingPair[1]);
                        if (keySettingPair[0] == "keySizeY") keyData_.keySizeY = int.Parse(keySettingPair[1]);

                        if (keySettingPair[0] == "fontSize") keyData_.fontSize = int.Parse(keySettingPair[1]);
                        if (keySettingPair[0] == "showText") keyData_.showText = bool.Parse(keySettingPair[1]);

                        if (keySettingPair[0] == "keyColorR") keyData_.keyColorR = int.Parse(keySettingPair[1]);
                        if (keySettingPair[0] == "keyColorG") keyData_.keyColorG = int.Parse(keySettingPair[1]);
                        if (keySettingPair[0] == "keyColorB") keyData_.keyColorB = int.Parse(keySettingPair[1]);
                        //
                        if (keySettingPair[0] == "keyTextColorR") keyData_.keyTextColorR = int.Parse(keySettingPair[1]);
                        if (keySettingPair[0] == "keyTextColorG") keyData_.keyTextColorG = int.Parse(keySettingPair[1]);
                        if (keySettingPair[0] == "keyTextColorB") keyData_.keyTextColorB = int.Parse(keySettingPair[1]);
                        //
                        if (keySettingPair[0] == "keyColorPressedR") keyData_.keyColorPressedR = int.Parse(keySettingPair[1]);
                        if (keySettingPair[0] == "keyColorPressedG") keyData_.keyColorPressedG = int.Parse(keySettingPair[1]);
                        if (keySettingPair[0] == "keyColorPressedB") keyData_.keyColorPressedB = int.Parse(keySettingPair[1]);
                        if (keySettingPair[0] == "keyColorPressedInvert") keyData_.keyColorPressedInvert = bool.Parse(keySettingPair[1]);
                        //
                        if (keySettingPair[0] == "keyTextColorPressedR") keyData_.keyTextColorPressedR = int.Parse(keySettingPair[1]);
                        if (keySettingPair[0] == "keyTextColorPressedG") keyData_.keyTextColorPressedG = int.Parse(keySettingPair[1]);
                        if (keySettingPair[0] == "keyTextColorPressedB") keyData_.keyTextColorPressedB = int.Parse(keySettingPair[1]);
                        if (keySettingPair[0] == "keyTextColorPressedInvert") keyData_.keyTextColorPressedInvert = bool.Parse(keySettingPair[1]);

                        if (keySettingPair[0] == "keyOpacity") keyData_.keyOpacity = float.Parse(keySettingPair[1]);

                        if (keySettingPair[0] == "keyBackgroundImage") keyData_.keyBackgroundImage = keySettingPair[1];
                        if (keySettingPair[0] == "keyBackgroundImagePressed") keyData_.keyBackgroundImagePressed = keySettingPair[1];

                        if (keySettingPair[0] == "sound") keyData_.sound = keySettingPair[1];
                        if (keySettingPair[0] == "soundVolume") keyData_.soundVolume = float.Parse(keySettingPair[1]);
                        //
                        if (keySettingPair[0] == "soundPressed") keyData_.soundPressed = keySettingPair[1];
                        if (keySettingPair[0] == "soundPressedVolume") keyData_.soundPressedVolume = float.Parse(keySettingPair[1]);

                        if (keySettingPair[0] == "keyBorder") keyData_.keyBorder = (ButtonBorderStyle)Enum.Parse(typeof(ButtonBorderStyle), keySettingPair[1]);

                        // dynamic
                        if (keySettingPair[0] == "KEY_LOCATION_X") keyData_.KEY_LOCATION_X = int.Parse(keySettingPair[1]);
                        if (keySettingPair[0] == "KEY_LOCATION_Y") keyData_.KEY_LOCATION_Y = int.Parse(keySettingPair[1]);

                        if (keySettingPair[0] == "KEY_SNAP_X") keyData_.KEY_SNAP_X = int.Parse(keySettingPair[1]);
                        if (keySettingPair[0] == "KEY_SNAP_Y") keyData_.KEY_SNAP_Y = int.Parse(keySettingPair[1]);

                        if (keySettingPair[0] == "KEY_LOCKED") keyData_.KEY_LOCKED = bool.Parse(keySettingPair[1]);

                        if (keySettingPair[0] == "USE_KEY_COUNT") keyData_.USE_KEY_COUNT = bool.Parse(keySettingPair[1]);
                        if (keySettingPair[0] == "KEY_COUNT") keyData_.KEY_COUNT = int.Parse(keySettingPair[1]);

                        // secret
                        if (keySettingPair[0] == "wiggleMode") keyData_.wiggleMode = bool.Parse(keySettingPair[1]);
                        if (keySettingPair[0] == "wiggleMode_wiggleAmount") keyData_.wiggleMode_wiggleAmount = int.Parse(keySettingPair[1]);
                        if (keySettingPair[0] == "wiggleMode_biasUp") keyData_.wiggleMode_biasUp = int.Parse(keySettingPair[1]);
                        if (keySettingPair[0] == "wiggleMode_biasDown") keyData_.wiggleMode_biasDown = int.Parse(keySettingPair[1]);
                        if (keySettingPair[0] == "wiggleMode_biasRight") keyData_.wiggleMode_biasRight = int.Parse(keySettingPair[1]);
                        if (keySettingPair[0] == "wiggleMode_biasLeft") keyData_.wiggleMode_biasLeft = int.Parse(keySettingPair[1]);
                    }
                    catch (Exception ex)
                    {
                        DialogResult prompt = MessageBox.Show("Unable to load key: " + name + "\n\nPress OK to attempt farther loading\nPress CANCEL to abort\n\n" + ex, "", MessageBoxButtons.OKCancel);
                        if (prompt == DialogResult.Cancel) return;
                        continue;
                    }
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