using System;
using System.Linq;
using MM = Nanva.Model.Models;

namespace Nanva.Function.BLL
{
    public class RequestBLL
    {
        public static PublicContent<MM.Request> Instance { get; } = new PublicContent<MM.Request>();
        public static int? GetCountAllRequest(bool Today=false)
        {
            var AllRequest = Instance.GetAll();
            if (Today)
                return AllRequest.Where(q => q.RequestDate == DateTime.Now).Count();
           return AllRequest.Count();
        }
    }
}
