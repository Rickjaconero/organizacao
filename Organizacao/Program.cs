using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.IO;
using Tweetinvi;
using Autofac;
using Newtonsoft.Json;
using Nito.AsyncEx;
using Tweetinvi.Parameters;
using Tweetinvi.Models;
using Newtonsoft.Json.Linq;
using Organizacao;
using Tweetinvi.Core.Events;

namespace Organizacao
{
    class Program
    {


        static void Main(string[] args)
        {
            Auth.SetUserCredentials("TXlcjpRTbZEgmkoxNT2oqCfeX", "C5BzmoaPbLSoZ8De8qej7aSb0OCz0f2MlouLybtDdY5freEhNN", "97486111-ySo0byQk5B1KXHRMSNMTUABulYn4VRb1nC0aCNHgS", "ixkpMxe6dMMOhL4lKF5yFVgWbnleB8KtO0tJruqkV0EbI");
            var authUser = User.GetAuthenticatedUser();
            var settings = authUser.GetAccountSettings();
            var matchingTweets = Search.SearchTweets("Libertadores").ToJson();

            var test = String.Empty;

            //inserir no fim do arquivo
            if (File.Exists(@"Dados.json"))
            {
                test = File.ReadAllText(@"Dados.json");
            }
            File.WriteAllText(@"Dados.json", test + Environment.NewLine + matchingTweets);
            Console.WriteLine("inseriu no fim do arquivo");

            /*
            var searchParameter = new SearchTweetsParameters("Libertadores")
            {
                MaximumNumberOfResults = 100,
                SearchType = SearchResultType.Recent
            };
            */
            TweetRetorno tweetJson;

            var test2 = String.Empty;
            //metodo 3 mlr ate agora
            JArray a = JArray.Parse(matchingTweets);
            var c = a.Count;
            var i = 0;
            while (c > 0)
            {
                // Console.ReadLine();//pause
                tweetJson = new TweetRetorno();
                tweetJson.id_tweet = a[i]["id_str"].ToString().PadRight(19, ' ');
                tweetJson.mensager = a[i]["full_text"].ToString().PadRight(300, ' ');
                tweetJson.user_id = a[i]["user"]["id_str"].ToString().PadRight(18, ' ');
                tweetJson.user = a[i]["user"]["screen_name"].ToString().PadRight(20, ' ');
                if (File.Exists(@"Data.txt"))
                {
                    test2 = File.ReadAllText(@"Data.txt");
                }
                String mensagem = String.Empty;
                mensagem += tweetJson.id_tweet.ToString();
                mensagem += tweetJson.mensager;
                mensagem += tweetJson.user_id.ToString();
                mensagem += tweetJson.user;

                Console.WriteLine(mensagem);


                File.WriteAllText(@"Data.txt", test2 + Environment.NewLine + mensagem);
                c--;
                i++;
            }

            Console.WriteLine(a.GetType());
        }

    }
}
