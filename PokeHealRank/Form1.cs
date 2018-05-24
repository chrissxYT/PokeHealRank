using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PokeHealRank
{
    public partial class Form1 : Form
    {
        List<HealItem> his = new List<HealItem>();

        public Form1()
        {
            InitializeComponent();
            if (Program.args.Length > 0)
                his = IO.phr_load(Program.args[0]);
        }

        void ui_update()
        {
            int i = listBox1.SelectedIndex;
            listBox1.Items.Clear();
            foreach (HealItem hi in his)
                listBox1.Items.Add(hi.ToString());
            listBox1.SelectedIndex = i;
        }

        void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                AddExtension = true,
                Filter = "PokeHealRanks|*.phr"
            };
            sfd.ShowDialog();
            IO.phr_save(sfd.FileName, his);
        }

        void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                AddExtension = true,
                Filter = "PokeHealRanks|*.phr"
            };
            ofd.ShowDialog();
            his = IO.phr_load(ofd.FileName);
            ui_update();
        }

        void button3_Click(object sender, EventArgs e)
        {
            his.Add(new HealItem(textBox1.Text, byte.Parse(textBox2.Text), ushort.Parse(textBox3.Text)));
            ui_update();
        }

        void button4_Click(object sender, EventArgs e)
        {
            his = MergeSorting.Sort(his);
            ui_update();
        }
    }
}
