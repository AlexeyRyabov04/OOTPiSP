namespace Object_Editor.Classes
{
    [Name("HDD")]
    [Class]
    public class HDD : Storage
    {
        public enum HDDInterface { 
            IDE, 
            mSATA, 
            SAS, 
            USB, 
            SCSI, 
            SATA 
        };
        private HDDInterface connectionInterface;
        private int seekTime;
        private int bufferCapacity;
        public HDD() { }

        public HDD(HDD hdd): base(hdd)
        {
            seekTime = hdd.seekTime;
            bufferCapacity = hdd.bufferCapacity;
            connectionInterface = hdd._ConnectionInterface;
        }
        public HDD(int _cost, int _guarantee, Vendor _vendor, int _storageCapacity, int _RWSpeed,
            HDDInterface _connectionInterface, int _seekTime, int _bufferCapacity)
            : base(_cost, _guarantee, _vendor, _storageCapacity, _RWSpeed)
        {
            connectionInterface = _connectionInterface;
            seekTime = _seekTime;
            bufferCapacity = _bufferCapacity;
        }

        [Name("Connection Interface")]
        public HDDInterface _ConnectionInterface { get { return connectionInterface; } set { connectionInterface = value; } }
        [Name("Seek time")]
        public int SeekTime { get { return seekTime; } set { seekTime = value; } }
        [Name("Buffer capacity")]
        public int BufferCapacity { get { return bufferCapacity; } set { bufferCapacity = value; } }
    }
}
