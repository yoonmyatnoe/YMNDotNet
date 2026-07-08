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








