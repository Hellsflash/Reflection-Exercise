using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        string input = Console.ReadLine();
        Type type = typeof(HarvestingFields);
        StringBuilder sb = new StringBuilder();

        while (input != "HARVEST")
        {

            switch (input)
            {
                case "private":
                    AppendFields(type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(f => f.IsPrivate));
                    break;

                case "protected":
                    AppendFields(type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(f => f.IsFamily));
                    break;

                case "public":
                    AppendFields(type.GetFields(BindingFlags.Instance | BindingFlags.Public).Where(f => f.IsPublic));
                    break;

                case "all":
                    AppendFields(type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
                    break;
            }
            input = Console.ReadLine();
        }
        Console.WriteLine(sb.ToString().Trim());

        void AppendFields(IEnumerable<FieldInfo> fields)
        {
            foreach (var field in fields)
            {
                var modifire = field.Attributes.ToString().ToLower();
                if (modifire.Equals("family"))
                {
                    modifire = "protected";
                }
                sb.AppendLine($"{modifire} {field.FieldType.Name} {field.Name}");
            }
        }
    }
}