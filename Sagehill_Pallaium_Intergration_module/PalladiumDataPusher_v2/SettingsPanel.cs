using Microsoft.Win32;
using Sagehill_Pallaium_Intergration_module.DbConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sagehill_Pallaium_Intergration_module.PalladiumDataPusher_v2
{
    public partial class SettingsPanel : Form
    {
        DatabaseConfigurationwiz dbcon = new DatabaseConfigurationwiz();
        public SettingsPanel()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
            dbcon.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdGrantPermision_CheckedChanged(object sender, EventArgs e)
        {
            }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void chRemovePermission_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey reg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\windows\\CurrentVersion\\Run", true);
            reg.DeleteValue("Palladium_integration for Sagehill", false);
            MessageBox.Show("App Permission has been removed from the registry", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void rdGrantPermision_CheckedChanged_1(object sender, EventArgs e)
        {
            RegistryKey reg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\windows\\CurrentVersion\\Run", true);
            reg.SetValue("Palladium_integration for Sagehill", Application.ExecutablePath.ToString());
            MessageBox.Show("App Permission has been granted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void ckspvlogfile_CheckedChanged(object sender, EventArgs e)
        {
            //get supplier or vendors
            var supplier = DateTime.Now.ToString("ddMMyyyy") + "_vendors_transaction.txt";
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var pathdat = CurrentDirectory + @"\innoandbrendo\portaldatatransactions\customersuppliers\" + supplier;
            Process.Start(pathdat);
        }

        private void ckCustomerententies_CheckedChanged(object sender, EventArgs e)
        {
            var customerer = DateTime.Now.ToString("ddMMyyyy") + "_custumer_transaction.txt";
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var pathdat = CurrentDirectory + @"\innoandbrendo\portaldatatransactions\customersuppliers\" + customerer;
            Process.Start(pathdat);
        }

        private void ckSupplInvoislog_CheckedChanged(object sender, EventArgs e)
        {
            var supplierinvoices = DateTime.Now.ToString("ddMMyyyy") + "_supplierinvoices_transaction.txt";
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var pathdat = CurrentDirectory + @"\innoandbrendo\portaldatatransactions\invoices\" + supplierinvoices;
            Process.Start(pathdat);
        }

        private void ckTenderInvoicelog_CheckedChanged(object sender, EventArgs e)
        {
            var tenderinvoices = DateTime.Now.ToString("ddMMyyyy") + "_tenderinvoices_transaction.txt";
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var pathdat = CurrentDirectory + @"\innoandbrendo\portaldatatransactions\invoices\" + tenderinvoices;
            Process.Start(pathdat);
        }

        private void ckReceiptslog_CheckedChanged(object sender, EventArgs e)
        {
            var receipts = DateTime.Now.ToString("ddMMyyyy") + "_receipts_transaction.txt";
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var pathdat = CurrentDirectory + @"\innoandbrendo\portaldatatransactions\receipt\" + receipts;
            Process.Start(pathdat);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            //get supplier or vendors
            var supplier = DateTime.Now.ToString("ddMMyyyy") + "_vendor_payload_log.txt";
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var pathdat = CurrentDirectory + @"\innoandbrendo\" + supplier;
            Process.Start(pathdat);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            
            var customer = DateTime.Now.ToString("ddMMyyyy") + "_customer_payload_log.txt";
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var pathdat = CurrentDirectory + @"\innoandbrendo\" + customer;
            Process.Start(pathdat);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var receipts = DateTime.Now.ToString("ddMMyyyy") + "_receipt_payload_log.txt";
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var pathdat = CurrentDirectory + @"\innoandbrendo\" + receipts;
            Process.Start(pathdat);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            var SupplerInvoices = DateTime.Now.ToString("ddMMyyyy") + "_SupplerInvoices_payload_log.txt";
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var pathdat = CurrentDirectory + @"\innoandbrendo\" + SupplerInvoices;
            Process.Start(pathdat);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            var _tenderInvoice = DateTime.Now.ToString("ddMMyyyy") + "_tenderInvoice_payload_log.txt";
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var pathdat = CurrentDirectory + @"\innoandbrendo\" + _tenderInvoice;
            Process.Start(pathdat);
        }

        private void ckSystemlogs_CheckedChanged(object sender, EventArgs e)
        {
            var SupplerInvoices = DateTime.Now.ToString("ddMMyyyy") + "_database_transaction_error.txt";
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var pathdat = CurrentDirectory + @"\innoandbrendo\databaseerrorlogs\" + SupplerInvoices;
            Process.Start(pathdat);
        }
    }
}
