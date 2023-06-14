using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Textblaster {
    public partial class StartForm : Form {
        private const string FOLDERPATH = "./templates";
        private const string CONFIG_PATH = @"./config.txt";
        private const string SEPERATOR = ";";
        private readonly Dictionary<string, string> _dynamicPlaceholder = new() {
            { "[date]", DateTime.Now.ToShortDateString() },
            { "[time]", DateTime.Now.ToShortTimeString() },
            { "[datetime]", DateTime.Now.ToString() },
        };

        public StartForm() {
            InitializeComponent();

            //Load templates
            updateTemplateList();
        }

        private void ConfigButton_Click(object sender, EventArgs e) {
            ConfigForm configForm = new ConfigForm(_dynamicPlaceholder, CONFIG_PATH, SEPERATOR);
            configForm.Show();
        }

        private void editButton_Click(object sender, EventArgs e) {
            string templateName = templates.SelectedItem.ToString() ?? "";
            openTemplateForm(templateName);
        }

        private void addButton_Click(object sender, EventArgs e) {
            openTemplateForm();
        }

        private void openTemplateForm(string templateName = "") {
            TemplateForm templateForm = new TemplateForm(this, FOLDERPATH, templateName);
            templateForm.Show();
        }

        public void updateTemplateList() {
            string[] fileNames = Directory.GetFiles(FOLDERPATH);
            templates.Items.Clear();

            //Update filename list
            foreach (string filePath in fileNames) {
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                templates.Items.Add(fileName);
            }

            //Auto-Select first filename
            if (templates.Items.Count > 0) {
                templates.SelectedIndex = 0;
            }

            //Reload placeholder fields
            loadInputFields();
        }

        private async void copyButton_Click(object sender, EventArgs e) {
            string selectedTemplate = templates.SelectedItem.ToString() ?? "";
            if (!string.IsNullOrEmpty(selectedTemplate)) {
                string filePath = Path.Combine(FOLDERPATH, selectedTemplate + ".txt");

                if (File.Exists(filePath)) {
                    //Read template file content
                    string template = File.ReadAllText(filePath);
                    template = replacePlaceholder(template);
                    Clipboard.SetText(template);
                    string oldText = copyButton.Text;
                    copyButton.ForeColor = Color.Green;
                    copyButton.Text = "Kopiert! " + (template.Length / 4) + " Sekunden gespart";
                    await Task.Delay(5000);
                    copyButton.ForeColor = Color.Black;
                    copyButton.Text = oldText;
                }
            }
        }

        private void templates_SelectedIndexChanged(object sender, EventArgs e) {
            loadInputFields();
        }

        private void loadInputFields() {
            //Load dynamic placeholder
            Dictionary<string, string> configValues = new Dictionary<string, string>();
            foreach (string key in _dynamicPlaceholder.Keys) {
                configValues.Add(key, _dynamicPlaceholder[key]);
            }

            //Read config file
            if (File.Exists(CONFIG_PATH)) {
                TextReader reader = new StreamReader(CONFIG_PATH);
                string? line;
                while ((line = reader.ReadLine()) != null) {
                    string[] lineValues = line.Split(SEPERATOR);
                    if (lineValues.Length == 2 && !configValues.ContainsKey(lineValues[0])) {
                        configValues.Add(lineValues[0], lineValues[1]);
                    }
                }
                reader.Close();
            }

            //Read template file
            string fileContent = "";
            string filePath = Path.Combine(FOLDERPATH, templates.SelectedItem.ToString() + ".txt");
            if (File.Exists(filePath)) {
                fileContent = File.ReadAllText(filePath);
            }

            if (!string.IsNullOrEmpty(fileContent)) {
                Regex regex = new Regex(@"\[(.*?)\]");
                MatchCollection matches = regex.Matches(fileContent);

                List<string> placeholders = new List<string>();
                foreach (Match match in matches) {
                    if (!placeholders.Contains(match.Groups[1].Value)) {
                        placeholders.Add(match.Groups[1].Value);
                    }
                }

                flowLayoutPanel.Controls.Clear();
                foreach (string placeholder in placeholders) {
                    Label label = new Label();
                    label.Text = placeholder;

                    TextBox textBox = new TextBox();
                    textBox.Text = configValues.GetValueOrDefault("[" + placeholder + "]", "");
                    textBox.Width = flowLayoutPanel.ClientSize.Width - label.Width - SystemInformation.VerticalScrollBarWidth;

                    flowLayoutPanel.Controls.Add(label);
                    flowLayoutPanel.Controls.Add(textBox);
                }
                flowLayoutPanel.PerformLayout();
            }
        }

        private string replacePlaceholder(string template) {
            //Replace placeholder in template
            string lastLabel = "";
            foreach (Control control in flowLayoutPanel.Controls) {
                if (control is Label) {
                    Label label = (Label)control;
                    lastLabel = "[" + label.Text + "]";
                } else if (control is TextBox) {
                    TextBox textBox = (TextBox)control;
                    template = template.Replace(lastLabel, textBox.Text);
                }
            }

            //Return filled template
            return template;
        }
    }
}