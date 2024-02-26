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
    public class UserRepository : IUserRepository
    {
        public void CreateUser(int roleId, string firstName, string secondName, long phone)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                connection.Execute(UserStoredProcedure.CreateUser, new { RoleId = roleId, FirstName = firstName, SecondName = secondName, Phone = phone }, commandType: CommandType.StoredProcedure);
            }
        }

        public UserDto GetUser(long id)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.QuerySingle<UserDto>(UserStoredProcedure.GetUser, new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public int UpdateUser(long id, int roleId, string firstName, string secondName, long phone)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Execute(UserStoredProcedure.UpdateUser, new { Id = id, RoleId = roleId, FirstName = firstName, SecondName = secondName, Phone = phone }, commandType: CommandType.StoredProcedure);
            }
        }

        public int DeleteUser(long id)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Execute(UserStoredProcedure.DeleteUser, new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public int RestoreUser(long id)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Execute(UserStoredProcedure.RestoreUser, new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }


    }
}
