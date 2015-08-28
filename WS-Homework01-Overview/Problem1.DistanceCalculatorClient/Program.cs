using System;
using WS_Homework01_Overview;

namespace Problem2.DistanceCalculator
{
    using DistanceCalculatorClient.ServiceReferanceCalculator;

    public class Program
    {
        static void Main()
        {
            var calculator = new DistanceCalculatorClient();
            var result = calculator.CalcDistance(
                new Point() {X = 5, Y = 7},
                new Point() {X = 8, Y = 10}
                );

            Console.WriteLine("Distance between the two points {0:F2}", result);
        }
    }
}
