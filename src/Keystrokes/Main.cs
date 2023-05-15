using System;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Keystrokes.Data;
using static Keystrokes.Tools.Fonts;
using static Keystrokes.Data.Storage;

namespace Keystrokes
{
    public partial class Main : Form
    {
        // configure mouse window events
        public const int HT_CAPTION = 0x2;
        public const int WM_NCLBUTTONDOWN = 0xA1;

        // grab dlls for mousedown
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // initialize presets
            Directory.CreateDirectory("Keystrokes\\presets");
            RefreshPresetList();

            // display keystrokes credit text
            CreditLabel.Text = "Keystrokes " + VERSION;
            Credit2Label.Left = CreditLabel.Width + 12;

            #region tooltipDictionary
            // bind tooltips
            string[] tooltipMap =
            {
                "MinimizeButton", "Minimize to system tray",
                "CloseButton", "Close",
                "PresetListbox", "List of user presets",
                "CreditLabel", "Keystrokes " + VERSION + " by o7q",
                "Credit2Label", "Keystrokes " + VERSION + " by o7q",
                "RefreshPresetsButton", "Refresh presets list",
                "LoadPresetButton", "Load selected preset",
                "ClearKeysButton", "Unload all keys",
                "DeletePresetButton", "Delete selected preset",
                "AddKeyButton", "Open key editor"
            };
            #endregion

            // configure tooltips
            for (int i = 0; i < tooltipMap.Length; i += 2)
                MainToolTip.SetToolTip(Controls.Find(tooltipMap[i], true)[0], tooltipMap[i + 1]);

            // configure tooltip draw
            MainToolTip.AutoPopDelay = 10000;
            MainToolTip.OwnerDraw = true;
            MainToolTip.BackColor = Color.FromArgb(20, 20, 20);
            MainToolTip.ForeColor = Color.FromArgb(150, 150, 150);

            FontFamily nexa = InitializeFont("Keystrokes.fonts.nexa_heavy.ttf");
            AddKeyButton.Font = new Font(nexa, 9f, FontStyle.Bold);
        }

        private void MainTooltip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void LoadPresetButton_Click(object sender, EventArgs e)
        {
            KeyInfo keyData_ = new KeyInfo();

            // load keys into array
            string[] files = Directory.GetFiles("Keystrokes\\presets\\" + PresetListbox.SelectedItem, "*.key");
            foreach (string file in files)
            {
                var name = new FileInfo(file).Name;

                // load data from file
                string keyFile = File.ReadAllText("Keystrokes\\presets\\" + PresetListbox.SelectedItem + "\\" + name);
                string[] keySetting = keyFile.Split('\n');

                for (int i = 0; i < keySetting.Length; i++)
                {
                    string[] keySettingPair = keySetting[i].Split('¶');

                    try
                    {
                        switch (keySettingPair[0])
                        {
                            case "presetName": keyData_.presetName = keySettingPair[1]; break;

                            case "keyId": keyData_.keyId = keySettingPair[1]; break;

                            case "keyText": keyData_.keyText = keySettingPair[1]; break;
                            case "keyCode": keyData_.keyCode = keySettingPair[1]; break;
                            case "isControllerKey": keyData_.isControllerKey = bool.Parse(keySettingPair[1]); break;

                            case "keySizeX": keyData_.keySizeX = int.Parse(keySettingPair[1]); break;
                            case "keySizeY": keyData_.keySizeY = int.Parse(keySettingPair[1]); break;

                            case "keyFont": keyData_.keyFont = keySettingPair[1]; break;
                            case "keyFontSize": keyData_.keyFontSize = float.Parse(keySettingPair[1]); break;
                            case "keyFontStyle": keyData_.keyFontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), keySettingPair[1]); break;
                            case "showText": keyData_.showText = bool.Parse(keySettingPair[1]); break;

                            case "keyColorR": keyData_.keyColorR = int.Parse(keySettingPair[1]); break;
                            case "keyColorG": keyData_.keyColorG = int.Parse(keySettingPair[1]); break;
                            case "keyColorB": keyData_.keyColorB = int.Parse(keySettingPair[1]); break;
                            //
                            case "keyTextColorR": keyData_.keyTextColorR = int.Parse(keySettingPair[1]); break;
                            case "keyTextColorG": keyData_.keyTextColorG = int.Parse(keySettingPair[1]); break;
                            case "keyTextColorB": keyData_.keyTextColorB = int.Parse(keySettingPair[1]); break;
                            //
                            case "keyColorPressedR": keyData_.keyColorPressedR = int.Parse(keySettingPair[1]); break;
                            case "keyColorPressedG": keyData_.keyColorPressedG = int.Parse(keySettingPair[1]); break;
                            case "keyColorPressedB": keyData_.keyColorPressedB = int.Parse(keySettingPair[1]); break;
                            case "keyColorPressedInvert": keyData_.keyColorPressedInvert = bool.Parse(keySettingPair[1]); break;
                            //
                            case "keyTextColorPressedR": keyData_.keyTextColorPressedR = int.Parse(keySettingPair[1]); break;
                            case "keyTextColorPressedG": keyData_.keyTextColorPressedG = int.Parse(keySettingPair[1]); break;
                            case "keyTextColorPressedB": keyData_.keyTextColorPressedB = int.Parse(keySettingPair[1]); break;
                            case "keyTextColorPressedInvert": keyData_.keyTextColorPressedInvert = bool.Parse(keySettingPair[1]); break;

                            case "keyOpacity": keyData_.keyOpacity = float.Parse(keySettingPair[1]); break;

                            case "useTransparentBackground": keyData_.useTransparentBackground = bool.Parse(keySettingPair[1]); break;
                            case "keyTransparencyKeyR": keyData_.keyTransparencyKeyR = int.Parse(keySettingPair[1]); break;
                            case "keyTransparencyKeyG": keyData_.keyTransparencyKeyG = int.Parse(keySettingPair[1]); break;
                            case "keyTransparencyKeyB": keyData_.keyTransparencyKeyB = int.Parse(keySettingPair[1]); break;

                            case "keyBackgroundImage": keyData_.keyBackgroundImage = keySettingPair[1]; break;
                            case "keyBackgroundImagePressed": keyData_.keyBackgroundImagePressed = keySettingPair[1]; break;

                            case "keySound": keyData_.keySound = keySettingPair[1]; break;
                            case "keySoundVolume": keyData_.keySoundVolume = float.Parse(keySettingPair[1]); break;
                            //
                            case "keySoundPressed": keyData_.keySoundPressed = keySettingPair[1]; break;
                            case "keySoundPressedVolume": keyData_.keySoundPressedVolume = float.Parse(keySettingPair[1]); break;

                            case "keyBorder": keyData_.keyBorder = (ButtonBorderStyle)Enum.Parse(typeof(ButtonBorderStyle), keySettingPair[1]); break;

                            // dynamic
                            case "KEY_LOCATION_X": keyData_.KEY_LOCATION_X = int.Parse(keySettingPair[1]); break;
                            case "KEY_LOCATION_Y": keyData_.KEY_LOCATION_Y = int.Parse(keySettingPair[1]); break;

                            case "KEY_SNAP_X": keyData_.KEY_SNAP_X = int.Parse(keySettingPair[1]); break;
                            case "KEY_SNAP_Y": keyData_.KEY_SNAP_Y = int.Parse(keySettingPair[1]); break;

                            case "KEY_LOCKED": keyData_.KEY_LOCKED = bool.Parse(keySettingPair[1]); break;

                            // stats
                            case "KEY_PRESSED_AMOUNT": keyData_.KEY_PRESSED_AMOUNT = int.Parse(keySettingPair[1]); break;
                            case "KEY_CLICKED_AMOUNT": keyData_.KEY_CLICKED_AMOUNT = int.Parse(keySettingPair[1]); break;

                            case "KEY_DISTANCE_AMOUNT": keyData_.KEY_DISTANCE_AMOUNT = float.Parse(keySettingPair[1]); break;

                            case "KEY_CREATION_DATE": keyData_.KEY_CREATION_DATE = keySettingPair[1]; break;
                            case "KEY_AGE_SECONDS": keyData_.KEY_AGE_SECONDS = int.Parse(keySettingPair[1]); break;
                            case "KEY_AGE_MINUTES": keyData_.KEY_AGE_MINUTES = int.Parse(keySettingPair[1]); break;
                            case "KEY_AGE_HOURS": keyData_.KEY_AGE_HOURS = int.Parse(keySettingPair[1]); break;
                            case "KEY_AGE_DAYS": keyData_.KEY_AGE_DAYS = int.Parse(keySettingPair[1]); break;

                            // secret
                            case "wiggleMode": keyData_.wiggleMode = bool.Parse(keySettingPair[1]); break;
                            case "wiggleMode_wiggleAmount": keyData_.wiggleMode_wiggleAmount = int.Parse(keySettingPair[1]); break;
                            case "wiggleMode_biasUp": keyData_.wiggleMode_biasUp = int.Parse(keySettingPair[1]); break;
                            case "wiggleMode_biasDown": keyData_.wiggleMode_biasDown = int.Parse(keySettingPair[1]); break;
                            case "wiggleMode_biasLeft": keyData_.wiggleMode_biasLeft = int.Parse(keySettingPair[1]); break;
                            case "wiggleMode_biasRight": keyData_.wiggleMode_biasRight = int.Parse(keySettingPair[1]); break;
                        }
                    }
                    catch (Exception ex)
                    {
                        DialogResult prompt = MessageBox.Show("Unable to correctly load key: " + name + "\nWas it created in an older version?\n\nPress OK to attempt farther loading\nPress CANCEL to abort\n\n" + ex, "", MessageBoxButtons.OKCancel);
                        if (prompt == DialogResult.Cancel)
                            return;
                        continue;
                    }
                }

                // display key with keyData_ settings
                Key newKey = new Key(keyData_);
                newKey.Show();
                keys.Add(newKey);
            }
        }

        private void ClearKeysButton_Click(object sender, EventArgs e)
        {
            UnloadKeys();
        }

        private void DeletePresetButton_Click(object sender, EventArgs e)
        {
            // do any presets exist? if not, return
            if (Directory.GetDirectories("Keystrokes\\presets").Length == 0)
                return;

            // delete selected preset
            try { Directory.Delete("Keystrokes\\presets\\" + PresetListbox.SelectedItem, true); } catch { }
            RefreshPresetList();
        }

        private void AddKeyButton_Click(object sender, EventArgs e)
        {
            // prevent multiple editors from being opened
            FormCollection allForms = Application.OpenForms;
            foreach (Form form in allForms)
                if (form.Name == "KeyEditor")
                    return;

            // open key editor
            KeyEditor keyEditor = new KeyEditor();
            keyEditor.FormClosed += KeymakerFormClosed;
            keyEditor.Show();
        }

        private void OpenPresetsButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "Keystrokes\\presets\\" + PresetListbox.SelectedItem);
        }

        private void RefreshPresetsButton_Click(object sender, EventArgs e)
        {
            RefreshPresetList();
        }

        private void MainNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MainContextMenuStrip.Show(Cursor.Position);
                return;
            }

            ShowForm();
        }

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void UnloadKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnloadKeys();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            MainNotifyIcon.Visible = true;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void KeymakerFormClosed(object sender, FormClosedEventArgs e)
        {
            RefreshPresetList();
        }

        private void RefreshPresetList()
        {
            // load all presets into combobox
            PresetListbox.Items.Clear();
            foreach (string file in Directory.GetDirectories("Keystrokes\\presets"))
                PresetListbox.Items.Add(Path.GetFileName(file));

            // set selectedindex to 0 if there is at least 1 preset
            if (PresetListbox.Items.Count >= 1 == true)
                PresetListbox.SelectedIndex = 0;
        }

        private void UnloadKeys()
        {
            // dispose of all child forms
            foreach (Form childForm in keys)
                childForm.Close();
            keys.Clear();
        }

        private void ShowForm()
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            MainNotifyIcon.Visible = false;
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