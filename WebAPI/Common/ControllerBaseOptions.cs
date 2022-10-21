using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Security.AccessControl;
using System.Reflection.Emit;

namespace WebAPI.Common
{
    public abstract class ControllerBaseOptions: ControllerBase
    {
        [HttpOptions]
        public void Options()
        {
            var res = String.Join(", ", this.GetType()
                .GetMethods()
                .SelectMany(m => m.GetCustomAttributes(false))
                .Where(a => a?.GetType()?.BaseType?.Name == "HttpMethodAttribute")
                .SelectMany(a => ((HttpMethodAttribute)a).HttpMethods)
                .Distinct()
                .ToList());

            Response.Headers.Add("Allow", res);
            Response.StatusCode = 204;
        }
    }
}
