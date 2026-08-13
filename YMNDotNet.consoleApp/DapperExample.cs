using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using YMNDotNet.consoleApp.Models;

namespace YMNDotNet.consoleApp
{
    public class DapperExample
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=YMNDotnet;User ID=sa;Password=9@1@84;";
        
        public void Read()
        {
            //using (IDbConnection db= new SqlConnection(_connectionString))
            //{
            //    string query = "select * from Tbl_blog where DeletedFlag=0";

            //    List<dynamic> lst = db.Query(query).ToList();
            //    foreach (var item in lst) {
            //        Console.WriteLine(item.Blog);
            //        Console.WriteLine(item.BlogTitle);
            //        Console.WriteLine(item.BlogAuthor);
            //        Console.WriteLine(item.BlogConent);
            //    }
            //}

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "select * from Tbl_blog where DeletedFlag=0";

                List<BlogDapperDataModel> lst = db.Query<BlogDapperDataModel>(query).ToList();
                foreach (var item in lst)
                {
                    Console.WriteLine(item.BlogID);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogConent);
                    Console.WriteLine("-----------------");
                }
            }

        }

        public void Create()
        {
            using(IDbConnection db = new SqlConnection(_connectionString))
            {
                Console.WriteLine("Enter the Blog Title:");
                string blogTitle = Console.ReadLine();
                Console.WriteLine("Enter the Blog Author");
                string blogAuthor = Console.ReadLine();
                Console.WriteLine("Enter the Blog Content:");
                string blogContent = Console.ReadLine();

                BlogDataModel BlogModel = new BlogDataModel
                {
                    BlogTitle = blogTitle,
                    BlogAuthor = blogAuthor,
                    BlogConent = blogContent
                };


                string query = @"INSERT INTO [dbo].[Tbl_blog]
                                       ([BlogTitle]
                                       ,[BlogAuthor]
                                       ,[BlogConent]
                                       ,[DeletedFlag])
                                 VALUES
                                       (@BlogTitle
                                       ,@BlogAuthor
                                       ,@BlogConent
                                       ,0)";
                int result = db.Execute(query, BlogModel);
                Console.WriteLine(result >0 ? "Insert Successfully":"Fail To Insert");
                
            }
        }

    }
}
