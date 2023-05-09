using Object_Editor.Serializers;

namespace Object_Editor.Factories.SerializersFactories
{
    public abstract class ModelFactory
    {
        public abstract string getName();
        public abstract string getExtension();
        public abstract ISerializer CreateSerializer();
    }
}
