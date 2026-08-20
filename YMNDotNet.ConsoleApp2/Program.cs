// See https://aka.ms/new-console-template for more information
using YMNDotNet.Database.Models;

Console.WriteLine("Hello, World!");

AppDbcontext db = new AppDbcontext();
var list = db.TblBlogs.ToList();
