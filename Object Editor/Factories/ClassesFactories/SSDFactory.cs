using Object_Editor.Classes;
using System.Reflection;

namespace Object_Editor.Factories.ClassesFactories
{
    internal class SSDFactory : StorageFactory
    {
        public override ComputerPart createPart()
        {
            return new SSD();
        }
        public override bool checkFields(ComputerPart computerPart, Panel panel, string name)
        {
            bool isCorrect = base.checkBaseFields(computerPart, panel, name);
            return isCorrect;
        }
    }
}
