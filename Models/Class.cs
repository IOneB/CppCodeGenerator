using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CodeGenerator.Models
{
    public class Class
    {
        [Required]
        public string Name { get; set; }

        public StructType Type { get; set; }

        public bool HasConstructor { get; set; }

        public List<Field> Fields { get; set; }

        public bool HasFields => Fields != null && Fields.Count > 0;
    }
}
