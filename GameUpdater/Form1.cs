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

namespace GameUpdater
{
    public partial class MainForm : Form
    {
        private const string FileHashesPath = "file_hashes.json";
        private const string FileHashesUrl = "http://localhost/game/file_hashes.json";
        private const string GameUrl = "http://localhost/game/data";
        private const string VersionUrl = "http://localhost/game/version.json";
        private const string ArchiveUrl = "http://localhost/game/cabalmain.7z";
        private const string ArchiveFilename = "cabalmain.7z";
        private readonly string ExtractPath = Path.Combine(Application.StartupPath, ".");
        private string VersionFilePath = "version.json";
        private const string Password = "123";

        //private string CurrentVersion;
        //private string LatestVersion;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckForUpdates();
        }

        private void CheckForUpdates()
        {
            try
            {   
                // Update local file list from server
                UpdateLocalFileListFromServer();

                using (var client = new WebClient())
                {
                    // Download the latest version info
                    var latestVersionJson = client.DownloadString(VersionUrl);
                    var latestVersionInfo = JsonConvert.DeserializeObject<VersionInfo>(latestVersionJson);

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
                        MessageBox.Show($"You have the latest version (version {currentVersionInfo.LatestVersion}).",
                            "No Update Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
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
                //SevenZip.SevenZipExtractor extractor = new SevenZip.SevenZipExtractor(tempFilePath);
                //extractor.ExtractArchive(ExtractPath);

                using (var archive = new SevenZipExtractor(tempFilePath, Password))
                {
                    archive.ExtractArchive(ExtractPath);
                }

                // Delete the temporary archive file
                File.Delete(tempFilePath);

                MessageBox.Show($"Game updated successfully.", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    var fileHashesJson = client.DownloadString(FileHashesUrl);
                    var fileHashes = JsonConvert.DeserializeObject<List<FileHash>>(fileHashesJson);

                    foreach (var fileHash in fileHashes)
                    {
                        var filePath = Path.Combine(ExtractPath, fileHash.Path);

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
                    File.WriteAllText(FileHashesPath, updatedFileHashesJson);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update local file list from server: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }

    public class VersionInfo
    {
        public string LatestVersion { get; set; }
        public List<FileInfo> Files { get; set; }
    }
    public class FileHash
    {
        public string Path { get; set; }
        public string Hash { get; set; }
    }

}
