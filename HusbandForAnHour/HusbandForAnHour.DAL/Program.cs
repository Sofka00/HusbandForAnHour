using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;


string ConnectionString = "Data Source=(localhost);Initial Catalog=HusbandForAnHour;Integrated Security=true; TrustServerCertificate=True";
IDbConnection connectoin = new SqlConnection(ConnectionString);
