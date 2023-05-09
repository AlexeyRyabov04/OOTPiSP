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

        public PeripheralDevice() { }
        protected PeripheralDevice(PeripheralDevice peripheralDevice): base(peripheralDevice)
        {
            connectionInterface = peripheralDevice._ConnectionInterface;
            isWireless = peripheralDevice.IsWireless;
        }

        [Name("Connection Interface")]
        public ConnectionInterface _ConnectionInterface { get { return connectionInterface; } set { connectionInterface = value; } }
        [Name("Wireless")]
        public bool IsWireless { get { return isWireless; } set { isWireless = value; } }
    }
}
