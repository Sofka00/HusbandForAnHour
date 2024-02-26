using Dapper;
using HusbandForAnHour.DAL;
using Microsoft.Data.SqlClient;
using System.Data;

public class RequestServiceRepository
{
    public void CreateRequestService(int idRequest, int idService)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            connection.Execute("CreateRequsetService", new { IdRequest = idRequest, IdService = idService }, commandType: CommandType.StoredProcedure);
        }
    }

    public int DeleteRequestService(int idRequest)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection.Execute("DeleteRequsetService", new { IdRequest = idRequest }, commandType: CommandType.StoredProcedure);
        }
    }

    public IEnumerable<RequestServiceDto> SelectRequestServiceByRequest(int idRequest)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection.Query<RequestServiceDto>("SelectRequestServiceByRequest", new { IdRequest = idRequest }, commandType: CommandType.StoredProcedure);
        }
    }

    public IEnumerable<RequestServiceDto> SelectRequestServiceByService(int idService)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection.Query<RequestServiceDto>("SelectRequestServiceByService", new { IdService = idService }, commandType: CommandType.StoredProcedure);
        }
    }
}
