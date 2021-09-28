using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextFliper
{
    public partial class Form1 : Form
    {

        private char[] textInputArea;

        public Form1()
        {
            InitializeComponent();
            textBox2.ReadOnly = true;
        }
        public void GetText()
        {
            int printFrom = 0;
            int printTo = 0;
            string textInput;
            textBox2.Text = "";
            textInputArea = textBox1.Text.ToArray();
            while( printFrom < textInputArea.Length)
            {
                int i;
                textInput = "";
                for (i = printFrom; i < textInputArea.Length && textInputArea[i] != '\r'; i++)
                {
                    printTo = i;
                }
                for (i = printTo ; i >= printFrom; i--)
                {
                    textInput += textInputArea[i];
                }
                printFrom = printTo + 1;
                if (printFrom < textInputArea.Length && textInputArea[printFrom] == '\r')
                {
                    textInput += textInputArea[printFrom];
                    printFrom++;
                    textInput += textInputArea[printFrom];
                    printFrom++;
                }
                textBox2.Text += textInput;
            }

           

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetText();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.SelectAll();
            textBox2.Copy();
        }
    }
}
