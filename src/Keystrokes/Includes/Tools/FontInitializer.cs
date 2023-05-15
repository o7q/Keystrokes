using System;
using System.IO;
using System.Drawing;
using System.Reflection;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace Keystrokes.Tools
{
    public static class Fonts
    {
        public static FontFamily InitializeFont(string fontLocation)
        {
            PrivateFontCollection fontMem = new PrivateFontCollection();
            byte[] fontData;

            // load the embedded font file as a byte array
            using (Stream fontStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fontLocation))
            {
                fontData = new byte[fontStream.Length];
                fontStream.Read(fontData, 0, (int)fontStream.Length);
            }

            // allocate unmanaged memory and copy the font data into it
            IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
            Marshal.Copy(fontData, 0, fontPtr, fontData.Length);

            // add embedded font to fontMem
            fontMem.AddMemoryFont(fontPtr, fontData.Length);

            // free allocated memory
            Marshal.FreeCoTaskMem(fontPtr);

            return fontMem.Families[0];
        }
    }
}