using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Editor.Classes
{
    internal class Vendor
    {
        private string name;
        private int yearOfFoundation;
        private int yearIncome;

        public Vendor(string _name, int _yearOfFoundation, int _yearIncome)
        {
            name = _name;
            yearOfFoundation = _yearOfFoundation;   
            yearIncome = _yearIncome;
        }

        [Name("Name")]
        public string Name { get { return name; } set { name = value; } }
        [Name("Year of foundation")]
        public int YearOfFoundation { get { return yearOfFoundation; } set { yearOfFoundation = value; } }
        [Name("Year income")]
        public int YearIncome { get { return yearIncome; } set { yearIncome = value; } }
    }
}
