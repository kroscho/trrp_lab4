using System;
using System.Windows.Forms;
using System.Drawing;
using Filter;

namespace Client
{
    public partial class MainForm : Form
    {

        Client client = new Client();
        Bitmap curImage;
        FilterService.FilterServiceClient conn;
        Bitmap resImage;


        public MainForm()
        {
            InitializeComponent();
        }

        private void butOpenFile_Click(object sender, EventArgs e)
        {
            openFile.Filter = @"Jpg picture files (*.jpg)|*.jpg";
            openFile.Multiselect = false;
            DialogResult answer = openFile.ShowDialog();
    
           
            if (answer==DialogResult.OK)
            {
                tbFilePath.Text = openFile.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = new Bitmap(openFile.FileName);
                curImage = new Bitmap(pictureBox1.Image);
            }
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void butFilter_Click(object sender, EventArgs e)
        {
            if (rBF1.Checked)
            {
                resImage= client.SendgRPC(new Bitmap(pictureBox1.Image), 1, conn, int.Parse(numericUpDown1.Text));
                pictureBox1.Image = resImage;
            }
            else if(rBF2.Checked)
            {   resImage= client.SendgRPC(new Bitmap(pictureBox1.Image), 2, conn, int.Parse(numericUpDown1.Text));
                pictureBox1.Image = resImage;
            }
            else
            {
                resImage = client.SendgRPC(new Bitmap(pictureBox1.Image), 3, conn, int.Parse(numericUpDown1.Text));
                pictureBox1.Image = resImage;
            }
        }

        private void successConn()
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
            numericUpDown1.Visible = true;
            rBF3.Visible = true;
        }
        private void butConServ_Click(object sender, EventArgs e)
        {

            conn=client.ConnectServ();
            if (conn != null)
            {
                successConn();
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
            DialogResult answer=saveFile.ShowDialog();
            if (answer == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFile.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                MessageBox.Show("Сохранено успешно!");
            }
        }

        private void rBF1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = 1;
            numericUpDown1.Increment = 1;
            numericUpDown1.Value = 1;
            numericUpDown1.ReadOnly = false;
        }

        private void rBF3_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = 0;
            numericUpDown1.Value = 0;
            numericUpDown1.Increment = 1;
            numericUpDown1.Maximum = 255;
            numericUpDown1.ReadOnly = false;


        }

        private void rBF2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Increment = 2;
            numericUpDown1.Value = 1;
            numericUpDown1.Minimum = 1;
            numericUpDown1.ReadOnly = true;
        }
    }
}
