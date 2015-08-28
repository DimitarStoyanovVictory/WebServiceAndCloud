using System;
using System.Net;

namespace Problem3.DistanceCalculatorClient
{
    public class Program
    {
        static void Main()
        {
            using (var client = new WebClient())
            {
                var responce =
                    client.UploadString(
                        "http://localhost:53134/distance?startPointX=2&startpointY=4&endPointX=3&endPointY=5", "POST",
                        "");
                Console.WriteLine(responce);    
            }
        }
    }
}
