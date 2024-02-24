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
    public class StatusRepository : IStatusRepository
    {
        public List<StatusDto> CreateStatus()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<StatusDto>(StatusStoredProcedure.CreateStatus).ToList();
            }
        }

        public List<StatusDto> DeleteStatus()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<StatusDto>(StatusStoredProcedure.DeleteStatus).ToList();
            }
        }

        public List<StatusDto> GetStatusById()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<StatusDto>(StatusStoredProcedure.GetStatusById).ToList();
            }
        }

        public List<StatusDto> UpdateStatus()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<StatusDto>(StatusStoredProcedure.UpdateStatus).ToList();
            }
        }
    }
}
