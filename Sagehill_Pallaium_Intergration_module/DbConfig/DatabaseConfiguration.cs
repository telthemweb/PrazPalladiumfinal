using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagehill_Pallaium_Intergration_module.DbConfig
{
    public class DatabaseConfiguration
    {
        Configuration config;

        public DatabaseConfiguration()
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        //Get connection string from App.Config file
        public string GetConnectionString(string key)
        {
            return config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
        }

        public void SaveConnectionString(string key, string value)
        {


            ConfigurationManager.RefreshSection("connectionStrings");
            ConnectionStringSettings database = new ConnectionStringSettings();

            database.ConnectionString = value;
            database.Name = key;
            database.ProviderName = "MySql.Data.MySqlClient";
            config.ConnectionStrings.ConnectionStrings.Add(database);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");

        }


        public void WriteConnectionString()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings.Remove("LocalMySqlServer");
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");

            ConnectionStringSettings css = new ConnectionStringSettings();
            css.ConnectionString = String.Format(
                "server=localhost;user=root;password=;database=busepayment;pooling=false;port=3306");
            css.Name = "LocalMySqlServer";
            config.ConnectionStrings.ConnectionStrings.Add(css);
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
        }


    }
}
