using Object_Editor.Classes;
using System.Reflection;

namespace Object_Editor.Factories
{
    internal class VideoCardFactory : ComputerPartFactory
    {
        private const int MaxNumOfMemorySlots = 16;
        private const int MaxFrequency = 8;
        private const int MaxBusWidth = 256;
        private const int MinBusWidth = 16;
        private const int MaxFillrate = 80;
        public override ComputerPart createPart()
        {
            return new VideoCard();
        }

        public override bool checkFields(ComputerPart computerPart, Panel panel, string name)
        {
            bool isCorrect = base.checkBaseFields(computerPart, panel, name);
            var videoCard = computerPart as VideoCard;
            if (videoCard != null)
            {
                if (videoCard.NumberOfMemorySlots <= 0 || videoCard.NumberOfMemorySlots > MaxNumOfMemorySlots)
                    isCorrect = setError(panel, name + ".NumberOfMemorySlotsControl",
                        "value must be from " + 1 + " to " + MaxNumOfMemorySlots);
                if (videoCard.MemoryFrequency <= 0 || videoCard.MemoryFrequency > MaxFrequency)
                    isCorrect = setError(panel, name + ".MemoryFrequencyControl",
                        "value must be from " + 1 + " to " + MaxFrequency);
                if (videoCard.BusWidth < MinBusWidth || videoCard.BusWidth > MaxBusWidth)
                    isCorrect = setError(panel, name + ".BusWidthControl",
                        "value must be from " + MinBusWidth + " to " + MaxBusWidth);
                if (videoCard.Fillrate <= 0 || videoCard.Fillrate > MaxFillrate)
                    isCorrect = setError(panel, name + ".FillrateControl",
                        "value must be from " + 1 + " to " + MaxFillrate);
            }
            return isCorrect;
        }
    }
}
