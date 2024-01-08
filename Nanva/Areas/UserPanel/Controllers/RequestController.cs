using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MM = Nanva.Model.Models;
using Nanva.Function;

namespace Nanva.Areas.UserPanel.Controllers
{
    public class RequestController : PublicController
    {
        private MM.DB_NanvaEntities _context;
        public RequestController()
        {
            _context = new MM.DB_NanvaEntities();
        }
        public ActionResult Index()
        {
            var RequestList = Mapper.Map(PublicContent<MM.Request>.Instance.GetAll().Where(s => s.PersonId == CurrentUser.PersonId && s.IsActive == true).OrderByDescending(s=>s.Id));
            return View(RequestList);
        }
        public ActionResult Create()
        {
            ViewBag.UserCars = PublicContent<MM.User>.Instance.GetAll().FirstOrDefault(s => s.Id == CurrentUser.UserId).Person.Car.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Request entity)
        {
            entity.PersonId = PublicContent<MM.User>.Instance.GetAll().FirstOrDefault(s => s.Id == CurrentUser.UserId).Person.Id;
            entity.WorkFlowType = (byte)Enums.RequestWorkFlow.Register;
            entity.IsActive = true;
            var Result = PublicContent<MM.Request>.Instance.Add(Mapper.Map(entity));
            ViewBag.UserCars = PublicContent<MM.User>.Instance.GetAll().FirstOrDefault(s => s.Id == CurrentUser.UserId).Person.Car.ToList();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? Id)
        {
            var ListCarView = new List<SelectListItem>();
            var listCar = PublicContent<MM.User>.Instance.GetAll().FirstOrDefault(s => s.Id == CurrentUser.UserId).Person.Car;
            foreach (var item in listCar)
                ListCarView.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            ViewBag.UserCars = ListCarView;
            var RequestType = new List<SelectListItem>();
            foreach (Enums.RequestType itemEnum in (Enums.RequestType[])Enum.GetValues(typeof(Enums.RequestType)))
                RequestType.Add(new SelectListItem() { Value = ((byte)itemEnum).ToString(), Text = itemEnum.EnumPersianName() });
            ViewBag.RequestType = RequestType;
            var entity = Mapper.Map(PublicContent<MM.Request>.Instance.GetAll().FirstOrDefault(s => s.Id == Id));
            return View(entity);
        }
        [HttpPost]
        public ActionResult Edit(Request entity)
        {
            var EntityUpdate = PublicContent<MM.Request>.Instance.GetAll().FirstOrDefault(s => s.Id == entity.Id);
            EntityUpdate.Type = entity.Type;
            EntityUpdate.CarId = entity.CarId;
            EntityUpdate.Discription = entity.Discription;
            EntityUpdate.Lat = entity.Lat;
            EntityUpdate.Lng = entity.Lng;

            var ListCarView = new List<SelectListItem>();
            var listCar = PublicContent<MM.User>.Instance.GetAll().FirstOrDefault(s => s.Id == CurrentUser.UserId).Person.Car;
            foreach (var item in listCar)
                ListCarView.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            ViewBag.UserCars = ListCarView;
            var RequestType = new List<SelectListItem>();
            foreach (Enums.RequestType itemEnum in (Enums.RequestType[])Enum.GetValues(typeof(Enums.RequestType)))
                RequestType.Add(new SelectListItem() { Value = ((byte)itemEnum).ToString(), Text = itemEnum.EnumPersianName() });
            ViewBag.RequestType = RequestType;
            ViewData["ResultCrude"] = PublicContent<MM.Request>.Instance.Update(EntityUpdate);
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

        public ActionResult Map(bool Added = true, bool Show = false,string LatLngUser="")
        {
            ViewBag.Added = Added;
            ViewBag.Show = Show;
            ViewBag.LatLngUser = LatLngUser;
            if (Show)
            {
                var doublelatlng = new List<string>{
                    "35.70660392091688,51.410801410675056,تعمیرگاه اطلس",
                    "35.706900128004705,51.423547267913825,مکانیکی جواد",
                    "35.71511508009424,51.423300504684455,باطری سازی محمدی",
                    "35.716665633528464,51.44017696380616,تعویض روغنی فرهاد",
                    "35.71770570703901,51.440951585900635,مکانیکی برادران",
                    "35.716134267491135,51.441518068313606,جلو بندی اکبری",
                    "35.718219641293,51.45056676890818,باطری سازی کاظم",
                    "35.71638688457366,51.45540118217469,خدمات مکانیکی احمدی",
                    "35.71330315920414 ,51.452010869979866,اگزوز سازی",
                    "35.711404082385954,51.45007109655126,دیاگ علی"
                };
                ViewBag.ShowLatLng = doublelatlng;
            }
            return PartialView();
        }
    }
}