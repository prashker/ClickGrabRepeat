using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClickGrabRepeat
{
    public partial class SnippingTool : Form
    {
        // http://stackoverflow.com/questions/4005910/make-net-snipping-tool-compatible-with-multiple-monitors
        // http://stackoverflow.com/questions/3123776/net-equivalent-of-snipping-tool

        public struct MultiScreenSize
        {
            public int minX;
            public int minY;
            public int maxRight;
            public int maxBottom;

            // Absolute width of multiscreen size
            public int Width()
            {
                return maxRight - minX;
            }

            // Absolute height of multiscreen size
            public int Height()
            {
                return maxBottom - minY;
            }
        }

        public Image image { get; set; }

        private Rectangle rcSelect = new Rectangle();
        private Rectangle prevSelect = new Rectangle();
        private Point pntStart = new Point();

        public enum SnipType { RectSelect, Point };

        private SnipType st;

        public SnippingTool(Image screenshot, SnipType st)
        {
            // Initialize component with a static image of current desktop
            InitializeComponent();
            BackgroundImage = screenshot;
            ShowInTaskbar = false;
            FormBorderStyle = FormBorderStyle.None;

            // http://stackoverflow.com/questions/8046560/how-to-stop-flickering-c-sharp-winforms
            // Flickering when re-paiting...my fault or??
            // DoubleBuffered = true fixes, but did I hax?
            DoubleBuffered = true;

            // Start in minimum position, to capture all screen
            MultiScreenSize winSize = FindMultiScreenSize();
            Size = new Size(winSize.Width(),
                            winSize.Height());
            Location = new Point(winSize.minX, winSize.minY);

            // Set SnipType
            this.st = st;
        }

        private static Bitmap capScreen()
        {
            MultiScreenSize currentLimits = FindMultiScreenSize();

            Console.WriteLine(String.Format("Found: {0}x{1}", currentLimits.minX, currentLimits.minY));

            // Create a working copy of the current screens
            // Pass an untouched screenshot to SnippingTool
            Bitmap overlay = new Bitmap(currentLimits.Width(),
                                        currentLimits.Height(),
                                        System.Drawing.Imaging.PixelFormat.Format32bppArgb);


            using (Graphics graph = Graphics.FromImage(overlay))
            {
                graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

                // Screenshot entire screen
                graph.CopyFromScreen(currentLimits.minX, currentLimits.minY, 0, 0, overlay.Size);
                return overlay;
            }
        }

        public static Rectangle Snip()
        {
            Bitmap ss = SnippingTool.capScreen();

            SnippingTool snipper = new SnippingTool(ss, SnipType.RectSelect);
            if (snipper.ShowDialog() == DialogResult.OK)
            {
                return snipper.rcSelect;
            }

            return new Rectangle(0, 0, 0, 0);
        }

        // Record X, Y position
        public static Point Point()
        {
            Bitmap ss = SnippingTool.capScreen();

            SnippingTool snipper = new SnippingTool(ss, SnipType.Point);
            if (snipper.ShowDialog() == DialogResult.OK)
            {
                Rectangle res = snipper.rcSelect;
                return new Point(res.X, res.Y);
            }

            return new Point(0, 0);
        }

        public static MultiScreenSize FindMultiScreenSize()
        {
            // Setup the start values based off initial monitor
            int minX = Screen.AllScreens[0].Bounds.X;
            int minY = Screen.AllScreens[0].Bounds.Y;

            int maxRight = Screen.AllScreens[0].Bounds.Right;
            int maxBottom = Screen.AllScreens[0].Bounds.Bottom;

            // Loop through all monitors to find true max-min
            foreach (Screen s in Screen.AllScreens)
            {

                // Find lower X
                if (s.Bounds.X < minX)
                {
                    minX = s.Bounds.X;
                }

                // Find lower Y
                if (s.Bounds.Y < minY)
                {
                    minY = s.Bounds.Y;
                }

                // Find higher Right
                if (s.Bounds.Right > maxRight)
                {
                    maxRight = s.Bounds.Right;
                }

                // Find higher Bottom
                if (s.Bounds.Bottom > maxBottom)
                {
                    maxBottom = s.Bounds.Bottom;
                }

            }

            MultiScreenSize totalScreens = new MultiScreenSize();
            totalScreens.minX = minX;
            totalScreens.minY = minY;
            totalScreens.maxRight = maxRight;
            totalScreens.maxBottom = maxBottom;

            return totalScreens;
        }

        private void SnippingTool_Paint(object sender, PaintEventArgs e)
        {
            using (Brush b = new SolidBrush(Color.FromArgb(120, Color.White)))
            using (Pen pen = new Pen(Color.Red, 1))
            using (Region region = new Region(new Rectangle(0, 0, Width, Height)))
            {
                // Create a region
                // Negate it from the current sleection
                region.Exclude(rcSelect);
                region.Intersect(e.ClipRectangle);

                // Draw overlay of non-selected portions
                e.Graphics.FillRegion(b, region);

                // Draw selection
                e.Graphics.DrawRectangle(pen, rcSelect.X, rcSelect.Y, rcSelect.Width - 1, rcSelect.Height - 1);
            }
        }

        private void SnippingTool_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            // Exclude for Point
            if (st == SnipType.Point)
                return;

            pntStart = e.Location;
            rcSelect = new Rectangle(pntStart, new Size(0, 0));
            prevSelect = rcSelect;

            Invalidate();
        }

        private void SnippingTool_MouseMove(object sender, MouseEventArgs e)
        {
            // If not holding left key (aka no reason to update)
            if (e.Button != MouseButtons.Left)
                return;

            if (st == SnipType.Point)
                return;

            int x1 = Math.Min(e.X, pntStart.X);
            int y1 = Math.Min(e.Y, pntStart.Y);
            int x2 = Math.Max(e.X, pntStart.X);
            int y2 = Math.Max(e.Y, pntStart.Y);
            Invalidate(prevSelect);
            prevSelect = rcSelect;

            rcSelect = new Rectangle(x1, y1, x2 - x1, y2 - y1);

            Invalidate(rcSelect);
        }

        private void SnippingTool_MouseUp(object sender, MouseEventArgs e)
        {
            if (st == SnipType.Point)
                rcSelect = new Rectangle(e.Location.X, e.Location.Y, 0, 0);

            // Fun Bug
            // Coordinates are relative to minX, minY
            // But CopyFromScreen is relative to Main Monitor
            // So coodinates need to be re-normalized relative to minX, minY
            // For multimon support
            SnippingTool.MultiScreenSize monitors = SnippingTool.FindMultiScreenSize();

            int relX = monitors.minX + rcSelect.X;
            int relY = monitors.minY + rcSelect.Y;

            rcSelect.X = relX;
            rcSelect.Y = relY;

            DialogResult = DialogResult.OK;
        }

        // Escape Key Quit
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                DialogResult = DialogResult.Cancel;

            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
