using Object_Editor.Classes;
using System.Xml.Serialization;

namespace Object_Editor.ClassModels
{
    [Serializable]
    [XmlInclude(typeof(SSDModel))]
    [XmlInclude(typeof(HDDModel))]
    public class StorageModel : ComputerPartModel
    {
        protected int storageCapacity;
        protected int RWSpeed;

        public StorageModel() { }
        protected StorageModel(Storage storage) : base(storage)
        {
            storageCapacity = storage.StorageCapacity;
            RWSpeed = storage._RWSpeed;
        }

        public int StorageCapacity { get { return storageCapacity; } set { storageCapacity = value; } }
        public int _RWSpeed { get { return RWSpeed; } set { RWSpeed = value; } }
    }
}
