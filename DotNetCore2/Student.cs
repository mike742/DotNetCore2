using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore2
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalMarks { get; set; }

        public static List<Student> LoadData()
        {
            List<Student> list = new List<Student>();

            list.Add(new Student() { Id = 101, Name = "Lucy", TotalMarks = 1020 });
            list.Add(new Student() { Id = 102, Name = "Mark", TotalMarks = 1008 });
            list.Add(new Student() { Id = 103, Name = "Rosy", TotalMarks = 1025 });

            return list;
        }
    }
}
