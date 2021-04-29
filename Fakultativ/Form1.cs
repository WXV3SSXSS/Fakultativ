using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fakultativ
{
    public partial class Algoritm : Form
    {



        Random Rnd = new Random();
        int N;
        int Rmin, Rmax;
        int[] Numbers;
        int H;
        int Min, Max;
        bool log;



        public Algoritm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log = true;
            while (log)
            {
                log = false;
                for (int i = 0; i < N - 1; i++)
                {
                    if (Numbers[i] > Numbers[i + 1])
                    {
                        H = Numbers[i];
                        Numbers[i] = Numbers[i + 1];
                        Numbers[i + 1] = H;
                        log = true;
                    }
                }
            }
            for (int i = 0; i < N; i++)
            {
                dataGridView1[0, i].Value = Numbers[i];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            log = true;
            while (log)
            {
                log = false;
                for (int i = 0; i < N - 1; i++)
                {
                    if (Numbers[i] < Numbers[i + 1])
                    {
                        H = Numbers[i];
                        Numbers[i] = Numbers[i + 1];
                        Numbers[i + 1] = H;
                        log = true;
                    }
                }
            }
            for (int i = 0; i < N; i++)
            {
                dataGridView1[0, i].Value = Numbers[i];
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Min = Numbers[0];
            for (int i = 1; i < N; i++)
            {
                if (Numbers[i] < Min) Min = Numbers[i];
            }
            button4.Text = "Min = " + Min.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Max = Numbers[0];
            for (int i = 1; i < N; i++)
            {
                if (Numbers[i] > Max) Max = Numbers[i];
            }
            button3.Text = "Max = " + Max.ToString();
        }

        private void Alogoritm_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            string k;
            k = textBox1.Text;
            bool isNumeric = int.TryParse(k, out N);
            string k2;
            k2 = textBox2.Text;
            bool isNumeric2 = int.TryParse(k2, out N);
            string k3;
            k3 = textBox3.Text;
            bool isNumeric3 = int.TryParse(k3, out N);
            if (isNumeric & isNumeric2 & isNumeric3)
            {
                SayHello();
            }
            else
            {
                this.textBox1.ForeColor = System.Drawing.Color.Red;
                textBox1.Text = "Введите число!!!";
            }
        }

        public void SayHello()
        {

            N = int.Parse(textBox1.Text);
            Rmin = int.Parse(textBox2.Text);
            Rmax = int.Parse(textBox3.Text);
            Numbers = new int[N];
            dataGridView1.RowCount = N;
            int Count = 0;
            while (Count < N)
            {
                H = (int)((Rmax - Rmin) * Rnd.NextDouble() + Rmin + 0.49999);
                for (int i = 0; i < Count; i++)
                {
                    if (Numbers[i] == H) goto L1;

                    dataGridView1[0, i].Value = Numbers[i];
                }
                Numbers[Count] = H;
                Count++;
            L1:;
            }

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button3.Text = "Найти Максимум";
            button4.Text = "Найти минимум";
        }
    }
}
