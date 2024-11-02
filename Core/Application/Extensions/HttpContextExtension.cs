using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static partial class Extension
    {
        public static string GetHost(this IHttpContextAccessor ctx)
            => $"{ctx.HttpContext.Request.Scheme}://{ctx.HttpContext.Request.Host}";
    }
}
