using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace ScreenGrab
{
    public partial class ClipboardSelect : Form
    {
        private Point start;
        private Point end;
        private int screenshotWidth;
        private int screenshotHeight;

        private Image img;

        private bool drawingRect;

        private Bitmap drawArea;
        private Bitmap grayImage;

        private Pen pen;
        private Pen transPen;

        private RegistrySettings.Settings settings;

        public ClipboardSelect(Image image, RegistrySettings.Settings s)
        {
            this.img = image;
            this.settings = s;
            InitializeComponent();
            pen = new Pen(Color.Red);
            transPen = new Pen(Color.FromArgb(128, 0, 0, 0));
            this.Cursor = Cursors.Cross;
        }

        private void ClipboardSelect_Load(object sender, EventArgs e)
        {
            this.screenshotWidth = this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.screenshotHeight = this.Height = Screen.PrimaryScreen.Bounds.Height;

            this.SetStyle(ControlStyles.AllPaintingInWmPaint 
                | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            this.UpdateStyles();

            this.drawArea = new Bitmap(screenshotWidth, screenshotHeight,
                PixelFormat.Format24bppRgb);

            this.start = new Point();
            this.end = new Point();
            this.drawingRect = false;
            this.grayImage = makeGrayscale(new Bitmap(this.img));

            InitializeDrawArea();

            drawScreenshotDisplay();
        }

        private void InitializeDrawArea()
        {
            Graphics graph;
            graph = Graphics.FromImage(drawArea);
        }

        public void noCrop()
        {
            this.start = new Point();
            this.end = new Point(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            cropAndSubmit();
        }

        private void cropAndSubmit()
        {
            this.Hide();

            Rectangle box = getBox();

            Bitmap bmimage = new Bitmap(box.Width, box.Height, PixelFormat.Format24bppRgb);
            
            bmimage.SetResolution(72, 72);
            Graphics grPhoto = Graphics.FromImage(bmimage);
            grPhoto.SmoothingMode = SmoothingMode.AntiAlias;
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grPhoto.PixelOffsetMode = PixelOffsetMode.HighQuality;

            grPhoto.DrawImage(img, new Rectangle(0, 0, box.Width, box.Height), box, GraphicsUnit.Pixel);

            submit(bmimage);

            this.Close();
        }

        private void submit(Bitmap bmimage)
        {
            if (settings.saveToFileEnabled)
                bmimage.Save(settings.fileLocation, System.Drawing.Imaging.ImageFormat.Png);

            if (settings.ftpEnabled)
            {
                String filename = DateTime.Now.ToString("s").Replace("T", "_") + ".png";
                String tempname = Path.GetTempFileName();

                if (settings.copyLinkToClipboard)
                {
                    Clipboard.SetText(settings.linkString + filename);
                }

                bmimage.Save(tempname, System.Drawing.Imaging.ImageFormat.Png);

                FTPUtility u = new FTPUtility(settings.ftpHost, settings.ftpUser,
                    settings.ftpPass, tempname, filename);
                u.uploadFile();
            }
        }

        private void ClipboardSelect_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.start = new Point();
                this.end = new Point();
                drawingRect = false;
                this.Invalidate(getBox());
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (drawingRect)
                {
                    this.end = e.Location;
                    cropAndSubmit();
                }
                else
                {
                    this.start = this.end = e.Location;
                    drawingRect = true;
                }
            }
        }

        private void ClipboardSelect_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.start != e.Location && e.Button == MouseButtons.Left && drawingRect)
            {
                this.end = e.Location;
                cropAndSubmit();
            }
        }

        private void ClipboardSelect_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawingRect)
            {
                Rectangle prevBox = getBox();

                this.end = e.Location;

                Rectangle nextBox = getBox();
                //int prevInfX = end.X > start.X ? -1 : 1;
                //int prevInfY = end.Y > start.Y ? -1 : 1;
                //prevBox.Inflate(prevInfX, prevInfY);

                //int nextInfX = end.X < start.X ? 1 : -1;
                //int nextInfY = end.Y < start.Y ? 1 : -1;
                //nextBox.Inflate(nextInfX, nextInfY);

                //Region r = new Region(prevBox);
                //r.Xor(nextBox);

                prevBox.Inflate(1, 1);
                nextBox.Inflate(1, 1);

                Region r = new Region(prevBox);
                r.Union(nextBox);

                this.Invalidate(r);
            }
        }

        private Rectangle getBox()
        {
            return new Rectangle(Math.Min(this.start.X, this.end.X),
                                 Math.Min(this.start.Y, this.end.Y),
                                 Math.Abs(this.start.X - this.end.X),
                                 Math.Abs(this.start.Y - this.end.Y));
        }

        private void drawScreenshotDisplay()
        {
            Graphics graph = Graphics.FromImage(this.drawArea);

            graph.DrawImage(grayImage, new Rectangle(0, 0, screenshotWidth, screenshotHeight));

            if (drawingRect)
            {
                Rectangle box = getBox();

                graph.DrawImage(img, box, box, GraphicsUnit.Pixel);

                graph.DrawRectangle(this.pen, box);
            }

            graph.Dispose();
        }

        private void ClipboardSelect_Paint(object sender, PaintEventArgs e)
        {
            Graphics graph;

            drawScreenshotDisplay();

            graph = e.Graphics;
            graph.DrawImage(drawArea, 0, 0, drawArea.Width, drawArea.Height);
        }

        private void ClipboardSelect_FormClosed(object sender, FormClosedEventArgs e)
        {
            drawArea.Dispose();
        }

        public static Bitmap makeGrayscale(Bitmap original)
        {
            Bitmap newBitmap =
               new Bitmap(original.Width, original.Height);

            Graphics g = Graphics.FromImage(newBitmap);

            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
              {
                 new float[] {.3f, .3f, .3f, 0, 0},
                 new float[] {.59f, .59f, .59f, 0, 0},
                 new float[] {.11f, .11f, .11f, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1}
              });

            ImageAttributes attributes = new ImageAttributes();

            attributes.SetColorMatrix(colorMatrix);
            g.DrawImage(original,
               new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height,
               GraphicsUnit.Pixel, attributes);

            g.Dispose();

            return newBitmap;
        }

        private void ClipboardSelect_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }


    }
}
