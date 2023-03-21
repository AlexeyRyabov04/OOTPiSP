namespace Object_Editor.Classes
{
    [Name("Mouse")]
    [Class]
    internal class Mouse : PeripheralDevice
    {
        private int sensitivity;
        private bool isNoiseless;

        public Mouse() { }
        public Mouse(Mouse mouse): base(mouse)
        {
            sensitivity = mouse.Sensitivity;
            isNoiseless = mouse.IsNoiseless;
        }
        [Name("Sensitivity")]
        public int Sensitivity 
        { 
            get { return sensitivity; }
            set 
            {
                    sensitivity = value; 
            } 
        }
        [Name("Noiseless")]
        public bool IsNoiseless { get { return isNoiseless; } set { isNoiseless = value; } }
    }
}
