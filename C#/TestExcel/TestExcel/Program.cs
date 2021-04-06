using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace TestExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Open(@"D:\Repo\helloworld\C#\TestExcel\통합 문서1.xlsx");

            printWorksheetsName(workbook);

            foreach (Excel.Worksheet sheet in workbook.Sheets)
            {
                printWorksheetContents(sheet);
            }

            workbook.Close(/*SaveChanges*/false);
            excelApp.Quit();
        }

        static void printWorksheetsName(Excel.Workbook workbook)
        {
            int i = 0;
            foreach (Excel.Worksheet sheet in workbook.Sheets)
            {
                Console.WriteLine($"Sheet{++i} is \"{sheet.Name}\"");
            }
        }

        static void printWorksheetName(Excel.Worksheet worksheet)
        {
            Console.WriteLine($"Current Sheet is \"{worksheet.Name}\"");
        }

        static void printWorksheetContents(Excel.Worksheet worksheet)
        {
            //Excel.Range usedRange = worksheet.UsedRange;
            

            printWorksheetName(worksheet);
            printRange(worksheet.UsedRange);
            //Console.WriteLine($" usedRange.RowHeight = {usedRange.Cells[1][1].value}");
            //Console.WriteLine($" usedRange. = {usedRange.Cells[1][1].value}");
            //foreach (worksheet.UsedRange)
            //Console.WriteLine($" worksheet.Cells[0][0] = \"{worksheet.Cells[1][1].value}\"");

            //Console.WriteLine($" worksheet.Cells[0][0] = \"{worksheet.Cells[1][1].value}\"");

            //int i = 0;
            //foreach (Excel.Worksheet sheet in worksheet.Cells[0][0])
            //{
            //    Console.WriteLine($"Sheet{++i} is \"{sheet.Name}\"");
            //}
        }

        /// <summary>
        /// Range의 범위를 출력. UsedRange 값을 넘겨주세요
        /// </summary>
        /// <param name="range">UsedRange</param>
        static void printRange(Excel.Range range)
        {
            Console.WriteLine($" Range.Rows.Count = {range.Rows.Count}");
            Console.WriteLine($" Range.Colums.Count = {range.Columns.Count}");

            //int rowCount = range.Rows.Count;//17
            //int columnCount = range.Columns.Count;//4

            foreach(Excel.Range row in range.Rows)
            {
                foreach (Excel.Range cell in row.Cells)
                {
                    Console.Write($"{cell.Cells[1].value}, ");
                }
                Console.WriteLine("");
            }
        }

        static void DeleteObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                Console.WriteLine("메모리 할당을 해제하는 중 문제가 발생하였습니다: " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
