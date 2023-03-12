using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Editor
{
    internal class NameAttribute : Attribute
    {
        public string Name { get; }
        public NameAttribute(string name) => Name = name;
        
    }
}
