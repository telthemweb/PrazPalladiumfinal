using Sagehill_Pallaium_Intergration_module.Integration_testing_v2;
using Sagehill_Pallaium_Intergration_module.Tech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Sagehill_Pallaium_Intergration_module
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /// for QuickPost Data [Tech/PostData.cs
            /// so far we are working with quick post file in Tech folder;
            /// I decided to created two setup so that we dont conflict with main form on time.
            /// So if want to rebuild make you comment on like what i did below

            /// ***************************************************************************

            //Application.Run(new PostData());

            /// for Main Form

            /// ***************************************************************************   

            //Application.Run(new MainForm());


            //Integration Testing
            Application.Run(new InterTestingPrazPalladium_v2());
        }
    }
}
