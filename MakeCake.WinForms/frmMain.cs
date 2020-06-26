using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MakeCake.WinForms
{
    public partial class frmMain : Form
    {
        private DateTime startTime;
        private int totalItems = 9;
        private SyncCake Cake1;
        private int syncCount;
        private AsyncCake Cake2;
        private int asyncCount;


        public frmMain()
        {
            InitializeComponent();
        }

        //https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.backgroundworker?view=netcore-3.1
        private void btnRunTests_Click(object sender, EventArgs e)
        {
            txtSync.Text = "";
            txtAsync.Text = "";
            startTime = DateTime.Now;
            Cake1 = new SyncCake();
            syncCount = 0;
            Cake2 = new AsyncCake();
            asyncCount = 0;

            //MakeCakeAsync.AsyncCake makeCake = new MakeCakeAsync.AsyncCake();

            //Prepare the sync worker
            BackgroundWorker syncWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true
            };
            syncWorker.DoWork += new DoWorkEventHandler(syncWorker_DoWork);
            syncWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(syncWorker_RunWorkerCompleted);
            syncWorker.ProgressChanged += new ProgressChangedEventHandler(syncWorker_ProgressChanged);

            //Prepare the async working
            BackgroundWorker asyncWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true
            };
            asyncWorker.DoWork += new DoWorkEventHandler(asyncWorker_DoWork);
            asyncWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(asyncWorker_RunWorkerCompleted);
            asyncWorker.ProgressChanged += new ProgressChangedEventHandler(asyncWorker_ProgressChanged);

            //Run the tasks!
            if (syncWorker.IsBusy == false && asyncWorker.IsBusy == false)
            {
                syncWorker.RunWorkerAsync();
                asyncWorker.RunWorkerAsync();
            }
        }


        // This event handler is where the time-consuming work is done.
        private void syncWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            for (int i = 1; i <= totalItems; i++)
            {
                syncCount = i;
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    worker.ReportProgress((int)Math.Round((double)(100 * i) / totalItems));
                    Cake1.MakeCake(i);
                    //// Perform a time consuming operation and report progress.
                    //System.Threading.Thread.Sleep(500);
                    //worker.ReportProgress(i * 10);
                }
            }
        }

        // This event handler updates the progress.
        private void syncWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblSync.Text = (e.ProgressPercentage.ToString() + "%");
            txtSync.Text += syncCount.ToString() + "/" + totalItems.ToString() + ". " + Cake1.CurrentStatus + ", " + DateTime.Now.ToString("hh:mm:sstt");
            if (syncCount < totalItems)
            {
                txtSync.Text += Environment.NewLine;
            }
        }

        // This event handler deals with the results of the background operation.
        private void syncWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                lblSync.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                lblSync.Text = "Error: " + e.Error.Message;
            }
            else
            {
                TimeSpan timespan = (DateTime.Now - startTime);
                lblSync.Text = "Done in " + timespan.TotalHours.ToString("00") + ":" + timespan.TotalMinutes.ToString("00") + ":" + timespan.TotalSeconds.ToString("00");
            }
        }

        // This event handler is where the time-consuming work is done.
        private void asyncWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            for (int i = 1; i <= totalItems; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    Cake2.MakeCakeAsync(i);
                    worker.ReportProgress((int)Math.Round((double)(100 * i) / totalItems));
                    //// Perform a time consuming operation and report progress.
                    //System.Threading.Thread.Sleep(500);
                    //worker.ReportProgress(i * 10);
                }
            }
        }

        // This event handler updates the progress.
        private void asyncWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblAsync.Text = (e.ProgressPercentage.ToString() + "%");
            txtAsync.Text += asyncCount.ToString() + "/" + totalItems.ToString() + ". " + Cake2.CurrentStatus + ", " + DateTime.Now.ToString("hh:mm:sstt");
            if (asyncCount < totalItems)
            {
                txtAsync.Text += Environment.NewLine;
            }
        }

        // This event handler deals with the results of the background operation.
        private void asyncWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                lblAsync.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                lblAsync.Text = "Error: " + e.Error.Message;
            }
            else
            {
                TimeSpan timespan = (DateTime.Now - startTime);
                lblAsync.Text = "Done in " + timespan.TotalHours.ToString("00") + ":" + timespan.TotalMinutes.ToString("00") + ":" + timespan.TotalSeconds.ToString("00");

            }
        }
    }
}
