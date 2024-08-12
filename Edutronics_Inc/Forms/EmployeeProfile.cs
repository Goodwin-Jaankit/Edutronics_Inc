using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Edutronics_Inc.Forms
{
    public partial class EmployeeProfile : Form
    {
        public EmployeeProfile()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, EventArgs e)
        {

        }

        private void Search_Click_1(object sender, EventArgs e)
        {
            try
            {
                string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                SqlConnection connect = new SqlConnection(myconnection);
                connect.Open();

                SqlCommand cmd = new SqlCommand("sp_searchemp", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@searchdata", SqlDbType.VarChar);
                cmd.Parameters.Add(p1).Value = searchbox.Text;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();

                adapter.Fill(dataSet);

                dataGridView1.DataSource = dataSet.Tables[0];

                string imagePath = dataGridView1.Rows[0].Cells[5].Value.ToString();
                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    pictureBox1.Image = Image.FromFile(imagePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    MessageBox.Show("Image not found or path is empty.");
                    pictureBox1.Image = null;
                }

                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
