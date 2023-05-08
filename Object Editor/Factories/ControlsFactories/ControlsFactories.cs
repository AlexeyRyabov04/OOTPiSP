using System.Reflection;

namespace Object_Editor.Factories.ControlsFactories
{
    internal abstract class ControlFactory
    {
        protected Font font;
        protected Point point;
        protected Size size;
        protected Panel panel;
        protected ControlFactory(Font _font, Point _point, Size _size, Panel _panel)
        {
            font = _font;
            point = _point;
            size = _size;
            panel = _panel;
        }
        public abstract Control createControl();
        public abstract void BindControl(Control control, object obj, string propertyName);
    }
    internal class LabelFactory : ControlFactory
    {
        private string text;
        private Color color;
        public LabelFactory(Font _font, Point _point, Size _size, Panel _panel, Color _color, string _text)
            : base(_font, _point, _size, _panel)
        {
            text = _text;
            color = _color;
        }
        public override Control createControl()
        {
            Label label = new Label();
            panel.Controls.Add(label);
            label.Font = font;
            label.Size = size;
            label.Location = point;
            label.Text = text;
            label.TextAlign = ContentAlignment.TopCenter;
            label.ForeColor = color;
            panel.Controls.SetChildIndex(label, 0);
            return label;
        }
        public override void BindControl(Control control, object obj, string propertyName) { }
    }

    internal class ComboBoxFactory : ControlFactory
    {
        private string[] fields;
        public ComboBoxFactory(Font _font, Point _point, Size _size, Panel _panel, string[] _fields)
            : base(_font, _point, _size, _panel)
        {
            fields = _fields;
        }
        public override Control createControl()
        {
            ComboBox comboBox = new ComboBox();
            panel.Controls.Add(comboBox);
            comboBox.Font = font;
            comboBox.Size = size;
            comboBox.Location = point;
            comboBox.FormattingEnabled = true;
            comboBox.Items.AddRange(fields);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.TabIndex = 0;
            comboBox.SelectedIndex = 0;
            comboBox.CausesValidation = false;
            panel.Controls.SetChildIndex(comboBox, 0);
            return comboBox;
        }
        public override void BindControl(Control control, object obj, string propertyName)
        {
            control.Name = obj + "." + propertyName + "Control";
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = obj;
            control.DataBindings.Add("Text", bindingSource, propertyName, true, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
    internal class TextBoxFactory : ControlFactory
    {
        private int maxLength;
        public TextBoxFactory(Font _font, Point _point, Size _size, Panel _panel, int _maxLength)
            : base(_font, _point, _size, _panel)
        {
            maxLength = _maxLength;
        }
        public override Control createControl()
        {
            TextBox textBox = new TextBox();
            panel.Controls.Add(textBox);
            textBox.Font = font;
            textBox.Size = size;
            textBox.Location = point;
            textBox.MaxLength = maxLength;
            panel.Controls.SetChildIndex(textBox, 0);
            return textBox;
        }
        public override void BindControl(Control control, object obj, string propertyName)
        {
            control.Name = obj + "." + propertyName + "Control";
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = obj;
            control.DataBindings.Add("Text", bindingSource, propertyName, true, DataSourceUpdateMode.OnPropertyChanged);
        }
    }

    internal class CheckBoxFactory : ControlFactory
    {
        public CheckBoxFactory(Font _font, Point _point, Size _size, Panel _panel)
            : base(_font, _point, _size, _panel) { }
        public override Control createControl()
        {
            CheckBox checkBox = new CheckBox();
            panel.Controls.Add(checkBox);
            checkBox.Font = font;
            checkBox.Size = size;
            checkBox.Location = point;
            panel.Controls.SetChildIndex(checkBox, 0);
            return checkBox;
        }
        public override void BindControl(Control control, object obj, string propertyName)
        {
            control.Name = obj + "." + propertyName + "Control";
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = obj;
            control.DataBindings.Add("Checked", bindingSource, propertyName, true, DataSourceUpdateMode.OnPropertyChanged);
        }
    }

    internal class NumericUpDownFactory : ControlFactory
    {
        private int maxValue;
        public NumericUpDownFactory(Font _font, Point _point, Size _size, Panel _panel, int _maxValue)
            : base(_font, _point, _size, _panel)
        {
            maxValue = _maxValue;
        }
        public override Control createControl()
        {
            NumericUpDown numericUpDown = new NumericUpDown();
            panel.Controls.Add(numericUpDown);
            numericUpDown.Font = font;
            numericUpDown.Size = size;
            numericUpDown.Location = point;
            numericUpDown.Maximum = maxValue;
            numericUpDown.Minimum = 0;
            numericUpDown.Value = 0;
            panel.Controls.SetChildIndex(numericUpDown, 0);
            return numericUpDown;
        }
        public override void BindControl(Control control, object obj, string propertyName)
        {
            control.Name = obj + "." + propertyName + "Control";
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = obj;
            control.DataBindings.Add("Value", bindingSource, propertyName, true, DataSourceUpdateMode.OnPropertyChanged);
        }
    }

}
