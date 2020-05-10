using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QianziNews.Authorization
{
    public class Operations
    {
        public static OperationAuthorizationRequirement Admin = new OperationAuthorizationRequirement { Name = "Admin" };
        public static OperationAuthorizationRequirement Create = new OperationAuthorizationRequirement { Name = "Create" };
        public static OperationAuthorizationRequirement Comment = new OperationAuthorizationRequirement { Name = "Comment" };
    }
}
