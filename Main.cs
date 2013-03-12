using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ScreenGrab
{
    public partial class Main : Form
    {


        public Main() 
        {
            InitializeComponent();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            startClipboardSelect(true);
        }

        private void menuSettings_Click(object sender, EventArgs e)
        {
            MainConfiguration mc = new MainConfiguration(RegistrySettings.getSettings());
            mc.Show();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Hide();

            ScreenGrab.HotKey hk1 = new HotKey();
            hk1.Key = Keys.PrintScreen;
            hk1.KeyModifier = (HotKey.KeyModifiers.Control | HotKey.KeyModifiers.Alt);
            hk1.HotKeyPressed += new EventHandler(hk_HotKeyPressed);

            ScreenGrab.HotKey hk2 = new HotKey();
            hk2.Key = Keys.PrintScreen;
            hk2.KeyModifier = (HotKey.KeyModifiers.Control | HotKey.KeyModifiers.Shift);
            hk2.HotKeyPressed += new EventHandler(hk2_HotKeyPressed);
        }

        void hk2_HotKeyPressed(object sender, EventArgs e)
        {
            Console.WriteLine("Got here!");
            printScreen();

            ClipboardSelect cs = startClipboardSelect(false);
            cs.noCrop();
        }

        void hk_HotKeyPressed(object sender, EventArgs e)
        {
            printScreen();

            startClipboardSelect(true);
        }

        private static void printScreen()
        {
            Bitmap i = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                  Screen.PrimaryScreen.Bounds.Height);

            Graphics g = Graphics.FromImage(i);
            g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y,
                0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);

            Clipboard.SetImage(i);
        }

        private static ClipboardSelect startClipboardSelect(bool show)
        {
            if (Clipboard.GetDataObject() != null)
            {
                IDataObject data = Clipboard.GetDataObject();

                if (data.GetDataPresent(DataFormats.Bitmap))
                {
                    Image image = (Image)data.GetData(DataFormats.Bitmap, true);
                    if (image.Height != Screen.PrimaryScreen.Bounds.Height
                         || image.Width != Screen.PrimaryScreen.Bounds.Width)
                    {
                        MessageBox.Show("The image on the clipboard is not a screen capture.", "ScreenGrab");
                    }
                    else
                    {
                        ClipboardSelect cs = new ClipboardSelect(image, RegistrySettings.getSettings());

                        if (show)
                            cs.Show();

                        return cs;
                    }
                }
                else
                {
                    MessageBox.Show("The clipboard does not contain an image.", "ScreenGrab");
                }
            }
            else
            {
                MessageBox.Show("The clipboard is empty.", "ScreenGrab");
            }
            return null;
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

    }
}
