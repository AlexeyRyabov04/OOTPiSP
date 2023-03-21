using Object_Editor.Classes;
using System.Reflection;

namespace Object_Editor.Factories
{
    internal class HDDFactory : StorageFactory
    {
        private const int MaxSeekTime = 800;
        private const int MinSeekTime = 200;
        private const int MaxBufferCapacity = 4;
        public override ComputerPart createPart()
        {
            return new HDD();
        }
        public override bool checkFields(ComputerPart computerPart, Panel panel, string name)
        {
            bool isCorrect = base.checkBaseFields(computerPart, panel, name);
            var hdd = computerPart as HDD;
            if (hdd != null)
            {
                if (hdd.SeekTime < MinSeekTime || hdd.SeekTime > MaxSeekTime)
                    isCorrect = setError(panel, name + ".SeekTimeControl",
                        "value must be from " + MinSeekTime + " to " + MaxSeekTime);
                if (hdd.BufferCapacity <= 0 || hdd.BufferCapacity > MaxBufferCapacity)
                    isCorrect = setError(panel, name + ".BufferCapacityControl",
                        "value must be from " + 1 + " to " + MaxBufferCapacity);
            }
            return isCorrect;
        }
    }
}
