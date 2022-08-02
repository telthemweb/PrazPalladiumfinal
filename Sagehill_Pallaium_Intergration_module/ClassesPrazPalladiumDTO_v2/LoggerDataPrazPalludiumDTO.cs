using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagehill_Pallaium_Intergration_module.ClassesDb
{
    class LoggerDataPrazPalludiumDTO
    {
        public void LogErrorToLogFile(string data) {

            //write log file
            try
            {
                var FilePath = "";
                var CurrentDirectory = Directory.GetCurrentDirectory();
                var FileName = DateTime.Now.ToString("ddMMyyyy") + "_payload_log.txt";

                var currentpath = CurrentDirectory + @"/innoandbrendo/";

                FilePath = Path.Combine(currentpath, DateTime.Now.ToString("ddMMyyyy"));

                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }

                FileStream fs = new FileStream(FilePath, FileMode.Create);
                //fs.Write(data);

                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    if (File.Exists(FilePath))
                    {
                        writer.WriteLine(data);
                        writer.WriteAsync(data);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+"   " + ex.StackTrace);
            }


        }

        public static string PathCombined(string path1, string path2)
        {
            var combined = Path.Combine(path1, path2);
            return combined;
        }
    }
}
