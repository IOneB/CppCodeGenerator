using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public static class Extensions
    {
        public static string Default(this FieldType fieldType)
        {
            return fieldType switch
            {
                FieldType.Double => "0.0",
                FieldType.Float => "0.0f",
                FieldType.String => "\"\"",
                FieldType.Char => "\'\'",
                _ => "0",
            };
        }

        public static (int Value, string Name)[] GetEnumDescriptions(this Enum fieldType)
            => fieldType.GetType()
                .GetEnumValues()
                .Cast<FieldType>()
                .Select(x =>
                (
                    Value: (int)x,
                    x.GetType()
                        .GetMember(x.ToString())
                        .First()
                        .GetCustomAttribute<DisplayAttribute>()?.Name
                ))
                .ToArray();

        public static string GetEnumDescription(this Enum fieldType)
            => fieldType.GetType()
                        .GetMember(fieldType.ToString())
                        .First()
                        .GetCustomAttribute<DescriptionAttribute>()?.Description;

        public static string GetEnumDisplay(this Enum fieldType)
            => fieldType.GetType()
                        .GetMember(fieldType.ToString())
                        .First()
                        .GetCustomAttribute<DisplayAttribute>()?.Name;
    }
}
