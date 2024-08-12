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
    public partial class AdmissionSelection : Form
    {
        public AdmissionSelection()
        {
            InitializeComponent();
       
        }



        private void Submit_Click(object sender, EventArgs e)
        {
    
        }

        private void Search_Click(object sender, EventArgs e)
        {
           

        }

        private void Clear_Click(object sender, EventArgs e)
        {
          
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {

                if (stdname.Text != "" && parentemail.Text != "" && comboBox3.Text != "" &&
                   comboBox1.Text != "" && comboBox2.Text != "" && txt_image_src.Text != "")
                {
                    string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                    SqlConnection connect = new SqlConnection(myconnection);
                    connect.Open();

                    SqlCommand cmd = new SqlCommand("sp_Admission", connect);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter p1 = new SqlParameter("@stdname", SqlDbType.VarChar);
                    cmd.Parameters.Add(p1).Value = stdname.Text;

                    SqlParameter p2 = new SqlParameter("@stdgender", SqlDbType.VarChar);
                    cmd.Parameters.Add(p2).Value = comboBox1.Text;

                    SqlParameter p3 = new SqlParameter("@applyingto", SqlDbType.VarChar);
                    cmd.Parameters.Add(p3).Value = comboBox2.Text;

                    SqlParameter p4 = new SqlParameter("@previousgrade", SqlDbType.VarChar);
                    cmd.Parameters.Add(p4).Value = comboBox3.Text;

                    SqlParameter p5 = new SqlParameter("@parentemail", SqlDbType.VarChar);
                    cmd.Parameters.Add(p5).Value = parentemail.Text;

                    SqlParameter p6 = new SqlParameter("@imgsrc", SqlDbType.VarChar.ToString());
                    cmd.Parameters.Add(p6).Value = "IMAGES/" + stdname.Text + ".png";


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

        private void btndelete_Click(object sender, EventArgs e)
        {
            stdname.Clear();
            parentemail.Clear();
            comboBox1.Text = string.Empty;
            comboBox2.Text = string.Empty;
            comboBox3.Text = string.Empty;
            parentemail.Clear();
            txt_image_src.Clear();
            pictureBox1.Image = null;
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Image Files (*.jpg,*.jpeg)|*.jpg;*.jpeg|PNG Files (*.png)|*.png";

            ofd.ShowDialog();

            txt_image_src.Text = ofd.FileName;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Image.FromFile(ofd.FileName);
        }
    }
}
