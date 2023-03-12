using Object_Editor.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Object_Editor.Factories
{
    internal abstract class ComputerPartFactory
    {
        public abstract ComputerPart createPart(List<Object> _fields);
    }
}
