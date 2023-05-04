using System;
using static Keystrokes.Tools.Input.XInput;

namespace Keystrokes.Tools.Input
{
    public static class ControllerInput
    {
        public static Tuple<string, string> controllerDetect()
        {
            if (XInputGetState(controllerIndex, ref controllerState) == XInputConstants.ERROR_SUCCESS)
            {
                if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_DPAD_UP) != 0) return Tuple.Create("CONTROLLER_UP", "┴");
                if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_DPAD_DOWN) != 0) return Tuple.Create("CONTROLLER_DOWN", "┬");
                if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_DPAD_LEFT) != 0) return Tuple.Create("CONTROLLER_LEFT", "┤");
                if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_DPAD_RIGHT) != 0) return Tuple.Create("CONTROLLER_RIGHT", "├");
                if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_A) != 0) return Tuple.Create("CONTROLLER_A", "Ⓐ");
                if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_B) != 0) return Tuple.Create("CONTROLLER_B", "Ⓑ");
                if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_X) != 0) return Tuple.Create("CONTROLLER_X", "ⓧ");
                if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_Y) != 0) return Tuple.Create("CONTROLLER_Y", "Ⓨ");
                if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_START) != 0) return Tuple.Create("CONTROLLER_START", "≡");
                if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_BACK) != 0) return Tuple.Create("CONTROLLER_BACK", "◰");

                // joystick
                if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_LEFT_THUMB) != 0) return Tuple.Create("CONTROLLER_LEFT_JOYSTICK", "");
                if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_RIGHT_THUMB) != 0) return Tuple.Create("CONTROLLER_RIGHT_JOYSTICK", "");
            }

            return Tuple.Create("", "");
        }

        public static Tuple<bool, string> triggerDetect()
        {
            XInputAnalogState state = new XInputAnalogState();
            XInputGetAnalogState(controllerIndex, ref state);

            int trigger_left = state.Gamepad.XINPUT_GAMEPAD_LEFT_TRIGGER;
            int trigger_right = state.Gamepad.XINPUT_GAMEPAD_RIGHT_TRIGGER;

            if (trigger_left > 150)
                return Tuple.Create(true, "CONTROLLER_LEFT_TRIGGER");
            if (trigger_right > 150)
                return Tuple.Create(true, "CONTROLLER_RIGHT_TRIGGER");

            return Tuple.Create(false, "");
        }

        public static Tuple<float, float, float> calculateJoystick(string joystickKey)
        {
            XInputAnalogState state = new XInputAnalogState();
            XInputGetAnalogState(controllerIndex, ref state);

            float joystickX = 0;
            float joystickY = 0;

            switch (joystickKey)
            {
                case "CONTROLLER_LEFT_JOYSTICK":
                    joystickX = state.Gamepad.XINPUT_GAMEPAD_LEFT_THUMB_X;
                    joystickY = state.Gamepad.XINPUT_GAMEPAD_LEFT_THUMB_Y;
                    break;
                case "CONTROLLER_RIGHT_JOYSTICK":
                    joystickX = state.Gamepad.XINPUT_GAMEPAD_RIGHT_THUMB_X;
                    joystickY = state.Gamepad.XINPUT_GAMEPAD_RIGHT_THUMB_Y;
                    break;
            }

            double joystickX_normal = joystickX / 32768;
            double joystickY_normal = joystickY / 32768;

            double radians = Math.Atan2(joystickY_normal, joystickX_normal);
            double degrees180 = radians * (180 / Math.PI);
            double degrees = (degrees180 + 360) % 360;

            return Tuple.Create((float)joystickX_normal, (float)-joystickY_normal, (float)degrees);
        }

        public static float calculateTrigger(string triggerKey)
        {
            XInputAnalogState state = new XInputAnalogState();
            XInputGetAnalogState(controllerIndex, ref state);

            float trigger = 0;

            switch (triggerKey)
            {
                case "CONTROLLER_LEFT_TRIGGER":
                    trigger = state.Gamepad.XINPUT_GAMEPAD_LEFT_TRIGGER;
                    break;
                case "CONTROLLER_RIGHT_TRIGGER":
                    trigger = state.Gamepad.XINPUT_GAMEPAD_RIGHT_TRIGGER;
                    break;
            }

            return trigger / 255;
        }
    }
}