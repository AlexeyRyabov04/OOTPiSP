using Object_Editor.Factories.SerializersFactories;
using Object_Editor.Serializers;

namespace Object_Editor.Factories.ModelsFactories
{
    public class XMLSerializerFactory : ModelFactory
    {
        public override string getName() { return "XML files"; }
        public override string getExtension() { return "*.xml"; }
        public override ISerializer CreateSerializer()
        {
            return new XMLSerializer();
        }
    }
}
