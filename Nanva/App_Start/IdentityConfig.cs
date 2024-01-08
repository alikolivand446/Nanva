using System;
using System.Security.Claims;
using System.Web.Mvc;
using static Nanva.Identity;

namespace Nanva
{
    public class Identity
    {
        public class AppUser : ClaimsPrincipal
        {
            public AppUser(ClaimsPrincipal principal)
            : base(principal) { }
            public string Name
            {
                get
                {
                    return this.FindFirst(ClaimTypes.Name).Value;
                }
            }

            public int UserId
            {
                get
                {
                    return Convert.ToInt32(this.FindFirst(ClaimTypes.NameIdentifier).Value);
                }
            }

            public int PersonId
            {
                get
                {
                    return Convert.ToInt32(this.FindFirst(ClaimTypes.PrimarySid).Value);
                }
            }
        }
    }
    public abstract class AppViewPage : WebViewPage
    {
        protected AppUser CurrentUser
        {
            get
            {
                return new AppUser(this.User as ClaimsPrincipal);
            }
        }
    }
    //نشد که بشه و درست کارکنه
    //public  class  AppViewPage : AppViewPage
    //{
    //}

    public class PermissionCheckerAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private int _CheckerPermission = 0;
        public PermissionCheckerAttribute(int checker)
        {
            _CheckerPermission = checker;
        }
        public void OnAuthorization(AuthorizationContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                string name = context.HttpContext.User.Identity.Name;
                if (!Function.Account.CheckedPermission(_CheckerPermission, name))
                {
                    //context.Result = new RedirectResult("/Nanva/Home/Login");
                }
            }
            else
            {
                context.Result = new RedirectResult("/Nanva/Home/Login");
            }
        }
    }

}