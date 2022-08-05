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
    class ReceiptComponent
    {
        public static void writeReceiptXml(DataTable dt)
        {
            XmlDocument doc = new XmlDocument();
            var declaration = doc.CreateXmlDeclaration("1.0", "utf-8", "yes");
            var receipts = doc.CreateElement("receipts");

            doc.AppendChild(declaration);
            doc.AppendChild(receipts);

            foreach (DataRow row in dt.Rows)
            {
                var outerInvId = row["invoicenumber"].ToString();
                if (!string.IsNullOrEmpty(outerInvId) && !string.IsNullOrWhiteSpace(outerInvId))
                {
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


                    
                    custNumber.InnerText = row["regnumber"].ToString();
                    docNo.InnerText = row["receiptnumber"].ToString();
                    docDate.InnerText = row["receiptdate"].ToString();
                    string accounttype = row["type"].ToString();
                   ;


                    tenderType.InnerText = row["method"].ToString();
                    var accountNumber = "";


                    //c account

                    //Registrations and Renewals:              4010-0000      Registrations & Renewals
                    //SPOC                                     4045-0000      SPOC Fees
                    //Bid Establishment Fees:                  4015-0000      Bid Establishment Fees
                    //Contract Fees:                           4005-0000      Contract Fees
                    //Training Fees:                           4095-0000      Training Fees
                    // Certification & Accreditation           4096-0000      Certification & Accreditation
                    //Exhibitions & Partnerships:              4090-0000      Advertisements & Partnerships
                    //Request for Exemptions:                  4040-0000      Exemption fees by Entities
                    //Application to Conduct                   4025-0000      Class A Authority to Conduct
                    //                                         4030-0000      Class B Authority to Conduct
                    //                                         4035-0000      Class C Authority to Conduct
                    //WBS                                      4075-0000      Whistle Blowing – Annual Subscriptions
                    //                                         4080-0000      Whistle Blowing – PE Registrations


                    if (accounttype == "CONTRACT FEE")
                    {
                        accountNumber = "4005-0000";
                    }
                    else if (accounttype == "SPOC")
                    {
                        accountNumber = "4045-0000";
                    }

                   
                    else if (accounttype == "ESTABLISHMENT FEE")
                    {
                        //roomfor change
                        accountNumber = "";
                    }
                    else if (accounttype == "SUPPLIER")
                    {
                        //roomfor change
                        accountNumber = "";
                    }

                    else if (accounttype == "BIDBOND")
                    {
                        //roomfor change
                        accountNumber = "";
                    }
                    else if (accounttype == "NONREFUNDABLE")
                    {
                        //roomfor change
                        accountNumber = "";
                    }
                    else if (accounttype == "REFUNDABLE")
                    {
                        //roomfor change
                        accountNumber = "";
                    }
                    else
                    {
                        //roomfor change
                        accountNumber = "";
                    }


                    intAccount.InnerText = accountNumber;
                    comment.InnerText = "Paid";
                    receiptAmount.InnerText = row["amount"].ToString();
                    total.InnerText = row["amount"].ToString();

                    //line
                    invoiceDocNo.InnerText = outerInvId;
                    amount.InnerText = row["amount"].ToString();
                    discountTaken.InnerText = "0.0";

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
            doc.Save(@"palladium/Receipts.xml");
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var errorFileName = DateTime.Now.ToString("ddMMyyyy") + "_receipts_transaction.txt";
            var erroFilePath = CurrentDirectory + @"/innoandbrendo/portaldatatransactions/receipt/" + errorFileName;
            using (StreamWriter writer = new StreamWriter(erroFilePath, true))
            {
                writer.WriteLine("======================  RECEIPTS TRANSACTION FROM PORTAL   DATE:  " + DateTime.Now.ToLongDateString() + "===========================\n\n\n");
                writer.WriteLine("Receipts have been pulled from Portal at:   " + DateTime.Now.ToShortTimeString() + "\n\n\n");
                writer.WriteLine("======================POWERED BY SAGEHILL DEVELOPERS ===========================\n\n\n");
                writer.Close();
            }
            //end of loop

        }
    }
}
