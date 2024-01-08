using VM = Nanva.Function;
using System;
using System.Linq;
using System.Web.Mvc;
using MM = Nanva.Model.Models;
using Nanva.Function;
using System.Collections.Generic;

namespace Nanva.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {

        private MM.DB_NanvaEntities _context;
        public UsersController()
        {
            _context = new MM.DB_NanvaEntities();
        }
        //[PermissionChecker(18)]
        public ActionResult Index(int PageId = 1 ,string filteremail="",string filterusername="")
        {
            var Users = PublicContent<MM.User>.Instance.GetAll();
            if (!string.IsNullOrEmpty(filteremail))
                Users = Users.Where(s => s.Person.Email.Contains(filteremail));
            if (!string.IsNullOrEmpty(filterusername))
                Users = Users.Where(s => s.UserName.Contains(filterusername));
            int take = 10;
            int skip = (PageId - 1) * take;
            Users = Users.OrderByDescending(s => s.RegisterDate).Skip(skip).Take(take);
            return View(Users);
        }

        //[PermissionChecker(2)]
        public ActionResult AddUser()
        {
            ViewData["RoleList"] = _context.Role.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(VM.AddUserFromAdmin entity)
        {
            try
            {
                ViewData["RoleList"] = _context.Role.ToList();
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "فرم را تکمیل کنید");
                    return View(entity);
                }
                if (Nanva.Function.Account.CheckEmailAndUserName(entity.UserName))
                {
                    ModelState.AddModelError("UserName", "نام کاربری دیگری انتخاب کنید.");
                    return View(entity);
                }
                if (!ModelState.IsValid) return View(entity);

                var Person = _context.Person.Add(new MM.Person()
                {
                    Email = entity.Email,
                    RoleId = entity.Role,
                });
                _context.SaveChanges();
                var User = _context.User.Add(new MM.User()
                {
                    UserName = Nanva.Function.Convertors.FixedText.Fixed(entity.UserName),
                    PersonID = Person.Id,
                    RegisterDate = DateTime.Now,
                    IsActive = entity.IsActive,
                    PassWord = PasswordHelper.EncodePasswordMd5(entity.PassWord)
                });
                _context.SaveChanges();
                ViewData["Issuccess"] = "true";
                return View(entity);
            }
            catch (Exception)
            {
                ViewData["Issuccess"] = "false";
                return View(entity);
            }

        }

        //[PermissionChecker(4)]
        public ActionResult EditUser(int? id)
        {
            ViewData["RoleList"] = _context.Role.ToList();
            var User = PublicContent<MM.User>.Instance.GetAll().FirstOrDefault(s => s.Id == id);
            var UserVm = new VM.User()
            {
                Id = User.Id,
                Email = User.Person.Email,
                Phone = User.Phone,
                Role = User.Person.RoleId,
                UserName = User.UserName,
            };
            return View(UserVm);
        }

        [HttpPost]
        public ActionResult EditUser(VM.User entity)
        {
            var ModelUser = PublicContent<MM.User>.Instance.GetAll().FirstOrDefault(s => s.Id == entity.Id);
            ModelUser.Phone = entity.Phone;
            if (!string.IsNullOrEmpty(entity.PassWord))
                ModelUser.PassWord = Nanva.Function.PasswordHelper.EncodePasswordMd5(entity.PassWord);
            ModelUser.Person.RoleId = entity.Role;
            ModelUser.IsActive = entity.IsActive;
            PublicContent<MM.User>.Instance.Update(ModelUser);
            ViewData["Issuccess"] = "true";
            ViewData["RoleList"] = _context.Role.ToList();
            return View(entity);
        }

        //[PermissionChecker(3)]
        [HttpPost]
        public ActionResult DeleteUser(int? id)
        {
            var User = PublicContent<MM.User>.Instance.GetAll().FirstOrDefault(U => U.Id == id);
            if (User == null)
                return Content("false");
            User.IsActive = false;
            var result= PublicContent<MM.User>.Instance.Update(User);
            return Content(result.ToString());
        }
    }
}