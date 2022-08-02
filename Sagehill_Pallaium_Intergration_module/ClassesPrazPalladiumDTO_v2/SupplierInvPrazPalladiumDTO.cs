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
    class SupplierInvPrazPalladiumDTO
    {
        /*
        |=============================================================================
        |
        |                  GET ALL TENDER INVOICES FROM PORTAL
        |
        |=============================================================================
        */

        private const string supplierInvoicessql = "SELECT max(regnumber) AS regnumber,SUBSTR(invoicenumber,4) as invoicenumber,max(code) AS code,max(name) AS name,max(year) AS year, sum(amount) as amount,max(invoicedate) AS invoicedate FROM supplier_invoices where monthname(invoicedate)=monthname(now()) && year(invoicedate)=year(NOW()) GROUP BY invoicenumber order by max(invoicedate) desc";

        public void getAllSupplerInvoicesFromPortal()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DatabasePrazPalladiumDTO.Retrieve(supplierInvoicessql);

                if (dt == null)
                {
                    Console.WriteLine("=================No Supplier Invoices====================>{*/\\*}");
                }
                else
                {
                    //Static Function to write Tender Invoices 
                    SuppliernvoiceComponent.writeSupplierInvoiceXml(dt);
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
