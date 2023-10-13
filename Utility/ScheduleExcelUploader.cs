using LTT.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace LTT.Utility
{
    class ScheduleExcelUploader
    {
        LectureStudentData data;

        public ScheduleExcelUploader(LectureStudentData data) 
        {
            this.data = data;
        }
        public void UploadSchedule(int userIndex, string[,] timetable)
        {
            DateTime dt;
            string timeString = "08:00";
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string path = Path.Combine(desktopPath, "2023년 시간표.xlsx");

                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = workbook.Worksheets.get_Item(1) as Excel.Worksheet;

                worksheet.Cells[1, 2] = "월";
                worksheet.Cells[1, 3] = "화";
                worksheet.Cells[1, 4] = "수";
                worksheet.Cells[1, 5] = "목";
                worksheet.Cells[1, 6] = "금";

                for(int i=2; i<29; i++)
                {
                    worksheet.Cells[i,1] = timeString;
                    dt=DateTime.ParseExact(timeString, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                    timeString = dt.AddMinutes(30).ToString("HH:mm");
                }
                
                for(int i=2; i < data.StudentList[userIndex].LectureRegistrationList.Count; i++)
                {
                    for(int j=2; j<7; j++)
                    {
                        worksheet.Cells[i, j] = timetable[i-2,j-2];
                    }
                }
                worksheet.Columns.AutoFit();
                workbook.SaveAs(path, Excel.XlFileFormat.xlWorkbookDefault);
                workbook.Close(true);
                excelApp.Quit();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
