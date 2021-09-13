using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Store_3.EndPoint.Utilities
{
    public static class ClaimUtility
    {
        public static string GetUserId(ClaimsPrincipal user)
        {
            var claimsidentity = user.Identity as ClaimsIdentity;
            string userid = claimsidentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return userid;
        }
    }
}
