using System.Data;
using System.Reflection;
using Object_Editor.Classes;
using Object_Editor.Factories.ClassesFactories;
using Object_Editor.Factories.ControlsFactories;

namespace Object_Editor
{
    public partial class AddForm : Form
    {
        ComputerPart? part;
        ComputerPart? copy;
        private const int PADDING = 50;
        private const int MAX_VALUE = 10000;
        private bool isAdd = false;
        public enum mode { Add, Edit, View };
        public static mode currMode;
        public static int partIndex;
        public AddForm()
        {
            InitializeComponent();
            typeComboBox.Enabled = true;
            if (MainForm.typesList != null)
                typeComboBox.Items.AddRange(MainForm.typesList.Select(i => i.Name).ToArray());
        }

        Dictionary<Type, Type> dictionary = new Dictionary<Type, Type>()
        {
            { typeof(CPU), typeof(CPUFactory) },
            { typeof(HDD), typeof(HDDFactory) },
            { typeof(Headphones), typeof(HeadphonesFactory) },
            { typeof(Keyboard), typeof(KeyboardFactory) },
            { typeof(MotherBoard), typeof(MotherBoardFactory) },
            { typeof(Mouse), typeof(MouseFactory) },
            { typeof(SSD), typeof(SSDFactory) },
            { typeof(VideoCard), typeof(VideoCardFactory) },
        };

        private void createLabel(int location, string name)
        {
            ControlFactory factory = new LabelFactory(new Font("Times New Roman", 14.25F, FontStyle.Regular),
                    new Point(0, location), new Size(218, 30), labelPanel, Color.Black, name);
            factory.createControl();
        }

        private void createControl(Object obj, Type type, string propertyName, int location)
        {
            ControlFactory? factory = null;
            if (type == typeof(Int32))
            {
                factory = new NumericUpDownFactory(new Font("Times New Roman", 14.25F, FontStyle.Regular),
                    new Point(0, location), new Size(218, 30), controlsPanel, MAX_VALUE);
            }
            else if (type == typeof(String))
            {
                factory = new TextBoxFactory(new Font("Times New Roman", 14.25F, FontStyle.Regular),
                    new Point(0, location), new Size(218, 30), controlsPanel, 15);
            }
            else if (type == typeof(Boolean))
            {
                factory = new CheckBoxFactory(new Font("Times New Roman", 14.25F, FontStyle.Regular),
                    new Point(0, location), new Size(30, 30), controlsPanel);
            }
            else if (type == typeof(Vendor))
            {
                if (part != null && part.Vendor != null)
                    createFields(part.Vendor, type, location + PADDING);
            }
            else if (type.IsEnum)
            {
                factory = new ComboBoxFactory(new Font("Times New Roman", 14.25F, FontStyle.Regular), new Point(0, location),
                    new Size(218, 30), controlsPanel, Enum.GetNames(type));
            }
            if (factory != null)
            {
                Control control = factory.createControl();
                factory.BindControl(control, obj, propertyName);
            }
        }

        private void createFields(Object obj, Type type, int location)
        {
            var fields = type.GetProperties();
            foreach (PropertyInfo field in fields)
            {
                Attribute? name = field.GetCustomAttribute(typeof(NameAttribute));
                if (name != null)
                    createLabel(location, ((NameAttribute)name).Name);
                createControl(obj, field.PropertyType, field.Name, location);
                location += PADDING;
            }
        }

        private void fillFields(Object? obj, bool enabled, ref int i)
        {
            if (obj != null)
                foreach (var field in obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
                {
                    if (field.FieldType == typeof(Vendor))
                    {
                        fillFields(field.GetValue(obj), enabled, ref i);
                    }
                    else if (field.FieldType == typeof(Int32) || field.FieldType == typeof(String))
                    {
                        controlsPanel.Controls[i].Text = Convert.ToString(field.GetValue(obj));
                        controlsPanel.Controls[i].Enabled = enabled;
                    }
                    else if (field.FieldType == typeof(Boolean))
                    {
                        CheckBox checkBox = (CheckBox)controlsPanel.Controls[i];
                        checkBox.Checked = Convert.ToBoolean(field.GetValue(obj));
                        checkBox.Enabled = enabled;
                    }
                    else if (field.FieldType.IsEnum)
                    {
                        ComboBox comboBox = (ComboBox)controlsPanel.Controls[i];
                        comboBox.SelectedIndex = comboBox.Items.IndexOf(Convert.ToString(field.GetValue(obj)));
                        comboBox.Enabled = enabled;
                    }
                    i--;
                }
        }
        private void fillControls(bool enabled)
        {
            part = MainForm.computerParts[partIndex];
            if (MainForm.typesList != null)
                typeComboBox.SelectedIndex = typeComboBox.Items.IndexOf(
                    MainForm.typesList[Array.IndexOf(MainForm.typesList, part.GetType())].Name);
            int i = controlsPanel.Controls.Count - 1;
            fillFields(part, enabled, ref i);
        }

        private void deleteControls(Panel panel)
        {
            int count = panel.Controls.Count;
            for (int i = 0; i < count; i++)
            {
                Control tmp = panel.Controls[0];
                panel.Controls.Remove(tmp);
                tmp.Dispose();
            }
        }

        private ComputerPart? createPart(Type type)
        {
            Object? obj = Activator.CreateInstance(dictionary[type]);
            ComputerPartFactory factory;
            if (obj != null)
            {
                factory = (ComputerPartFactory)obj;
                ComputerPart part = factory.createPart();
                Vendor vendor = new Vendor();
                part.Vendor = vendor;
                return part;
            }
            return null;
        }
        private void selectedChanged()
        {
            deleteControls(labelPanel);
            deleteControls(controlsPanel);
            int location = 0;
            if (MainForm.typesList != null)
            {
                Type? type = Type.GetType(MainForm.typesList[typeComboBox.SelectedIndex].ToString());
                if (type != null)
                {
                    if (currMode == mode.Add)
                        part = createPart(type);
                    if (part != null)
                        createFields(part, type, location);
                }
            }
        }
        private void typeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            panel2.AutoSize = false;
            selectedChanged();
            panel2.AutoSize = true;
            CenterToScreen();
        }
        private void clearErrors()
        {
            foreach (Control control in controlsPanel.Controls)
            {
                ErrorProvider? error = null;
                if (control.Tag != null)
                    error = control.Tag as ErrorProvider;
                if (error != null)
                    error.Clear();
            }
        }
        private bool checkFields()
        {
            bool isCorrect = true;
            clearErrors();
            if (part != null)
            {
                Object? obj = Activator.CreateInstance(dictionary[part.GetType()]);
                ComputerPartFactory factory;
                if (obj != null)
                {
                    factory = (ComputerPartFactory)obj;
                    isCorrect = factory.checkFields(part, controlsPanel, part.GetType().ToString());
                }
            }
            return isCorrect;
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (checkFields() && typeComboBox.SelectedIndex != -1)
            {
                if (part != null)
                    if (currMode == mode.Add)
                        MainForm.computerParts.Add(part);
                    else
                    {
                        MainForm.deleteComputerPart(partIndex);
                        MainForm.computerParts[partIndex] = part;
                    }
                isAdd = true;
                Close();
            }
        }

        private void createCopy()
        {
            if (MainForm.typesList != null)
                copy = Activator.CreateInstance(MainForm.typesList[typeComboBox.SelectedIndex], part) as ComputerPart;
        }
        private void AddForm_Load(object sender, EventArgs e)
        {
            if (currMode == mode.Add)
            {
                this.Text = "Add Form";
                button.Text = "Add computer part";
                mainLabel.Text = "Add Computer Part";
            }
            else if (currMode == mode.View)
            {
                this.Text = "View Form";
                button.Text = "Close";
                mainLabel.Text = "View Computer Part";
                typeComboBox.Enabled = false;
                fillControls(false);
            }
            else if (currMode == mode.Edit)
            {
                this.Text = "Edit Form";
                button.Text = "Edit computer part fields";
                mainLabel.Text = "Edit Computer Part";
                typeComboBox.Enabled = false;
                fillControls(true);
                createCopy();
            }
        }

        private void AddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isAdd)
                part = copy;
        }
    }
}
