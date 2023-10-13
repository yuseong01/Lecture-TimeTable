using LTT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;


namespace LTT.Utility
{
    class LectureLoader
    {
        public LectureLoader()
        {

        }

        private string GetNullString(object str)
        {
            if(str == null)
            {
                return "";
            }    

            return str.ToString();
        }

        public void LoadExcel(LectureStudentData lectureStudentData)
        {
            try
            {
                // Excel Application 객체 생성
                Excel.Application application = new Excel.Application();

                // Workbook 객체 생성 및 파일 오픈 (바탕화면에 있는 excelStudy.xlsx 가져옴)
                Excel.Workbook workbook = application.Workbooks.Open(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\2023년도 1학기 강의시간표.xlsx");

                // sheets에 읽어온 엑셀값을 넣기 (한 workbook 내의 모든 sheet 가져옴)
                Excel.Sheets sheets = workbook.Sheets;

                // 특정 sheet의 값 가져오기
                Excel.Worksheet worksheet = sheets["Sheet1"] as Excel.Worksheet;

                // 범위 설정 (좌측 상단, 우측 하단)
                Excel.Range cellRange = worksheet.get_Range("A2", "L185") as Excel.Range;

                // 설정한 범위만큼 데이터 담기 (Value2 -셀의 기본 값 제공)
                Array data = cellRange.Cells.Value2;

                // 데이터 출력
                for (int i = 1; i <= 184; i++)
                {
                    string[] list = new string[12];
                    
                    for (int j = 1; j <= 12; j++)
                    {
                        list[j - 1] = GetNullString(data.GetValue(i, j));
                    }

                    Lectures lectures = new Lectures(int.Parse(list[0]), list[1], int.Parse(list[2]), list[3], list[4], list[5], int.Parse(list[6]), int.Parse(list[7]), list[8], list[9], list[10], list[11]);

                    lectureStudentData.LectureList.Add(lectures);
                }


                // 모든 워크북 닫기
                application.Workbooks.Close();

                // application 종료
                application.Quit();
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
