using Microsoft.Data.SqlClient;

var connStr = "server=localhost\\sqlexpress;" +
                "database=SalesDb;" +
                 "trusted_connection=true;" +
                 "trustServerCertificate=true;";

var conn = new SqlConnection(connStr);

conn.Open();

if(conn.State != System.Data.ConnectionState.Open)
{
    throw new Exception("Connection didn't open");
}

Console.WriteLine("Success!");

// put out sql code here
var sql = "SELECT * from Customers where id between 10 and 19;";
var cmd = new SqlCommand(sql, conn);
var reader = cmd.ExecuteReader();
while (reader.Read()) // return true while theres another row
{
    var id = Convert.ToInt32(reader["Id"]);
    var name = Convert.ToString(reader["Name"]);
    Console.WriteLine($"Id={id}, name={name}");
} 


conn.Close();