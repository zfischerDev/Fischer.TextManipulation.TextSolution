using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
