using Object_Editor.Classes;
using Object_Editor.Factories.SerializersFactories;
using Object_Editor.Serializers;
using System.IO;
using System.IO.Compression;
using System.Reflection;

namespace Object_Editor
{
    public partial class MainForm : Form
    {
        public static Type[]? typesList;
        internal static List<ComputerPart> computerParts = new List<ComputerPart>();
        private Dictionary<string, ModelFactory> modelFactories = new Dictionary<string, ModelFactory>();
        private Dictionary<string, IArchiver> plugins = new Dictionary<string, IArchiver>();
        private string filter = string.Empty;
        public MainForm()
        {
            InitializeComponent();
            typesList = Assembly.GetExecutingAssembly().GetTypes().
                Where(type => type.IsDefined(typeof(ClassAttribute))).ToArray();
        }

        private void displayComputerParts()
        {
            while (dataGridView.Rows.Count > 0)
                dataGridView.Rows.RemoveAt(0);
            int i = 1;
            foreach (ComputerPart part in computerParts)
            {
                var type = part.GetType().GetCustomAttribute(typeof(NameAttribute));
                NameAttribute? a = null;
                if (type != null)
                    a = (NameAttribute)type;
                if (a != null && part.Vendor != null)
                    dataGridView.Rows.Add(i++, a.Name, part.Cost, part.Guarantee, part.Vendor.Name);
            }
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            AddForm.currMode = AddForm.mode.Add;
            addForm.ShowDialog();
            displayComputerParts();
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            AddForm.currMode = AddForm.mode.View;
            AddForm.partIndex = dataGridView.CurrentRow.Index;
            addForm.ShowDialog();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            AddForm.currMode = AddForm.mode.Edit;
            AddForm.partIndex = dataGridView.CurrentRow.Index;
            addForm.ShowDialog();
            displayComputerParts();
        }

        private void dataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            viewButton.Enabled = true;
            editButton.Enabled = true;
            deleteButton.Enabled = true;
        }

        public static void deleteComputerPart(int index)
        {
            ComputerPart part = computerParts[index];
            part.Vendor = null ?? part.Vendor;
            part = null ?? part;
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            deleteComputerPart(dataGridView.CurrentRow.Index);
            computerParts.RemoveAt(dataGridView.CurrentRow.Index);
            dataGridView.Rows.RemoveAt(dataGridView.CurrentRow.Index);
            displayComputerParts();
            if (dataGridView.Rows.Count == 0)
            {
                viewButton.Enabled = false;
                editButton.Enabled = false;
                deleteButton.Enabled = false;
            }
        }

        private void fillModelFactoriesList()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var factories = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(ModelFactory)));
            foreach (var factory in factories)
            {
                ModelFactory? obj = (ModelFactory?)Activator.CreateInstance(factory);
                if (obj != null)
                    modelFactories.Add(obj.getExtension().Trim('*'), obj);
            }
        }

        private void GetFilter()
        {
            foreach (var factory in modelFactories)
            {
                filter += factory.Value.getName() + "|" + factory.Value.getExtension() + "; ";
                foreach (var plugin in plugins)
                    filter += factory.Value.getExtension() + plugin.Key + "; ";
                filter = filter.Remove(filter.Length - 2, 2);
                filter += "|";
            }
            filter = filter.Remove(filter.Length - 1);
        }

        private void getPlugins()
        {
            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\.."));
            var directories = Directory.GetDirectories(path).ToList();
            directories.Remove(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..")));
            foreach (var dir in directories)
            {
                var dllFiles = Directory.GetFiles(dir, "bin/*.dll", SearchOption.AllDirectories);
                foreach (var dllFile in dllFiles)
                {
                    var assembly = Assembly.LoadFrom(dllFile);
                    var types = assembly.GetExportedTypes().Where
                        (t => t.GetInterfaces().Contains(typeof(IArchiver)) && !t.IsAbstract);
                    foreach(Type type in types)
                    {
                        IArchiver? archiver = (IArchiver?)Activator.CreateInstance(type);
                        if (archiver != null)
                            plugins.Add(archiver.getExtension(), archiver);
                    }
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            getPlugins();
            fillModelFactoriesList();
            GetFilter();
            CPU cpu = new CPU();
            cpu.NumberOfCores = 1;
            cpu.Frequency = 1;
            cpu.Cost = 1;
            cpu.Guarantee = 1;
            Vendor ven1 = new Vendor();
            ven1.Name = "vendor1";
            ven1.YearOfFoundation = 1905;
            ven1.YearIncome = 1;
            cpu.Vendor = ven1;
            VideoCard videoCard = new VideoCard();
            videoCard.BusWidth = 17;
            videoCard.MemoryFrequency = 1;
            videoCard.Fillrate = 1;
            videoCard.NumberOfMemorySlots = 1;
            videoCard.Cost = 1;
            videoCard.Guarantee = 1;
            Vendor ven2 = new Vendor();
            ven2.Name = "\\\"";
            ven2.YearOfFoundation = 1998;
            ven2.YearIncome = 187;
            videoCard.Vendor = ven2;
            HDD hdd = new HDD();
            hdd.Cost = 1;
            hdd.Guarantee = 4;
            Vendor ven3 = new Vendor();
            ven3.Name = "ven dor3\\\"asd=][";
            ven3.YearOfFoundation = 1965;
            ven3.YearIncome = 15;
            hdd.Vendor = ven3;
            hdd.StorageCapacity = 32;
            hdd._RWSpeed = 120;
            hdd.SeekTime = 200;
            hdd.BufferCapacity = 20;
            hdd._ConnectionInterface = HDD.HDDInterface.SAS;
            computerParts.Add(hdd);
            computerParts.Add(cpu);
            computerParts.Add(videoCard);
            var a = new CPU(1, 1, new Vendor("\\\"\"sad\"", 1905, 1), 1, 1);
            var b = new VideoCard(1, 1, new Vendor("vendor2", 1998, 187), 1, 1, 17, 1);
            computerParts.Add(a);
            computerParts.Add(b);
            saveFileDialog.Filter = filter;
            openFileDialog.Filter = filter;
            displayComputerParts();
        }

        private string getSelectedFilter(FileDialog fileDialog)
        {
            string fileName = fileDialog.FileName;
            if (plugins.ContainsKey(Path.GetExtension(fileName)))
                fileName = Path.GetFileNameWithoutExtension(fileName);
            return Path.GetExtension(fileName);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ISerializer? serializer = modelFactories[getSelectedFilter(openFileDialog)].CreateSerializer();
                if (serializer != null)
                {
                    using MemoryStream ms = new();
                    using FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open);
                    string pluginExt = Path.GetExtension(openFileDialog.FileName);
                    if (plugins.ContainsKey(pluginExt))
                        plugins[pluginExt].Decompress(fs, ms);
                    else
                    {
                        fs.CopyTo(ms);
                        ms.Position = 0;
                    }
                    try
                    {
                        computerParts = serializer.Deserialize(ms);
                        displayComputerParts();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("File read error");
                    }
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ISerializer? serializer = modelFactories[getSelectedFilter(saveFileDialog)].CreateSerializer();
                if (serializer != null)
                {
                    using FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create);
                    using MemoryStream ms = new MemoryStream();
                    string pluginExt = Path.GetExtension(saveFileDialog.FileName);
                    serializer.Serialize(computerParts, fs);
                    if (plugins.ContainsKey(pluginExt))
                    {
                        fs.Position = 0;
                        fs.CopyTo(ms);
                        plugins[pluginExt].Compress(fs, ms);
                    }
                }
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (computerParts.Count == 0)
                saveAsToolStripMenuItem.Enabled = false;
            else saveAsToolStripMenuItem.Enabled = true;
        }

    }
}