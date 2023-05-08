using Object_Editor.Classes;
using Object_Editor.Serializers;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace UnitTests
{
    [TestClass]
    public class Tests
    {
        private const string filepath = "file.txt";
        private CustomSerializer CreateSerializer()
        {
            return new CustomSerializer();
        }

        private bool CompareObjects(object obj1, object obj2)
        {
            Type type = obj1.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object? value1 = property?.GetValue(obj1);
                object? value2 = property?.GetValue(obj2);
                if (value1 != null && value2 != null && property != null)
                {
                    if (property.Name == "Vendor")
                    {
                        if (!CompareObjects(value1, value2))
                            return false;
                        continue;
                    }
                    if (!value1.Equals(value2))
                        return false;
                }
                else
                    return false;
            }
            return true;
        }

        [TestMethod]
        public void TestSerializer()
        {
            List<ComputerPart> list = new List<ComputerPart>() {
                new CPU(1, 1, new Vendor("\\\"\"sad\"", 1905, 1), 1, 1),
                new VideoCard(1, 1, new Vendor("vendor2", 1998, 187), 1, 1, 17, 1)};
            const string expected = "[CPU:NumberOfCores=1,Frequency=1,Cost=1,Guarantee=1," +
                "Vendor=[Vendor:Name=\"\\\"\"\"\"sad\"\"\",YearOfFoundation=1905,YearIncome=1]]" +
                "[VideoCard:NumberOfMemorySlots=1,MemoryFrequency=1,BusWidth=17,Fillrate=1," +
                "Cost=1,Guarantee=1,Vendor=[Vendor:Name=\"vendor2\",YearOfFoundation=1998,YearIncome=187]]";
            using StreamWriter sw = new StreamWriter(filepath);
            CustomSerializer serializer = CreateSerializer();
            serializer.Serialize(list, sw.BaseStream);
            sw.Close();
            string result = File.ReadAllText(filepath);
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void TestDeserializer()
        {
            List<ComputerPart> list = new List<ComputerPart>() {
                new CPU(1, 1, new Vendor("vendor1", 1905, 1), 1, 1),
                new VideoCard(1, 1, new Vendor("vendor2", 1998, 187), 1, 1, 17, 1),
                new HDD(1, 1, new Vendor("vendor3", 1965, 15), 32, 120, HDD.HDDInterface.SAS, 200, 20)};
            using StreamWriter sw = new StreamWriter(filepath);
            CustomSerializer serializer = CreateSerializer();
            serializer.Serialize(list, sw.BaseStream);
            sw.Close();
            using StreamReader sr = new StreamReader(filepath);
            var res = serializer.Deserialize(sr.BaseStream);
            sr.Close();
            bool isCorrect = (res.Count == list.Count);
            if (isCorrect)
                for (int i = 0; i < list.Count; i++)
                    if (!CompareObjects(list[i], res[i]))
                    {
                        isCorrect = false;
                        break;
                    }
            Assert.IsTrue(isCorrect);
        }

        [TestMethod]
        public void TestQuotesInStrings()
        {
            List<ComputerPart> list = new List<ComputerPart>() {
                new CPU(1, 1, new Vendor("askjdk\"\"s\"\\\"", 1905, 1), 1, 1),
                new VideoCard(1, 1, new Vendor("\"\"\"\"\"", 1998, 187), 1, 1, 17, 1) };
            using StreamWriter sw = new StreamWriter(filepath);
            CustomSerializer serializer = CreateSerializer();
            serializer.Serialize(list, sw.BaseStream);
            sw.Close();
            using StreamReader sr = new StreamReader(filepath);
            var res = serializer.Deserialize(sr.BaseStream);
            sr.Close();
            bool isCorrect = (res.Count == list.Count);
            if (isCorrect)
                for (int i = 0; i < list.Count; i++)
                    if (!CompareObjects(list[i], res[i]))
                    {
                        isCorrect = false;
                        break;
                    }
            Assert.IsTrue(isCorrect);
        }

        [TestMethod]
        public void TestExtraCharactersInBegin()
        {
            const string str = "sadasd[CPU:NumberOfCores=1,Frequency=1,Cost=1,Guarantee=1," +
                "Vendor=[Vendor:Name=\"vendor1\",YearOfFoundation=1905,YearIncome=1]]" +
                "[VideoCard:NumberOfMemorySlots=1,MemoryFrequency=1,BusWidth=17,Fillrate=1," +
                "Cost=1,Guarantee=1,Vendor=[Vendor:Name=\"vendor2\",YearOfFoundation=1998,YearIncome=187]]";
            CustomSerializer serializer = CreateSerializer();
            File.WriteAllText(filepath, str);
            using StreamReader sr = new StreamReader(filepath);
            Action action = () => serializer.Deserialize(sr.BaseStream);
            Assert.ThrowsException<FileFormatException>(action);
        }

        [TestMethod]
        public void TestExtraCharactersInFile()
        {
            const string str = "sadasd[CPU:NumberOfCores=1,Frequency=1,Cost=1,Guarantee=1," +
                "Vendor=[Vendor:Name=\"vendor1\",sYearOfFoundation=1905,YearIncome=1]]" +
                "[VideoCard:NumberOfMemorySlots=1,MemoryFrequency=1,dBusWidth=17,Fillrate=1," +
                "Cost=1,Guarantee=1,Vendor=[Vendor:Name=\"vendor2\",fYearOfFoundation=1998,YearIncome=187]]";
            CustomSerializer serializer = CreateSerializer();
            File.WriteAllText(filepath, str);
            using StreamReader sr = new StreamReader(filepath);
            Action action = () => serializer.Deserialize(sr.BaseStream);
            Assert.ThrowsException<FileFormatException>(action);
        }
    }
}