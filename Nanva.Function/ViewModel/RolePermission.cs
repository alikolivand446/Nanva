using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MM = Nanva.Model.Models;

namespace Nanva.Function
{
    public class RolePermission
    {
        public int Id { get; set; }

        [Display(Name = "نقش")]
        public int? RoleId { get; set; }

        [Display(Name = "دسترسی")]
        public int? PermissionId { get; set; }

    }
    public partial class Mapper
    {
        public static RolePermission Map(MM.RolePermission entity)
        {
            return new RolePermission()
            {
                Id = entity.Id,
                RoleId = entity.RoleId,
                PermissionId=entity.PermissionId
            };
        }
        public static MM.RolePermission Map(RolePermission entity)
        {
            return new MM.RolePermission()
            {
                Id = entity.Id,
                RoleId = entity.RoleId,
                PermissionId = entity.PermissionId
            };
        }
        public static List<RolePermission> Map(IEnumerable<MM.RolePermission> entity)
        {
            var ListResult = new List<RolePermission>();
            foreach (var Itemlist in entity)
            {
                ListResult.Add(Map(Itemlist));
            }
            return ListResult;
        }
    }
}
