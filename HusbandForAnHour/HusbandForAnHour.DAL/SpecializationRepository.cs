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
using HusbandForAnHour.DAL.IRepositories;
namespace HusbandForAnHour.DAL
{
    public class SpecializationRepository : ISpecializationRepository
    {
        public void CreateSpecialization(string name)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                connection.Execute(SpecializationStoredProcedure.CreateSpecialization, new { Name = name }, commandType: CommandType.StoredProcedure);
            }
        }

        public SpecializationDto GetSpecialization(int id)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.QuerySingle<SpecializationDto>(SpecializationStoredProcedure.GetSpecialization, new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public int UpdateSpecialization(int id, string name)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Execute(SpecializationStoredProcedure.UpdateSpecialization, new { Id = id, Name = name }, commandType: CommandType.StoredProcedure);
            }
        }

        public int DeleteSpecialization(int id)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Execute(SpecializationStoredProcedure.DeleteSpecialization, new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public int RestoreSpecialization(int id)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Execute(SpecializationStoredProcedure.RestoreSpecialization, new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }
        public List<SpecializationDto> GetAllSpecialization()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<SpecializationDto>(SpecializationStoredProcedure.GetAllSpecialization, commandType: CommandType.StoredProcedure).ToList();
            }
        }

    }
}
