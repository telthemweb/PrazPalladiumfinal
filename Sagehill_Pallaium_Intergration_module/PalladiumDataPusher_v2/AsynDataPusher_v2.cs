using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sagehill_Pallaium_Intergration_module.PalladiumDataPusher_v2
{
    public partial class AsynDataPusher_v2 : Form
    {
        public AsynDataPusher_v2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SettingsPanel sp = new SettingsPanel();
            sp.ShowDialog();
        }

        private void AsynDataPusher_v2_Load(object sender, EventArgs e)
        {

        }
    }
}
