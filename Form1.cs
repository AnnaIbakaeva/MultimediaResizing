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
        public Form1()
        {
            InitializeComponent();
            random = new Random();
            var initArray = CreateInitArray(8);
            var series = new Series("Init");
            chart1.Series.Add(series);
            foreach (var point in initArray)
            {
                series.Points.Add(new DataPoint(point.X, point.Y));
            }
            var endArray = SizeConverter.Convert(initArray, 5);
            var series2 = new Series("End");
            chart1.Series.Add(series2);
            foreach (var point in endArray)
            {
                series2.Points.Add(new DataPoint(point.X, point.Y));
                OutputListBox.Text += "x: " + point.X + ", y: " + point.Y + "\n";
            }
        }

        private List<DoublePoint> CreateInitArray(int n)
        {
            var initArray = new List<DoublePoint>();
            for (int i = 0; i < n; i++)
            {
                initArray.Add(new DoublePoint(i, random.Next(1, 10)));
            }
            return initArray;
        }
        
    }
}
