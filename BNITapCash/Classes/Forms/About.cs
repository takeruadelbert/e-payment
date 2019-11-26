using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using BNITapCash.Interface;
using EPaymentUpdater;

namespace BNITapCash.Forms
{
    public partial class About : Form, IApplicationUpdateable, EventFormHandler
    {
        public About()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            //txtVersion.Text = Properties.Resources.VersionApp;
            txtVersion.Text = ApplicationAssembly.GetName().Version.ToString();            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start(Properties.Resources.DeveloperURL);
        }

        private void About_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            UnsubscribeEvents();
            Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCheckUpdate_Click(object sender, EventArgs e)
        {
            ApplicationUpdater updater = new ApplicationUpdater(this);
            updater.DoUpdate();
        }

        public void UnsubscribeEvents()
        {
            linkLabel1.LinkClicked -= linkLabel1_LinkClicked;

            btnCheckUpdate.Click -= btnCheckUpdate_Click;
            button1.Click -= button1_Click_1;
            button2.Click -= button2_Click;
        }

        public string ApplicationName
        {
            get { return "epayment"; }
        }

        public string ApplicationID
        {
            get { return "epayment"; }
        }

        public Assembly ApplicationAssembly
        {
            get { return Assembly.GetExecutingAssembly(); }
        }

        public Icon ApplicationIcon
        {
            get { return this.Icon; }
        }

        public Uri UpdateXmlLocation
        {
            get { return new Uri("https://www.dropbox.com/s/xcrb3pio6bu6dra/update.xml?dl=1"); }
        }

        public Form Context
        {
            get { return this; }
        }
    }
}
