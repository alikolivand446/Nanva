using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MM = Nanva.Model.Models;
namespace Nanva.Function
{
    public class Request
    {
        public int Id { get; set; }
        [Display(Name = "نوع درخواست")]
        public Nullable<byte> Type { get; set; }

        [Display(Name = "نوع درخواست")]
        public string TypeName { get; set; }

        [Display(Name = "مرحله درخواست")]
        public Nullable<byte> WorkFlowType { get; set; }

        [Display(Name = "مرحله درخواست")]
        public string WorkFlowTypeName { get; set; }

        [Display(Name = "توضیحات")]
        public string Discription { get; set; }

        [Display(Name = "نقطه درخواست")]
        public string MapPoint { get; set; }

        [Display(Name = "شخص")]
        public int PersonId { get; set; }

        [Display(Name = "شخص")]
        public string PersonName { get; set; }

        [Display(Name = "ماشین")]
        public int CarId { get; set; }

        [Display(Name = "ماشین")]
        public string CarName { get; set; }

        [Display(Name = "تاریخ درخواست")]
        public DateTime? RequestDate { get; set; }
        [Display(Name = "تاریخ درخواست")]
        public string RequestDateFa { get; set; }
        public bool? IsActive { get; set; }

        [Display(Name = "عرض جغرافیایی")]
        public double? Lat { get; set; }

        [Display(Name = "طول جغرافیایی")]
        public double? Lng { get; set; }
        public MM.Person Person { get; set; }
    }
    public partial class Mapper
    {
        public static Request Map(MM.Request entity)
        {
            return new Request()
            {
                Id = entity.Id,
                CarId = entity.CarId,
                CarName = entity.Car.Name,
                Discription = entity.Discription,
                PersonId = entity.PersonId,
                PersonName = entity?.Person?.Fname??"" + " " + entity?.Person?.Lname??"",
                Type = entity.Type,
                TypeName = entity.Type != null ? ((Enums.RequestType)Enum.Parse(typeof(Enums.RequestType), entity.Type.ToString())).EnumPersianName() : "",
                WorkFlowType = entity.WorkFlowType,
                WorkFlowTypeName= entity.WorkFlowType != null ? ((Enums.RequestWorkFlow)Enum.Parse(typeof(Enums.RequestWorkFlow), entity.WorkFlowType.ToString())).EnumPersianName() :"",
                RequestDate =entity.RequestDate,
                RequestDateFa= entity.RequestDate !=null?Nanva.Function.Convertors.DateTimeConvertor.ToShamsi((DateTime)entity.RequestDate):"",
                IsActive=entity.IsActive,
                Person=entity.Person,
                Lat=entity.Lat,
                Lng=entity.Lng,
            };
        }
        public static MM.Request Map(Request entity)
        {
            return new MM.Request()
            {
                Id = entity.Id,
                CarId = entity.CarId,
                Discription = entity.Discription,
                PersonId = entity.PersonId,
                Type = entity.Type,
                WorkFlowType = entity.WorkFlowType,
                RequestDate = DateTime.Now,
                MapPoint=entity.MapPoint,
                IsActive = entity.IsActive,
                Person = entity.Person,
                Lat = entity.Lat,
                Lng = entity.Lng,
            };
        }
        public static IEnumerable<Request> Map(IEnumerable<MM.Request> entity)
        {
            var ListResult = new List<Request>();
            foreach (var Itemlist in entity)
            {
                ListResult.Add(Map(Itemlist));
            }
            return ListResult;
        }
    }
}
