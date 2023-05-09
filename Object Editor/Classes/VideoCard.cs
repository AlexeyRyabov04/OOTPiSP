namespace Object_Editor.Classes
{
    [Name("Videocard")]
    [Class]
    internal class VideoCard : ComputerPart
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
