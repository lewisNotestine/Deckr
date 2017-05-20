using System;
using System.ComponentModel;
using System.Reflection;

namespace Deckr.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum described)
        {
            var type = described.GetType();

            var member = type.GetMember(described.ToString());

            if ((member?.Length) > 0)
            {
                var attr = member[0].GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
                return string.IsNullOrWhiteSpace(attr?.Description) ? described.ToString() : attr?.Description;
            }
            return described.ToString();
        }
    }
}
