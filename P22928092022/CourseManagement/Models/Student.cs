using CourseManagement.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Models
{
    class Student
    {
        static int _s_Id;
        public readonly int Id;
        public string Name;
        public string SurName;
        public byte Age;

        public string GroupNo;
        public StudentType StudentType;

        static Student()
        {
            _s_Id = 0;
        }

        public Student(string name, string surname, byte age, string groupNo, StudentType studentType)
        {
            _s_Id++;
            Id = _s_Id;
            Name = name;
            SurName = surname;
            Age = age;
            GroupNo = groupNo.ToUpper();
            StudentType = studentType;
        }

        public override string ToString()
        {
            return $"{Id} {Name} {SurName} {GroupNo}";
        }
    }
}
