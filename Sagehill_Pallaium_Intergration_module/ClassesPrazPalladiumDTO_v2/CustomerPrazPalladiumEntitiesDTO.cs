using Sagehill_Pallaium_Intergration_module.ClassesDb;
using Sagehill_Pallaium_Intergration_module.ClassesPrazPalladiumDTO_v2.WriteXML_V2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagehill_Pallaium_Intergration_module.ClassesPrazPalladiumDTO_v2
{
    class CustomerPrazPalladiumEntitiesDTO
    {
        /*
        |=============================================================================
        |
        |                  GET ALL CUSTOMERS FROM PORTAL
        |
        |=============================================================================
        */
        //private String settingName = "TestSetting";
        PalladiumSoftware.Integration.Maintenance maintenance = new PalladiumSoftware.Integration.Maintenance();
        PalladiumSoftware.Integration.Documents documents = new PalladiumSoftware.Integration.Documents();
        PalladiumSoftware.Integration.Enquiries enquiries = new PalladiumSoftware.Integration.Enquiries();
        


        public void getAllCustomerEntitesFromPortal(string searchvalue)
        {
            try
            {
                string customerEntitesssql = string.Empty;
                if (string.IsNullOrEmpty(searchvalue) && string.IsNullOrWhiteSpace(searchvalue))
                
                {
                    customerEntitesssql = "SELECT name,regnumber,slug,city,province,district,sector,posted,creator,created_at FROM portal_entities WHERE monthname(created_at)=monthname(now()) && year(created_at)=year(NOW()) order by created_at DESC";

                }
                else
                {

                        customerEntitesssql = "SELECT name,regnumber,slug,city,province,district,sector,posted,creator,created_at FROM portal_entities WHERE year(created_at) ='" + searchvalue + "'"; 
                }

                DataTable dt = new DataTable();
               
                dt = DatabasePrazPalladiumDTO.Retrieve(customerEntitesssql);

                if (dt == null)
                {
                    Console.WriteLine("=================No Customers====================>{*/\\*}");
                    var CurrentDirectory = Directory.GetCurrentDirectory();
                    var errorFileName = "sg_" + DateTime.Now.ToString("ddMMyyyy") + "_database_transaction_error.txt";
                    var erroFilePath = CurrentDirectory + @"/innoandbrendo/databaseerrorlogs/" + errorFileName;
                    using (StreamWriter writer = new StreamWriter(erroFilePath, true))
                    {
                        writer.WriteLine("===============TODAY CUSTOMER RECORDS   DATE:  " + DateTime.Now.ToLongDateString() + "===========================  TIME:  " + DateTime.Now.ToLongTimeString() + "\n\n\n");
                        
                        writer.WriteLine("\n\n\n");
                        writer.WriteLine("=======================NO CUSTOMERS===========================\n\n\n");

                        writer.WriteLine("\n\n\n");

                        writer.WriteLine("===============POWERED BY SAGEHILL DEVELOPERS ===========================\n\n\n");
                        writer.Close();
                    }
                }
                else
                {
                    //Static Function to write Tender Invoices 
                    CustomerEntitiesComponent.writeCutomerEntitiestXml(dt);
                    TransactionsPrazPortalLogDTO.writeCustomerFile(dt);
                }
            }
            catch (Exception ex)
            {
                var CurrentDirectory = Directory.GetCurrentDirectory();
                var errorFileName = "sg_"+DateTime.Now.ToString("ddMMyyyy") + "_database_transaction_error.txt";
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
        |=============================================================================
        |
        |                  POST ALL CUSTOMERS
        |
        |=============================================================================
        */

        public void PostAllCustomerEntitestoPalladium(string filename)
        {
            try
            {

                string xmlString = File.ReadAllText(filename);
                string response = maintenance.ProcessCustomers("TestSetting", xmlString);
                Console.WriteLine(response);
                var CurrentDirectory = Directory.GetCurrentDirectory();
                var FileName = DateTime.Now.ToString("ddMMyyyy") + "_customers_payload_log.txt";
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
                var errorFileName = DateTime.Now.ToString("ddMMyyyy") + "_customer_error_log.txt";
                var erroFilePath = CurrentDirectory + @"/innoandbrendo/errorlogs/customers/" + errorFileName;
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


        public void PostAllSuppliersCustomerEntitestoPalladium(string filename)
        {
            try
            {

                string xmlString = File.ReadAllText(filename);
                string response = maintenance.ProcessCustomers("TestSetting", xmlString);
                Console.WriteLine(response);
                var CurrentDirectory = Directory.GetCurrentDirectory();
                var FileName = DateTime.Now.ToString("ddMMyyyy") + "_vendor_customers_payload_log.txt";
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
                var errorFileName = DateTime.Now.ToString("ddMMyyyy") + "_vendor_customer_error_log.txt";
                var erroFilePath = CurrentDirectory + @"/innoandbrendo/errorlogs/customers/" + errorFileName;
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
