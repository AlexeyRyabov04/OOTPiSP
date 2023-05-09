using Object_Editor.Classes;

namespace Object_Editor.ClassModels
{
    [Serializable]
    public class VideoCardModel : ComputerPartModel
    {
        private int numberOfMemorySlots = 0;
        private int memoryFrequency = 0;
        private int busWidth = 0;
        private int fillrate = 0;

        public VideoCardModel() { }
        public VideoCardModel(VideoCard videoCard) : base(videoCard)
        {
            numberOfMemorySlots = videoCard.NumberOfMemorySlots;
            memoryFrequency = videoCard.MemoryFrequency;
            busWidth = videoCard.BusWidth;
            fillrate = videoCard.Fillrate;
        }
        public int NumberOfMemorySlots { get { return numberOfMemorySlots; } set { numberOfMemorySlots = value; } }
        public int MemoryFrequency { get { return memoryFrequency; } set { memoryFrequency = value; } }
        public int BusWidth { get { return busWidth; } set { busWidth = value; } }
        public int Fillrate { get { return fillrate; } set { fillrate = value; } }
    }
}
