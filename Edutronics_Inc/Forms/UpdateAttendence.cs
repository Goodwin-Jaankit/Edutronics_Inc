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

namespace Edutronics_Inc.Forms
{
    public partial class UpdateAttendence : Form
    {
        public UpdateAttendence()
        {
            InitializeComponent();
        }

        private void Print_Click(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {

                if (stdid.Text != "" && comboBox1.Text != "" )
                   
                {
                    string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                    SqlConnection connect = new SqlConnection(myconnection);
                    connect.Open();

                    SqlCommand cmd = new SqlCommand("sp_attendence", connect);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter p1 = new SqlParameter("@stdid", SqlDbType.VarChar);
                    cmd.Parameters.Add(p1).Value = stdid.Text;

                    SqlParameter p2 = new SqlParameter("@status", SqlDbType.VarChar);
                    cmd.Parameters.Add(p2).Value = comboBox1.Text;



                    int i = cmd.ExecuteNonQuery();

                      if (i > 0)

                    {
                       
                            MessageBox.Show("Inserted successfully");

                            stdid.Text = "";
                            comboBox1.Text = "";
                            searchbox.Text = "";
                         


                    }
                    else
                    {
                        MessageBox.Show(" invalid");

                    }

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

        private void btnfetch_Click(object sender, EventArgs e)
        {
        }

        private void btndelete_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Are you sure want to delete Employee details?", "Confirmation message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                SqlConnection connect = new SqlConnection(myconnection);
                connect.Open();

                SqlCommand cmd = new SqlCommand("sp_deletestd", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@stdname", SqlDbType.VarChar);
                cmd.Parameters.Add(p1).Value = searchbox.Text;

                int a = cmd.ExecuteNonQuery();

                if (a > 0)
                {

                    MessageBox.Show("Data deleted successfully");

                }

                connect.Close();

            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            searchbox.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            stdid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            SqlConnection connect = new SqlConnection(myconnection);
            connect.Open();

            SqlCommand cmd = new SqlCommand("sp_fetchattendence", connect);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter("@id", SqlDbType.VarChar);
            cmd.Parameters.Add(p1).Value = searchbox.Text;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();

            adapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];

            connect.Close();
        }
    }
}
