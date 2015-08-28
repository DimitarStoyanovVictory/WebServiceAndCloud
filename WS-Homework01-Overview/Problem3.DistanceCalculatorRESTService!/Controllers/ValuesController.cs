using System;
using System.Web.Http;

namespace Problem3.DistanceCalculatorRESTService
{
    public class ValuesController : ApiController
    {
        [Route("distance")]
        public double CalcDistance(int startPointX, int startpointY, int  endPointX, int endPointY)
        {
            int deltaX = startPointX - endPointX;
            int deltaY = endPointX - endPointY;
            return Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
        }   
    }
}