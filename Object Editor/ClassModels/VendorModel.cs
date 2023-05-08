using Object_Editor.Classes;

namespace Object_Editor.ClassModels
{
    [Serializable]
    public class VendorModel
    {
        private string name = string.Empty;
        private int yearOfFoundation;
        private int yearIncome;

        public VendorModel() { }
        public VendorModel(Vendor vendor)
        {
            name = vendor.Name ?? string.Empty;
            yearOfFoundation = vendor.YearOfFoundation;
            yearIncome = vendor.YearIncome;
        }
        public string Name { get { return name; } set { name = value; } }
        public int YearOfFoundation { get { return yearOfFoundation; } set { yearOfFoundation = value; } }
        public int YearIncome { get { return yearIncome; } set { yearIncome = value; } }
    }
}
