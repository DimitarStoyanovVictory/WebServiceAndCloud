using System;
using System.Drawing;
using System.Web.Http;

namespace Problem3.DistanceCalculatorRESTService
{
    public class CalculatorControler : ApiController
    {
        public double CalcDistance(Point startPoint, Point endPoint)
        {
            int deltaX = startPoint.X - endPoint.X;
            int deltaY = startPoint.Y - endPoint.Y;
            return Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
        }
    }
}