using Sagehill_Pallaium_Intergration_module.ClassesPrazPalladiumDTO_v2;
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
    public partial class TimerSchedular : Form
    {
        public TimerSchedular()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SchedularTimerPrazPalladiumDTO schedularsetting = new SchedularTimerPrazPalladiumDTO();
                schedularsetting.SaveSchedularString(txtHours.Text.Trim(), txtMinutes.Text.Trim(), txtSeconds.Text.Trim());
                MessageBox.Show("New schedule time has been successfully saved  (*v*)!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            SchedularTimerPrazPalladiumDTO schedularsetting = new SchedularTimerPrazPalladiumDTO();
            MessageBox.Show("App set to run at:  " + schedularsetting.GetScheduleString("sc_hours") + ":" + schedularsetting.GetScheduleString("sc_minutes") + ":" + schedularsetting.GetScheduleString("sc_secs"));
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var datakey = "";
            SchedularTimerPrazPalladiumDTO schedularsetting = new SchedularTimerPrazPalladiumDTO();


            //H
            var smallHour = "hour";
            var smallHours = "hours";
            var smallh = "h";
            var bigH = "H";
            var capitaHour = "Hour";
            var capitaHours = "Hours";
            var ALLcapitaHour = "HOURS";
            var ALLcapitaHours = "HOUR";


            //M
            var smallM = "minute";
            var smallMs = "minutes";
            var smallm = "m";
            var bigM = "M";
            var capitaM = "Minute";
            var ALLcapitaM = "MINUTE";

            //M
            var smallsec = "second";
            var smallsecs = "seconds";
            var smalls = "s";
            var bigS = "S";
            var capitaS = "Second";
            var ALLcapitasec = "SECOND";

            //H
            if (txtKey.Text == smallHour)
            {
                datakey = "sc_hours";
                schedularsetting.AddUpdateAppSettings(datakey, txtValue.Text.Trim());
                MessageBox.Show("Schedule time has been successfully Updated  (*v*)!!");
            }
            else if (txtKey.Text == smallHours)
            {
                datakey = "sc_hours";
                schedularsetting.AddUpdateAppSettings(datakey, txtValue.Text.Trim());
                MessageBox.Show("Schedule time has been successfully Updated  (*v*)!!");
            }
            else if (txtKey.Text == smallh)
            {
                datakey = "sc_hours";
                schedularsetting.AddUpdateAppSettings(datakey, txtValue.Text.Trim());
                MessageBox.Show("Schedule time has been successfully Updated  (*v*)!!");
            }
            else if (txtKey.Text == bigH)
            {
                datakey = "sc_hours";
                schedularsetting.AddUpdateAppSettings(datakey, txtValue.Text.Trim());
                MessageBox.Show("Schedule time has been successfully Updated  (*v*)!!");
            }
            else if (txtKey.Text == capitaHour)
            {
                datakey = "sc_hours";
                schedularsetting.AddUpdateAppSettings(datakey, txtValue.Text.Trim());
                MessageBox.Show("Schedule time has been successfully Updated  (*v*)!!");
            }
            else if (txtKey.Text == capitaHours)
            {
                datakey = "sc_hours";
                schedularsetting.AddUpdateAppSettings(datakey, txtValue.Text.Trim());
                MessageBox.Show("Schedule time has been successfully Updated  (*v*)!!");
            }
            else if (txtKey.Text == ALLcapitaHour)
            {
                datakey = "sc_hours";
                schedularsetting.AddUpdateAppSettings(datakey, txtValue.Text.Trim());
                MessageBox.Show("Schedule time has been successfully Updated  (*v*)!!");
            }
            else if (txtKey.Text == ALLcapitaHours)
            {
                datakey = "sc_hours";
                schedularsetting.AddUpdateAppSettings(datakey, txtValue.Text.Trim());
                MessageBox.Show("Schedule time has been successfully Updated  (*v*)!!");
            }



            //M

            else if (txtKey.Text == smallM)
            {
                datakey = "sc_minutes";
                schedularsetting.AddUpdateAppSettings(datakey, txtValue.Text.Trim());
                MessageBox.Show("Schedule time has been successfully Updated  (*v*)!!");
            }
            else if (txtKey.Text == smallMs)
            {
                datakey = "sc_minutes";
                schedularsetting.AddUpdateAppSettings(datakey, txtValue.Text.Trim());
                MessageBox.Show("Schedule time has been successfully Updated  (*v*)!!");
            }
            else if (txtKey.Text == smallm)
            {
                datakey = "sc_minutes";
                schedularsetting.AddUpdateAppSettings(datakey, txtValue.Text.Trim());
                MessageBox.Show("Schedule time has been successfully Updated  (*v*)!!");
            }
            else if (txtKey.Text == bigM)
            {
                datakey = "sc_minutes";
                schedularsetting.AddUpdateAppSettings(datakey, txtValue.Text.Trim());
                MessageBox.Show("Schedule time has been successfully Updated  (*v*)!!");
            }
            else if (txtKey.Text == capitaM)
            {
                datakey = "sc_minutes";
                schedularsetting.AddUpdateAppSettings(datakey, txtValue.Text.Trim());
                MessageBox.Show("Schedule time has been successfully Updated  (*v*)!!");
            }
            else if (txtKey.Text == ALLcapitaM)
            {
                datakey = "sc_minutes";
                schedularsetting.AddUpdateAppSettings(datakey, txtValue.Text.Trim());
                MessageBox.Show("Schedule time has been successfully Updated  (*v*)!!");
            }

            //s

            else if (txtKey.Text == smallsec)
            {
                datakey = "sc_secs";
                schedularsetting.AddUpdateAppSettings(datakey, txtValue.Text.Trim());
                MessageBox.Show("Schedule time has been successfully Updated  (*v*)!!");
            }
            else if (txtKey.Text == smallsecs)
            {
                datakey = "sc_secs";
                schedularsetting.AddUpdateAppSettings(datakey, txtValue.Text.Trim());
                MessageBox.Show("Schedule time has been successfully Updated  (*v*)!!");
            }
            else if (txtKey.Text == smalls)
            {
                datakey = "sc_secs";
                schedularsetting.AddUpdateAppSettings(datakey, txtValue.Text.Trim());
                MessageBox.Show("Schedule time has been successfully Updated  (*v*)!!");
            }
            else if (txtKey.Text == bigS)
            {
                datakey = "sc_secs";
                schedularsetting.AddUpdateAppSettings(datakey, txtValue.Text.Trim());
                MessageBox.Show("Schedule time has been successfully Updated  (*v*)!!");
            }
            else if (txtKey.Text == capitaS)
            {
                datakey = "sc_secs";
                schedularsetting.AddUpdateAppSettings(datakey, txtValue.Text.Trim());
                MessageBox.Show("Schedule time has been successfully Updated  (*v*)!!");
            }
            else if (txtKey.Text == ALLcapitasec)
            {
                datakey = "sc_secs";
                schedularsetting.AddUpdateAppSettings(datakey, txtValue.Text.Trim());
                MessageBox.Show("Schedule time has been successfully Updated  (*v*)!!");
            }
        }
    }
}
