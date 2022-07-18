using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Sagehill_Pallaium_Intergration_module
{
    public class MysqlConnectionClass
    {



      public  Logger logger = new Logger();

        

        //Database variables 
        private  MySqlDataReader dataReader = null;
        private  MySqlConnection connection = null; 
        private DataTable dataTable = new DataTable();
      
        

        //Method to connect to database and execute a query. Takes two string parameters and returns a DataTable
        public DataTable ConnectAndQuery(string conString, string sqlCmd)
        {   
            

            try

            {
                connection = new MySqlConnection(conString);
                connection.Open();
                if (!connection.Ping())
                {
                    MessageBox.Show("Could not connect to Portal database please check if your link is up", "Network Error, Failed to connect to Portal Database", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    logger.Log("Failed To connect to Praz Mysql because the link or network is down");
                   // Application.SetUnhandledExceptionMode();
                }
                
                
               
                
                logger.Log("Connection to Mysql Successfully opened");


                //Check if there is a connection to the database server



                //Indicate  that the connection was successfull

                MySqlCommand cmd = new MySqlCommand(sqlCmd, connection);
                //executing the sql command
                dataReader = cmd.ExecuteReader();
                logger.Log("Executed SQL Command");

                //loading the data from data reader to data table
                dataTable.Load(dataReader);
                


                

            }
            catch (Exception ex)
            {   //showing any exeption  thrown by the database 
                logger.Log("Hanlded Exeption: " + ex.ToString());
                MessageBox.Show("There was a system error please contact the Administrator","Error in executing the Module",MessageBoxButtons.OK,MessageBoxIcon.Error);

                
            }
            finally
            {
                if (connection != null &&connection.State!=ConnectionState.Closed)
                {
                    //closing the connection
                    connection.Close();
                    logger.Log("PRAZ MySQL Connection Has been successfully closed");

                    
                    
                }

            }
            // returns the a data table that amounts to the executed table
            return dataTable;

        }
        //Method to connect and insert to palladium
        public void ConnectAndInsert(string conString, string sqlCmd)
        {

        }
        

    }

    
}
