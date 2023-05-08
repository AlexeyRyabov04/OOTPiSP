namespace Object_Editor.Classes
{
    [Name("Videocard")]
    [Class]
    public class VideoCard : ComputerPart
    {
        private int numberOfMemorySlots;
        private int memoryFrequency;
        private int busWidth;
        private int fillrate;

        public VideoCard() { }
        public VideoCard(VideoCard videoCard): base(videoCard)
        {
            numberOfMemorySlots = videoCard.NumberOfMemorySlots;
            memoryFrequency = videoCard.MemoryFrequency;
            busWidth = videoCard.BusWidth;
            fillrate = videoCard.Fillrate;
        }
        public VideoCard(int _cost, int _guarantee, Vendor _vendor, int _numberOfMemorySlots, 
            int _memoryFrequency, int _busWidth, int _fillrate)
            : base(_cost, _guarantee, _vendor)
        {
            numberOfMemorySlots = _numberOfMemorySlots;
            memoryFrequency = _memoryFrequency;
            busWidth = _busWidth;
            fillrate = _fillrate;
        }
        [Name("Memory slots")]
        public int NumberOfMemorySlots { get { return numberOfMemorySlots; } set { numberOfMemorySlots = value; } }
        [Name("Memory frequency")]
        public int MemoryFrequency { get { return memoryFrequency; }set { memoryFrequency = value; } }
        [Name("Bus width")]
        public int BusWidth { get { return busWidth; } set { busWidth = value;} }
        [Name("Fillrate")]
        public int Fillrate { get { return fillrate; } set { fillrate = value; } }
    }
}
