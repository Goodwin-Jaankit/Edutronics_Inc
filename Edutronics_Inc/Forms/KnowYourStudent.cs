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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Edutronics_Inc.Forms
{
    public partial class KnowYourStudent : Form
    {
        public KnowYourStudent()
        {
            InitializeComponent();
        }

        private void Fetch_Click(object sender, EventArgs e)
        {
            
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
           
        }
    


        private void totaldays_TextChanged(object sender, EventArgs e)
        {

        }

        private void result_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnfetch_Click(object sender, EventArgs e)
        {
            string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (SqlConnection connect = new SqlConnection(myconnection))
            {
                try
                {
                    connect.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_fetchtotaldatecount", connect))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter p1 = new SqlParameter("@id", SqlDbType.VarChar);
                        cmd.Parameters.Add(p1).Value = stdid.Text;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataSet dataSet = new DataSet();
                            adapter.Fill(dataSet);

                            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                            {
                                StringBuilder dataStringBuilder = new StringBuilder();

                                foreach (DataRow row in dataSet.Tables[0].Rows)
                                {
                                    foreach (var item in row.ItemArray)
                                    {
                                        dataStringBuilder.Append(item.ToString() + "\t");
                                    }
                                    dataStringBuilder.AppendLine();
                                }

                                totalpresent.Text = dataStringBuilder.ToString();
                            }
                            else
                            {
                                totalpresent.Text = "No data found.";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the values from the text boxes
                int totalPresent = int.Parse(totalpresent.Text);
                int totalDays = int.Parse(totaldays.Text);

                // Calculate the percentage
                double percentage = ((double)totalPresent / totalDays) * 100;

                // Display the result in the result text box
                result.Text = percentage.ToString("F2") + "%";
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values.");
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Total days cannot be zero.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

                using (SqlConnection connect = new SqlConnection(myconnection))
                {
                    connect.Open();


                    using (SqlCommand cmd = new SqlCommand("sp_knowmarks", connect))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar)).Value = textBox1.Text;
                        cmd.Parameters.Add(new SqlParameter("@term", SqlDbType.VarChar)).Value = comboBox1.Text;
                        cmd.Parameters.Add(new SqlParameter("@period", SqlDbType.Int)).Value = year.Text;

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet dataSet = new DataSet();

                        adapter.Fill(dataSet);
                        dataGridView1.DataSource = dataSet.Tables[0];


                    }

                    // Second stored procedure call
                    using (SqlCommand cmdDetails = new SqlCommand("sp_searchestd", connect))
                    {
                        cmdDetails.CommandType = CommandType.StoredProcedure;
                        cmdDetails.Parameters.Add(new SqlParameter("@searchdata", SqlDbType.VarChar)).Value = textBox1.Text;

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

                    // third one


                    using (SqlCommand cmd = new SqlCommand("sp_summarks", connect))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar)).Value = textBox1.Text;
                        cmd.Parameters.Add(new SqlParameter("@term", SqlDbType.VarChar)).Value = comboBox1.Text;
                        cmd.Parameters.Add(new SqlParameter("@period", SqlDbType.Int)).Value = int.Parse(year.Text);

                        
                        object result = cmd.ExecuteScalar();
                        

                        if (result != null && result != DBNull.Value)
                        {
                            textBoxMarks.Text = result.ToString();
                        }
                        else
                        {
                            textBoxMarks.Text = "0";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
