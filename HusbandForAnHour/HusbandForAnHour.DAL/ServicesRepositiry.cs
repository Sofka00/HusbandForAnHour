﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using HusbandForAnHour.DAL.StoredProcedures;
using HusbandForAnHour.DAL.IRepositorys;
using HusbandForAnHour.DAL.Dtos;

namespace HusbandForAnHour.DAL
{
    public class ServicesRepositiry : IServicesRepositiry
    {
        public ServicesDto CreateServices(ServicesDto servicesDto)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<ServicesDto>(ServicesStoredProcedure.CreateServices, servicesDto).FirstOrDefault();    
            }                                                                                    
        }

        public List<ServicesDto> DeleteServices()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<ServicesDto>(ServicesStoredProcedure.DeleteServices).ToList();
            }
        }

        public List<ServicesDto> GetAllServices()
        {
           using(IDbConnection connection = new SqlConnection(Options.ConnectionString)) 
            { 
                return connection.Query<ServicesDto>(ServicesStoredProcedure.GetAllServices).ToList();
            }
        }

        public List<ServicesDto> GetServicesById()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<ServicesDto>(ServicesStoredProcedure.GetServicesById).ToList();
            }
        }

        public List<ServicesDto> UpdateServices()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<ServicesDto>(ServicesStoredProcedure.UpdateServices).ToList();
            }
        }
    }
}
