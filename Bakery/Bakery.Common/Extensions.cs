using System;
using System.ComponentModel;

namespace Bakery.Common
{
    public static class Extensions
    {
        public static string GetDescription(this Enum en)
        {
            var type = en.GetType();
            var memInfo = type.GetMember(en.ToString());
            if (memInfo == null || memInfo.Length <= 0)
                return en.ToString();
            var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute),false);
            if (attrs != null && attrs.Length > 0)
                return ((DescriptionAttribute)attrs[0]).Description;
            return en.ToString();
        }
    }
}