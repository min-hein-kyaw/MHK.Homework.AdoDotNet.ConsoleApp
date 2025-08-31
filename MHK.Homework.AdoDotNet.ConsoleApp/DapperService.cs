using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
namespace MHK.Homework.AdoDotNet.ConsoleApp
{
    public class DapperService
    {
        private SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "MHKDotNetTrainingInPersonBatch1",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public void Read()
        {
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            db.Open();
            List<Student> lst = db.Query<Student>(@"select * from Student
where deleteFlag = 0").ToList(); 
            //dynamic but don't want so pass a class in <dynamic> -> <Student>
            //for (int i = 0; i < lst.Count; i++)
            //{
            //    Student item = lst[i];
            //    Console.WriteLine($"{i+1} {item.SNumber} - {item.Name}");
            //}
            int id = 1;
            foreach (Student item in lst)
            {
                Console.WriteLine($"{id} {item.SNumber} - {item.Name}");
                id++;
            }
        }

        public void Create()
        {
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            db.Open();
            int results = db.Execute(@"INSERT INTO [dbo].[Student]
                           ([sNumber]
                           ,[name]
                           ,[fatherName]
                           ,[DateOfBirth]
                           ,[gender]
                           ,[mobileNumber]
                           ,[deleteFlag])
                     VALUES
                           (
		                   '00007',
		                   'Ying',
		                   'Wan',
		                   '2000-12-06',
		                   'female',
		                   '09123456',
		                   0
		   

		                   )");
            Console.WriteLine($"{results} rows affected");
        }
        public void Update()
        {
            using IDbConnection db = new SqlConnection( sqlConnectionStringBuilder.ConnectionString);
            db.Open();
            int results = db.Execute(@"UPDATE [dbo].[Student]
                                   SET [sNumber] = '99999'
                                      ,[name] = 'Blah Blah Blah'
      
                                 WHERE Id = 2");
            Console.WriteLine($"{results} rows affected");
        }

        public void Delete()
        {
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            db.Open();
            int results = db.Execute(@"UPDATE [dbo].[Student]
                                   SET [deleteFlag] = 1
      
                                 WHERE Id = 2");
            Console.WriteLine($"{results} rows affected");
        }

    }
}
