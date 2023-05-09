using Object_Editor.Factories.SerializersFactories;
using Object_Editor.Serializers;

namespace Object_Editor.Factories.ModelsFactories
{
    public class CustomSerializerFactory : ModelFactory
    {
        public override string getName() { return "Text files"; }
        public override string getExtension() { return "*.txt"; }
        public override ISerializer CreateSerializer()
        {
            return new CustomSerializer();
        }
    }
}
