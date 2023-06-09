﻿using System;
using static Keystrokes.Tools.Input.XInput;

namespace Keystrokes.Tools.Input
{
    public static class ControllerInput
    {
        public static Tuple<string, string, int> ControllerDetect()
        {
            // checks the state of the controller connected to the system
            // uses the XInput library to retrieve the controller state
            // depending on the buttons pressed on the controller, it returns a tuple containing the detected input

            if (XInputGetState(controllerIndex, ref controllerState) == XInputConstants.ERROR_SUCCESS)
            {
                if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_A) != 0) return Tuple.Create("CONTROLLER_A", "Ⓐ", 15);
                if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_B) != 0) return Tuple.Create("CONTROLLER_B", "Ⓑ", 15);
                if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_X) != 0) return Tuple.Create("CONTROLLER_X", "ⓧ", 15);
                if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_Y) != 0) return Tuple.Create("CONTROLLER_Y", "Ⓨ", 15);
                if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_LEFT_SHOULDER) != 0) return Tuple.Create("CONTROLLER_LEFT_SHOULDER", "[  LB  ]", -10);
                if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_RIGHT_SHOULDER) != 0) return Tuple.Create("CONTROLLER_RIGHT_SHOULDER", "[  RB  ]", -10);
                if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_START) != 0) return Tuple.Create("CONTROLLER_START", "≡", 10);
                if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_BACK) != 0) return Tuple.Create("CONTROLLER_BACK", "⧉", 10);

                // joystick
                if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_LEFT_THUMB) != 0) return Tuple.Create("CONTROLLER_LEFT_JOYSTICK", "", 0);
                if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_RIGHT_THUMB) != 0) return Tuple.Create("CONTROLLER_RIGHT_JOYSTICK", "", 0);

                // dpad
                if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_DPAD_UP) != 0) return Tuple.Create("CONTROLLER_DPAD", "", 0);
                if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_DPAD_DOWN) != 0) return Tuple.Create("CONTROLLER_DPAD", "", 0);
                if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_DPAD_LEFT) != 0) return Tuple.Create("CONTROLLER_DPAD", "", 0);
                if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_DPAD_RIGHT) != 0) return Tuple.Create("CONTROLLER_DPAD", "", 0);
            }

            // if no buttons are pressed or the controller is not connected, return an empty tuple
            return Tuple.Create("", "", 0);
        }

        public static Tuple<bool, string> TriggerDetect()
        {
            // checks the state of the triggers (analog buttons) on the controller
            // it retrieves the analog state using the XInput library
            // if either the left or right trigger exceeds a threshold value, it returns a tuple indicating the trigger is pressed and its name
            // otherwise, it returns a tuple indicating no triggers are pressed

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

        public static Tuple<float, float, float> CalculateJoystick(string joystickKey)
        {
            // calculates the values of the specified joystick on the controller
            // retrieves the analog state using the XInput library and determines the position and angle of the joystick
            // returns a tuple containing the x-axis position, y-axis position, and angle of the joystick

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

            // calculate angle
            double radians = Math.Atan2(joystickY_normal, joystickX_normal);
            double degrees180 = radians * (180 / Math.PI);
            double degrees = (degrees180 + 360) % 360;

            return Tuple.Create((float)joystickX_normal, (float)-joystickY_normal, (float)degrees);
        }

        public static float CalculateTrigger(string triggerKey)
        {
            // calculates the position of the specified trigger on the controller
            // retrieves the analog state using the XInput library and returns the normalized position of the trigger
            // returns the normalized trigger state

            XInputAnalogState state = new XInputAnalogState();
            XInputGetAnalogState(controllerIndex, ref state);

            float trigger = 0;

            switch (triggerKey)
            {
                case "CONTROLLER_LEFT_TRIGGER": trigger = state.Gamepad.XINPUT_GAMEPAD_LEFT_TRIGGER; break;
                case "CONTROLLER_RIGHT_TRIGGER": trigger = state.Gamepad.XINPUT_GAMEPAD_RIGHT_TRIGGER; break;
            }

            return trigger / 255;
        }

        public static string CalculateDpad()
        {
            // checks the state of the d-pad on the controller
            // retrieves the current controller state using the XInput library and determines which d-pad button is pressed
            // returns a string indicating the direction of the d-pad or an empty string if no button is pressed

            XInputGetState(controllerIndex, ref controllerState);

            if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_DPAD_UP) != 0) return "up";
            if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_DPAD_DOWN) != 0) return "down";
            if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_DPAD_LEFT) != 0) return "left";
            if ((controllerState.Gamepad.Buttons & XINPUT_GAMEPAD_DPAD_RIGHT) != 0) return "right";

            return "";
        }
    }
}