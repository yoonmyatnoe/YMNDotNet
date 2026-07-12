// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

Console.ReadKey();
string connectionStr = "Data Source=.;Initial Catalog=YMNDotnet;User ID=sa;Password=ymn@123;";
Console.WriteLine(value:"Connection String ="+ connectionStr);
SqlConnection connection = new SqlConnection(connectionStr);

connection.Open();

string query = @"SELECT [Blogid]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogConent]
  FROM [dbo].[Tbl_blog]";
SqlCommand cmd = new SqlCommand(cmdText: query,connection);
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
}connection.Close();

string connectionStr2 = "Data Source=.;Initial Catalog=YMNDotnet;User ID=sa;Password=ymn@123;";
SqlConnection connection2 = new SqlConnection(connectionStr2);

Console.WriteLine("Enter Blog Title:");
string blogTitle = Console.ReadLine();
Console.WriteLine("Enter Blog Author:");
string blogAuthor = Console.ReadLine();
Console.WriteLine("Enter Blog Content:");
string blogContent = Console.ReadLine();


connection2.Open();
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


SqlCommand cmd2 = new SqlCommand(cmdText: query2, connection2);
cmd2.Parameters.AddWithValue("@BlogTitle", blogTitle);
cmd2.Parameters.AddWithValue("@BlogAuthor", blogAuthor);
cmd2.Parameters.AddWithValue("@BlogConent", blogContent);
int result = cmd2.ExecuteNonQuery();

Console.WriteLine(result>0? "Insert Successfully":"Fail Insert");
connection2.Close();









