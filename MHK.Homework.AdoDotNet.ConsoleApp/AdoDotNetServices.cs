using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHK.Homework.AdoDotNet.ConsoleApp
{
    public class AdoDotNetServices
    {
        SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "MHKDotNetTrainingInPersonBatch1",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };
        public void Read()
        {
            #region
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            string query = @"SELECT [StudentId]
                              ,[StudentNumber]
                              ,[StudentName]
                              ,[FatherName]
                              ,[DateOfBirth]
                              ,[Age]
                              ,[Gender]
                              ,[Address]
                              ,[MobileNumber]
                              ,[Program]
                              ,[DeleteFlag]
                          FROM [dbo].[Enrollment]"; //read the date from the table
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            sqlConnection.Close();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dataRow = dataTable.Rows[i];
                Console.WriteLine($"{dataRow["StudentId"]} {dataRow["StudentNumber"]} {dataRow["StudentName"]}");
            }
            #endregion
        }
        public void Write()
        {
            #region
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            string query = @"INSERT INTO [dbo].[Enrollment]
           ([StudentNumber]
           ,[StudentName]
           ,[FatherName]
           ,[DateOfBirth]
           ,[Age]
           ,[Gender]
           ,[Address]
           ,[MobileNumber]
           ,[Program]
           ,[DeleteFlag])
     VALUES
           (
		   'ST348-252',
		   'Minnie',
		   'Mr. Mickey',
		   '2000-01-02',
		   '25',
		   'female',
		   'United States',
		   '0912346',
		   'Arts',
		   '0'
		   
		   )";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            int rows = cmd.ExecuteNonQuery();
            string message = rows > 0 ? $"{rows} rows affected." : "insterting failed";
            Console.WriteLine(message);
            sqlConnection.Close();
            #endregion
        }
        public void Update()
        {
            #region
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            string query = @"UPDATE [dbo].[Enrollment]
                       SET StudentName = 'Sam'
                     WHERE StudentId = 1";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            int rows = cmd.ExecuteNonQuery();
            string message = rows > 0 ? $"{rows} rows affected." : "updating failed";
            Console.WriteLine(message);
            sqlConnection.Close();
            #endregion
        }
        public void Delete()
        {
            #region
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            string query = @"UPDATE [dbo].[Enrollment]
                       SET DeleteFlag = 1
                     WHERE StudentId = 1";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            int rows = cmd.ExecuteNonQuery();
            string message = rows > 0 ? $"{rows} rows affected." : "deleting failed";
            Console.WriteLine(message);
            sqlConnection.Close();
            #endregion

        }
    }
}
