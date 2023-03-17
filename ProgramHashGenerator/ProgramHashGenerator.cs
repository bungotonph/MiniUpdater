using Newtonsoft.Json;
using System.Security.Cryptography;

class ProgramHashGenerator
{

    static void Main(string[] args)
    {
        // Define the root directory to search for files
        //string rootDirectory = Directory.GetCurrentDirectory() + "\\GameUpdate";

        // Create a dictionary to store the file names and their hash values
        //Dictionary<string, string> fileHashes = new Dictionary<string, string>();

        /*
        // Recursively search for all files in the root directory and its subdirectories
        foreach (string filePath in Directory.EnumerateFiles(rootDirectory, "*", SearchOption.AllDirectories))
        {
            // Compute the hash value for the file
            string hash = ComputeFileHash(filePath);

            // Add the file name and hash value to the dictionary
            string relativePath = GetRelativePath(filePath, rootDirectory);
            fileHashes[relativePath] = hash;
        }*/

        /*
        var fileHashes = new List<FileHash>();
        //Updated
        foreach (string file in Directory.GetFiles(rootDirectory, "*", SearchOption.AllDirectories))
        {
            var relativePath = GetRelativePath(file, rootDirectory);
            var hash = HashGenerator.GenerateHash(file);

            fileHashes.Add(new FileHash
            {
                Path = relativePath,
                Hash = hash
            });
        }

        // Serialize the dictionary as JSON and write it to a file
        string json = JsonConvert.SerializeObject(fileHashes, Formatting.Indented);
        string filePath = Path.Combine(rootDirectory, "file_hashes.json");
        File.WriteAllText(filePath, json);
        */

        // Define the root directory to search for files
        string rootDirectory = Directory.GetCurrentDirectory() + "\\GameUpdate";

        var fileHashes = new List<FileHash>();

        // Get all files in the root directory and its subdirectories
        var allFiles = Directory.GetFiles(rootDirectory, "*", SearchOption.AllDirectories);

        foreach (string file in allFiles)
        {
            if (file.EndsWith("file_hashes.json"))
            {
                continue;
            }

            if (file.EndsWith("version.json"))
            {
                continue;
            }

            var relativePath = GetRelativePath(file, rootDirectory);

            if (relativePath.StartsWith("updates"))
            {
                continue;
            }

            var hash = HashGenerator.GenerateHash(file);

            fileHashes.Add(new FileHash
            {
                Path = relativePath,
                Hash = hash
            });
        }

        // Add the NumFiles property to the first line of the JSON file
        string json = JsonConvert.SerializeObject(new { NumFiles = allFiles.Length - 3, FileHashes = fileHashes }, Formatting.Indented);

        string filePath = Path.Combine(rootDirectory, "file_hashes.json");
        File.WriteAllText(filePath, json);
    }

    // Computes the SHA256 hash of a file
    static string ComputeFileHash(string filePath)
    {
        using (var sha256 = SHA256.Create())
        {
            using (var stream = File.OpenRead(filePath))
            {
                byte[] hashBytes = sha256.ComputeHash(stream);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }

    // Gets the relative path of a file with respect to a root directory
    static string GetRelativePath(string filePath, string rootDirectory)
    {
        Uri fileUri = new Uri(filePath);
        Uri rootUri = new Uri(rootDirectory + Path.DirectorySeparatorChar);
        return rootUri.MakeRelativeUri(fileUri).ToString();
    }
}

public class VersionInfo
{
    public string? LatestVersion { get; set; }
    public List<FileInfo>? Files { get; set; }
}
public class FileHash
{
    public string? Path { get; set; }
    public string? Hash { get; set; }
}