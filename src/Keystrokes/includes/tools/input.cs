using System;
using System.Runtime.InteropServices;

namespace Keystrokes.Tools
{
    public static class Input
    {
        // Define XInput constants and structures
        public static class XInputConstants
        {
            public const int ERROR_SUCCESS = 0;
            public const int ERROR_DEVICE_NOT_CONNECTED = 1167;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct XInputState
        {
            public int PacketNumber;
            public XInputGamepad Gamepad;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct XInputGamepad
        {
            public ushort Buttons;
            public byte LeftTrigger;
            public byte RightTrigger;
            public short ThumbLX;
            public short ThumbLY;
            public short ThumbRX;
            public short ThumbRY;
        }

        // Define XInput functions
        [DllImport("xinput1_4.dll", EntryPoint = "XInputGetState")]
        public static extern int XInputGetState(int dwUserIndex, ref XInputState pState);

        // Initialize XInput variables
        static int playerIndex = 0;
        static XInputState state = new XInputState();

        public const ushort XINPUT_GAMEPAD_DPAD_UP = 0x0001;
        public const ushort XINPUT_GAMEPAD_DPAD_DOWN = 0x0002;
        public const ushort XINPUT_GAMEPAD_DPAD_LEFT = 0x0004;
        public const ushort XINPUT_GAMEPAD_DPAD_RIGHT = 0x0008;
        public const ushort XINPUT_GAMEPAD_A = 0x1000;
        public const ushort XINPUT_GAMEPAD_B = 0x2000;
        public const ushort XINPUT_GAMEPAD_X = 0x4000;
        public const ushort XINPUT_GAMEPAD_Y = 0x8000;
        public const ushort XINPUT_GAMEPAD_RIGHT_SHOULDER = 0x0200;
        public const ushort XINPUT_GAMEPAD_RIGHT_THUMB = 0x0080;
        public const ushort XINPUT_GAMEPAD_LEFT_SHOULDER = 0x0100;
        public const ushort XINPUT_GAMEPAD_LEFT_THUMB = 0x0040;
        public const ushort XINPUT_GAMEPAD_START = 0x0010;
        public const ushort XINPUT_GAMEPAD_BACK = 0x0020;

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
            {
                if ((state.Gamepad.Buttons & key) != 0)
                {
                    return true;
                }
            }

            if (isController == true) return false;

            short keyState = GetAsyncKeyState(Convert.ToInt32(key_string, 16));
            bool keyPressed = ((keyState >> 15) & 0x0001) == 0x0001;

            if (keyPressed == true)
                return true;

            return false;
        }


        public static string xinputDetect()
        {
            if (XInputGetState(playerIndex, ref state) == XInputConstants.ERROR_SUCCESS)
            {
                if ((state.Gamepad.Buttons & XINPUT_GAMEPAD_DPAD_UP) != 0) return "CONTROLLER_UP";
                if ((state.Gamepad.Buttons & XINPUT_GAMEPAD_DPAD_DOWN) != 0) return "CONTROLLER_DOWN";
                if ((state.Gamepad.Buttons & XINPUT_GAMEPAD_DPAD_LEFT) != 0) return "CONTROLLER_LEFT";
                if ((state.Gamepad.Buttons & XINPUT_GAMEPAD_DPAD_RIGHT) != 0) return "CONTROLLER_RIGHT";
                if ((state.Gamepad.Buttons & XINPUT_GAMEPAD_A) != 0) return "CONTROLLER_A";
                if ((state.Gamepad.Buttons & XINPUT_GAMEPAD_B) != 0) return "CONTROLLER_B";
                if ((state.Gamepad.Buttons & XINPUT_GAMEPAD_X) != 0) return "CONTROLLER_X";
                if ((state.Gamepad.Buttons & XINPUT_GAMEPAD_Y) != 0) return "CONTROLLER_Y";
                if ((state.Gamepad.Buttons & XINPUT_GAMEPAD_RIGHT_SHOULDER) != 0) return "CONTROLLER_RIGHT_SHOULDER";
                if ((state.Gamepad.Buttons & XINPUT_GAMEPAD_RIGHT_THUMB) != 0) return "CONTROLLER_RIGHT_THUMB";
                if ((state.Gamepad.Buttons & XINPUT_GAMEPAD_LEFT_SHOULDER) != 0) return "CONTROLLER_LEFT_SHOULDER";
                if ((state.Gamepad.Buttons & XINPUT_GAMEPAD_LEFT_THUMB) != 0) return "CONTROLLER_LEFT_THUMB";
                if ((state.Gamepad.Buttons & XINPUT_GAMEPAD_START) != 0) return "CONTROLLER_START";
                if ((state.Gamepad.Buttons & XINPUT_GAMEPAD_BACK) != 0) return "CONTROLLER_BACK";
            }

            return "";
        }
    }
}