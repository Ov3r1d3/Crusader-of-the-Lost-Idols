using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;


namespace Crusader_of_the_Lost_Idols
{
    class Pixel_Detect
    {
        public static Bitmap Screenshot()
        {
            // this is where we will store a snapshot of the screen
            Bitmap bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);


            // creates a graphics object so we can draw the screen in the bitmap (bmpScreenshot)
            Graphics g = Graphics.FromImage(bmpScreenshot);

            // copy from screen into the bitmap we created
            g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);

            // return the screenshot
            return bmpScreenshot;
        }

        public static bool FindBitmap(Bitmap bmpNeedle, Bitmap bmpHaystack, out Point location)
        {
            for (int outerX = 0; outerX < bmpHaystack.Width - bmpNeedle.Width; outerX++)
            {
                for (int outerY = 0; outerY < bmpHaystack.Height - bmpNeedle.Height; outerY++)
                {
                    for (int innerX = 0; innerX < bmpNeedle.Width; innerX++)
                    {
                        for (int innerY = 0; innerY < bmpNeedle.Height; innerY++)
                        {
                            Color cNeedle = bmpNeedle.GetPixel(innerX, innerY);
                            Color cHaystack = bmpHaystack.GetPixel(innerX + outerX, innerY + outerY);

                            if (cNeedle.R != cHaystack.R || cNeedle.G != cHaystack.G || cNeedle.B != cHaystack.B)
                            {
                                goto notFound;
                            }
                        }
                    }
                    location = new Point(outerX, outerY);
                    return true;
                notFound:
                    continue;
                }
            }
            location = Point.Empty;
            return false;
        }
    }
}
