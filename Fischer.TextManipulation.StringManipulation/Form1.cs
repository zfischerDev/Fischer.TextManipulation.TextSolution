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

namespace Fischer.TextManipulation.StringManipulation
{
    public partial class Form1 : Form
    {
        private TextProcessingLibrary textLibrary;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            textLibrary = new TextProcessingLibrary();

            if (!string.IsNullOrEmpty(txtToManipulate.Text))
            {
                //clear the result textbox
                txtResult.Text = string.Empty;
                txtResult.Text = textLibrary.ReverseText(txtToManipulate.Text);
            }
        }

        private void btnCountLetters_Click(object sender, EventArgs e)
        {
            //Clear the exisiting result
            txtResult.Text = string.Empty;

            textLibrary = new TextProcessingLibrary();
            txtResult.Text = textLibrary.GetCharCount(txtToManipulate.Text);
        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;
            txtToManipulate.Text = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
