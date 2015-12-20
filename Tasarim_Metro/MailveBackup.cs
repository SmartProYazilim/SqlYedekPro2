using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Tasarim_Metro
{
    public partial class MailveBackup : MetroForm
    {
        public MailveBackup()
        {
            InitializeComponent();
        }

        private SqlConnection con;
        private SqlCommand com;
        private SqlDataReader reader;
        string sql = "";
        string connectionstring = "";
        public static string dosyayolu1;

        public void DosyaYaz()
        {
            string simdi = String.Format("{0:dd-MM-yyyy-HH-mm}", DateTime.Now);
            dosyayolu1 = tutulan + simdi + ".xml";

            if (Directory.Exists(@"C:\DataZamanliXml"))
            {

            }
            else
            {
                Directory.CreateDirectory(@"C:\DataZamanliXml");
            }

            XmlTextWriter yaz = new XmlTextWriter(new FileStream(
            @"C:\DataZamanliXml" + "//" + dosyayolu1, FileMode.OpenOrCreate), Encoding.Unicode);
            yaz.Formatting = Formatting.Indented;

            yaz.WriteStartDocument();
            yaz.WriteStartElement("Backup");
            yaz.WriteStartElement("Bilgiler");
            yaz.WriteAttributeString("dev", "hyapiskan");
            yaz.WriteElementString("Database Adı", tutulan);
            yaz.WriteElementString("Yedekleme Tarihi", dataTarih.Text);
            yaz.WriteElementString("Yedekleme Saati", DataSaat.Text);
            yaz.WriteStartElement("Mail Adresiniz");
            yaz.WriteElementString("Mail adres", txtMailAdres.Text);
            yaz.WriteElementString("Mail Şifre", txtSifre.Text);
            yaz.WriteElementString("Gönderilecek Mail Adresi", txtGonderilicekMail.Text);
            yaz.WriteElementString("Konu", txtKonu.Text);
            yaz.WriteElementString("Mesaj", txtMesaj.Text);

            yaz.WriteElementString("Tarih-Saat", simdi);
            yaz.WriteElementString("Durum", "Backup Başarıyla Alındı.");
            yaz.WriteEndElement();
            yaz.WriteEndElement();
            yaz.Flush();
            yaz.Close();
        }
        public static string tutulan;
        private void timer1_Tick(object sender, EventArgs e)
        {
            string tarih = DateTime.Now.ToShortDateString();
            string saat = DateTime.Now.ToLongTimeString();


            if (saat == DataSaat.Text && tarih == dataTarih.Text)
            {
                pictureBox2.Visible = false;
                progressBar1.Value = 100;
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
                    var yolla = "C:\\DataZamanliXml" + "\\" + dosyayolu1;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Port = 587;
                    smtp.Host = "smtp.live.com";
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential(txtMailAdres.Text, txtSifre.Text);
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(txtMailAdres.Text);
                    mail.To.Add(txtGonderilicekMail.Text);
                    mail.IsBodyHtml = true;
                    mail.Subject = (txtKonu.Text);
                    mail.Attachments.Add(new Attachment(yolla));
                    smtp.Send(mail);
                    MessageBox.Show("Database Backup Başarılı Bir Şekilde Alındı Mail Gönderildi");
                    //progressBar1.Value = 0;
                    con.Close();

                }
                catch (Exception hata)
                {
                    //logla.Loglama(hata);
                    MessageBox.Show(hata.Message); ;
                }
            }
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
                btnBaglan.Enabled = false;


                btnYer.Enabled = true;
                btnBackup.Enabled = true;
                cmbVeriTabani.Enabled = true;
                txtYer.Enabled = true;
            }
            catch (Exception hata)
            {
                //logla.Loglama(hata);
                MessageBox.Show(hata.Message);
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

        private void MailveBackup_Load(object sender, EventArgs e)
        {
            timer2.Start();
            pictureBox2.Hide();
            txtYer.Enabled = false;
            cmbVeriTabani.Enabled = false;
            btnBackup.Enabled = false;
            btnYer.Enabled = false;
           
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

        private void btnBackup_Click(object sender, EventArgs e)
        {
            timer1.Start();
            pictureBox2.Visible = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                txtSifre.PasswordChar = '\0';
            }
            else
            {
                txtSifre.PasswordChar = '*';
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox2.Checked)
            {
                txtSifre.PasswordChar = '\0';
            }
            else
            {
                txtSifre.PasswordChar = '*';
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

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblTarih.Text = DateTime.Now.ToLongTimeString();
            lblSaat.Text = DateTime.Now.ToShortDateString();
        }

        
    }
}


