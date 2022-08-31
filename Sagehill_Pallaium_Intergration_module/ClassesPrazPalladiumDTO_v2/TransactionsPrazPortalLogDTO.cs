using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagehill_Pallaium_Intergration_module.ClassesPrazPalladiumDTO_v2
{
    class TransactionsPrazPortalLogDTO
    {
        public static void writeReceiptsFile(DataTable dataTable)
        {
            try
            {
               
                //Int64 x;
                try
                {
                    var _receipt_data = DateTime.Now.ToString("ddMMyyyy") + "_receipt_data.txt";
                    var CurrentDirectory = Directory.GetCurrentDirectory();
                    var pathdat = CurrentDirectory + @"\innoandbrendo\recordspulled\receipts\" + _receipt_data;

                    StreamWriter sw = new StreamWriter(pathdat, true, Encoding.ASCII);
                    sw.WriteLine("===============TODAY RECEIPTS RECORDS   DATE:  " + DateTime.Now.ToLongDateString() + "===========================  TIME:  " + DateTime.Now.ToLongTimeString() + "\n\n\n");

                    foreach (DataRow row in dataTable.Rows)
                    {
                        var regnumber = row["regnumber"].ToString();
                        var receiptnumber = row["receiptnumber"].ToString();
                        var created_at = row["receiptdate"].ToString();
                        var currency = row["name"].ToString();
                        var myTenderType = row["method"].ToString();
                        var lineTotal = row["amount"].ToString();

                        sw.WriteLine("RegNumber  " + regnumber + "  | Receipt Number   " + receiptnumber + "  | Created   " + created_at + "   |currency    " + currency + "  | Tender Type    " + myTenderType + "     |Amount   $" + lineTotal, Environment.NewLine);
                    }
                    sw.WriteLine("\n\n\n\n\n\n");
                    sw.WriteLine("\n\n\n\n\n\n");
                    sw.WriteLine("================================================END====================================\n\n\n\n\n\n");

                    //close the file
                    sw.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }


        public static void writeTenderInvoiceFile(DataTable dataTable)
        {
            try
            {


                //Open the File
                var _invoices_data = DateTime.Now.ToString("ddMMyyyy") + "_tender_invoices_data.txt";
                var CurrentDirectory = Directory.GetCurrentDirectory();
                var pathdat = CurrentDirectory + @"\innoandbrendo\recordspulled\invoices\" + _invoices_data;

                StreamWriter sw = new StreamWriter(pathdat, true, Encoding.ASCII);
                sw.WriteLine("===============TODAY TENDERS INVOICES RECORDS   DATE:  " + DateTime.Now.ToLongDateString() + "===========================  TIME:  " + DateTime.Now.ToLongTimeString() + "\n\n\n");

                foreach (DataRow row in dataTable.Rows)
                {
                    var invoice_number = row["invoicenumber"].ToString();
                    var currencycode = row["currency"].ToString();
                    var custNumber = row["regnumber"].ToString();
                    var total = row["amount"].ToString();
                    var reference = "TENDER INVOICE";
                    var docDate = row["invoicedate"].ToString();


                    sw.WriteLine("InvoiceNo  " + invoice_number + "  | DocDate   " + docDate + "  | Currency Code  " + currencycode + "  | Customer Number   " + custNumber + "   |Reference    " + reference + "     |total   $" + total , Environment.NewLine);
                }
                sw.WriteLine("\n\n\n\n\n\n");
                sw.WriteLine("\n\n\n\n\n\n");
                sw.WriteLine("=========================END==========================\n\n\n\n\n\n");

                sw.Close();
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.ToString());
            }

        }


        public static void writeSupplierInvoiceFile(DataTable dataTable)
        {
            try
            {


                //Open the File
                var _invoices_data = DateTime.Now.ToString("ddMMyyyy") + "_supplier_invoices_data.txt";
                var CurrentDirectory = Directory.GetCurrentDirectory();
                var pathdat = CurrentDirectory + @"\innoandbrendo\recordspulled\invoices\" + _invoices_data;

                StreamWriter sw = new StreamWriter(pathdat, true, Encoding.ASCII);
                sw.WriteLine("====TODAY SUPPLIER INVOICES RECORDS   DATE:  " + DateTime.Now.ToLongDateString() + "======  TIME:  " + DateTime.Now.ToLongTimeString() + "\n\n\n");

                foreach (DataRow row in dataTable.Rows)
                {
                    var invoice_number = row["invoicenumber"].ToString();
                    var currencycode = row["name"].ToString();
                    var custNumber = row["regnumber"].ToString();
                    var total = row["amount"].ToString();
                    var reference = "SUPPLIER INVOICE";
                    var docDate = row["invoicedate"].ToString();


                    sw.WriteLine("InvoiceNo  " + invoice_number + "  | DocDate   " + docDate + "  | Currency Code  " + currencycode + "  | Customer Number   " + custNumber + "   |Reference    " + reference + "     |total   $" + total , Environment.NewLine);
                }
                sw.WriteLine("\n\n\n\n\n\n");
                sw.WriteLine("\n\n\n\n\n\n");
                sw.WriteLine("=========================END==========================\n\n\n\n\n\n");

                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }



        public static void writeCustomerFile(DataTable dataTable)
        {
            try
            {

                var _customer_data = DateTime.Now.ToString("ddMMyyyy") + "_customer_data.txt";
                var CurrentDirectory = Directory.GetCurrentDirectory();
                var pathdat = CurrentDirectory + @"\innoandbrendo\recordspulled\customerandsuppliers\" + _customer_data;

                StreamWriter sw = new StreamWriter(pathdat, true, Encoding.ASCII);
                sw.WriteLine("===============TODAY CUSTOMERS RECORDS   DATE:  " + DateTime.Now.ToLongDateString() + "===========================  TIME:  " + DateTime.Now.ToLongTimeString() + "\n\n\n");

                foreach (DataRow row in dataTable.Rows)
                {
                    var vcnumber = row["regnumber"].ToString();
                    var name = row["name"].ToString();

                    sw.WriteLine("Reg Number  " + vcnumber + "  | Company Name   " + name , Environment.NewLine);
                }
                sw.WriteLine("\n\n\n\n\n\n");
                sw.WriteLine("\n\n\n\n\n\n");
                sw.WriteLine("=========================END===========================\n\n\n\n\n\n");


                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }





        public static void writeSupplierFile(DataTable dataTable)
        {
            try
            {


                //Open the File
                var _customer_data = DateTime.Now.ToString("ddMMyyyy") + "_supplier_data.txt";
                var CurrentDirectory = Directory.GetCurrentDirectory();
                var pathdat = CurrentDirectory + @"\innoandbrendo\recordspulled\customerandsuppliers\" + _customer_data;

                StreamWriter sw = new StreamWriter(pathdat, true, Encoding.ASCII);
                sw.WriteLine("===============TODAY SUPPLIERS RECORDS   DATE:  " + DateTime.Now.ToLongDateString() + "==================  TIME:  " + DateTime.Now.ToLongTimeString() + "\n\n\n");

                foreach (DataRow row in dataTable.Rows)
                {
                    var vcnumber = row["regnumber"].ToString();
                    var name = row["name"].ToString();

                    sw.WriteLine("Reg Number  " + vcnumber + "  | Company Name   " + name, Environment.NewLine);
                }
                sw.WriteLine("\n\n\n\n\n\n");
                sw.WriteLine("\n\n\n\n\n\n");
                sw.WriteLine("=======================================END====================================\n\n\n\n\n\n");


                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        

        public static void writeSupplierCustomerFile(DataTable dataTable)
        {
            try
            {


                //Open the File
                var _customer_data = DateTime.Now.ToString("ddMMyyyy") + "_supplier_customer_data.txt";
                var CurrentDirectory = Directory.GetCurrentDirectory();
                var pathdat = CurrentDirectory + @"\innoandbrendo\recordspulled\customerandsuppliers\" + _customer_data;

                StreamWriter sw = new StreamWriter(pathdat, true, Encoding.ASCII);
                sw.WriteLine("===============TODAY CUSTOMER RECORDS   DATE:  " + DateTime.Now.ToLongDateString() + "==================  TIME:  " + DateTime.Now.ToLongTimeString() + "\n\n\n");

                foreach (DataRow row in dataTable.Rows)
                {
                    var vcnumber = row["regnumber"].ToString();
                    var name = row["name"].ToString();

                    sw.WriteLine("Reg Number  " + vcnumber + "  | Company Name   " + name, Environment.NewLine);
                }
                sw.WriteLine("\n\n\n\n\n\n");
                sw.WriteLine("\n\n\n\n\n\n");
                sw.WriteLine("=======================================END====================================\n\n\n\n\n\n");


                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

    }
}
