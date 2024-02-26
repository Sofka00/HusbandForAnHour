using Dapper;
using HusbandForAnHour.DAL;
using HusbandForAnHour.DAL.Dtos;
using HusbandForAnHour.DAL.StoredProcedures;
using Microsoft.Data.SqlClient;
using System.Data;

public class RequestRepository
{

    public RequestRepository()
    {
    }

    public void CreateRequest(long clientId, DateTime date, string address, int statusId, string comment)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            connection.Execute(RequestStoredProcedure.CreateRequest, new { ClientId = clientId, Date = date, Address = address, StatusId = statusId, Comment = comment }, commandType: CommandType.StoredProcedure);
        }
    }

    public int DeleteRequest(int id)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection.Execute(RequestStoredProcedure.DeleteRequest, new { Id = id }, commandType: CommandType.StoredProcedure);
        }
    }

    public int RestoreRequest(int id)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection.Execute(RequestStoredProcedure.RestoreRequest, new { Id = id }, commandType: CommandType.StoredProcedure);
        }
    }

    public RequestDto GetRequest(int id)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection.QuerySingle<RequestDto>(RequestStoredProcedure.GetRequest, new { Id = id }, commandType: CommandType.StoredProcedure);
        }
    }

    public List<RequestDto> GetRequestByClient(long clientId)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection.Query<RequestDto>(RequestStoredProcedure.GetRequestByClient, new { Id = clientId }, commandType: CommandType.StoredProcedure).ToList();
        }
    }

    public int UpdateRequest(int id, long clientId, DateTime date, string address, int statusId, string comment)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
           return connection.Execute(RequestStoredProcedure.UpdateRequest, new { Id = id, ClientId = clientId, Date = date, Address = address, StatusId = statusId, Comment = comment }, commandType: CommandType.StoredProcedure);
        }
    }
}