// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;
using YMNDotNet.consoleApp;

//Console.WriteLine("Hello, World!");

//Console.ReadKey();



DotNetExample dotNetExample = new DotNetExample();
//dotNetExample.Read();
//dotNetExample.Create();
//dotNetExample.Edit();
//dotNetExample.Delete();

//DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Create();

EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Read();
eFCoreExample.Create();








