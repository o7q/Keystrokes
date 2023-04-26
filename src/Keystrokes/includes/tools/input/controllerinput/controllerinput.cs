using System;
using static Keystrokes.Tools.Input.XInput;

namespace Keystrokes.Tools.Input
{
    public static class ControllerInput
    {
        public static Tuple<float, float, float> calculateJoystick(string joystick)
        {
            XInputState_PRESSURE state = new XInputState_PRESSURE();
            XInputGetState_PRESSURE(playerIndex, ref state);

            float joystickX = 0;
            float joystickY = 0;

            switch (joystick)
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

        public static Tuple<bool, string> joystickDetect()
        {
            XInputState_PRESSURE state = new XInputState_PRESSURE();
            XInputGetState_PRESSURE(playerIndex, ref state);

            float joystick_leftX = state.Gamepad.XINPUT_GAMEPAD_LEFT_THUMB_X;
            float joystick_leftY = state.Gamepad.XINPUT_GAMEPAD_LEFT_THUMB_Y;
            double joystick_leftX_normal = joystick_leftX / 32768;
            double joystick_leftY_normal = joystick_leftY / 32768;

            float joystick_rightX = state.Gamepad.XINPUT_GAMEPAD_RIGHT_THUMB_X;
            float joystick_rightY = state.Gamepad.XINPUT_GAMEPAD_RIGHT_THUMB_Y;
            double joystick_rightX_normal = joystick_rightX / 32768;
            double joystick_rightY_normal = joystick_rightY / 32768;

            if (joystick_leftX_normal > 0.75 || joystick_leftY_normal > 0.75 || joystick_leftX_normal < -0.75 || joystick_leftY_normal < -0.75)
                return Tuple.Create(true, "CONTROLLER_LEFT_JOYSTICK");
            if (joystick_rightX_normal > 0.75 || joystick_rightY_normal > 0.75 || joystick_rightX_normal < -0.75 || joystick_rightY_normal < -0.75)
                return Tuple.Create(true, "CONTROLLER_RIGHT_JOYSTICK");
            return Tuple.Create(false, "");
        }

        public static string controllerDetect()
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
