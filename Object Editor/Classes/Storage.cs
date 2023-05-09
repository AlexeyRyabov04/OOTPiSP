namespace Object_Editor.Classes
{
    public abstract class Storage : ComputerPart
    {
        protected int storageCapacity;
        protected int RWSpeed;

        public Storage() { }
        protected Storage(Storage storage): base(storage)
        {
            storageCapacity = storage.StorageCapacity;
            RWSpeed = storage._RWSpeed;
        }
        public Storage(int _cost, int _guarantee, Vendor _vendor, int _storageCapacity, int _RWSpeed)
            : base(_cost, _guarantee, _vendor)
        {
            storageCapacity = _storageCapacity;
            RWSpeed = _RWSpeed;
        }

        [Name("Storage capacity")]
        public int StorageCapacity { get { return storageCapacity; } set { storageCapacity = value; } }
        [Name("Read-Write speed")]
        public int _RWSpeed { get { return RWSpeed; } set { RWSpeed = value; } }
    }
}
