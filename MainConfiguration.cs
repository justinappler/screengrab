using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace ScreenGrab
{
    public partial class MainConfiguration : Form
    {
        RegistrySettings.Settings s;

        public MainConfiguration(RegistrySettings.Settings s)
        {
            InitializeComponent();
            this.s = s;
        }

        private void MainConfiguration_Load(object sender, EventArgs e)
        {
            if (s != null)
            {
                chkEnableSaveToFile.Checked = s.saveToFileEnabled;
                chkEnableFTP.Checked = s.ftpEnabled;
                chkLinkEnabled.Checked = s.copyLinkToClipboard;
                txtLinkString.Text = s.linkString;
                txtPass.Text = s.ftpPass;
                txtUser.Text = s.ftpUser;
                txtServer.Text = s.ftpHost;
                txtSaveToFileLocation.Text = s.fileLocation;

            }
        }

        private void chkEnableSaveToFile_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableSaveToFile.Checked == true)
                groupSaveToFile.Enabled = true;
            else
                groupSaveToFile.Enabled = false;
        }

        private void chkEnableFTP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableFTP.Checked == true)
                groupFTP.Enabled = true;
            else
                groupFTP.Enabled = false;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult res = dlgSaveToFile.ShowDialog();
            if (res == DialogResult.OK)
            {
                txtSaveToFileLocation.Text = dlgSaveToFile.FileName;
            }
            else
            {
                txtSaveToFileLocation.Text = "";
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            txtServer.BackColor = Color.White;
            txtUser.BackColor = Color.White;
            txtPass.BackColor = Color.White;

            if (txtServer.Text == "")
            {
                txtServer.BackColor = Color.Pink;
                MessageBox.Show("FTP Host cannot be blank.", "ScreenGrab");
                return;
            }
            if (txtServer.Text.StartsWith("ftp://"))
            {
                txtServer.Text = txtServer.Text.Replace("ftp://", "");
            }

            if (txtServer.Text.EndsWith("/"))
            {
                txtServer.Text = txtServer.Text.Substring(0, txtServer.Text.Length - 1);
            }

            Thread t = new Thread(new ThreadStart(testFTP));
            t.Start();
        }

        private void testFTP()
        {
            FTPUtility ftp = new FTPUtility(txtServer.Text, txtUser.Text, txtPass.Text);

            Color clr = ftp.test() ? Color.LightGreen : clr = Color.Pink;
            
            txtServer.SafeInvoke(() => { txtServer.BackColor = clr; });
            txtUser.SafeInvoke(() => { txtUser.BackColor = clr; });
            txtPass.SafeInvoke(() => { txtPass.BackColor = clr; });
        }

        private void chkLinkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            txtLinkString.Enabled = chkLinkEnabled.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Data Validation Checks
            if (chkEnableSaveToFile.Checked && txtSaveToFileLocation.Text == "")
            {
                MessageBox.Show("File Save Location cannot be blank.", "ScreenGrab");
            }
            else if (chkEnableFTP.Checked && txtServer.Text == "")
            {
                MessageBox.Show("FTP Host cannot be blank.", "ScreenGrab");
            }
            else
            {
                s.fileLocation = txtSaveToFileLocation.Text;
                s.copyLinkToClipboard = chkLinkEnabled.Checked;
                s.ftpEnabled = chkEnableFTP.Checked;
                s.ftpHost = txtServer.Text;
                s.ftpPass = txtPass.Text;
                s.ftpUser = txtUser.Text;
                s.linkString = txtLinkString.Text;
                s.saveToFileEnabled = chkEnableSaveToFile.Checked;

                if (s.ftpHost.StartsWith("ftp://"))
                {
                    s.ftpHost = s.ftpHost.Replace("ftp://", "");
                }

                if (s.ftpHost.EndsWith("/"))
                {
                    s.ftpHost = s.ftpHost.Substring(0, s.ftpHost.Length - 1);
                }

                if (!s.linkString.EndsWith("/"))
                {
                    s.linkString += "/";
                }

                RegistrySettings.saveSettings(s);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
