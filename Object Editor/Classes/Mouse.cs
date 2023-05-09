namespace Object_Editor.Classes
{
    [Name("Mouse")]
    [Class]
    public class Mouse : PeripheralDevice
    {
        private int sensitivity;
        private bool isNoiseless;

        public Mouse() { }
        public Mouse(Mouse mouse): base(mouse)
        {
            sensitivity = mouse.Sensitivity;
            isNoiseless = mouse.IsNoiseless;
        }
        public Mouse(int _cost, int _guarantee, Vendor _vendor,
            ConnectionInterface _connectionInterface, bool _isWireless, int _sensitivity, bool _isNoiseless)
            : base(_cost, _guarantee, _vendor, _connectionInterface, _isWireless)
        {
            sensitivity = _sensitivity;
            isNoiseless = _isNoiseless;
        }
        [Name("Sensitivity")]
        public int Sensitivity { get { return sensitivity; } set { sensitivity = value; } }
        [Name("Noiseless")]
        public bool IsNoiseless { get { return isNoiseless; } set { isNoiseless = value; } }
    }
}
