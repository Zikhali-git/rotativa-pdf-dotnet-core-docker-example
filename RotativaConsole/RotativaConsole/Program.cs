using System.IO;
using System;
using System.Reflection;

namespace RotativaConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string resourceName = "RotativaConsole.File.test.html";
            string fileContents = ReadEmbeddedResource(resourceName);




            string currentDirectory = Directory.GetCurrentDirectory();

            //string htmlFile = Path.Combine(currentDirectory, "File", "test.html");

            //string pdfFile = Path.Combine(currentDirectory, "File", "test.pdf");

            string workingDirectory = Path.Combine(currentDirectory, "Rotativa");

            //string html = File.ReadAllText(htmlFile);

            byte[] pdfByteArr = WkhtmltopdfDriver.ConvertHtml("C:\\Projects\\RotativaConsole\\RotativaConsole\\Rotativa", "", fileContents);

            File.WriteAllBytes("RotativaConsole.File", pdfByteArr);

            Console.WriteLine("Pdf Created");
        }

        static string ReadEmbeddedResource(string resourceName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }

            return "Resource not found.";
        }
    }
}