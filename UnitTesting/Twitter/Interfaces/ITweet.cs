using System;
using System.Collections.Generic;
using System.Text;

namespace Twitter.Interfaces
{
    interface ITweet
    {
        void ReceiveMessage(string message);
    }
}
