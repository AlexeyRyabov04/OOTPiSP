using Object_Editor.Classes;

namespace Object_Editor.Factories
{
    internal abstract class ComputerPartFactory
    {
        private const int MaxCost = 10000;
        private const int MaxGuarantee = 36;
        private const int MaxYearOfFoundation = 2023;
        private const int MinYearOfFoundation = 1900;
        private const int MaxYearIncome = 10000;
        public abstract ComputerPart createPart();
        protected bool setError(Panel panel, string name, string message)
        {
            ErrorProvider error = new ErrorProvider();
            var control = panel.Controls.Find(name, false).FirstOrDefault();
            error.SetError(control, message);
            error.BlinkRate = 0;
            if (control != null)
                control.Tag = error;
            return false;
        }
        protected virtual bool checkBaseFields(ComputerPart computerPart, Panel panel, string name)
        {
            bool isCorrect = true;
            if (computerPart != null)
            {
                if (computerPart.Cost <= 0 || computerPart.Cost > MaxCost)
                    isCorrect = setError(panel, name + ".CostControl", 
                        "value must be from " + 1 + " to " + MaxCost);
                if (computerPart.Guarantee <= 0 || computerPart.Guarantee > MaxGuarantee)
                    isCorrect = setError(panel, name + ".GuaranteeControl", 
                        "value must be from " + 1 + " to " + MaxGuarantee);
                name = name.Substring(0, name.LastIndexOf('.')) + ".Vendor";
                if (computerPart.Vendor != null) {
                    if (computerPart.Vendor.Name == null || computerPart.Vendor.Name.Equals(""))
                        isCorrect = setError(panel, name + ".NameControl", "field is empty");
                    if (computerPart.Vendor.YearOfFoundation < MinYearOfFoundation
                        || computerPart.Vendor.YearOfFoundation > MaxYearOfFoundation)
                        isCorrect = setError(panel, name + ".YearOfFoundationControl",
                            "value must be from " + MinYearOfFoundation + " to " + MaxYearOfFoundation);
                    if (computerPart.Vendor.YearIncome <= 0 || computerPart.Vendor.YearIncome > MaxYearIncome)
                        isCorrect = setError(panel, name + ".YearIncomeControl",
                            "value must be from " + 1 + " to " + MaxYearIncome);
                }                            
            }
            return isCorrect;
        }
        public abstract bool checkFields(ComputerPart computerPart, Panel panel, string name);
    }
}
