using System;
using System.Collections.Generic;
using System.Linq;
using Nanva.Function;
using System.Web.Mvc;
using MM=Nanva.Model.Models;

namespace Nanva.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        private MM.DB_NanvaEntities _context;
        public RoleController()
        {
            _context = new MM.DB_NanvaEntities();
        }

        //[PermissionChecker(19)]
        public ActionResult Index( int PageId=1)
        {
            int take = 10;
            int skip = (PageId - 1) * take;
            var Roles = PublicContent<MM.Role>.Instance.GetAll().Select(Mapper.Map);
            Roles = Roles.OrderByDescending(s => s.Id).Skip(skip).Take(take);
            return View(Roles);
        }

        //[PermissionChecker(6)]
        public ActionResult Add()
        {
            ViewData["ListPermission"]= Mapper.Map(PublicContent<MM.Permission>.Instance.GetAll());

            return View();
        }

        [HttpPost]
        public ActionResult Add(Role entity ,List<int> SelectedPermission)
        {
            try
            {
                ViewData["ListPermission"] = Mapper.Map(PublicContent<MM.Permission>.Instance.GetAll());
                var Issuccess = false;
                if (string.IsNullOrEmpty(entity.NameEn) || string.IsNullOrEmpty(entity.Title))
                {
                    ModelState.AddModelError("", "");
                    return View(entity);
                }
                var AllPermiton = PublicContent<MM.RolePermission>.Instance.GetAll();
                var resultAddRole = PublicContent<MM.Role>.Instance.Add(new MM.Role() { NameEn = entity.NameEn, Title = entity.Title });
                if (resultAddRole != null)
                {
                    Issuccess = true;
                    foreach (var item in SelectedPermission)
                        PublicContent<MM.RolePermission>.Instance.Add(new MM.RolePermission() { RoleId = resultAddRole.Id, PermissionId = item });
                }
                else {
                    Issuccess = false;
                }
                ViewData["Issuccess"] = Issuccess.ToString();
                return View();
            }
            catch (Exception)
            {
                ViewData["Issuccess"] = "false";
                return View();
            }

        }

        //[PermissionChecker(8)]
        public ActionResult Edit(int Id)
        {
            ViewData["ListPermission"] = Mapper.Map(PublicContent<MM.Permission>.Instance.GetAll());
            ViewData["ListRolePermission"] = Mapper.Map(PublicContent<MM.RolePermission>.Instance.GetAll());
            var Role =Mapper.Map(_context.Role.FirstOrDefault(s => s.Id == Id));
            return View(Role);
        }

        [HttpPost]
        public ActionResult Edit(Role entity, List<int> SelectedPermission)
        {
            try
            {
                ViewData["ListPermission"] = Mapper.Map(PublicContent<MM.Permission>.Instance.GetAll());
                ViewData["ListRolePermission"] = Mapper.Map(PublicContent<MM.RolePermission>.Instance.GetAll());
                var Issuccess = false;
                if (string.IsNullOrEmpty(entity.NameEn) || string.IsNullOrEmpty(entity.Title))
                {
                    ModelState.AddModelError("", "");
                    return View(entity);
                }
                var AllPermiton = PublicContent<MM.RolePermission>.Instance.GetAll();
                var EntityUpdate = PublicContent<MM.Role>.Instance.GetAll().FirstOrDefault(s=>s.Id==entity.Id);
                EntityUpdate.NameEn = entity.NameEn;
                EntityUpdate.Title = entity.Title;
                var resultAddRole = PublicContent<MM.Role>.Instance.Update(EntityUpdate);
                if (resultAddRole )
                {
                    Issuccess = true;
                    foreach (var item in SelectedPermission)
                    {
                        if(!AllPermiton.Any(s=>s.PermissionId == item && s.RoleId == entity.Id))
                            PublicContent<MM.RolePermission>.Instance.Add(new MM.RolePermission() { RoleId = entity.Id, PermissionId = item });
                    }
                }
                else
                {
                    Issuccess = false;
                }
                ViewData["Issuccess"] = Issuccess.ToString();
                return View(Mapper.Map(EntityUpdate));
            }
            catch (Exception)
            {
                ViewData["Issuccess"] = "false";
                return View();
            }

        }

    }
}