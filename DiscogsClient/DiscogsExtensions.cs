using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DiscogsClient
{
    public static class DiscogsExtensions
    {
        /// <summary>
        /// Get description from selected enum
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum obj)
        {
            try
            {
                Type type = obj.GetType();
                MemberInfo[] memberInfos = type.GetMember(obj.ToString());
                MemberInfo enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == type);
                object[] valueAttributes =
                      enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return ((DescriptionAttribute)valueAttributes[0]).Description;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Adds object properties as parameters
        /// </summary>
        /// <param name="request"></param>
        /// <param name="parameter"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IRestRequest AddAsParameter(this IRestRequest request, object parameter, ParameterType type = ParameterType.QueryString)
        {
            if (parameter == null)
                return request;

            foreach (var property in parameter.GetType().GetProperties())
            {
                var value = property.GetValue(parameter, null);
                if (value == null)
                    continue;

                var key = property.Name;
                var desc = Attribute.GetCustomAttributes(property, typeof(DescriptionAttribute));
                if (desc.Length > 0)
                    key = ((DescriptionAttribute)desc[0]).Description;

                if (value.GetType().IsEnum)
                {
                    var description = ((Enum)value).GetDescription();
                    if (description.Length > 0)
                        value = description;
                }              

                request.AddParameter(key, value, type);
            }
            return request;
        }
    }
}
