using Object_Editor.Classes;
using System.Reflection;

namespace Object_Editor.Factories
{
    internal class CPUFactory : ComputerPartFactory
    {
        private const int MaxNumOfCores = 256;
        private const int MaxFrequency = 8;
        public override ComputerPart createPart() 
        {
            return new CPU();
        }
        public override bool checkFields(ComputerPart computerPart, Panel panel, string name)
        {
            bool isCorrect = base.checkBaseFields(computerPart, panel, name);
            var cpu = computerPart as CPU;
            if (cpu != null)
            {
                if (cpu.NumberOfCores <= 0 || cpu.NumberOfCores > MaxNumOfCores)
                    isCorrect = setError(panel, name + ".NumberOfCoresControl", 
                        "value must be from " + 1 + " to " + MaxNumOfCores);
                if (cpu.Frequency <= 0 || cpu.Frequency > MaxFrequency)
                    isCorrect = setError(panel, name + ".FrequencyControl", 
                        "value must be from " + 1 + " to " + MaxFrequency);
            }
            return isCorrect;
        }
    }
}
