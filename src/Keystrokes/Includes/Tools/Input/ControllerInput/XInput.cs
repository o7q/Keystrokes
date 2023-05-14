using System.Runtime.InteropServices;

namespace Keystrokes.Tools.Input
{
    public static class XInput
    {
        // define xinput constants
        public static class XInputConstants
        {
            public const int ERROR_SUCCESS = 0;
            public const int ERROR_DEVICE_NOT_CONNECTED = 1167;
        }

        // define xinput get state function signature
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
            public byte LeftTrigger;
            public byte RightTrigger;
            public short ThumbLX;
            public short ThumbLY;
            public short ThumbRX;
            public short ThumbRY;
        }

        #region XINPUT_ANALOG
        // define xinput get analog state analog function signature
        [DllImport("xinput1_4.dll", EntryPoint = "XInputGetState")]
        public static extern uint XInputGetAnalogState(int dwUserIndex, ref XInputAnalogState pState);

        // define structure
        [StructLayout(LayoutKind.Sequential)]
        public struct XInputAnalogState
        {
            public uint dwPacketNumber;
            public XInputAnalogGamepad Gamepad;
        }

        // define xinput gamepad analog structure
        [StructLayout(LayoutKind.Explicit)]
        public struct XInputAnalogGamepad
        {
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
        #endregion

        // initialize xinput variables
        public static int controllerIndex = 0;
        public static XInputState controllerState = new XInputState();

        public const ushort XINPUT_GAMEPAD_DPAD_UP = 0x0001;
        public const ushort XINPUT_GAMEPAD_DPAD_DOWN = 0x0002;
        public const ushort XINPUT_GAMEPAD_DPAD_LEFT = 0x0004;
        public const ushort XINPUT_GAMEPAD_DPAD_RIGHT = 0x0008;
        public const ushort XINPUT_GAMEPAD_A = 0x1000;
        public const ushort XINPUT_GAMEPAD_B = 0x2000;
        public const ushort XINPUT_GAMEPAD_X = 0x4000;
        public const ushort XINPUT_GAMEPAD_Y = 0x8000;
        public const ushort XINPUT_GAMEPAD_LEFT_SHOULDER = 0x0100;
        public const ushort XINPUT_GAMEPAD_LEFT_THUMB = 0x0040;
        public const ushort XINPUT_GAMEPAD_RIGHT_SHOULDER = 0x0200;
        public const ushort XINPUT_GAMEPAD_RIGHT_THUMB = 0x0080;
        public const ushort XINPUT_GAMEPAD_START = 0x0010;
        public const ushort XINPUT_GAMEPAD_BACK = 0x0020;
    }
}