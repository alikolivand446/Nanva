using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MM = Nanva.Model.Models;
using Nanva.Function;

namespace Nanva.Areas.UserPanel.Controllers
{
    public class CarController : PublicController
    {
        private MM.DB_NanvaEntities _context;
        public CarController()
        {
            _context = new MM.DB_NanvaEntities();
        }
        //[PermissionChecker(21)]
        public ActionResult Index()
        {
            var CarList = Mapper.Map(PublicContent<MM.Car>.Instance.GetAll().Where(s => s.PersonId == CurrentUser.PersonId && s.IsActive == true));
            return View(CarList);
        }

        //[PermissionChecker(15)]
        public ActionResult Create()
        {
            var ListPlaqueType = new List<SelectListItem>();
            foreach (Enums.PlaqueType itemEnum in (Enums.PlaqueType[])Enum.GetValues(typeof(Enums.PlaqueType)))
                ListPlaqueType.Add(new SelectListItem() { Value = ((byte)itemEnum).ToString(), Text = itemEnum.EnumPersianName() });
            ViewBag.PlaqueType = ListPlaqueType;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Car entity)
        {

            if (!ModelState.IsValid || entity == null)
            {
                var ListPlaqueType = new List<SelectListItem>();
                foreach (Enums.PlaqueType itemEnum in (Enums.PlaqueType[])Enum.GetValues(typeof(Enums.PlaqueType)))
                    ListPlaqueType.Add(new SelectListItem() { Value = ((byte)itemEnum).ToString(), Text = itemEnum.EnumPersianName() });
                ViewBag.PlaqueType = ListPlaqueType;
                ModelState.AddModelError("Color", "فرم را به درستی وارد کنید");
                return View(entity);
            }
            entity.PersonId = CurrentUser.PersonId;
            entity.IsActive = true;
            var Result = PublicContent<MM.Car>.Instance.Add(Mapper.Map(entity));
            ViewBag.UserCars = PublicContent<MM.User>.Instance.GetAll().FirstOrDefault(s => s.Id == CurrentUser.UserId).Person.Car.ToList();
            return RedirectToAction("Index");
        }

        //[PermissionChecker(17)]
        public ActionResult Edit(int? id)
        {
            var ListPlaqueType = new List<SelectListItem>();
            foreach (Enums.PlaqueType itemEnum in (Enums.PlaqueType[])Enum.GetValues(typeof(Enums.PlaqueType)))
                ListPlaqueType.Add(new SelectListItem() { Value = ((byte)itemEnum).ToString(), Text = itemEnum.EnumPersianName() });
            ViewBag.PlaqueType = ListPlaqueType;
            var entity =Mapper.Map(PublicContent<MM.Car>.Instance.GetAll().FirstOrDefault(s => s.Id == id));
            return View(entity);
        }
        [HttpPost]
        public ActionResult Edit(Car entity)
        {
            var ListPlaqueType = new List<SelectListItem>();
            foreach (Enums.PlaqueType itemEnum in (Enums.PlaqueType[])Enum.GetValues(typeof(Enums.PlaqueType)))
                ListPlaqueType.Add(new SelectListItem() { Value = ((byte)itemEnum).ToString(), Text = itemEnum.EnumPersianName() });
            ViewBag.PlaqueType = ListPlaqueType;
            if (!ModelState.IsValid || entity == null)
            {
                ModelState.AddModelError("Color", "فرم را به درستی وارد کنید");
                return View(entity);
            }
            var EntityUpdate = PublicContent<MM.Car>.Instance.GetAll().FirstOrDefault(s => s.Id == entity.Id);
            EntityUpdate.Name = entity.Name;
            EntityUpdate.Color = entity.Color;
            EntityUpdate.Model = entity.Model;
            EntityUpdate.CreateYear =Function.Convertors.DateTimeConvertor.ToMiladi(entity.CreateYearFa);
            EntityUpdate.IranNumber = entity.IranNumber;
            EntityUpdate.PlaqueThreeDigit = entity.PlaqeThreeDigit;
            EntityUpdate.PlaqueTwoDigit = entity.PlaqueTwoDigit;
            EntityUpdate.PlaqueType = entity.PlaqueType;
            ViewData["ResultCrude"] = PublicContent<MM.Car>.Instance.Update(EntityUpdate);
            return View(entity);
        }

        //[PermissionChecker(16)]
        [HttpPost]
        public JsonResult Delete(int? id)
        {
            var Car = PublicContent<MM.Car>.Instance.GetAll().FirstOrDefault(U => U.Id == id);
            if (Car == null)
                return Json(false);
            Car.IsActive = false;
            PublicContent<MM.Car>.Instance.Update(Car);
            return Json(true);
        }
    }
}