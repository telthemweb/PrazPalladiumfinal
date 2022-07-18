using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data;
using MySql.Data.MySqlClient;
using System.Xml.Linq;
using System.Windows.Forms;
using System.IO;

namespace Sagehill_Pallaium_Intergration_module
{
    public class PalladiumIntergrationClass

    {

        Logger logger = new Logger();
        PalladiumSoftware.Integration.Maintenance maintenance = new PalladiumSoftware.Integration.Maintenance();
        PalladiumSoftware.Integration.Documents documents = new PalladiumSoftware.Integration.Documents();
        string settingName = "TestSetting";
        //TestSetting

        public void WriteXMLCustom(DataTable dataTable, string xmlDocName)
        {
            //160-50 =110-20 =90 -34 
        }

        public static bool CheckInvoiceRecordExist(string str)
        {
            try
            {
                string conStringInner = @"server=10.0.0.12;userid=palladium;password=palladium2021@;database=palladium;Connection Timeout=600";

               
                string sqlcmd = "select invoice_number from invoices where invoice_number ='" + str + "' && monthname(updated_at)=monthname(now()) && year(updated_at)=year(now()) order by updated_at desc";
                MysqlConnectionClass mysqlcon = new MysqlConnectionClass();
                DataTable dt = new DataTable();
                dt = mysqlcon.ConnectAndQuery(conStringInner, sqlcmd);

                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        //method to write data from database to xml document
        public void WriteToXMLRecievables(DataTable dataTable, string conString, string sqlCmd, string xmlDocName)
        {
            try
            {
                MysqlConnectionClass mysqlcon = new MysqlConnectionClass();
                dataTable = mysqlcon.ConnectAndQuery(conString, sqlCmd);

                XmlDocument doc = new XmlDocument();
                //static nodes declation
                var declaration = doc.CreateXmlDeclaration("1.0", "utf-8", "yes");
                var customers = doc.CreateElement("customers");
                doc.AppendChild(declaration);
                doc.AppendChild(customers);

                foreach (DataRow row in dataTable.Rows)
                {
                    //for (int i = 0; i <=5; i++)
                    {
                        string emailValue = row["emails"].ToString().Trim();
                        string phonesValue = row["phones"].ToString().Trim();
                        string stripedEmail = "";

                        string stripedPhones = "";


                        //=================================stripe Phones==========================================

                        int phoneswithCommas = phonesValue.IndexOf(",");
                        int phonesswithsemcolon = phonesValue.IndexOf(";");
                        int phonesswithforwardslash = phonesValue.IndexOf("/");
                        int phonesswithat = phonesValue.IndexOf("@");
                        if (phoneswithCommas > 0)
                        {
                            stripedPhones = phonesValue.Substring(0, phoneswithCommas);
                        }
                        else if (phonesswithsemcolon > 0)
                        {
                            stripedPhones = phonesValue.Substring(0, phonesswithsemcolon);
                        }
                        else if (phonesswithforwardslash > 0)
                        {
                            stripedPhones = phonesValue.Substring(0, phonesswithforwardslash);
                        }
                        else if (phonesswithat > 0)
                        {
                            stripedPhones = phonesValue.Substring(0, phonesswithat);
                        }
                        else
                        {
                            stripedPhones = phonesValue.ToString();

                        }


                        //===============================Stripe Emails============================================
                        int emailswithCommas = emailValue.IndexOf(",");
                        int emailswithsemcolon = emailValue.IndexOf(";");
                        int emailswithforwardslash = emailValue.IndexOf("/");
                        if (emailswithCommas > 0)
                        {
                            stripedEmail = emailValue.Substring(0, emailswithCommas);
                        }
                        else if (emailswithsemcolon > 0)
                        {
                            stripedEmail = emailValue.Substring(0, emailswithsemcolon);
                        }

                        else if (emailswithforwardslash > 0)
                        {
                            stripedEmail = emailValue.Substring(0, emailswithforwardslash);
                        }
                        else
                        {
                            stripedEmail = emailValue.ToString();
                        }

                        //declaration of dynamic xml nodes/elements
                        var customer = doc.CreateElement("customer");
                        var number = doc.CreateElement("number");
                        var name = doc.CreateElement("name");
                        var phone = doc.CreateElement("phone");
                        var cell = doc.CreateElement("cell");
                        var email = doc.CreateElement("email");
                        var street1 = doc.CreateElement("street1");


                        //Appending Data to the dynamic XML nodes

                        number.InnerText = row["regnumber"].ToString();
                        name.InnerText = row["name"].ToString();
                        cell.InnerText = phonesValue;
                        email.InnerText = stripedEmail;
                        street1.InnerText = row["address"].ToString();

                        //Change here

                        phone.InnerText = phonesValue;

                        //Appending child nodes to parrent nodes
                        customer.AppendChild(number);
                        customer.AppendChild(name);
                        customer.AppendChild(phone);
                        customer.AppendChild(cell);
                        customer.AppendChild(email);
                        customer.AppendChild(street1);

                        // customer.AppendChild(street2);

                        customers.AppendChild(customer);


                    }
                    doc.Save(xmlDocName + ".xml");
                }

            }
            catch (Exception ex)
            {
                logger.Log(ex.ToString());
                // MessageBox.Show("There was a system error please contact the Administrator", "Error in executing the Module", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        public void WriteToXMLPayables(DataTable dataTable, string conString, string sqlCmd, string xmlDocName)
        {
            try
            {

                MysqlConnectionClass mysqlcon = new MysqlConnectionClass();
                dataTable = mysqlcon.ConnectAndQuery(conString, sqlCmd);
                dataTable.TableName = "vendor";

                XmlDocument doc = new XmlDocument();
                //static nodes declation
                var declaration = doc.CreateXmlDeclaration("1.0", "utf-8", "yes");
                var vendors = doc.CreateElement("vendors");
                doc.AppendChild(declaration);
                doc.AppendChild(vendors);

                foreach (DataRow row in dataTable.Rows)
                {

                    string emailValue = row["emails"].ToString().Trim();
                    string phonesValue = row["phones"].ToString().Trim();
                    string stripedEmail = "";

                    string stripedPhones = "";


                    //=================================stripe Phones==========================================




                    int phoneswithCommas = phonesValue.IndexOf(",");
                    int phonesswithsemcolon = phonesValue.IndexOf(";");
                    int phonesswithforwardslash = phonesValue.IndexOf("/");
                    int phonesswithat = phonesValue.IndexOf("@");
                    if (phoneswithCommas > 0)
                    {
                        stripedPhones = phonesValue.Substring(0, phoneswithCommas);
                    }
                    else if (phonesswithsemcolon > 0)
                    {
                        stripedPhones = phonesValue.Substring(0, phonesswithsemcolon);
                    }
                    else if (phonesswithforwardslash > 0)
                    {
                        stripedPhones = phonesValue.Substring(0, phonesswithforwardslash);
                    }

                    else if (phonesswithat > 0)
                    {
                        stripedPhones = phonesValue.Substring(0, phonesswithat);
                    }
                    else
                    {
                        stripedPhones = phonesValue.ToString();
                    }


                    //===============================Stripe Emails============================================



                    int emailswithCommas = emailValue.IndexOf(",");
                    int emailswithsemcolon = emailValue.IndexOf(";");
                    int emailswithforwardslash = emailValue.IndexOf("/");
                    if (emailswithCommas > 0)
                    {
                        stripedEmail = emailValue.Substring(0, emailswithCommas);
                    }
                    else if (emailswithsemcolon > 0)
                    {
                        stripedEmail = emailValue.Substring(0, emailswithsemcolon);
                    }
                    else if (emailswithforwardslash > 0)
                    {
                        stripedEmail = emailValue.Substring(0, emailswithforwardslash);
                    }
                    else
                    {
                        stripedEmail = emailValue.ToString();
                    }

                    //declaration of dynamic xml nodes/elements
                    var vendor = doc.CreateElement("vendor");
                    var number = doc.CreateElement("number");
                    var name = doc.CreateElement("name");
                    var city = doc.CreateElement("city");
                    var phone = doc.CreateElement("phone");
                    var cell = doc.CreateElement("cell");
                    var email = doc.CreateElement("email");
                    var street1 = doc.CreateElement("street1");

                    //Appending Data to the dynamic XML nodes

                    number.InnerText = row["regnumber"].ToString();
                    name.InnerText = row["name"].ToString();
                    phone.InnerText = stripedPhones;
                    cell.InnerText = stripedPhones;

                    email.InnerText = stripedEmail;



                    street1.InnerText = row["address"].ToString();

                    //Appending child nodes to parrent nodes
                    vendor.AppendChild(number);
                    vendor.AppendChild(name);
                    vendor.AppendChild(city);
                    vendor.AppendChild(phone);
                    vendor.AppendChild(cell);
                    vendor.AppendChild(email);
                    vendor.AppendChild(street1);
                    vendors.AppendChild(vendor);


                }

                doc.Save(xmlDocName + ".xml");


            }
            catch (Exception ex)
            {
                logger.Log(ex.ToString());
                //MessageBox.Show("There was a system error please contact the Administrator", "Error in executing the Module", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        // method to return all rows with same inv num in a data table

        private DataTable MatcherTable(DataTable table, string invno)
        {
            DataTable match = table.Rows.Cast<DataRow>()
                                   .GroupBy(x => x[invno])
                                   .Where(g => g.Count() > 1)
                                   .Select(k => k.FirstOrDefault())
                                   .CopyToDataTable();
            return match;
        }

        //=====================write to the SalesInvoices xml without lines================================
        public void WriteToXMLInvoices(DataTable dataTable, string conString, string sqlCmd, string xmlDocName)
        {
            try
            {

                MysqlConnectionClass mysqlcon = new MysqlConnectionClass();
                dataTable = mysqlcon.ConnectAndQuery(conString, sqlCmd);
               // var datatable1 = mysqlcon.ConnectAndQuery(conString, "SELECT SUBSTR(invoice_number,4) as invoice_number,year,name,regnumber,cost,code,source_id,additional,created_at,updated_at FROM invoices");




                XmlDocument doc = new XmlDocument();
                //static nodes declation
                var declaration = doc.CreateXmlDeclaration("1.0", "utf-8", "yes");
                var documents = doc.CreateElement("documents");

                doc.AppendChild(declaration);
               
               
                foreach (DataRow row in dataTable.Rows)
                {





                    var document = doc.CreateElement("document");
                    var docNo = doc.CreateElement("docNo");
                    var docDate = doc.CreateElement("docDate");
                    var currencycode = doc.CreateElement("currencyCode");
                    var custNumber = doc.CreateElement("custNumber");
                    var shipTo = doc.CreateElement("shipTo");
                    var reference = doc.CreateElement("reference");
                    var subTotal = doc.CreateElement("subTotal");
                    var total = doc.CreateElement("total");
                    var salesName = doc.CreateElement("salesName");
                    var additionalInfo = doc.CreateElement("additionalInfo");
                    var term = doc.CreateElement("term");

                    var lines = doc.CreateElement("lines");

                    
                    docNo.InnerText = row["invoice_number"].ToString();
                    docDate.InnerText = row["updated_at"].ToString();
                    currencycode.InnerText = row["name"].ToString();
                    custNumber.InnerText = row["regnumber"].ToString();
                    shipTo.InnerText = "Procurement Regulatory Authority of Zimbabwe 9th Floor Pearl House 61 Samora Machel Avenue Harare";
                    reference.InnerText = row["source_id"].ToString();
                    subTotal.InnerText = row["cost"].ToString();
                    total.InnerText = row["cost"].ToString();
                    salesName.InnerText = "Portal";
                    additionalInfo.InnerText = row["additional"].ToString(); 
                    term.InnerText = "COD";



                    document.AppendChild(docNo);
                    document.AppendChild(docDate);
                    document.AppendChild(currencycode);
                    document.AppendChild(custNumber);
                    document.AppendChild(shipTo);
                    document.AppendChild(reference);
                    document.AppendChild(subTotal);
                    document.AppendChild(total);
                    document.AppendChild(salesName);
                    document.AppendChild(additionalInfo);
                    document.AppendChild(term);


                    /* DataTable dt = new DataTable();
                     var x = row["invoice_number"].ToString();
                     var y = datatable1;

                     DataRow[] foundlines = datatable1.Select("invoice_number ='inv" + row["invoice_number"].ToString() + "'");

                     if (foundlines.Length > 0)
                     { dt = foundlines.CopyToDataTable(); }*/



                    var sqlcmd = "SELECT SUBSTR(invoice_number,4) as invoice_number,year,name,regnumber,cost,description,code,source_id,additional,created_at,updated_at FROM invoices Where invoice_number=@param_1 && monthname(updated_at)=monthname(now()) && year(updated_at)=year(now())  order by updated_at desc";
                   // string conStringInner = @"server=localhost;userid=root;password=;database=prazdb;Connection Timeout=600";
                    string conStringInner = @"server=10.0.0.12;userid=palladium;password=palladium2021@;database=palladium;Connection Timeout=600";

                    MySqlConnection con = new MySqlConnection(conStringInner);
                    con.Open();
                    MySqlCommand m = new MySqlCommand(sqlcmd,con);
                    m.Parameters.Add("@param_1", MySqlDbType.VarChar);

                    m.Parameters["@param_1"].Value = "inv" + row["invoice_number"];
                    MySqlDataReader dataReader = m.ExecuteReader();
                    DataTable datatable1 = new DataTable();
                    datatable1.Load(dataReader);

                    if (con != null && con.State != ConnectionState.Closed)
                    {
                        //closing the connection
                        con.Close();
                        logger.Log("PRAZ MySQL Connection Has been successfully closed");



                    }

                    var i = 0;
                    foreach (DataRow dr in datatable1.Rows)
                    {
                        
                        i = i + 1;
                        
                        
                        var line = doc.CreateElement("line");
                        var lineNo = doc.CreateElement("lineNo");
                        var binids = doc.CreateElement("binids");
                        var bin = doc.CreateElement("bin");
                        var bincode = doc.CreateElement("bincode");
                        var quantity = doc.CreateElement("quantity");
                        var partNumber = doc.CreateElement("partNumber");
                        var partDesc = doc.CreateElement("partDesc");
                        var location = doc.CreateElement("location");
                        var qty = doc.CreateElement("qty");
                        var unitOfMeasure = doc.CreateElement("unitOfMeasure");
                        var type = doc.CreateElement("type");
                        var isTaxInclusive = doc.CreateElement("isTaxInclusive");
                        var unitPrice = doc.CreateElement("unitPrice");
                        var lineTotal = doc.CreateElement("lineTotal");

                        //lines      we need to loop through all sales invoices here 
                        term.InnerText = "COD";
                        lineNo.InnerText = i.ToString();
                        partNumber.InnerText = dr["code"].ToString();
                        location.InnerText = "DEFAULT";
                        partDesc.InnerText = dr["description"].ToString();

                        bincode.InnerText = "DEFAULT";
                        quantity.InnerText = "1";
                        qty.InnerText = "1";
                        unitOfMeasure.InnerText = "EA";
                        isTaxInclusive.InnerText = false.ToString();
                        unitPrice.InnerText = dr["cost"].ToString();
                        lineTotal.InnerText = dr["cost"].ToString();


                        bin.AppendChild(bincode);
                        bin.AppendChild(quantity);
                        binids.AppendChild(bin);
                        line.AppendChild(lineNo);
                        line.AppendChild(partNumber);
                        line.AppendChild(location);
                        line.AppendChild(partDesc);
                        line.AppendChild(qty);
                        line.AppendChild(unitOfMeasure);
                        line.AppendChild(isTaxInclusive);
                        line.AppendChild(unitPrice);
                        line.AppendChild(lineTotal);
                        line.AppendChild(binids);
                        lines.AppendChild(line);




                    }

                    document.AppendChild(lines);
                    documents.AppendChild(document);


                }
                doc.AppendChild(documents);
                doc.Save(xmlDocName + ".xml");
            }
            catch (Exception ex)
            {
                logger.Log(ex.ToString());
                //MessageBox.Show("There was a system error please contact the Administrator", "Error in executing the Module", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //=====================write to the SalesInvoices xml without lines================================




        //=====================write to the Receipts xml ================================
        public void WriteToXMLReciepts(DataTable dataTable, string conString, string sqlCmd, string xmlDocName)
        {
            try
            {
                MysqlConnectionClass mysqlcon = new MysqlConnectionClass();

                dataTable = mysqlcon.ConnectAndQuery(conString, sqlCmd);

                XmlDocument doc = new XmlDocument();
                //static nodes declation
                var declaration = doc.CreateXmlDeclaration("1.0", "utf-8", "yes");
                var receipts = doc.CreateElement("receipts");

                doc.AppendChild(declaration);
                doc.AppendChild(receipts);

                foreach (DataRow row in dataTable.Rows)
                {
                    var existNewInvoice = row["newInvoice"].ToString();
                    bool checkexist = CheckInvoiceRecordExist(existNewInvoice);

                    var receipt = doc.CreateElement("receipt");
                    var custNumber = doc.CreateElement("custNumber");
                    var docNo = doc.CreateElement("docNo");
                    var docDate = doc.CreateElement("docDate");
                    var tenderType = doc.CreateElement("tenderType");
                    var intAccount = doc.CreateElement("intAccount");
                    var department = doc.CreateElement("department");
                    var exchangeRate = doc.CreateElement("exchangeRate");
                    var comment = doc.CreateElement("comment");
                    var receiptAmount = doc.CreateElement("receiptAmount");
                    var deposit = doc.CreateElement("deposit");
                    var total = doc.CreateElement("total");
                    var invoiceDocNo = doc.CreateElement("invoiceDocNo");
                    var discountTaken = doc.CreateElement("discountTaken");
                    var amount = doc.CreateElement("amount");
                    var lines = doc.CreateElement("lines");
                    var line = doc.CreateElement("line");

                    if (checkexist==true) 
                    {
                        //Appending data to the dynamic nodes
                        custNumber.InnerText = row["regnumber"].ToString();
                        docNo.InnerText = row["receiptnumber"].ToString();
                        docDate.InnerText = row["created_at"].ToString();
                        string myTenderType = row["method"].ToString();
                        string tender = "";



                        string accountNumber = row["account"].ToString();

                        //check  for account to be deposited ammount
                        if (myTenderType == "ECOCASH")
                        {
                            accountNumber = "1050-0000";
                            tender = "Ecocash";
                        }
                        else if (myTenderType == "PAYNOW")
                        {
                            accountNumber = "1050-0000";
                            tender = "Ecocash";
                        }

                        else if (myTenderType == "suspense")
                        {
                            accountNumber = "1050-0000";
                            tender = "Suspense";
                        }


                        else
                        {
                            accountNumber = "1060-0000";
                            tender = "Cash";
                        }

                        tenderType.InnerText = tender;

                        intAccount.InnerText = accountNumber;
                        comment.InnerText = "Paid";
                        receiptAmount.InnerText = row["amount"].ToString();
                        total.InnerText = row["amount"].ToString();

                        //line
                        invoiceDocNo.InnerText = row["invoicenumber"].ToString();
                        amount.InnerText = row["amount"].ToString();
                        discountTaken.InnerText = "0.0";
                        //End of lines



                        //appending lines
                        line.AppendChild(invoiceDocNo);
                        line.AppendChild(discountTaken);
                        line.AppendChild(amount);
                        lines.AppendChild(line);
                        //end of appending lines

                        receipt.AppendChild(custNumber);
                        receipt.AppendChild(docNo);
                        receipt.AppendChild(docDate);
                        receipt.AppendChild(tenderType);
                        receipt.AppendChild(intAccount);
                        receipt.AppendChild(comment);
                        receipt.AppendChild(department);
                        receipt.AppendChild(exchangeRate);
                        receipt.AppendChild(receiptAmount);
                        receipt.AppendChild(deposit);
                        receipt.AppendChild(total);
                        receipt.AppendChild(lines);
                        receipts.AppendChild(receipt);
                    }
                    
                }
                doc.Save(xmlDocName + ".xml");
            }
            catch (Exception ex)
            {
                logger.Log(ex.ToString());
                // MessageBox.Show("There was a system error please contact the Administrator", "Error in executing the Module", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }



        //To post to palladium Recievables
        public void PostToPalladiumRecievables(string filename)
        {
            try
            {

                string xmlString = System.IO.File.ReadAllText(filename);
                string response = maintenance.ProcessCustomers(settingName, xmlString);
               
                logger.Log(response);


            }

            catch (Exception ex)
            {
                logger.Log(ex.ToString());
                //  MessageBox.Show("There was a system error please contact the Administrator", "Error in executing the Module", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //To post to palladium  payables
        public void PostToPalladiumPayables(string filename)
        {
            try
            {
                string xmlString = System.IO.File.ReadAllText(filename);
                string response = maintenance.ProcessVendors(settingName, xmlString);

                //log response message
                logger.Log(response);
            }
            catch (Exception ex)
            {
                logger.Log(ex.ToString());
                // MessageBox.Show("There was a system error please contact the Administrator", "Error in executing the Module", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
        //To post to palladium Invoices
        public void PostToPalladiumInvoices(string filename)
        {
            try
            {

                /*XDocument doc =  XDocument.Load(filename);
                doc*/
                string xmlString = System.IO.File.ReadAllText(filename);
                string response = documents.ProcessSalesInvoices(settingName, xmlString);

                //log response message
                logger.Log(response);
            }
            catch (Exception ex)
            {
                logger.Log(ex.ToString());
                //  MessageBox.Show("There was a system error please contact the Administrator", "Error in executing the Module", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        // To post to palldium Reciepts
        public void PostToPalladiumReciepts(string filename)
        {
            try
            {
                string xmlString = System.IO.File.ReadAllText(filename);
                string response = documents.ProcessReceipts(settingName, xmlString);

                //log response message
                logger.Log(response);
            }
            catch (Exception ex)
            {
                logger.Log(ex.ToString());
                // MessageBox.Show("There was a system error please contact the Administrator", "Error in executing the Module", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }






        }

        public void writeCustomerandvendorsFile(string conString, string sqlCmd,DataTable dataTable)
        {
            try
            {
                MysqlConnectionClass mysqlcon = new MysqlConnectionClass();
                dataTable = mysqlcon.ConnectAndQuery(conString, sqlCmd);

                //Open the File
                StreamWriter sw = new StreamWriter(@"datafile\customerandvendors.txt", true, Encoding.ASCII);
                sw.Write("\r\nCustomers Entry :");
                sw.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                sw.WriteLine("=====================================================================Customer and vendors=====================================================================================");

                foreach (DataRow row in dataTable.Rows)
                {
                    var vcnumber = row["regnumber"].ToString();
                    var name = row["name"].ToString();
                    var emailValue = row["emails"].ToString().Trim();
                    var phonesValue = row["phones"].ToString().Trim();
                    var street1 = row["address"].ToString();

                    sw.WriteLine("Reg Number  " + vcnumber + "  | Company Name   " + name + "  | Emails  " + emailValue + "  | Physical Address   " + street1, Environment.NewLine);
                }

                sw.WriteLine("=====================================================================Customer and vendors======================================================================================");



            }
            catch (Exception ex)
            {
                logger.Log(ex.ToString());
            }

        }

       
        public void writeReceiptsFile(string conString, string sqlCmd, DataTable dataTable)
        {
            try
            {
                MysqlConnectionClass mysqlcon = new MysqlConnectionClass();
                dataTable = mysqlcon.ConnectAndQuery(conString, sqlCmd);
                //Int64 x;
                try
                {
                    //Open the File
                    StreamWriter sw = new StreamWriter(@"datafile\receipt.txt", true, Encoding.ASCII);
                    sw.Write("\r\nReceipts Entry :");
                    sw.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                    sw.WriteLine("=====================================================================RECEIPTS=====================================================================================");

                    foreach (DataRow row in dataTable.Rows)
                    {
                        var regnumber = row["regnumber"].ToString();
                        var receiptnumber = row["receiptnumber"].ToString();
                        var invoicenumber = row["invoicenumber"].ToString();
                        var created_at = row["created_at"].ToString();
                        var currency = row["currency"].ToString();
                        var myTenderType = row["method"].ToString();
                        var lineTotal = row["amount"].ToString();

                        sw.WriteLine("RegNumber  " + regnumber + "  | Receipt Number   " + receiptnumber + "  | Invoice Number  "+ invoicenumber + "  | Created   "+ created_at+ "   |currency    "+ currency + "  | Tender Type    "+ myTenderType + "     |Amount   $" + lineTotal, Environment.NewLine);
                    }
                    sw.WriteLine("=====================================================================RECEIPTS=====================================================================================");

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
                logger.Log(ex.ToString());
            }

        }

       
        public void writeInvoiceFile(string conString, string sqlCmd, DataTable dataTable)
        {
            try
            {
                MysqlConnectionClass mysqlcon = new MysqlConnectionClass();
                dataTable = mysqlcon.ConnectAndQuery(conString, sqlCmd);

                //Open the File
                StreamWriter sw = new StreamWriter(@"datafile\invoices.txt", true, Encoding.ASCII);
                sw.Write("\r\nInvoices Entry :");
                sw.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                sw.WriteLine("=====================================================================Invoices=====================================================================================");

                foreach (DataRow row in dataTable.Rows)
                {
                    var invoice_number = row["invoice_number"].ToString();
                    var docDateupdated_at = row["updated_at"].ToString();
                    var currencycode = row["name"].ToString();
                    var custNumber = row["regnumber"].ToString();
                    var reference = row["source_id"].ToString();
                    var subTotal = row["cost"].ToString();
                    var total = row["cost"].ToString();
                    var mysalesName = "Praz Online Portal";
                    var additionalInfo = row["additional"].ToString();
                    var partNumber = row["code"].ToString();

                    sw.WriteLine("InvoiceNo  " + invoice_number + "  | DocDate   " + docDateupdated_at + "  | Currency Code  " + currencycode + "  | Customer Number   " + custNumber + "   |Reference    " + reference + "  | SubTotal   " + subTotal + "     |total   $" + total+ "  | SalesName   " + mysalesName + "    Additional Info   "+ additionalInfo+ " Part Number  "+ partNumber, Environment.NewLine);
                }

                sw.WriteLine("=====================================================================Invoices=====================================================================================");


            }
            catch (Exception ex)
            {
                logger.Log(ex.ToString());
            }

        }
    }
}