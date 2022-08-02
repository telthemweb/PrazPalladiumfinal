using Sagehill_Pallaium_Intergration_module.ClassesDb;
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
    }
}
