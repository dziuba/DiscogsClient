using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
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
        public static RestRequest AddAsParameter(this RestRequest request, object parameter, ParameterType type = ParameterType.QueryString, IFormatProvider[] providers = null)
        {
            if (parameter == null)
                return request;

            if (providers == null)
                providers = DiscogsClientConfiguration.RestParameterFormatProviders;

            foreach (var property in parameter.GetType().GetProperties())
            {
                var value = property.GetValue(parameter, null);
                if (value == null)
                    continue;

                var key = property.Name;
                var desc = Attribute.GetCustomAttributes(property, typeof(DescriptionAttribute));
                if (desc.Length > 0)
                    key = ((DescriptionAttribute)desc[0]).Description;

                if (providers != null)
                    value = providers.FormatData(value);          

                request.AddParameter(key, value, type);
            }
            return request;
        }

        /// <summary>
        /// Formats data with supplied providers
        /// </summary>
        /// <param name="providers"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static object FormatData(this IFormatProvider[] providers, object element)
        {
            foreach (var provider in providers)
            {
                try
                {
                    return string.Format(provider, "{0}", element);
                }
                catch (FormatException) { }
            }

            return element;
        }

        /// <summary>
        /// Serialize object to json (Newtonsoft) and add it to request's body
        /// </summary>
        /// <param name="request"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static RestRequest SerializeToJsonBody(this RestRequest request, object obj)
        {
            if (obj == null)
                return request;

            //var converter = new StringEnumConverter();
            string json = JsonConvert.SerializeObject(obj);

            request.AddParameter("application/json", json, ParameterType.RequestBody); 
            
            return request;
        }
    }
}
