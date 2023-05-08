using Object_Editor.Classes;

namespace Object_Editor.ClassModels
{
    [Serializable]
    public class MouseModel : PeripheralDeviceModel
    {
        private int sensitivity;
        private bool isNoiseless;

        public MouseModel() { }
        public MouseModel(Mouse mouse) : base(mouse)
        {
            sensitivity = mouse.Sensitivity;
            isNoiseless = mouse.IsNoiseless;
        }
        public int Sensitivity { get { return sensitivity; } set { sensitivity = value; } }
        public bool IsNoiseless { get { return isNoiseless; } set { isNoiseless = value; } }
    }
}
