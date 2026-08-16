using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace YMNDotNet.consoleApp
{
    public class DotNetExample
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=YMNDotnet;User ID=sa;Password=9@1@84;";
        public void Read()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            connection.Open();

            string query = @"SELECT [Blogid]
                                  ,[BlogTitle]
                                  ,[BlogAuthor]
                                  ,[BlogConent]
                              FROM [dbo].[Tbl_blog]
                              WHERE DeletedFlag=0";
            SqlCommand cmd = new SqlCommand(cmdText: query, connection);
            /*SqlDataAdapter adapter = new SqlDataAdapter(selectCommand: cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dataTable: dt);
            connection.Close();

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine(value: row["Blogid"] + " " + row["BlogTitle"] + " " + row["BlogAuthor"] + " " + row["BlogConent"]);
            } 

            For Retrive the whole dataset and looping output each row
            */

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(value: reader["Blogid"] + " " + reader["BlogTitle"] + " " + reader["BlogAuthor"] + " " + reader["BlogConent"]);
            }
            connection.Close();
        }

        public void Create()
        {
            
            SqlConnection connection = new SqlConnection(_connectionString);

            Console.WriteLine("Enter Blog Title:");
            string blogTitle = Console.ReadLine();
            Console.WriteLine("Enter Blog Author:");
            string blogAuthor = Console.ReadLine();
            Console.WriteLine("Enter Blog Content:");
            string blogContent = Console.ReadLine();


            connection.Open();
            //string query2 = $@"INSERT INTO [dbo].[Tbl_blog]
            //           ([BlogTitle]
            //           ,[BlogAuthor]
            //           ,[BlogConent])
            //     VALUES
            //           ('{blogTitle}'
            //           ,'{blogAuthor}'
            //           ,'{blogContent}')";

            string query2 = $@"INSERT INTO [dbo].[Tbl_blog]
                                       ([BlogTitle]
                                       ,[BlogAuthor]
                                       ,[BlogConent])
                                 VALUES
                                       (@BlogTitle
                                       ,@BlogAuthor
                                       ,@BlogConent)";


            SqlCommand cmd = new SqlCommand(cmdText: query2, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", blogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blogAuthor);
            cmd.Parameters.AddWithValue("@BlogConent", blogContent);
            int result = cmd.ExecuteNonQuery();

            Console.WriteLine(result > 0 ? "Insert Successfully" : "Fail Insert");
            connection.Close();
        }

        public void Edit()
        {
            Console.WriteLine("Enter a Blog ID:");
            string blogId = Console.ReadLine(); 

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = @"SELECT [Blogid]
                                  ,[BlogTitle]
                                  ,[BlogAuthor]
                                  ,[BlogConent]
                                  ,[DeletedFlag]
                              FROM [dbo].[Tbl_blog] where Blogid=@blogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@blogId", blogId);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader["BlogId"]);
                Console.WriteLine(reader["BlogTitle"]);
                Console.WriteLine(reader["BlogAuthor"]);
                Console.WriteLine(reader["BlogConent"]);

            }
            connection.Close();
            Console.WriteLine("Enter 1:For Title,2:For Author,3:For Blog Content!");
            string editCate = Console.ReadLine();
            SqlConnection connection2 = new SqlConnection(_connectionString);
            connection2.Open();
            switch (editCate)
            {
                case "1":
                    Console.WriteLine("Enter Blog Title:");
                    string blogTitle = Console.ReadLine();
                    string query2 = $@"UPDATE [dbo].[Tbl_blog]
                                       SET [BlogTitle] = @BlogTitle
                                       WHERE BlogId=@BlogId";
                    SqlCommand cmd2 = new SqlCommand(cmdText: query2, connection2);
                    cmd2.Parameters.AddWithValue("@BlogTitle", blogTitle);
                    cmd2.Parameters.AddWithValue("@BlogId", blogId);
                    int result2 = cmd2.ExecuteNonQuery();
                    Console.WriteLine(result2 > 0 ? "Update Successfully" : "Fail Update");
                    break;
                case "2":
                    Console.WriteLine("Enter Blog Author:");
                    string blogAuthor = Console.ReadLine();
                    string query3 = $@"UPDATE [dbo].[Tbl_blog]
                                       SET [BlogAuthor] = @BlogAuthor
                                       WHERE BlogId=@BlogId";
                    SqlCommand cmd3 = new SqlCommand(cmdText: query3, connection2);
                    cmd3.Parameters.AddWithValue("@BlogAuthor", blogAuthor);
                    cmd3.Parameters.AddWithValue("@BlogId", blogId);
                    int result3 = cmd3.ExecuteNonQuery();
                    Console.WriteLine(result3 > 0 ? "Update Successfully" : "Fail Update");
                    break;
                case "3":
                    Console.WriteLine("Enter Blog Title:");
                    string blogContent = Console.ReadLine();
                    string query4 = $@"UPDATE [dbo].[Tbl_blog]
                                       SET [BlogConent] = @BlogContent
                                       WHERE BlogId=@BlogId";
                    SqlCommand cmd4 = new SqlCommand(cmdText: query4, connection2);
                    cmd4.Parameters.AddWithValue("@BlogContent", blogContent);
                    cmd4.Parameters.AddWithValue("@BlogId", blogId);
                    int result4 = cmd4.ExecuteNonQuery();
                    Console.WriteLine(result4 > 0 ? "Update Successfully" : "Fail Update");
                    break;

            }

            connection2.Close();

        }
        
        public void Delete()
        {
            Console.WriteLine("Enter the blog Id that you want to delete!");
            string blogID = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = $@"UPDATE [dbo].[Tbl_blog]
                               SET [DeletedFlag] = 1
                             WHERE BlogID = @BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("BlogId", blogID);
            int result = cmd.ExecuteNonQuery();
            Console.WriteLine(result > 0 ? "Successfully Deleted!": "Fail To Delete");
            connection.Close();

        }

    }
}
