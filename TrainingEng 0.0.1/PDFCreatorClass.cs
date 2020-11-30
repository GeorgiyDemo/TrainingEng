using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TrainingEng_0._0._1
{
    class PDFCreatorClass
    {
        private String FileName;
        private String FileContent;
        public PDFCreatorClass(String FileName, String FileContent)
        {
            this.FileName = FileName;
            this.FileContent = FileContent;

            //Запускаем создание PDF
            this.Processing();
        }
        private void Processing()
        {
            PdfDocument document = new PdfDocument();

            // Create an empty page
            PdfPage page = document.AddPage();

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Create a font
            XFont font = new XFont("Verdana", 20, XFontStyle.Bold);

            // Draw the text
            gfx.DrawString(this.FileContent, font, XBrushes.Black,
              new XRect(0, 0, page.Width, page.Height), XStringFormat.Center);

            // Save the document...
            String FilePath = Globals.CurrentDirFormater() + "\\Report\\" + this.FileName;
            document.Save(FilePath);
            // ...and start a viewer.
            Process.Start(FilePath);
        }
    }


}
