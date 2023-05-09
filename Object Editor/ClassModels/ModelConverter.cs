using Object_Editor.Classes;
namespace Object_Editor.ClassModels
{
    public static class ModelConverter
    {
        public static List<ComputerPart> ModelsToClasses(List<ComputerPartModel> models)
        {
            List<ComputerPart> computerParts = new();
            foreach (var model in models)
            {
                switch (model)
                {
                    case CPUModel:
                        CPU cpu = new CPU();
                        CopyFields(cpu, (CPUModel)model);
                        computerParts.Add(cpu);
                        break;
                    case HDDModel:
                        HDD hdd = new HDD();
                        CopyFields(hdd, (HDDModel)model);
                        computerParts.Add(hdd);
                        break;
                    case HeadphonesModel:
                        Headphones headphones = new Headphones();
                        CopyFields(headphones, (HeadphonesModel)model);
                        computerParts.Add(headphones);
                        break;
                    case KeyboardModel:
                        Keyboard keyboard = new Keyboard();
                        CopyFields(keyboard, (KeyboardModel)model);
                        computerParts.Add(keyboard);
                        break;
                    case MotherBoardModel:
                        MotherBoard motherBoard = new MotherBoard();
                        CopyFields(motherBoard, (MotherBoardModel)model);
                        computerParts.Add(motherBoard);
                        break;
                    case MouseModel:
                        Mouse mouse = new Mouse();
                        CopyFields(mouse, (MouseModel)model);
                        computerParts.Add(mouse);
                        break;
                    case SSDModel:
                        SSD ssd = new SSD();
                        CopyFields(ssd, (SSDModel)model);
                        computerParts.Add(ssd);
                        break;
                    case VideoCardModel:
                        VideoCard videoCard = new VideoCard();
                        CopyFields(videoCard, (VideoCardModel)model);
                        computerParts.Add(videoCard);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(model));
                }
            }
            return computerParts;
        }

        public static List<ComputerPartModel> ModelsFromClasses(List<ComputerPart> parts) 
        {
            List<ComputerPartModel> models = new();
            foreach (var part in parts)
            {
                switch (part)
                {
                    case CPU:
                        models.Add(new CPUModel((CPU)part));
                        break;
                    case HDD:
                        models.Add(new HDDModel((HDD)part));
                        break;
                    case Headphones:
                        models.Add(new HeadphonesModel((Headphones)part));
                        break;
                    case Keyboard:
                        models.Add(new KeyboardModel((Keyboard)part));
                        break;
                    case MotherBoard:
                        models.Add(new MotherBoardModel((MotherBoard)part));
                        break;
                    case Mouse:
                        models.Add(new MouseModel((Mouse)part));
                        break;
                    case SSD:
                        models.Add(new SSDModel((SSD)part));
                        break;
                    case VideoCard:
                        models.Add(new VideoCardModel((VideoCard)part));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(part));
                }
            }
            return models;
        }
        private static void CopyFields(object part, object model)
        {
            Vendor vendor;
            var props = part.GetType().GetProperties();
            foreach (var prop in model.GetType().GetProperties())
            {
                var targetProp = props.FirstOrDefault(i => i.Name == prop.Name);
                if (targetProp != null && targetProp.CanWrite)
                {
                    if (prop.Name == "Vendor")
                    {
                        vendor = new Vendor();
                        var ven = prop.GetValue(model);
                        if (ven != null)
                            CopyFields(vendor, ven);
                        targetProp.SetValue(part, vendor);
                        continue;
                    }
                    targetProp.SetValue(part, prop.GetValue(model));
                }
            }
        }
    }
}
