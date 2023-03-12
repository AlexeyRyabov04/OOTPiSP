using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Editor.Classes
{
    [Name("Mouse")]
    internal class Mouse : PeripheralDevice
    {
        private int sensitivity;
        private bool isNoiseless;

        public Mouse(int _cost, int _guarantee, Vendor _vendor,
            int _sensitivity, bool _isNoiseless, bool _isWireless, 
            ConnectionInterface _connectionInterface) : base(_cost, _guarantee, _vendor,
            _connectionInterface, _isWireless)
        {
            sensitivity = _sensitivity;
            isNoiseless = _isNoiseless;
        }

        [Name("Sensitivity")]
        public int Sensitivity { get { return sensitivity; } set { sensitivity = value; } }
        [Name("Noiseless")]
        public bool IsNoiseless { get { return isNoiseless; } set { isNoiseless = value; } }
    }
}
