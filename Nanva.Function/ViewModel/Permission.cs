using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MM = Nanva.Model.Models;

namespace Nanva.Function
{
    public class Permission
    {
        public int Id { get; set; }

        [Display(Name = "نام نقش")]
        public string PermissionTitle { get; set; }

        [Display(Name = "نام انگلیسی")]
        public int? ParentId { get; set; }
    }
    public partial class Mapper
    {
        public static Permission Map(MM.Permission entity)
        {
            return new Permission()
            {
                Id = entity.Id,
                PermissionTitle = entity.PermissionTitle,
                ParentId=entity.ParentId
            };
        }
        public static MM.Permission Map(Permission entity)
        {
            return new MM.Permission()
            {
                Id = entity.Id,
                PermissionTitle = entity.PermissionTitle,
                ParentId = entity.ParentId
            };
        }
        public static List<Permission> Map(IEnumerable<MM.Permission> entity)
        {
            var ListResult = new List<Permission>();
            foreach (var Itemlist in entity)
            {
                ListResult.Add(Map(Itemlist));
            }
            return ListResult;
        }
    }
}
