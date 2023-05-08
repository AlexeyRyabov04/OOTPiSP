using Object_Editor.Factories.SerializersFactories;
using Object_Editor.Serializers;

namespace Object_Editor.Factories.ModelsFactories
{
    public class BinarySerializerFactory : ModelFactory
    {
        public override string getName() { return "Binary files"; }
        public override string getExtension() { return "*.bin"; }
        public override ISerializer CreateSerializer()
        {
            return new BinarySerializer();
        }
    }
}
