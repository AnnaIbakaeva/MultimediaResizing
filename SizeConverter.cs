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
            for (int i = 0; i < newCount; i++)
            {
                newArray.Add(new DoublePoint(currentX, 0));
                currentX += segmentSize;
            }
            var 
            foreach (var point in newArray)
            {
                int max = (int)Math.Ceiling(point.X);
                int min = (int)Math.Floor(point.X);
                CalculatePointY(initArray[min], initArray[max], point);
            }
            return newArray;
        }

        private static void CalculateSquare()
        {
        }

        private static DoublePoint CalculatePointY(DoublePoint p1, DoublePoint p2, DoublePoint endPoint)
        {
            double tmp = (p2.Y*p1.X) - (p1.Y*p2.X);
            double b = tmp/(p1.X - p2.X);
            double k = (p1.Y - b)/p1.X;
            double y = (k * endPoint.X) + b;
            endPoint.Y = y;
            return endPoint;
        }
    }
}
