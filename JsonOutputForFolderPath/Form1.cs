using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonOutputForFolderPath
{
    public partial class JSONFormat : Form
    {
        public JSONFormat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = folderDialog.SelectedPath;
                    textBox.Text="***  Input path: "+ path + "  ***\n";
                    string json = JsonHelper.FormatJson(path);
                    textBox.Text += json;
                    WriteJsonToTxt(json);
                }
            }
        }
        private void WriteJsonToTxt(string json)
        {
            using (StreamWriter writetext = new StreamWriter("json.txt"))
            {
                writetext.Write(json);
            }
        }
    }
}
