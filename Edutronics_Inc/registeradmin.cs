using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Edutronics_Inc
{
    public partial class registeradmin : Form
    {
        public registeradmin()
        {
            InitializeComponent();
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

        private void registeradmin_Load(object sender, EventArgs e)
        {

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnfetch_Click(object sender, EventArgs e)
        {
            try
            {

                if (password.Text != txt_password.Text)
                {
                    MessageBox.Show("Password does not match!");
                    return;
                }

                string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                SqlConnection connect = new SqlConnection(myconnection);
                connect.Open();

                SqlCommand cmd = new SqlCommand("sp_insertadmin", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                string key = "b14ca5898a4e4133bbce2ea2315a1916";

                SqlParameter p2 = new SqlParameter("@admin", SqlDbType.VarChar);
                string encryptusername = EncryptString(key, txt_username.Text);
                cmd.Parameters.Add(p2).Value = encryptusername;

                SqlParameter p3 = new SqlParameter("@password", SqlDbType.VarChar);
                string encryptpassword = EncryptString(key, txt_password.Text);
                cmd.Parameters.Add(p3).Value = encryptpassword;




                int i = cmd.ExecuteNonQuery();

                if (i > 0)

                {

                    MessageBox.Show("Inserted successfully");

                }
                else
                {
                    MessageBox.Show(" invalid");

                }



                connect.Close();
            }


            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
