namespace MakeCake.WinForms
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRunTests = new System.Windows.Forms.Button();
            this.lblSync = new System.Windows.Forms.Label();
            this.lblAsync = new System.Windows.Forms.Label();
            this.txtSync = new System.Windows.Forms.TextBox();
            this.txtAsync = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnRunTests
            // 
            this.btnRunTests.Location = new System.Drawing.Point(13, 13);
            this.btnRunTests.Name = "btnRunTests";
            this.btnRunTests.Size = new System.Drawing.Size(150, 46);
            this.btnRunTests.TabIndex = 0;
            this.btnRunTests.Text = "Run tests";
            this.btnRunTests.UseVisualStyleBackColor = true;
            this.btnRunTests.Click += new System.EventHandler(this.btnRunTests_Click);
            // 
            // lblSync
            // 
            this.lblSync.AutoSize = true;
            this.lblSync.Location = new System.Drawing.Point(13, 66);
            this.lblSync.Name = "lblSync";
            this.lblSync.Size = new System.Drawing.Size(63, 32);
            this.lblSync.TabIndex = 1;
            this.lblSync.Text = "Sync";
            // 
            // lblAsync
            // 
            this.lblAsync.AutoSize = true;
            this.lblAsync.Location = new System.Drawing.Point(459, 66);
            this.lblAsync.Name = "lblAsync";
            this.lblAsync.Size = new System.Drawing.Size(76, 32);
            this.lblAsync.TabIndex = 2;
            this.lblAsync.Text = "Async";
            // 
            // txtSync
            // 
            this.txtSync.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSync.Location = new System.Drawing.Point(13, 102);
            this.txtSync.Multiline = true;
            this.txtSync.Name = "txtSync";
            this.txtSync.Size = new System.Drawing.Size(420, 684);
            this.txtSync.TabIndex = 3;
            // 
            // txtAsync
            // 
            this.txtAsync.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAsync.Location = new System.Drawing.Point(459, 102);
            this.txtAsync.Multiline = true;
            this.txtAsync.Name = "txtAsync";
            this.txtAsync.Size = new System.Drawing.Size(420, 684);
            this.txtAsync.TabIndex = 3;
            // 
            // frmMain
            // 
            this.ClientSize = new System.Drawing.Size(891, 798);
            this.Controls.Add(this.txtAsync);
            this.Controls.Add(this.txtSync);
            this.Controls.Add(this.lblAsync);
            this.Controls.Add(this.lblSync);
            this.Controls.Add(this.btnRunTests);
            this.Name = "frmMain";
            this.Text = "Sync/ Async testing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRunTests;
        private System.Windows.Forms.Label lblSync;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSync;
        private System.Windows.Forms.TextBox txtAsync;
        private System.Windows.Forms.Label lblAsync;
    }
}

