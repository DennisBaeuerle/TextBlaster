using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Textblaster {
    public partial class ConfigForm : Form {
        private Dictionary<string, string> _dynamicPlaceholder;
        private string _configPath;
        private string _seperator;

        public ConfigForm(Dictionary<string, string> dynamicPlaceholder, string configPath, string seperator) {
            //Init component
            InitializeComponent();
            _dynamicPlaceholder = dynamicPlaceholder;
            _configPath = configPath;
            _seperator = seperator;

            //Set default configurations
            foreach (string key in dynamicPlaceholder.Keys) {
                placeholderDataGrid.Rows.Add(key, _dynamicPlaceholder[key]);
            }

            //Disable default configurations
            foreach (DataGridViewRow row in placeholderDataGrid.Rows) {
                if (row.Index != placeholderDataGrid.Rows.Count - 1) {
                    row.ReadOnly = true;
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                }
            }

            //Read config file
            if (File.Exists(_configPath)) {
                TextReader reader = new StreamReader(_configPath);
                string? line;
                while ((line = reader.ReadLine()) != null) {
                    string[] values = line.Split(_seperator);
                    if (values.Length == 2) {
                        placeholderDataGrid.Rows.Add(values[0], values[1]);
                    }
                }

                //Close reader
                reader.Close();
            } else {
                File.Create(_configPath).Close();
            }
        }

        private void saveConfigButton_Click(object sender, EventArgs e) {
            TextWriter writer = new StreamWriter(_configPath);
            for (int i = 0; i < placeholderDataGrid.Rows.Count - 1; i++) {
                for (int j = 0; j < placeholderDataGrid.Columns.Count; j++) {
                    string value = placeholderDataGrid.Rows[i].Cells[j].Value.ToString() ?? "";
                    if (j == 0 && !string.IsNullOrEmpty(value)) {
                        bool hasKey = _dynamicPlaceholder.ContainsKey(value);
                        if (hasKey) {
                            continue;
                        }
                    }
                    writer.Write(value);
                    if (j < placeholderDataGrid.Columns.Count - 1) {
                        writer.Write(_seperator);
                    }
                }
                writer.Write("\n");
            }
            writer.Close();
            this.Close();
        }

        private void placeholderDataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == 0) {
                string newValue = placeholderDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() ?? "";
                if (!(newValue.StartsWith("[") && newValue.EndsWith("]"))) {
                    placeholderDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "[" + newValue + "]";
                }
            }
        }
    }
}
