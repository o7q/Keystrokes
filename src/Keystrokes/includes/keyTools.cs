using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Keystrokes.Tools
{
    public static class keyTools
    {
        public static string VERSION = "v1.4.0";

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

        public static T ChangeType<T>(this object obj)
        {
            return (T)Convert.ChangeType(obj, typeof(T));
        }
    }
}