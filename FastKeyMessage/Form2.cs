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

namespace FastKeyMessage
{
    public partial class Form2 : Form
    {
        Pathes pathes = new Pathes();
        int numNubmer = 0;
        public string[] NumButtonsText = new string[9];
        public Form2()
        {
            InitializeComponent();
            NumButtonsText[0] = Num1Button.Text;
            NumButtonsText[1] = Num2Button.Text;
            NumButtonsText[2] = Num3Button.Text;
            NumButtonsText[3] = Num4Button.Text;
            NumButtonsText[4] = Num5Button.Text;
            NumButtonsText[5] = Num6Button.Text;
            NumButtonsText[6] = Num7Button.Text;
            NumButtonsText[7] = Num8Button.Text;
            NumButtonsText[8] = Num9Button.Text;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void Num1Button_Click(object sender, EventArgs e)
        {
            textBox1.Text = File.ReadAllText(pathes.MessagePath1);
            label1.Text = "Выбран Numpad 1";
        }


        private void Num2Button_Click(object sender, EventArgs e)
        {
            textBox1.Text = File.ReadAllText(pathes.MessagePath2);
            numNubmer = 2;
            label1.Text = "Выбран Numpad 2";
        }

        private void Num3Button_Click(object sender, EventArgs e)
        {
            textBox1.Text = File.ReadAllText(pathes.MessagePath3);
            numNubmer = 3;
            label1.Text = "Выбран Numpad 3";
        }

        private void Num4Button_Click(object sender, EventArgs e)
        {
            textBox1.Text = File.ReadAllText(pathes.MessagePath4);
            numNubmer = 4;
            label1.Text = "Выбран Numpad 4";
        }

        private void Num5Button_Click(object sender, EventArgs e)
        {
            textBox1.Text = File.ReadAllText(pathes.MessagePath5);
            numNubmer = 5;
            label1.Text = "Выбран Numpad 5";
        }

        private void Num6Button_Click(object sender, EventArgs e)
        {
            textBox1.Text = File.ReadAllText(pathes.MessagePath6);
            numNubmer = 6;
            label1.Text = "Выбран Numpad 6";
        }

        private void Num7Button_Click(object sender, EventArgs e)
        {
            textBox1.Text = File.ReadAllText(pathes.MessagePath7);
            numNubmer = 7;
            label1.Text = "Выбран Numpad 7"; 
        }

        private void Num8Button_Click(object sender, EventArgs e)
        {
            textBox1.Text = File.ReadAllText(pathes.MessagePath8);
            numNubmer = 8;
            label1.Text = "Выбран Numpad 8";
        }

        private void Num9Button_Click(object sender, EventArgs e)
        {
            textBox1.Text = File.ReadAllText(pathes.MessagePath9);
            numNubmer = 9;
            label1.Text = "Выбран Numpad 9";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (numNubmer)
            {
                case 1:
                    File.WriteAllText(pathes.MessagePath1, textBox1.Text);
                    break;
                case 2:
                    File.WriteAllText(pathes.MessagePath2, textBox1.Text);
                    break;
                case 3:
                    File.WriteAllText(pathes.MessagePath3, textBox1.Text);
                    break;
                case 4:
                    File.WriteAllText(pathes.MessagePath4, textBox1.Text);
                    break;
                case 5:
                    File.WriteAllText(pathes.MessagePath5, textBox1.Text);
                    break;
                case 6:
                    File.WriteAllText(pathes.MessagePath6, textBox1.Text);
                    break;
                case 7:
                    File.WriteAllText(pathes.MessagePath7, textBox1.Text);
                    break;
                case 8:
                    File.WriteAllText(pathes.MessagePath8, textBox1.Text);
                    break;
                case 9:
                    File.WriteAllText(pathes.MessagePath9, textBox1.Text);
                    break;

            }
        }
    }
}
