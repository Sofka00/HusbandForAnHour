using Dapper;
using HusbandForAnHour.DAL.Dtos;
using HusbandForAnHour.DAL.IRepositorys;
using HusbandForAnHour.DAL.StoredProcedures;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HusbandForAnHour.DAL
{
    public class RequestRepository : IRequestRepository
    {
        public List<GetAllRequestDto> GetAllRequest()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<GetAllRequestDto>(RequestStoredProcedure.GetAllRequest).ToList();
            }
        }

        public List<RequestDto> CreateRequest()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<RequestDto>(RequestStoredProcedure.CreateRequest).ToList();
            }
        }

        public List<RequestDto> DeleteRequestById()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<RequestDto>(RequestStoredProcedure.DeleteRequestById).ToList();
            }
        }

        public List<RequestDto> GetRequestById()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<RequestDto>(RequestStoredProcedure.GetRequestById).ToList();
            }
        }

        public List<RequestDto> UpdateRequest()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<RequestDto>(RequestStoredProcedure.UpdateRequest).ToList();
            }
        }
    }
}
