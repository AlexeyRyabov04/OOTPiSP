using Object_Editor.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Editor.Factories
{
    internal class SSDFactory : ComputerPartFactory
    {
        public override ComputerPart createPart(List<Object> _fields)
        {
            Vendor vendor = new Vendor(Convert.ToString(_fields[2]) ?? "name",
                Convert.ToInt32(_fields[1]),
                Convert.ToInt32(_fields[0]));
            return new SSD(Convert.ToInt32(_fields[4]),
                Convert.ToInt32(_fields[3]),
                vendor, (SSD.ConnectionInterface)Enum.Parse(typeof(SSD.ConnectionInterface),
                Convert.ToString(_fields[8]) ?? "null"),
                 (SSD.Controller)Enum.Parse(typeof(SSD.Controller),
                 Convert.ToString(_fields[7]) ?? "null"),
                 Convert.ToInt32(_fields[6]), 
                 Convert.ToInt32(_fields[5]));
        }
    }
}
