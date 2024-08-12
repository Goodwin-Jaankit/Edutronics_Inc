using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace Edutronics_Inc.Forms
{
    public partial class Parent : Form
    {

        string randomcode, from, pass, messagebody, to;
        public Parent()
        {
            InitializeComponent();
        }

        private void btnfetch_Click(object sender, EventArgs e)
        {
            MailMessage message = new MailMessage();
            to = (mail.Text).ToString();
            from = "goodwinjackie777@gmail.com";
            pass = "eknw nisy cuwp uyqg";
            messagebody = "Kindly pay the fees bill, Name: " + stdname.Text + "  amount of Rs: " + txtfees.Text + " for " + term.Text;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messagebody;
            message.Subject = "Edutronics_Inc(Fees Pending)";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(message);
                MessageBox.Show("OTP send successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

                    // First stored procedure call
                    using (SqlCommand cmd = new SqlCommand("sp_searchfees", connect))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@searchdata", SqlDbType.VarChar)).Value = stdid.Text;

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet dataSet = new DataSet();

                        adapter.Fill(dataSet);

                        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dataSet.Tables[0];



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
                            stdname.Text = detailsRow["std_name"].ToString();
                            mail.Text = detailsRow["parent_email"].ToString();

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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Parent_Load(object sender, EventArgs e)
        {

        }

        private void Search_Click(object sender, EventArgs e)
        {

          


         

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            stdid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            term.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtfees.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
           


        }

        private void fetch_Click(object sender, EventArgs e)
        {

          
         

        }

        private void fees(object sender, EventArgs e)
        {

        }
    }
}
