using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using HusbandForAnHour.DAL.StoredProcedures;
using HusbandForAnHour.DAL.Dtos;
using HusbandForAnHour.DAL.IRepositories;

namespace HusbandForAnHour.DAL
{
    public class ServiceRepository : IServiceRepository
    {
        public void CreateService(string name, int specializationId)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                connection.Execute(ServiceStoredProcedure.CreateServices, new { Name = name, SpecializationId = specializationId }, commandType: CommandType.StoredProcedure);
            }
        }

        public int DeleteService(int id)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Execute(ServiceStoredProcedure.DeleteServices, new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public int RestoreService(int id)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Execute(ServiceStoredProcedure.RestoreService, new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public ServicesDto GetService(int id)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.QuerySingle<ServicesDto>(ServiceStoredProcedure.GetService, new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }
         public List<ServicesDto> GetAllServices()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<ServicesDto>(ServiceStoredProcedure.GetAllServices, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<ServicesDto> GetServiceBySpecialization(int id)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<ServicesDto>(ServiceStoredProcedure.GetServiceBySpecialization, new { Id = id }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int UpdateService(int id, string name, int specializationId)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Execute(ServiceStoredProcedure.UpdateService, new { Id = id, Name = name, SpecializationId = specializationId }, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
