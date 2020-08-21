using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace WFApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
                MessageBox.Show("Пустая строка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                bool textBoxDontHaveErrChar = true;
                for (int i = 0; i < Path.GetInvalidPathChars().Length; i++)
                    if (textBox1.Text.Contains(Path.GetInvalidPathChars()[i]))
                        textBoxDontHaveErrChar = false;
                if (textBox1.Text.Length > 2)
                    for (int i = 0; i < Path.GetInvalidFileNameChars().Length; i++)
                        if (textBox1.Text.Substring(3, textBox1.Text.Length - 3).Contains(Path.GetInvalidFileNameChars()[i]) && Path.GetInvalidFileNameChars()[i] != '\\')
                            textBoxDontHaveErrChar = false;
                if (
                    textBox1.Text.Substring(1, 2).Equals(":\\") &&
                    Char.IsLetter(Convert.ToChar(textBox1.Text.Substring(0, 1))) &&
                    textBoxDontHaveErrChar == true
                    )
                    listBox1.Items.Add(textBox1.Text);
                else
                    listBox2.Items.Add(textBox1.Text);
                textBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 1)
            {
                listBox2.Items.Add(listBox1.SelectedItem);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.Items.Remove(listBox2.SelectedItem);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItems.Count == 1)
            {
                textBox1.Text = Convert.ToString(listBox2.SelectedItem);
                listBox2.Items.Remove(listBox2.SelectedItem);
            }
        }
    }
}
