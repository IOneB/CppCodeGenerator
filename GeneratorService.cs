using CodeGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class GeneratorService
    {

        public string Generate(Class data)
            => $"{data.Type.GetEnumDescription()} {data.Name} {{\r\n" +
                "    private:\r\n" +
                    $"{string.Join("\r\n", data.Fields.Select(x => $"        {x.Type.GetEnumDescription()} {x.Name};"))}\r\n" +
                "    public:\r\n" +
                    @$"{string.Join("\r\n", data.Fields.Select(x =>
                        Properties(x))) + "\r\n"}" +
                "};";

        private static string Properties(Field x)
        {
            return $"        {x.Type.GetEnumDescription()} get_{x.Name}() {{\r\n" +
                $"            return this->{x.Name};\r\n" +
                "        }\r\n" +
                $"        void set_{x.Name}({x.Type.GetEnumDescription()} new_{x.Name}){{\r\n" +
                $"            this->{x.Name} = new_{x.Name};\r\n" +
                $"        }}";
        }
    }
}
