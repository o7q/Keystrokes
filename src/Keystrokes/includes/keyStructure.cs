using System.Windows.Forms;

namespace Keystrokes.Structure
{
    public struct keyInfo
    {
        public string presetName;

        public string keyId;

        public string keyText;
        public int keyCode;

        public int keySizeX;
        public int keySizeY;

        public int fontSize;
        public bool showText;

        public int keyColorR;
        public int keyColorG;
        public int keyColorB;

        public int keyTextColorR;
        public int keyTextColorG;
        public int keyTextColorB;

        public int keyColorPressedR;
        public int keyColorPressedG;
        public int keyColorPressedB;
        public bool keyColorPressedInvert;

        public int keyTextColorPressedR;
        public int keyTextColorPressedG;
        public int keyTextColorPressedB;
        public bool keyTextColorPressedInvert;

        public float keyOpacity;

        public string keyBackgroundImage;
        public string keyBackgroundImagePressed;

        public string sound;
        public string soundPressed;

        public ButtonBorderStyle keyBorder;

        // dynamic
        public int KEY_LOCATION_X;
        public int KEY_LOCATION_Y;

        public int KEY_SNAP_X;
        public int KEY_SNAP_Y;

        public bool KEY_LOCKED;

        public bool USE_KEY_COUNT;
        public int KEY_COUNT;

        // secret
        public bool wiggleMode;
        public int wiggleMode_wiggleAmount;
        public int wiggleMode_biasUp;
        public int wiggleMode_biasDown;
        public int wiggleMode_biasRight;
        public int wiggleMode_biasLeft;
    }
}