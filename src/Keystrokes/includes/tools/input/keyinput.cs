using System;
using System.Runtime.InteropServices;
using static Keystrokes.Tools.Input.XInput;

namespace Keystrokes.Tools.Input
{
    public static class KeyInput
    {
        // key detection script
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);
        public static bool keyDetect(string key_string, bool isController)
        {
            ushort key = 0;
            switch (key_string)
            {
                case "CONTROLLER_UP": key = XINPUT_GAMEPAD_DPAD_UP; break;
                case "CONTROLLER_DOWN": key = XINPUT_GAMEPAD_DPAD_DOWN; break;
                case "CONTROLLER_LEFT": key = XINPUT_GAMEPAD_DPAD_LEFT; break;
                case "CONTROLLER_RIGHT": key = XINPUT_GAMEPAD_DPAD_RIGHT; break;
                case "CONTROLLER_A": key = XINPUT_GAMEPAD_A; break;
                case "CONTROLLER_B": key = XINPUT_GAMEPAD_B; break;
                case "CONTROLLER_X": key = XINPUT_GAMEPAD_X; break;
                case "CONTROLLER_Y": key = XINPUT_GAMEPAD_Y; break;
                case "CONTROLLER_RIGHT_SHOULDER": key = XINPUT_GAMEPAD_RIGHT_SHOULDER; break;
                case "CONTROLLER_RIGHT_THUMB": key = XINPUT_GAMEPAD_RIGHT_THUMB; break;
                case "CONTROLLER_LEFT_SHOULDER": key = XINPUT_GAMEPAD_LEFT_SHOULDER; break;
                case "CONTROLLER_LEFT_THUMB": key = XINPUT_GAMEPAD_LEFT_THUMB; break;
                case "CONTROLLER_START": key = XINPUT_GAMEPAD_START; break;
                case "CONTROLLER_BACK": key = XINPUT_GAMEPAD_BACK; break;
            }

            // Check for button press
            if (XInputGetState(playerIndex, ref state) == XInputConstants.ERROR_SUCCESS)
                if ((state.Gamepad.Buttons & key) != 0)
                    return true;

            if (isController == true) return false;

            short keyState = GetAsyncKeyState(Convert.ToInt32(key_string, 16));
            bool keyPressed = ((keyState >> 15) & 0x0001) == 0x0001;

            if (keyPressed == true)
                return true;

            return false;
        }
    }
}