using Sagehill_Pallaium_Intergration_module.ClassesPrazPalladiumDTO_v2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sagehill_Pallaium_Intergration_module.PalladiumDataPusher_v2
{
    public partial class AsynDataPusher_v2 : Form
    {
        SchedularTimerPrazPalladiumDTO schedularsetting = new SchedularTimerPrazPalladiumDTO();
        ReceiptPrazPalladiumDTO receipts = new ReceiptPrazPalladiumDTO();
        CustomerPrazPalladiumEntitiesDTO customer = new CustomerPrazPalladiumEntitiesDTO();
        SupplierAccountPrazPalladiumDTO supplier = new SupplierAccountPrazPalladiumDTO();
        SupplierInvPrazPalladiumDTO supplierInvoice = new SupplierInvPrazPalladiumDTO();
        TenderInvPrazPalladiumDTO tenderInvoice = new TenderInvPrazPalladiumDTO();

        public AsynDataPusher_v2()
        {
            InitializeComponent();
        }

        public void MyTimer(object sender, System.Timers.ElapsedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SettingsPanel sp = new SettingsPanel();
            sp.ShowDialog();
        }

        private void AsynDataPusher_v2_Load(object sender, EventArgs e)
        {
            tmTelthemweb.Enabled = true;
            tmTelthemweb.Start();

            var h = int.Parse(schedularsetting.GetScheduleString("sc_hours"));
            var m = int.Parse(schedularsetting.GetScheduleString("sc_minutes"));
            var s = int.Parse(schedularsetting.GetScheduleString("sc_secs"));

            int hr, min, sc;
            if (string.IsNullOrEmpty(h.ToString()) &&  string.IsNullOrEmpty(m.ToString()) && string.IsNullOrEmpty(s.ToString()))
            {
                hr = 0;
                min = 0;
                sc = 0;
            }
            else
            {
                hr = h;
                min = m;
                sc = s;
            }

            //add task schedule 

            //TaskSchedularPrazPalladiumDTO.IntervalInSeconds(hr, min, sc, () =>
            // {
            //     PullDataFromPortal();
            //     //PostDataFromPortal();

            // });

            TaskSchedularPrazPalladiumDTO.IntervalInHours(hr, min, sc, () =>
            {
                PullDataFromPortal();
                //Thread.Sleep(1000);
                PostDataFromPortal();

            });
        }


        //pull data from Portal
        private void PullDataFromPortal()
        {

            customer.getAllCustomerEntitesFromPortal("");
            supplier.getAllSupplierAccountFromPortal("");
            supplier.getAllCustomerAccountFromPortal("");



            supplierInvoice.getAllSupplerInvoicesFromPortal("");
            tenderInvoice.getAllTenderInvoicesFromPortal("");
            


            receipts.getAllReceiptsFromPortal("");
           

        }

        //post data to palladium
        private void PostDataFromPortal()
        {
            var xmlCustomerentities = @"palladium/customers.xml";
            var xmlvendorCustomerentities = @"palladium/vendor_customer.xml";
            var xmlvendor = @"palladium/vendors.xml";
            var xmlsupplerInvoice = @"palladium/SupplierInvoices.xml";
            var xmlTenderInvoices = @"palladium/TenderInvoices.xml";
            var xmlReceipts = @"palladium/Receipts.xml";

            customer.PostAllCustomerEntitestoPalladium(xmlCustomerentities);
            customer.PostAllSuppliersCustomerEntitestoPalladium(xmlvendorCustomerentities);
            


            supplier.PostToPalladiumSupplierAccount(xmlvendor);
            

            supplierInvoice.PostToPalladiumSupplerInvoices(xmlsupplerInvoice);
            

            tenderInvoice.PostToPalladiumTenderInvoice(xmlTenderInvoices);
            

            receipts.PostToPalladiumReceipts(xmlReceipts);


        }



        private void button1_Click(object sender, EventArgs e)
        {
            string message = "Are sure you want to exit this system.?";
            string title = "Sagehill Business Solutions";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void tmTelthemweb_Tick(object sender, EventArgs e)
        {
            labelTimer.Text = DateTime.Now.ToString("hh:mm:ss");
        }
    }
}
