namespace Object_Editor.Classes
{
    [Name("Mother board")]
    [Class]
    public class MotherBoard : ComputerPart
    {
        private int numberOfMemorySlots;
        public enum Socket { 
            SocketB2, 
            PAC611, 
            LGA1200, 
            Socket478 
        };
        private Socket socket;
        public enum Format { 
            AT, 
            ATX, 
            LPX, 
            NLX 
        };
        private Format format;

        public MotherBoard() { }
        public MotherBoard(MotherBoard motherBoard): base(motherBoard)
        {
            numberOfMemorySlots = motherBoard.NumberOfMemorySlots;
            socket = motherBoard._Socket;
            format = motherBoard._Format;
        }
        public MotherBoard(int _cost, int _guarantee, Vendor _vendor, Socket _socket, Format _format)
            : base(_cost, _guarantee, _vendor)
        {
            socket = _socket;
            format = _format;
        }

        [Name("Memory Slots")]
        public int NumberOfMemorySlots { get { return numberOfMemorySlots; } set { numberOfMemorySlots = value;} }
        [Name("Socket")]
        public Socket _Socket { get { return socket; } set { socket = value; }}
        [Name("Format")]
        public Format _Format { get { return format; } set { format = value; } }
    }
}
