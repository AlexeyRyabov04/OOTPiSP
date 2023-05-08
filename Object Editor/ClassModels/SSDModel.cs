using Object_Editor.Classes;
using static Object_Editor.Classes.SSD;

namespace Object_Editor.ClassModels
{
    [Serializable]
    public class SSDModel : StorageModel
    {
        private SSDInterface connectionInterface;
        private Controller controller;
        public SSDModel() { }
        public SSDModel(SSD ssd) : base(ssd)
        {
            connectionInterface = ssd._ConnectionInterface;
            controller = ssd._Controller;
        }

        public SSDInterface _ConnectionInterface { get { return connectionInterface; } set { connectionInterface = value; } }
        public Controller _Controller { get { return controller; } set { controller = value; } }
    }
}
