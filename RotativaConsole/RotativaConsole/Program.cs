using System.IO;
using System;
using System.Reflection;
using RotativaIO.NetCore;

namespace RotativaConsole
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var pdfBytes = ConvertHtmlToPdf();

            var pdfUrl = await GetRotativaIOPdfUrl();


            Console.WriteLine("Pdf Created");
        }

        public static byte[] ConvertHtmlToPdf()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            string htmlFile = Path.Combine(currentDirectory, "File", "test.html");

            string pdfFile = Path.Combine(currentDirectory, "File", "test.pdf");

            string workingDirectory = Path.Combine(currentDirectory, "Rotativa");

            string html = File.ReadAllText(htmlFile);

            byte[] pdfByteArr = WkhtmltopdfDriver.ConvertHtml(workingDirectory, "", html);

            File.WriteAllBytes(pdfFile, pdfByteArr);

            return pdfByteArr;
        }

        // Example from github repo @https://github.com/RotativaHQ/rotativaio.netcore/tree/master
        public static async Task<string> GetRotativaIOPdfUrl()
        {
            var cli = new RotativaioClient("3b8626bf9ad74c98b7f641a8e668e1db", "https://eunorth.rotativahq.com");
            var res = await cli.GetPdfUrl("", "<b>Ciao</b>", "", "", "", "");
            return res;
        }
    }
}