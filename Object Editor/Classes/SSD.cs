using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Object_Editor.Classes
{
    [Name("SSD")]
    internal class SSD : Storage
    {
        public enum ConnectionInterface { 
            SATA, 
            mSATA, 
            M2, 
            PCIExpress 
        };
        private ConnectionInterface connectionInterface;
        public enum Controller {
            Marvell, 
            Phison, 
            Realtek 
        };
        private Controller controller;
        public SSD(int _cost, int _guarantee, Vendor _vendor, ConnectionInterface _connectionInterface, 
            Controller _controller, int _storageCapacity, int _RWSpeed) :
            base(_cost, _guarantee, _vendor, _storageCapacity, _RWSpeed)
        {
            connectionInterface = _connectionInterface;
            controller = _controller;
        }

        [Name("Connection Interface")]
        public ConnectionInterface _ConnectionInterface { get { return connectionInterface; } set { connectionInterface = value; } }
        [Name("Controller")]
        public Controller _Controller { get { return controller; } set { controller = value; } }
    }
}
