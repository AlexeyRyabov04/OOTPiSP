using Object_Editor.Classes;
using System.Reflection;
using System.Text;

namespace Object_Editor.Serializers
{
    public class CustomSerializer : ISerializer
    {
        public void Serialize(List<ComputerPart> obj, Stream stream)
        {
            StringBuilder sb = new StringBuilder();
            foreach (ComputerPart part in obj)
                sb.Append(SerializeObject(part));
            StreamWriter sw = new StreamWriter(stream);
            sw.Write(sb.ToString());
            sw.Flush();
        }

        public string SerializeObject(object? data)
        {
            if (data == null)
            {
                return "";
            }
            Type type = data.GetType();
            if (type.IsEnum || type == typeof(string))
                return "\"" + data.ToString()?.Replace("\"", "\"\"") + "\"";
            else if (type.IsPrimitive)
                return data.ToString() ?? "";
            StringBuilder sb = new StringBuilder();
            if (type.IsClass)
                sb.Append("[" + type.Name + ":" + SerializeProperties(data) + "]");
            return sb.ToString();
        }

        public string SerializeProperties(object data)
        {
            StringBuilder sb = new StringBuilder();
            PropertyInfo[] properties = data.GetType().GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo property = properties[i];
                if (property.CanRead)
                {
                    sb.Append(property.Name + "=");
                    sb.Append(SerializeObject(property.GetValue(data, null)));
                    if (i < properties.Length - 1)
                        sb.Append(",");
                }
            }
            return sb.ToString();
        }

        public List<ComputerPart> Deserialize(Stream stream)
        {
            List<ComputerPart> list = new();
            using var reader = new StreamReader(stream);
            string input = reader.ReadToEnd().Trim();
            int index = 0;
            while (index != input.Length)
            {
                ComputerPart? part = (ComputerPart?)ParseObject(input, ref index);
                if (part != null)
                    list.Add(part);
                else
                {
                    list.Clear();
                    throw new FileFormatException();
                }
            }
            return list;
        }

        private static object? ParseObject(string input, ref int currentIndex)
        {
            int startIndex = currentIndex;
            currentIndex++;
            string className = ParseToken(input, ref currentIndex, ':');
            Type? type = Type.GetType("Object_Editor.Classes." + className);
            Object? obj = null;
            if (type != null)
            {
                obj = Activator.CreateInstance(type);
                if (obj != null)
                {
                    PropertyInfo[] properties = obj.GetType().GetProperties();
                    while (currentIndex < input.Length && input[currentIndex++] != ']')
                    {
                        string propertyName = ParseToken(input, ref currentIndex, '=');
                        currentIndex++;
                        PropertyInfo? property = properties.FirstOrDefault(p => p.Name == propertyName);
                        if (property != null)
                        {
                            Type propertyType = property.PropertyType;
                            if (propertyType.IsEnum)
                            {
                                string enumValue = ParseQuotedToken(input, ref currentIndex);
                                property.SetValue(obj, Enum.Parse(propertyType, enumValue));
                            }
                            else if (propertyType == typeof(string))
                            {
                                string stringValue = ParseQuotedToken(input, ref currentIndex);
                                property.SetValue(obj, stringValue);
                            }
                            else if (propertyType.IsClass)
                            {
                                object? propertyValue = ParseObject(input, ref currentIndex);
                                property.SetValue(obj, propertyValue);
                            }
                            else
                            {
                                var value = ParseToken(input, ref currentIndex, ',');
                                property.SetValue(obj, Convert.ChangeType(value, propertyType));
                            }
                        }
                        else throw new FileFormatException();
                    }
                }
            }
            return obj;
        }
        private static string ParseToken(string input, ref int currentIndex, char delimiter)
        {
            int startIndex = currentIndex;
            while (currentIndex < input.Length && input[currentIndex] != delimiter && input[currentIndex] != ']')
                currentIndex++;
            return input.Substring(startIndex, currentIndex - startIndex).Trim();
        }
        private static string ParseQuotedToken(string input, ref int currentIndex)
        {
            int startIndex = ++currentIndex;
            while (currentIndex < input.Length)
            {
                if (input[currentIndex] == '"' && input[currentIndex + 1] == '"')
                    currentIndex++;
                else if (input[currentIndex] == '"')
                {
                    currentIndex++;
                    break;
                }
                currentIndex++;
            }
            return input.Substring(startIndex, currentIndex - startIndex - 1).Replace("\"\"", "\"");
        }
    }
}
