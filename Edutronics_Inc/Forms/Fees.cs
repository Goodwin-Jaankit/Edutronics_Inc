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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Edutronics_Inc.Forms
{
    public partial class Fees : Form
    {
        public Fees()
        {
            InitializeComponent();
        }
        private void Add_Click(object sender, EventArgs e)
        {

          
        }

        private void Search_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                searchbox.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                stdid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                stdfees.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
               





            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {

        }

        private void Delete_Click(object sender, EventArgs e)
        {
           
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {

                if (stdid.Text != "" && stdfees.Text != "" && comboBox1.Text != "")

                {
                    string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                    SqlConnection connect = new SqlConnection(myconnection);
                    connect.Open();

                    SqlCommand cmd = new SqlCommand("sp_stdfees", connect);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter p1 = new SqlParameter("@id", SqlDbType.VarChar);
                    cmd.Parameters.Add(p1).Value = stdid.Text;

                    SqlParameter p2 = new SqlParameter("@term", SqlDbType.VarChar);
                    cmd.Parameters.Add(p2).Value = comboBox1.Text;

                    SqlParameter p3 = new SqlParameter("@fees", SqlDbType.VarChar);
                    cmd.Parameters.Add(p3).Value = stdfees.Text;



                    int i = cmd.ExecuteNonQuery();

                    if (i > 0)

                    {
                        try
                        {

                            MessageBox.Show("Inserted successfully");

                            stdid.Text = "";
                            stdfees.Text = "";
                            comboBox1.Text = "";
                            searchbox.Text = "";



                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred " + ex.Message);
                        }
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

            if (stdid.Text != "" && comboBox1.Text != "" && stdfees.Text != "")
            {
                string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                SqlConnection connect = new SqlConnection(myconnection);
                connect.Open();

                SqlCommand cmd = new SqlCommand("sp_updatefees", connect);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@id", stdid.Text));
                cmd.Parameters.Add(new SqlParameter("@term", comboBox1.Text));
                cmd.Parameters.Add(new SqlParameter("@fees", stdfees.Text));




                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    try
                    {
                        MessageBox.Show("Updated successfully");
                        stdid.Text = "";
                        stdfees.Text = "";
                        comboBox1.Text = "";
                        searchbox.Text = "";

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred  " + ex.Message);
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

        private void Print_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            SqlConnection connect = new SqlConnection(myconnection);
            connect.Open();

            SqlCommand cmd = new SqlCommand("sp_searchfees", connect);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter("@searchdata", SqlDbType.VarChar);
            cmd.Parameters.Add(p1).Value = searchbox.Text;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();

            adapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];

            connect.Close();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure want to delete details?", "Confirmation message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                SqlConnection connect = new SqlConnection(myconnection);
                connect.Open();

                SqlCommand cmd = new SqlCommand("sp_deletfees", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@id", SqlDbType.VarChar);
                cmd.Parameters.Add(p1).Value = searchbox.Text;

                int a = cmd.ExecuteNonQuery();

                if (a > 0)
                {

                    MessageBox.Show("Data deleted successfully");

                }

                connect.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnfetch_Click(object sender, EventArgs e)
        {

        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            { printDocument1.Print(); }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap b = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(b, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            e.Graphics.DrawImage(b, new Point(120, 120));
        }
    }
}
