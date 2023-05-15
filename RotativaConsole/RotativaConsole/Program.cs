﻿using System.IO;
using System;
using System.Reflection;

namespace RotativaConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            string htmlFile = Path.Combine(currentDirectory, "File", "test.html");

            string pdfFile = Path.Combine(currentDirectory, "File", "test.pdf");

            string workingDirectory = Path.Combine(currentDirectory, "Rotativa");

            string html = File.ReadAllText(htmlFile);

            byte[] pdfByteArr = WkhtmltopdfDriver.ConvertHtml(workingDirectory, "", html);

            File.WriteAllBytes(pdfFile, pdfByteArr);

            Console.WriteLine("Pdf Created");
        }
    }
}