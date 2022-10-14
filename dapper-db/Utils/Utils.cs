using System.ComponentModel;
using System.Reflection;

namespace dapper_db
{
    public static class Utils
    {
        public static string GetEnumDescription(Enum value)
        {
            return value.GetType().GetMember(value.ToString()).FirstOrDefault()?.GetCustomAttribute<DescriptionAttribute>()?.Description ?? value.ToString();
        }
    }
}
