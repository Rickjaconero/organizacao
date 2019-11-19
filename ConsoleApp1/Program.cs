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

            SerializaString s = new SerializaString();

            int opcao;
            long valor;
            do
            {
                Console.WriteLine("Digite uma Opcao:");
                Console.WriteLine("1 - Buscar tweets:");
                Console.WriteLine("2 - Pesquisar sequencial:");
                Console.WriteLine("3 - Pesquisa binaria:");
                Console.WriteLine("4 - Gerar indice sequencial");
                Console.WriteLine("5 - Pesquisa no arquivo de indice");
                Console.WriteLine("6 - Dados pelo Json");
                Console.WriteLine("0 - Sair");

                opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("1 - buscando tweets:");
                        s.insereJson(matchingTweets);
                        s.insereNaLsita(matchingTweets);
                        s.puxaLista();
                        s.ordenaLista();
                        s.insereArquivoDados();
                        break;
                    case 2:
                        Console.WriteLine("2 - pesquisar sequencial:");
                        Console.WriteLine("digite o valor:");
                        valor = long.Parse(Console.ReadLine());
                        s.pesquisaSequencial(valor);
                        break;
                    case 3:
                        Console.WriteLine("3 - pesquisa binaria:");
                        Console.WriteLine("digite o valor:");
                        valor = long.Parse(Console.ReadLine());
                        s.pesquisaBinaria(valor);
                        break;

                    case 4:
                        Console.WriteLine("4 - Gerar indice sequencial");
                        s.insereArquivoDadosIndice();
                        break;
                    case 5:
                        Console.WriteLine("5 - Pesquisa no arquivo de indice");
                        Console.WriteLine("digite o valor:");
                        valor = long.Parse(Console.ReadLine());
                        s.pesquisaIndice(valor);
                        break;
                    case 6:
                        Console.WriteLine("Salva dados do json em arquivo");
                        s.dadosPeloJson();
                        break;
                }
            } while (opcao != 0);
            Console.WriteLine("Saiu");
        }
    }
}
