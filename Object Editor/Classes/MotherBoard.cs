using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Editor.Classes
{
    [Name("Mother board")]
    internal class MotherBoard : ComputerPart
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

       public MotherBoard(int _cost, int _guarantee, Vendor _vendor, int _numberOfMemorySlots, Socket _socket, Format _format)
            : base(_cost, _guarantee, _vendor)
        {
            numberOfMemorySlots = _numberOfMemorySlots;
            socket = _socket;
            format = _format;
        }
        [Name("Memory Slots")]
        public int NumberOfMemorySlots { get { return numberOfMemorySlots; } set { numberOfMemorySlots = value; } }
        [Name("Socket")]
        public Socket _Socket { get { return socket; } set { socket = value; } }
        [Name("Format")]
        public Format _Format { get { return format; } set { format = value; } }

    }
}
