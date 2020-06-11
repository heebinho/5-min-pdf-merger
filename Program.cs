using System;
using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.IO;

namespace merger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Merging documents....");
            mergeDocs();
        }


        static void mergeDocs()
        {
            string[] files = new string[] { @"x.pdf", @"y.pdf" };
            PdfDocument outputDocument = new PdfDocument();

            foreach (string file in files)
            {
                PdfDocument inputDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import);

                int count = inputDocument.PageCount;
                for (int idx = 0; idx < count; idx++)
                {
                    PdfPage page = inputDocument.Pages[idx];
                    outputDocument.AddPage(page);
                }
            }

            const string filename = @"x-y.pdf";
            outputDocument.Save(filename);
            Console.WriteLine("done.");
        }
    }




}
