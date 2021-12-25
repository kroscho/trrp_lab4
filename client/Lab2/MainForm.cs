using System;
using System.Windows.Forms;
using System.Drawing;
using Filter;

namespace Client
{
    public partial class MainForm : Form
    {

        Client client = new Client();
        System.Drawing.Bitmap curImage;
        FilterService.FilterServiceClient conn;
        System.Drawing.Bitmap resImage;


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
            pictureBox1.Image = new Bitmap(openFile.FileName);
            curImage = new Bitmap(pictureBox1.Image);
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void butFilter_Click(object sender, EventArgs e)
        {
            if (rBF1.Checked)
            {
                resImage= client.SendgRPC(curImage, 1, conn);
                pictureBox1.Image = resImage;
            }
            else
            {   resImage= client.SendgRPC(curImage, 2, conn);
                pictureBox1.Image = resImage;
            }
        }

        private void butConServ_Click(object sender, EventArgs e)
        {

            conn=client.ConnectServ();
            if (conn != null)
            {
                butConServ.Visible = false;
                pictureBox1.Visible = true;
                label1.Visible = true;
                tbFilePath.Visible = true;
                butOpenFile.Visible = true;
                rBF1.Visible = true;
                rBF2.Visible = true;
                butFilter.Visible = true;
                butDef.Visible = true;
                butSave.Visible = true;
            }


        }

        private void butDef_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = curImage;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(conn!=null)
            conn.DecreaseCountClients(new DecreaseRequest());
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            saveFile.Filter = @"Jpg picture files (*.jpg)|*.jpg";
            saveFile.ShowDialog();
            pictureBox1.Image.Save(saveFile.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            MessageBox.Show("Сохранено успешно!");
        }
    }
}
