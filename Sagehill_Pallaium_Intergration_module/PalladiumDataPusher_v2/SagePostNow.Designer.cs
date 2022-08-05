
namespace Sagehill_Pallaium_Intergration_module.PalladiumDataPusher_v2
{
    partial class SagePostNow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SagePostNow));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.fyReceipts = new System.Windows.Forms.Button();
            this.fyTendInvoices = new System.Windows.Forms.Button();
            this.fySupInvoices = new System.Windows.Forms.Button();
            this.fySuppliers = new System.Windows.Forms.Button();
            this.fyCustomers = new System.Windows.Forms.Button();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdReceipts = new System.Windows.Forms.Button();
            this.cmdTendInvoices = new System.Windows.Forms.Button();
            this.cmdSupInvoices = new System.Windows.Forms.Button();
            this.cmdSupplers = new System.Windows.Forms.Button();
            this.cmdCustomers = new System.Windows.Forms.Button();
            this.cmdPostTransactions = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.stbProgress = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.strLoading = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbProgresstask = new System.Windows.Forms.ToolStripProgressBar();
            this.telthemwebTime = new System.Windows.Forms.Timer(this.components);
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.stbProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(387, 38);
            this.label1.TabIndex = 11;
            this.label1.Text = "Note:  Filter only work here, others will be fetching records\r\n according to curr" +
    "ent month";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.fyReceipts);
            this.groupBox4.Controls.Add(this.fyTendInvoices);
            this.groupBox4.Controls.Add(this.fySupInvoices);
            this.groupBox4.Controls.Add(this.fySuppliers);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.fyCustomers);
            this.groupBox4.Controls.Add(this.cmbYear);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 54);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(667, 163);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filter  by year";
            // 
            // fyReceipts
            // 
            this.fyReceipts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fyReceipts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fyReceipts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.fyReceipts.ForeColor = System.Drawing.Color.White;
            this.fyReceipts.Location = new System.Drawing.Point(336, 98);
            this.fyReceipts.Name = "fyReceipts";
            this.fyReceipts.Size = new System.Drawing.Size(150, 35);
            this.fyReceipts.TabIndex = 17;
            this.fyReceipts.Text = "Receipts";
            this.fyReceipts.UseVisualStyleBackColor = false;
            this.fyReceipts.Click += new System.EventHandler(this.fyReceipts_Click);
            // 
            // fyTendInvoices
            // 
            this.fyTendInvoices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fyTendInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fyTendInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.fyTendInvoices.ForeColor = System.Drawing.Color.White;
            this.fyTendInvoices.Location = new System.Drawing.Point(170, 120);
            this.fyTendInvoices.Name = "fyTendInvoices";
            this.fyTendInvoices.Size = new System.Drawing.Size(150, 35);
            this.fyTendInvoices.TabIndex = 16;
            this.fyTendInvoices.Text = "Tender Invoices";
            this.fyTendInvoices.UseVisualStyleBackColor = false;
            this.fyTendInvoices.Click += new System.EventHandler(this.fyTendInvoices_Click);
            // 
            // fySupInvoices
            // 
            this.fySupInvoices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fySupInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fySupInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.fySupInvoices.ForeColor = System.Drawing.Color.White;
            this.fySupInvoices.Location = new System.Drawing.Point(11, 120);
            this.fySupInvoices.Name = "fySupInvoices";
            this.fySupInvoices.Size = new System.Drawing.Size(150, 35);
            this.fySupInvoices.TabIndex = 15;
            this.fySupInvoices.Text = "Supplier Invoices";
            this.fySupInvoices.UseVisualStyleBackColor = false;
            this.fySupInvoices.Click += new System.EventHandler(this.fySupInvoices_Click);
            // 
            // fySuppliers
            // 
            this.fySuppliers.BackColor = System.Drawing.Color.Gray;
            this.fySuppliers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fySuppliers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.fySuppliers.ForeColor = System.Drawing.Color.White;
            this.fySuppliers.Location = new System.Drawing.Point(170, 79);
            this.fySuppliers.Name = "fySuppliers";
            this.fySuppliers.Size = new System.Drawing.Size(150, 35);
            this.fySuppliers.TabIndex = 13;
            this.fySuppliers.Text = "Suppliers/Vendors";
            this.fySuppliers.UseVisualStyleBackColor = false;
            this.fySuppliers.Click += new System.EventHandler(this.fySuppliers_Click);
            // 
            // fyCustomers
            // 
            this.fyCustomers.BackColor = System.Drawing.Color.Gray;
            this.fyCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fyCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.fyCustomers.ForeColor = System.Drawing.Color.White;
            this.fyCustomers.Location = new System.Drawing.Point(11, 79);
            this.fyCustomers.Name = "fyCustomers";
            this.fyCustomers.Size = new System.Drawing.Size(150, 35);
            this.fyCustomers.TabIndex = 1;
            this.fyCustomers.Text = "Customers/Enteties";
            this.fyCustomers.UseVisualStyleBackColor = false;
            this.fyCustomers.Click += new System.EventHandler(this.fyCustomers_Click);
            // 
            // cmbYear
            // 
            this.cmbYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Items.AddRange(new object[] {
            "2019",
            "2020",
            "2021",
            "2022",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030",
            "2031",
            "2032",
            "2033",
            "2034",
            "2035",
            "2036",
            "2037",
            "2038",
            "2039",
            "2040"});
            this.cmbYear.Location = new System.Drawing.Point(421, 30);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(215, 33);
            this.cmbYear.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmdReceipts);
            this.groupBox1.Controls.Add(this.cmdTendInvoices);
            this.groupBox1.Controls.Add(this.cmdSupInvoices);
            this.groupBox1.Controls.Add(this.cmdSupplers);
            this.groupBox1.Controls.Add(this.cmdCustomers);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 221);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(665, 106);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Month Data";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(25, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 21);
            this.label2.TabIndex = 18;
            this.label2.Text = "Note:  No Filter Here";
            // 
            // cmdReceipts
            // 
            this.cmdReceipts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdReceipts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdReceipts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.cmdReceipts.ForeColor = System.Drawing.Color.White;
            this.cmdReceipts.Location = new System.Drawing.Point(493, 47);
            this.cmdReceipts.Name = "cmdReceipts";
            this.cmdReceipts.Size = new System.Drawing.Size(150, 35);
            this.cmdReceipts.TabIndex = 18;
            this.cmdReceipts.Text = "Receipts";
            this.cmdReceipts.UseVisualStyleBackColor = false;
            this.cmdReceipts.Click += new System.EventHandler(this.cmdReceipts_Click);
            // 
            // cmdTendInvoices
            // 
            this.cmdTendInvoices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdTendInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdTendInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.cmdTendInvoices.ForeColor = System.Drawing.Color.White;
            this.cmdTendInvoices.Location = new System.Drawing.Point(337, 64);
            this.cmdTendInvoices.Name = "cmdTendInvoices";
            this.cmdTendInvoices.Size = new System.Drawing.Size(150, 35);
            this.cmdTendInvoices.TabIndex = 18;
            this.cmdTendInvoices.Text = "Tender Invoices";
            this.cmdTendInvoices.UseVisualStyleBackColor = false;
            this.cmdTendInvoices.Click += new System.EventHandler(this.cmdTendInvoices_Click);
            // 
            // cmdSupInvoices
            // 
            this.cmdSupInvoices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdSupInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSupInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.cmdSupInvoices.ForeColor = System.Drawing.Color.White;
            this.cmdSupInvoices.Location = new System.Drawing.Point(181, 64);
            this.cmdSupInvoices.Name = "cmdSupInvoices";
            this.cmdSupInvoices.Size = new System.Drawing.Size(150, 35);
            this.cmdSupInvoices.TabIndex = 18;
            this.cmdSupInvoices.Text = "Supplier Invoices";
            this.cmdSupInvoices.UseVisualStyleBackColor = false;
            this.cmdSupInvoices.Click += new System.EventHandler(this.cmdSupInvoices_Click);
            // 
            // cmdSupplers
            // 
            this.cmdSupplers.BackColor = System.Drawing.Color.Gray;
            this.cmdSupplers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSupplers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.cmdSupplers.ForeColor = System.Drawing.Color.White;
            this.cmdSupplers.Location = new System.Drawing.Point(337, 23);
            this.cmdSupplers.Name = "cmdSupplers";
            this.cmdSupplers.Size = new System.Drawing.Size(150, 35);
            this.cmdSupplers.TabIndex = 18;
            this.cmdSupplers.Text = "Suppliers/Vendors";
            this.cmdSupplers.UseVisualStyleBackColor = false;
            this.cmdSupplers.Click += new System.EventHandler(this.cmdSupplers_Click);
            // 
            // cmdCustomers
            // 
            this.cmdCustomers.BackColor = System.Drawing.Color.Gray;
            this.cmdCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.cmdCustomers.ForeColor = System.Drawing.Color.White;
            this.cmdCustomers.Location = new System.Drawing.Point(181, 23);
            this.cmdCustomers.Name = "cmdCustomers";
            this.cmdCustomers.Size = new System.Drawing.Size(150, 35);
            this.cmdCustomers.TabIndex = 2;
            this.cmdCustomers.Text = "Customers/Enteties";
            this.cmdCustomers.UseVisualStyleBackColor = false;
            this.cmdCustomers.Click += new System.EventHandler(this.cmdCustomers_Click);
            // 
            // cmdPostTransactions
            // 
            this.cmdPostTransactions.BackColor = System.Drawing.Color.Black;
            this.cmdPostTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPostTransactions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.cmdPostTransactions.ForeColor = System.Drawing.Color.White;
            this.cmdPostTransactions.Location = new System.Drawing.Point(506, 347);
            this.cmdPostTransactions.Name = "cmdPostTransactions";
            this.cmdPostTransactions.Size = new System.Drawing.Size(173, 35);
            this.cmdPostTransactions.TabIndex = 18;
            this.cmdPostTransactions.Text = "Post All Transactions";
            this.cmdPostTransactions.UseVisualStyleBackColor = false;
            this.cmdPostTransactions.Click += new System.EventHandler(this.cmdPostTransactions_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Red;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.button11.ForeColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(583, 12);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(96, 39);
            this.button11.TabIndex = 16;
            this.button11.Text = "Exit";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Green;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(395, 12);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(182, 39);
            this.button7.TabIndex = 17;
            this.button7.Text = "Database Configuration";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(267, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 39);
            this.button1.TabIndex = 19;
            this.button1.Text = "Settings";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // stbProgress
            // 
            this.stbProgress.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel4,
            this.timeLabel,
            this.strLoading,
            this.lbProgresstask});
            this.stbProgress.Location = new System.Drawing.Point(0, 394);
            this.stbProgress.Name = "stbProgress";
            this.stbProgress.Size = new System.Drawing.Size(690, 30);
            this.stbProgress.TabIndex = 20;
            this.stbProgress.Text = "StatusBAR";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(184, 25);
            this.toolStripStatusLabel1.Text = "Developed by Sagehill Developers";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(45, 25);
            this.toolStripStatusLabel4.Text = "| Time: ";
            // 
            // timeLabel
            // 
            this.timeLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.timeLabel.ForeColor = System.Drawing.Color.Green;
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(0, 25);
            // 
            // strLoading
            // 
            this.strLoading.Name = "strLoading";
            this.strLoading.Size = new System.Drawing.Size(128, 25);
            this.strLoading.Text = "         |  Loading              ";
            // 
            // lbProgresstask
            // 
            this.lbProgresstask.MarqueeAnimationSpeed = 1500;
            this.lbProgresstask.Name = "lbProgresstask";
            this.lbProgresstask.Size = new System.Drawing.Size(100, 24);
            this.lbProgresstask.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // telthemwebTime
            // 
            this.telthemwebTime.Enabled = true;
            this.telthemwebTime.Tick += new System.EventHandler(this.telthemwebTime_Tick);
            // 
            // SagePostNow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 424);
            this.Controls.Add(this.stbProgress);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.cmdPostTransactions);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SagePostNow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUICK POST";
            this.Load += new System.EventHandler(this.SagePostNow_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.stbProgress.ResumeLayout(false);
            this.stbProgress.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button fySuppliers;
        private System.Windows.Forms.Button fyCustomers;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button fyReceipts;
        private System.Windows.Forms.Button fyTendInvoices;
        private System.Windows.Forms.Button fySupInvoices;
        private System.Windows.Forms.Button cmdPostTransactions;
        private System.Windows.Forms.Button cmdReceipts;
        private System.Windows.Forms.Button cmdTendInvoices;
        private System.Windows.Forms.Button cmdSupInvoices;
        private System.Windows.Forms.Button cmdSupplers;
        private System.Windows.Forms.Button cmdCustomers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip stbProgress;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel timeLabel;
        private System.Windows.Forms.Timer telthemwebTime;
        private System.Windows.Forms.ToolStripStatusLabel strLoading;
        private System.Windows.Forms.ToolStripProgressBar lbProgresstask;
    }
}