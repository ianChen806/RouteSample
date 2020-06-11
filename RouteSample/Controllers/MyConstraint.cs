using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace RouteSample.Controllers
{
    public class MyConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (routeDirection == RouteDirection.IncomingRequest)
            {
                var value = values[routeKey];
                if (int.TryParse(value.ToString(), out _))
                {
                    return true;
                }
            }

            return false;
        }
    }
}