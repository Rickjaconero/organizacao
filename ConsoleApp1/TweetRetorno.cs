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
        public String id_tweet { get; set; }

        public String mensager { get; set; }

        public String user_id { get; set; }

        public String user { get; set; }

        public String hashtags { get; set; }


        public TweetRetorno()
        {

        }

        public String toString()
        {
            String mensagem = String.Empty;
            mensagem += this.id_tweet.ToString();
            mensagem += this.mensager;
            mensagem += this.user_id.ToString();
            mensagem += this.user;
            mensagem += this.hashtags;
            return mensagem;
        }
    }
}
