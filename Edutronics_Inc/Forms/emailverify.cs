using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Edutronics_Inc.Forms
{
    public partial class emailverify : Form
    {
        string randomcode, from, pass, messagebody, to;

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (randomcode == (enterotp.Text).ToString())
            {
                MessageBox.Show("OTP verified successfully");

                registeradmin registeradmin = new registeradmin();
                registeradmin.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Invalid OTP ");
            }
        }

        private void enterotp_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnfetch_Click(object sender, EventArgs e)
        {

            if (regemail.Text.Trim().ToLower() != "goodwinjacky233@gmail.com")
            {
                MessageBox.Show("This email is not registered.");
                return;
            }

            Random random = new Random();
            randomcode = (random.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = (regemail.Text).ToString();
            from = "goodwinjackie777@gmail.com";
            pass = "eknw nisy cuwp uyqg";
            messagebody = "Your OTP for change password: " + randomcode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messagebody;
            message.Subject = "Edutronics_Inc";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(message);
                MessageBox.Show("OTP send successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public emailverify()
        {
            InitializeComponent();
        }

        private void emailverify_Load(object sender, EventArgs e)
        {
           

        }

        private void fetch_Click(object sender, EventArgs e)
        {
            



        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
