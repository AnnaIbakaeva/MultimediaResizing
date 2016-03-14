using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResizingApplication
{
    public partial class Form1 : Form
    {
        private Random random;
        public Form1()
        {
            InitializeComponent();
            random = new Random();
        }

        private List<DoublePoint> CreateInitArray(int n)
        {
            var initArray = new List<DoublePoint>();
            for (int i = 0; i < n; i++)
            {
                initArray.Add(new DoublePoint(i, random.Next(0, 100)));
            }
            return initArray;
        }
        
    }
}
