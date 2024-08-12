using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Edutronics_Inc.Forms
{
    public partial class EmployeeLogin : Form
    {
        public EmployeeLogin()
        {
            InitializeComponent();
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

                                            Accounts accounts = new Accounts();
                                            accounts.Show();
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
                MessageBox.Show("Please provide Username & Password");
            }
        }

        private void EmployeeLogin_Load(object sender, EventArgs e)
        {
            txt_password.PasswordChar = '*';
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txt_password.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {

        }
    }
}
