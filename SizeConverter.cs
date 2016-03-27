using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResizingApplication
{
    static class SizeConverter
    {
        public static List<DoublePoint> Convert(List<DoublePoint> initArray, int newCount)
        {
            var newArray = new List<DoublePoint>();
            double segmentSize = (double)(initArray.Count-1) / newCount;
            double currentX = 0;
            double[] arrayX = new double[newCount];
            double[] arrayY = new double[newCount];
            for (int i = 0; i < newCount; i++)
            {
                arrayX[i] = currentX;
                currentX += segmentSize;
            }
            newArray.Add(new DoublePoint(arrayX[0], initArray[0].Y));
            arrayY[0] = initArray[0].Y;
            for (int i = 1; i < arrayX.Length; i++)
            {
                int max = (int)Math.Ceiling(arrayX[i]);
                int min = (int)Math.Floor(arrayX[i]);
                double y = 0;
                if (min != max)
                    y = CalculatePointY(initArray[min], initArray[max], arrayX[i]);
                else
                    y = initArray[min].Y;
                arrayY[i] = y;
                
                double sumSquare = 0;
                for (int j = 0; j < min; j++)
                {
                    sumSquare += CalculateTrapeziumSquare(initArray[j], initArray[j + 1]);
                }
                sumSquare += CalculateTrapeziumSquare(initArray[min], new DoublePoint(arrayX[i], y));
                var averageY = sumSquare / arrayX[i];
                newArray.Add(new DoublePoint(arrayX[i], averageY));
            }
            newArray.Add(initArray.Last());
            return newArray;
        }

        private static double CalculateTrapeziumSquare(DoublePoint p1, DoublePoint p2)
        {
            var h = (p2.Y + p1.Y) / 2;
            return h * (p2.X - p1.X);
        }

        private static double CalculatePointY(DoublePoint p1, DoublePoint p2, double x)
        {
            double tmp = (x - p1.X) * (p2.Y - p1.Y);
            double y = (tmp / (p2.X - p1.X)) + p1.Y;
            //	double tmp = (p2.Y*p1.X) - (p1.Y*p2.X);
            //	double b = tmp/(p1.X - p2.X);
            //	double k = (p1.Y - b)/p1.X;
            //	double y = (k * x) + b;
            return y;
        }
    }
}
