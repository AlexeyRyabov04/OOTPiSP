using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Editor.Classes
{
    [Name("Keyboard")]
    internal class Keyboard : PeripheralDevice
    {
        private bool hasCyrillicSupport;
        private bool hasNumpad;

        public Keyboard(int _cost, int _guarantee, Vendor _vendor,
            bool _hasCyrillicSupport, bool _hasNumpad, bool _isWireless,
            ConnectionInterface _connectionInterface) : base(_cost, _guarantee, _vendor,
            _connectionInterface, _isWireless)
        {
            hasCyrillicSupport = _hasCyrillicSupport;
            hasNumpad = _hasNumpad;
        }

        [Name("Cyrillic Support")]
        public bool HasCyrillicSupport { get { return hasCyrillicSupport; } set { hasCyrillicSupport = value; } }
        [Name("Numpad")]
        public bool HasNumpad { get { return hasNumpad; } set { hasNumpad = value; } }
    }
}
