using Sagehill_Pallaium_Intergration_module.DbConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sagehill_Pallaium_Intergration_module.Tech
{
    public partial class PostData : Form
    {
        
       //public string conString = @"server=localhost;userid=root;password=;database=prazdb;Connection Timeout=600";
        //public string conString = @"server=10.0.0.12;userid=palladium;password=palladium2021@;database=palladium;Connection Timeout=600";




        




////Trim email and address  ==== to meet the max length of 100 
///
///this one fetch customer according to current month created and current year.
        public string sqlCmdCustomerVendor = "select regnumber,SUBSTR(name,1,200) as name,SUBSTR(address,1,100) as address,SUBSTR(REPLACE(REPLACE(REPLACE(`emails`, ' ', ''), '\t', ''), '\n', ''),1,50) as emails,SUBSTR(REPLACE(REPLACE(REPLACE(`phones`, ' ', ''), '\t', ''), '\n', ''),1,50) as phones,source_id,created_at,updated_at from accountdetails where monthname(created_at)=monthname(now()) && year(created_at)=year(now()) order by created_at desc limit 0,50000";

        ///this one fetch receipts according to current month created and current year.
        public string sqlCmdReceipts = "SELECT receiptnumber,concat('IN-',SUBSTR(invoicenumber,4)) as invoicenumber,invoicenumber as newInvoice,regnumber,method,currency,amount,description,account,created_at FROM receipted where monthname(created_at)=monthname(now()) and year(created_at)=year(now()) order by created_at desc";

        ///this one fetch invoices according to current month created and current year.
        public string sqlCmdInvoices = "SELECT SUBSTR(invoice_number,4) as invoice_number,ANY_VALUE(year) as year,ANY_VALUE(name) as name,ANY_VALUE(regnumber) as regnumber, sum(cost) as cost,ANY_VALUE(code) as code,ANY_VALUE(description) as description,ANY_VALUE(updated_at) as updated_at,ANY_VALUE(created_at) as created_at,ANY_VALUE(source_id) as source_id,SUBSTR(ANY_VALUE(additional),1,50) as additional FROM invoices where monthname(updated_at)=monthname(now()) && year(updated_at)=year(now()) GROUP BY invoice_number order by ANY_VALUE(updated_at) desc";

        public string sqlCmdCustomerVendorYear = "";

        PalladiumIntergrationClass pi = new PalladiumIntergrationClass();
        Logger logger = new Logger();

        DataTable dataTableRec = new DataTable();
        DataTable dataTablePay = new DataTable();
        DataTable dataTable = new DataTable();

        public string xmlDocNameCustomers = "Customers";
        public string xmlDocNameVendors = "Vendors";
        public string xmlDocNameInvoices = "SalesInvoices";
        public string xmlDocNameReceipts = "Receipts";


   
        public PostData()
        {
            InitializeComponent();
        }
        delegate void SetTextCallback(string text);

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

        private void PostData_Load(object sender, EventArgs e)
        {
           


            SetText("Time Stamp: " + DateTime.Now.ToLongTimeString());
            SetText(">>Connecting to third Party DB(Mysql) ...");
            SetText(">>Successfully connected");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            logger.Log("Written Data To XML Document");
            SetText(">>Successfully connected to PRAZ PORTAL");
            SetText(">>Extracting Customervendor records from PRAZ PORTAL...");

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

                string conString = configdb;
                pi.WriteToXMLRecievables(dataTableRec, conString, sqlCmdCustomerVendor, xmlDocNameCustomers);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetText(">>Loading Customer vendor records to Palladium Accounting...");
            pi.PostToPalladiumRecievables("Customers.xml");
            pi.PostToPalladiumPayables("Vendors.xml");
            logger.Log(">>Pushed Customer vendor records  to palladium...");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            logger.Log("Written Data To XML Document");
            SetText(">>Successfully connected to PRAZ PORTAL");
            SetText(">>Extracting Sales Invoices from PRAZ PORTAL...");
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

            string conString = configdb;




            pi.WriteToXMLInvoices(dataTable, conString, sqlCmdInvoices, xmlDocNameInvoices);
            SetText(">>Extracting Sales Invoices text file......");
            pi.writeInvoiceFile(conString, sqlCmdInvoices, dataTable);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetText(">>Loading Sales Invoices to Palladium Accounting...");
            pi.PostToPalladiumInvoices("SalesInvoices.xml"); 
            logger.Log(">>Pushed Sales Invoices to palladium...");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SetText(">>Loading Receipts to Palladium Accounting...");
            pi.PostToPalladiumReciepts("Receipts.xml");
            logger.Log(">>Pushed Sales Receipts to palladium...");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            logger.Log("Written Data To XML Document");
            SetText(">>Successfully connected to PRAZ PORTAL");
            SetText(">>Extracting Receipts from PRAZ PORTAL...");


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

            string conString = configdb;
            pi.WriteToXMLReciepts(dataTable, conString, sqlCmdReceipts, xmlDocNameReceipts);
            SetText(">>Extracting Receipts text file......");
            pi.writeReceiptsFile(conString, sqlCmdReceipts, dataTable);
        }

        // TextWriterTraceListener textfle
        
                
                

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmbYears_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void button8_Click(object sender, EventArgs e)
        {
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

            string conString = configdb;
            pi.WriteToXMLPayables(dataTablePay, conString, sqlCmdCustomerVendor, xmlDocNameVendors);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Since we have more customers - we can filter them with year created_at

            sqlCmdCustomerVendorYear = "select regnumber,SUBSTR(name,1,200) as name,SUBSTR(address,1,100) as address,SUBSTR(REPLACE(REPLACE(REPLACE(`emails`, ' ', ''), '\t', ''), '\n', ''),1,50) as emails,SUBSTR(REPLACE(REPLACE(REPLACE(`phones`, ' ', ''), '\t', ''), '\n', ''),1,50) as phones,source_id,created_at,updated_at from accountdetails where year(created_at) ='" + cmbYear.Text +"' limit 0,50000";
            DataTable dataTableRecYear = new DataTable();
            DataTable dataTablePayYear = new DataTable();
            logger.Log("Written Data To XML Document");
            SetText(">>Successfully connected to PRAZ PORTAL");
            SetText(">>Extracting Customervendor records from PRAZ PORTAL...");
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

            string conString = configdb;
            pi.WriteToXMLRecievables(dataTableRecYear, conString, sqlCmdCustomerVendorYear, xmlDocNameCustomers);
            pi.WriteToXMLPayables(dataTablePayYear, conString, sqlCmdCustomerVendorYear, xmlDocNameVendors);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //Fetch by Year
            SetText(">>Loading Customer vendor records to Palladium Accounting...");
            pi.PostToPalladiumRecievables("Customers.xml");
            pi.PostToPalladiumPayables("Vendors.xml");
            logger.Log(">>Pushed Customer vendor records  to palladium...");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DatabaseConfigurationwiz dbcon = new DatabaseConfigurationwiz();
            dbcon.ShowDialog();
        }
    }
}
