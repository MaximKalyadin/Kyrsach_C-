using System;
using System.Collections.Generic;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using FactoryFurnitureBusinessLogic.HelperModel;
using FactoryFurnitureBusinessLogic.ViewModel;
using System.ComponentModel;

namespace FactoryFurnitureBusinessLogic.BusinessLogic
{
    static class SaveToPdf
    {
        public static void CreateDoc(PdfInfo info)
        {
            Document document = new Document();
            DefineStyles(document);
            Section section = document.AddSection();
            Paragraph paragraph = section.AddParagraph(info.Title);
            paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Style = "Normal";
            Paragraph date = section.AddParagraph("Дата : " + info.Date.ToShortDateString());
            date.Format.SpaceAfter = "1cm";
            date.Format.Alignment = ParagraphAlignment.Left;
            date.Style = "Normal";
            var table = document.LastSection.AddTable();
            table.Format.Alignment = ParagraphAlignment.Center;
            List<string> columns = new List<string> { "4cm", "4cm", "4cm"};
            int Count = 0;
            foreach (var elem in columns)
            {
                table.AddColumn(elem);
            }
            CreateRow(new PdfRowParameters
            {
                Table = table,
                Texts = new List<string> { "", "Заявки поматериалам",  "" },
                Style = "NormalTitle",
                ParagraphAlignment = ParagraphAlignment.Center
            });
            CreateRow(new PdfRowParameters
            {
                Table = table,
                Texts = new List<string> { "Заявки", "Материалы", "Количество" },
                Style = "NormalTitle",
                ParagraphAlignment = ParagraphAlignment.Center
            });
            foreach (var ms in info.Request)
            {
                CreateRow(new PdfRowParameters
                {
                    Table = table,
                    Texts = new List<string> { ms.RequestName, ms.MaterialName, ms.Count.ToString() },
                    Style = "Normal",
                    ParagraphAlignment = ParagraphAlignment.Left
                });
                Count += ms.Count;
            }
            CreateRow(new PdfRowParameters
            {
                Table = table,
                Texts = new List<string> { "Общее количество", "", Count.ToString() },
                Style = "NormalTitle",
                ParagraphAlignment = ParagraphAlignment.Center
            });
            Count = 0;
            CreateRow(new PdfRowParameters
            {
                Table = table,
                Texts = new List<string> { "", "Мебель по материалам", "" },
                Style = "NormalTitle",
                ParagraphAlignment = ParagraphAlignment.Center
            });
            CreateRow(new PdfRowParameters
            {
                Table = table,
                Texts = new List<string> { "Мебель", "Материалы", "Количество" },
                Style = "NormalTitle",
                ParagraphAlignment = ParagraphAlignment.Center
            }); 
            foreach (var ms in info.Furniture)
            {
                CreateRow(new PdfRowParameters
                {
                    Table = table,
                    Texts = new List<string> {ms.FurnitureName, ms.MaterialName, ms.Count.ToString() },
                    Style = "Normal",
                    ParagraphAlignment = ParagraphAlignment.Left
                });
                Count += ms.Count;
            }
            CreateRow(new PdfRowParameters
            {
                Table = table,
                Texts = new List<string> { "Общее количество", "", Count.ToString() },
                Style = "NormalTitle",
                ParagraphAlignment = ParagraphAlignment.Center
            });
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always)
            {
                Document = document
            };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(info.FileName);
        }

        private static void DefineStyles(Document document)
        {
            Style style = document.Styles["Normal"];
            style.Font.Name = "Times New Roman";
            style.Font.Size = 10;
            style = document.Styles.AddStyle("NormalTitle", "Normal");
            style.Font.Bold = true;
        }

        private static void CreateRow(PdfRowParameters rowParameters)
        {
            Row row = rowParameters.Table.AddRow();
            for (int i = 0; i < rowParameters.Texts.Count; ++i)
            {
                FillCell(new PdfCellParameters
                {
                    Cell = row.Cells[i],
                    Text = rowParameters.Texts[i],
                    Style = rowParameters.Style,
                    BorderWidth = 0.1,
                    ParagraphAlignment = rowParameters.ParagraphAlignment
                });
            }
        }
        /// <summary>
        /// Заполнение ячейки
        /// </summary>
        /// <param name="cellParameters"></param>
       private static void FillCell(PdfCellParameters cellParameters)
        {
            cellParameters.Cell.AddParagraph(cellParameters.Text);
            if (!string.IsNullOrEmpty(cellParameters.Style))
            {
                cellParameters.Cell.Style = cellParameters.Style;
            }
            cellParameters.Cell.Borders.Left.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Borders.Right.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Borders.Top.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Borders.Bottom.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Format.Alignment = cellParameters.ParagraphAlignment;
            cellParameters.Cell.VerticalAlignment = VerticalAlignment.Center;
        }
    }
}
