using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nanva.Function
{
    public static class PublicFunction
    {
            public static string EnumPersianName(this Enum enumType)
            {
                return enumType.GetType().GetMember(enumType.ToString())
                       .First()
                       .GetCustomAttribute<DisplayAttribute>()
                        .Name;
            }
    }
}
