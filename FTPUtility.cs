using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace ScreenGrab
{
    class FTPUtility
    {
        private String host;
        private String user;
        private String pass;
        private String tempname;
        private String filename;
        private FtpWebRequest req;
        private UploadProgess prog;

        public FTPUtility(String host, String user, String pass)
        {
            this.host = host;
            this.user = user;
            this.pass = pass;
        }

        public FTPUtility(String host, String user, String pass, String tempname, String filename)
        {
            this.host = host;
            this.user = user;
            this.pass = pass;
            this.tempname = tempname;
            this.filename = filename;
        }

        public void uploadFile()
        {
            prog = new ScreenGrab.UploadProgess();
            prog.Show();
            Thread t = new Thread(new ThreadStart(executeUploadFile));
            t.Start();
        }

        private void executeUploadFile()
        {
            FileInfo file = new FileInfo(tempname);
            String uri = "ftp://" + host + "/" + filename;

            req = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));

            req.Credentials = new NetworkCredential(user, pass);
            req.KeepAlive = false;
            req.Method = WebRequestMethods.Ftp.UploadFile;
            req.UseBinary = true;
            req.ContentLength = file.Length;
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;

            FileStream fs = file.OpenRead();

            try
            {
                Stream strm = req.GetRequestStream();
                contentLen = fs.Read(buff, 0, buffLength);

                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }

                strm.Close();
                fs.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Image failed to upload.", "ScreenGrab");
            }
            prog.SafeInvoke(() => { prog.Close(); });
        }

        public bool test()
        {
            String uri = "ftp://" + host + "/";

            req = (FtpWebRequest) FtpWebRequest.Create(new Uri(uri));

            req.Credentials = new NetworkCredential(user, pass);
            req.KeepAlive = false;
            req.Method = WebRequestMethods.Ftp.ListDirectory;
            req.UseBinary = true;

            try
            {
                WebResponse response = req.GetResponse();
                response.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
