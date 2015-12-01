using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace ScreenShot1Lib
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.webBrowser.Navigated += new WebBrowserNavigatedEventHandler(webBrowser_Navigated);
            this.webBrowser.StatusTextChanged += new EventHandler(webBrowser_StatusTextChanged);
            Go();

            Type type = typeof(Form1);
            this.toolStripStatusLabel.Text += Statistics.VersionVersionInfo;
        }

        void ResetStatusLabelSize()
        {
            int width = this.Width - this.toolStripStatusLabel.Width - 30;
            if (tspBar.Visible)
                width -= this.tspBar.Width;
            this.tssLblInfo.Width = width;
        }

        void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            this.txtAddress.Text = this.webBrowser.Url.AbsoluteUri;
        }

        void webBrowser_StatusTextChanged(object sender, EventArgs e)
        {
            this.tssLblInfo.Text = this.webBrowser.StatusText;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            Go();
        }

        private void Go()
        {
            try
            {
                this.webBrowser.Navigate(txtAddress.Text.Trim());
                this.btnSave.Enabled = false;
                this.tspBar.Visible = true;
                ResetStatusLabelSize();
            }
            catch { }
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.btnSave.Enabled = true;
            this.tspBar.Visible = false;
            ResetStatusLabelSize();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = saveFileDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrEmpty(saveFileDialog.FileName))
                {
                    string filename = saveFileDialog.FileName.Trim();
                    ImageFormat format = ImageFormat.Jpeg;
                    switch (filename.ToLower())
                    {
                        case "bmp":
                            format = ImageFormat.Bmp;
                            break;
                        case "jpg":
                        case "jpeg":
                            format = ImageFormat.Jpeg;
                            break;
                        case "png":
                        default:
                            format = ImageFormat.Png;
                            break;

                    }
                    
                    SaveImage(saveFileDialog.FileName, format);
                    if (MessageBox.Show("保存完成!\n是否打开图片文件?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(filename);
                    }
                }
            }
            catch { }
        }

        private void webBrowser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            this.tspBar.Maximum = Convert.ToInt32(e.MaximumProgress);
            if (Convert.ToInt32(e.CurrentProgress) < 0)
            {
                this.tspBar.Value = 0;
            }
            else {
                this.tspBar.Value = Convert.ToInt32(e.CurrentProgress);
            }

        }

        private void SaveImage(string path, ImageFormat format)
        {
            int browserWidth = webBrowser.Width;
            int browserHeight = webBrowser.Height;
            Rectangle rectBody = this.webBrowser.Document.Body.ScrollRectangle;
            int width = rectBody.Width + 20;
            int height = rectBody.Height;
            this.webBrowser.Width = width;
            this.webBrowser.Height = height;
            try
            {
                Snapshot snap = new Snapshot();
                using (Bitmap bmp = snap.TakeSnapshot(this.webBrowser.ActiveXInstance, new Rectangle(0, 0, width, height)))
                {
                    //this.webBrowser.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                    bmp.Save(path, format);
                    //using (Image img = ImageHelper.GetThumbnailImage(bmp, bmp.Width, bmp.Height))
                    //{
                    //    ImageHelper.SaveImage(img, path, format);
                    //}
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            this.webBrowser.Width = browserWidth;
            this.webBrowser.Height = browserHeight;
        }



        private void frmBrowser_Load(object sender, EventArgs e)
        {
            ResetStatusLabelSize();
        }

        private void frmBrowser_Resize(object sender, EventArgs e)
        {
            ResetStatusLabelSize();
        }


    }
}