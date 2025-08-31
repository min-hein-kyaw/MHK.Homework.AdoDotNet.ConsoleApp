// See https://aka.ms/new-console-template for more information
using MHK.Homework.AdoDotNet.ConsoleApp;
using Microsoft.Data.SqlClient;
using System.Data;


//AdoDotNetServices adoDotNetServices = new AdoDotNetServices();

//Console.WriteLine("Reading Data...");
//adoDotNetServices.Read();

//Console.WriteLine("Adding Data...");
//adoDotNetServices.Create();

//Console.WriteLine("Updating Data...");
//adoDotNetServices.Update();

//Console.WriteLine("Deleting Data...");
//adoDotNetServices.Delete();

//DapperService dapper = new DapperService();
//dapper.Read();
////dapper.Create();
////dapper.Update();
////dapper.Delete();
//Console.ReadLine();

EntityFrameWorkServices entityFrameWorkService = new EntityFrameWorkServices();
//entityFrameWorkService.Read(); //worked
//entityFrameWorkService.Create();//worked
//entityFrameWorkService.Update();//worked
entityFrameWorkService.Delete();




