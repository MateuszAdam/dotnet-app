using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace MatchDataManager.Api.ActionFilters
{
    public class LocationActionFilter: ActionFilterAttribute
    {
        public LocationActionFilter() { }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log("OnActionExecuting", filterContext.RouteData);
        }
       


        private void Log(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = String.Format("{0} controller:{1} action:{2}", methodName, controllerName, actionName);
            Debug.WriteLine(message, "Action Filter Log");
        }
    }
}
