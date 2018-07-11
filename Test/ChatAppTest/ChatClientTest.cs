using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChatServer;
using ChatApp;
namespace ChatAppTest
{
    [TestClass]
    public class ChatClientTest
    {
        [TestMethod]
        public void connectionTest()
        {
            bool expected = true;
            ServerHandler server = new ServerHandler();
            server.runServerForWork();

            Client client = new Client();


        }
    }
}
