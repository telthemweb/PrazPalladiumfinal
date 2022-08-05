using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Sagehill_Pallaium_Intergration_module.ClassesPrazPalladiumDTO_v2
{
    class SchedularTimerPrazPalladiumDTO
    {
        Configuration schedularconfig;
        public SchedularTimerPrazPalladiumDTO()
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
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
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
