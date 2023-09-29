using Hangfire.Dashboard;
using Hangfire.Annotations;


namespace AzureTestMVC.Utilities
{
    public class HangFireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            // can add some more logic here...
            // return HttpContext.Current.User.Identity.IsAuthenticated;

            //Can use this for NetCore
            return true;
        }
    }
}
