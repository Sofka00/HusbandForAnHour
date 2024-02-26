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
    public class UserRoleRepository : IUserRoleRepository
    {
        public void CreateUserRole(string name)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                connection.Execute(UserRoleStoredProcedure.CreateUserRole, new { Name = name }, commandType: CommandType.StoredProcedure);
            }
        }

        public UserRoleDto GetUserRole(int id)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.QuerySingle<UserRoleDto>(UserRoleStoredProcedure.GetUserRole, new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public int UpdateUserRole(int id, string name)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Execute(UserRoleStoredProcedure.UpdateUserRole, new { Id = id, Name = name }, commandType: CommandType.StoredProcedure);
            }
        }

        public int DeleteUserRole(int id)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Execute(UserRoleStoredProcedure.DeleteUserRole, new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public int RestoreUserRole(int id)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Execute(UserRoleStoredProcedure.RestoreUserRole, new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public List<UserRoleDto> GetAllUserRole()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<UserRoleDto>(UserRoleStoredProcedure.GetAllUserRole, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
