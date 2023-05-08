using Object_Editor.Classes;

namespace Object_Editor.Serializers
{
    public interface ISerializer
    {
        void Serialize(List<ComputerPart> obj, Stream stream);
        List<ComputerPart> Deserialize(Stream stream);
    }
}
