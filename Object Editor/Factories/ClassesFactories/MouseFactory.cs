using Object_Editor.Classes;
using System.Reflection;

namespace Object_Editor.Factories.ClassesFactories
{
    internal class MouseFactory : ComputerPartFactory
    {
        private const int MaxSensitivity = 1000;
        public override ComputerPart createPart()
        {
            return new Mouse();
        }
        public override bool checkFields(ComputerPart computerPart, Panel panel, string name)
        {
            bool isCorrect = base.checkBaseFields(computerPart, panel, name);
            var mouse = computerPart as Mouse;
            if (mouse != null)
            {
                if (mouse.Sensitivity <= 0 || mouse.Sensitivity > MaxSensitivity)
                    isCorrect = setError(panel, name + ".SensitivityControl",
                        "value must be from " + 1 + " to " + MaxSensitivity);
            }
            return isCorrect;
        }
    }
}
