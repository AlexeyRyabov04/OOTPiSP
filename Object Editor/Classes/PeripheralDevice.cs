using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Editor.Classes
{
    internal abstract class PeripheralDevice : ComputerPart
    {
        public enum ConnectionInterface { 
            USB, 
            eSATA, 
            HDMI, 
            DVI 
        };
        protected ConnectionInterface connectionInterface;
        protected bool isWireless;
        public PeripheralDevice(int _cost, int _guarantee, Vendor _vendor, ConnectionInterface _connectionInterface, bool _isWireless) 
            : base(_cost, _guarantee, _vendor)
        {
            connectionInterface = _connectionInterface;
            isWireless = _isWireless;
        }

        [Name("Connection Interface")]
        public ConnectionInterface _ConnectionInterface { get { return connectionInterface; } set { connectionInterface = value; } }
        [Name("Wireless")]
        public bool IsWireless { get { return isWireless; } set { isWireless = value; } }
    }
}
