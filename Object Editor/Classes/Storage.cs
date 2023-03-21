namespace Object_Editor.Classes
{
    internal abstract class Storage : ComputerPart
    {
        protected int storageCapacity;
        protected int RWSpeed;

        public Storage() { }
        protected Storage(Storage storage): base(storage)
        {
            storageCapacity = storage.StorageCapacity;
            RWSpeed = storage._RWSpeed;
        }

        [Name("Storage capacity")]
        public int StorageCapacity { get { return storageCapacity; } set { storageCapacity = value; } }
        [Name("Read-Write speed")]
        public int _RWSpeed { get { return RWSpeed; } set { RWSpeed = value; } }
    }
}
