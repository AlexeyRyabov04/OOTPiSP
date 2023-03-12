using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Editor.Classes
{
    [Name("HDD")]
    internal class HDD : Storage
    {
        public enum ConnectionInterface { 
            IDE, 
            mSATA, 
            SAS, 
            USB, 
            SCSI, 
            SATA 
        };
        private ConnectionInterface connectionInterface;
        private int seekTime;
        private int bufferCapacity;
        public HDD(int _cost, int _guarantee, Vendor _vendor, ConnectionInterface _connectionInterface, 
            int _seekTime, int _bufferCapacity,int _storageCapacity, int _RWSpeed) :
            base(_cost, _guarantee, _vendor, _storageCapacity, _RWSpeed)
        {
            connectionInterface = _connectionInterface;
            seekTime = _seekTime;
            bufferCapacity = _bufferCapacity;
        }

        [Name("Connection Interface")]
        public ConnectionInterface _ConnectionInterface { get { return connectionInterface; } set { connectionInterface = value; } }
        [Name("Seek time")]
        public int SeekTime { get { return seekTime; } set { seekTime = value; } }
        [Name("Buffer capacity")]
        public int BufferCapacity { get { return bufferCapacity; } set { bufferCapacity = value; } }
    }
}
