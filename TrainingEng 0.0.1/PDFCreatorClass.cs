using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        //Метод создания документа
        private void CreateDocument()
        {

            //Создаём новый пустой документ
            this.document = new Document();

            //Объявляем стили документа
            DefineStyles();

            //Создаем элементы страницы документа
            CreatePage();

            //Заполняем документ данными
            FillContent();

            MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToFile(document, "MigraDoc.mdddl");

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
            renderer.Document = document;

            renderer.RenderDocument();

            //Сохраняем документ
            String filename = Globals.CurrentDirFormater() + "\\Report\\" + this.FileName;
            renderer.PdfDocument.Save(filename);

            //Запускаем просмотрщик PDF-файлов
            Process.Start(filename);

        }

        //Выставление форматирование и задание общего стиля для PDF-документа
        private void DefineStyles()
        {

            MigraDoc.DocumentObjectModel.Style style = this.document.Styles["Normal"];
            style.Font.Name = "Verdana";

            style = this.document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = this.document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            style = this.document.Styles.AddStyle("Table", "Normal");
            style.Font.Name = "Verdana";
            style.Font.Name = "Times New Roman";
            style.Font.Size = 9;

            style = this.document.Styles.AddStyle("Reference", "Normal");
            style.ParagraphFormat.SpaceBefore = "5mm";
            style.ParagraphFormat.SpaceAfter = "5mm";
            style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right);
        }

        //Объявление и создание основных элементов таблицы
        private void CreatePage()
        {
            // Добавляем новую секцию в документе
            Section section = this.document.AddSection();

            // Объявляем подвал-footer
            Paragraph paragraph = section.Footers.Primary.AddParagraph();
            paragraph.AddText("Eadyical 2020");
            paragraph.Format.Font.Size = 9;
            paragraph.Format.Alignment = ParagraphAlignment.Center;

            // Данные выше таблицы
            paragraph = section.AddParagraph();
            paragraph.Format.SpaceBefore = "8cm";
            paragraph.Style = "Reference";
            paragraph.AddFormattedText("Результаты пользователя " + this.UserName, TextFormat.Bold);
            paragraph.AddTab();
            paragraph.AddText("Дата формирования отчета: ");
            paragraph.AddDateField("dd.MM.yyyy");

            // Создаем таблицу
            this.table = section.AddTable();
            this.table.Style = "Table";
            this.table.Borders.Width = 0.25;
            this.table.Borders.Left.Width = 0.5;
            this.table.Borders.Right.Width = 0.5;
            this.table.Rows.LeftIndent = 0;

            // Объявляем размеры колонок таблицы
            Column column = this.table.AddColumn("4cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = this.table.AddColumn("4cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = this.table.AddColumn("4cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = this.table.AddColumn("4cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            //Добавляем колонки
            Row row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;

            //Объявляем названия колонок
            row.Cells[0].AddParagraph("№ класса");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].MergeDown = 1;

            row.Cells[1].AddParagraph("№ темы");
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].MergeDown = 1;

            row.Cells[2].AddParagraph("Кол-во правильных ответов");
            row.Cells[2].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[2].MergeDown = 1;

            row.Cells[3].AddParagraph("Дата/время");
            row.Cells[3].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[3].MergeDown = 1;

        }

        //Заполнение таблицы данными
        private void FillContent()
        {
            //Добавление колонки из-за объединенных колонок
            this.table.AddRow();
            for (int i = 0; i < ResultsList.Count; i++)
            {
                UserResultsClass thisResult = ResultsList[i];
                Row row = this.table.AddRow();
                row.Cells[0].AddParagraph(thisResult.classId);
                row.Cells[1].AddParagraph(thisResult.topicId);
                row.Cells[2].AddParagraph(thisResult.points);
                row.Cells[3].AddParagraph(thisResult.time);
            }

        }


    }


}
