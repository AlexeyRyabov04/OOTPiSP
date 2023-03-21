using Object_Editor.Classes;
using System.Reflection;

namespace Object_Editor.Factories
{
    internal class HeadphonesFactory : ComputerPartFactory
    {
        private const int MaxSensitivity = 125;
        private const int MinSensitivity = 80;
        private const int MaxImpedance = 600;
        private const int MinImpedance = 8;
        public override ComputerPart createPart()
        {
            return new Headphones();
        }
        public override bool checkFields(ComputerPart computerPart, Panel panel, string name)
        {
            bool isCorrect = base.checkBaseFields(computerPart, panel, name);
            var headphones = computerPart as Headphones;
            if (headphones != null)
            {
                if (headphones.Sensitivity < MinSensitivity || headphones.Sensitivity > MaxSensitivity)
                    isCorrect = setError(panel, name + ".SensitivityControl",
                        "value must be from " + MinImpedance + " to " + MaxImpedance);
                if (headphones.Impedance < MinImpedance || headphones.Impedance > MaxImpedance)
                    isCorrect = setError(panel, name + ".ImpedanceControl",
                        "value must be from " + MinImpedance + " to " + MaxImpedance);
            }
            return isCorrect;
        }
    }
}
