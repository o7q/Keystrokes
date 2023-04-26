using System.Runtime.InteropServices;

namespace Keystrokes.Tools.Input
{
    public static class XInput
    {
        // Define XInput constants and structures
        public static class XInputConstants
        {
            public const int ERROR_SUCCESS = 0;
            public const int ERROR_DEVICE_NOT_CONNECTED = 1167;
        }

        // Define XInput functions
        [DllImport("xinput1_4.dll", EntryPoint = "XInputGetState")]
        public static extern int XInputGetState(int dwUserIndex, ref XInputState pState);

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
/*            public byte LeftTrigger;
            public byte RightTrigger;*/
            public short ThumbLX;
            public short ThumbLY;
            public short ThumbRX;
            public short ThumbRY;
        }


        // Define XInputGetState function signature
        [DllImport("xinput1_4.dll", EntryPoint = "XInputGetState")]
        public static extern uint XInputGetState_PRESSURE(int dwUserIndex, ref XInputState_PRESSURE pState);

        // Define XINPUT_STATE structure
        [StructLayout(LayoutKind.Sequential)]
        public struct XInputState_PRESSURE
        {
            public uint dwPacketNumber;
            public XInputGamepad_PRESSURE Gamepad;
        }

        // Define XINPUT_GAMEPAD structure
        [StructLayout(LayoutKind.Explicit)]
        public struct XInputGamepad_PRESSURE
        {
/*            [FieldOffset(0)]
            public ushort wButtons;*/
            [FieldOffset(2)]
            public byte XINPUT_GAMEPAD_LEFT_TRIGGER;
            [FieldOffset(3)]
            public byte XINPUT_GAMEPAD_RIGHT_TRIGGER;
            [FieldOffset(4)]
            public short XINPUT_GAMEPAD_LEFT_THUMB_X;
            [FieldOffset(6)]
            public short XINPUT_GAMEPAD_LEFT_THUMB_Y;
            [FieldOffset(8)]
            public short XINPUT_GAMEPAD_RIGHT_THUMB_X;
            [FieldOffset(10)]
            public short XINPUT_GAMEPAD_RIGHT_THUMB_Y;
        }

        // Initialize XInput variables
        public static int playerIndex = 0;
        public static XInputState state = new XInputState();

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
    }
}
