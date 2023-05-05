using System;

namespace Keystrokes.Tools
{
    public static class Numbers
    {
        public static bool IsNumber(string input, string type)
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

        public static string GenerateID(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[length];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
                stringChars[i] = chars[random.Next(chars.Length)];

            var finalString = new String(stringChars);

            return finalString;
        }
    }
}