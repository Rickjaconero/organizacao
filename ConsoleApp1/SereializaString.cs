using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;


namespace Organizacao
{
    class SerializaString
    {
        List<TweetRetorno> lista;
        TweetRetorno tweetJson;

        public void insereJson(String matchingTweets)
        {
            var stringDeJson = String.Empty;
            if (File.Exists(@"Dados.json"))
            {
                stringDeJson = File.ReadAllText(@"Dados.json");
            }
            File.WriteAllText(@"Dados.json", stringDeJson + Environment.NewLine + matchingTweets);
            return;
        }

        public void dadosPeloJson()
        {
            string[] stringDeJson = null;
            int count = 0;

            if (File.Exists(@"teste1.json"))
            {
                stringDeJson = File.ReadAllLines(@"teste1.json");
                while (count < 100)
                {
                    JArray arrayDeJSon = JArray.Parse(stringDeJson[count]);
                    var c = arrayDeJSon.Count;
                    var i = 0;
                    while (c > 0)
                    {
                        //Console.WriteLine(i +" c = " +c);
                        tweetJson = new TweetRetorno();
                        /*
                        tweetJson.id_tweet = arrayDeJSon[i]["id_str"].ToString().Replace("\n", "  ").PadRight(19, ' ');
                        byte[] bytes = Encoding.Default.GetBytes(tweetJson.id_tweet);
                        tweetJson.id_tweet = Encoding.UTF8.GetString(bytes);
                        Console.WriteLine(tweetJson.id_tweet.Length);

                        tweetJson.mensager = arrayDeJSon[i]["full_text"].ToString().Replace("\n", "");
                        Console.WriteLine(tweetJson.mensager);
                        Console.WriteLine(tweetJson.mensager.Length);
                        bytes = Encoding.Default.GetBytes(tweetJson.mensager);
                        Console.WriteLine(bytes);
                        tweetJson.mensager = Encoding.UTF8.GetString(bytes).PadRight(526, ' ');
                        Console.WriteLine(tweetJson.mensager);
                        Console.WriteLine(tweetJson.mensager.Length);

                        tweetJson.mensager = Regex.Replace(tweetJson.mensager, @"\p{Cs}", " ");
                        Console.WriteLine(tweetJson.mensager);
                        Console.WriteLine(tweetJson.mensager.Length);


                        tweetJson.user_id = arrayDeJSon[i]["user"]["id_str"].ToString().Replace("\n", "  ").PadRight(19, ' ');
                        bytes = Encoding.Default.GetBytes(tweetJson.user_id);
                        tweetJson.user_id = Encoding.UTF8.GetString(bytes);
                        Console.WriteLine(tweetJson.user_id.Length);

                        tweetJson.user = arrayDeJSon[i]["user"]["screen_name"].ToString().Replace("\n", "  ").PadRight(20, ' ');
                        bytes = Encoding.Default.GetBytes(tweetJson.user);
                        tweetJson.user = Encoding.UTF8.GetString(bytes);
                        Console.WriteLine(tweetJson.user.Length);
                        */
                        tweetJson.hashtags = arrayDeJSon[i]["entities"]["hashtags"].ToString();
                        Console.WriteLine(tweetJson.hashtags);

                        lista.Add(tweetJson);
                        //Console.ReadLine();
                        c--;
                        i++;
                        count++;
                    }
                }
            }
            return;
        }


        public void insereNaLsita(String matchingTweets)
        {
            lista = new List<TweetRetorno>();
            JArray arrayDeJSon = JArray.Parse(matchingTweets);
            var c = arrayDeJSon.Count;
            var i = 0;
            while (c > 0)
            {
                //Console.WriteLine(i +" c = " +c);
                tweetJson = new TweetRetorno();

                tweetJson.id_tweet = arrayDeJSon[i]["id_str"].ToString().Replace("\n", "  ").PadRight(19, ' ');
                byte[] bytes = Encoding.Default.GetBytes(tweetJson.id_tweet);
                tweetJson.id_tweet = Encoding.UTF8.GetString(bytes);
                Console.WriteLine(tweetJson.id_tweet.Length);

                tweetJson.mensager = arrayDeJSon[i]["full_text"].ToString().Replace("\n", "");
                Console.WriteLine(tweetJson.mensager);
                Console.WriteLine(tweetJson.mensager.Length);
                bytes = Encoding.Default.GetBytes(tweetJson.mensager);
                Console.WriteLine(bytes);
                tweetJson.mensager = Encoding.UTF8.GetString(bytes).PadRight(526, ' ');
                Console.WriteLine(tweetJson.mensager);
                Console.WriteLine(tweetJson.mensager.Length);

                tweetJson.mensager = Regex.Replace(tweetJson.mensager, @"\p{Cs}", " ");
                Console.WriteLine(tweetJson.mensager);
                Console.WriteLine(tweetJson.mensager.Length);


                tweetJson.user_id = arrayDeJSon[i]["user"]["id_str"].ToString().Replace("\n", "  ").PadRight(19, ' ');
                bytes = Encoding.Default.GetBytes(tweetJson.user_id);
                tweetJson.user_id = Encoding.UTF8.GetString(bytes);
                Console.WriteLine(tweetJson.user_id.Length);

                tweetJson.user = arrayDeJSon[i]["user"]["screen_name"].ToString().Replace("\n", "  ").PadRight(20, ' ');
                bytes = Encoding.Default.GetBytes(tweetJson.user);
                tweetJson.user = Encoding.UTF8.GetString(bytes);
                Console.WriteLine(tweetJson.user.Length);

                lista.Add(tweetJson);
                //Console.ReadLine();
                c--;
                i++;
            }
            return;
        }

        public void puxaLista()
        {
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(@"Data.txt");
                lista = new List<TweetRetorno>();
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    tweetJson = new TweetRetorno();
                    tweetJson.id_tweet = line.Substring(0, 19);
                    //Console.WriteLine(tweetJson.id_tweet.Length);
                    tweetJson.mensager = line.Substring(19, 526);
                    //Console.WriteLine(tweetJson.mensager.Length);
                    tweetJson.user_id = line.Substring(545, 19);
                    //Console.WriteLine(tweetJson.user_id.Length);
                    tweetJson.user = line.Substring(564, 20);
                    //Console.WriteLine(tweetJson.user.Length);
                    //Console.ReadLine();
                    lista.Add(tweetJson);
                }
                file.Close();
            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine("Arquivo nao encontrado");
            }
            return;
        }

        public void ordenaLista()
        {
            lista.Sort(delegate (TweetRetorno t1, TweetRetorno t2) { return t1.id_tweet.CompareTo(t2.id_tweet); });
            lista.ForEach(delegate (TweetRetorno t)
            { //Console.WriteLine(t.toString());
            });
            return;
        }

        public void pesquisaIndice(long valor)//tem q troca e fazer binaria direto
        {
            try
            {
                var fileStream = new FileStream(@"DataIndice.txt", FileMode.Open, FileAccess.Read);
                using (var streamReader = new System.IO.StreamReader(@"DataIndice.txt", Encoding.UTF8))
                {
                    string str;
                    long num;
                    int posicao;
                    while ((str = streamReader.ReadLine()) != null)
                    {
                        num = long.Parse(str.Substring(0, 19));
                        posicao = int.Parse(str.Substring(20, 10));
                        if (num == valor)
                        {
                            Console.WriteLine("achou no indice");
                            Console.WriteLine("numero = " + num);
                        }
                        else
                        {
                            Console.WriteLine("nao achou no indice");
                        }
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Arquivo nao encontrado");
            }
        }


        public bool pesquisaSequencial(long valor)
        {
            try
            {
                string[] str1 = File.ReadAllLines(@"Data.txt");
                int tamlin = 586;
                int linhas = (str1.Length / tamlin);
                //Console.WriteLine("str = " + str.Length + " tamlin = " + tamlin + " linhas = " + linhas);
                //Console.ReadLine();
                foreach (string linha in str1)
                {
                    long num;
                    num = long.Parse(linha.Substring(0, 19));
                    Console.WriteLine("Comparou valor = " + valor + " com numero = " + num);
                    if (valor == num)
                    {
                        Console.WriteLine("achou");
                        Console.WriteLine(linha);
                        return true;
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Arquivo nao encontrado");
            }
            return false;
        }

        public long pesquisaBinaria(long valor)
        {
            try
            {
                string[] str = File.ReadAllLines(@"Data.txt");
                int tam = str.Length;
                int inf = 0;
                int sup = tam;
                int meio = sup / 2;
                Console.WriteLine("tam = " + tam + " inferio = " + inf + " superior = " + sup);
                while (inf < sup)
                {
                    Console.WriteLine("tam = " + tam + " inferio = " + inf + " superior = " + sup);
                    Console.WriteLine("meio de linha = " + meio);
                    int soma = inf + sup;
                    meio = (soma / 2);
                    if ((soma % 2) == 0)
                    {
                        meio++;
                    }
                    long num;
                    num = long.Parse(str[meio].Substring(0, 19));
                    Console.ReadLine();
                    Console.WriteLine("Comparou valor = " + valor + " com numero = " + num);
                    if (valor == num)
                    {
                        Console.WriteLine("achou");
                        return meio;
                    }
                    if (valor < num)
                    {
                        Console.WriteLine("menor");
                        sup = meio - 1;
                    }
                    else
                    {
                        Console.WriteLine("maior");
                        inf = meio - 1;
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Arquivo nao encontrado");
            }
            Console.WriteLine("nao achou");
            return -1;
        }

        public void insereArquivoDados()
        {
            int tam = lista.Count;
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"Data.txt");
            for (int i = 0; i < tam; i++)
            {
                file.WriteLine(lista[i].toString());
                Console.WriteLine(lista[i].toString().Length);
                //Console.ReadLine();
                //Console.WriteLine(i);
            }
            file.Close();
            return;
        }


        public void insereArquivoDadosIndice()
        {
            this.puxaLista();
            this.ordenaLista();
            int tam = lista.Count;
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"DataIndice.txt");
            for (int i = 1; i <= tam; i += 10)
            {
                file.WriteLine(lista[i - 1].id_tweet + i.ToString().PadLeft(6, '0').PadLeft(10));
                //Console.WriteLine(i);
            }
            file.Close();
        }

        private List<string> arquivoParaLista()
        {
            string line;
            List<String> organiza = new List<String>();

            System.IO.StreamReader file = new System.IO.StreamReader(@"Data.txt");
            while ((line = file.ReadLine()) != null)
            {
                organiza.Add(line);
            }

            file.Close();
            return organiza;
        }

    }
}
