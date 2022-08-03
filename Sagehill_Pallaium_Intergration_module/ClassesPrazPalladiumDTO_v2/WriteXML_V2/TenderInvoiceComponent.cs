using Sagehill_Pallaium_Intergration_module.ClassesDb;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Sagehill_Pallaium_Intergration_module.ClassesPrazPalladiumDTO_v2.WriteXML_V2
{
    class TenderInvoiceComponent
    {
        public static void writeTenderInvoiceXml(DataTable dt)
        {
            XmlDocument doc = new XmlDocument();
            //static nodes declation
            var declaration = doc.CreateXmlDeclaration("1.0", "utf-8", "yes");
            var documents = doc.CreateElement("documents");

            doc.AppendChild(declaration);

            foreach (DataRow row in dt.Rows)
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
                var tax = doc.CreateElement("tax");
                var discountPerc = doc.CreateElement("discountPerc");

                docNo.InnerText = row["invoicenumber"].ToString();
                docDate.InnerText = row["invoicedate"].ToString();
                currencycode.InnerText = row["currency"].ToString();
                custNumber.InnerText = row["regnumber"].ToString();
                shipTo.InnerText = "Procurement Regulatory Authority of Zimbabwe 9th Floor Pearl House 61 Samora Machel Avenue Harare";
                additionalInfo.InnerText = "TENDER_INVOICE";
                subTotal.InnerText = row["amount"].ToString();
                total.InnerText = row["amount"].ToString();
                reference.InnerText = "TENDER INVOICE";
                salesName.InnerText = "Portal";
                term.InnerText = "COD";


                document.AppendChild(docNo);
                document.AppendChild(docDate);
                document.AppendChild(currencycode);
                document.AppendChild(custNumber);
                document.AppendChild(shipTo);
                document.AppendChild(reference);
                document.AppendChild(subTotal);
                document.AppendChild(discountPerc);
                document.AppendChild(tax);
                document.AppendChild(total);
                document.AppendChild(salesName);
                document.AppendChild(additionalInfo);
                document.AppendChild(term);


                try
                {

               
                //This query will write All Lines
                string sqlInnerSql = "SELECT id,regnumber,invoicenumber,tendernumber,description,feetype,type,currency,year,amount,invoicedate FROM tender_invoices WHERE invoicenumber='" + row["newInvoice"].ToString() + "'";
                DataTable dtsqlInnerSql = new DataTable();
                dtsqlInnerSql = DatabasePrazPalladiumDTO.Retrieve(sqlInnerSql);

                if (dtsqlInnerSql == null)
                {
                    Console.WriteLine("No line record");
                }

                var i = 0;
                foreach (DataRow linesRows in dtsqlInnerSql.Rows)
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
                    var taxCode = doc.CreateElement("taxCode");
                    var lineTotal = doc.CreateElement("lineTotal");




                    lineNo.InnerText = i.ToString();
                    partNumber.InnerText = linesRows["tendernumber"].ToString();
                    location.InnerText = "DEFAULT";
                    partDesc.InnerText = linesRows["description"].ToString();

                    bincode.InnerText = "DEFAULT";
                    quantity.InnerText = "1";
                    qty.InnerText = "1";
                    unitOfMeasure.InnerText = "EA";
                    isTaxInclusive.InnerText = false.ToString();
                    unitPrice.InnerText = linesRows["amount"].ToString();
                    lineTotal.InnerText = linesRows["amount"].ToString();


                    bin.AppendChild(bincode);
                    bin.AppendChild(quantity);
                    binids.AppendChild(bin);
                    line.AppendChild(lineNo);
                    line.AppendChild(partNumber);
                    line.AppendChild(partDesc);
                    line.AppendChild(location);
                    line.AppendChild(qty);
                    line.AppendChild(unitOfMeasure);
                    line.AppendChild(type);
                    line.AppendChild(isTaxInclusive);
                    line.AppendChild(unitPrice);
                    line.AppendChild(taxCode);
                    line.AppendChild(lineTotal);
                    line.AppendChild(binids);
                    lines.AppendChild(line);
                }
                //=======end of Inner for loop====
                document.AppendChild(lines);
                documents.AppendChild(document);

                }
                catch (Exception ex)
                {
                    var dtCurrentDirectory = Directory.GetCurrentDirectory();
                    var dberrorFileName = DateTime.Now.ToString("ddMMyyyy") + "_database_transaction_error.txt";
                    var derroFilePath = dtCurrentDirectory + @"/innoandbrendo/databaseerrorlogs/" + dberrorFileName;
                    using (StreamWriter writer = new StreamWriter(derroFilePath, true))
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
            }//end of outer forloop

            doc.AppendChild(documents);
            doc.Save(@"palladium/TenderInvoices.xml");
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var errorFileName = DateTime.Now.ToString("ddMMyyyy") + "_tenderinvoices_transaction.txt";
            var erroFilePath = CurrentDirectory + @"/innoandbrendo/portaldatatransactions/invoices/" + errorFileName;
            using (StreamWriter writer = new StreamWriter(erroFilePath, true))
            {
                writer.WriteLine("======================  TENDER INVOICES TRANSACTION FROM PORTAL   DATE:  " + DateTime.Now.ToLongDateString() + "===========================\n\n\n");
                writer.WriteLine("Tender Invoices  Data have been pulled from Portal at:     " + DateTime.Now.ToShortTimeString() + "\n\n\n");
                writer.WriteLine("======================POWERED BY SAGEHILL DEVELOPERS ===========================\n\n\n");
            }
        }
    }
}
