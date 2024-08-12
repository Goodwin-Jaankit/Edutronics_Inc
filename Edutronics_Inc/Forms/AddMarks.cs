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
    public partial class AddMarks : Form
    {
        public AddMarks()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {

          
        }

        private void Fetch_Click(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                searchbox.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                stdid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                stdmarks.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
             
               
          
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
           
        }

        private void Update_Click(object sender, EventArgs e)
        {

        
        }

        private void Delete_Click(object sender, EventArgs e)
        {
        }

        private void Print_Click(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {

                if (stdid.Text != "" && stdmarks.Text != "" && comboBox1.Text != "" && comboBox2.Text != "")

                {
                    string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                    SqlConnection connect = new SqlConnection(myconnection);
                    connect.Open();

                    SqlCommand cmd = new SqlCommand("sp_insertmarks", connect);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter p1 = new SqlParameter("@id", SqlDbType.VarChar);
                    cmd.Parameters.Add(p1).Value = stdid.Text;


                    SqlParameter p2 = new SqlParameter("@exam", SqlDbType.VarChar);
                    cmd.Parameters.Add(p2).Value = comboBox2.Text;

                    SqlParameter p3 = new SqlParameter("@marks", SqlDbType.VarChar);
                    cmd.Parameters.Add(p3).Value = stdmarks.Text;

                    SqlParameter p4 = new SqlParameter("@subjects", SqlDbType.VarChar);
                    cmd.Parameters.Add(p4).Value = comboBox1.Text;




                    int i = cmd.ExecuteNonQuery();

                    if (i > 0)

                    {
                        try
                        {

                            MessageBox.Show("Inserted successfully");

                            stdid.Text = "";
                            stdmarks.Text = "";
                            comboBox1.Text = "";
                            comboBox2.Text = "";
                            searchbox.Text = "";



                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred while saving the image: " + ex.Message);
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

        private void btnfetch_Click(object sender, EventArgs e)
        {
            string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            SqlConnection connect = new SqlConnection(myconnection);
            connect.Open();

            SqlCommand cmd = new SqlCommand("sp_fetchmarks", connect);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();

            adapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];

            connect.Close();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (stdid.Text != "" && stdmarks.Text != "" && comboBox1.Text != "" && comboBox2.Text != "")
            {
                string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                SqlConnection connect = new SqlConnection(myconnection);
                connect.Open();

                SqlCommand cmd = new SqlCommand("sp_updatemarks", connect);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@id", stdid.Text));
                cmd.Parameters.Add(new SqlParameter("@subject", comboBox1.Text));
                cmd.Parameters.Add(new SqlParameter("@marks", stdmarks.Text));
                cmd.Parameters.Add(new SqlParameter("@exam", comboBox2.Text));



                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    try
                    {
                        MessageBox.Show("Updated successfully");
                        stdid.Text = "";
                        stdmarks.Text = "";
                        comboBox1.Text = "";
                        searchbox.Text = "";

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

        private void btndelete_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Are you sure want to delete details?", "Confirmation message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                SqlConnection connect = new SqlConnection(myconnection);
                connect.Open();

                SqlCommand cmd = new SqlCommand("sp_deletemarks", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@id", SqlDbType.VarChar);
                cmd.Parameters.Add(p1).Value = searchbox.Text;

                SqlParameter p2 = new SqlParameter("@exam", SqlDbType.VarChar);
                cmd.Parameters.Add(p2).Value = comboBox2.Text;

                SqlParameter p3 = new SqlParameter("@subject", SqlDbType.VarChar);
                cmd.Parameters.Add(p3).Value = comboBox1.Text;

              

                int a = cmd.ExecuteNonQuery();

                if (a > 0)
                {

                    MessageBox.Show("Data deleted successfully");

                }

                connect.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            SqlConnection connect = new SqlConnection(myconnection);
            connect.Open();

            SqlCommand cmd = new SqlCommand("sp_searchmarks", connect);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter("@id", SqlDbType.VarChar);
            cmd.Parameters.Add(p1).Value = searchbox.Text;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();

            adapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];

            connect.Close();
        }

        private void AddMarks_Load(object sender, EventArgs e)
        {
          
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if( printPreviewDialog1.ShowDialog() == DialogResult.OK )
            { printDocument1.Print(); }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap b = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(b, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            e.Graphics.DrawImage(b, new Point(120, 120));
        }

        private void stdid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
