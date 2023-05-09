using Object_Editor.Classes;
using System.Xml.Serialization;

namespace Object_Editor.ClassModels
{
    [Serializable]
    [XmlInclude(typeof(PeripheralDeviceModel))]
    [XmlInclude(typeof(StorageModel))]
    [XmlInclude(typeof(CPUModel))]
    [XmlInclude(typeof(VideoCardModel))]
    [XmlInclude(typeof(MotherBoardModel))]
    public class ComputerPartModel
    {
        protected int cost;
        protected int guarantee;
        protected VendorModel vendor = new VendorModel();

        protected ComputerPartModel() { }
        protected ComputerPartModel(ComputerPart part)
        {
            cost = part.Cost;
            guarantee = part.Guarantee;
            if (part.Vendor != null)
                vendor = new VendorModel(part.Vendor);
        }

        public int Cost { get { return cost; } set { cost = value; } }
        public int Guarantee { get { return guarantee; } set { guarantee = value; } }
        public VendorModel Vendor { get { return vendor; } set { vendor = value; } }
    }
}
