using System.Drawing;
using System.Windows.Forms;

namespace Keystrokes.Data
{
    public struct KeyInfo
    {
        public string VERSION;
        public string VERSION_CREATED_ON;

        public string presetName;

        public string keyId;

        public string keyText;
        public string keyCode;
        public bool isControllerKey;
        public int keyRefreshRate;

        public int keySizeX;
        public int keySizeY;

        public bool displayCps;

        public string keyFont;
        public float keyFontSize;
        public FontStyle keyFontStyle;
        public bool displayText;

        public int keyColorR;
        public int keyColorG;
        public int keyColorB;
        //
        public int keyTextColorR;
        public int keyTextColorG;
        public int keyTextColorB;
        //
        public int keyColorPressedR;
        public int keyColorPressedG;
        public int keyColorPressedB;
        public bool keyColorPressedInvert;
        //
        public int keyTextColorPressedR;
        public int keyTextColorPressedG;
        public int keyTextColorPressedB;
        public bool keyTextColorPressedInvert;

        public float keyOpacity;

        public bool useTransparentBackground;
        public int keyTransparencyKeyR;
        public int keyTransparencyKeyG;
        public int keyTransparencyKeyB;

        public string keyBackgroundImage;
        public string keyBackgroundImagePressed;

        public string keySound;
        public float keySoundVolume;
        //
        public string keySoundPressed;
        public float keySoundPressedVolume;

        public ButtonBorderStyle keyBorder;

        // dynamic
        public int KEY_LOCATION_X;
        public int KEY_LOCATION_Y;

        public int KEY_SNAP_X;
        public int KEY_SNAP_Y;

        public bool KEY_LOCKED;

        // stats
        public int KEY_PRESSED_AMOUNT;
        public int KEY_CLICKED_AMOUNT;
        public int KEY_HIGHEST_CPS;

        public int KEY_PIXEL_DISTANCE;
        public int MOUSE_PIXEL_DISTANCE;
        public int JOYSTICK_ANGLE_SUM;

        public string KEY_NICKNAME;
        public int KEY_AGE_SECONDS;
        public string KEY_CREATION_DATE;

        // secret
        public bool wiggleMode;
        public int wiggleMode_wiggleAmount;
        public int wiggleMode_biasUp;
        public int wiggleMode_biasDown;
        public int wiggleMode_biasLeft;
        public int wiggleMode_biasRight;
    }
}