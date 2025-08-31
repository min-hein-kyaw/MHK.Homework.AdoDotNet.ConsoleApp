using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHK.Homework.AdoDotNet.ConsoleApp
{
    public class EntityFrameWorkServices
    {
        AppDbContext db = new AppDbContext();

        public void Read()
        {
            List<StudentDto> lst = db.Students.ToList();
            foreach (StudentDto student in lst)
            {
                Console.WriteLine($"{student.SNumber} - {student.Name} ");
            }
        }
        public void Create()
        {
            StudentDto stud = new StudentDto()
            {
                SNumber = "S004",
                Name = "Student 004",
                FatherName = " U Maung",
                Gender = "M",
                MobileNumber = "0934256",
                DateOfBirth = new DateTime(2000, 1, 1),
            };

            db.Students.Add(stud);
            int result = db.SaveChanges();
            Console.WriteLine($"{result} rows affected");
        }
        public void Update()
        {
            StudentDto edit = db.Students.Where(x => x.Id == 2).FirstOrDefault();
            if (edit != null)
            {
                edit.Name = "Ghost";
                int results = db.SaveChanges();
                Console.WriteLine($"{results} rows affected");
            }
        }
        public void Delete()
        {
            StudentDto delete = db.Students.Where(x => x.Id == 6).FirstOrDefault();
            if (delete != null)
            {
                db.Students.Remove(delete);
                int results = db.SaveChanges();
                Console.WriteLine($"{results} rows affected");
            }
            Console.ReadLine();
        }
    }
}
