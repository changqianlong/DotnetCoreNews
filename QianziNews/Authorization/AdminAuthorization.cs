using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QianziNews.Authorization
{
    public class AdminAuthorization: AuthorizationHandler<OperationAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement)
        {
            if (context.User == null)
            {
                return Task.CompletedTask;
            }
            else if (context.User.IsInRole("User") && requirement.Name == "Comment")
            {
                context.Succeed(requirement);
            }
            if (context.User.IsInRole("Admin"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
