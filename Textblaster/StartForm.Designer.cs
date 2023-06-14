namespace Textblaster {
    partial class StartForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            configButton = new Button();
            editButton = new Button();
            addButton = new Button();
            templates = new ComboBox();
            copyButton = new Button();
            flowLayoutPanel = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // configButton
            // 
            configButton.Location = new Point(12, 12);
            configButton.Name = "configButton";
            configButton.Size = new Size(308, 23);
            configButton.TabIndex = 0;
            configButton.Text = "Platzhalter anpassen";
            configButton.UseVisualStyleBackColor = true;
            configButton.Click += ConfigButton_Click;
            // 
            // editButton
            // 
            editButton.Location = new Point(268, 41);
            editButton.Name = "editButton";
            editButton.Size = new Size(23, 23);
            editButton.TabIndex = 1;
            editButton.Text = "x";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // addButton
            // 
            addButton.Location = new Point(297, 41);
            addButton.Name = "addButton";
            addButton.Size = new Size(23, 23);
            addButton.TabIndex = 2;
            addButton.Text = "+";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // templates
            // 
            templates.FormattingEnabled = true;
            templates.Location = new Point(12, 41);
            templates.Name = "templates";
            templates.Size = new Size(250, 23);
            templates.TabIndex = 3;
            templates.SelectedIndexChanged += templates_SelectedIndexChanged;
            // 
            // copyButton
            // 
            copyButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            copyButton.Location = new Point(12, 226);
            copyButton.Name = "copyButton";
            copyButton.Size = new Size(308, 23);
            copyButton.TabIndex = 4;
            copyButton.Text = "Vorlage kopieren";
            copyButton.UseVisualStyleBackColor = true;
            copyButton.Click += copyButton_Click;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.AutoSize = true;
            flowLayoutPanel.Location = new Point(12, 70);
            flowLayoutPanel.MaximumSize = new Size(308, 150);
            flowLayoutPanel.MinimumSize = new Size(308, 0);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(308, 150);
            flowLayoutPanel.TabIndex = 5;
            // 
            // StartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(332, 261);
            Controls.Add(flowLayoutPanel);
            Controls.Add(copyButton);
            Controls.Add(templates);
            Controls.Add(addButton);
            Controls.Add(editButton);
            Controls.Add(configButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "StartForm";
            Text = "TextBlaster";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button configButton;
        private Button editButton;
        private Button addButton;
        private ComboBox templates;
        private Button copyButton;
        private FlowLayoutPanel flowLayoutPanel;
    }
}