namespace Hierarchy
{
    class Vendor 
    {
        private string name;
        private int yearOfFoundation;
        private int yearIncome;
    }
    abstract class ComputerPart
    {
        protected int cost;
        protected Vendor vendor;
        protected int guarantee;
    }

    abstract class PeripheralDevice : ComputerPart
    {
        public enum ConnectionInterface { USB, eSATA, HDMI, DVI };
        protected ConnectionInterface connectionInterface;
        protected bool isWireless;
    }

    class Headphones : PeripheralDevice
    {
        private int sensitivity;
        private int impedance;
    }

    class Keyboard : PeripheralDevice
    {
        private bool hasCyrillicSupport;
        private bool hasNumpad;
    }

    class Mouse : PeripheralDevice
    {
        private int sensitivity;
        private bool isNoiseless;
    }

    class CPU : ComputerPart
    {
        private int numberOfCores;
        private double frequency;
    }

    class MotherBoard : ComputerPart
    {
        private int numberOfMemorySlots;
        public enum Socket { SocketB2, PAC611, LGA1200, Socket478 };
        private Socket socket;
        public enum Format { AT, ATX, LPX, NLX };
        private Format format;
    }

    class VideoCard : ComputerPart
    {
        private int memoryFrequency;
        private int busWidth;
        private int fillrate;
    }

    abstract class Storage : ComputerPart
    {
        protected int storageCapacity;
        protected int RWSpeed;
    }

    class HDD : Storage
    {
        private int bufferCapacity;
        public enum ConnectionInterface { IDE, mSATA, SAS, USB, SCSI, SATA};
        private ConnectionInterface connectionInterface;
        private double seekTime;

    }

    class SSD : Storage
    {
        public enum ConnectionInterface { SATA, mSATA, M2, PCIExpress };
        private ConnectionInterface connectionInterface;
        public enum Controller { Marvell, Phison, Realtek };
        private Controller controller;
    }
    
}
