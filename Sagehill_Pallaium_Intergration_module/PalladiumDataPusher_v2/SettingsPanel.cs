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
            MessageBox.Show("App Permission has been removed from the registry", "Sagehill Business Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void rdGrantPermision_CheckedChanged_1(object sender, EventArgs e)
        {
            RegistryKey reg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\windows\\CurrentVersion\\Run", true);
            reg.SetValue("Palladium_integration for Sagehill", Application.ExecutablePath.ToString());
            MessageBox.Show("App Permission has been granted successfully!", "Sagehill Business Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void ckspvlogfile_CheckedChanged(object sender, EventArgs e)
        {
            //get supplier or vendors
            var supplier = DateTime.Now.ToString("ddMMyyyy") + "_vendors_transaction.txt";
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var pathdat = CurrentDirectory + @"\innoandbrendo\portaldatatransactions\customersuppliers\" + supplier;
            if (File.Exists(pathdat))
            {
                Process.Start(pathdat);
            }
            else
            {
                string message = "No file found";
                string title = "Sagehill Business Solutions";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);

            }
        }

        private void ckCustomerententies_CheckedChanged(object sender, EventArgs e)
        {
            var customerer = DateTime.Now.ToString("ddMMyyyy") + "_custumer_transaction.txt";
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var pathdat = CurrentDirectory + @"\innoandbrendo\portaldatatransactions\customersuppliers\" + customerer;
            if (File.Exists(pathdat))
            {
                Process.Start(pathdat);
            }
            else
            {
                string message = "No file found";
                string title = "Sagehill Business Solutions";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);

            }
        }

        private void ckSupplInvoislog_CheckedChanged(object sender, EventArgs e)
        {
            var supplierinvoices = DateTime.Now.ToString("ddMMyyyy") + "_supplierinvoices_transaction.txt";
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var pathdat = CurrentDirectory + @"\innoandbrendo\portaldatatransactions\invoices\" + supplierinvoices;
            if (File.Exists(pathdat))
            {
                Process.Start(pathdat);
            }
            else
            {
                string message = "No file found";
                string title = "Sagehill Business Solutions";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);

            }
        }

        private void ckTenderInvoicelog_CheckedChanged(object sender, EventArgs e)
        {
            var tenderinvoices = DateTime.Now.ToString("ddMMyyyy") + "_tenderinvoices_transaction.txt";
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var pathdat = CurrentDirectory + @"\innoandbrendo\portaldatatransactions\invoices\" + tenderinvoices;
            if (File.Exists(pathdat))
            {
                Process.Start(pathdat);
            }
            else
            {
                string message = "No file found";
                string title = "Sagehill Business Solutions";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);

            }
        }

        private void ckReceiptslog_CheckedChanged(object sender, EventArgs e)
        {
            var receipts = DateTime.Now.ToString("ddMMyyyy") + "_receipts_transaction.txt";
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var pathdat = CurrentDirectory + @"\innoandbrendo\portaldatatransactions\receipt\" + receipts;
            if (File.Exists(pathdat))
            {
                Process.Start(pathdat);
            }
            else
            {
                string message = "No file found";
                string title = "Sagehill Business Solutions";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);

            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            //get supplier or vendors
            var supplier = DateTime.Now.ToString("ddMMyyyy") + "_vendor_payload_log.txt";
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var pathdat = CurrentDirectory + @"\innoandbrendo\" + supplier;
            if (File.Exists(pathdat))
            {
                Process.Start(pathdat);
            }
            else
            {
                string message = "No file found";
                string title = "Sagehill Business Solutions";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);
                
            }
            
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            
            var customer = DateTime.Now.ToString("ddMMyyyy") + "_customer_payload_log.txt";
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var pathdat = CurrentDirectory + @"\innoandbrendo\" + customer;
            if (File.Exists(pathdat))
            {
                Process.Start(pathdat);
            }
            else
            {
                string message = "No file found";
                string title = "Sagehill Business Solutions";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var receipts = DateTime.Now.ToString("ddMMyyyy") + "_receipt_payload_log.txt";
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var pathdat = CurrentDirectory + @"\innoandbrendo\" + receipts;
            if (File.Exists(pathdat))
            {
                Process.Start(pathdat);
            }
            else
            {
                string message = "No file found";
                string title = "Sagehill Business Solutions";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);

            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            var SupplerInvoices = DateTime.Now.ToString("ddMMyyyy") + "_SupplerInvoices_payload_log.txt";
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var pathdat = CurrentDirectory + @"\innoandbrendo\" + SupplerInvoices;
            if (File.Exists(pathdat))
            {
                Process.Start(pathdat);
            }
            else
            {
                string message = "No file found";
                string title = "Sagehill Business Solutions";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            var _tenderInvoice = DateTime.Now.ToString("ddMMyyyy") + "_tenderInvoice_payload_log.txt";
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var pathdat = CurrentDirectory + @"\innoandbrendo\" + _tenderInvoice;
            if (File.Exists(pathdat))
            {
                Process.Start(pathdat);
            }
            else
            {
                string message = "No file found";
                string title = "Sagehill Business Solutions";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);

            }
        }

        private void ckSystemlogs_CheckedChanged(object sender, EventArgs e)
        {
            var SupplerInvoices = DateTime.Now.ToString("ddMMyyyy") + "_database_transaction_error.txt";
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var pathdat = CurrentDirectory + @"\innoandbrendo\databaseerrorlogs\" + SupplerInvoices;
            if (File.Exists(pathdat))
            {
                Process.Start(pathdat);
            }
            else
            {
                string message = "No file found";
                string title = "Sagehill Business Solutions";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);

            }
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            TimerSchedular ts = new TimerSchedular();
            ts.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SagePostNow sd = new SagePostNow();
            sd.ShowDialog();
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            //payload
            var supplier = DateTime.Now.ToString("ddMMyyyy") + "_supplier_data.txt";
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var pathdat = CurrentDirectory + @"\innoandbrendo\recordspulled\customerandsuppliers\" + supplier;
            if (File.Exists(pathdat))
            {
                Process.Start(pathdat);
            }
            else
            {
                string message = "No file found";
                string title = "Sagehill Business Solutions";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);

            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            //payload
            var customerer = DateTime.Now.ToString("ddMMyyyy") + "_customer_data.txt";
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var pathdat = CurrentDirectory + @"\innoandbrendo\recordspulled\customerandsuppliers\" + customerer;
            if (File.Exists(pathdat))
            {
                Process.Start(pathdat);
            }
            else
            {
                string message = "No file found";
                string title = "Sagehill Business Solutions";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);

            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            var receipts = DateTime.Now.ToString("ddMMyyyy") + "_receipt_data.txt";
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var pathdat = CurrentDirectory + @"\innoandbrendo\recordspulled\receipts\" + receipts;
            if (File.Exists(pathdat))
            {
                Process.Start(pathdat);
            }
            else
            {
                string message = "No file found";
                string title = "Sagehill Business Solutions";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);

            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            //payload
            var supplierinvoices = DateTime.Now.ToString("ddMMyyyy") + "_supplier_invoices_data.txt";
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var pathdat = CurrentDirectory + @"\innoandbrendo\recordspulled\invoices\" + supplierinvoices;
            if (File.Exists(pathdat))
            {
                Process.Start(pathdat);
            }
            else
            {
                string message = "No file found";
                string title = "Sagehill Business Solutions";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);

            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            //payload
            var tenderinvoices = DateTime.Now.ToString("ddMMyyyy") + "_tender_invoices_data.txt";
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var pathdat = CurrentDirectory + @"\innoandbrendo\recordspulled\invoices\" + tenderinvoices;
            if (File.Exists(pathdat))
            {
                Process.Start(pathdat);
            }
            else
            {
                string message = "No file found";
                string title = "Sagehill Business Solutions";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);

            }
        }
    }
}
