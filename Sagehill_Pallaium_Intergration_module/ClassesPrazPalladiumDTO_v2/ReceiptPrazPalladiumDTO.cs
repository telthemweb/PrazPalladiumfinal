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
    class ReceiptPrazPalladiumDTO
    {
        //private String settingName = "TestSetting";
        PalladiumSoftware.Integration.Maintenance maintenance = new PalladiumSoftware.Integration.Maintenance();
        PalladiumSoftware.Integration.Documents documents = new PalladiumSoftware.Integration.Documents();
        PalladiumSoftware.Integration.Enquiries enquiries = new PalladiumSoftware.Integration.Enquiries();
        /*
        |=============================================================================
        |
        |                  GET ALL RECEIPT FROM PORTAL
        |
        |=============================================================================
        */


        public void getAllReceiptsFromPortal(string searchvalue)
        {
            try
            {

                string receiptsql = string.Empty;
                if (string.IsNullOrEmpty(searchvalue) && string.IsNullOrWhiteSpace(searchvalue))

                {
                     receiptsql = "SELECT concat('IN-',SUBSTR(invoicenumber,4)) as invoicenumber,receiptnumber,type,description,regnumber,method,name,receiptdate,amount FROM portal_receipts where monthname(receiptdate)=monthname(now()) and year(receiptdate)=year(now()) order by receiptdate desc";

                }
                else
                {
                    receiptsql = "SELECT concat('IN-',SUBSTR(invoicenumber,4)) as invoicenumber,receiptnumber,type,description,regnumber,method,name,receiptdate,amount FROM portal_receipts WHERE year(receiptdate) ='" + searchvalue + "'";
                }

                DataTable dt = new DataTable();
                dt = DatabasePrazPalladiumDTO.Retrieve(receiptsql);

                if (dt == null)
                {
                    var CurrentDirectory = Directory.GetCurrentDirectory();
                    var errorFileName = "sg_" + DateTime.Now.ToString("ddMMyyyy") + "_database_transaction_error.txt";
                    var erroFilePath = CurrentDirectory + @"/innoandbrendo/databaseerrorlogs/" + errorFileName;
                    using (StreamWriter writer = new StreamWriter(erroFilePath, true))
                    {
                        writer.WriteLine("===============TODAY RECEIPTS RECORDS   DATE:  " + DateTime.Now.ToLongDateString() + "===========================  TIME:  " + DateTime.Now.ToLongTimeString() + "\n\n\n");

                        writer.WriteLine("\n\n\n");
                        writer.WriteLine("=======================NO RECEIPTS===========================\n\n\n");

                        writer.WriteLine("\n\n\n");

                        writer.WriteLine("===============POWERED BY SAGEHILL DEVELOPERS ===========================\n\n\n");
                        writer.Close();
                    }
                }
                else
                {
                    //Static Function to write receipts xml 
                    ReceiptComponent.writeReceiptXml(dt);
                    TransactionsPrazPortalLogDTO.writeReceiptsFile(dt);
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
        |    To post to palladium  Receipts
        |
        |---------------------------------------------------------------------------------------
        */
        public void PostToPalladiumReceipts(string filename)
        {
            try
            {

                string xmlString = System.IO.File.ReadAllText(filename);
                string response = documents.ProcessReceipts("TestSetting", xmlString);
                Console.WriteLine(response);
                var CurrentDirectory = Directory.GetCurrentDirectory();
                var FileName = DateTime.Now.ToString("ddMMyyyy") + "_receipts_payload_log.txt";
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
                var errorFileName = DateTime.Now.ToString("ddMMyyyy") + "_receipts_error.txt";
                var erroFilePath = CurrentDirectory + @"/innoandbrendo/errorlogs/receipts/" + errorFileName;
                using (StreamWriter writer = new StreamWriter(erroFilePath, true))
                {
                    writer.WriteLine("===============TODAY ERROR DETAILS   DATE:  " +DateTime.Now.ToLongDateString()+"===========================  TIME:  "+ DateTime.Now.ToLongTimeString() + "\n\n\n");
                    writer.WriteLine(ex.Message);
                    writer.WriteLine("\n\n\n");
                    writer.WriteLine("===============ERROR DETAILS===========================\n\n\n");
                    writer.WriteLine(ex.StackTrace);
                    writer.WriteLine("\n\n\n");
                    writer.WriteLine("===============POWERED BY SAGEHILL DEVELOPERS ===========================\n\n\n");
                    writer.Close();
                }
            }

        }


    }
}
