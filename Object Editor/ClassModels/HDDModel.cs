using Object_Editor.Classes;
using static Object_Editor.Classes.HDD;

namespace Object_Editor.ClassModels
{
    [Serializable]
    public class HDDModel : StorageModel
    {
        private HDDInterface connectionInterface;
        private int seekTime;
        private int bufferCapacity;
        public HDDModel() { }

        public HDDModel(HDD hdd) : base(hdd)
        {
            seekTime = hdd.SeekTime;
            bufferCapacity = hdd.BufferCapacity;
            connectionInterface = hdd._ConnectionInterface;
        }

        public HDDInterface _ConnectionInterface { get { return connectionInterface; } set { connectionInterface = value; } }
        public int SeekTime { get { return seekTime; } set { seekTime = value; } }
        public int BufferCapacity { get { return bufferCapacity; } set { bufferCapacity = value; } }
    }
}
