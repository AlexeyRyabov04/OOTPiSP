using Object_Editor.Classes;
using System.Reflection;

namespace Object_Editor.Factories
{
    internal class KeyboardFactory : ComputerPartFactory
    {
        public override ComputerPart createPart()
        {
            return new Keyboard();
        }
        public override bool checkFields(ComputerPart computerPart, Panel panel, string name)
        {
            bool isCorrect = checkBaseFields(computerPart, panel, name);
            return isCorrect;
        }
    }
}
