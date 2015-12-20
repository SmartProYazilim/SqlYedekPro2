namespace Tasarim_Metro
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.picBackup = new System.Windows.Forms.PictureBox();
            this.picBackupMail = new System.Windows.Forms.PictureBox();
            this.picHakkinda = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBackup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackupMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHakkinda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // picBackup
            // 
            this.picBackup.Image = ((System.Drawing.Image)(resources.GetObject("picBackup.Image")));
            this.picBackup.Location = new System.Drawing.Point(11, 270);
            this.picBackup.Name = "picBackup";
            this.picBackup.Size = new System.Drawing.Size(184, 157);
            this.picBackup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBackup.TabIndex = 0;
            this.picBackup.TabStop = false;
            this.picBackup.Click += new System.EventHandler(this.picBackup_Click);
            this.picBackup.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.picBackup.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // picBackupMail
            // 
            this.picBackupMail.ErrorImage = null;
            this.picBackupMail.Image = ((System.Drawing.Image)(resources.GetObject("picBackupMail.Image")));
            this.picBackupMail.InitialImage = null;
            this.picBackupMail.Location = new System.Drawing.Point(213, 270);
            this.picBackupMail.Name = "picBackupMail";
            this.picBackupMail.Size = new System.Drawing.Size(233, 157);
            this.picBackupMail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBackupMail.TabIndex = 1;
            this.picBackupMail.TabStop = false;
            this.picBackupMail.Click += new System.EventHandler(this.picBackupMail_Click);
            this.picBackupMail.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            this.picBackupMail.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseMove);
            // 
            // picHakkinda
            // 
            this.picHakkinda.Image = ((System.Drawing.Image)(resources.GetObject("picHakkinda.Image")));
            this.picHakkinda.Location = new System.Drawing.Point(462, 270);
            this.picHakkinda.Name = "picHakkinda";
            this.picHakkinda.Size = new System.Drawing.Size(228, 157);
            this.picHakkinda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHakkinda.TabIndex = 2;
            this.picHakkinda.TabStop = false;
            this.picHakkinda.Click += new System.EventHandler(this.picHakkinda_Click);
            this.picHakkinda.MouseLeave += new System.EventHandler(this.picHakkinda_MouseLeave);
            this.picHakkinda.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-3, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(693, 178);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave_1);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.picHakkinda);
            this.Controls.Add(this.picBackupMail);
            this.Controls.Add(this.picBackup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Backup Alma 1.1";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ((System.ComponentModel.ISupportInitialize)(this.picBackup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackupMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHakkinda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBackup;
        private System.Windows.Forms.PictureBox picBackupMail;
        private System.Windows.Forms.PictureBox picHakkinda;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

