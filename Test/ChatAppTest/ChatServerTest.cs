using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChatServer;
namespace ChatAppTest
{
    [TestClass]
    public class ChatServerTest
    {
        [TestMethod]
        public void ServerCommandTestOnSuccess()
        {
            String command = "\\start";
            ServerHandler server = new ServerHandler();
            try
            {
                server.commandWorker(command);
            }
            catch (Exception e) {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ServerCommandTestOnError()
        {
            String command = "\\blabla";
            ServerHandler server = new ServerHandler();
            try
            {
                server.commandWorker(command);
                Assert.Fail();
            }
            catch (Exception e)
            {

            }
        }

        [TestMethod]
        public void ServerRunCommand() {
            bool expected = true;
            ServerHandler handler = new ServerHandler();

            Assert.AreEqual(expected,handler.runServerForWork());
        }
    }
}
