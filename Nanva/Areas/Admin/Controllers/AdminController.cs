using System.Web.Mvc;
using Nanva.Function;
namespace Nanva.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        //[PermissionChecker(9)]
        public ActionResult Index()
        {
            var statelogin = Account.LoginUser(new LoginViewModel()
            {
                Password="123",
                UserName="alikolivand123"
            });
            return View();
        }
    }
}