namespace Textblaster {
    partial class TemplateForm {
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
            saveButton = new Button();
            templateText = new RichTextBox();
            nameInput = new TextBox();
            SuspendLayout();
            // 
            // saveButton
            // 
            saveButton.Location = new Point(12, 415);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(776, 23);
            saveButton.TabIndex = 0;
            saveButton.Text = "Vorlage speichern";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // templateText
            // 
            templateText.Location = new Point(12, 48);
            templateText.Name = "templateText";
            templateText.Size = new Size(776, 361);
            templateText.TabIndex = 1;
            templateText.Text = "";
            // 
            // nameInput
            // 
            nameInput.Location = new Point(12, 12);
            nameInput.Name = "nameInput";
            nameInput.PlaceholderText = "Name der Vorlage...";
            nameInput.Size = new Size(776, 23);
            nameInput.TabIndex = 2;
            // 
            // TemplateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(nameInput);
            Controls.Add(templateText);
            Controls.Add(saveButton);
            Name = "TemplateForm";
            Text = "TextBlaster";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button saveButton;
        private RichTextBox templateText;
        private TextBox nameInput;
    }
}