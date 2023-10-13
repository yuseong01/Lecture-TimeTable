using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.View
{
    internal class MenuView
    {
        public void PrintLogin()
        {
            Console.WriteLine("\n\n\n");
            Console.WriteLine("                    __   __  _     __ _____  __    __     __      ______  ______               ");
            Console.WriteLine("                   |  | |  || ＼  | ||_   _||  |  |  |   |  |    |_    _||_    _|                ");
            Console.WriteLine("                   |  | |  ||   ＼| |  | |  |  |  |  |   |  |      |  |    |  |                  ");
            Console.WriteLine("                   |  | |  ||  .  ` |  | |  |  |  |  |   |  |      |  |    |  |                  ");
            Console.WriteLine("                   |  |_|  ||  |＼  | _| |_ ＼ ＼_/  / _ |  |____  |  |    |  |                  ");
            Console.WriteLine("                   ＼_____/ ＼_|  ＼/|_____|  ＼____/ (_) ＼_____/ |__|    |__|                  \n\n\n\n");
            Console.WriteLine("                               [ 입력하려면 < ENTER > 를 눌러주세요]  §종료 :ESC \n\n\n");
            Console.WriteLine("                                 ╇  STUDENT ID(8 NUM)      :                                                    \n");
            Console.WriteLine("                                 ╇  PASSWORD(6-10 ENG&NUM) :                                                       \n\n\n\n\n");
        }
        public void PrintMenu()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("                    __   __  _     __ _____  __    __     __      ______  ______               ");
            Console.WriteLine("                   |  | |  || ＼  | ||_   _||  |  |  |   |  |    |_    _||_    _|                ");
            Console.WriteLine("                   |  | |  ||   ＼| |  | |  |  |  |  |   |  |      |  |    |  |                  ");
            Console.WriteLine("                   |  | |  ||  .  ` |  | |  |  |  |  |   |  |      |  |    |  |                  ");
            Console.WriteLine("                   |  |_|  ||  |＼  | _| |_ ＼ ＼/  / _  |  |____  |  |    |  |                  ");
            Console.WriteLine("                   ＼_____/ ＼_|  ＼/|_____|  ＼___/ (_) ＼_____/  |__|    |__|              \n");
            Console.WriteLine("                                                                      §뒤로가기 :ESC \n\n\n\n");
            Console.WriteLine("                                       ① 강의시간표 조회                                                             ");
            Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                       ② 관심과목 담기                                                             ");
            Console.WriteLine("                                                                                                  ");
            Console.WriteLine("                                       ③ 수강신청                  ");
            Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                       ④ 수강내역 조회                                                             \n\n\n");
            Console.Write("\n\n\n     [ Enter Menu Number ] ▶ ");
        }
        public void PrintInterestedLectureMenu()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("                    __   __  _     __ _____  __    __     __      ______  ______               ");
            Console.WriteLine("                   |  | |  || ＼  | ||_   _||  |  |  |   |  |    |_    _||_    _|                ");
            Console.WriteLine("                   |  | |  ||   ＼| |  | |  |  |  |  |   |  |      |  |    |  |                  ");
            Console.WriteLine("                   |  | |  ||  .  ` |  | |  |  |  |  |   |  |      |  |    |  |                  ");
            Console.WriteLine("                   |  |_|  ||  |＼  | _| |_ ＼ ＼/  / _  |  |____  |  |    |  |                  ");
            Console.WriteLine("                   ＼_____/ ＼_|  ＼/|_____|  ＼___/ (_) ＼_____/  |__|    |__|  \n");
            Console.WriteLine("                                                                      §뒤로가기 :ESC \n\n\n\n");
            Console.WriteLine("                                       ① 관심과목 추가                                                   ");
            Console.WriteLine("                                                                                                          ");
            Console.WriteLine("                                       ② 관심과목 내역                                                   ");
            Console.WriteLine("                                                                                                          ");
            Console.WriteLine("                                       ③ 관심과목 시간표                                                 ");
            Console.WriteLine("                                                                                                          ");
            Console.WriteLine("                                       ④ 관심과목 삭제                                             \n\n\n");
            Console.Write("\n\n\n     [ Enter Menu Number ] ▶ ");
        }
        public void PrintRegistrationLectureMenu()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("                    __   __  _     __ _____  __    __     __      ______  ______               ");
            Console.WriteLine("                   |  | |  || ＼  | ||_   _||  |  |  |   |  |    |_    _||_    _|                ");
            Console.WriteLine("                   |  | |  ||   ＼| |  | |  |  |  |  |   |  |      |  |    |  |                  ");
            Console.WriteLine("                   |  | |  ||  .  ` |  | |  |  |  |  |   |  |      |  |    |  |                  ");
            Console.WriteLine("                   |  |_|  ||  |＼  | _| |_ ＼ ＼/  / _  |  |____  |  |    |  |                  ");
            Console.WriteLine("                   ＼_____/ ＼_|  ＼/|_____|  ＼___/ (_) ＼_____/  |__|    |__| \n");
            Console.WriteLine("                                                                      §뒤로가기 :ESC \n\n\n\n\n");

            Console.WriteLine("                                       ① 수강신청                                                  ");
            Console.WriteLine("                                                                                                          ");
            Console.WriteLine("                                       ② 수강신청 내역                                                   ");
            Console.WriteLine("                                                                                                          ");
            Console.WriteLine("                                       ③ 수강신청 시간표                                                 ");
            Console.WriteLine("                                                                                                          ");
            Console.WriteLine("                                       ④ 수강과목 삭제                                             \n\n\n");
            Console.Write("\n\n\n     [ Enter Menu Number ] ▶ ");
        }
        public void PrintRegistrationCourseMenu()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("                    __   __  _     __ _____  __    __     __      ______  ______               ");
            Console.WriteLine("                   |  | |  || ＼  | ||_   _||  |  |  |   |  |    |_    _||_    _|                ");
            Console.WriteLine("                   |  | |  ||   ＼| |  | |  |  |  |  |   |  |      |  |    |  |                  ");
            Console.WriteLine("                   |  | |  ||  .  ` |  | |  |  |  |  |   |  |      |  |    |  |                  ");
            Console.WriteLine("                   |  |_|  ||  |＼  | _| |_ ＼ ＼/  / _  |  |____  |  |    |  |                  ");
            Console.WriteLine("                   ＼_____/ ＼_|  ＼/|_____|  ＼___/ (_) ＼_____/  |__|    |__|  \n");
            Console.WriteLine("                                                                      §뒤로가기 :ESC \n\n\n\n");

            Console.WriteLine("                                       ① 검색 후 신청                                                  ");
            Console.WriteLine("                                                                                                          ");
            Console.WriteLine("                                       ② 관심과목 신청                                                  ");
            Console.WriteLine("                                                                                                          ");
            Console.WriteLine("                                                                                       ");
            Console.WriteLine("                                                                                                          ");
            Console.WriteLine("                                                                                   \n\n\n");
            Console.Write("\n\n\n     [ Enter Menu Number ] ▶ ");
        }
    }
}
