using System;
using System.Windows.Forms;

namespace Queue
{
    public partial class Form1 : Form
    {
        Queue queue;
        ListOur list;
        public Form1()
        {
            InitializeComponent();
            queue = new Queue(5);
            list = new ListOur();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Node node = new Node(textBox1.Text, int.Parse(textBox2.Text));
            if (radioButton1.Checked)
            {
                queue.EnQueue(node);
                WriteQueue();
            }
            else
            {
                list.Add(node);
                WriteList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                queue.Step();
                WriteQueue();
            }
            else
            {
                list.Step();
                WriteList();
            }
        }

        void WriteQueue()
        {
            richTextBox1.Clear();
            Node now = queue.Head;
            for (int i = 0; i < queue.Count; i++)
            {
                richTextBox1.Text += now.Data + " " + now.Time + "\n";
                now = now.Next;
            }
        }

        void WriteList()
        {
            richTextBox1.Clear();
            Node now = list.Head;
            while (now !=null)
            {
                richTextBox1.Text += now.Data + " " + now.Time + "\n";
                now = now.Next;
            }
        }
    }
}
