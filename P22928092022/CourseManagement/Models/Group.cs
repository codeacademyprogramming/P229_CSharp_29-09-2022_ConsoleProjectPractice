using CourseManagement.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Models
{
    class Group
    {
        static int _no;
        public string No;
        public byte Limit;
        public GroupType GroupType;

        public Student[] Students;

        static Group()
        {
            _no = 100;
        }

        public Group(byte limit, GroupType groupType)
        {
            Students = new Student[0];
            Limit = limit;
            GroupType = groupType;
            _no++;
            No = $"{GroupType.ToString()[0]}{_no}";
        }

        public override string ToString()
        {
            return $"{No} {GroupType} {Limit}";
        }
    }
}
