using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Edutronics_Inc.Forms
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            SqlConnection connect = new SqlConnection(myconnection);
            connect.Open();

            SqlCommand cmd = new SqlCommand("sp_searchestd", connect);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter("@searchdata", SqlDbType.VarChar);
            cmd.Parameters.Add(p1).Value = searchbox.Text;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();

            adapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];

            connect.Close();
        }

        private void Fetch_Click(object sender, EventArgs e)
        {
            string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            SqlConnection connect = new SqlConnection(myconnection);
            connect.Open();

            SqlCommand cmd = new SqlCommand("sp_studentfetch", connect);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();

            adapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];

            connect.Close();

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                searchbox.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                stdid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                stdname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                parentemail.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                Parentmobile.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                txt_image_src.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

                string imagePath = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private string GetUniqueImagePath(string baseName)
        {
            string dir = "IMAGES";
            string fileName = baseName + ".png";
            string path = Path.Combine(dir, fileName);

            int count = 1;
            while (File.Exists(path))
            {
                fileName = baseName + count + ".png";
                path = Path.Combine(dir, fileName);
                count++;
            }

            return path;

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

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap b = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(b, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            e.Graphics.DrawImage(b, new Point(120, 120));
        }

        private void Print_Click(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {

                if (stdid.Text != "" && stdname.Text != "" && comboBox1.Text != "" &&
                   parentemail.Text != "" && Parentmobile.Text != "" && txt_image_src.Text != "")
                {
                    string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                    SqlConnection connect = new SqlConnection(myconnection);
                    connect.Open();

                    SqlCommand cmd = new SqlCommand("sp_student", connect);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter p1 = new SqlParameter("@std_id", SqlDbType.VarChar);
                    cmd.Parameters.Add(p1).Value = stdid.Text;

                    SqlParameter p2 = new SqlParameter("@std_name", SqlDbType.VarChar);
                    cmd.Parameters.Add(p2).Value = stdname.Text;

                    SqlParameter p3 = new SqlParameter("@std_class", SqlDbType.VarChar);
                    cmd.Parameters.Add(p3).Value = comboBox1.Text;

                    SqlParameter p4 = new SqlParameter("@parent_email", SqlDbType.VarChar);
                    cmd.Parameters.Add(p4).Value = parentemail.Text;

                    SqlParameter p5 = new SqlParameter("@parent_mobile", SqlDbType.VarChar);
                    cmd.Parameters.Add(p5).Value = Parentmobile.Text;

                    SqlParameter p6 = new SqlParameter("@std_img", SqlDbType.VarChar.ToString());
                    cmd.Parameters.Add(p6).Value = "IMAGES/" + stdname.Text + ".png";


                    int i = cmd.ExecuteNonQuery();

                    if (i > 0)

                    {
                        try
                        {
                            Image img = new Bitmap(txt_image_src.Text);
                            img.Save("IMAGES/" + stdname.Text + ".png", ImageFormat.Png);
                            MessageBox.Show("Inserted successfully");

                            stdid.Text = "";
                            stdname.Text = "";
                            comboBox1.Text = "";
                            parentemail.Text = "";
                            Parentmobile.Text = "";
                            txt_image_src.Text = "";
                            pictureBox1.Image = null;



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

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (stdid.Text != "" && stdname.Text != "" && comboBox1.Text != "" &&
                 parentemail.Text != "" && Parentmobile.Text != "" && txt_image_src.Text != "")
            {
                string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                SqlConnection connect = new SqlConnection(myconnection);
                connect.Open();

                SqlCommand cmd = new SqlCommand("sp_updatestd", connect);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@std_id", stdid.Text));
                cmd.Parameters.Add(new SqlParameter("@std_name", stdname.Text));
                cmd.Parameters.Add(new SqlParameter("@std_class", comboBox1.Text));
                cmd.Parameters.Add(new SqlParameter("@parent_email", parentemail.Text));
                cmd.Parameters.Add(new SqlParameter("@parent_mobile", Parentmobile.Text));
                string imagePath = GetUniqueImagePath(stdname.Text);

                cmd.Parameters.Add(new SqlParameter("@std_img", imagePath));

                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    try
                    {
                        Image img = new Bitmap(txt_image_src.Text);
                        img.Save(imagePath, ImageFormat.Png);
                        MessageBox.Show("Updated successfully");
                        stdid.Text = "";
                        stdname.Text = "";
                        comboBox1.Text = "";
                        parentemail.Text = "";
                        Parentmobile.Text = "";
                        txt_image_src.Text = "";
                        pictureBox1.Image = null;
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

        private void btnfetch_Click(object sender, EventArgs e)
        {
            string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            SqlConnection connect = new SqlConnection(myconnection);
            connect.Open();

            SqlCommand cmd = new SqlCommand("sp_studentfetch", connect);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();

            adapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];

            connect.Close();
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

        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Image Files (*.jpg,*.jpeg)|*.jpg;*.jpeg|PNG Files (*.png)|*.png";

            ofd.ShowDialog();

            txt_image_src.Text = ofd.FileName;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Image.FromFile(ofd.FileName);
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            { printDocument1.Print(); }
        }
    }
}
