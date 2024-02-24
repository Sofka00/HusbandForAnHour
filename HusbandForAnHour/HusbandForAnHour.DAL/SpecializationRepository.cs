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
    public class SpecializationRepository : ISpecializationRepository
    {
        public List<SpecializationDto> CreateSpecialization()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<SpecializationDto>(SpecializationStoredProcedure.CreateSpecialization).ToList();
            }
        }

        public List<SpecializationDto> DeleteSpecialization()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<SpecializationDto>(SpecializationStoredProcedure.DeleteSpecialization).ToList();
            }
        }

        public List<SpecializationDto> GetSpecializationById()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<SpecializationDto>(SpecializationStoredProcedure.GetSpecializationById).ToList();
            }
        }

        public List<SpecializationDto> UpdateSpecialization()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<SpecializationDto>(SpecializationStoredProcedure.UpdateSpecialization).ToList();
            }
        }
    }
}
