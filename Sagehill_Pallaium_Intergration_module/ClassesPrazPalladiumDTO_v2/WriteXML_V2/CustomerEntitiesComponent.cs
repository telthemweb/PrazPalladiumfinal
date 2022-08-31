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
    class CustomerEntitiesComponent
    {
        public static void writeCutomerEntitiestXml(DataTable dt)
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



                number.InnerText = row["regnumber"].ToString();
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

                // customer.AppendChild(street2);

                customers.AppendChild(customer);
            }
            doc.Save(@"palladium/customers.xml");
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var errorFileName = DateTime.Now.ToString("ddMMyyyy") + "_custumer_transaction.txt";
            var erroFilePath = CurrentDirectory + @"/innoandbrendo/portaldatatransactions/customersuppliers/" + errorFileName;
            using (StreamWriter writer = new StreamWriter(erroFilePath, true))
            {
                writer.WriteLine("======================  CUSTOMERS TRANSACTION FROM PORTAL   DATE:  " + DateTime.Now.ToLongDateString() + "===========================\n\n\n");
                writer.WriteLine("Data pulled from Portal and Xml created at:   " + DateTime.Now.ToShortTimeString() + "\n\n\n");
                writer.WriteLine("======================POWERED BY SAGEHILL DEVELOPERS ===========================\n\n\n");
                writer.Close();
            }
            //END FOR LOOP
        }
    }
}
