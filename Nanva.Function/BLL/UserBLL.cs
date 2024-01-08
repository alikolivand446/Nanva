using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MM = Nanva.Model.Models;

namespace Nanva.Function.BLL
{
    public class UserBLL 
    {
        public static PublicContent<MM.User> Instance { get; } = new PublicContent<MM.User>();
        public static int? GetCountAllUser(bool Today=false)
        {
            var AllUser = Instance.GetAll();
            if (Today)
                return AllUser.Where(q => q.RegisterDate == DateTime.Now).Count();
           return AllUser.Count();
        }
    }
}
