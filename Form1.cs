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

        private List<double> CreateInitArray(int n)
        {
            var initArray = new List<double>();
            for (int i = 0; i < n; i++)
            {
                initArray.Add(random.NextDouble());
            }
            return initArray;
        }
        
    }
}
