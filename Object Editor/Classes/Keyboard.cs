namespace Object_Editor.Classes
{
    [Name("Keyboard")]
    [Class]
    internal class Keyboard : PeripheralDevice
    {
        private bool hasCyrillicSupport;
        private bool hasNumpad;

        public Keyboard() { }
        public Keyboard(Keyboard keyboard): base(keyboard)
        {
            hasCyrillicSupport = keyboard.HasCyrillicSupport;
            hasNumpad = keyboard.HasNumpad;
        }

        [Name("Cyrillic Support")]
        public bool HasCyrillicSupport { get { return hasCyrillicSupport; } set { hasCyrillicSupport = value; } }
        [Name("Numpad")]
        public bool HasNumpad { get { return hasNumpad; } set { hasNumpad = value; } }
    }
}
