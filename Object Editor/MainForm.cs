using Object_Editor.Classes;
using System.Reflection;

namespace Object_Editor
{
    public partial class MainForm : Form
    {
        public static Type[]? typesList;
        internal static List<ComputerPart> computerParts = new List<ComputerPart>();
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
    }
}