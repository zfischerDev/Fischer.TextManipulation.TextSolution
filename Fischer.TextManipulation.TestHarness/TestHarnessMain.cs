using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fischer.TextManipulation.TextLibraries;

namespace Fischer.TextManipulation.TestHarness
{
    public partial class TestHarnessMain : Form
    {
        public TestHarnessMain()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            //get the file by choosing the path
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //Add the path to the textbox
                txtFilePath.Text = fileDialog.FileName; 
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            TextProcessingLibrary library = new TextProcessingLibrary();
            //Clear any existing results
            lstSearchResults.Items.Clear();

            //Get the matches
            List<string> resultList = library.GetAllSearchMatches(txtFilePath.Text, txtSearchText.Text);
            foreach (var result in resultList)
            {
                lstSearchResults.Items.Add(result);
            }
            
            MessageBox.Show(string.Format($"There are {resultList.Count} matches."));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
