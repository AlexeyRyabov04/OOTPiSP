using static Object_Editor.Classes.HDD;

namespace Object_Editor.Classes
{
    [Name("SSD")]
    [Class]
    public class SSD : Storage
    {
        public enum SSDInterface { 
            SATA, 
            mSATA, 
            M2, 
            PCIExpress 
        };
        private SSDInterface connectionInterface;
        public enum Controller {
            Marvell, 
            Phison, 
            Realtek 
        };
        private Controller controller;
        public SSD() { }
        public SSD(SSD ssd): base(ssd)
        {
            connectionInterface = ssd._ConnectionInterface;
            controller = ssd._Controller;
        }
        public SSD(int _cost, int _guarantee, Vendor _vendor, int _storageCapacity, int _RWSpeed,
            SSDInterface _connectionInterface, Controller _controller)
            : base(_cost, _guarantee, _vendor, _storageCapacity, _RWSpeed)
        {
            connectionInterface = _connectionInterface;
            controller = _controller;
        }
        [Name("Connection Interface")]
        public SSDInterface _ConnectionInterface{ get { return connectionInterface; } set { connectionInterface = value; } }
        [Name("Controller")]
        public Controller _Controller { get { return controller; } set { controller = value; } }
    }
}
