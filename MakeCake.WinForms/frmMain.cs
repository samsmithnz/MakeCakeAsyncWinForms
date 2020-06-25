using MakeCakeAsync;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeCake.WinForms
{
    public partial class frmMain : Form
    {
        SyncCake Cake1;
        int syncCount;

        public frmMain()
        {
            InitializeComponent();
        }

        //https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.backgroundworker?view=netcore-3.1
        private void btnRunTests_Click(object sender, EventArgs e)
        {
            txtSync.Text = "";
            txtAsync.Text = "";
            Cake1 = new SyncCake();
            syncCount = 0;

            //MakeCakeAsync.AsyncCake makeCake = new MakeCakeAsync.AsyncCake();

            BackgroundWorker syncWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true
            };
            syncWorker.DoWork += new DoWorkEventHandler(syncWorker_DoWork);
            syncWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(syncWorker_RunWorkerCompleted);
            syncWorker.ProgressChanged += new ProgressChangedEventHandler(syncWorker_ProgressChanged);

            BackgroundWorker asyncWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true
            };
            asyncWorker.DoWork += new DoWorkEventHandler(asyncWorker_DoWork);
            asyncWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(asyncWorker_RunWorkerCompleted);
            asyncWorker.ProgressChanged += new ProgressChangedEventHandler(asyncWorker_ProgressChanged);


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

            for (int i = 1; i <= 20; i++)
            {
                syncCount = i;
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    Cake1.MakeCake(i);
                    worker.ReportProgress((int)Math.Round((double)(100 * i) / 20));
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
            txtSync.Text = txtSync.Text + syncCount.ToString() + ". " + Cake1.CurrentStatus + Environment.NewLine;
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
                lblSync.Text = "Done!";
            }
        }

        // This event handler is where the time-consuming work is done.
        private void asyncWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            for (int i = 1; i <= 10; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    System.Threading.Thread.Sleep(500);
                    worker.ReportProgress(i * 10);
                }
            }
        }

        // This event handler updates the progress.
        private void asyncWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblAsync.Text = (e.ProgressPercentage.ToString() + "%");
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
                lblAsync.Text = "Done!";
            }
        }
    }
}
