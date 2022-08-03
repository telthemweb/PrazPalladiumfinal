using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sagehill_Pallaium_Intergration_module.DbConfig
{
    public partial class DatabaseConfigurationwiz : Form
    {
        public DatabaseConfigurationwiz()
        {
            InitializeComponent();
        }

        private void DatabaseConfigurationwiz_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string passwordvalue = string.Empty;
            if (string.IsNullOrEmpty(txtPass.Text) && string.IsNullOrWhiteSpace(txtPass.Text))
            {

                passwordvalue = string.Format("server={0};database={1};userid={2};password=;SSL Mode=None;Port=3306;Connection Timeout=600", txtServerName.Text, txtDbName.Text, txtUser.Text);

            }
            else
            {
                passwordvalue = string.Format("server={0};database={1};userid={2};password={3};SSL Mode=None;Port=3306;Connection Timeout=600", txtServerName.Text, txtDbName.Text, txtUser.Text, txtPass.Text);

            }
            string connectionString = passwordvalue;
            try
            {
                SqlHelperClass helper = new SqlHelperClass(connectionString);
                if (helper.IsConnection)
                    MessageBox.Show("Test connection succeeded.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string passwordvalue = string.Empty;
                if (string.IsNullOrEmpty(txtPass.Text) && string.IsNullOrWhiteSpace(txtPass.Text))
                {

                    passwordvalue = string.Format("server={0};database={1};userid={2};password=;SSL Mode=None;Port=3306;Connection Timeout=600", txtServerName.Text, txtDbName.Text, txtUser.Text);

                }
                else
                {
                    passwordvalue = string.Format("server={0};database={1};userid={2};password={3};SSL Mode=None;Port=3306;Connection Timeout=600", txtServerName.Text, txtDbName.Text, txtUser.Text, txtPass.Text);

                }
                string connectionString = passwordvalue;
                SqlHelperClass helper = new SqlHelperClass(connectionString);
                if (helper.IsConnection)
                {
                    DatabaseConfiguration setting = new DatabaseConfiguration();
                    setting.SaveConnectionString("cn", connectionString);
                    MessageBox.Show("Your connection string has been successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseConfiguration setting = new DatabaseConfiguration();
                MessageBox.Show(setting.GetConnectionString("cn"));
            }catch(Exception ex)
            {
                var dtCurrentDirectory = Directory.GetCurrentDirectory();
                var dberrorFileName = DateTime.Now.ToString("ddMMyyyy") + "_database_configuration_error.txt";
                var derroFilePath = dtCurrentDirectory + @"/innoandbrendo/databaseerrorlogs/config/" + dberrorFileName;
                using (StreamWriter writer = new StreamWriter(derroFilePath, true))
                {
                    writer.WriteLine("===============TODAY DATABASE CONFIGURATION ERROR DETAILS   DATE:  " + DateTime.Now.ToLongDateString() + "===========================  TIME:  " + DateTime.Now.ToLongTimeString() + "\n\n\n");
                    writer.WriteLine(ex.Message);
                    writer.WriteLine("\n\n\n");
                    writer.WriteLine("=======================ERROR DETAILS===========================\n\n\n");
                    writer.WriteLine(ex.StackTrace);
                    writer.WriteLine("\n\n\n");
                    writer.WriteLine("===============POWERED BY SAGEHILL DEVELOPERS ===========================\n\n\n");

                }
            }
        }
    }
}
