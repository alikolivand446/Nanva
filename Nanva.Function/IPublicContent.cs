using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MM = Nanva.Model.Models;
using Nanva.Function;

namespace Nanva.Function
{
    public  interface IPublicContent<T> where T:class
    {
        T  Add(T Entity);
        bool Update(T Entity);
        void Delete(T Entity);
        T Find(int Id);
        IQueryable<T> GetAll();
        void Save();
    }
}
