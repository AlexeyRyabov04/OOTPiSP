namespace Object_Editor.Classes
{
    public abstract class ComputerPart
    {
        protected int cost;
        protected int guarantee;
        protected Vendor? vendor;

        protected ComputerPart() { }
        protected ComputerPart(ComputerPart part)
        {
            cost = part.Cost;
            guarantee = part.Guarantee;
            if (part.Vendor != null)
                vendor = new Vendor(part.Vendor);
        }
        
        protected ComputerPart(int _cost, int _guarantee, Vendor _vendor)
        {
            cost = _cost;
            guarantee = _guarantee;
            vendor = _vendor;
        }

        [Name("Cost")]
        public int Cost { get { return cost; } set { cost = value; } }
        [Name("Guarantee")]
        public int Guarantee { get { return guarantee; } set { guarantee = value; } }
        [Name("Vendor")]
        public Vendor? Vendor { get { return vendor; } set { vendor = value; } }
    }
}
