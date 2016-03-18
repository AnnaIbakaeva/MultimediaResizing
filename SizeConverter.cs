using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResizingApplication
{
    public static class SizeConverter
    {
        public static List<DoublePoint> Convert(List<DoublePoint> initArray, int newCount)
        {
            var newArray = new List<DoublePoint>();
            double segmentSize = (double)(initArray.Count)/newCount;
            double currentX = 0;
            double[] arrayX = new double[newCount];
            for (int i = 0; i < newCount; i++)
            {
                arrayX[i] = currentX;
                currentX += segmentSize;
            }
            for (int i=0; i < arrayX.Length; i++)
            {
                int max = (int)Math.Ceiling(arrayX[i]);
                int min = (int)Math.Floor(arrayX[i]);
                double y = 0;
                if (min != max)
                    y = CalculatePointY(initArray[min], initArray[max], arrayX[i]);
                else
                    y = initArray[min].Y;
                double sumSquare = 0;
                for (int j = 0; j < min; j++)
                {
                    sumSquare += CalculateTrapeziumSquare(initArray[j], initArray[j+1]);
                }
                sumSquare += CalculateTrapeziumSquare(initArray[min], new DoublePoint(arrayX[i], y));
                var width = arrayX[i];
                if (i > 0)
                    width = arrayX[i] - arrayX[i-1];
                var averageY = sumSquare / width;
                newArray.Add(new DoublePoint(arrayX[i], averageY));
            }
            return newArray;
        }

        private static double CalculateTrapeziumSquare(DoublePoint p1, DoublePoint p2)
        {
            var h = (p2.Y + p1.Y) / 2;
            return h * (p2.X - p1.X);
        }

        private static double CalculatePointY(DoublePoint p1, DoublePoint p2, double x)
        {
            double tmp = (p2.Y*p1.X) - (p1.Y*p2.X);
            double b = tmp/(p1.X - p2.X);
            double k = (p1.Y - b)/p1.X;
            double y = (k * x) + b;
            return y;
        }
    }
}
