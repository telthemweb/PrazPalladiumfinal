using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagehill_Pallaium_Intergration_module.ClassesDb
{


    class SchedulerPrazPalludiumDTO
    {
        Configuration schedularconfig;
        public SchedulerPrazPalludiumDTO()
        {
            schedularconfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }



        //Get connection string from App.Config file
        public string GetScheduleString(string key)
        {
            string result = "";
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                result = appSettings[key] ?? "0";
                Console.WriteLine(result);
            }
            catch (ConfigurationErrorsException ex)
            {
                var CurrentDirectory = Directory.GetCurrentDirectory();
                var errorFileName = DateTime.Now.ToString("ddMMyyyy") + "_customer_error_log.txt";
                var erroFilePath = CurrentDirectory + @"/innoandbrendo/databaseerrorlogs/config/" + errorFileName;
                using (StreamWriter writer = new StreamWriter(erroFilePath, true))
                {
                    writer.WriteLine("===============TODAY ERROR DETAILS   DATE:  " + DateTime.Now.ToLongDateString() + "===========================  TIME:  " + DateTime.Now.ToLongTimeString() + "\n\n\n");
                    writer.WriteLine(ex.Message);
                    writer.WriteLine("\n\n\n");
                    writer.WriteLine("=======================ERROR DETAILS===========================\n\n\n");
                    writer.WriteLine(ex.StackTrace);
                    writer.WriteLine("\n\n\n");
                    writer.WriteLine("===============POWERED BY SAGEHILL DEVELOPERS ===========================\n\n\n");

                }
            }
            return result;

        }


        //Save connection string to App.config file
        public void SaveSchedularString(string sage_hour, string sage_minutes, string sage_seconds)
        {
            schedularconfig.AppSettings.Settings.Add("sc_hours", sage_hour);
            schedularconfig.AppSettings.Settings.Add("sc_minutes", sage_minutes);
            schedularconfig.AppSettings.Settings.Add("sc_secs", sage_seconds);
            schedularconfig.Save(ConfigurationSaveMode.Modified);
            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("sagehillSchedular_module");
        }

        //Save connection string to App.config file
        public void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var settings = schedularconfig.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                schedularconfig.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(schedularconfig.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }
    }
}
