using System.ComponentModel.DataAnnotations;

namespace CodeGenerator
{
    public enum StructType
    {
        [Display(Name = "class")]
        Class = 0,
        [Display(Name = "struct")]
        Struct = 1
    }
}