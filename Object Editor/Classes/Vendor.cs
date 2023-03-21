namespace Object_Editor.Classes
{
    internal class Vendor
    {
        private const int MaxYearOfFoundation = 2023;
        private const int MinYearOfFoundation = 1900;
        private const int MaxYearIncome = 10000;
        private string? name;
        private int yearOfFoundation;
        private int yearIncome;

        public Vendor() { }
        public Vendor(Vendor vendor) 
        {
            name = vendor.Name;
            yearOfFoundation = vendor.YearOfFoundation;
            yearIncome = vendor.YearIncome;
        }
        [Name("Name")]
        public string? Name { get { return name; } set { name = value; } }
        [Name("Year of foundation")]
        public int YearOfFoundation { get { return yearOfFoundation; } set { yearOfFoundation = value; } }
        [Name("Year income")]
        public int YearIncome { get { return yearIncome; } set { yearIncome = value; } }
    }
}
