using MySql.Data.MySqlClient;

namespace Sagehill_Pallaium_Intergration_module.DbConfig
{
    class SqlHelperClass
    {
        MySqlConnection cn;
        public SqlHelperClass(string connectionString)
        {
            cn = new MySqlConnection(connectionString);
        }

        public bool IsConnection
        {
            get
            {
                if (cn.State == System.Data.ConnectionState.Closed)
                    cn.Open();
                return true;
            }
        }
    }
}
