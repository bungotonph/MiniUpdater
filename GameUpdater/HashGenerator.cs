using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GameUpdater
{
    public static class HashGenerator
    {
        public static string GenerateHash(string filePath)
        {
            try
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (var reader = new StreamReader(stream))
                {
                    var content = reader.ReadToEnd();
                    using (var sha256 = SHA256.Create())
                    {
                        var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(content));
                        return BitConverter.ToString(hash).Replace("-", "").ToLower();
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"I/O exception occurred while reading file: {e.Message}");
                return null;
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine($"Access denied while reading file: {e.Message}");
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error occurred while generating hash: {e.Message}");
                return null;
            }
        }
    }
}