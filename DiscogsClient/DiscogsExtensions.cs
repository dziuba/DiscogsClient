using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DiscogsClient
{
    public static class DiscogsExtensions
    {
        public static string GetDiscogsParameterValue(this object obj)
        {
            try
            {
                Type type = obj.GetType();
                MemberInfo[] memberInfos = type.GetMember(obj.ToString());
                MemberInfo enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == type);
                object[] valueAttributes =
                      enumValueMemberInfo.GetCustomAttributes(typeof(DiscogsParameterValueAttribute), false);
                return ((DiscogsParameterValueAttribute)valueAttributes[0]).Value;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
