using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Drawing.Imaging;

namespace ClickGrabRepeat
{
    public class CGRWorker
    {
        // Types of jobs this utility can do
        // Indefinite (repeats forever)
        // Fixed (repeats repeatTimes times)
        public enum RepeatType { Indefinite, Fixed };

        // Event Register for UI Updates
        public event EventHandler progressUpdate;

        // Where to Click (Coordinates)
        public Point click { get; set; }

        // How long to wait after Clicking to...
        public int waitMS { get; set; }

        // Grab. Where to grab (Rectangle)
        public Rectangle grab { get; set; }

        // Repetition
        public RepeatType repeat { get; set; }
        public int repeatTimes { get; set; }

        public string saveFolder { get; set; }

        public bool running;

        // Number of CGR's Performed
        private int progress;
        public int getProgress()
        {
            return progress;
        }

        public CGRWorker()
        {
            progress = 1;
        }

        public void clickGrabRepeat()
        {
            running = true;

            // Indefinite Mode TBD
            // Once I figure out how to hook onto a key outside of form
            if (repeat == RepeatType.Indefinite)
            {
                repeat = RepeatType.Fixed;
                repeatTimes = 100;
            }

            if (repeat == RepeatType.Fixed)
            {
                while (progress <= repeatTimes)
                {
                    // Notify update to UI thead
                    if (progressUpdate != null)
                        progressUpdate(this, null);

                    // Click
                    LeftMouseClick(click.X, click.Y);

                    // Rest
                    //Console.WriteLine("Waiting " + waitMS + "ms");
                    Thread.Sleep(waitMS);

                    // Grab
                    String filename = "" + progress + ".png";
                    Bitmap screenshot = grabScreenshot();

                    // Save to Folder
                    saveBitmap(screenshot, filename, ImageFormat.Png);

                    // Resource Cleanup
                    // Important: Without this mem usage was high
                    screenshot.Dispose();

                    // Repeat
                    progress++;
                }
            }

            running = false;

            // Minor hack fix (while loop above does +1 at the end)
            progress--;

            if (progressUpdate != null)
                progressUpdate(this, null);

            resetProgress();
        }

        public void resetProgress()
        {
            progress = 1;
        }

        public Bitmap grabScreenshot()
        {
            // Create a working copy of the current screens
            // Pass an untouched screenshot to SnippingTool

            Bitmap overlay = new Bitmap(grab.Width,
                                        grab.Height,
                                        System.Drawing.Imaging.PixelFormat.Format32bppArgb);


            using (Graphics graph = Graphics.FromImage(overlay)) {

                graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

                // Screenshot entire screen
                graph.CopyFromScreen(grab.X, grab.Y, 0, 0, overlay.Size, CopyPixelOperation.SourceCopy);

                return overlay;
            }
        }

        public void saveBitmap(Bitmap b, String filename, ImageFormat f)
        {
            // Combile FilePath with FileName
            String fullPath = Path.Combine(new string[] { saveFolder, filename });

            //Console.WriteLine("Saving shot to " + fullPath);

            b.Save(fullPath, f);
        }

        // http://stackoverflow.com/questions/8272681/how-can-i-simulate-a-mouse-click-at-a-certain-position-on-the-screen

        //This is a replacement for Cursor.Position in WinForms
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;

        //This simulates a left mouse click
        public static void LeftMouseClick(int xpos, int ypos)
        {
            SetCursorPos(xpos, ypos);
            mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);
        }

    }
}
