namespace Object_Editor.Classes
{
    [Name("Keyboard")]
    [Class]
    public class Keyboard : PeripheralDevice
    {
        private bool hasCyrillicSupport;
        private bool hasNumpad;

        public Keyboard() { }
        public Keyboard(Keyboard keyboard): base(keyboard)
        {
            hasCyrillicSupport = keyboard.HasCyrillicSupport;
            hasNumpad = keyboard.HasNumpad;
        }
        public Keyboard(int _cost, int _guarantee, Vendor _vendor,
            ConnectionInterface _connectionInterface, bool _isWireless, 
            bool _hasCyrillicSupport, bool _hasNumpad)
            : base(_cost, _guarantee, _vendor, _connectionInterface, _isWireless)
        {
            hasCyrillicSupport = _hasCyrillicSupport;
            hasNumpad |= _hasNumpad;
        }
        [Name("Cyrillic Support")]
        public bool HasCyrillicSupport { get { return hasCyrillicSupport; } set { hasCyrillicSupport = value; } }
        [Name("Numpad")]
        public bool HasNumpad { get { return hasNumpad; } set { hasNumpad = value; } }
    }
}
