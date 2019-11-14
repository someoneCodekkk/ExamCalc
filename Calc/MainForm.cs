﻿using System;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            //
        }

        private void buttonNumber_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if(b.Text.Equals("Backspace"))
            {
                if(textBoxExpression.Text.Length > 0)
                {
                    textBoxExpression.Text = textBoxExpression.Text.Remove(textBoxExpression.Text.Length - 1);
                }
            }
            else
            {
                textBoxExpression.Text += b.Text;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxExpression.Clear();
        }
    }
}
