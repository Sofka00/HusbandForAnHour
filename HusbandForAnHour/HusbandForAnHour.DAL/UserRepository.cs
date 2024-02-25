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
    public class UserRepository : IUserRepository
    {
        public UserDto CreateUser(UserDto userDto)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                var anonymus = new { Id = userDto.Id, RoleId = userDto.RoleId, FirstName=userDto.FirstName, SecondName = userDto.SecondName, Phone = userDto.Phone, SpecializationId = userDto.SpecializationId};
                return connection.Query<UserDto>(UserStoredProcedure.CreateUser, anonymus).FirstOrDefault();
            }
        }

        public List<UserDto> DeleteUser()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<UserDto>(UserStoredProcedure.DeleteUser).ToList();
            }
        }

        public List<UserDto> GetUserById()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<UserDto>(UserStoredProcedure.GetUserById).ToList();
            }
        }

        public List<UserDto> UpdateUser()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<UserDto>(UserStoredProcedure.UpdateUser).ToList();
            }
        }
        public int GetLastUserId()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<int>("SELECT TOP 1 dbo.[User].Id FROM dbo.[User] ORDER BY Id DESC").FirstOrDefault();
            }
        }

    }
}
