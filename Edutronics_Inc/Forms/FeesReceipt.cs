using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Edutronics_Inc.Forms
{
    public partial class FeesReceipt : Form
    {

        private static int counter = 0;
        public FeesReceipt()
        {
            InitializeComponent();

            txtresult.ReadOnly = true;
        }
        private void fetch_Click(object sender, EventArgs e)
        {
          
        }

        private void Generate_Click(object sender, EventArgs e)
        {
           

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            stdid.Clear();
            stdfees.Clear();
            comboBox1.Text = string.Empty;
            comboBox1.Items.Clear();
            name.Clear();
            txtresult.Clear();
            txtrecno.Text = string.Empty;
            Year.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(txtresult.Text, new Font("Times New Roman", 18, FontStyle.Bold), Brushes.Black, new Point(10, 10));
        }

        private void Paid_Click(object sender, EventArgs e)
        {
           
        }

        private void FeesReceipt_Load(object sender, EventArgs e)
        {

        }

        private void btnfetch_Click(object sender, EventArgs e)
        {
            try
            {
                string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

                using (SqlConnection connect = new SqlConnection(myconnection))
                {
                    connect.Open();

                    // First stored procedure call
                    using (SqlCommand cmd = new SqlCommand("sp_feesreceipt", connect))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar)).Value = stdid.Text;
                        cmd.Parameters.Add(new SqlParameter("@term", SqlDbType.VarChar)).Value = comboBox1.Text;
                        cmd.Parameters.Add(new SqlParameter("@period", SqlDbType.Int)).Value = Year.Text;

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet dataSet = new DataSet();

                        adapter.Fill(dataSet);

                        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                        {
                            DataRow row = dataSet.Tables[0].Rows[0];
                            stdid.Text = row["StudentID"].ToString();
                            comboBox1.Text = row["Term"].ToString();
                            stdfees.Text = row["Fees"].ToString();
                            Year.Text = row["Period"].ToString();

                        }
                        else
                        {
                            MessageBox.Show("No fee data found for the given ID.");
                        }
                    }

                    // Second stored procedure call
                    using (SqlCommand cmdDetails = new SqlCommand("sp_searchestd", connect))
                    {
                        cmdDetails.CommandType = CommandType.StoredProcedure;
                        cmdDetails.Parameters.Add(new SqlParameter("@searchdata", SqlDbType.VarChar)).Value = stdid.Text;

                        SqlDataAdapter adapterDetails = new SqlDataAdapter(cmdDetails);
                        DataSet dataSetDetails = new DataSet();

                        adapterDetails.Fill(dataSetDetails);

                        if (dataSetDetails.Tables.Count > 0 && dataSetDetails.Tables[0].Rows.Count > 0)
                        {
                            DataRow detailsRow = dataSetDetails.Tables[0].Rows[0];
                            name.Text = detailsRow["std_name"].ToString();
                            // Populate other fields as needed
                        }
                        else
                        {
                            MessageBox.Show("No additional data found for the given ID.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (stdid.Text != "" && comboBox1.Text != "" && stdfees.Text != "")
            {
                string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                SqlConnection connect = new SqlConnection(myconnection);
                connect.Open();

                SqlCommand cmd = new SqlCommand("sp_updatereceiptstd_fees", connect);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@id", stdid.Text));
                cmd.Parameters.Add(new SqlParameter("@term", comboBox1.Text));
                cmd.Parameters.Add(new SqlParameter("@period", Year.Text));
                cmd.Parameters.Add(new SqlParameter("@status", Status.Text));
                cmd.Parameters.Add(new SqlParameter("@receipt", txtrecno.Text));




                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    try
                    {
                        MessageBox.Show("Updated successfully");
                        stdid.Clear();
                        stdfees.Clear();
                        comboBox1.Text = string.Empty;
                        comboBox1.Items.Clear();
                        name.Clear();
                        txtresult.Clear();
                        txtrecno.Text = string.Empty;
                        Year.Clear();
                        Status.Items.Clear();
                        Status.Text = string.Empty;

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

        private void btnprint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            stdid.Clear();
            stdfees.Clear();
            comboBox1.Text = string.Empty;
           
            name.Clear();
            txtresult.Clear();
            txtrecno.Text = string.Empty;
            Year.Clear();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            counter++;
            string receiptNumber = "rec" + DateTime.Now.ToString("yyyyMMddHHmmss") + counter.ToString("D4");
            txtrecno.Text = receiptNumber;

            txtresult.Clear();
            txtresult.Text += "******************************************\n";
            txtresult.Text += "**                                                                            **\n";
            txtresult.Text += "**                         Fees Receipt                             **\n";
            txtresult.Text += "**                                                                            **\n";
            txtresult.Text += "******************************************\n";

            txtresult.Text += "                                            \n";

            txtresult.Text += " \n";
            txtresult.Text += "Date                  :    " + DateTime.Now + "\n\n";

            txtresult.Text += "Student Name  :    " + name.Text + "\n\n";

            txtresult.Text += "Student Id        :    " + stdid.Text + "\n\n";
            txtresult.Text += "Term                :    " + comboBox1.Text + "\n\n";
            txtresult.Text += "Receipt no       :    " + receiptNumber + "\n\n";
            txtresult.Text += " \n";
            txtresult.Text += " \n";
            txtresult.Text += "\n                                         Signature";




        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }

}
    

