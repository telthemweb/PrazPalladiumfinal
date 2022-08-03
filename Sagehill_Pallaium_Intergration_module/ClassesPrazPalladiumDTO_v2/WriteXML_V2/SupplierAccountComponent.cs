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

                number.InnerText = row["regnumber"].ToString(); //regnumber
                name.InnerText = row["name"].ToString();


                vendor.AppendChild(number);
                vendor.AppendChild(name);
                vendor.AppendChild(city);
                vendor.AppendChild(phone);
                vendor.AppendChild(cell);
                vendor.AppendChild(email);
                vendor.AppendChild(street1);
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
            }
            //END FOR LOOP
        }
    }
}
