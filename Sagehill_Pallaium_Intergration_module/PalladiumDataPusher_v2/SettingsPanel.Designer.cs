
namespace Sagehill_Pallaium_Intergration_module.PalladiumDataPusher_v2
{
    partial class SettingsPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsPanel));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chRemovePermission = new System.Windows.Forms.CheckBox();
            this.rdGrantPermision = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ckSystemlogs = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ckReceiptslog = new System.Windows.Forms.CheckBox();
            this.ckTenderInvoicelog = new System.Windows.Forms.CheckBox();
            this.ckSupplInvoislog = new System.Windows.Forms.CheckBox();
            this.ckCustomerententies = new System.Windows.Forms.CheckBox();
            this.ckspvlogfile = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(856, 54);
            this.panel1.TabIndex = 8;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Sagehill_Pallaium_Intergration_module.Properties.Resources.logo__3_;
            this.pictureBox2.Location = new System.Drawing.Point(691, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(157, 54);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 30);
            this.label2.TabIndex = 8;
            this.label2.Text = "Setup";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chRemovePermission);
            this.groupBox1.Controls.Add(this.rdGrantPermision);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 90);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grant Permissions";
            // 
            // chRemovePermission
            // 
            this.chRemovePermission.AutoSize = true;
            this.chRemovePermission.ForeColor = System.Drawing.Color.Red;
            this.chRemovePermission.Location = new System.Drawing.Point(209, 48);
            this.chRemovePermission.Name = "chRemovePermission";
            this.chRemovePermission.Size = new System.Drawing.Size(119, 17);
            this.chRemovePermission.TabIndex = 15;
            this.chRemovePermission.Text = "Remove Permission";
            this.chRemovePermission.UseVisualStyleBackColor = true;
            this.chRemovePermission.CheckedChanged += new System.EventHandler(this.chRemovePermission_CheckedChanged);
            // 
            // rdGrantPermision
            // 
            this.rdGrantPermision.AutoSize = true;
            this.rdGrantPermision.ForeColor = System.Drawing.Color.Green;
            this.rdGrantPermision.Location = new System.Drawing.Point(32, 48);
            this.rdGrantPermision.Name = "rdGrantPermision";
            this.rdGrantPermision.Size = new System.Drawing.Size(100, 17);
            this.rdGrantPermision.TabIndex = 5;
            this.rdGrantPermision.Text = "Grant Permision";
            this.rdGrantPermision.UseVisualStyleBackColor = true;
            this.rdGrantPermision.CheckedChanged += new System.EventHandler(this.rdGrantPermision_CheckedChanged_1);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(383, 22);
            this.label1.TabIndex = 12;
            this.label1.Text = "Allow App Run Automatically when server switch on";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSchedule);
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Location = new System.Drawing.Point(435, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(413, 83);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database Configurations";
            // 
            // btnSchedule
            // 
            this.btnSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnSchedule.ForeColor = System.Drawing.Color.White;
            this.btnSchedule.Location = new System.Drawing.Point(217, 26);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(182, 39);
            this.btnSchedule.TabIndex = 19;
            this.btnSchedule.Text = "Schedule Timer";
            this.btnSchedule.UseVisualStyleBackColor = false;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(24, 26);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(182, 39);
            this.button7.TabIndex = 18;
            this.button7.Text = "Database Configuration";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.groupBox3.Controls.Add(this.ckSystemlogs);
            this.groupBox3.Location = new System.Drawing.Point(435, 288);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(271, 78);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "System Logs";
            // 
            // ckSystemlogs
            // 
            this.ckSystemlogs.AutoSize = true;
            this.ckSystemlogs.Location = new System.Drawing.Point(5, 33);
            this.ckSystemlogs.Name = "ckSystemlogs";
            this.ckSystemlogs.Size = new System.Drawing.Size(79, 17);
            this.ckSystemlogs.TabIndex = 5;
            this.ckSystemlogs.Text = "Systemlogs";
            this.ckSystemlogs.UseVisualStyleBackColor = true;
            this.ckSystemlogs.CheckedChanged += new System.EventHandler(this.ckSystemlogs_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ckReceiptslog);
            this.groupBox4.Controls.Add(this.ckTenderInvoicelog);
            this.groupBox4.Controls.Add(this.ckSupplInvoislog);
            this.groupBox4.Controls.Add(this.ckCustomerententies);
            this.groupBox4.Controls.Add(this.ckspvlogfile);
            this.groupBox4.Location = new System.Drawing.Point(11, 152);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(414, 125);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Portal Transactions Timestamp";
            // 
            // ckReceiptslog
            // 
            this.ckReceiptslog.AutoSize = true;
            this.ckReceiptslog.Location = new System.Drawing.Point(19, 99);
            this.ckReceiptslog.Name = "ckReceiptslog";
            this.ckReceiptslog.Size = new System.Drawing.Size(101, 17);
            this.ckReceiptslog.TabIndex = 4;
            this.ckReceiptslog.Text = "Receipts log file";
            this.ckReceiptslog.UseVisualStyleBackColor = true;
            this.ckReceiptslog.CheckedChanged += new System.EventHandler(this.ckReceiptslog_CheckedChanged);
            // 
            // ckTenderInvoicelog
            // 
            this.ckTenderInvoicelog.AutoSize = true;
            this.ckTenderInvoicelog.Location = new System.Drawing.Point(250, 71);
            this.ckTenderInvoicelog.Name = "ckTenderInvoicelog";
            this.ckTenderInvoicelog.Size = new System.Drawing.Size(136, 17);
            this.ckTenderInvoicelog.TabIndex = 3;
            this.ckTenderInvoicelog.Text = "Tender Invoices log file";
            this.ckTenderInvoicelog.UseVisualStyleBackColor = true;
            this.ckTenderInvoicelog.CheckedChanged += new System.EventHandler(this.ckTenderInvoicelog_CheckedChanged);
            // 
            // ckSupplInvoislog
            // 
            this.ckSupplInvoislog.AutoSize = true;
            this.ckSupplInvoislog.Location = new System.Drawing.Point(250, 34);
            this.ckSupplInvoislog.Name = "ckSupplInvoislog";
            this.ckSupplInvoislog.Size = new System.Drawing.Size(150, 17);
            this.ckSupplInvoislog.TabIndex = 2;
            this.ckSupplInvoislog.Text = "Suppliers Invoices logs file";
            this.ckSupplInvoislog.UseVisualStyleBackColor = true;
            this.ckSupplInvoislog.CheckedChanged += new System.EventHandler(this.ckSupplInvoislog_CheckedChanged);
            // 
            // ckCustomerententies
            // 
            this.ckCustomerententies.AutoSize = true;
            this.ckCustomerententies.Location = new System.Drawing.Point(19, 71);
            this.ckCustomerententies.Name = "ckCustomerententies";
            this.ckCustomerententies.Size = new System.Drawing.Size(147, 17);
            this.ckCustomerententies.TabIndex = 1;
            this.ckCustomerententies.Text = "Customers/Entities log file";
            this.ckCustomerententies.UseVisualStyleBackColor = true;
            this.ckCustomerententies.CheckedChanged += new System.EventHandler(this.ckCustomerententies_CheckedChanged);
            // 
            // ckspvlogfile
            // 
            this.ckspvlogfile.AutoSize = true;
            this.ckspvlogfile.Location = new System.Drawing.Point(19, 34);
            this.ckspvlogfile.Name = "ckspvlogfile";
            this.ckspvlogfile.Size = new System.Drawing.Size(149, 17);
            this.ckspvlogfile.TabIndex = 0;
            this.ckspvlogfile.Text = "Suppliers/Vendors log File";
            this.ckspvlogfile.UseVisualStyleBackColor = true;
            this.ckspvlogfile.CheckedChanged += new System.EventHandler(this.ckspvlogfile_CheckedChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(691, 397);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 30);
            this.button2.TabIndex = 12;
            this.button2.Text = "Close System";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox5.Controls.Add(this.checkBox1);
            this.groupBox5.Controls.Add(this.checkBox2);
            this.groupBox5.Controls.Add(this.checkBox3);
            this.groupBox5.Controls.Add(this.checkBox4);
            this.groupBox5.Controls.Add(this.checkBox5);
            this.groupBox5.Location = new System.Drawing.Point(434, 156);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(414, 125);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Palladium Transactions";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(19, 99);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(101, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Receipts log file";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(250, 71);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(136, 17);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "Tender Invoices log file";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(250, 34);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(150, 17);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "Suppliers Invoices logs file";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(19, 71);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(147, 17);
            this.checkBox4.TabIndex = 1;
            this.checkBox4.Text = "Customers/Entities log file";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(19, 34);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(149, 17);
            this.checkBox5.TabIndex = 0;
            this.checkBox5.Text = "Suppliers/Vendors log File";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(563, 397);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 30);
            this.button1.TabIndex = 13;
            this.button1.Text = "Restart App";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Silver;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(440, 397);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 30);
            this.button3.TabIndex = 14;
            this.button3.Text = "Quick Post";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Silver;
            this.groupBox6.Controls.Add(this.checkBox6);
            this.groupBox6.Controls.Add(this.checkBox7);
            this.groupBox6.Controls.Add(this.checkBox8);
            this.groupBox6.Controls.Add(this.checkBox9);
            this.groupBox6.Controls.Add(this.checkBox10);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox6.Location = new System.Drawing.Point(11, 298);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(414, 125);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Portal Transactions Payload";
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(19, 99);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(97, 17);
            this.checkBox6.TabIndex = 4;
            this.checkBox6.Text = "Receipts file";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(250, 71);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(139, 17);
            this.checkBox7.TabIndex = 3;
            this.checkBox7.Text = "Tender Invoices file";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(250, 34);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(151, 17);
            this.checkBox8.TabIndex = 2;
            this.checkBox8.Text = "Suppliers Invoices file";
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.checkBox8_CheckedChanged);
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(19, 71);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(153, 17);
            this.checkBox9.TabIndex = 1;
            this.checkBox9.Text = "Customers/Entities file";
            this.checkBox9.UseVisualStyleBackColor = true;
            this.checkBox9.CheckedChanged += new System.EventHandler(this.checkBox9_CheckedChanged);
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(19, 34);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(154, 17);
            this.checkBox10.TabIndex = 0;
            this.checkBox10.Text = "Suppliers/Vendors File";
            this.checkBox10.UseVisualStyleBackColor = true;
            this.checkBox10.CheckedChanged += new System.EventHandler(this.checkBox10_CheckedChanged);
            // 
            // SettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 439);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSchedule;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.CheckBox ckReceiptslog;
        private System.Windows.Forms.CheckBox ckTenderInvoicelog;
        private System.Windows.Forms.CheckBox ckSupplInvoislog;
        private System.Windows.Forms.CheckBox ckCustomerententies;
        private System.Windows.Forms.CheckBox ckspvlogfile;
        private System.Windows.Forms.CheckBox ckSystemlogs;
        private System.Windows.Forms.CheckBox rdGrantPermision;
        private System.Windows.Forms.CheckBox chRemovePermission;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox10;
    }
}