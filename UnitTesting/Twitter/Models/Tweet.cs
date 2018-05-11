﻿using System;
using System.Collections.Generic;
using System.Text;
using Twitter.Interfaces;

namespace Twitter.Models
{
   public class Tweet : ITweet
    {
        private IClient client;

        public Tweet(IClient client)
        {
            this.client = client;
        }

        public void ReceiveMessage(string message)
        {
            this.client.WriteTweet(message);
            this.client.SendTweetToServer(message);
        }
    }
}
