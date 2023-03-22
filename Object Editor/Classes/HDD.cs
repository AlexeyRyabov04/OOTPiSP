namespace Object_Editor.Classes
{
    [Name("HDD")]
    [Class]
    internal class HDD : Storage
    {
        public enum ConnectionInterface { 
            IDE, 
            mSATA, 
            SAS, 
            USB, 
            SCSI, 
            SATA 
        };
        private ConnectionInterface connectionInterface;
        private int seekTime;
        private int bufferCapacity;
        public HDD() { }

        public HDD(HDD hdd): base(hdd)
        {
            seekTime = hdd.seekTime;
            bufferCapacity = hdd.bufferCapacity;
            connectionInterface = hdd._ConnectionInterface;
        }

        [Name("Connection Interface")]
        public ConnectionInterface _ConnectionInterface { get { return connectionInterface; } set { connectionInterface = value; } }
        [Name("Seek time")]
        public int SeekTime { get { return seekTime; } set { seekTime = value; } }
        [Name("Buffer capacity")]
        public int BufferCapacity { get { return bufferCapacity; } set { bufferCapacity = value; } }
    }
}
