using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Keystrokes.obj
{
    public struct keyInfo
    {
        public string presetName;

        public string keyId;

        public string keyText;
        public int keyCode;

        public int keySizeX;
        public int keySizeY;

        public int fontSize;

        public int keyColorR;
        public int keyColorG;
        public int keyColorB;

        public int keyTextColorR;
        public int keyTextColorG;
        public int keyTextColorB;

        public int keyColorPressedR;
        public int keyColorPressedG;
        public int keyColorPressedB;
        public bool keyColorPressedInvert;

        public int keyTextColorPressedR;
        public int keyTextColorPressedG;
        public int keyTextColorPressedB;
        public bool keyTextColorPressedInvert;

        public float keyOpacity;

        public ButtonBorderStyle keyBorder;

        // dynamic
        public int KEY_LOCATION_X;
        public int KEY_LOCATION_Y;

        public int KEY_SNAP_X;
        public int KEY_SNAP_Y;
    }

    public static class keyTools
    {
        public static string VERSION = "v1.1.0";

        public static List<Form> keys = new List<Form>();

        // key detection script
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);
        public static bool keyDetect(int key)
        {
            short keyState = GetAsyncKeyState(key);
            bool keyPressed = ((keyState >> 15) & 0x0001) == 0x0001;

            if (keyPressed)
                return true;

            return false;
        }

        public static bool isNumber(string input, string type)
        {
            if (type == "int")
                if (int.TryParse(input, out _) == true) return true;
            if (type == "float")
                if (float.TryParse(input, out _) == true) return true;
            if (type == "double")
                if (double.TryParse(input, out _) == true) return true;

            return false;
        }

        public static string[] keyTextFixes =
        {
            "Esc", "Escape",
            "ScrLk", "Scroll",
            "`", "Oemtilde",
            "1", "D1",
            "2", "D2",
            "3", "D3",
            "4", "D4",
            "5", "D5",
            "6", "D6",
            "7", "D7",
            "8", "D8",
            "9", "D9",
            "0", "D0",
            "-", "OemMinus",
            "+", "Oemplus",
            "⬅", "Back",
            "[", "OemOpenBrackets",
            "]", "Oem6",
            "\\", "Oem5",
            "Caps", "Capital",
            ";", "Oem1",
            "'", "Oem7",
            "Shift", "ShiftKey",
            ",", "Oemcomma",
            ".", "OemPeriod",
            "/", "OemQuestion",
            "Ctrl", "ControlKey",
            "Win", "LWin",
            "Alt", "Menu",
            "Ins", "Insert",
            "PgUp", "PageUp",
            "Del", "Delete",
            "PgDn", "Next",
            "Num0", "NumPad0",
            "Num1", "NumPad1",
            "Num2", "NumPad2",
            "Num3", "NumPad3",
            "Num4", "NumPad4",
            "Num5", "NumPad5",
            "Num6", "NumPad6",
            "Num7", "NumPad7",
            "Num8", "NumPad8",
            "Num9", "NumPad9",
            "Num.", "Decimal",
            "Num+", "Add",
            "Num-", "Subtract",
            "Num*", "Multiply",
            "Num/", "Divide",
            "NumLk", "NumLock"
        };
    }
}