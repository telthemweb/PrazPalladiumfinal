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
    class SupplierAccountPrazPalladiumDTO
    {

       // private String settingName = "TestSetting";
        PalladiumSoftware.Integration.Maintenance maintenance = new PalladiumSoftware.Integration.Maintenance();
        PalladiumSoftware.Integration.Documents documents = new PalladiumSoftware.Integration.Documents();
        PalladiumSoftware.Integration.Enquiries enquiries = new PalladiumSoftware.Integration.Enquiries();
        public void getAllSupplierAccountFromPortal(string searchvalue)
        {
            try
            {
                string customerEntitesssql = string.Empty;
                if (string.IsNullOrEmpty(searchvalue) && string.IsNullOrWhiteSpace(searchvalue))

                {
                    customerEntitesssql = "SELECT name,regnumber,locality,city,province,district,sector,country,created_at FROM portal_account WHERE monthname(created_at)=monthname(now()) && year(created_at)=year(NOW()) order by created_at DESC";

                }
                else
                {

                    customerEntitesssql = "SELECT name,regnumber,locality,city,province,district,sector,country,created_at FROM portal_account WHERE year(created_at) ='" + searchvalue + "'";
                }

                DataTable dt = new DataTable();
                dt = DatabasePrazPalladiumDTO.Retrieve(customerEntitesssql);

                if (dt == null)
                {
                    Console.WriteLine("=================No Suppliers====================>{*/\\*}");

                    var CurrentDirectory = Directory.GetCurrentDirectory();
                    var errorFileName = "sg_" + DateTime.Now.ToString("ddMMyyyy") + "_database_transaction_error.txt";
                    var erroFilePath = CurrentDirectory + @"/innoandbrendo/databaseerrorlogs/" + errorFileName;
                    using (StreamWriter writer = new StreamWriter(erroFilePath, true))
                    {
                        writer.WriteLine("===============TODAY SUPPLIERS RECORDS   DATE:  " + DateTime.Now.ToLongDateString() + "===========================  TIME:  " + DateTime.Now.ToLongTimeString() + "\n\n\n");

                        writer.WriteLine("\n\n\n");
                        writer.WriteLine("=======================NO SUPPLIERSS===========================\n\n\n");

                        writer.WriteLine("\n\n\n");

                        writer.WriteLine("===============POWERED BY SAGEHILL DEVELOPERS ===========================\n\n\n");
                        writer.Close();
                    }
                }
                else
                {
                    //Static Function to write Tender Invoices 
                    SupplierAccountComponent.writeSupplierAccountstXml(dt);
                    TransactionsPrazPortalLogDTO.writeSupplierFile(dt);
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


        //Get all Customers
        public void getAllCustomerAccountFromPortal(string searchvalue)
        {
            try
            {
                string customerEntitesssql = string.Empty;
                if (string.IsNullOrEmpty(searchvalue) && string.IsNullOrWhiteSpace(searchvalue))

                {
                    customerEntitesssql = "SELECT name,regnumber,locality,city,province,district,sector,country,created_at FROM portal_account WHERE monthname(created_at)=monthname(now()) && year(created_at)=year(NOW()) order by created_at DESC";

                }
                else
                {

                    customerEntitesssql = "SELECT name,regnumber,locality,city,province,district,sector,country,created_at FROM portal_account WHERE year(created_at) ='" + searchvalue + "'";
                }

                DataTable dt = new DataTable();
                dt = DatabasePrazPalladiumDTO.Retrieve(customerEntitesssql);

                if (dt == null)
                {
                    Console.WriteLine("=================No Suppliers====================>{*/\\*}");

                    var CurrentDirectory = Directory.GetCurrentDirectory();
                    var errorFileName = "sg_" + DateTime.Now.ToString("ddMMyyyy") + "_database_transaction_error.txt";
                    var erroFilePath = CurrentDirectory + @"/innoandbrendo/databaseerrorlogs/" + errorFileName;
                    using (StreamWriter writer = new StreamWriter(erroFilePath, true))
                    {
                        writer.WriteLine("===============TODAY CUSTOMERS RECORDS   DATE:  " + DateTime.Now.ToLongDateString() + "===========================  TIME:  " + DateTime.Now.ToLongTimeString() + "\n\n\n");

                        writer.WriteLine("\n\n\n");
                        writer.WriteLine("=======================NO CUSTOMERS===========================\n\n\n");

                        writer.WriteLine("\n\n\n");

                        writer.WriteLine("===============POWERED BY SAGEHILL DEVELOPERS ===========================\n\n\n");
                        writer.Close();
                    }
                }
                else
                {
                   
                    
                    SupplierAccountComponent.writeCustAccountstXml(dt);


                    TransactionsPrazPortalLogDTO.writeSupplierCustomerFile(dt);
                }
            }
            catch (Exception ex)
            {
                var CurrentDirectory = Directory.GetCurrentDirectory();
                var errorFileName = DateTime.Now.ToString("ddMMyyyy") + "_databases_transaction_error.txt";
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
        |    To post to palladium  Vendors
        |
        |---------------------------------------------------------------------------------------
        */
        public void PostToPalladiumSupplierAccount(string filename)
        {
            try
            {
                string xmlString = File.ReadAllText(filename);
                string response = maintenance.ProcessVendors("TestSetting", xmlString);
                var CurrentDirectory = Directory.GetCurrentDirectory();
                var FileName = DateTime.Now.ToString("ddMMyyyy") + "_vendor_payload_log.txt";
                var FilePath = CurrentDirectory + @"/innoandbrendo/" + FileName;
                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    writer.WriteLine(response);
                }
            }
            catch (Exception ex)
            {
                var CurrentDirectory = Directory.GetCurrentDirectory();
                var errorFileName = DateTime.Now.ToString("ddMMyyyy") + "_vendor_error.txt";
                var erroFilePath = CurrentDirectory + @"/innoandbrendo/errorlogs/supplers/" + errorFileName;
                using (StreamWriter writer = new StreamWriter(erroFilePath, true))
                {
                    writer.WriteLine("===============TODAY ERROR DETAILS   DATE:  " + DateTime.Now.ToLongDateString() + "===========================  TIME:  " + DateTime.Now.ToLongTimeString() + "\n\n\n");
                    writer.WriteLine(ex.Message);
                    writer.WriteLine("\n\n\n");
                    writer.WriteLine("=======================ERROR DETAILS===========================\n\n\n");
                    writer.WriteLine(ex.StackTrace);
                    writer.WriteLine("\n\n\n");
                    writer.WriteLine("===============POWERED BY SAGEHILL DEVELOPERS ===========================\n\n\n");

                }
            }
        }

    }
}
