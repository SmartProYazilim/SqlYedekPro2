using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasarim_Metro
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            picBackup.BackColor = Color.Black;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            picBackup.BackColor = Color.Red;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            picBackupMail.BackColor = Color.Black;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            picBackupMail.BackColor = Color.LightGreen;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            picHakkinda.BackColor = Color.Black;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            picHakkinda.BackColor = Color.Orange;
        }

        private void picBackup_Click(object sender, EventArgs e)
        {
            Backup back = new Backup();
            this.Hide();
            back.Show();
        }

        private void picBackupMail_Click(object sender, EventArgs e)
        {
            MailveBackup mb = new MailveBackup();
            this.Hide();
            mb.Show();
        }

        private void picHakkinda_Click(object sender, EventArgs e)
        {
            Hakkında hakkinda = new Hakkında();
            this.Hide();
            hakkinda.Show();
        }

        private void pictureBox1_MouseLeave_1(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Black;
        }

        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            pictureBox1.BackColor = Color.Red;
        }

        private void picHakkinda_MouseLeave(object sender, EventArgs e)
        {
           picHakkinda.BackColor = Color.Black;
        }
    }
}
