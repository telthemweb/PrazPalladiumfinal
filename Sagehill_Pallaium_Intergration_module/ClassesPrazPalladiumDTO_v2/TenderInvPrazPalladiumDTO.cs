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
    class TenderInvPrazPalladiumDTO
    {
        private const string tenderInvoicessql = "SELECT max(id) AS id,max(regnumber) AS regnumber,SUBSTR(invoicenumber,4) as invoicenumber,max(tendernumber) AS tendernumber,max(description) AS description,max(feetype) AS feetype,max(TYPE) AS type,max(currency) AS currency,max(year) AS year, sum(amount) as amount,max(invoicedate) AS invoicedate FROM tender_invoices where monthname(invoicedate)=monthname(now()) && year(invoicedate)=year(NOW()) GROUP BY invoicenumber order by max(invoicedate) desc";





        /*
         |=============================================================================
         |
         |                  GET ALL TENDER INVOICES FROM PORTAL
         |
         |=============================================================================
         */

        public void getAllTenderInvoicesFromPortal()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DatabasePrazPalladiumDTO.Retrieve(tenderInvoicessql);

                if (dt == null)
                {
                    Console.WriteLine("=================No Tender Invoices====================>{*/\\*}");
                }
                else
                {
                    //Static Function to write Tender Invoices 
                    TenderInvoiceComponent.writeTenderInvoiceXml(dt);
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
