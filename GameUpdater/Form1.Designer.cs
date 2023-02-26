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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.LabelVersionLatest = new System.Windows.Forms.Label();
            this.BTNCheckFiles = new System.Windows.Forms.Button();
            this.BTNStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 68);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(356, 23);
            this.progressBar.TabIndex = 1;
            // 
            // LabelVersionLatest
            // 
            this.LabelVersionLatest.AutoSize = true;
            this.LabelVersionLatest.Location = new System.Drawing.Point(37, 42);
            this.LabelVersionLatest.Name = "LabelVersionLatest";
            this.LabelVersionLatest.Size = new System.Drawing.Size(0, 13);
            this.LabelVersionLatest.TabIndex = 2;
            // 
            // BTNCheckFiles
            // 
            this.BTNCheckFiles.Location = new System.Drawing.Point(241, 112);
            this.BTNCheckFiles.Name = "BTNCheckFiles";
            this.BTNCheckFiles.Size = new System.Drawing.Size(127, 33);
            this.BTNCheckFiles.TabIndex = 3;
            this.BTNCheckFiles.Text = "Check Files";
            this.BTNCheckFiles.UseVisualStyleBackColor = true;
            this.BTNCheckFiles.Click += new System.EventHandler(this.BTNCheckFiles_Click);
            // 
            // BTNStart
            // 
            this.BTNStart.Enabled = false;
            this.BTNStart.Location = new System.Drawing.Point(241, 151);
            this.BTNStart.Name = "BTNStart";
            this.BTNStart.Size = new System.Drawing.Size(127, 33);
            this.BTNStart.TabIndex = 4;
            this.BTNStart.Text = "Start";
            this.BTNStart.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Server Status:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 207);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTNStart);
            this.Controls.Add(this.BTNCheckFiles);
            this.Controls.Add(this.LabelVersionLatest);
            this.Controls.Add(this.progressBar);
            this.Name = "MainForm";
            this.Text = "Legion Launcher";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label LabelVersionLatest;
        private System.Windows.Forms.Button BTNCheckFiles;
        private System.Windows.Forms.Button BTNStart;
        private System.Windows.Forms.Label label1;
    }
}

