using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Timer = System.Timers.Timer;
using System.Diagnostics;
using Sagehill_Pallaium_Intergration_module.Tech;
using Microsoft.Win32;
using Sagehill_Pallaium_Intergration_module.DbConfig;

namespace Sagehill_Pallaium_Intergration_module
{

    public partial class MainForm : Form
    {

        public MainForm()
        {

            Logger logger = new Logger();


            //10minutes = 600000ms
            //5mins = 300000ms
            //4min = 240000ms
            //6mins = 360000ms
            //7mins =420000ms
            //8mins =480000ms
            //9mins = 540000ms
            //15mins =900000ms
            //30mins = 1800000
            //3mins = 180000ms



            Timer x = new Timer(1800000);
           
            x.AutoReset = true;
            x.Elapsed += new System.Timers.ElapsedEventHandler(MyTimer);//timer event handler
            x.Start();//starting timer
            InitializeComponent();

        }
        delegate void SetTextCallback(string text);


        //Method to set text to richtextbox in a thread that didnt create the rich textbox

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.MainRichTextbox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.MainRichTextbox.AppendText(text + Environment.NewLine);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            SetText("\n>>Loading Intergration Module...");

        }

        //timer event handler method
        public void MyTimer(object sender, System.Timers.ElapsedEventArgs e)
        {

            //the code below will be called every 120 seconds
            try
            {
                //Parameters for mysql connection

                SetText("Time Stamp: " + DateTime.Now.ToLongTimeString());
                SetText(">>Connecting to third Party DB(Mysql) ...");

                //from configuration wizard
                DatabaseConfiguration setting = new DatabaseConfiguration();
                string configdb = string.Empty;

                var configcnstr = setting.GetConnectionString("cn");
                if (string.IsNullOrEmpty(configcnstr) && string.IsNullOrWhiteSpace(configcnstr))
                {

                    configdb = @"server=10.0.0.12;userid=palladium;password=palladium2021@;database=palladium;Connection Timeout=600";

                }
                else
                {
                    configdb = setting.GetConnectionString("cn");

                }
                
                //string conString = @"server=localhost;userid=root;password=;database=prazdb;Connection Timeout=600";
                string conString = configdb;
                
                
                
                //Trim email and address  ==== to meet the max length of 100 
                string sqlCmdCustomerVendor = "select regnumber,name,SUBSTR(address,1,100) as address,SUBSTR(REPLACE(REPLACE(REPLACE(`emails`, ' ', ''), '\t', ''), '\n', ''),1,50) as emails,phones,source_id,created_at,updated_at from accountdetails where monthname(created_at)=monthname(now()) && year(created_at)=year(now()) order by created_at desc limit 0,50000";
               
                string sqlCmdReceipts = "SELECT receiptnumber,concat('IN-',SUBSTR(invoicenumber,4)) as invoicenumber,invoicenumber as newInvoice,regnumber,method,currency,amount,description,account,created_at FROM receipted where monthname(created_at)=monthname(now()) and year(created_at)=year(now()) order by created_at desc";
                
                string sqlCmdInvoices = "SELECT SUBSTR(invoice_number,4) as invoice_number,ANY_VALUE(year) as year,ANY_VALUE(name) as name,ANY_VALUE(regnumber) as regnumber, sum(cost) as cost,ANY_VALUE(code) as code,ANY_VALUE(description) as description,ANY_VALUE(updated_at) as updated_at,ANY_VALUE(created_at) as created_at,ANY_VALUE(source_id) as source_id,SUBSTR(ANY_VALUE(additional),1,50) as additional FROM invoices where monthname(updated_at)=monthname(now()) && year(updated_at)=year(now()) GROUP BY invoice_number order by ANY_VALUE(updated_at) desc";

                string xmlDocNameCustomers = "Customers";
                string xmlDocNameVendors = "Vendors";
                string xmlDocNameInvoices = "SalesInvoices";
                string xmlDocNameReceipts = "Receipts";


                PalladiumIntergrationClass pi = new PalladiumIntergrationClass();

                DataTable dataTableRec = new DataTable();
                DataTable dataTablePay = new DataTable();
                DataTable dataTable = new DataTable();
                DataTable dataTableLines = new DataTable();


                //executing methods to write into xml docs
                pi.WriteToXMLRecievables(dataTableRec, conString, sqlCmdCustomerVendor, xmlDocNameCustomers);
                pi.WriteToXMLPayables(dataTablePay, conString, sqlCmdCustomerVendor, xmlDocNameVendors);
                pi.WriteToXMLInvoices(dataTable, conString, sqlCmdInvoices, xmlDocNameInvoices);
                pi.WriteToXMLReciepts(dataTable, conString, sqlCmdReceipts, xmlDocNameReceipts);



                Logger logger = new Logger();
                logger.Log("Written Data To XML Document");
                SetText(">>Successfully connected to remote DB(MySql)...");
                SetText(">>Extracting Data from remote DB(MySql)...");




                SetText(">>Loading Data to Palladium Accounting...");
                //executing method to push xml docs into palladium 
                pi.PostToPalladiumRecievables("Customers.xml");
                pi.PostToPalladiumPayables("Vendors.xml");
                pi.PostToPalladiumInvoices("SalesInvoices.xml");
                pi.PostToPalladiumReciepts("Receipts.xml");

                logger.Log(">>Pushed Data to palladium...");

                // SetText(">>Success...\n");


                // TextWriterTraceListener textfle
                pi.writeCustomerandvendorsFile(conString, sqlCmdCustomerVendor, dataTableRec);
                pi.writeInvoiceFile(conString, sqlCmdInvoices, dataTable);
                pi.writeReceiptsFile(conString, sqlCmdReceipts, dataTable);



            }
            catch (Exception ex)
            {
                Logger logger = new Logger();
                logger.Log(ex.ToString());
                SetText("The Module had an Error, Try to restart it and contact the Administrator");
            }

        }


        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Process.Start("Log.txt");

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            About fn = new About();
            fn.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close Application ? If you Exit Praz Portal Data will not be pushed to Palladium",
                               "Closing Application",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Exit Application ?",
                               "Do you want to close Application ? If you exit Praz Portal Data will not be pushed to Palladium",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information) == DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void MainRichTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void postToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            //PostData pstData = new PostData();
           // pstData.ShowDialog();
        }

        private void technicalAssistantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Technical fmtec = new Technical();
            fmtec.ShowDialog();
        }

        private void makeAppRunOnStartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistryKey reg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\windows\\CurrentVersion\\Run", true);
            reg.SetValue("Palladium_integration for Sagehill", Application.ExecutablePath.ToString());
            MessageBox.Show("Permission granted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void removeFromStartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistryKey reg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\windows\\CurrentVersion\\Run", true);
            reg.DeleteValue("Palladium_integration for Sagehill", false);
            MessageBox.Show("App removed the value from the registry", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void salesInvoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"datafile\invoices.txt");
        }

        private void receiptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"datafile\receipt.txt");
            
        }

        private void customerandvendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"datafile\customerandvendors.txt");
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About fn = new About();
            fn.ShowDialog();
        }

        private void databaseConfigurationsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DatabaseConfigurationwiz dbcon = new DatabaseConfigurationwiz();
            dbcon.ShowDialog();
        }

        private void databaseConfigurationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatabaseConfigurationwiz dbcon = new DatabaseConfigurationwiz();
            dbcon.ShowDialog();
        }
    }
}