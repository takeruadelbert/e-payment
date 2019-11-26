using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BNITapCash.Forms
{
    public partial class Loading : Form
    {
        public Action Worker
        {
            get;
            set;
        }
        public Loading(Action worker)
        {
            InitializeComponent();
            if (worker == null)
                throw new ArgumentException();
            Worker = worker;
        }

        private void Loading_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
