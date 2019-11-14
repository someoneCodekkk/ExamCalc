using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonNumber_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            //MessageBox.Show(b.Name);
            textBoxExpression.Text += b.Text;
        }

        void ClearTextBoxExpression()
        {
            textBoxExpression.Clear();
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxExpression();
        }
    }
}
