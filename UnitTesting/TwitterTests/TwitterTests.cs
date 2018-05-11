using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Twitter.Interfaces;
using Twitter.Models;

namespace TwitterTests
{
    [TestFixture]
    class TwitterTests
    {
        [Test]
        public void SendTweetToServerShouldSendTheMessageToItsServer()
        {
            string test = "Test";
            var serverMock = new  Mock<IServer>();
            serverMock.Setup(s => s.SaveTweet(test));
            var microvawe = new MicrowaveOven(serverMock.Object);
            microvawe.SendTweetToServer(test);

            serverMock.Verify(tr => tr.SaveTweet(It.Is<string>(s => s == test)),
              Times.Once);
        }


        [Test]
        public void ReceiveMessageShouldInvokeItsClientToWriteTheMessage()
        {
            
            var client = new Mock<IClient>();
            client.Setup(c => c.WriteTweet(It.IsAny<string>()));
            var tweet = new Tweet(client.Object);

            
            tweet.ReceiveMessage("Test");

           
            client.Verify(c => c.WriteTweet(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void ReceiveMessageShouldInvokeItsClientToSendTheMessageToTheServer()
        {
            
            var client = new Mock<IClient>();
            client.Setup(c => c.SendTweetToServer(It.IsAny<string>()));
            var tweet = new Tweet(client.Object);

            
            tweet.ReceiveMessage("Test");

            
            client.Verify(c => c.SendTweetToServer(It.IsAny<string>()), Times.Once);
        }

    }
}
