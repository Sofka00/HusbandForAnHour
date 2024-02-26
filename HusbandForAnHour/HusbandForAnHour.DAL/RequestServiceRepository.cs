using HusbandForAnHour.DAL.Dtos;
using HusbandForAnHour.DAL;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

public class RequestServiceRepository : IRequestService
{

    public void CreateRequestService(int idRequest, int idService)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            connection.Execute(RequsetServiceStoredProcedure.CreateRequsetService, new { IdRequest = idRequest, IdService = idService }, commandType: CommandType.StoredProcedure);
        }
    }

    public int DeleteRequestService(int idRequest)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection.Execute(RequsetServiceStoredProcedure.DeleteRequsetService, new { IdRequest = idRequest }, commandType: CommandType.StoredProcedure);
        }
    }

    public List<RequestServiceDto> GetRequestServiceByRequest(int idRequest)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection.Query<RequestServiceDto>(RequsetServiceStoredProcedure.SelectRequestServiceByRequest, new { IdRequest = idRequest }, commandType: CommandType.StoredProcedure).ToList();
        }
    }

    public List<RequestServiceDto> GetRequestServiceByService(int idService)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection.Query<RequestServiceDto>(RequsetServiceStoredProcedure.SelectRequestServiceByService, new { IdService = idService }, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
