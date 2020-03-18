using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CodeGenerator
{
    public enum StructType
    {
        [Display(Name = "Класс")]
        [Description("class")]
        Class = 0,
        [Display(Name = "Структура")]
        [Description("struct")]
        Struct = 1
    }
}