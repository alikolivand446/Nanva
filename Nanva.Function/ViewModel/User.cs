using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MM = Nanva.Model.Models;

namespace Nanva.Function
{
    public class User
    {
        public int Id { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد.")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserName { get; set; }

        [Display(Name = "تلفن")]
        public string Phone { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد.")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [EmailAddress(ErrorMessage = "فرمت ایمیل نادرست است.")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0}نمیتواند خالی باشد .")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string PassWord { get; set; }

        [Display(Name = "تکرار کلمه عبور")]
        [Required(ErrorMessage = "{0}نمیتواند خالی باشد .")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string ConfirmPassWord { get; set; }

        [Display(Name = "تاریخ ثبت نام")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        public int Role { get; set; }
    }

    public class LoginViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد.")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserName { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0}نمیتواند خالی باشد .")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool Remember { get; set; }

        public bool LoginRequired { get; set; }
        public string ReturnUrl { get; set; }
    }
    public class ChengePasswordViewModel
    {
        [Display(Name = "کلمه عبور قبلی")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد.")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string OldPassWord { get; set; }

        [Display(Name = "کلمه عبور جدید")]
        [Required(ErrorMessage = "{0}نمیتواند خالی باشد .")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string NewPassword { get; set; }

        [Display(Name = "تکرار کلمه عبور جدید")]
        [Required(ErrorMessage = "{0}نمیتواند خالی باشد .")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [Compare("NewPassword", ErrorMessage = "کلمه عبور با تکرار مغایرت ندارد.")]
        public string ConfirmPassWord { get; set; }
    }

    public class EditProfileViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد.")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد.")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [EmailAddress(ErrorMessage = "فرمت ایمیل نادرست است.")]
        public string Email { get; set; }

        [Display(Name = "نام ")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد.")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Fname { get; set; }

        [Display(Name = "نام خانوادگی ")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد.")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Lname { get; set; }


        [Display(Name = "تاریخ تولد ")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد.")]
        public string Birthday { get; set; }

        [Display(Name = " کدملی ")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد.")]
        [MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string NationalCode { get; set; }

        [Display(Name = " تلفن همراه ")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد.")]
        [MaxLength(11, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Phone { get; set; }

        [Display(Name = " آدرس ")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد.")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Address { get; set; }

        [Display(Name = "تصویر")]
        public HttpPostedFileBase Image { get; set; }
    }

    public class AddUserFromAdmin
    {

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد.")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserName { get; set; }

        //[Display(Name = "تلفن")]
        //public string Phone { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد.")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [EmailAddress(ErrorMessage = "فرمت ایمیل نادرست است.")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0}نمیتواند خالی باشد .")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string PassWord { get; set; }

        [Display(Name = "تکرار کلمه عبور")]
        [Required(ErrorMessage = "{0}نمیتواند خالی باشد .")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string ConfirmPassWord { get; set; }

        //[Display(Name = "تاریخ ثبت نام")]
        //public DateTime RegisterDate { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        public int Role { get; set; }
    }
}
