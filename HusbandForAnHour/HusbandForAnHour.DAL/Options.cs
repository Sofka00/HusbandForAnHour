using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HusbandForAnHour.DAL
{
    public class Options
    {
        public const string ConnectionString = "Data Source=(localhost);Initial Catalog=HusbandForAnHour;Integrated Security=true; TrustServerCertificate=True";
    }
}
