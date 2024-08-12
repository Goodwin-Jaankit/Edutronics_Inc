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
    public partial class AdmissionSelectionFinal : Form
    {
        public AdmissionSelectionFinal()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

            string selectedOption = comboBox1.SelectedItem.ToString();
            try
            {
                if (admname.Text != "" && admgrade.Text != "")
                {
                    try
                    {
                        string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                        SqlConnection connect = new SqlConnection(myconnection);
                        connect.Open();
                        if (selectedOption == "Approved")
                        {
                            SqlCommand cmd = new SqlCommand("sp_updadmission", connect);
                            cmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter p1 = new SqlParameter("@stdname", SqlDbType.VarChar);
                            cmd.Parameters.Add(p1).Value = admname.Text;

                            SqlParameter p2 = new SqlParameter("@status", SqlDbType.VarChar);
                            cmd.Parameters.Add(p2).Value = comboBox1.Text;

                            int i = cmd.ExecuteNonQuery();

                            if (i > 0)
                            {

                                MessageBox.Show("Updated successfully");


                            }
                            else
                            {
                                MessageBox.Show("Invalid operation");
                            }

                        }

                        connect.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }


                }
                else
                {
                    MessageBox.Show("Please provide all details");
                }


                try
                {
                    if (selectedOption == "Rejected")
                    {
                        DialogResult dialogResult = MessageBox.Show("Are you sure want to delete Employee details?", "Confirmation message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                            SqlConnection connect = new SqlConnection(myconnection);
                            connect.Open();

                            SqlCommand cmd = new SqlCommand("sp_rejectadmission", connect);
                            cmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter p1 = new SqlParameter("@stdname", SqlDbType.VarChar);
                            cmd.Parameters.Add(p1).Value = admname.Text;

                            int a = cmd.ExecuteNonQuery();

                            if (a > 0)
                            {

                                MessageBox.Show("Data deleted successfully");

                            }

                            connect.Close();

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void Fetch_Click(object sender, EventArgs e)
        {
            string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            SqlConnection connect = new SqlConnection(myconnection);
            connect.Open();

            SqlCommand cmd = new SqlCommand("sp_fetchstd", connect);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();

            adapter.Fill(dataSet);

            dataGridViewAdmissions.DataSource = dataSet.Tables[0];

            connect.Close();
        }

        private void dataGridViewAdmissions_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                admname.Text = dataGridViewAdmissions.SelectedRows[0].Cells[0].Value.ToString();
                admgrade.Text = dataGridViewAdmissions.SelectedRows[0].Cells[3].Value.ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            SqlConnection connect = new SqlConnection(myconnection);
            connect.Open();

            SqlCommand cmd = new SqlCommand("sp_approvedstd", connect);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();

            adapter.Fill(dataSet);

            dataGridViewAdmissions.DataSource = dataSet.Tables[0];

            connect.Close();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            { printDocument1.Print(); }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap b = new Bitmap(dataGridViewAdmissions.Width, dataGridViewAdmissions.Height);
            dataGridViewAdmissions.DrawToBitmap(b, new Rectangle(0, 0, dataGridViewAdmissions.Width, dataGridViewAdmissions.Height));
            e.Graphics.DrawImage(b, new Point(120, 120));
        }
    }
}
