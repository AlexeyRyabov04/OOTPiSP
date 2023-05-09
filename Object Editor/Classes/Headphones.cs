namespace Object_Editor.Classes
{
    [Name("Headphones")]
    [Class]
    internal class Headphones : PeripheralDevice
    {
        private int sensitivity;
        private int impedance;

        public Headphones() { }
        public Headphones(Headphones headphones): base(headphones)
        {
            sensitivity = headphones.Sensitivity;
            impedance = headphones.Impedance;
        }
        [Name("Sensitivity")]
        public int Sensitivity { get { return sensitivity; } set { sensitivity = value; } }
        [Name("Impedance")]
        public int Impedance { get { return impedance; } set{ impedance = value; } }
    }
}
