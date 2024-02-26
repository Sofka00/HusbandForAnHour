using Dapper;
using HusbandForAnHour.DAL.Dtos;
using HusbandForAnHour.DAL.IRepositories;
using HusbandForAnHour.DAL.StoredProcedures;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusbandForAnHour.DAL
{
    public class UserSpecializationRepository : IUserSpecializationRepository
    {
        public void CreateUserSpecialization(long idUser, int idService)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                connection.Execute(UserSpecializationStoredProcedure.CreateUserSpecialization, new { IdUser = idUser, IdService = idService }, commandType: CommandType.StoredProcedure);
            }
        }

        public int DeleteUserSpecialization(long idUser)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Execute(UserSpecializationStoredProcedure.DeleteUserSpecialization, new { IdUser = idUser }, commandType: CommandType.StoredProcedure);
            }
        }

        public List<UserSpecializationDto> SelectUserSpecializationByUser(long idUser)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<UserSpecializationDto>(UserSpecializationStoredProcedure.SelectUserSpecializationByUser, new { IdUser = idUser }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<UserSpecializationDto> SelectUserSpecializationBySpecialization(int idSpecialization)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<UserSpecializationDto>(UserSpecializationStoredProcedure.SelectUserSpecializationBySpecialization, new { IdSpecialization = idSpecialization }, commandType: CommandType.StoredProcedure).ToList();
            }
        }


    }
}
