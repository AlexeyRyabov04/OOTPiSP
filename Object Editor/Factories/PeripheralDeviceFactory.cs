using Object_Editor.Classes;
namespace Object_Editor.Factories
{
    internal abstract class PeripheralDeviceFactory : ComputerPartFactory
    {
        protected override bool checkBaseFields(ComputerPart computerPart, Panel panel, string name)
        {
            bool isCorrect = base.checkBaseFields(computerPart, panel, name);
            return isCorrect;
        }
    }
}
