namespace Object_Editor
{
    internal class NameAttribute : Attribute
    {
        public string Name { get; }
        public NameAttribute(string name) => Name = name;
        
    }
    [AttributeUsage(AttributeTargets.Class)]
    internal class ClassAttribute : Attribute
    { 
    }
}
