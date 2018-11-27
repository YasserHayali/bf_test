using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BF_Test.Helpers
{
    public class CustomAuthorizationFilterAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string authHeader = context.HttpContext.Request.Headers["Authorization"];
            if (authHeader != null)
            {
                if (authHeader == Constants.TEST_ADMIN_AUTH_TOKEN)
                {
                    return;
                }
            }
            context.Result = new UnauthorizedResult();
        }
    }
}
