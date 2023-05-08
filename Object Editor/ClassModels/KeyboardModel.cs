using Object_Editor.Classes;
namespace Object_Editor.ClassModels
{
    [Serializable]
    public class KeyboardModel : PeripheralDeviceModel
    {
        private bool hasCyrillicSupport;
        private bool hasNumpad;

        public KeyboardModel() { }
        public KeyboardModel(Keyboard keyboard) : base(keyboard)
        {
            hasCyrillicSupport = keyboard.HasCyrillicSupport;
            hasNumpad = keyboard.HasNumpad;
        }

        public bool HasCyrillicSupport { get { return hasCyrillicSupport; } set { hasCyrillicSupport = value; } }
        public bool HasNumpad { get { return hasNumpad; } set { hasNumpad = value; } }
    }
}
