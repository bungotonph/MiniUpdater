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
            this.label1 = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar.ForeColor = System.Drawing.Color.Green;
            this.progressBar.Location = new System.Drawing.Point(0, 0);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(397, 12);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 1;
            // 
            // LabelVersionLatest
            // 
            this.LabelVersionLatest.AutoSize = true;
            this.LabelVersionLatest.BackColor = System.Drawing.Color.Transparent;
            this.LabelVersionLatest.ForeColor = System.Drawing.Color.Black;
            this.LabelVersionLatest.Location = new System.Drawing.Point(12, 183);
            this.LabelVersionLatest.Name = "LabelVersionLatest";
            this.LabelVersionLatest.Size = new System.Drawing.Size(0, 13);
            this.LabelVersionLatest.TabIndex = 2;
            // 
            // BTNCheckFiles
            // 
            this.BTNCheckFiles.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BTNCheckFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNCheckFiles.FlatAppearance.BorderSize = 0;
            this.BTNCheckFiles.Location = new System.Drawing.Point(320, 176);
            this.BTNCheckFiles.Margin = new System.Windows.Forms.Padding(0);
            this.BTNCheckFiles.Name = "BTNCheckFiles";
            this.BTNCheckFiles.Size = new System.Drawing.Size(72, 23);
            this.BTNCheckFiles.TabIndex = 3;
            this.BTNCheckFiles.Text = "Check Files";
            this.BTNCheckFiles.UseVisualStyleBackColor = false;
            this.BTNCheckFiles.Click += new System.EventHandler(this.BTNCheckFiles_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Server Status:";
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.StartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartButton.FlatAppearance.BorderSize = 0;
            this.StartButton.Location = new System.Drawing.Point(260, 125);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(132, 50);
            this.StartButton.TabIndex = 9;
            this.StartButton.Text = "P L A Y";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(397, 205);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTNCheckFiles);
            this.Controls.Add(this.LabelVersionLatest);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mini Updater";
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
        private System.Windows.Forms.Label label1;
        private Button StartButton;
    }
}

