using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusbandForAnHour.DAL.StoredProcedures
{
    public class ServiceStoredProcedure
    {
        public const string CreateServices = "CreateService";

        public const string DeleteServices = "DeleteService";

        public const string GetService = "GetService";
        public const string GetAllServices = "GetAllServices";
        public const string RestoreService = "RestoreService";

        public const string GetServiceBySpecialization = "GetServiceBySpecialization";
        public const string UpdateService = "UpdateService"; 
    }
}
