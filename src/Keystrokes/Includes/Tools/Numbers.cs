using System;

namespace Keystrokes.Tools
{
    public static class Numbers
    {
        public static bool IsNumber(string input, string type)
        {
            // checks if the provided input is a valid number of the specified type
            // if the input can be parsed as the specified type, the method returns true; otherwise, it returns false
            // if the input is an empty string, it also returns false
            if (type == "int")
                if (int.TryParse(input, out _) == true)
                    return true;
            if (type == "float")
                if (float.TryParse(input, out _) == true)
                    return true;
            if (type == "double")
                if (double.TryParse(input, out _) == true)
                    return true;
            if (input == "")
                return false;

            return false;
        }

        public static string GenerateID(int length)
        {
            // creates a random string of the specified length
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[length];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
                stringChars[i] = chars[random.Next(chars.Length)];

            var finalString = new string(stringChars);

            return finalString;
        }
    }
}