using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Edutronics_Inc.Forms
{
    public partial class AdminLogin : Form
    {
        public Home Form1 { get; }

        public AdminLogin()
        {
            InitializeComponent();
        }

        public AdminLogin(Home form1)
        {
            Form1 = form1;
        }

        public static string EncryptString(string key, string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }
        public static string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        private void Submit_btn_Click(object sender, EventArgs e)
        {
            



        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
     
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txt_password.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {
            txt_password.PasswordChar = '*';
        }

        private void Submit_btn_Click_1(object sender, EventArgs e)
        {

            if (txt_username.Text != "" && txt_password.Text != "" )
            {
                try
                {
                    string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                    SqlConnection connect = new SqlConnection(myconnection);
                    connect.Open();


                    SqlCommand cmd = new SqlCommand("sp_loginadmin", connect);
                    cmd.CommandType = CommandType.StoredProcedure;

                    string key = "b14ca5898a4e4133bbce2ea2315a1916";
                    string fetchunameencrypt = EncryptString(key, txt_username.Text);

                    cmd.Parameters.Add("@username", SqlDbType.VarChar);
                    cmd.Parameters["@username"].Value = fetchunameencrypt;

                    cmd.Parameters.Add("@password", SqlDbType.VarChar);
                    string fetchpwdencrypt = EncryptString(key, txt_password.Text);
                    cmd.Parameters["@password"].Value = fetchpwdencrypt;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    DataSet dataSet = new DataSet();

                    adapter.Fill(dataSet);

                    string x = dataSet.Tables[0].Rows[0][0].ToString();

                    string decryptuname = DecryptString(key, x);

                    //MessageBox.Show(fetchunameencrypt);


                    if (x != "")
                    {
                        MessageBox.Show("welcome admin!!!" + decryptuname);



                        Admindashboard admission = new Admindashboard();


                        admission.Show();
                        this.Hide();
                        GC.Collect();

                   


                    }
                    else
                    {
                        MessageBox.Show("Invalid user");
                    }

                    connect.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("please provide Username & Password");
            }

          

        }

        private void Cancel_btn_Click_1(object sender, EventArgs e)
        {
            txt_username.Clear();
            txt_password.Clear();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Studentname_Click(object sender, EventArgs e)
        {

        }

        private void txt_password_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_username_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            emailverify emailverify = new emailverify();
            emailverify.Show();
            this.Hide();
        }
    }
}
