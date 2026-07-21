using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace YMNDotNet.consoleApp
{
    public class DotNetExample
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=YMNDotnet;User ID=sa;Password=ymn@123;";
        public void Read()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            connection.Open();

            string query = @"SELECT [Blogid]
                                  ,[BlogTitle]
                                  ,[BlogAuthor]
                                  ,[BlogConent]
                              FROM [dbo].[Tbl_blog]";
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

            foreach (reader.Read())
            {
                Console.WriteLine(reader["BlogId"]);
                Console.WriteLine(reader["BlogTitle"]);
                Console.WriteLine(reader["BlogAuthor"]);
                Console.WriteLine(reader["BlogConent"]);

            }
            connection.Close();    
        }
    }
}
