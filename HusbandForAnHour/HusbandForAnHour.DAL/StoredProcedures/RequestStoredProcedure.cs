using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusbandForAnHour.DAL.StoredProcedures
{
    public class RequestStoredProcedure
    {
        public const string CreateRequest = "CreateRequest";
        public const string DeleteRequest = "DeleteRequest";
        public const string RestoreRequest = "RestoreRequest";

        public const string GetRequest = "GetRequest";
        public const string GetAllRequestByStatus = "GetAllRequestByStatus";

        public const string GetRequestByClient = "GetRequestByClient";
        public const string UpdateRequest = "UpdateRequest";

    }
}
