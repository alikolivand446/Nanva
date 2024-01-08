using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MM = Nanva.Model.Models;
using Nanva.Function.Convertors;
using Nanva.Function;

namespace Nanva.Function
{
    public class Account
    {
        public static Nanva.Model.Models.DB_NanvaEntities _context = new MM.DB_NanvaEntities();
        public static MM.User LoginUser(LoginViewModel account)
        {
            if (account == null) return null;
            string Password = PasswordHelper.EncodePasswordMd5(account.Password);
            string UserName = FixedText.Fixed(account.UserName);
            var user = _context.User.FirstOrDefault(u => u.UserName == UserName && u.PassWord == Password);
            return user;
        }

        public static MM.User AddOrUpdateUser(User entity)
        {
            try
            {
                if (entity.Id != 0)
                {
                     _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    return new MM.User() { };
                }
                else
                {
                    var Persone = _context.Person.Add(new MM.Person()
                    {
                        RoleId = entity.Role,
                        Mobile = entity.Phone,
                        IsActive = entity.IsActive
                    });
                    var users= _context.User.Add(new MM.User()
                    {
                        IsActive = entity.IsActive,
                        PassWord = entity.PassWord,
                        PersonID = Persone.Id,
                        RegisterDate = DateTime.Now,
                        UserName = entity.UserName,
                        Phone = entity.Phone
                    });
                    _context.SaveChanges();
                    return users;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool CheckEmailAndUserName(string UserName)
        {
            var fixText = FixedText.Fixed(UserName);
            return _context.User.Any(s => s.UserName == fixText);
        }

        public static bool CheckedPermission(int permissionId, string userName)
        {
            int userId = _context.User.Single(s => s.UserName == userName).Id;
            List<int> userRoles =
                _context.User.Where(s => s.Id == userId).Select(s => s.Person.RoleId).ToList();
            if (!userRoles.Any())
                return false;
            List<int?> rolePermission = _context.RolePermission.Where(s => s.PermissionId == permissionId)?.Select(s => s.RoleId)?.ToList();
            return rolePermission != null ? rolePermission.Any(s => userRoles.Contains((int)s)) : false;
        }

        public static bool AdminPanel(string UserName)
        {
            var user = _context.User.FirstOrDefault(s=>s.UserName== UserName);
            if (user.Person.Role.RolePermission.Any(s => s.PermissionId == 9))
            {
                return true;
            }
            return true;
        }
    }
}
