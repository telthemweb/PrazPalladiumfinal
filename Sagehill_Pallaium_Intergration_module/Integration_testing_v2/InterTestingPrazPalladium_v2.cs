using DevOne.Security.Cryptography.BCrypt;
using Sagehill_Pallaium_Intergration_module.ClassesDb;
using Sagehill_Pallaium_Intergration_module.PalladiumDataPusher_v2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Sagehill_Pallaium_Intergration_module.Integration_testing_v2
{
    public partial class InterTestingPrazPalladium_v2 : Form
    {
        public InterTestingPrazPalladium_v2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoggerDataPrazPalludiumDTO loger = new LoggerDataPrazPalludiumDTO();
            var data = "waraarr";
            loger.LogErrorToLogFile(data);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SagePostNow sg = new SagePostNow();
            sg.Show();
            this.Hide();
        }

        private void InterTestingPrazPalladium_v2_Load(object sender, EventArgs e)
        {
            var time = DateTime.Now.ToLongTimeString();
            button4.Text = time;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string salt = BCryptHelper.GenerateSalt();
            string passwordHash = BCryptHelper.HashPassword("phhdhdhdhdhhd", salt);
            Console.WriteLine(passwordHash);
            
        }
    }
}
