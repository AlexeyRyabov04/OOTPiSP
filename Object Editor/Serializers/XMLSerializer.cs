using Object_Editor.Classes;
using System.Xml.Serialization;
using Object_Editor.ClassModels;

namespace Object_Editor.Serializers
{
    public class XMLSerializer : ISerializer
    {
        public void Serialize(List<ComputerPart> obj, Stream stream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<ComputerPartModel>));
            serializer.Serialize(stream, ModelConverter.ModelsFromClasses(obj));
        }

        public List<ComputerPart> Deserialize(Stream stream)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<ComputerPartModel>));
            var obj = deserializer.Deserialize(stream) ?? new List<ComputerPartModel>();
            return ModelConverter.ModelsToClasses((List<ComputerPartModel>)obj);
        }
    }
}
