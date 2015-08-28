using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using ConsumingWebServicesClient;

namespace ConsumingWebServicesClientGrpfic
{
    public partial class MainWindow
    {
        private const string BaseUri = "http://localhost:62858";
        private const string RegisterUserUri = BaseUri + "/api/account/register";
        private const string LoginUserUri = BaseUri + "/Token";
        private const string CreateGameUri = BaseUri + "/api/games/create";
        private const string JoinGameUri = BaseUri + "/api/games/join";
        private const string PlayGameUri = BaseUri + "/api/games/play";
        private const int ReadLineBufferSize = 600;
        private string commandName = "";
        public RegistrationInfo RegInfo { get; } = new RegistrationInfo();

        public MainWindow()
        {
            InitializeComponent();

            //CommandNameTextboxPlaceholder();

            button.Click += GetTextboxInfo;
        }

        //private void CommandNameTextboxPlaceholder()
        //{
        //    commandNameBox.Text = "Pleace enter command name...";

        //    commandNameBox.GotFocus += RemoveText;

        //    commandNameBox.LostFocus += AddText;
        //}

        //private void AddText(object sender, EventArgs e)
        //{
        //    commandNameBox.Text = "Pleace enter command name...";
        //}

        //private void RemoveText(object sender, EventArgs e)
        //{
        //    commandNameBox.Text = "";
        //}


        //Didn't have time for the other methods, they are analogical
        private void GetTextboxInfo(object sender, RoutedEventArgs e)
        {
            commandName = commandNameBox.Text;

            switch (commandName)
            {
                case "register":
                    RegisterUser();
                    break;

                //case "login":
                //    LoginUser();
                //    break;

                //case "create-game":
                //    CreateGame();
                //    break;

                //case "join-game":
                //    JoinGame();
                //    break;

                //case "play":
                //    PlayGame();
                //    break;

                case "":
                    break;

                default:
                    results.AppendText("No command of that type, pleace reenter command name in command textbox\n");
                    break;
            }
        }

        //private async void PlayGame()
        //{
        //    var httpClient = new HttpClient();

        //    var regInfo = GetPlayGameInfo();

        //    using (httpClient)
        //    {

        //        httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("Bearer " + accessToken);

        //        var bodyData = new FormUrlEncodedContent(new[]
        //        {
        //            new KeyValuePair<string, string>("GameId", createGameId)
        //        });

        //        var response = await httpClient.PostAsync(PlayGameUri, bodyData);
        //        if (!response.IsSuccessStatusCode)
        //        {
        //            this.results.AppendText(response.StatusCode + " " + response.Content.ReadAsStringAsync().Result);
        //            this.results.AppendText("Command has finished");
        //        }
        //        else
        //        {
        //            var game = response.Content.ReadAsStringAsync().Result;
        //            this.results.AppendText("Command has finished");
        //        }
        //    }
        //}

        //private object GetPlayGameInfo()
        //{
        //    PlayGameInfo
        //}

        //class PlayGameInfo
        //{
        //    public string AccessToken { get; set; }

        //    public string GameId { get; set; }
        //}

        //private async void CreateGame()
        //{
        //    var httpClient = new HttpClient();

        //    using (httpClient)
        //    {
        //        httpClient = new HttpClient();
        //        Console.Write("Pleace enter access token: ");
        //        var accessToken = ReadLine();

        //        httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("Bearer " + accessToken);

        //        var response = await httpClient.PostAsync(CreateGameUri, null);
        //        if (!response.IsSuccessStatusCode)
        //        {
        //            this.results.AppendText(response.StatusCode + " " + response.Content.ReadAsStringAsync().Result);
        //            this.results.AppendText("Command has finished");
        //        }
        //        else
        //        {
        //            var game = response.Content.ReadAsStringAsync();
        //            Console.WriteLine("Game created with Id: {0}", game.Id);
        //            this.results.AppendText("Command has finished");
        //        }
        //    }
        //}

        //private async void LoginUser()
        //{
        //    var httpClient = new HttpClient();

        //    using (httpClient)
        //    {
        //        Console.Write("Pleace enter the username that you want to login: ");
        //        var username = Console.ReadLine();
        //        Console.Write("Pleace enter the password of the username: ");
        //        var password = Console.ReadLine();

        //        var bodyData = new FormUrlEncodedContent(new[]
        //        {
        //            new KeyValuePair<string, string>("Username", username),
        //            new KeyValuePair<string, string>("Password", password),
        //            new KeyValuePair<string, string>("grant_type", "password")
        //        });

        //        var response = await httpClient.PostAsync(LoginUserUri, bodyData);
        //        if (!response.IsSuccessStatusCode)
        //        {
        //            this.results.AppendText(response.StatusCode + " " + response.Content.ReadAsStringAsync().Result);
        //            this.results.AppendText("Command has finished");
        //        }
        //        else
        //        {
        //            var post = await response.Content.ReadAsAsync<PostDTO>();
        //            Console.WriteLine("Logged in with Username: {0};\nWith access_token: {1}", post.Username, post.Access_Token);
        //            this.results.AppendText("Command has finished");
        //        }
        //    }
        //}

        private void RegisterUser()
        {
            var httpClient = new HttpClient();

            var regInfo = GetRegistrationInformation();

            using (httpClient)
            {
                var bodyData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Email", regInfo.Email),
                    new KeyValuePair<string, string>("Password", SecureStringToString(regInfo.Passwod)),
                    new KeyValuePair<string, string>("ConfirmPassword", SecureStringToString(regInfo.Passwod))
                });

                var response = httpClient.PostAsync(RegisterUserUri, bodyData).Result;
                if (!response.IsSuccessStatusCode)
                {
                    this.results.AppendText(response.StatusCode + " " + response.Content.ReadAsStringAsync().Result + "\n");
                    this.results.AppendText("Command has finished");
                }
                else
                {
                    this.results.AppendText("Account successfully created\n");
                    this.results.AppendText("Command has finished");
                }
            }
        }

        public string SecureStringToString(SecureString value)
        {
            IntPtr valuePtr = IntPtr.Zero;

            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }

        private RegistrationInfo GetRegistrationInformation()
        {
            RegisterUser regForm = new RegisterUser();
            RegistrationInfo regInfo = new RegistrationInfo();

            regForm.ShowDialog();

            if (regForm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (regForm.Password.Length > 0)
                {
                    foreach (var c in regForm.Password.ToCharArray())
                    {
                        regInfo.Passwod.AppendChar(c);
                    }
                }

                regInfo.Email = regForm.EmailText;
            }

            return regInfo;
        }

        //private async void JoinGame()
        //{
        //    var httpClient = new HttpClient();

        //    using (httpClient)
        //    {
        //        httpClient = new HttpClient();
        //        Console.Write("Pleace enter access token: ");
        //        var accessToken = ReadLine();
        //        Console.Write("Pleace enter game identity number: ");
        //        var gameId = ReadLine();

        //        httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("Bearer " + accessToken);

        //        var bodyData = new FormUrlEncodedContent(new[]
        //        {
        //            new KeyValuePair<string, string>("GameId", gameId)
        //        });

        //        var response = await httpClient.PostAsync(JoinGameUri, bodyData);
        //        if (!response.IsSuccessStatusCode)
        //        {
        //            Console.WriteLine(response.StatusCode + " " + response.Content.ReadAsStringAsync().Result);
        //            this.results.AppendText("Command has finished");
        //        }
        //        else
        //        {
        //            var game = response.Content.ReadAsStringAsync();
        //            Console.WriteLine("Game joined with Id {0}", game.Id);
        //            this.results.AppendText("Command has finished");
        //        }
        //    }
        //}

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
