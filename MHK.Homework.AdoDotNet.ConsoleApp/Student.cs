using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHK.Homework.AdoDotNet.ConsoleApp
{
    public class Student
    {
        public int Id { get; set; }

        public required string SNumber { get; set; }

        public required string Name { get; set; }

        public required string FatherName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public required string Gender { get; set; }

        public required string MobileNumber { get; set; }

        public bool DeleteFlag { get; set; }
    }
}
