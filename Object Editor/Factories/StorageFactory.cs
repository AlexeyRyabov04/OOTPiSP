using Object_Editor.Classes;
using System.ComponentModel;

namespace Object_Editor.Factories
{
    internal abstract class StorageFactory : ComputerPartFactory
    {
        private const int MaxStorageCapacity = 256;
        private const int MinStorageCapacity = 32;
        private const int MaxRWSpeed = 600;
        private const int MinRWSpeed = 100;
        protected override bool checkBaseFields(ComputerPart computerPart, Panel panel, string name)
        {
            bool isCorrect = base.checkBaseFields(computerPart, panel, name);   
            var storage = computerPart as Storage;
            if (storage != null) {
                if (storage.StorageCapacity < MinStorageCapacity || storage.StorageCapacity > MaxStorageCapacity)
                    isCorrect = setError(panel, name + ".StorageCapacityControl", "value must be from " + MinStorageCapacity + " to " + MaxStorageCapacity);
                if (storage._RWSpeed < MinRWSpeed || storage._RWSpeed > MaxRWSpeed)
                    isCorrect = setError(panel, name + "._RWSpeedControl", "value must be from " + MinRWSpeed + " to " + MaxRWSpeed);
            }
            return isCorrect;
        }
    }
}
