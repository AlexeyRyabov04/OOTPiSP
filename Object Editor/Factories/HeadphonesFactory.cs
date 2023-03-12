using Object_Editor.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Editor.Factories
{
    internal class HeadphonesFactory : ComputerPartFactory
    {
        public override ComputerPart createPart(List<Object> _fields)
        {
            Vendor vendor = new Vendor(Convert.ToString(_fields[2]) ?? "name", 
                Convert.ToInt32(_fields[1]),
                Convert.ToInt32(_fields[0]));
            return new Headphones(Convert.ToInt32(_fields[4]), 
                Convert.ToInt32(_fields[3]), vendor, 
                Convert.ToInt32(_fields[8]),
                Convert.ToInt32(_fields[7]),
                Convert.ToBoolean(_fields[5]),
                (PeripheralDevice.ConnectionInterface)Enum.Parse(typeof(PeripheralDevice.ConnectionInterface), 
                Convert.ToString(_fields[6]) ?? "null"));
        }
    }
}
