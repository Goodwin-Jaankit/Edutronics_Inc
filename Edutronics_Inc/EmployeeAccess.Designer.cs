namespace Edutronics_Inc
{
    partial class EmployeeAccess
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeAccess));
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.txt_image_src = new System.Windows.Forms.TextBox();
            this.Employeeimg = new System.Windows.Forms.Label();
            this.Fetch = new System.Windows.Forms.Button();
            this.searchbox = new System.Windows.Forms.TextBox();
            this.Print = new System.Windows.Forms.Button();
            this.Update = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.empsalary = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.empname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.empid = new System.Windows.Forms.TextBox();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Browse = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // txt_image_src
            // 
            this.txt_image_src.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txt_image_src.Location = new System.Drawing.Point(696, 233);
            this.txt_image_src.Name = "txt_image_src";
            this.txt_image_src.Size = new System.Drawing.Size(222, 30);
            this.txt_image_src.TabIndex = 44;
            // 
            // Employeeimg
            // 
            this.Employeeimg.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.Employeeimg.AutoSize = true;
            this.Employeeimg.BackColor = System.Drawing.Color.Transparent;
            this.Employeeimg.Font = new System.Drawing.Font("Times New Roman", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Employeeimg.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Employeeimg.Location = new System.Drawing.Point(691, 184);
            this.Employeeimg.Name = "Employeeimg";
            this.Employeeimg.Size = new System.Drawing.Size(168, 30);
            this.Employeeimg.TabIndex = 42;
            this.Employeeimg.Text = "Employee img";
            // 
            // Fetch
            // 
            this.Fetch.BackgroundImage = global::Edutronics_Inc.Properties.Resources.Screenshot_2024_05_29_1955311;
            this.Fetch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Fetch.FlatAppearance.BorderSize = 0;
            this.Fetch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Fetch.Font = new System.Drawing.Font("Times New Roman", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Fetch.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Fetch.Location = new System.Drawing.Point(418, 297);
            this.Fetch.Name = "Fetch";
            this.Fetch.Size = new System.Drawing.Size(122, 49);
            this.Fetch.TabIndex = 40;
            this.Fetch.Text = "Fetch";
            this.Fetch.UseVisualStyleBackColor = true;
            this.Fetch.Click += new System.EventHandler(this.Fetch_Click);
            // 
            // searchbox
            // 
            this.searchbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.searchbox.Location = new System.Drawing.Point(989, 282);
            this.searchbox.Multiline = true;
            this.searchbox.Name = "searchbox";
            this.searchbox.Size = new System.Drawing.Size(99, 38);
            this.searchbox.TabIndex = 39;
            // 
            // Print
            // 
            this.Print.BackgroundImage = global::Edutronics_Inc.Properties.Resources.Screenshot_2024_05_29_201140;
            this.Print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Print.FlatAppearance.BorderSize = 0;
            this.Print.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Print.Font = new System.Drawing.Font("Times New Roman", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Print.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Print.Location = new System.Drawing.Point(580, 297);
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(122, 49);
            this.Print.TabIndex = 38;
            this.Print.Text = "Print";
            this.Print.UseVisualStyleBackColor = true;
            this.Print.Click += new System.EventHandler(this.Print_Click);
            // 
            // Update
            // 
            this.Update.BackgroundImage = global::Edutronics_Inc.Properties.Resources.Screenshot_2024_05_29_195710;
            this.Update.FlatAppearance.BorderSize = 0;
            this.Update.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Update.Font = new System.Drawing.Font("Times New Roman", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Update.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Update.Location = new System.Drawing.Point(254, 297);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(122, 49);
            this.Update.TabIndex = 37;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // Delete
            // 
            this.Delete.BackgroundImage = global::Edutronics_Inc.Properties.Resources.Screenshot_2024_05_29_1947281;
            this.Delete.FlatAppearance.BorderSize = 0;
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Delete.Font = new System.Drawing.Font("Times New Roman", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Delete.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Delete.Location = new System.Drawing.Point(752, 297);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(122, 49);
            this.Delete.TabIndex = 36;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Add
            // 
            this.Add.BackgroundImage = global::Edutronics_Inc.Properties.Resources.Screenshot_2024_05_29_195353;
            this.Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Add.FlatAppearance.BorderSize = 0;
            this.Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Add.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Add.Location = new System.Drawing.Point(95, 297);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(137, 49);
            this.Add.TabIndex = 35;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(95, 394);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1063, 351);
            this.dataGridView1.TabIndex = 32;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "L.K.G",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBox2.Location = new System.Drawing.Point(379, 234);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(222, 33);
            this.comboBox2.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(374, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 30);
            this.label5.TabIndex = 32;
            this.label5.Text = "Employee Class";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Office Staff",
            "English Teacher",
            "Tamil Teacher",
            "Maths Teacher",
            "Science Teacher",
            "Social Teacher ",
            "PIT Teacher"});
            this.comboBox1.Location = new System.Drawing.Point(94, 234);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(222, 33);
            this.comboBox1.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(89, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 30);
            this.label4.TabIndex = 30;
            this.label4.Text = "Employee Role";
            // 
            // empsalary
            // 
            this.empsalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.empsalary.Location = new System.Drawing.Point(698, 109);
            this.empsalary.Name = "empsalary";
            this.empsalary.Size = new System.Drawing.Size(222, 30);
            this.empsalary.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label3.Location = new System.Drawing.Point(691, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 30);
            this.label3.TabIndex = 28;
            this.label3.Text = "Employee Salary";
            // 
            // empname
            // 
            this.empname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.empname.Location = new System.Drawing.Point(369, 106);
            this.empname.Name = "empname";
            this.empname.Size = new System.Drawing.Size(222, 30);
            this.empname.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(364, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 30);
            this.label2.TabIndex = 26;
            this.label2.Text = "Employee Name";
            // 
            // empid
            // 
            this.empid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.empid.Location = new System.Drawing.Point(94, 106);
            this.empid.Name = "empid";
            this.empid.Size = new System.Drawing.Size(222, 30);
            this.empid.TabIndex = 25;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            this.printPreviewDialog1.Load += new System.EventHandler(this.printPreviewDialog1_Load);
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(89, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 30);
            this.label1.TabIndex = 24;
            this.label1.Text = "Employee ID ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Edutronics_Inc.Properties.Resources.Screenshot_2024_05_29_201952;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(989, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 207);
            this.pictureBox1.TabIndex = 45;
            this.pictureBox1.TabStop = false;
            // 
            // Browse
            // 
            this.Browse.BackColor = System.Drawing.Color.Transparent;
            this.Browse.FlatAppearance.BorderSize = 0;
            this.Browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Browse.Font = new System.Drawing.Font("Segoe Print", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Browse.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Browse.Image = global::Edutronics_Inc.Properties.Resources.folder;
            this.Browse.Location = new System.Drawing.Point(852, 184);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(52, 30);
            this.Browse.TabIndex = 43;
            this.Browse.UseVisualStyleBackColor = false;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // Search
            // 
            this.Search.BackColor = System.Drawing.Color.Transparent;
            this.Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Search.FlatAppearance.BorderSize = 0;
            this.Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Search.Font = new System.Drawing.Font("Segoe Print", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search.ForeColor = System.Drawing.Color.Transparent;
            this.Search.Image = global::Edutronics_Inc.Properties.Resources.people;
            this.Search.Location = new System.Drawing.Point(1094, 271);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(65, 49);
            this.Search.TabIndex = 41;
            this.Search.UseVisualStyleBackColor = false;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // EmployeeAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Edutronics_Inc.Properties.Resources.Screenshot_2024_05_29_190538;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1298, 814);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txt_image_src);
            this.Controls.Add(this.Browse);
            this.Controls.Add(this.Employeeimg);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.Fetch);
            this.Controls.Add(this.searchbox);
            this.Controls.Add(this.Print);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.empsalary);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.empname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.empid);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Name = "EmployeeAccess";
            this.Text = "EmployeeAccess";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.TextBox txt_image_src;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.Label Employeeimg;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button Fetch;
        private System.Windows.Forms.TextBox searchbox;
        private System.Windows.Forms.Button Print;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox empsalary;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox empname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox empid;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Label label1;
    }
}