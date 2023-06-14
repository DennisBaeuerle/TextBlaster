namespace Textblaster {
    partial class ConfigForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            placeholderDataGrid = new DataGridView();
            descriptionLabel = new Label();
            saveConfigButton = new Button();
            placeholder = new DataGridViewTextBoxColumn();
            value = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)placeholderDataGrid).BeginInit();
            SuspendLayout();
            // 
            // placeholderDataGrid
            // 
            placeholderDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            placeholderDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            placeholderDataGrid.Columns.AddRange(new DataGridViewColumn[] { placeholder, value });
            placeholderDataGrid.Location = new Point(12, 12);
            placeholderDataGrid.Name = "placeholderDataGrid";
            placeholderDataGrid.RowTemplate.Height = 25;
            placeholderDataGrid.Size = new Size(565, 477);
            placeholderDataGrid.TabIndex = 0;
            placeholderDataGrid.CellEndEdit += placeholderDataGrid_CellEndEdit;
            // 
            // descriptionLabel
            // 
            descriptionLabel.Location = new Point(12, 541);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(565, 43);
            descriptionLabel.TabIndex = 2;
            descriptionLabel.Text = "Beschreibung: Hier können Sie alle Platzhalter editieren und definieren, die in Ihren Vorlagen verfügbar sein sollen. Diese werden im Programmordner als config.txt gespeichert.";
            // 
            // saveConfigButton
            // 
            saveConfigButton.Location = new Point(12, 504);
            saveConfigButton.Name = "saveConfigButton";
            saveConfigButton.Size = new Size(565, 23);
            saveConfigButton.TabIndex = 3;
            saveConfigButton.Text = "Änderungen übernehmen";
            saveConfigButton.UseVisualStyleBackColor = true;
            saveConfigButton.Click += saveConfigButton_Click;
            // 
            // placeholder
            // 
            placeholder.HeaderText = "Platzhalter";
            placeholder.Name = "placeholder";
            // 
            // value
            // 
            value.HeaderText = "Standard-Wert";
            value.Name = "value";
            // 
            // ConfigForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 593);
            Controls.Add(saveConfigButton);
            Controls.Add(descriptionLabel);
            Controls.Add(placeholderDataGrid);
            Name = "ConfigForm";
            Text = "TextBlaster";
            ((System.ComponentModel.ISupportInitialize)placeholderDataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView placeholderDataGrid;
        private Label descriptionLabel;
        private Button saveConfigButton;
        private DataGridViewTextBoxColumn placeholder;
        private DataGridViewTextBoxColumn value;
    }
}