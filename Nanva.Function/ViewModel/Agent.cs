using Nanva.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nanva.Function;
using MM = Nanva.Model.Models;

namespace Nanva.Function
{
    public class Agent
    {
        public int Id { get; set; }

        [Display(Name="نام کارشناس")]
        public string Name { get; set; }

        [Display(Name = "نظرات")]
        public string Comment { get; set; }

        [Display(Name = "نظرات")]
        public int CommentId { get; set; }

        [Display(Name = "اشخاص")]
        public MM.Person Person { get; set; }
        public int PersonId { get; set; }
    }
    public partial class Mapper
    {
        public static Agent Map(MM.Agent entity)
        {
            return new Agent()
            {
                Id = entity.Id,
                Name = entity.Name,
                CommentId = entity.CommentId,
                Person = entity.Person,
                PersonId = entity.PersonId,
            };
        }
        public static MM.Agent Map(Agent entity)
        {
            return new MM.Agent()
            {
                Id = entity.Id,
                Name = entity.Name,
                CommentId = entity.CommentId,
                Person = entity.Person,
                PersonId = entity.PersonId,
            };
        }
        public static IEnumerable<Agent> Map(IEnumerable<MM.Agent> entity)
        {
            var ListResult = new List<Agent>();
            foreach (var Itemlist in entity)
            {
                ListResult.Add(Map(Itemlist));
            }
            return ListResult;
        }
    }
}
