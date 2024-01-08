using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Nanva.Function;
using MM = Nanva.Model.Models;
namespace Nanva.Areas.UserPanel.Controllers
{
    public class UserPanelController : PublicController
    {
        private Nanva.Model.Models.DB_NanvaEntities _context = new Nanva.Model.Models.DB_NanvaEntities();
        public ActionResult Index()
        {
            if (Session["UserID"] == null && Session["UserName"] == null)
            {
                ModelState.AddModelError("Email", "ابتدا وارد سایت شوید");
                return RedirectToAction("LogIn", "Home", new { area = "" });
            }
            var UserId = Convert.ToInt32(Session["UserID"]);
            var user = _context.User.FirstOrDefault(s => s.Id == UserId);
            return View(user);

        }

        public ActionResult ChengePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChengePassword(ChengePasswordViewModel entity)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("","");
                return View(entity);
            }

            var User = PublicContent<MM.User>.Instance.GetAll().FirstOrDefault(s => s.Id == CurrentUser.UserId);
            if (User.PassWord != PasswordHelper.EncodePasswordMd5(entity.OldPassWord))
            {
                ModelState.AddModelError("OldPassWord", "پسورد فعلی اشتباه است.");
                return View(entity);
            }

            User.PassWord = PasswordHelper.EncodePasswordMd5(entity.NewPassword);
            var UpdateUserPass = PublicContent<MM.User>.Instance.Update(User);
            if (UpdateUserPass)
                ViewBag.Issuccess = true;
            else
                ViewBag.Issuccess = false;
            return View();
        }

        public ActionResult EditProfile()
        {
            var UserEntity = PublicContent<MM.User>.Instance.GetAll().FirstOrDefault(s => s.Id == CurrentUser.UserId);
            var EditUserEntity = new EditProfileViewModel() {
                UserName = UserEntity.UserName,
                Email = UserEntity.Person.Email,
                Address = UserEntity.Person?.Address,
                Fname = UserEntity.Person?.Fname,
                Lname = UserEntity.Person?.Lname,
                NationalCode = UserEntity?.Person?.NationalCode,
                //Avatar = UserEntity.Person?.Image?.ToString(),
                Birthday=Nanva.Function.Convertors.DateTimeConvertor.ToShamsi(UserEntity.Person.Birthday),
                Phone=UserEntity?.Phone,
            };
            return View(EditUserEntity);
        }
        [HttpPost]
        public ActionResult EditProfile(EditProfileViewModel entity)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
                return View(entity);
            }
            var AllUser = PublicContent<MM.User>.Instance.GetAll();
            var UpdateUser = PublicContent<MM.User>.Instance.GetAll().FirstOrDefault(s => s.Id == CurrentUser.UserId);
            if (UpdateUser.UserName != entity.UserName.Trim().ToLower() && AllUser.Any(s => s.UserName == entity.UserName.Trim().ToLower()))
            {
                ModelState.AddModelError("UserName", "این نام کاربری قبلا استفاده شده، نام کاربری دیگری انتخاب کنید");
                return View(entity);
            }
            if (entity.Image != null && entity.Image.ContentLength > 0)
            {
                var uploadDir = "~/Content/images/UserImages";
                string FileName = new Random().Next().ToString()+ entity.Image.FileName;
                var imagePath = Path.Combine(Server.MapPath(uploadDir), FileName);
                var imageUrl = Path.Combine(uploadDir, FileName);
                entity.Image.SaveAs(imagePath);
                UpdateUser.Image = FileName;
            }
            UpdateUser.UserName = entity.UserName.Trim().ToLower();
            UpdateUser.Phone = entity.Phone;
            UpdateUser.Person.Email = entity.Email;
            UpdateUser.Person.NationalCode = entity.NationalCode;
            UpdateUser.Person.Address = entity.Address;
            UpdateUser.Person.Birthday = Function.Convertors.DateTimeConvertor.ToMiladi(entity.Birthday);
            UpdateUser.Person.Lname = entity.Lname.Trim();
            UpdateUser.Person.Fname = entity.Fname.Trim();
            var resUpdate = PublicContent<MM.User>.Instance.Update(UpdateUser);
            ViewBag.Issuccess = resUpdate;
            return View(entity);
        }
    }
}