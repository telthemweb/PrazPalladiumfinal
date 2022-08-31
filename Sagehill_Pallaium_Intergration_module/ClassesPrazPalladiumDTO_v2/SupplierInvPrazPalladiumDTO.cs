using Sagehill_Pallaium_Intergration_module.ClassesDb;
using Sagehill_Pallaium_Intergration_module.ClassesPrazPalladiumDTO_v2.WriteXML_V2;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagehill_Pallaium_Intergration_module.ClassesPrazPalladiumDTO_v2
{
    class SupplierInvPrazPalladiumDTO
    {

        //private String settingName = "TestSetting";
        PalladiumSoftware.Integration.Maintenance maintenance = new PalladiumSoftware.Integration.Maintenance();
        PalladiumSoftware.Integration.Documents documents = new PalladiumSoftware.Integration.Documents();
        PalladiumSoftware.Integration.Enquiries enquiries = new PalladiumSoftware.Integration.Enquiries();
        /*
        |=============================================================================
        |
        |                  GET ALL TENDER INVOICES FROM PORTAL
        |
        |=============================================================================
        */


        public void getAllSupplerInvoicesFromPortal(string searchvalue)
        {
            try
            {
                string supplierInvoicessql = string.Empty;
                if (string.IsNullOrEmpty(searchvalue) && string.IsNullOrWhiteSpace(searchvalue))

                {
                     supplierInvoicessql = "SELECT max(regnumber) AS regnumber,SUBSTR(invoicenumber,4) as invoicenumber,invoicenumber As newInvoice,max(code) AS code,max(name) AS name,max(year) AS year, sum(amount) as amount,max(invoicedate) AS invoicedate FROM supplier_invoices where monthname(invoicedate)=monthname(now()) && year(invoicedate)=year(NOW()) GROUP BY invoicenumber order by max(invoicedate) desc";

                }
                else
                {
                     supplierInvoicessql = "SELECT max(regnumber) AS regnumber,SUBSTR(invoicenumber,4) as invoicenumber,invoicenumber As newInvoice,max(code) AS code,max(name) AS name,max(year) AS year, sum(amount) as amount,max(invoicedate) AS invoicedate FROM supplier_invoices WHERE year(invoicedate) ='" + searchvalue + "' GROUP BY invoicenumber order by max(invoicedate) desc";
                }

                DataTable dt = new DataTable();
                dt = DatabasePrazPalladiumDTO.Retrieve(supplierInvoicessql);

                if (dt == null)
                {
                    Console.WriteLine("=================No Supplier Invoices====================>{*/\\*}");
                    var CurrentDirectory = Directory.GetCurrentDirectory();
                    var errorFileName = "sg_" + DateTime.Now.ToString("ddMMyyyy") + "_database_transaction_error.txt";
                    var erroFilePath = CurrentDirectory + @"/innoandbrendo/databaseerrorlogs/" + errorFileName;
                    using (StreamWriter writer = new StreamWriter(erroFilePath, true))
                    {
                        writer.WriteLine("===============TODAY SUPPLIERS INVOICES RECORDS   DATE:  " + DateTime.Now.ToLongDateString() + "===========================  TIME:  " + DateTime.Now.ToLongTimeString() + "\n\n\n");

                        writer.WriteLine("\n\n\n");
                        writer.WriteLine("=======================NO SUPPLIERS INVOICES===========================\n\n\n");

                        writer.WriteLine("\n\n\n");

                        writer.WriteLine("===============POWERED BY SAGEHILL DEVELOPERS ===========================\n\n\n");
                        writer.Close();
                    }
                }
                else
                {
                    //Static Function to write Tender Invoices 
                    SuppliernvoiceComponent.writeSupplierInvoiceXml(dt);
                    TransactionsPrazPortalLogDTO.writeSupplierInvoiceFile(dt);
                }
            }
            catch (Exception ex)
            {
                var CurrentDirectory = Directory.GetCurrentDirectory();
                var errorFileName = DateTime.Now.ToString("ddMMyyyy") + "_database_transaction_error.txt";
                var erroFilePath = CurrentDirectory + @"/innoandbrendo/databaseerrorlogs/" + errorFileName;
                using (StreamWriter writer = new StreamWriter(erroFilePath, true))
                {
                    writer.WriteLine("===============TODAY ERROR DETAILS   DATE:  " + DateTime.Now.ToLongDateString() + "===========================  TIME:  " + DateTime.Now.ToLongTimeString() + "\n\n\n");
                    writer.WriteLine(ex.Message);
                    writer.WriteLine("\n\n\n");
                    writer.WriteLine("=======================ERROR DETAILS===========================\n\n\n");
                    writer.WriteLine(ex.StackTrace);
                    writer.WriteLine("\n\n\n");
                    writer.WriteLine("===============POWERED BY SAGEHILL DEVELOPERS ===========================\n\n\n");
                    writer.Close();
                }
            }
        }




        /*
        |---------------------------------------------------------------------------------------
        |       
        |    To post to palladium  Sales Invoices
        |
        |---------------------------------------------------------------------------------------
        */
        public void PostToPalladiumSupplerInvoices(string filename)
        {
            try
            {

                string xmlString = File.ReadAllText(filename);
                string response = documents.ProcessSalesInvoices("TestSetting", xmlString);
                Console.WriteLine(response);
                var CurrentDirectory = Directory.GetCurrentDirectory();
                var FileName = DateTime.Now.ToString("ddMMyyyy") + "_SupplerInvoices_payload_log.txt";
                var FilePath = CurrentDirectory + @"/innoandbrendo/" + FileName;
                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    writer.WriteLine(response);
                    writer.Close();
                }

            }

            catch (Exception ex)
            {
                var CurrentDirectory = Directory.GetCurrentDirectory();
                var errorFileName = DateTime.Now.ToString("ddMMyyyy") + "_supplerInvoices_error.txt";
                var erroFilePath = CurrentDirectory + @"/innoandbrendo/errorlogs/supInvoices/" + errorFileName;
                using (StreamWriter writer = new StreamWriter(erroFilePath, true))
                {
                    writer.WriteLine("===============TODAY ERROR DETAILS   DATE:  " + DateTime.Now.ToLongDateString() + "===========================  TIME:  " + DateTime.Now.ToLongTimeString() + "\n\n\n");
                    writer.WriteLine(ex.Message);
                    writer.WriteLine("\n\n\n");
                    writer.WriteLine("=======================ERROR DETAILS===========================\n\n\n");
                    writer.WriteLine(ex.StackTrace);
                    writer.WriteLine("\n\n\n");
                    writer.WriteLine("===============POWERED BY SAGEHILL DEVELOPERS ===========================\n\n\n");
                    writer.Close();
                }
            }

        }



    }
}
