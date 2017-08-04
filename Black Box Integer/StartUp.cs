using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        string input = Console.ReadLine();

        var type = typeof(BlackBoxInt);
        var instance = Activator.CreateInstance(type, true);
        var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        while (input != "END")
        {
            var inputArgs = input.Split('_');
            var digit = int.Parse(inputArgs[1]);

            methods.FirstOrDefault(m => m.Name == inputArgs[0])?.Invoke(instance, new object[] { digit });

            foreach (var field in fields)
            {
                sb.AppendLine(field.GetValue(instance).ToString());
            }
            input = Console.ReadLine();
        }
        Console.WriteLine(sb.ToString().Trim());
    }
}