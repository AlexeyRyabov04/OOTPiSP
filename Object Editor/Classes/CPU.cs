namespace Object_Editor.Classes
{
    [Name("CPU")]
    [Class]
    public class CPU : ComputerPart
    {
        private int numberOfCores;
        private int frequency;

        public CPU() { }
        public CPU(ComputerPart part): base(part)
        {
            var cpu = part as CPU;
            if (cpu != null)
            {
                numberOfCores = cpu.NumberOfCores;
                frequency = cpu.Frequency;
            }
        }
        public CPU(int _cost, int _guarantee, Vendor _vendor, int _numberOfCores, int _frequency) 
            : base(_cost, _guarantee, _vendor)
        {
            numberOfCores = _numberOfCores;
            frequency = _frequency;
        }

        [Name("Cores")]
        public int NumberOfCores { get { return numberOfCores; } set { numberOfCores = value;} }
        [Name("Frequency")]
        public int Frequency { get { return frequency; } set { frequency = value; } }
    }
}
