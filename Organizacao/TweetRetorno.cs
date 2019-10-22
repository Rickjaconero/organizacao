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

        public TweetRetorno()
        {

        }
    }
}