using Object_Editor.Classes;
using System.Xml.Serialization;
using static Object_Editor.Classes.PeripheralDevice;

namespace Object_Editor.ClassModels
{
    [Serializable]
    [XmlInclude(typeof(HeadphonesModel))]
    [XmlInclude(typeof(KeyboardModel))]
    [XmlInclude(typeof(MouseModel))]
    public class PeripheralDeviceModel : ComputerPartModel
    {
        protected ConnectionInterface connectionInterface;
        protected bool isWireless;

        public PeripheralDeviceModel() { }
        protected PeripheralDeviceModel(PeripheralDevice peripheralDevice) : base(peripheralDevice)
        {
            connectionInterface = peripheralDevice._ConnectionInterface;
            isWireless = peripheralDevice.IsWireless;
        }

        public ConnectionInterface _ConnectionInterface { get { return connectionInterface; } set { connectionInterface = value; } }
        public bool IsWireless { get { return isWireless; } set { isWireless = value; } }
    }
}
