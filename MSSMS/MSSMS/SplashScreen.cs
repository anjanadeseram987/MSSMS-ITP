using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace MSSMS
{
    public partial class SplashScreen : Form
    {
        //
        // Summary:
        //     counter variable for timer to determine the splashscreen visible time
        int counter = 0;

        public SplashScreen()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //setting version infomation automatically
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            this.versionLabel.Text = String.Format(this.versionLabel.Text, version.Major, version.Minor, version.Build, version.Revision);
        }

        //
        // Summary:
        //     Show splash screen for about 4 seconds everytime the app starts
        private void SplashTimer_Tick(object sender, EventArgs e)
        {
            counter++;
            if (counter >= 200)
            {
                SplashTimer.Enabled = false;
                this.Hide();
                LoginScreen login = new LoginScreen();
                login.Show();
            }

        }
    }
}
