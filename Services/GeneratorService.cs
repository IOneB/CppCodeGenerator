using CodeGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class GeneratorService
    {

        public string Generate(Class data)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{data.Type.GetEnumDescription()} {data.Name} {{"); // Заголовок

            if (data.HasFields)
            {
                sb.AppendLine("    private:");  // поля
                sb.AppendLine($"{string.Join("\r\n", data.Fields.Select(x => $"        {x.Type.GetEnumDisplay()} {x.Name};"))}"); // Список полей
            }

            if (data.HasConstructor || data.HasFields)
                sb.AppendLine("    public:");

            if(data.HasConstructor)
                sb.AppendLine(Constructors(data));

            if (data.HasFields)
            {
                sb.AppendLine($"{string.Join("\r\n", data.Fields.Select(x => Properties(x)))}");
            }
            sb.AppendLine("};");

            return sb.ToString();
        }

        private string Constructors(Class data)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"        {data.Name}(){{");
            if (data.HasFields)
            {
                foreach (var field in data.Fields)
                {
                    sb.AppendLine($"            {field.Name} = {field.Type.Default()};");
                }
            }
            sb.AppendLine("        }");

            // Конструктор с параметрами
            if (data.HasFields)
            {
                sb.AppendLine($"        {data.Name}({string.Join(", ", data.Fields.Select(x => $"{x.Type.GetEnumDisplay()} {x.Name}"))}){{");
                foreach (var field in data.Fields)
                {
                    sb.AppendLine($"            this->{field.Name} = {field.Name};");
                }

                sb.AppendLine("        }");
            }

            return sb.ToString();
        }

        private string Properties(Field x)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"        {x.Type.GetEnumDisplay()} get_{x.Name}() {{");  // get-method
            sb.AppendLine($"            return this->{x.Name};");
            sb.AppendLine("        }");

            sb.AppendLine($"        void set_{x.Name}({x.Type.GetEnumDisplay()} new_{x.Name}){{");   // set-method
            sb.AppendLine($"            this->{x.Name} = new_{x.Name};");
            sb.AppendLine("        }");

            return sb.ToString();
        }
    }
}
