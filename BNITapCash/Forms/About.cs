using System;
using System.Windows.Forms;

namespace BNITapCash.Forms
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            txtVersion.Text = Properties.Resources.VersionApp;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start(Properties.Resources.DeveloperURL);
        }

        private void txtVersion_Click(object sender, EventArgs e)
        {

        }

        private void About_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AppName_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
