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

namespace Edutronics_Inc
{
    public partial class EmployeeAccess : Form
    {
        public EmployeeAccess()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {

                if (empid.Text != "" && empname.Text != "" && empname.Text != "" &&
                   comboBox1.Text != "" && comboBox2.Text != "" && txt_image_src.Text != "")
                {
                    string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                    SqlConnection connect = new SqlConnection(myconnection);
                    connect.Open();

                    SqlCommand cmd = new SqlCommand("sp_employeedetails", connect);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter p1 = new SqlParameter("@empid", SqlDbType.VarChar);
                    cmd.Parameters.Add(p1).Value = empid.Text;

                    SqlParameter p2 = new SqlParameter("@empname", SqlDbType.VarChar);
                    cmd.Parameters.Add(p2).Value = empname.Text;

                    SqlParameter p3 = new SqlParameter("@empsalary", SqlDbType.VarChar);
                    cmd.Parameters.Add(p3).Value = empsalary.Text;

                    SqlParameter p4 = new SqlParameter("@emprole", SqlDbType.VarChar);
                    cmd.Parameters.Add(p4).Value = comboBox1.Text;

                    SqlParameter p5 = new SqlParameter("@empclass", SqlDbType.VarChar);
                    cmd.Parameters.Add(p5).Value = comboBox2.Text;

                    SqlParameter p6 = new SqlParameter("@empimg", SqlDbType.VarChar.ToString());
                    cmd.Parameters.Add(p6).Value = "IMAGES/" + empname.Text + ".png";


                    int i = cmd.ExecuteNonQuery();

                    if (i > 0)

                    {
                        try
                        {
                            Image img = new Bitmap(txt_image_src.Text);
                            img.Save("IMAGES/" + empname.Text + ".png", ImageFormat.Png);
                            MessageBox.Show("Inserted successfully");

                            empid.Text = "";
                            empname.Text = "";
                            empsalary.Text = "";
                            comboBox1.Text = "";
                            comboBox2.Text = "";
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

        private void Fetch_Click(object sender, EventArgs e)
        {
            string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            SqlConnection connect = new SqlConnection(myconnection);
            connect.Open();

            SqlCommand cmd = new SqlCommand("sp_fetchemp", connect);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();

            adapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];

            connect.Close();
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

            if (empid.Text != "" && empname.Text != "" && empsalary.Text != "" &&
       comboBox1.Text != "" && comboBox2.Text != "" && txt_image_src.Text != "")
            {
                string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                SqlConnection connect = new SqlConnection(myconnection);
                connect.Open();

                SqlCommand cmd = new SqlCommand("sp_updateemp", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@empid", empid.Text));
                cmd.Parameters.Add(new SqlParameter("@empname", empname.Text));
                cmd.Parameters.Add(new SqlParameter("@empsalary", empsalary.Text));
                cmd.Parameters.Add(new SqlParameter("@emprole", comboBox1.Text));
                cmd.Parameters.Add(new SqlParameter("@empclass", comboBox2.Text));

                string imagePath = GetUniqueImagePath(empname.Text);

                cmd.Parameters.Add(new SqlParameter("@empimg", imagePath));

                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    try
                    {
                        Image img = new Bitmap(txt_image_src.Text);
                        img.Save(imagePath, ImageFormat.Png);
                        MessageBox.Show("Updated successfully");

                        empid.Text = "";
                        empname.Text = "";
                        empsalary.Text = "";
                        comboBox1.Text = "";
                        comboBox2.Text = "";
                        txt_image_src.Text = "";
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

        private void Print_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            { printDocument1.Print(); }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                searchbox.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                empid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                empname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                empsalary.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
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

        private void Browse_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Image Files (*.jpg,*.jpeg)|*.jpg;*.jpeg|PNG Files (*.png)|*.png";

            ofd.ShowDialog();

            txt_image_src.Text = ofd.FileName;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Image.FromFile(ofd.FileName);
            }

            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: Select any Image " + ex.Message);
            }
        }

        private void Search_Click(object sender, EventArgs e)
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

            connect.Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure want to delete Employee details?", "Confirmation message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                string myconnection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                SqlConnection connect = new SqlConnection(myconnection);
                connect.Open();

                SqlCommand cmd = new SqlCommand("sp_deleteemp", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@empid", SqlDbType.VarChar);
                cmd.Parameters.Add(p1).Value = searchbox.Text;

                int a = cmd.ExecuteNonQuery();

                if (a > 0)
                {

                    MessageBox.Show("Data deleted successfully");

                }

                connect.Close();

            }

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
    }
}
