using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public static class Extensions
    {
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
                        .GetCustomAttribute<DisplayAttribute>()?.Name;
    }
}
