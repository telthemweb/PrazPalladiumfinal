using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Sagehill_Pallaium_Intergration_module
{   //logger class inherits from abstract logerbase class
    public class Logger : LogBase
    {

        //constructor
        public Logger()
        {   
            this.CurrentDirectory=Directory.GetCurrentDirectory();
            this.FileName = "Log.txt";
            this.FilePath = this.CurrentDirectory + "/" + this.FileName;
        }


        
        //encapsulated variables
        private string CurrentDirectory { get; set; }
        private string FileName { get; set; }
        private string FilePath { get; set; }

        //overide of abstract method log() in base class
        public override void Log(string message)
        {
            try
            {   //writing to log file
                using (System.IO.StreamWriter w = System.IO.File.AppendText(this.FilePath))
                {
                    w.Write("\r\nLog Entry :");
                    w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                    w.WriteLine("{0}",message);
                    w.WriteLine("------------------------------------------");
                }

            }
            //displaying exeception if any
            catch (Exception ex)
            {
                MessageBox.Show("Failed to write to log file Call Administrator. Error: "+ ex.ToString(), "Log Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

    }
}
