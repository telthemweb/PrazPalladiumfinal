using Sagehill_Pallaium_Intergration_module.ClassesPrazPalladiumDTO_v2;
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

namespace Sagehill_Pallaium_Intergration_module.PalladiumDataPusher_v2
{
    public partial class SagePostNow : Form
    {
        ReceiptPrazPalladiumDTO receipts = new ReceiptPrazPalladiumDTO();
        CustomerPrazPalladiumEntitiesDTO customer = new CustomerPrazPalladiumEntitiesDTO();
        SupplierAccountPrazPalladiumDTO supplier = new SupplierAccountPrazPalladiumDTO();
        SupplierInvPrazPalladiumDTO supplierInvoice = new SupplierInvPrazPalladiumDTO();
        TenderInvPrazPalladiumDTO tenderInvoice = new TenderInvPrazPalladiumDTO();
        public SagePostNow()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string message = "Are suew you want to exit?";
            string title = "Close Application";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void fyCustomers_Click(object sender, EventArgs e)
        {
           
            customer.getAllCustomerEntitesFromPortal(cmbYear.Text.Trim());
        }

        private void fySuppliers_Click(object sender, EventArgs e)
        {
            
            supplier.getAllSupplierAccountFromPortal(cmbYear.Text.Trim());
        }

        private void fySupInvoices_Click(object sender, EventArgs e)
        {
            
            supplierInvoice.getAllSupplerInvoicesFromPortal(cmbYear.Text.Trim());
        }

        private void fyTendInvoices_Click(object sender, EventArgs e)
        {
            tenderInvoice.getAllTenderInvoicesFromPortal(cmbYear.Text.Trim());
        }

        private void cmdCustomers_Click(object sender, EventArgs e)
        {
            customer.getAllCustomerEntitesFromPortal("");
        }

        private void cmdSupplers_Click(object sender, EventArgs e)
        {
            supplier.getAllSupplierAccountFromPortal("");
        }

        private void cmdSupInvoices_Click(object sender, EventArgs e)
        {
            supplierInvoice.getAllSupplerInvoicesFromPortal("");
        }

        private void cmdTendInvoices_Click(object sender, EventArgs e)
        {
            tenderInvoice.getAllTenderInvoicesFromPortal("");
        }

        private void fyReceipts_Click(object sender, EventArgs e)
        {
            
            receipts.getAllReceiptsFromPortal(cmbYear.Text.Trim());
        }

        private void cmdReceipts_Click(object sender, EventArgs e)
        {
            
            receipts.getAllReceiptsFromPortal("");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DatabaseConfigurationwiz dbcon = new DatabaseConfigurationwiz();
            dbcon.ShowDialog();
        }

        private void SagePostNow_Load(object sender, EventArgs e)
        {

        }

        private void fyPostTransactions_Click(object sender, EventArgs e)
        {
            

        }

        private void cmdPostTransactions_Click(object sender, EventArgs e)
        {
            //post all

            /*
        |---------------------------------------------------------------------------------------
        |       
        |           Post all Palladium 
        |
        |---------------------------------------------------------------------------------------
        */

            var xmlCustomerentities = @"palladium/customers.xml";
            var xmlvendor = @"palladium/vendors.xml";
            var xmlsupplerInvoice = @"palladium/SupplierInvoices.xml";
            var xmlTenderInvoices = @"palladium/TenderInvoices.xml";
            var xmlReceipts = @"palladium/Receipts.xml";

            customer.PostAllCustomerEntitestoPalladium(xmlCustomerentities);
            supplier.PostToPalladiumSupplierAccount(xmlvendor);
            supplierInvoice.PostToPalladiumSupplerInvoices(xmlsupplerInvoice);
            tenderInvoice.PostToPalladiumTenderInvoice(xmlTenderInvoices);
            receipts.PostToPalladiumReceipts(xmlReceipts);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SettingsPanel sp = new SettingsPanel();
            sp.ShowDialog();
        }
    }
}
