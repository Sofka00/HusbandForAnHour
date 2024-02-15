using Dapper;
using HusbandForAnHour.DAL.Dtos;
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
    public class UserRoleRepository
    {
        public List<UserRoleDto> CreateUserRole()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<UserRoleDto>(UserRoleStoredProcedure.CreateUserRole).ToList();
            }
        }

        public List<UserRoleDto> DeleteUserRoleById()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<UserRoleDto>(UserRoleStoredProcedure.DeleteUserRoleById).ToList();
            }
        }

        public List<UserRoleDto> GetUserRoleById()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<UserRoleDto>(UserRoleStoredProcedure.GetUserRoleById).ToList();
            }
        }

        public List<UserRoleDto> UpdateUserRole()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<UserRoleDto>(UserRoleStoredProcedure.UpdateUserRole).ToList();
            }
        }
    }
}
