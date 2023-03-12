using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Editor.Classes
{
    [Name("Headphones")]
    internal class Headphones : PeripheralDevice
    {
        private int sensitivity;
        private int impedance;

        public Headphones(int _cost, int _guarantee, Vendor _vendor,
            int _sensitivity, int _impedance, bool _isWireless,
            ConnectionInterface _connectionInterface) : base(_cost, _guarantee, _vendor,
            _connectionInterface, _isWireless)
        {
            sensitivity = _sensitivity;
            impedance = _impedance;
        }

        [Name("Sensitivity")]
        public int Sensitivity { get { return sensitivity; } set { sensitivity = value; } }
        [Name("Impedance")]
        public int Impedance { get { return impedance; } set { impedance = value; } }
    }
}
