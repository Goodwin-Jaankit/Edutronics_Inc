using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Edutronics_Inc.Forms
{
    public partial class Rootaccess : Form
    {
        public Rootaccess()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
           
        }

        private void Fetch_Click(object sender, EventArgs e)
        {
         

        }

        private void Update_Click(object sender, EventArgs e)
        {
          

         
        }

        private void Search_Click(object sender, EventArgs e)
        {
    
        }

        private void Delete_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
               
                empid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                empusername.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                emppassword.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
          

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (empid.Text != "" && empusername.Text != "" && emppassword.Text != "")
                {
                    string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                    SqlConnection connect = new SqlConnection(myconnection);
                    connect.Open();

                    SqlCommand cmd = new SqlCommand("sp_empaccess", connect);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter p1 = new SqlParameter("@empid", SqlDbType.VarChar);
                    cmd.Parameters.Add(p1).Value = empid.Text;

                    SqlParameter p2 = new SqlParameter("@username", SqlDbType.VarChar);
                    cmd.Parameters.Add(p2).Value = empusername.Text;

                    SqlParameter p3 = new SqlParameter("@password", SqlDbType.VarChar);
                    cmd.Parameters.Add(p3).Value = emppassword.Text;



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

                else
                {
                    MessageBox.Show("please provide product details");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred" + ex.Message);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (empid.Text != "" && empusername.Text != "" && emppassword.Text != "")
                {
                    string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                    SqlConnection connect = new SqlConnection(myconnection);
                    connect.Open();

                    SqlCommand cmd = new SqlCommand("sp_empaccessupdate", connect);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add(new SqlParameter("@empid", empid.Text));
                    cmd.Parameters.Add(new SqlParameter("@empname", empusername.Text));
                    cmd.Parameters.Add(new SqlParameter("@emppassword", emppassword.Text));





                    int i = cmd.ExecuteNonQuery();

                    if (i > 0)
                    {
                        try
                        {

                            MessageBox.Show("Updated successfully");
                            empid.Text = "";
                            empusername.Text = "";
                            emppassword.Text = "";

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred while saving the image: " + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid operation");
                    }

                    connect.Close();
                }
                else
                {
                    MessageBox.Show("Please provide all details");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred : " + ex.Message);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure want to delete Employee details?", "Confirmation message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                SqlConnection connect = new SqlConnection(myconnection);
                connect.Open();

                SqlCommand cmd = new SqlCommand("sp_deleteempaccess", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@empname", SqlDbType.VarChar);
                cmd.Parameters.Add(p1).Value = empusername.Text;

                int a = cmd.ExecuteNonQuery();

                if (a > 0)
                {

                    MessageBox.Show("Data deleted successfully");

                }

                connect.Close();

            }
        }

        private void emppassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnfetch_Click(object sender, EventArgs e)
        {
            try
            {
                string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                SqlConnection connect = new SqlConnection(myconnection);
                connect.Open();

                SqlCommand cmd = new SqlCommand("sp_empaccessfetch", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();

                adapter.Fill(dataSet);

                dataGridView1.DataSource = dataSet.Tables[0];

                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred : " + ex.Message);
            }
        }
    }
}
