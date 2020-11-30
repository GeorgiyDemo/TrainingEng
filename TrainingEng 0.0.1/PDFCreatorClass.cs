using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
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
        
        private Table table;
        private Document document;
        private String FileName;
        private String UserName;
        private List<UserResultsClass> ResultsList;

        public PDFCreatorClass(String FileName, String UserName, List<UserResultsClass> ResultsList)
        {
            this.FileName = FileName;
            this.UserName = UserName;
            this.ResultsList = ResultsList;
            this.CreateDocument();
        }

        private void CreateDocument()
        {

            // Create a new MigraDoc document
            this.document = new Document();
            this.document.Info.Title = "A sample invoice";
            this.document.Info.Subject = "Demonstrates how to create an invoice.";
            this.document.Info.Author = "Stefan Lange";

            DefineStyles();

            CreatePage();

            FillContent();

            //string ddl = MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToString(document);
            MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToFile(document, "MigraDoc.mdddl");

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
            renderer.Document = document;

            renderer.RenderDocument();

            // Save the document...
            String filename = Globals.CurrentDirFormater() + "\\Report\\" + this.FileName;
            renderer.PdfDocument.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);

        }

        private void DefineStyles()
        {
            // Get the predefined style Normal.
            MigraDoc.DocumentObjectModel.Style style = this.document.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Verdana";

            style = this.document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = this.document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            // Create a new style called Table based on style Normal
            style = this.document.Styles.AddStyle("Table", "Normal");
            style.Font.Name = "Verdana";
            style.Font.Name = "Times New Roman";
            style.Font.Size = 9;

            // Create a new style called Reference based on style Normal
            style = this.document.Styles.AddStyle("Reference", "Normal");
            style.ParagraphFormat.SpaceBefore = "5mm";
            style.ParagraphFormat.SpaceAfter = "5mm";
            style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right);
        }

        private void CreatePage()
        {
            // Each MigraDoc document needs at least one section.
            Section section = this.document.AddSection();

            // Create footer
            Paragraph paragraph = section.Footers.Primary.AddParagraph();
            paragraph.AddText("PowerBooks Inc · Sample Street 42 · 56789 Cologne · Germany");
            paragraph.Format.Font.Size = 9;
            paragraph.Format.Alignment = ParagraphAlignment.Center;

            // Add the print date field
            paragraph = section.AddParagraph();
            paragraph.Format.SpaceBefore = "8cm";
            paragraph.Style = "Reference";
            paragraph.AddFormattedText("Результаты пользователя "+this.UserName, TextFormat.Bold);
            paragraph.AddTab();
            paragraph.AddText("Cologne, ");
            paragraph.AddDateField("dd.MM.yyyy");

            // Create the item table
            this.table = section.AddTable();
            this.table.Style = "Table";
            this.table.Borders.Width = 0.25;
            this.table.Borders.Left.Width = 0.5;
            this.table.Borders.Right.Width = 0.5;
            this.table.Rows.LeftIndent = 0;

            // Before you can add a row, you must define the columns
            Column column = this.table.AddColumn("3.5cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = this.table.AddColumn("3.5cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = this.table.AddColumn("3.5cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = this.table.AddColumn("3.5cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = this.table.AddColumn("3.5cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            Row row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;

            row.Cells[0].AddParagraph("№ класса");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].MergeDown = 1;

            row.Cells[1].AddParagraph("№ темы");
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].MergeDown = 1;

            row.Cells[2].AddParagraph("Кол-во правильных ответов");
            row.Cells[2].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[2].MergeDown = 1;

            row.Cells[3].AddParagraph("ФИО");
            row.Cells[3].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[3].MergeDown = 1;

            row.Cells[4].AddParagraph("Дата/время");
            row.Cells[4].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[4].MergeDown = 1;

        }


        //TODO CHECK
        private void FillContent()
        {

            for (int i=0;i< ResultsList.Count; i++)
            {
                UserResultsClass thisResult = ResultsList[i];
                Row row = this.table.AddRow();
                row.Cells[0].AddParagraph(thisResult.classId);
                row.Cells[1].AddParagraph(thisResult.topicId);
                row.Cells[2].AddParagraph(thisResult.points);
                row.Cells[3].AddParagraph(thisResult.username);
                row.Cells[4].AddParagraph(thisResult.time);
            }

        }


    }


}
