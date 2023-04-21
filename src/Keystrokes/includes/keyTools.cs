﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Keystrokes.Tools
{
    public static class keyTools
    {
        public static string VERSION = "v1.2.0";

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
            if (input == "")
                return false;

            return false;
        }

        public static string generateID(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[length];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
                stringChars[i] = chars[random.Next(chars.Length)];

            var finalString = new String(stringChars);

            return finalString;
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
            "=", "Oemplus",
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