 namespace P01_HarvestingFields
{
    using System;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            string command;
            var type = typeof(HarvestingFields);
            while ((command = Console.ReadLine()) != "HARVEST")
            {
                switch (command)
                {
                    case "protected":
                        var fields =  type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
                        foreach (var field in fields)
                        {
                            if (field.IsPrivate)
                            {

                            }
                            else
                            {
                                Console.WriteLine($"protected {field.FieldType.Name} {field.Name}");
                            }
                           
                        }
                        break;

                    case "public":
                         fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
                        foreach (var field in fields)
                        {
                            Console.WriteLine($"public {field.FieldType.Name} {field.Name}");
                        }
                        break;

                    case "all":
                        fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                        foreach (var field in fields)
                        {
                            var modifier = field.Attributes.ToString().ToLower();
                            if (modifier == "family")
                            {
                                modifier = "protected";
                            }
                            Console.WriteLine($"{modifier} {field.FieldType.Name} {field.Name}");
                        }
                        break;

                    case "private":
                        fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
                        foreach (var field in fields)
                        {
                            if (field.IsPrivate)
                            {
                                Console.WriteLine($"private {field.FieldType.Name} {field.Name}");
                            }
                           
                           
                        }
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
