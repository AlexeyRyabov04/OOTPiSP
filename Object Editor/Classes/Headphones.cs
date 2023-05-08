namespace Object_Editor.Classes
{
    [Name("Headphones")]
    [Class]
    public class Headphones : PeripheralDevice
    {
        private int sensitivity;
        private int impedance;

        public Headphones() { }
        public Headphones(Headphones headphones): base(headphones)
        {
            sensitivity = headphones.Sensitivity;
            impedance = headphones.Impedance;
        }
        public Headphones(int _cost, int _guarantee, Vendor _vendor,
            ConnectionInterface _connectionInterface, bool _isWireless, int _sensitivity, int _impedance)
            : base(_cost, _guarantee, _vendor, _connectionInterface, _isWireless)
        {
            sensitivity = _sensitivity;
            impedance = _impedance;
        }

        [Name("Sensitivity")]
        public int Sensitivity { get { return sensitivity; } set { sensitivity = value; } }
        [Name("Impedance")]
        public int Impedance { get { return impedance; } set{ impedance = value; } }
    }
}
