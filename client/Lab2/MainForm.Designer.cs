
namespace Client
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.butOpenFile = new System.Windows.Forms.Button();
            this.butFilter = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rBF1 = new System.Windows.Forms.RadioButton();
            this.rBF2 = new System.Windows.Forms.RadioButton();
            this.butConServ = new System.Windows.Forms.Button();
            this.butDef = new System.Windows.Forms.Button();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.butSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите файл картинки";
            this.label1.Visible = false;
            // 
            // tbFilePath
            // 
            this.tbFilePath.Location = new System.Drawing.Point(16, 32);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.Size = new System.Drawing.Size(379, 22);
            this.tbFilePath.TabIndex = 2;
            this.tbFilePath.Visible = false;
            // 
            // butOpenFile
            // 
            this.butOpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butOpenFile.Location = new System.Drawing.Point(401, 32);
            this.butOpenFile.Name = "butOpenFile";
            this.butOpenFile.Size = new System.Drawing.Size(44, 23);
            this.butOpenFile.TabIndex = 3;
            this.butOpenFile.Text = "...";
            this.butOpenFile.UseVisualStyleBackColor = true;
            this.butOpenFile.Visible = false;
            this.butOpenFile.Click += new System.EventHandler(this.butOpenFile_Click);
            // 
            // butFilter
            // 
            this.butFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butFilter.Location = new System.Drawing.Point(12, 585);
            this.butFilter.Name = "butFilter";
            this.butFilter.Size = new System.Drawing.Size(208, 29);
            this.butFilter.TabIndex = 5;
            this.butFilter.Text = "Применить фильтр";
            this.butFilter.UseVisualStyleBackColor = true;
            this.butFilter.Visible = false;
            this.butFilter.Click += new System.EventHandler(this.butFilter_Click);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            this.openFile.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(16, 61);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(986, 519);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // rBF1
            // 
            this.rBF1.AutoSize = true;
            this.rBF1.Checked = true;
            this.rBF1.Location = new System.Drawing.Point(475, 591);
            this.rBF1.Name = "rBF1";
            this.rBF1.Size = new System.Drawing.Size(88, 21);
            this.rBF1.TabIndex = 16;
            this.rBF1.TabStop = true;
            this.rBF1.Text = "Фильтр1";
            this.rBF1.UseVisualStyleBackColor = true;
            this.rBF1.Visible = false;
            // 
            // rBF2
            // 
            this.rBF2.AutoSize = true;
            this.rBF2.Location = new System.Drawing.Point(569, 592);
            this.rBF2.Name = "rBF2";
            this.rBF2.Size = new System.Drawing.Size(88, 21);
            this.rBF2.TabIndex = 17;
            this.rBF2.Text = "Фильтр2";
            this.rBF2.UseVisualStyleBackColor = true;
            this.rBF2.Visible = false;
            // 
            // butConServ
            // 
            this.butConServ.Location = new System.Drawing.Point(386, 225);
            this.butConServ.Name = "butConServ";
            this.butConServ.Size = new System.Drawing.Size(274, 160);
            this.butConServ.TabIndex = 18;
            this.butConServ.Text = "Подключиться к серверу";
            this.butConServ.UseVisualStyleBackColor = true;
            this.butConServ.Click += new System.EventHandler(this.butConServ_Click);
            // 
            // butDef
            // 
            this.butDef.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butDef.Location = new System.Drawing.Point(226, 585);
            this.butDef.Name = "butDef";
            this.butDef.Size = new System.Drawing.Size(219, 30);
            this.butDef.TabIndex = 19;
            this.butDef.Text = "Вернуть исходное";
            this.butDef.UseVisualStyleBackColor = true;
            this.butDef.Visible = false;
            this.butDef.Click += new System.EventHandler(this.butDef_Click);
            // 
            // butSave
            // 
            this.butSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butSave.Location = new System.Drawing.Point(796, 586);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(195, 33);
            this.butSave.TabIndex = 20;
            this.butSave.Text = "Сохранить как...";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Visible = false;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 627);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.butDef);
            this.Controls.Add(this.butConServ);
            this.Controls.Add(this.rBF2);
            this.Controls.Add(this.rBF1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.butFilter);
            this.Controls.Add(this.butOpenFile);
            this.Controls.Add(this.tbFilePath);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Клиент";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.Button butOpenFile;
        private System.Windows.Forms.Button butFilter;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton rBF1;
        private System.Windows.Forms.RadioButton rBF2;
        private System.Windows.Forms.Button butConServ;
        private System.Windows.Forms.Button butDef;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.Button butSave;
    }
}

