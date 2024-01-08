 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanva.Function
{
    public class Person
    {
        public int Id { get; set; }

        [Display(Name = "نام")]
        public string Fname { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string Lname { get; set; }

        [Display(Name = "سن")]
        public Nullable<byte> Age { get; set; }

        [Display(Name = "تاریخ تولد")]
        public Nullable<System.DateTime> Birthday { get; set; }

        [Display(Name = "جنسیت")]
        public Nullable<bool> Sex { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Display(Name = "موبایل")]
        public string Mobile { get; set; }

        [Display(Name = "نقش")]
        public int RoleId { get; set; }

        [Display(Name = "نام نقش")]
        public string NationalCode { get; set; }

        [Display(Name = "آدرس")]
        public string Address { get; set; }

        [Display(Name = "تصویر")]
        public byte[] Image { get; set; }

        [Display(Name = "استان")]
        public Nullable<long> ProvinceID { get; set; }

        [Display(Name = "شهرستان")]
        public Nullable<long> CityID { get; set; }

        [Display(Name = "وضعیت")]
        public Nullable<bool> IsActive { get; set; }
    }
}
