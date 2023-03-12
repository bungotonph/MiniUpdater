using System.Runtime.CompilerServices;
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.BTNClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.progressBar.ForeColor = System.Drawing.Color.Green;
            this.progressBar.Location = new System.Drawing.Point(0, 558);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(799, 31);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 1;
            // 
            // LabelVersionLatest
            // 
            this.LabelVersionLatest.AutoSize = true;
            this.LabelVersionLatest.BackColor = System.Drawing.Color.Transparent;
            this.LabelVersionLatest.ForeColor = System.Drawing.Color.White;
            this.LabelVersionLatest.Location = new System.Drawing.Point(563, 65);
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
            this.BTNCheckFiles.Location = new System.Drawing.Point(559, 531);
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
            this.BTNStart.BackgroundImage = global::GameUpdater.Properties.Resources.start_normal;
            this.BTNStart.Enabled = false;
            this.BTNStart.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BTNStart.FlatAppearance.BorderSize = 0;
            this.BTNStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.BTNStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.BTNStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTNStart.Location = new System.Drawing.Point(558, 434);
            this.BTNStart.Margin = new System.Windows.Forms.Padding(0);
            this.BTNStart.Name = "BTNStart";
            this.BTNStart.Size = new System.Drawing.Size(232, 96);
            this.BTNStart.TabIndex = 4;
            this.BTNStart.UseVisualStyleBackColor = false;
            this.BTNStart.BackColorChanged += new System.EventHandler(this.BTNStart_BackColor);
            this.BTNStart.BackgroundImageChanged += new System.EventHandler(this.BTNStart_BackColor);
            this.BTNStart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BTNStart_Click);
            this.BTNStart.MouseLeave += new System.EventHandler(this.BTNStart_MouseLeave);
            this.BTNStart.MouseHover += new System.EventHandler(this.BTNStart_MouseOver);
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
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(646, 88);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(152, 106);
            this.webBrowser1.TabIndex = 7;
            this.webBrowser1.Url = new System.Uri("http://localhost/game/web/sbajoquickfixclassifiedshieldcodeson.php", System.UriKind.Absolute);
            // 
            // BTNClose
            // 
            this.BTNClose.BackColor = System.Drawing.Color.Transparent;
            this.BTNClose.BackgroundImage = global::GameUpdater.Properties.Resources.close_normal;
            this.BTNClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BTNClose.FlatAppearance.BorderSize = 0;
            this.BTNClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNClose.Location = new System.Drawing.Point(769, 1);
            this.BTNClose.Name = "BTNClose";
            this.BTNClose.Size = new System.Drawing.Size(28, 17);
            this.BTNClose.TabIndex = 8;
            this.BTNClose.UseVisualStyleBackColor = false;
            this.BTNClose.Click += new System.EventHandler(this.BTNClose_Click);
            this.BTNClose.MouseEnter += new System.EventHandler(this.BTNClose_MouseEnter);
            this.BTNClose.MouseLeave += new System.EventHandler(this.BTNClose_MouseLeave);
            this.BTNClose.MouseHover += new System.EventHandler(this.BTNClose_MouseLeave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GameUpdater.Properties.Resources.Legion;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(799, 589);
            this.Controls.Add(this.BTNClose);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTNStart);
            this.Controls.Add(this.BTNCheckFiles);
            this.Controls.Add(this.LabelVersionLatest);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
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
        private System.Windows.Forms.WebBrowser webBrowser1;
        private Button BTNClose;
    }
}

