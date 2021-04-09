using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            Excel.Sheets sheets = workbook.Sheets;

            try
            {
                printWorksheetsName(workbook);

                foreach (Excel.Worksheet sheet in sheets)
                {
                    printWorksheetContents(sheet);
                }
            }
            catch(Exception ex)
            {
                
            }
            finally
            {
                if (sheets != null)
                {
                    Marshal.ReleaseComObject(sheets);
                    sheets = null;
                }

                if (workbook != null)
                {
                    workbook.Close(/*SaveChanges*/false);
                    Marshal.ReleaseComObject(workbook);
                    workbook = null;
                }

                if (excelApp != null)
                {
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                    excelApp = null;
                }

                GC.Collect();
            }
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
            printWorksheetName(worksheet);
            printRange(worksheet.UsedRange);
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

        static bool CheckValidation(Excel.Range range)
        {
            string subtitle1 = range.Rows[2].Cells[1].value;//순번
            string subtitle2 = range.Rows[2].Cells[2].value;//앱
            string subtitle3 = range.Rows[2].Cells[3].value;//상태
            string subtitle4 = range.Rows[2].Cells[4].value;//종류
            string subtitle5 = range.Rows[2].Cells[5].value;//제목
            string subtitle6 = range.Rows[2].Cells[6].value;//내용

            if (!(subtitle1 == "순번" && subtitle2 == "앱" && subtitle3 == "상태" &&
                  subtitle4 == "종류" && subtitle5 == "제목" && subtitle6 == "내용"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static Excel.Worksheet GetWorksheetbyName(Excel.Workbook workbook, string name)
        {
            foreach (Excel.Worksheet sheet in workbook.Worksheets)
            {
                if (sheet.Name == name)
                {
                    return sheet;
                }
            }

            return null;
        }
    }
}
