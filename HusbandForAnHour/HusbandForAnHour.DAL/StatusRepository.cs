using HusbandForAnHour.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using HusbandForAnHour.DAL.StoredProcedures;
using HusbandForAnHour.DAL.IRepositories;

namespace HusbandForAnHour.DAL
{
    public class StatusRepository : IStatusRepository
    {
        public void CreateStatus(string name)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                connection.Execute(StatusStoredProcedure.CreateStatus, new { Name = name }, commandType: CommandType.StoredProcedure);
            }
        }

        public StatusDto GetStatus(int id)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.QuerySingle<StatusDto>(StatusStoredProcedure.GetStatus, new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public int UpdateStatus(int id, string name)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Execute(StatusStoredProcedure.UpdateStatus, new { Id = id, Name = name }, commandType: CommandType.StoredProcedure);
            }
        }

        public int DeleteStatus(int id)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Execute(StatusStoredProcedure.DeleteStatus, new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public int RestoreStatus(int id)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Execute(StatusStoredProcedure.RestoreStatus, new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
