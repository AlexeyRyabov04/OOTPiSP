using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Editor.Classes
{
    [Name("CPU")]
    internal class CPU : ComputerPart
    {
        private int numberOfCores;
        private int frequency;

        public CPU(int _cost, int _guarantee, Vendor _vendor, int _numberOfCores, int _frequency)
            : base(_cost, _guarantee, _vendor)
        {
            numberOfCores = _numberOfCores;
            frequency = _frequency;
        }

        [Name("Cores")]
        public int NumberOfCores { get { return numberOfCores; } set { numberOfCores = value; } }
        [Name("Frequency")]
        public int Frequency { get { return frequency; } set { frequency = value; } }
    }
}
