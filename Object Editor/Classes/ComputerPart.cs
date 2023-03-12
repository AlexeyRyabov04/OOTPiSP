using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Editor.Classes
{
    internal abstract class ComputerPart
    {
        protected int cost;
        protected int guarantee;
        protected Vendor vendor;

        public ComputerPart(int _cost, int _guarantee, Vendor _vendor)
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
        public Vendor Vendor { get { return vendor; } set { vendor = value; } }
    }
}
