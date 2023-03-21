namespace Object_Editor
{
    partial class AddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            typeComboBox = new ComboBox();
            label2 = new Label();
            mainLabel = new Label();
            button = new Button();
            labelPanel = new Panel();
            controlsPanel = new Panel();
            panel1 = new Panel();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // typeComboBox
            // 
            typeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            typeComboBox.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            typeComboBox.FormattingEnabled = true;
            typeComboBox.Location = new Point(245, 57);
            typeComboBox.Name = "typeComboBox";
            typeComboBox.Size = new Size(218, 29);
            typeComboBox.TabIndex = 0;
            typeComboBox.SelectedValueChanged += typeComboBox_SelectedValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(33, 55);
            label2.Name = "label2";
            label2.Size = new Size(176, 25);
            label2.TabIndex = 0;
            label2.Text = "Computer part type";
            // 
            // mainLabel
            // 
            mainLabel.AutoSize = true;
            mainLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            mainLabel.Location = new Point(141, 9);
            mainLabel.Name = "mainLabel";
            mainLabel.Size = new Size(205, 30);
            mainLabel.TabIndex = 3;
            mainLabel.Text = "Add Computer part";
            // 
            // button
            // 
            button.Dock = DockStyle.Bottom;
            button.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button.Location = new Point(0, 76);
            button.Name = "button";
            button.Size = new Size(475, 41);
            button.TabIndex = 6;
            button.Text = "Add Computer Part";
            button.UseVisualStyleBackColor = true;
            button.Click += button_Click;
            // 
            // labelPanel
            // 
            labelPanel.AutoSize = true;
            labelPanel.Location = new Point(4, 3);
            labelPanel.Name = "labelPanel";
            labelPanel.Size = new Size(215, 48);
            labelPanel.TabIndex = 5;
            // 
            // controlsPanel
            // 
            controlsPanel.AutoSize = true;
            controlsPanel.Location = new Point(240, 3);
            controlsPanel.Name = "controlsPanel";
            controlsPanel.Size = new Size(342, 54);
            controlsPanel.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(button);
            panel1.Location = new Point(5, 110);
            panel1.Name = "panel1";
            panel1.Size = new Size(475, 117);
            panel1.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.Controls.Add(controlsPanel);
            panel2.Controls.Add(labelPanel);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(475, 60);
            panel2.TabIndex = 8;
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(489, 248);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(typeComboBox);
            Controls.Add(mainLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AddForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddForm";
            FormClosing += AddForm_FormClosing;
            Load += AddForm_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox typeComboBox;
        private Label label2;
        private Label mainLabel;
        private Button button;
        private Panel labelPanel;
        private Panel controlsPanel;
        private Panel panel1;
        private Panel panel2;
    }
}