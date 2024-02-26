using Dapper;
using HusbandForAnHour.DAL;
using HusbandForAnHour.DAL.Dtos;
using HusbandForAnHour.DAL.StoredProcedures;
using Microsoft.Data.SqlClient;
using System.Data;

public class RequestWorkerRepository
{
    public void CreateRequestWorker(int idRequest, long idWorker)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            connection.Execute(RequestWorkerStoredProcedure.CreateRequestWorker, new { IdRequest = idRequest, IdWorker = idWorker }, commandType: CommandType.StoredProcedure);
        }
    }

    public int DeleteRequestWorker(int idRequest)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection.Execute(RequestWorkerStoredProcedure.DeleteRequestWorker, new { IdRequest = idRequest }, commandType: CommandType.StoredProcedure);
        }
    }

    public List<RequestWorkerDto> SelectRequestWorkerByRequest(int idRequest)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection.Query<RequestWorkerDto>(RequestWorkerStoredProcedure.SelectRequestWorkerByRequest, new { IdRequest = idRequest }, commandType: CommandType.StoredProcedure).ToList();
        }
    }

    public List<RequestWorkerDto> SelectRequestWorkerByWorker(long idWorker)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection.Query<RequestWorkerDto>(RequestWorkerStoredProcedure.SelectRequestWorkerByWorker, new { IdWorker = idWorker }, commandType: CommandType.StoredProcedure).ToList();
        }
    }

}