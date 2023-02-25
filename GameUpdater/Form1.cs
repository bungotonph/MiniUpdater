using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;
using SevenZip;

namespace GameUpdater
{
    public partial class MainForm : Form
    {
        private const string VersionUrl = "http://localhost/game/version.json";
        private const string ArchiveUrl = "http://localhost/game/cabalmain.7z";
        private const string ArchiveFilename = "cabalmain.7z";
        private readonly string ExtractPath = Path.Combine(Application.StartupPath, ".");
        private string VersionFilePath = "version.json";
        private const string Password = "123";

        private string CurrentVersion;
        private string LatestVersion;

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
                SevenZip.SevenZipBase.SetLibraryPath(Path.Combine(Application.StartupPath, "7z.dll"));
                //SevenZip.SevenZipExtractor extractor = new SevenZip.SevenZipExtractor(tempFilePath);
                //extractor.ExtractArchive(ExtractPath);

                using (var archive = new SevenZipExtractor(tempFilePath, Password))
                {
                    archive.ExtractArchive(ExtractPath);
                }

                // Delete the temporary archive file
                File.Delete(tempFilePath);

                MessageBox.Show($"Update complete (version {LatestVersion}).", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class VersionInfo
    {
        public string LatestVersion { get; set; }
    }
}
