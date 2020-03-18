using System.ComponentModel.DataAnnotations;

namespace CodeGenerator.Models
{
    public class Field
    {
        [Required]
        public string Name { get; set; }
        public FieldType Type { get; set; }
    }
}