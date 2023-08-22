using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExportTable
{
    public static class Export
    {
        public static void ExportToPdf(DataTable dt, string strFilePath,DataTable dt2=null)
        {
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(strFilePath, FileMode.Create));
            document.Open();
            iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 5);

            PdfPTable table = new PdfPTable(dt.Columns.Count);
            PdfPRow row = null;
            float[] widths = new float[dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++)
                widths[i] = 4f;

            table.SetWidths(widths);

            table.WidthPercentage = 100;
            int iCol = 0;
            string colname = "";
            PdfPCell cell = new PdfPCell(new Phrase("Products"));

            cell.Colspan = dt.Columns.Count;

            foreach (DataColumn c in dt.Columns)
            {
                table.AddCell(new Phrase(c.ColumnName, font5));
            }

            foreach (DataRow r in dt.Rows)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int h = 0; h < dt.Columns.Count; h++)
                    {
                        table.AddCell(new Phrase(r[h].ToString(), font5));
                    }
                }
            }
            document.Add(table);

            if (dt2 != null)
            {
                PdfPTable table2 = new PdfPTable(dt2.Columns.Count);
                PdfPRow row2 = null;
                float[] widths2= new float[dt2.Columns.Count];
                for (int i = 0; i < dt2.Columns.Count; i++)
                    widths2[i] = 4f;

                table2.SetWidths(widths2);

                table2.WidthPercentage = 100;
                int iCol2 = 0;
                string colname2 = "";
                PdfPCell cell2 = new PdfPCell(new Phrase("Products"));

                cell2.Colspan = dt2.Columns.Count;

                foreach (DataColumn c in dt2.Columns)
                {
                    table2.AddCell(new Phrase(c.ColumnName, font5));
                }

                foreach (DataRow r in dt2.Rows)
                {
                    if (dt2.Rows.Count > 0)
                    {
                        for (int h = 0; h < dt2.Columns.Count; h++)
                        {
                            table2.AddCell(new Phrase(r[h].ToString(), font5));
                        }
                    }
                }
                document.Add(new Chunk("\n"));
                document.Add(table2);
            }


            document.Close();
        }
        public static bool ExportToExcel(this System.Data.DataTable DataTable, string ExcelFilePath, out string Error,DataTable dt2=null)
        {

            bool returnValue = false;
            Error = "";
            try
            {
                int ColumnsCount;

                if (DataTable == null || (ColumnsCount = DataTable.Columns.Count) == 0)
                {
                    Error = "Empty Table";
                    return false;
                }
                



                // load excel, and create a new workbook
                Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
                Excel.Workbooks.Add();

                // single worksheet
                Microsoft.Office.Interop.Excel._Worksheet Worksheet = Excel.ActiveSheet;

                object[] Header = new object[ColumnsCount];

                // column headings               
                for (int i = 0; i < ColumnsCount; i++)
                    Header[i] = DataTable.Columns[i].ColumnName;

                Microsoft.Office.Interop.Excel.Range HeaderRange = Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[1, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[1, ColumnsCount]));
                HeaderRange.Value = Header;
                //HeaderRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                HeaderRange.Font.Bold = true;

                // DataCells
                int RowsCount = DataTable.Rows.Count;
                object[,] Cells = new object[RowsCount, ColumnsCount];

                for (int j = 0; j < RowsCount; j++)
                    for (int i = 0; i < ColumnsCount; i++)
                        Cells[j, i] = DataTable.Rows[j][i];

                Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[2, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[RowsCount + 1, ColumnsCount])).Value = Cells;

                // check fielpath
                if (ExcelFilePath != null && ExcelFilePath != "")
                {
                    try
                    {
                        if (dt2 != null)
                        {

                            ColumnsCount = dt2.Columns.Count;


                            Header = new object[dt2.Columns.Count];

                            // column headings               
                            for (int i = 0; i < ColumnsCount; i++)
                                Header[i] = dt2.Columns[i].ColumnName;

                            HeaderRange = Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[DataTable.Rows.Count + 2, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[DataTable.Rows.Count + 2, ColumnsCount]));
                            HeaderRange.Value = Header;
                            //HeaderRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                            HeaderRange.Font.Bold = true;

                            // DataCells
                            RowsCount = dt2.Rows.Count;
                            Cells = new object[RowsCount, ColumnsCount];

                            for (int j = 0; j < RowsCount; j++)
                                for (int i = 0; i < ColumnsCount; i++)
                                    Cells[j, i] = dt2.Rows[j][i];

                            Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[DataTable.Rows.Count+3, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[DataTable.Rows.Count + 3, ColumnsCount])).Value = Cells;
                        }



                        Worksheet.SaveAs(ExcelFilePath);
                        Excel.Quit();
                        returnValue = true;
                        //System.Windows.MessageBox.Show("Excel file saved!");
                    }
                    catch (Exception ex)
                    {
                        Error = ex.Message;
                    }
                }
                else    // no filepath is given
                {
                    Excel.Visible = true;
                }
                
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }

            return returnValue;
        }
    }
}
