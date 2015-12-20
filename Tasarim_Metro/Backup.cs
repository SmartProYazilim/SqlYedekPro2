using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Tasarim_Metro
{
    public partial class Backup : MetroForm
    {
        public Backup()
        {
            InitializeComponent();
        }
        private SqlConnection con;
        private SqlCommand com;
        private SqlDataReader reader;
        string sql = "";
        string connectionstring = "";
        public static string dosyayolu1;

        public static void DosyaYaz()
        {
            string simdi = String.Format("{0:dd-MM-yyyy-HH-mm}", DateTime.Now);
            dosyayolu1 = tutulan + simdi + ".xml";

            if (Directory.Exists(@"C:\DataXml"))
            {

            }
            else
            {
                Directory.CreateDirectory(@"C:\DataXml");
            }

            XmlTextWriter yaz = new XmlTextWriter(new FileStream(
            @"C:\DataXml" + "//" + dosyayolu1, FileMode.OpenOrCreate), Encoding.Unicode);
            yaz.Formatting = Formatting.Indented;

            yaz.WriteStartDocument();
            yaz.WriteStartElement("Backup");
            yaz.WriteStartElement("Bilgiler");
            yaz.WriteAttributeString("dev", "hyapiskan");
            yaz.WriteElementString("Tarih-Saat", simdi);
            yaz.WriteElementString("Database Adı", tutulan);
            yaz.WriteElementString("Durum", "Backup Başarıyla Alındı.");
            yaz.WriteEndElement();
            yaz.WriteEndElement();
            yaz.Flush();
            //yaz.Close();
        }

        private void btnBaglan_Click(object sender, EventArgs e)
        {
            try
            {
                connectionstring = "Data Source=" + txtServer.Text + "; User Id=" + txtUser.Text + "; Password=" + txtPass.Text + "";
                con = new SqlConnection(connectionstring);
                con.Open();
                sql = "select * from sys.databases";
                com = new SqlCommand(sql, con);
                reader = com.ExecuteReader();
                cmbVeriTabani.Items.Clear();
                while (reader.Read())
                {
                    cmbVeriTabani.Items.Add(reader[0].ToString());
                }
                txtServer.Enabled = false;
                txtUser.Enabled = false;
                txtPass.Enabled = false;
                btnBackup.Enabled = false;
                btnKapat.Enabled = true;

                btnYer.Enabled = true;
                btnBackup.Enabled = true;
                cmbVeriTabani.Enabled = true;

            }
            catch (Exception hata)
            {

                
                MessageBox.Show(hata.Message);
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            txtUser.Enabled = true;
            txtServer.Enabled = true;
            txtPass.Enabled = true;
            cmbVeriTabani.Enabled = false;
            btnBackup.Enabled = false;
            btnYer.Enabled = false;
        }

        private void Backup_Load(object sender, EventArgs e)
        {
            btnKapat.Enabled = false;
            cmbVeriTabani.Enabled = false;
            btnBackup.Enabled = false;
            btnYer.Enabled = false;

        }
        private static string tutulan;
        private void btnBackup_Click(object sender, EventArgs e)
        {
            tutulan = cmbVeriTabani.Items[cmbVeriTabani.SelectedIndex].ToString();
            try
            {
                if (cmbVeriTabani.Text.CompareTo("") == 0)
                {
                    MessageBox.Show("Lütfen Bir Database Seçiniz");
                    return;
                }
                con = new SqlConnection(connectionstring);
                con.Open();
                sql = "backup database " + cmbVeriTabani.Text + " to disk ='" + txtYer.Text + "\\" + cmbVeriTabani.Text + ".bak'";
                com = new SqlCommand(sql, con);
                com.ExecuteNonQuery();
                DosyaYaz();
                MessageBox.Show("Database Backup Başarılı");
                con.Close();
            }
            catch (Exception hata)
            {
                
                MessageBox.Show(hata.Message); ;
            }
        }

        private void btnYer_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dl = new FolderBrowserDialog();
            if (dl.ShowDialog() == DialogResult.OK)
            {
                var dosyayolu = txtYer.Text = dl.SelectedPath;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                txtPass.PasswordChar = '\0';
            }
            else
            {
                txtPass.PasswordChar = '*';
            }
        }

       

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Black;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox1.BackColor = Color.Yellow;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            foreach (Form item in Application.OpenForms)
            {
                if (item.Name == "Form1")
                {
                    item.Show();

                }
            }

            this.Dispose();
            this.Close();
        }
    }
}
