using System.Net.Http;

namespace Battleships.Client
{
    public class Program
    {
        static void Main()
        {
            var httpClient = new HttpClient();

            RegisterUser(httpClient);
        }

        private static void RegisterUser(HttpClient httpClient)
        {
            using (httpClient)
            {
                
            }
        }
    }
}
