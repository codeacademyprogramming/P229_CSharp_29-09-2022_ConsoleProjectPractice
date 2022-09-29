using CourseManagement.Enums;
using CourseManagement.Interfaces;
using CourseManagement.Models;
using CourseManagement.Services;
using System;

namespace CourseManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            ICourseService courseService = new CourseService();

            do
            {
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("Etmek Isdediyniz Emeliyyatin Nomresini Daxil Edin:");
                Console.WriteLine("1. Qrup Elave Et");
                Console.WriteLine("2. Qruplarin Siyahisini Gosder");
                Console.WriteLine("3. Telebe Elave Et");
                Console.WriteLine("4. Butun Telebelerin Siyahisini Gosder");
                Console.WriteLine("5. Qrup Uzerinde Deyisiklik Etmek");
                Console.WriteLine("6. Telebe Uzerinde Deyisiklik Etmek");
                string answerStr = Console.ReadLine();
                int answerNum;
                while (!int.TryParse(answerStr, out answerNum) || answerNum < 1 || answerNum > 6)
                {
                    Console.WriteLine("Duzgun Secim Edin:");
                    answerStr = Console.ReadLine();
                }

                switch (answerNum)
                {
                    case 1:
                        AddGroup(ref courseService);
                        break;
                    case 2:
                        ShowGroups(courseService);
                        break;
                    case 3:
                        AddStudent(ref courseService);
                        break;
                    case 4:
                        ShowAllStudent(courseService);
                        break;
                    case 5:
                        EditGroup(ref courseService);
                        break;
                    case 6:
                        EditStudent(ref courseService);
                        break;
                }
                
            } while (true);

            
        }

        static void AddGroup(ref ICourseService courseService)
        {
            Console.Clear();
            Console.WriteLine("Qrupun Limitini Daxil Et");
            string limitStr = Console.ReadLine();
            byte limit;
            while (!byte.TryParse(limitStr, out limit))
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Duzgun Limit Deyeri Daxil Et");
                limitStr = Console.ReadLine();
            }

            Console.WriteLine("Qrupun Novunu Sec Qarsisindaki Reqemi daxil Et");
            foreach (var item in Enum.GetValues(typeof(GroupType)))
            {
                Console.WriteLine($"{(int)item} {item}");
            }
            string groupTypeStr = Console.ReadLine();
            int groupTypeNum;
            while (!int.TryParse(groupTypeStr, out groupTypeNum) || groupTypeNum < 1 || groupTypeNum > 3)
            {
                Console.WriteLine("Duzgun Qrup Novunu Daxil Et Minimum 1 maksimum 3");
                groupTypeStr = Console.ReadLine();
            }

            courseService.AddGroup(limit, (GroupType)groupTypeNum);
            //Console.BackgroundColor = ConsoleColor.Green;
            //Console.ForegroundColor = ConsoleColor.White;
            //Console.WriteLine("Qrup Ugurla Elave Olundu");
        }

        static void ShowGroups(ICourseService courseService)
        {
            Console.Clear();
            foreach (Group group in courseService.Groups)
            {
                Console.WriteLine(group);
            }
        }

        static void AddStudent(ref ICourseService courseService)
        {
            if (courseService.Groups.Length <= 0)
            {
                Console.WriteLine("Once Qrup Elave Et");
                return;
            }

            Console.WriteLine("Siyahidan Telebeni Elave Etmek Isdediyin Qrupun Nomresini Daxil Et");
            ShowGroups(courseService);
            string groupNo = Console.ReadLine();
            while (!courseService.CheckGroupByNo(groupNo))
            {
                Console.WriteLine("Duzgun Qrup Nomresi Daxil Et");
                groupNo = Console.ReadLine();
            }
            Console.WriteLine("Telebenin Adini Daxil Et");
            string name = Console.ReadLine();

            Console.WriteLine("Telebenin SoyAdini daxil et");
            string surName = Console.ReadLine();

            Console.WriteLine("Telebenin Yasini daxil Et");
            string ageStr = Console.ReadLine();
            byte age;
            while (!byte.TryParse(ageStr, out age))
            {
                Console.WriteLine("Duzgun Yas Daxil Et");
                ageStr = Console.ReadLine();
            }

            Console.WriteLine("Telebenin Zemanet Novunu Sec");
            foreach (var item in Enum.GetValues(typeof(StudentType)))
            {
                Console.WriteLine($"{(int)item} {item}");
            }

            string studentTypeStr = Console.ReadLine();
            int studentTypeNum;
            while (!int.TryParse(studentTypeStr,out studentTypeNum) || studentTypeNum < 1 || studentTypeNum > 2)
            {
                Console.WriteLine("Duzgun Zemanen Novunu Daxil Et. Minimum 1 Maksimum 2");
                studentTypeStr = Console.ReadLine();
            }

            courseService.AddStudent(name, surName, age, (StudentType)studentTypeNum, groupNo);
           
        }

        static void ShowAllStudent(ICourseService courseService)
        {
            if(courseService.Groups.Length <= 0)
            {
                Console.WriteLine("Once Qrup Elave Et");
                return;
            }

            foreach (Group group in courseService.Groups)
            {
                foreach (Student student in group.Students)
                {
                    Console.WriteLine(student);
                }
            }
        }

        static void EditGroup(ref ICourseService courseService)
        {
            if (courseService.Groups.Length <= 0)
            {
                Console.WriteLine("Once Qrup yarat");
                return;
            }

            Console.WriteLine("Duzelis Etmek Isdediyin Qrupun Nomresini Daxil Et");
            ShowGroups(courseService);
            string groupNo = Console.ReadLine();
            while (!courseService.CheckGroupByNo(groupNo))
            {
                Console.WriteLine("Duzgun Qrup Nomresi Daxil Et");
                groupNo = Console.ReadLine();
            }

            Console.WriteLine("Qrupun Limitini Daxil Et");
            string limitStr = Console.ReadLine();
            byte limit;
            while (!byte.TryParse(limitStr, out limit))
            {
                Console.WriteLine("Duzgun Limit Deyeri Daxil Et");
                limitStr = Console.ReadLine();
            }

            Console.WriteLine("Qrupun Novunu Sec Qarsisindaki Reqemi daxil Et");
            foreach (var item in Enum.GetValues(typeof(GroupType)))
            {
                Console.WriteLine($"{(int)item} {item}");
            }
            string groupTypeStr = Console.ReadLine();
            int groupTypeNum;
            while (!int.TryParse(groupTypeStr, out groupTypeNum) || groupTypeNum < 1 || groupTypeNum > 3)
            {
                Console.WriteLine("Duzgun Qrup Novunu Daxil Et Minimum 1 maksimum 3");
                groupTypeStr = Console.ReadLine();
            }

            courseService.EditGroup(groupNo, (GroupType)groupTypeNum, limit);
        }

        static void EditStudent(ref ICourseService courseService)
        {
            if (courseService.Groups.Length <= 0)
            {
                Console.WriteLine("Once Qrup yarat");
                return;
            }

            Console.WriteLine("Duzelis Etmek Isdediyin Qrupun Nomresini Daxil Et");
            ShowGroups(courseService);
            string groupNo = Console.ReadLine();
            while (!courseService.CheckGroupByNo(groupNo))
            {
                Console.WriteLine("Duzgun Qrup Nomresi Daxil Et");
                groupNo = Console.ReadLine();
            }

            Student[] students = courseService.GetStudentsByGroupNo(groupNo);

            if (students == null || students.Length <= 0)
            {
                Console.WriteLine("Once Qrupa Telebe Elave Et");
                return;
            }

            Console.WriteLine("Duzelis Etmek Isdediyniz Telebenin Id-ni daxil Et");
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }

            string idStr = Console.ReadLine();
            int idNum;
            while (!int.TryParse(idStr,out idNum) || !courseService.CheckStudentById(idNum))
            {
                Console.WriteLine("Duzgun Telebe Id-si Daxil Et");
                idStr = Console.ReadLine();
            }

            Console.WriteLine("Telebenin Adini Daxil Et");
            string name = Console.ReadLine();

            Console.WriteLine("Telebenin SoyAdini daxil et");
            string surName = Console.ReadLine();

            Console.WriteLine("Telebenin Yasini daxil Et");
            string ageStr = Console.ReadLine();
            byte age;
            while (!byte.TryParse(ageStr, out age))
            {
                Console.WriteLine("Duzgun Yas Daxil Et");
                ageStr = Console.ReadLine();
            }

            Console.WriteLine("Telebenin Zemanet Novunu Sec");
            foreach (var item in Enum.GetValues(typeof(StudentType)))
            {
                Console.WriteLine($"{(int)item} {item}");
            }

            string studentTypeStr = Console.ReadLine();
            int studentTypeNum;
            while (!int.TryParse(studentTypeStr, out studentTypeNum) || studentTypeNum < 1 || studentTypeNum > 2)
            {
                Console.WriteLine("Duzgun Zemanen Novunu Daxil Et. Minimum 1 Maksimum 2");
                studentTypeStr = Console.ReadLine();
            }

            courseService.EditStudent(idNum, name, surName, age, (StudentType)studentTypeNum, groupNo);
        }
    }
}
