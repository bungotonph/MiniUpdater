using System;
using System.Net;
using System.IO;

namespace WebServer
{
    public class WebServer
    {
        private HttpListener listener;
        private string rootDirectory;

        public WebServer(string rootDirectory)
        {
            this.rootDirectory = rootDirectory;
            listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:80/");
            listener.Start();
        }

        public void Run()
        {
            Console.WriteLine("Web server running. Press any key to stop.");
            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                HttpListenerContext context = listener.GetContext();
                ProcessRequest(context);
            }
            listener.Stop();
        }

        private void ProcessRequest(HttpListenerContext context)
        {
            string filename = Path.GetFileName(context.Request.RawUrl);
            string filepath = Path.Combine(rootDirectory, filename);

            if (filename == "" || !File.Exists(filepath))
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Response.Close();
                return;
            }

            byte[] buffer = File.ReadAllBytes(filepath);
            context.Response.ContentType = GetMimeType(filepath);
            context.Response.ContentLength64 = buffer.Length;
            context.Response.OutputStream.Write(buffer, 0, buffer.Length);
            context.Response.OutputStream.Close();
        }

        private string GetMimeType(string filepath)
        {
            string extension = Path.GetExtension(filepath);
            switch (extension.ToLower())
            {
                case ".htm":
                case ".html":
                    return "text/html";
                case ".css":
                    return "text/css";
                case ".js":
                    return "application/javascript";
                case ".png":
                    return "image/png";
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".gif":
                    return "image/gif";
                default:
                    return "application/octet-stream";
            }
        }
    }
}
