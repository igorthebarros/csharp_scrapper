using System.ComponentModel;

namespace Scrapper.Utils
{
    public static class ScrapperUtil
    {
        public static string GetDescription(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);

            if (name == null)
                return string.Empty;

            var field = type.GetField(name);

            if(field == null)
                return string.Empty;

            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attr)
                return attr.Description;

            return value.ToString();
        }
    }
}
