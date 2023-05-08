using Object_Editor.Classes;
using static Object_Editor.Classes.MotherBoard;

namespace Object_Editor.ClassModels
{
    [Serializable]
    public class MotherBoardModel : ComputerPartModel
    {
        private int numberOfMemorySlots;
        private Socket socket;
        private Format format;

        public MotherBoardModel() { }
        public MotherBoardModel(MotherBoard motherBoard) : base(motherBoard)
        {
            numberOfMemorySlots = motherBoard.NumberOfMemorySlots;
            socket = motherBoard._Socket;
            format = motherBoard._Format;
        }
        public int NumberOfMemorySlots { get { return numberOfMemorySlots; } set { numberOfMemorySlots = value; } }
        public Socket _Socket { get { return socket; } set { socket = value; } }
        public Format _Format { get { return format; } set { format = value; } }
    }
}
