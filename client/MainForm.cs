using System;
using System.Windows.Forms;
using System.Drawing;
using Filter;

namespace Client
{
    public partial class MainForm : Form
    {

        Client client = new Client();
        System.Drawing.Image curImage;
        FilterService.FilterServiceClient conn;

        public MainForm()
        {
            InitializeComponent();
        }

        private void butOpenFile_Click(object sender, EventArgs e)
        {
            openFile.Filter = @"Jpg picture files (*.jpg)|*.jpg";
            openFile.Multiselect = false;
            openFile.ShowDialog();
            tbFilePath.Text = openFile.FileName;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = System.Drawing.Image.FromFile(openFile.FileName);
            curImage = pictureBox1.Image;
        }

        

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void butFilter_Click(object sender, EventArgs e)
        {
            if(rBF1.Checked)
                pictureBox1.Image=client.SendgRPC(curImage,1, conn);
            else
                pictureBox1.Image=client.SendgRPC(curImage, 2, conn);
        }

        private void butConServ_Click(object sender, EventArgs e)
        {

            conn=client.ConnectServ();
            butConServ.Visible = false;
            pictureBox1.Visible = true;
            label1.Visible = true;
            tbFilePath.Visible = true;
            butOpenFile.Visible = true;
            rBF1.Visible = true;
            rBF2.Visible = true;
            butFilter.Visible = true;
            butDef.Visible = true;


        }

        private void butDef_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = curImage;
        }
    }
}
