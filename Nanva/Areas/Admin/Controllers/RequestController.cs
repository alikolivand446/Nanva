using Nanva.Function;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MM= Nanva.Model.Models;
namespace Nanva.Areas.Admin.Controllers
{
    public class RequestController : Controller
    {
        private MM.DB_NanvaEntities _context;
        public RequestController()
        {
            _context = new MM.DB_NanvaEntities();
        }
        //[PermissionChecker(20)]
        public ActionResult Index()
        {
            return View(Mapper.Map(PublicContent<MM.Request>.Instance.GetAll().Where(s=>s.IsActive==true)));
        }
        //[PermissionChecker(23)]
        public ActionResult Agent(int? id)
        {
            var AgentList = PublicContent<MM.Person>.Instance.GetAll().Where(s=>s.RoleId== (int)Enums.Role.Agent).ToList();
            var listSelectListItem = new List<SelectListItem>();
            foreach (var item in AgentList)
                listSelectListItem.Add(new SelectListItem() { Text = item.Fname+" "+item.Lname, Value = item.Id.ToString() });
            ViewBag.AgentList = listSelectListItem;
            var entity = new AgentRequest() { RequestId = id };
            return View(entity); 
        }
        [HttpPost]
        public ActionResult Agent(AgentRequest entity)
        {
            entity.Id = 0;
            var AddResult = PublicContent<MM.AgentRequest>.Instance.Add(Mapper.Map(entity));
            var UpdateRequest = PublicContent<MM.Request>.Instance.GetAll().FirstOrDefault(s => s.Id == entity.RequestId);
            UpdateRequest.WorkFlowType = (byte)Enums.RequestWorkFlow.ReferToExpert;
            var resUpdate = PublicContent<MM.Request>.Instance.Update(UpdateRequest);
            var AgentList = PublicContent<MM.Person>.Instance.GetAll().Where(s => s.RoleId == (int)Enums.Role.Agent).ToList();
            var listSelectListItem = new List<SelectListItem>();
            foreach (var item in AgentList)
                listSelectListItem.Add(new SelectListItem() { Text = item.Fname + " " + item.Lname, Value = item.Id.ToString() });
            ViewBag.AgentList = listSelectListItem;
            ViewData["Issuccess"] = AddResult != null ? "true" : "false";
            return View(entity);
        }
        [HttpPost]
        public JsonResult Delete(int? id)
        {
            var Request = PublicContent<MM.Request>.Instance.GetAll().FirstOrDefault(U => U.Id == id);
            if (Request == null)
                return Json(false);
            Request.IsActive = false;
            PublicContent<MM.Request>.Instance.Update(Request);
            return Json(true);
        }
    }
}