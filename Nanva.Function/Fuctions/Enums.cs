using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanva.Function
{
    public class Enums
    {
        /// <summary>
        /// نوع نقش
        /// </summary>
        public enum Role
        {
            [Display(Name = "خدا")]
            God = 1,
            [Display(Name = "مدیرسایت")]
            Admin = 2,
            [Display(Name = "کاربرعادی")]
            User = 3,
            [Display(Name = "کارشناس")]
            Agent = 4,
        }

        /// <summary>
        /// نوع درخواست کاربر
        /// </summary>
        public enum RequestType
        {
            /// <summary>
            /// اعزام درخواست تعمیر ماشین
            /// </summary>
            [Display(Name = "اعزام برای تعمیر ماشین")]
            Repair = 1,
            /// <summary>
            /// تعمیر ماشین حضوری
            /// </summary>
            [Display(Name = "تعمیر ماشین  حضوری ")]
            RepairFaceToFace = 3,
            /// <summary>
            ///  اعزام درخواست آنی سرویس 
            /// </summary>
            [Display(Name = "اعزام برای آنی سرویس")]
            Fueling = 2,
            /// <summary>
            /// اعزام قیمت گذاری
            /// </summary>
            [Display(Name = "اعزام برای قیت گذاری")]
            Pricing = 4,
        }

        /// <summary>
        /// مرحله درخواست
        /// </summary>
        public enum RequestWorkFlow
        {
            /// <summary>
            /// ثبت درخواست مرحله اول
            /// </summary>
            [Display(Name = "ثبت درخواست")]
            Register = 1,
            /// <summary>
            /// تایید به دست مدیر سیستم مرحله دوم
            /// </summary>
            [Display(Name = "تایید به دست مدیر")]
            Confirmation = 2,
            /// <summary>
            /// ارجاع به کارشناس
            /// </summary>
            [Display(Name = "ارجاع به کارشناس")]
            ReferToExpert = 3,
            /// <summary>
            /// مختومه درخواست مرحله آخر
            /// </summary>
            [Display(Name = "مختومه")]
            Finish = 4,
        }
        /// <summary>
        /// نوع  پلاک
        /// </summary>
        public enum PlaqueType
        {
            [Display(Name = "ب")]
            B = 1,

            [Display(Name = "د")]
            D = 2,

            [Display(Name = "ج")]
            J = 3,

            [Display(Name = "س")]
            C = 4,

            [Display(Name = "ص")]
            S = 5,

            [Display(Name = "ط")]
            T = 6,

            [Display(Name = "ق")]
            GH = 7,

            [Display(Name = "ل")]
            L = 8,
            [Display(Name = "م")]
            M = 9,

            [Display(Name = "ن")]
            N = 10,

            [Display(Name = "و")]
            V = 11,

            [Display(Name = "ه")]
            H = 12,
            [Display(Name = "ی")]
            Y = 13,

            /// <summary>
            /// ادارات و نهادهای دولتی		
            /// </summary>
            [Display(Name = "الف")]
            A = 14,

            /// <summary>
            /// پلیس (نیروی انتظامی)	
            /// </summary>
            [Display(Name = "پ")]
            P = 15,

            /// <summary>
            /// تاکسی ها
            /// </summary>
            [Display(Name = "ت")]
            Taxi = 16,

            /// <summary>
            /// سپاه پاسداران انقلاب اسلامی	
            /// </summary>
            [Display(Name = "ث")]
            C2 = 17,

            /// <summary>
            /// وزارت دفاع و پشتیبانی نیروهای مسلح
            /// </summary>
            [Display(Name = "ز")]
            Z = 18,

            /// <summary>
            /// معلولین و جانبازان (نماد ویلچر)	
            /// </summary>
            [Display(Name = "ژ")]
            ZH = 19,

            /// <summary>
            /// ارتش جمهوری اسلامی ایران	
            /// </summary>
            [Display(Name = "ش")]
            SH = 20,

            /// <summary>
            /// خودروهای عمومی	
            /// </summary>
            [Display(Name = "ع")]
            Ai = 21,

            /// <summary>
            /// ستاد فرماندهی کل نیروهای مسلح	
            /// </summary>
            [Display(Name = "ف")]
            F = 22,

            /// <summary>
            /// ماشین آلات کشاورزی
            /// </summary>
            [Display(Name = "ک")]
            K = 23,

            /// <summary>
            /// گذر موقت 
            /// </summary>
            [Display(Name = "گ")]
            G = 24,

            /// <summary>
            /// دیپلمات سفارتخانه
            /// </summary>
            [Display(Name = "ف")]
            Dip = 25,

            /// <summary>
            /// سرویس‌های سفارتخانه
            /// </summary>
            [Display(Name = "ک")]
            Service = 26,
        }
    }
}
