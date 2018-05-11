using System;
using System.Collections.Generic;
using System.Text;
using Twitter.Interfaces;

namespace Twitter.Models
{
    public class MicrowaveOven : IClient
    {
        IServer server;
        public MicrowaveOven( IServer server)
        {
            this.server = server;
        }

        public void SendTweetToServer(string message)
        {
            this.server.SaveTweet(message);
        }

        public void WriteTweet(string message)
        {
            Console.WriteLine(message);
        }
    }
}
