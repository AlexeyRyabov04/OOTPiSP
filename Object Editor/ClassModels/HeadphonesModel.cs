using Object_Editor.Classes;

namespace Object_Editor.ClassModels
{
    [Serializable]
    public class HeadphonesModel : PeripheralDeviceModel
    {
        private int sensitivity;
        private int impedance;

        public HeadphonesModel() { }
        public HeadphonesModel(Headphones headphones) : base(headphones)
        {
            sensitivity = headphones.Sensitivity;
            impedance = headphones.Impedance;
        }
        public int Sensitivity { get { return sensitivity; } set { sensitivity = value; } }
        public int Impedance { get { return impedance; } set { impedance = value; } }
    }
}
