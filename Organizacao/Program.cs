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
using Nancy.Json;
using Nancy.Json.Simple;
using RestSharp;
using Tweetinvi.Core.Events;

namespace ConsoleApp1
{
    class Program
    {
        private TweetRetorno t;
       

        static void Main(string[] args)
        {
            Auth.SetUserCredentials("TXlcjpRTbZEgmkoxNT2oqCfeX", "C5BzmoaPbLSoZ8De8qej7aSb0OCz0f2MlouLybtDdY5freEhNN", "97486111-ySo0byQk5B1KXHRMSNMTUABulYn4VRb1nC0aCNHgS", "ixkpMxe6dMMOhL4lKF5yFVgWbnleB8KtO0tJruqkV0EbI");
            var authUser = User.GetAuthenticatedUser();
            var settings = authUser.GetAccountSettings();
            var matchingTweets = Search.SearchTweets("Libertadores").ToJson();
            var lista = matchingTweets[1];
            Console.WriteLine(lista);

            var test = String.Empty;

            //inserir no fim do arquivo
            if (File.Exists(@"Dados.json"))
            {
                test = File.ReadAllText(@"Dados.json");
            }
            File.WriteAllText(@"Dados.json",test + Environment.NewLine + matchingTweets);
            Console.WriteLine("inseriu no fim do arquivo");    

            //metodo 3 
            JArray a = JArray.Parse(matchingTweets);
            var c = a.Count;
            var i = 0;
            while (c > 0)
            {
                //ta pulando de 2 em 2
                Console.WriteLine("O valor de c eh = " + c.ToString());
                Console.WriteLine("O valor de i eh = " + i.ToString());

                Console.ReadLine();//pause

 
                Console.WriteLine(a[i]["id"].ToString());

                //Console.WriteLine(a.);
                c--;
                i++;
            }
           
            Console.WriteLine(a.GetType());
            





        }



    }
}
