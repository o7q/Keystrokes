using System.Drawing;
using System.Windows.Forms;

namespace Keystrokes.Data
{
    public struct KeyInfo
    {
        public string presetName;

        public string keyId;

        public string keyText;
        public string keyCode;
        public bool isControllerKey;

        public int keySizeX;
        public int keySizeY;

        public string keyFont;
        public float fontSize;
        public FontStyle fontStyle;
        public bool showText;

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
        public int transparencyKeyR;
        public int transparencyKeyG;
        public int transparencyKeyB;

        public string keyBackgroundImage;
        public string keyBackgroundImagePressed;

        public string sound;
        public float soundVolume;
        //
        public string soundPressed;
        public float soundPressedVolume;

        public ButtonBorderStyle keyBorder;

        // dynamic
        public int KEY_LOCATION_X;
        public int KEY_LOCATION_Y;

        public int KEY_SNAP_X;
        public int KEY_SNAP_Y;

        public bool KEY_LOCKED;

        // stats
        public int KEY_PRESSED_COUNT;
        public string KEY_NICKNAME;
        public string KEY_BIRTHDAY;
        public int KEY_LIFE_SECONDS;
        public int KEY_LIFE_MINUTES;
        public int KEY_LIFE_HOURS;
        public int KEY_LIFE_DAYS;

        // secret
        public bool wiggleMode;
        public int wiggleMode_wiggleAmount;
        public int wiggleMode_biasUp;
        public int wiggleMode_biasDown;
        public int wiggleMode_biasLeft;
        public int wiggleMode_biasRight;
    }
}