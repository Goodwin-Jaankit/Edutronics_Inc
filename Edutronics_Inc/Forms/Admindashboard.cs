using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Edutronics_Inc.Forms
{
    public partial class Admindashboard : Form
    {
        public Admindashboard()
        {
            InitializeComponent();
            random = new Random();
        }

        //fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
   


        private Color SelectThemeColor()
        {
            int index = random.Next(Themecolor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(Themecolor.ColorList.Count);
            }
            tempIndex = index;
            string color = Themecolor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    paneltitle.BackColor = color;
                    panellogo.BackColor = Themecolor.ChangeColorBrightness(color, -0.3);
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelmenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(childForm);
            this.panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            labeltitle.Text = childForm.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           
        

        }

        private void paneltitle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Admindashboard_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EmployeeAccess(), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AdmissionSelectionFinal(), sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Rootaccess(), sender);
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private System.Windows.Forms.Timer autoCloseTimer;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            GC.Collect();
        }
    }

}