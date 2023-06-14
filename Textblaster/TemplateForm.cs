using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Textblaster {
    public partial class TemplateForm : Form {

        private StartForm _startForm;
        private string _folderPath;

        public TemplateForm(StartForm form, string folderPath) {
            InitializeComponent();
            _startForm = form;
            _folderPath = folderPath;
        }

        public TemplateForm(StartForm form, string folderPath, string templateName = "") {
            InitializeComponent();
            _folderPath = folderPath;
            _startForm = form;

            if (!string.IsNullOrEmpty(templateName)) {
                //Load template by name
                createFolderIfNotExists();
                string filePath = Path.Combine(_folderPath, templateName + ".txt");
                if (File.Exists(filePath)) {
                    //Read template file content
                    string fileContent = File.ReadAllText(filePath);

                    //Init template name & text
                    nameInput.Text = templateName;
                    templateText.Text = fileContent;
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e) {
            //Setup folder & filePath
            createFolderIfNotExists();
            string filePath = Path.Combine(_folderPath, nameInput.Text + ".txt");

            //Enter template into file
            string fileContent = templateText.Text;
            File.WriteAllText(filePath, fileContent);

            //Close edit form
            _startForm.updateTemplateList();
            this.Close();
        }

        private void createFolderIfNotExists() {
            if (!Directory.Exists(_folderPath)) {
                Directory.CreateDirectory(_folderPath);
            }
        }
    }
}
