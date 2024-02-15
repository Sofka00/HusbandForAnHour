using HusbandForAnHour.DAL.Dtos;
using HusbandForAnHour.DAL.IRepositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using HusbandForAnHour.DAL.StoredProcedures;

namespace HusbandForAnHour.DAL
{
    public class RequestRepository : IRequestRepositorys
    {
        public List<RequestDto> GetAllRequest()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<RequestDto>(RequestStoredProcedure.GetAllRequest).ToList();
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
