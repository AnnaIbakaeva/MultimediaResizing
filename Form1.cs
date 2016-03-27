using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ResizingApplication
{
    public partial class Form1 : Form
    {
        private Random random;
        private int initArrayCount;
        private int endArrayCount;
        public Form1()
        {
            InitializeComponent();
            random = new Random();

            UpdateInitArrayCount();
            UpdateEndArrayCount();

            Calculate();
        }

        private void Calculate()
        {
            var initArray = CreateInitArray();
            OutputListBox.Items.Clear();
            chart1.Series[0].Points.Clear();
            foreach (var point in initArray)
            {
                chart1.Series[0].Points.Add(new DataPoint(point.X, point.Y));
                OutputListBox.Items.Add("x: " + Math.Round(point.X, 3) + ", y: " + Math.Round(point.Y, 3) + "\n");
            }
            var endArray = SizeConverter.Convert(initArray, endArrayCount);
            listBox1.Items.Clear();
            chart1.Series[1].Points.Clear();
            foreach (var point in endArray)
            {
                chart1.Series[1].Points.Add(new DataPoint(point.X, point.Y));
                listBox1.Items.Add("x: " + Math.Round(point.X, 3) + ", y: " + Math.Round(point.Y, 3) + "\n");
            }
        }

        private List<DoublePoint> CreateInitArray()
        {
            var initArray = new List<DoublePoint>();
            for (int i = 0; i < initArrayCount; i++)
            {
                initArray.Add(new DoublePoint(i, random.Next(1, 10)));
            }
            return initArray;
        }

        private void UpdateInitArrayCount()
        {
            try
            {
                initArrayCount = Convert.ToInt32(textBox1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Неверный формат данных. Введите целое число.");
                textBox1.Text = "1";
                initArrayCount = Convert.ToInt32(textBox1.Text);
            }
        }

        private void UpdateEndArrayCount()
        {
            try
            {
                endArrayCount = Convert.ToInt32(textBox2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Неверный формат данных. Введите целое число.");
                textBox2.Text = "1";
                endArrayCount = Convert.ToInt32(textBox2.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateInitArrayCount();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateEndArrayCount();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Calculate();
        }
    }
}
