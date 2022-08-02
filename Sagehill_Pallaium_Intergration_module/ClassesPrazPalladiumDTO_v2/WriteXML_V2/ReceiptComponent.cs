using System;
using System.Collections.Generic;
using System.Data;
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
                    string myTenderType = row["method"].ToString();
                    string tender = "";


                    tenderType.InnerText = tender;


                    //check for account



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
            //end of loop

        }
    }
}
