using Sagehill_Pallaium_Intergration_module.ClassesDb;
using Sagehill_Pallaium_Intergration_module.ClassesPrazPalladiumDTO_v2.WriteXML_V2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagehill_Pallaium_Intergration_module.ClassesPrazPalladiumDTO_v2
{
    class ReceiptPrazPalladiumDTO
    {
        /*
        |=============================================================================
        |
        |                  GET ALL RECEIPT FROM PORTAL
        |
        |=============================================================================
        */

        private const string receiptsql = "SELECT concat('IN-',SUBSTR(invoicenumber,4)) as invoicenumber,receiptnumber,type,description,regnumber,method,name,receiptdate,amount FROM portal_receipts where monthname(receiptdate)=monthname(now()) and year(receiptdate)=year(now()) order by receiptdate desc";

        public void getAllReceiptsFromPortal()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DatabasePrazPalladiumDTO.Retrieve(receiptsql);

                if (dt == null)
                {
                    Console.WriteLine("=================No Receipts found====================>{*/\\*}");
                }
                else
                {
                    //Static Function to write receipts xml 
                    ReceiptComponent.writeReceiptXml(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("======================TRACK ERROR==================================");
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
