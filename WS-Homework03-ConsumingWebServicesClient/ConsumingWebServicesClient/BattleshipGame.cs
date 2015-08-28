using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ConsumingWebServicesClient
{
    public class BattleshipGame
    {
        private const string BaseUri = "http://localhost:62858";
        private const string RegisterUserUri = BaseUri + "/api/account/register";
        private const string LoginUserUri = BaseUri + "/Token";
        private const string CreateGameUri = BaseUri + "/api/games/create";
        private const string JoinGameUri = BaseUri + "/api/games/join";
        private const string PlayGameUri = BaseUri + "/api/games/play";
        private const int ReadLineBufferSize = 600;

        static void Main()
        {
            Console.Write("Welcome to BattleShip game enter command to start: ");

            var command = Console.ReadLine();
            while (command != "")
            {
                switch (command)
                {
                    case "register":
                        RegisterUser();
                        break;

                    case "login":
                        LoginUser();
                        break;

                    case "create-game":
                        CreateGame();
                        break;

                    case "join-game":
                        JoinGame();
                        break;

                    case "play":
                        PlayGame();
                        break;

                    case "": break;

                    default:
                        Console.WriteLine("No command of that type, pleace renter command or press \"Enter\" if you wish to quit: ");
                        break;
                }

                command = Console.ReadLine();
            }
        }

        private async static void PlayGame()
        {
            var httpClient = new HttpClient();

            using (httpClient)
            {
                Console.Write("Pleace enter access token: ");
                var accessToken = ReadLine();
                Console.Write("Pleace enter game identity number: ");
                var createGameId = ReadLine();
                Console.Write("Pleace enter the position you want to move on axis X");
                var positionX = Console.ReadLine();
                Console.Write("Pleace enter the position you want to move on axis Y");
                var positionY = Console.ReadLine();

                httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("Bearer " + accessToken);

                var bodyData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("GameId", createGameId),
                    new KeyValuePair<string, string>("GameId", positionX),
                    new KeyValuePair<string, string>("GameId", positionY)
                });

                var responce = await httpClient.PostAsync(PlayGameUri, bodyData);
                if (!responce.IsSuccessStatusCode)
                {
                    Console.WriteLine(responce.StatusCode + " " + responce.Content.ReadAsStringAsync().Result);
                    PrintMessages();
                }
                else
                {
                    var game = responce.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(game);
                    PrintMessages();
                }
            }
        }

        private async static void CreateGame()
        {
            var httpClient = new HttpClient();

            using (httpClient)
            {
                httpClient = new HttpClient();
                Console.Write("Pleace enter access token: ");
                var accessToken = ReadLine();

                httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("Bearer " + accessToken);

                var responce = await httpClient.PostAsync(CreateGameUri, null);
                if (!responce.IsSuccessStatusCode)
                {
                    Console.WriteLine(responce.StatusCode + " " + responce.Content.ReadAsStringAsync().Result);
                    PrintMessages();
                }
                else
                {
                    var game = responce.Content.ReadAsStringAsync();
                    Console.WriteLine("Game created with Id: {0}", game.Id);
                    PrintMessages();
                }
            }
        }

        private async static void LoginUser()
        {
            var httpClient = new HttpClient();

            using (httpClient)
            {
                Console.Write("Pleace enter the username that you want to login: ");
                var username = Console.ReadLine();
                Console.Write("Pleace enter the password of the username: ");
                var password = Console.ReadLine();

                var bodyData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Username", username),
                    new KeyValuePair<string, string>("Password", password),
                    new KeyValuePair<string, string>("grant_type", "password")
                });

                var responce = await httpClient.PostAsync(LoginUserUri, bodyData);
                if (!responce.IsSuccessStatusCode)
                {
                    Console.WriteLine(responce.StatusCode + " " + responce.Content.ReadAsStringAsync().Result);
                    PrintMessages();
                }
                else
                {
                    var post = await responce.Content.ReadAsAsync<PostDTO>();
                    Console.WriteLine("Logged in with Username: {0};\nWith access_token: {1}", post.Username, post.Access_Token);
                    PrintMessages();
                }
            }
        }

        private async static void RegisterUser()
        {
            var httpClient = new HttpClient();

            using (httpClient)
            {
                Console.Write("Pleace enter the username that you want to login: ");
                var email = Console.ReadLine();
                Console.Write("Pleace enter the password of the username: ");
                var password = Console.ReadLine();
                Console.Write("Pleace confirm password of the username: ");
                var confirmPassword = Console.ReadLine();

                var bodyData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Email", email),
                    new KeyValuePair<string, string>("Password", password),
                    new KeyValuePair<string, string>("ConfirmPassword", confirmPassword)
                });

                var response = await httpClient.PostAsync(RegisterUserUri, bodyData);
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response.StatusCode + " " + response.Content.ReadAsStringAsync().Result);
                    PrintMessages();
                }
                else
                {
                    Console.WriteLine("Succesfully created account");
                    PrintMessages();
                }
            }
        }

        private async static void JoinGame()
        {
            var httpClient = new HttpClient();

            using (httpClient)
            {
                httpClient = new HttpClient();
                Console.Write("Pleace enter access token: ");
                var accessToken = ReadLine();
                Console.Write("Pleace enter game identity number: ");
                var gameId = ReadLine();

                httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("Bearer " + accessToken);

                var bodyData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("GameId", gameId)
                });

                var responce = await httpClient.PostAsync(JoinGameUri, bodyData);
                if (!responce.IsSuccessStatusCode)
                {
                    Console.WriteLine(responce.StatusCode + " " + responce.Content.ReadAsStringAsync().Result);
                    PrintMessages();
                }
                else
                {
                    var game = responce.Content.ReadAsStringAsync();
                    Console.WriteLine("Game joined with Id {0}", game.Id);
                    PrintMessages();
                }
            }
        }

        private static void PrintMessages()
        {
            Console.WriteLine("Command has finished");
            Console.Write("Press \"Enter\" if you wish to quit program or type the name of other command: ");
        }

        private static string ReadLine()
        {
            Stream inputStream = Console.OpenStandardInput(ReadLineBufferSize);
            byte[] bytes = new byte[ReadLineBufferSize];
            int outputLength = inputStream.Read(bytes, 0, ReadLineBufferSize);
            char[] chars = Encoding.UTF7.GetChars(bytes, 0, outputLength);
            return new string(chars).Replace("\r\n", "");
        }
    }
}
