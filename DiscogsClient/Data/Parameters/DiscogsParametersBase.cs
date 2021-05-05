using RestSharp;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DiscogsClient.Data.Parameters
{
    public class DiscogsParametersBase
    {
        private object GetMemberValue(MemberInfo member)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Field:
                    return ((FieldInfo)member).GetValue(this);
                case MemberTypes.Property:
                    return ((PropertyInfo)member).GetValue(this);
                default:
                    return null;
            }
        }

        public Dictionary<string, string> GetParameters()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            MemberInfo[] members = GetType().GetMembers();
            foreach(var member in members)
            {
                try
                {
                    object value = GetMemberValue(member);

                    string text;
                    if (value.GetType().IsEnum)
                    {
                        text = value.GetDiscogsParameterValue();
                    }
                    else
                    {
                        text = value.ToString();
                    }

                    if (!string.IsNullOrEmpty(text))
                        parameters.Add(member.Name, text);
                }
                catch (Exception) { }
            }

            return parameters;
        }
    }
}
