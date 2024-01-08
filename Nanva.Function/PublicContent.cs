using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MM = Nanva.Model.Models;
using Nanva.Function;

namespace Nanva.Function
{
    public  class PublicContent<T>:IPublicContent<T> where T :class
    {
        public static PublicContent<T> Instance { get; } = new PublicContent<T>();
        private static MM.DB_NanvaEntities _Context ;
        public PublicContent()
        {
            _Context = new MM.DB_NanvaEntities();
        }

        public T Add(T Entity)
        {
            if (Entity == null)
                return null;
            var Result= _Context.Set<T>().Add(Entity);
            Save();
            return Result;
        }

        public void Delete(T Entity)
        {
            if (Entity == null)
                return;
            _Context.Set<T>().Remove(Entity);
        }

        public  T Find(int Id)
        {
            return _Context.Set<T>().Find(Id);
        }

        public T Get(T Entity)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _Context.Set<T>();
        }

        public T GetById(int Id)
        {
            return null;
        }

        public void Save()
        {
            _Context.SaveChanges();
        }

        public bool Update(T Entity)
        {
            try
            {
                if (Entity == null)return false;
                _Context.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
                Save();
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        public string GetImageByUserName(string UserName)
        {
            return PublicContent<MM.User>.Instance.GetAll().FirstOrDefault(s => s.UserName == UserName)?.Image;
        }
    }
}
