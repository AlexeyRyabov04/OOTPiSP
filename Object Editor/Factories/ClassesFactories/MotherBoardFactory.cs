using Object_Editor.Classes;
using System.Reflection;

namespace Object_Editor.Factories.ClassesFactories
{
    internal class MotherBoardFactory : ComputerPartFactory
    {
        private const int MaxNumOfMemorySlots = 32;
        private const int MinNumOfMemorySlots = 2;
        public override ComputerPart createPart()
        {
            return new MotherBoard();
        }
        public override bool checkFields(ComputerPart computerPart, Panel panel, string name)
        {
            bool isCorrect = base.checkBaseFields(computerPart, panel, name);
            var motherBoard = computerPart as MotherBoard;
            if (motherBoard != null)
            {
                if (motherBoard.NumberOfMemorySlots < MinNumOfMemorySlots
                    || motherBoard.NumberOfMemorySlots > MaxNumOfMemorySlots)
                    isCorrect = setError(panel, name + ".NumberOfMemorySlotsControl",
                        "value must be from " + MinNumOfMemorySlots + " to " + MaxNumOfMemorySlots);
            }
            return isCorrect;
        }
    }
}
