using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string dirOriginal = @"C:/Original.pdf";
            string novoPdf = @"C:\Nova.pdf";
            var pdfr = new PdfReader(dirOriginal);

            Document doc = new Document(PageSize.LETTER);
            Document.Compress = true;

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(novoPdf, FileMode.Create));
            doc.Open();

            PdfImportedPage page;

            for (int i = 1; i < pdfr.NumberOfPages + 1; i++)
            {
                page = writer.GetImportedPage(pdfr, i);
                writer.DirectContent.AddTemplate(page, PageSize.LETTER.Width / pdfr.GetPageSize(i).Width, 0, 0, PageSize.LETTER.Height  / pdfr.GetPageSize(i).Height , 0, 10);
                doc.NewPage();
            }

            doc.Close();
        }
    }
}
