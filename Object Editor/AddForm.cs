using System.Data;
using System.Reflection;
using Object_Editor.Classes;

namespace Object_Editor
{
    public partial class AddForm : Form
    {
        private const int PADDING = 50;
        private const int MAX_VALUE = 10000;
        public static int mode;
        public static int partIndex;
        public AddForm()
        {
            InitializeComponent();
        }

        Dictionary<Type, Type> dictionary = new Dictionary<Type, Type>()
        {
            { typeof(CPU), typeof(Factories.CPUFactory) },
            { typeof(HDD), typeof(Factories.HDDFactory) },
            { typeof(Headphones), typeof(Factories.HeadphonesFactory) },
            { typeof(Keyboard), typeof(Factories.KeyboardFactory) },
            { typeof(MotherBoard), typeof(Factories.MotherBoardFactory) },
            { typeof(Mouse), typeof(Factories.MouseFactory) },
            { typeof(SSD), typeof(Factories.SSDFactory) },
            { typeof(VideoCard), typeof(Factories.VideoCardFactory) },
        };

        private void createLabel(int location, string name)
        {
            ControlFactory factory = new LabelFactory(new Font("Times New Roman", 14.25F, FontStyle.Regular),
                    new Point(0, location), new Size(218, 30), labelPanel, Color.Black, name);
            factory.createControl();
        }

        private void createPart(Type type)
        {
            Object? obj = Activator.CreateInstance(dictionary[type]);
            Factories.ComputerPartFactory factory;
            if (obj != null)
            {
                factory = (Factories.ComputerPartFactory)obj;
                List<Object> list = new List<Object>();
                int count = controlsPanel.Controls.Count;
                for (int i = 0; i < count; i++)
                {
                    if (controlsPanel.Controls[i] is CheckBox)
                    {
                        CheckBox control = (CheckBox)controlsPanel.Controls[i];
                        list.Add(control.Checked.ToString());
                    }
                    else
                        list.Add(controlsPanel.Controls[i].Text);
                }
                ComputerPart part = factory.createPart(list);
                if (mode == 0)
                    MainForm.computerParts.Add(part);
                else
                    MainForm.computerParts[partIndex] = part;
            }

        }
        private void createControl(Type type, int location)
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
                createFields(type, location + PADDING);
            }
            else if (type.IsEnum)
            {
                FieldInfo[] fields = type.GetFields();
                factory = new ComboBoxFactory(new Font("Times New Roman", 14.25F, FontStyle.Regular), new Point(0, location),
                    new Size(218, 30), controlsPanel, fields.Skip(1).Select(i => i.Name).ToArray());
            }
            if (factory != null)
                factory.createControl();
        }

        private void createFields(Type type, int location)
        {
            var fields = type.GetProperties();
            foreach (PropertyInfo field in fields)
            {
                Attribute? name = field.GetCustomAttribute(typeof(NameAttribute));
                if (name != null)
                    createLabel(location, ((NameAttribute)name).Name);
                createControl(field.PropertyType, location);
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
            ComputerPart part = MainForm.computerParts[partIndex];
            string partName = part.GetType().ToString();
            partName = partName.Substring(partName.LastIndexOf(".") + 1);
            typeComboBox.SelectedIndex = typeComboBox.Items.IndexOf(partName);
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
        private void typeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            deleteControls(labelPanel);
            deleteControls(controlsPanel);
            int location = 0;
            Type? type = Type.GetType("Object_Editor.Classes." + typeComboBox.SelectedItem.ToString());
            if (type != null)
                createFields(type, location);
            CenterToScreen();
        }

        private void deleteErrorLabels()
        {
            int count = labelPanel.Controls.Count;
            for (int i = 0; i < labelPanel.Controls.Count; i++)
            {
                if (labelPanel.Controls[i].ForeColor == Color.Red)
                    labelPanel.Controls.Remove(labelPanel.Controls[i--]);
            }
        }
        private bool checkFields()
        {
            deleteErrorLabels();
            bool isCorrect = true;
            foreach (Control control in controlsPanel.Controls)
            {
                if ((control as NumericUpDown)?.Value > MAX_VALUE ||
                    (control as NumericUpDown)?.Value <= 0 ||
                    (control as TextBox)?.Text.Length == 0 ||
                    (control as TextBox)?.Text.Length > 15)
                {
                    Label label = new Label();
                    ControlFactory factory = new LabelFactory(new Font("Times New Roman", 10F, FontStyle.Regular),
                        new Point(0, control.Location.Y + 20), new Size(218, 15), labelPanel, Color.Red, "Error data");
                    factory.createControl();
                    isCorrect = false;
                }
            }
            return isCorrect;
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (checkFields())
            {
                if (mode != 1)
                {
                    Type? type = Type.GetType("Object_Editor.Classes." + typeComboBox.SelectedItem.ToString());
                    if (type != null && checkFields())
                        createPart(type);
                }
                Close();
            }
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            typeComboBox.Enabled = true;
            if (mode == 0)
            {
                this.Text = "Add Form";
                button.Text = "Add computer part";
                mainLabel.Text = "Add Computer Part";
            }
            else if (mode == 1)
            {
                this.Text = "View Form";
                button.Text = "Close";
                mainLabel.Text = "View Computer Part";
                typeComboBox.Enabled = false;
                fillControls(false);
            }
            else if (mode == 2)
            {
                this.Text = "Edit Form";
                button.Text = "Edit computer part fields";
                mainLabel.Text = "Edit Computer Part";
                fillControls(true);
            }
        }
    }
}
