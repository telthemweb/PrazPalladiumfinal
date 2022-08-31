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
    class SupplierAccountComponent
    {
        public static void writeSupplierAccountstXml(DataTable dt)
        {
            XmlDocument doc = new XmlDocument();
            var declaration = doc.CreateXmlDeclaration("1.0", "utf-8", "yes");
            var vendors = doc.CreateElement("vendors");
            doc.AppendChild(declaration);
            doc.AppendChild(vendors);

            foreach (DataRow row in dt.Rows)
            {
                var vendor = doc.CreateElement("vendor");
                var number = doc.CreateElement("number");
                var name = doc.CreateElement("name");
                var city = doc.CreateElement("city");
                var phone = doc.CreateElement("phone");
                var cell = doc.CreateElement("cell");
                var email = doc.CreateElement("email");
                var street1 = doc.CreateElement("street1");
                var invoiceWorkflowNew = doc.CreateElement("invoiceWorkflowNew");
                var invoiceWorkflowDA = doc.CreateElement("invoiceWorkflowDA");
                var invoiceWorkflowSO = doc.CreateElement("invoiceWorkflowSO");

                number.InnerText = row["regnumber"].ToString(); //regnumber
                name.InnerText = row["name"].ToString();
                invoiceWorkflowNew.InnerText = "1";
                invoiceWorkflowDA.InnerText = "1";
                invoiceWorkflowSO.InnerText = "1";


                vendor.AppendChild(number);
                vendor.AppendChild(name);
                vendor.AppendChild(city);
                vendor.AppendChild(phone);
                vendor.AppendChild(cell);
                vendor.AppendChild(email);
                vendor.AppendChild(street1);
                vendor.AppendChild(invoiceWorkflowNew);
                vendor.AppendChild(invoiceWorkflowDA);
                vendor.AppendChild(invoiceWorkflowSO);




                vendors.AppendChild(vendor);
            }
            doc.Save(@"palladium/vendors.xml");
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var errorFileName = DateTime.Now.ToString("ddMMyyyy") + "_vendors_transaction.txt";
            var erroFilePath = CurrentDirectory + @"/innoandbrendo/portaldatatransactions/customersuppliers/" + errorFileName;
            using (StreamWriter writer = new StreamWriter(erroFilePath, true))
            {
                writer.WriteLine("======================  SUPPLIERS TRANSACTION FROM PORTAL   DATE:  " + DateTime.Now.ToLongDateString() + "===========================\n\n\n");
                writer.WriteLine("Supplier Data have been pulled from Portal at:   " + DateTime.Now.ToShortTimeString() + "\n\n\n");
                writer.WriteLine("======================POWERED BY SAGEHILL DEVELOPERS ===========================\n\n\n");
                writer.Close();
            }
            //END FOR LOOP
        }

        

        public static void writeCustAccountstXml(DataTable dt)
        {
            XmlDocument doc = new XmlDocument();
            var declaration = doc.CreateXmlDeclaration("1.0", "utf-8", "yes");
            var customers = doc.CreateElement("customers");
            doc.AppendChild(declaration);
            doc.AppendChild(customers);

            foreach (DataRow row in dt.Rows)
            {
                var customer = doc.CreateElement("customer");
                var number = doc.CreateElement("number");
                var name = doc.CreateElement("name");
                var phone = doc.CreateElement("phone");
                var cell = doc.CreateElement("cell");
                var email = doc.CreateElement("email");
                var street1 = doc.CreateElement("street1");
                var invoiceWorkflowNew = doc.CreateElement("invoiceWorkflowNew");
                var invoiceWorkflowDA = doc.CreateElement("invoiceWorkflowDA");
                var invoiceWorkflowSO = doc.CreateElement("invoiceWorkflowSO");

                number.InnerText = row["regnumber"].ToString(); //regnumber
                name.InnerText = row["name"].ToString();
                invoiceWorkflowNew.InnerText = "1";
                invoiceWorkflowDA.InnerText = "1";
                invoiceWorkflowSO.InnerText = "1";


                customer.AppendChild(number);
                customer.AppendChild(name);
                customer.AppendChild(phone);
                customer.AppendChild(cell);
                customer.AppendChild(email);
                customer.AppendChild(street1);

                customer.AppendChild(invoiceWorkflowNew);
                customer.AppendChild(invoiceWorkflowDA);
                customer.AppendChild(invoiceWorkflowSO);


                customers.AppendChild(customer);
            }
            doc.Save(@"palladium/vendor_customer.xml");
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var errorFileName = DateTime.Now.ToString("ddMMyyyy") + "_vendor_customer_transaction.txt";
            var erroFilePath = CurrentDirectory + @"/innoandbrendo/portaldatatransactions/customersuppliers/" + errorFileName;
            using (StreamWriter writer = new StreamWriter(erroFilePath, true))
            {
                writer.WriteLine("======================  SUPPLIER CUSTOMERS TRANSACTION FROM PORTAL   DATE:  " + DateTime.Now.ToLongDateString() + "===========================\n\n\n");
                writer.WriteLine("Supplier Customer Data have been pulled from Portal at:   " + DateTime.Now.ToShortTimeString() + "\n\n\n");
                writer.WriteLine("======================POWERED BY SAGEHILL DEVELOPERS ===========================\n\n\n");
                writer.Close();
            }
            //END FOR LOOP
        }

    }
}
