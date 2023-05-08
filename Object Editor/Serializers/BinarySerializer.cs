using Object_Editor.Classes;
using Object_Editor.ClassModels;
using System.Runtime.Serialization.Formatters.Binary;

#pragma warning disable SYSLIB0011
namespace Object_Editor.Serializers
{
    public class BinarySerializer : ISerializer
    {
        public void Serialize(List<ComputerPart> obj, Stream stream)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(stream, ModelConverter.ModelsFromClasses(obj));
        }

        public List<ComputerPart> Deserialize(Stream stream)
        {
            BinaryFormatter deserializer = new BinaryFormatter();
            var obj = deserializer.Deserialize(stream) ?? new List<ComputerPartModel>();
            return ModelConverter.ModelsToClasses((List<ComputerPartModel>)obj);
        }
    }
}
#pragma warning restore SYSLIB0011