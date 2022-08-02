using MySql.Data.MySqlClient;
using Sagehill_Pallaium_Intergration_module.DbConfig;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagehill_Pallaium_Intergration_module.ClassesDb
{
    

    class DatabasePrazPalladiumDTO
    {
        public static MySqlConnection conn;

        //out query

        public static MySqlConnection OuterConnOpen()
        {
            if (conn == null)
            {
                DatabaseConfiguration setting = new DatabaseConfiguration();
                var cnstr = setting.GetConnectionString("cn");
                conn = new MySqlConnection(cnstr);
            }

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            return conn;
        }

        private static MySqlConnection ConnOpen()
        {
            if (conn == null)
            {
                DatabaseConfiguration setting = new DatabaseConfiguration();
                var cnstr = setting.GetConnectionString("cn");
                conn = new MySqlConnection(cnstr);
            }

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            return conn;
        }

        //Insert new record
        public static bool Insert(string query)
        {
            try
            {
                int numRows = 0;
                MySqlCommand cmd = new MySqlCommand(query, ConnOpen());
                numRows = cmd.ExecuteNonQuery();
                if (numRows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }



        //delete a record
        public static bool Delete(string query)
        {
            try
            {
                int numRows = 0;
                MySqlCommand cmd = new MySqlCommand(query, ConnOpen());
                numRows = cmd.ExecuteNonQuery();
                if (numRows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }

        //retrieve records
        public static DataTable Retrieve(string query)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(query, ConnOpen());
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }

        }
    }
}
