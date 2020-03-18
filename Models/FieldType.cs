using System.ComponentModel.DataAnnotations;

namespace CodeGenerator
{
    public enum FieldType
    {
        [Display(Name = "int")]
        Int = 0,
        [Display(Name = "double")]
        Double = 1,
        [Display(Name = "float")]
        Float = 2,
        [Display(Name = "string")]
        String = 3,
        [Display(Name = "char")]
        Char = 4,
    }
}