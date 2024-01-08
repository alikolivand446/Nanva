using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanva.Function
{
    public class Comment
    {
        public int Id { get; set; }

        [Display(Name = "متن")]
        public string Text { get; set; }
        [Display(Name = "امتیاز")]
        public Nullable<int> Scour { get; set; }
        [Display(Name = "شخص")]
        public int PersonId { get; set; }
    }
}
