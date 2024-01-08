using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MM = Nanva.Model.Models;
using Nanva.Function.Convertors;

namespace Nanva.Function
{
    public class Car
    {
        public int Id { get; set; }

        [Display(Name = "نام ماشین")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد.")]
        public string Name { get; set; }

        [Display(Name = "رنگ")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد.")]
        public string Color { get; set; }

        [Display(Name = "مدل")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد.")]
        public string  Model { get; set; }

        public DateTime CreateYear { get; set; }

        [Display(Name = "سال ساخت")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد.")]
        public string CreateYearFa { get; set; }

        [Display(Name = "شماره پلاک")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد.")]
        public string IranNumber { get; set; }

        [Display(Name = "سه رقم پلاک")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد.")]
        public string PlaqeThreeDigit { get; set; }

        [Display(Name = "دو رقم پلاک")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد.")]
        public string PlaqueTwoDigit { get; set; }

        [Display(Name = "نوع پلاک")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد.")]
        public byte? PlaqueType { get; set; }

        public string PlaqueTypeFa { get; set; }

        /// <summary>
        /// نمایش پلاک به صورت کلی
        /// </summary>
        [Display(Name = "پلاک")]
        public string PlaqueFull { get; set; }

        [Display(Name = "مالک")]
        public string PersonName { get; set; }

        [Display(Name = "شخص")]
        public int PersonId { get; set; }
        public  MM.Person Person { get; set; }

        public bool? IsActive { get; set; }
    }
    public partial class Mapper
    {
        public static Car Map(MM.Car entity)
        {
            return new Car()
            {
                Id = entity.Id,
                Name = entity.Name,
                Color = entity.Color,
                Model = entity.Model,
                CreateYearFa = entity.CreateYear != null?DateTimeConvertor.ToShamsi((DateTime)entity.CreateYear):null,
                PersonName = entity.Person.Fname + " " + entity.Person.Lname,
                IranNumber = entity.IranNumber,
                PlaqeThreeDigit = entity.PlaqueThreeDigit,
                PlaqueTwoDigit = entity.PlaqueTwoDigit,
                PlaqueFull = entity.PlaqueTwoDigit + entity.PlaqueType != null ? ((Enums.PlaqueType)Enum.Parse(typeof(Enums.PlaqueType), entity.PlaqueType.ToString())).EnumPersianName() : "" + entity.PlaqueThreeDigit + "[" + entity.IranNumber + "]",
                PlaqueType = entity.PlaqueType,
                PlaqueTypeFa = entity.PlaqueType != null ? ((Enums.PlaqueType)Enum.Parse(typeof(Enums.PlaqueType), entity.PlaqueType.ToString())).EnumPersianName() : "",
                PersonId= entity.PersonId,
                Person = entity.Person,
                IsActive=entity.IsActive,
            };
        }
        public static MM.Car Map(Car entity)
        {
            return new MM.Car()
            {
                Id = entity.Id,
                Name = entity.Name,
                Color = entity.Color,
                Model = entity.Model,
                CreateYear = DateTimeConvertor.ToMiladi(entity.CreateYearFa),
                IranNumber = entity.IranNumber,
                PlaqueThreeDigit = entity.PlaqeThreeDigit,
                PlaqueTwoDigit = entity.PlaqueTwoDigit,
                PlaqueType = entity.PlaqueType,
                PersonId=entity.PersonId,
                Person=entity.Person,
                IsActive = entity.IsActive,
            };
        }
        public static IEnumerable<Car> Map(IEnumerable<MM.Car> entity)
        {
            var ListResult = new List<Car>();
            foreach (var Itemlist in entity)
            {
                ListResult.Add(Map(Itemlist));
            }
            return ListResult;
        }
    }
}
