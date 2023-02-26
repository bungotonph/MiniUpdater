using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
using SevenZip;
using System.Threading.Tasks;
using System.ComponentModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;
using System.Threading;
using System.Drawing;

namespace GameUpdater
{
    public partial class MainForm : Form
    {
        private const string FileHashesPath = "file_hashes.json";
        private const string FileHashesUrl = "http://51.79.158.143/game/file_hashes.json";
        private const string GameDir = ".";
        private const string GameUrl = "http://51.79.158.143/game/";
        private const string VersionUrl = "http://51.79.158.143/game/version.json";
        private const string ArchiveUrl = "http://51.79.158.143/game/cabalmain.7z";
        private const string ArchiveFilename = "cabalmain.7z";
        private readonly string ExtractPath = Path.Combine(Application.StartupPath, ".");
        private readonly string VersionFilePath = "version.json";
        private const string Password = "123";
        private System.Windows.Forms.Label lblServerStatus;

        //private string CurrentVersion;
        //private string LatestVersion;

        public MainForm()
        {
            InitializeComponent();

            lblServerStatus = new System.Windows.Forms.Label();
            lblServerStatus.Text = "Offline";
            lblServerStatus.AutoSize = true;
            lblServerStatus.Location = new Point(85, 10);

            // Add the Label control to the form's controls collection
            this.Controls.Add(lblServerStatus);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckForUpdates();
        }
        private void CheckForUpdates()
        {
            try
            {
                // Set the label's text to "Checking..."
                lblServerStatus.Text = "Checking...";

                // Update local file list from server
                UpdateLocalFileListFromServer();

                using (var client = new WebClient())
                {
                    // Download the latest version info
                    var latestVersionJson = client.DownloadString(VersionUrl);
                    var latestVersionInfo = JsonConvert.DeserializeObject<VersionInfo>(latestVersionJson);
                    // Set the label's text to "Online" if no exceptions are caught
                    lblServerStatus.Text = "Online";
                    lblServerStatus.ForeColor = Color.Green;

                    // Load the local version info
                    VersionInfo currentVersionInfo;
                    using (var file = File.OpenText(VersionFilePath))
                    {
                        var serializer = new JsonSerializer();
                        currentVersionInfo = (VersionInfo)serializer.Deserialize(file, typeof(VersionInfo));
                    }

                    // Compare versions and prompt to update if necessary
                    if (currentVersionInfo == null || currentVersionInfo.LatestVersion != latestVersionInfo.LatestVersion)
                    {
                        var result = MessageBox.Show($"An update is available (version {latestVersionInfo.LatestVersion}). Would you like to download and install it now?",
                            "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            // Download and extract game archive
                            DownloadAndExtractGameArchive();
                            currentVersionInfo = latestVersionInfo;

                            // Save the updated version info to local file
                            using (var file = File.CreateText(VersionFilePath))
                            {
                                var serializer = new JsonSerializer();
                                serializer.Serialize(file, currentVersionInfo);
                            }
                        }
                    }
                    else
                    {   progressBar.Value = 100;
                        LabelVersionLatest.Text = $"You have the latest version ({currentVersionInfo.LatestVersion}).";
                        BTNStart.Enabled = true;
                        BTNCheckFiles.Enabled = false;
                        //_ = MessageBox.Show($"You have the latest version (version {currentVersionInfo.LatestVersion}).",
                        //        "No Update Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {        
                // Set the label's text to "Offline" if an exception is caught
                lblServerStatus.Text = "Offline";
                lblServerStatus.ForeColor = Color.Red;
                MessageBox.Show($"Failed to check for updates: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DownloadAndExtractGameArchive()
        {
            try
            {
                // Create a temporary file to store the downloaded archive
                string tempFilePath = Path.Combine(Path.GetTempPath(), ArchiveFilename);

                // Download the archive
                using (var client = new WebClient())
                {
                    client.DownloadFile(ArchiveUrl, tempFilePath);
                }

                // Extract the archive
                SevenZipBase.SetLibraryPath(Path.Combine(Application.StartupPath, "7z.dll"));
                SevenZipExtractor extractor = new SevenZipExtractor(tempFilePath, Password);

                extractor.Extracting += (sender, e) =>
                {
                    progressBar.Invoke((MethodInvoker)delegate { progressBar.Value = (int)((double)e.PercentDone / 100 * 100); });
                    LabelVersionLatest.Invoke((MethodInvoker)delegate { LabelVersionLatest.Text = "Extracting game files... " + e.PercentDone.ToString() + "%"; });
                };

                extractor.ExtractArchive(ExtractPath);

                // Delete the temporary archive file
                File.Delete(tempFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateLocalFileListFromServer()
        {
            try
            {
                using (var client = new WebClient())
                {
                    // Download the file hashes JSON from the server
                    var fileHashesJson = client.DownloadString(FileHashesUrl);

                    // Deserialize the JSON array of file hashes into a List<FileHash>
                    var fileHashes = JsonConvert.DeserializeObject<List<FileHash>>(fileHashesJson);

                    // Loop through each file hash and check if it exists locally and if it has been modified
                    foreach (var fileHash in fileHashes)
                    {
                        var filePath = Path.Combine(GameDir, fileHash.Path);

                        if (File.Exists(filePath))
                        {
                            var localFileHash = HashGenerator.GenerateHash(filePath);

                            if (localFileHash != fileHash.Hash)
                            {
                                // File has been modified, replace with new version
                                File.Delete(filePath);
                                client.DownloadFile(Path.Combine(GameUrl, fileHash.Path), filePath);
                            }
                        }
                        else
                        {
                            // File does not exist, download it
                            client.DownloadFile(Path.Combine(GameUrl, fileHash.Path), filePath);
                        }
                    }

                    // Write updated file hashes to local file
                    var updatedFileHashesJson = JsonConvert.SerializeObject(fileHashes, Formatting.Indented);
                    var tempFileHashesPath = FileHashesPath + ".tmp"; // use a temp file to avoid file locking issues
                    File.WriteAllText(tempFileHashesPath, updatedFileHashesJson);
                    File.Replace(tempFileHashesPath, FileHashesPath, null); // replace original file with temp file
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show($"Failed to update local file list from server: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTNCheckFiles_Click(object sender, EventArgs e)
        {
            try
            {
                // Set the label's text to "Checking..."
                lblServerStatus.Text = "Checking...";

                // Update local file list from server
                UpdateLocalFileListFromServer();
                BTNStart.Enabled = false;

                using (var client = new WebClient())
                {
                    // Download the latest version info
                    var latestVersionJson = client.DownloadString(VersionUrl);
                    var latestVersionInfo = JsonConvert.DeserializeObject<VersionInfo>(latestVersionJson);

                    // Set the label's text to "Online" if no exceptions are caught
                    lblServerStatus.Text = "Online";
                    lblServerStatus.ForeColor = Color.Green;

                    // Load the local version info
                    VersionInfo currentVersionInfo;
                    using (var file = File.OpenText(VersionFilePath))
                    {
                        var serializer = new JsonSerializer();
                        currentVersionInfo = (VersionInfo)serializer.Deserialize(file, typeof(VersionInfo));
                    }

                    // Compare versions and prompt to update if necessary
                    if (currentVersionInfo == null || currentVersionInfo.LatestVersion != latestVersionInfo.LatestVersion)
                    {
                        var result = MessageBox.Show($"An update is available (version {latestVersionInfo.LatestVersion}). Would you like to download and install it now?",
                            "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            // Download and extract game archive
                            DownloadAndExtractGameArchive();
                            currentVersionInfo = latestVersionInfo;

                            // Save the updated version info to local file
                            using (var file = File.CreateText(VersionFilePath))
                            {
                                var serializer = new JsonSerializer();
                                serializer.Serialize(file, currentVersionInfo);
                            }
                        }
                    }
                    else
                    {
                        progressBar.Value = 100;
                        LabelVersionLatest.Text = $"You have the latest version ({currentVersionInfo.LatestVersion}).";
                        BTNStart.Enabled = true;
                        BTNCheckFiles.Enabled = false;
                        //_ = MessageBox.Show($"You have the latest version (version {currentVersionInfo.LatestVersion}).",
                        //        "No Update Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                // Set the label's text to "Online" if no exceptions are caught
                lblServerStatus.Text = "Offline";
                lblServerStatus.ForeColor = Color.Red;
                MessageBox.Show($"Failed to check for updates: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class VersionInfo
    {
        public string LatestVersion { get; set; }
    }
    public class FileHash
    {
        public string Path { get; set; }
        public string Hash { get; set; }
    }

}
