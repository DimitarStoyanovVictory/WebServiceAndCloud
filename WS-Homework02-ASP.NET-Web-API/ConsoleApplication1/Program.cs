using System;
using System.Globalization;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            DateTime date = DateTime.ParseExact("16/09/1989", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine(date.Year);
        }
    }
}
