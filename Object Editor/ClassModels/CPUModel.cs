using Object_Editor.Classes;

namespace Object_Editor.ClassModels
{
    [Serializable]
    public class CPUModel : ComputerPartModel
    {
        private int numberOfCores;
        private int frequency;

        public CPUModel() { }
        public CPUModel(ComputerPart part) : base(part)
        {
            var cpu = part as CPU;
            if (cpu != null)
            {
                numberOfCores = cpu.NumberOfCores;
                frequency = cpu.Frequency;
            }
        }
        public int NumberOfCores { get { return numberOfCores; } set { numberOfCores = value; } }
        public int Frequency { get { return frequency; } set { frequency = value; } }
    }
}
