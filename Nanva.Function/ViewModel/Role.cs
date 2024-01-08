using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MM = Nanva.Model.Models;

namespace Nanva.Function
{
    public class Role
    {
        public int Id { get; set; }

        [Display(Name = "نام نقش")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد.")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Title { get; set; }

        [Display(Name = "نام انگلیسی")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد.")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string NameEn { get; set; }
    }
    public partial class Mapper
    {
        public static Role Map(MM.Role entity)
        {
            return new Role()
            {
                Id = entity.Id,
                NameEn = entity.NameEn,
                Title=entity.Title,
            };
        }
        public static MM.Role Map(Role entity)
        {
            return new MM.Role()
            {
                Id = entity.Id,
                NameEn = entity.NameEn,
                Title = entity.Title
            };
        }
        public static IEnumerable<Role> Map(IEnumerable<MM.Role> entity)
        {
            var ListResult = new List<Role>();
            foreach (var Itemlist in entity)
            {
                ListResult.Add(Map(Itemlist));
            }
            return ListResult;
        }
    }
}
