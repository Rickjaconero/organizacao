using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Organizacao
{
    class TweetRetorno
    {
        public int id_tweet { get; set; }

        public String mensagem { get; set; }

        public String data { get; set; }

        public String pais { get; set; }

        public String hashtags { get; set; }

        public TweetRetorno()
        {

        }

        public void AddTweet(TweetRetorno newTweetRetorno)
        {
            var json = File.ReadAllText("arquivoDados.txt");
            var tweets = JsonConvert.DeserializeObject<List<TweetRetorno>>(json);
            tweets.Add(newTweetRetorno);
            File.WriteAllText("arquivoDados.txt", JsonConvert.SerializeObject(tweets));
        }
        /*
        public TweetRetorno GetTweet(string id)
        {
            var json = File.ReadAllText("arquivoDados.txt");
            var tweets = JsonConvert.DeserializeObject<List<TweetRetorno>>(json);
            var result = new TweetRetorno();
            foreach (var c in tweets)
            {
                if (c.id_tweet = id)
                {
                    result = c;
                    break;
                }
            }
            return result;
        }
        
        public int store(string[] reservation)
        {
            JObject tweet = new JObject(
                new JProperty("id", ),
                new JProperty("name", reservation[0]),
                new JProperty("address", reservation[1]),
                new JProperty("gender", reservation[2]),
                new JProperty("age", reservation[3])
            );

            using (StreamWriter file = File.CreateText(Settings.databasePath + "customer.json"))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                tweet.WriteTo(writer);
            }

            return 1;
        }
        */
    }
}
