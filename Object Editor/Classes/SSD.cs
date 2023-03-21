namespace Object_Editor.Classes
{
    [Name("SSD")]
    [Class]
    internal class SSD : Storage
    {
        public enum ConnectionInterface { 
            SATA, 
            mSATA, 
            M2, 
            PCIExpress 
        };
        private ConnectionInterface connectionInterface;
        public enum Controller {
            Marvell, 
            Phison, 
            Realtek 
        };
        private Controller controller;
        public SSD() { }
        public SSD(SSD ssd): base(ssd)
        {
            connectionInterface = ssd._ConnectionInterface;
            controller = ssd._Controller;
        }

        [Name("Connection Interface")]
        public ConnectionInterface _ConnectionInterface
        {
            get { return connectionInterface; }
            set
            { 
                connectionInterface = value;
            } 
        }
        [Name("Controller")]
        public Controller _Controller 
        { 
            get { return controller; }
            set
            { 
                controller = value; 
            } 
        }
    }
}
