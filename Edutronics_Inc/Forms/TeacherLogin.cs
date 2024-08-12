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

namespace Edutronics_Inc.Forms
{
    public partial class TeacherLogin : Form
    {
        public TeacherLogin()
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
            if (txt_username.Text != "" && txt_password.Text != "")
            {
                try
                {

                    string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;


                    using (SqlConnection connect = new SqlConnection(myconnection))
                    {
                        connect.Open();


                        using (SqlCommand cmd = new SqlCommand("sp_emplogin", connect))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;


                            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = txt_username.Text;
                            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = txt_password.Text;


                            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                            {
                                DataSet dataSet = new DataSet();
                                adapter.Fill(dataSet);


                                if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                                {

                                    if (int.TryParse(dataSet.Tables[0].Rows[0][0].ToString(), out int x))
                                    {
                                        if (x > 0)
                                        {
                                            MessageBox.Show("Welcome admin!!!");

                                            TeacherDashboard teacherDashboard = new TeacherDashboard();
                                            teacherDashboard.Show();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Invalid user");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Login result is not a valid number.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Login failed: no data returned.");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("please provide Username & Password");
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txt_password.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void TeacherLogin_Load(object sender, EventArgs e)
        {
            txt_password.PasswordChar = '*';
        }
    }
}
