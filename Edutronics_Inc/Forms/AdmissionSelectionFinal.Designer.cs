namespace Edutronics_Inc.Forms
{
    partial class AdmissionSelectionFinal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdmissionSelectionFinal));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Fetch = new System.Windows.Forms.Button();
            this.admgrade = new System.Windows.Forms.TextBox();
            this.admname = new System.Windows.Forms.TextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.dataGridViewAdmissions = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnadd = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdmissions)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Approved",
            "Rejected"});
            this.comboBox1.Location = new System.Drawing.Point(793, 568);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(222, 28);
            this.comboBox1.TabIndex = 49;
            // 
            // Fetch
            // 
            this.Fetch.BackgroundImage = global::Edutronics_Inc.Properties.Resources.Screenshot_2024_05_29_2006341;
            this.Fetch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Fetch.FlatAppearance.BorderSize = 0;
            this.Fetch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Fetch.Font = new System.Drawing.Font("Times New Roman", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Fetch.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Fetch.Location = new System.Drawing.Point(98, 546);
            this.Fetch.Name = "Fetch";
            this.Fetch.Size = new System.Drawing.Size(122, 49);
            this.Fetch.TabIndex = 48;
            this.Fetch.Text = "Pending";
            this.Fetch.UseVisualStyleBackColor = true;
            this.Fetch.Click += new System.EventHandler(this.Fetch_Click);
            // 
            // admgrade
            // 
            this.admgrade.Location = new System.Drawing.Point(671, 561);
            this.admgrade.Multiline = true;
            this.admgrade.Name = "admgrade";
            this.admgrade.Size = new System.Drawing.Size(98, 35);
            this.admgrade.TabIndex = 47;
            // 
            // admname
            // 
            this.admname.Location = new System.Drawing.Point(444, 561);
            this.admname.Multiline = true;
            this.admname.Name = "admname";
            this.admname.Size = new System.Drawing.Size(165, 35);
            this.admname.TabIndex = 46;
            // 
            // btnAccept
            // 
            this.btnAccept.BackgroundImage = global::Edutronics_Inc.Properties.Resources.Screenshot_2024_05_29_200846;
            this.btnAccept.FlatAppearance.BorderSize = 0;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAccept.Font = new System.Drawing.Font("Times New Roman", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnAccept.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnAccept.Location = new System.Drawing.Point(893, 612);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(122, 49);
            this.btnAccept.TabIndex = 45;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // dataGridViewAdmissions
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            this.dataGridViewAdmissions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewAdmissions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAdmissions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewAdmissions.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewAdmissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAdmissions.Location = new System.Drawing.Point(98, 76);
            this.dataGridViewAdmissions.Name = "dataGridViewAdmissions";
            this.dataGridViewAdmissions.RowHeadersWidth = 62;
            this.dataGridViewAdmissions.RowTemplate.Height = 28;
            this.dataGridViewAdmissions.Size = new System.Drawing.Size(1086, 433);
            this.dataGridViewAdmissions.TabIndex = 44;
            this.dataGridViewAdmissions.DoubleClick += new System.EventHandler(this.dataGridViewAdmissions_DoubleClick);
            // 
            // label2
            // 
            this.label2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(439, 523);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 30);
            this.label2.TabIndex = 50;
            this.label2.Text = "Admission Name";
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(666, 523);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 30);
            this.label1.TabIndex = 51;
            this.label1.Text = "Grade";
            // 
            // label3
            // 
            this.label3.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(788, 523);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 30);
            this.label3.TabIndex = 52;
            this.label3.Text = "Select";
            // 
            // btnadd
            // 
            this.btnadd.BackgroundImage = global::Edutronics_Inc.Properties.Resources.Screenshot_2024_05_29_195353;
            this.btnadd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnadd.FlatAppearance.BorderSize = 0;
            this.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnadd.Font = new System.Drawing.Font("Times New Roman", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnadd.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnadd.Location = new System.Drawing.Point(1052, 537);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(132, 49);
            this.btnadd.TabIndex = 84;
            this.btnadd.Text = "Approved";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnprint
            // 
            this.btnprint.BackgroundImage = global::Edutronics_Inc.Properties.Resources.Screenshot_2024_05_29_201140;
            this.btnprint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnprint.FlatAppearance.BorderSize = 0;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnprint.Font = new System.Drawing.Font("Times New Roman", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnprint.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnprint.Location = new System.Drawing.Point(1052, 608);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(132, 49);
            this.btnprint.TabIndex = 85;
            this.btnprint.Text = "Print";
            this.btnprint.UseVisualStyleBackColor = true;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
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
            // 
            // AdmissionSelectionFinal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Edutronics_Inc.Properties.Resources.Screenshot_2024_05_29_1905381;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1486, 814);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Fetch);
            this.Controls.Add(this.admgrade);
            this.Controls.Add(this.admname);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.dataGridViewAdmissions);
            this.DoubleBuffered = true;
            this.Name = "AdmissionSelectionFinal";
            this.Text = "AdmissionSelectionFinal";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdmissions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button Fetch;
        private System.Windows.Forms.TextBox admgrade;
        private System.Windows.Forms.TextBox admname;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.DataGridView dataGridViewAdmissions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnprint;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}