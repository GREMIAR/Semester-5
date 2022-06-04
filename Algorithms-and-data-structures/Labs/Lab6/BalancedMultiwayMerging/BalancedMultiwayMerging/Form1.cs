using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BalancedMultiwayMerging
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Open_Click(object sender, EventArgs e)
        {
            if (textBox_mergeWaysCount.Text=="" || int.Parse(textBox_mergeWaysCount.Text)<2)
            {
                MessageBox.Show("Число путей слияния должно быть не менее 2.", "Ошибка");
                return;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Algorithm alg = new Algorithm(openFileDialog.FileName, int.Parse(textBox_mergeWaysCount.Text), checkBox_Clean.Checked);
                alg.Sort();
            }
        }

        private void textBox_mergeWaysCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}
