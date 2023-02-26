using System.Windows.Forms;

namespace GameUpdater
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.LabelVersionLatest = new System.Windows.Forms.Label();
            this.BTNCheckFiles = new System.Windows.Forms.Button();
            this.BTNStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BTNClose = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.progressBar.ForeColor = System.Drawing.Color.Green;
            this.progressBar.Location = new System.Drawing.Point(24, 501);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(609, 31);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 1;
            // 
            // LabelVersionLatest
            // 
            this.LabelVersionLatest.AutoSize = true;
            this.LabelVersionLatest.BackColor = System.Drawing.Color.Transparent;
            this.LabelVersionLatest.ForeColor = System.Drawing.Color.White;
            this.LabelVersionLatest.Location = new System.Drawing.Point(21, 543);
            this.LabelVersionLatest.Name = "LabelVersionLatest";
            this.LabelVersionLatest.Size = new System.Drawing.Size(0, 13);
            this.LabelVersionLatest.TabIndex = 2;
            // 
            // BTNCheckFiles
            // 
            this.BTNCheckFiles.AutoSize = true;
            this.BTNCheckFiles.BackColor = System.Drawing.Color.Transparent;
            this.BTNCheckFiles.BackgroundImage = global::GameUpdater.Properties.Resources.cf_normal;
            this.BTNCheckFiles.FlatAppearance.BorderSize = 0;
            this.BTNCheckFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNCheckFiles.Location = new System.Drawing.Point(646, 537);
            this.BTNCheckFiles.Margin = new System.Windows.Forms.Padding(0);
            this.BTNCheckFiles.Name = "BTNCheckFiles";
            this.BTNCheckFiles.Size = new System.Drawing.Size(66, 19);
            this.BTNCheckFiles.TabIndex = 3;
            this.BTNCheckFiles.UseVisualStyleBackColor = false;
            this.BTNCheckFiles.Click += new System.EventHandler(this.BTNCheckFiles_Click);
            this.BTNCheckFiles.MouseEnter += new System.EventHandler(this.BTNCF_MouseEnter);
            this.BTNCheckFiles.MouseLeave += new System.EventHandler(this.BTNCF_MouseOver);
            this.BTNCheckFiles.MouseHover += new System.EventHandler(this.BTNCF_MouseOver);
            // 
            // BTNStart
            // 
            this.BTNStart.AutoSize = true;
            this.BTNStart.BackColor = System.Drawing.Color.Transparent;
            this.BTNStart.BackgroundImage = global::GameUpdater.Properties.Resources.startover;
            this.BTNStart.Enabled = false;
            this.BTNStart.FlatAppearance.BorderSize = 0;
            this.BTNStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNStart.Location = new System.Drawing.Point(646, 490);
            this.BTNStart.Margin = new System.Windows.Forms.Padding(0);
            this.BTNStart.Name = "BTNStart";
            this.BTNStart.Size = new System.Drawing.Size(136, 44);
            this.BTNStart.TabIndex = 4;
            this.BTNStart.UseVisualStyleBackColor = false;
            this.BTNStart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BTNStart_Click);
            this.BTNStart.MouseEnter += new System.EventHandler(this.BTNStart_MouseEnter);
            this.BTNStart.MouseLeave += new System.EventHandler(this.BTNStart_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Server Status:";
            // 
            // BTNClose
            // 
            this.BTNClose.Location = new System.Drawing.Point(712, 12);
            this.BTNClose.Name = "BTNClose";
            this.BTNClose.Size = new System.Drawing.Size(75, 23);
            this.BTNClose.TabIndex = 6;
            this.BTNClose.Text = "X";
            this.BTNClose.UseVisualStyleBackColor = true;
            this.BTNClose.Click += new System.EventHandler(this.BTNClose_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(1, 88);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(797, 386);
            this.webBrowser1.TabIndex = 7;
            this.webBrowser1.Url = new System.Uri("http://sbajo.net/game/web/sbajoquickfixclassifiedshieldcodeson.php", System.UriKind.Absolute);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GameUpdater.Properties.Resources.PHLauncher;
            this.ClientSize = new System.Drawing.Size(799, 604);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.BTNClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTNStart);
            this.Controls.Add(this.BTNCheckFiles);
            this.Controls.Add(this.LabelVersionLatest);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Legion Launcher";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label LabelVersionLatest;
        private System.Windows.Forms.Button BTNCheckFiles;
        private System.Windows.Forms.Button BTNStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTNClose;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}

