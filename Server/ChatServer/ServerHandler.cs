using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatServer
{
    public class ServerHandler
    {

        private const int PORT = 8005;
        private const String SERVERIP = "127.0.0.1";
        private const int MAXCONNECTION = 10;
        private Socket socket;
        private IPEndPoint ipPoint;
        private List<Client> clientList;
        private bool waitcli = true;
        public ServerHandler() {
            clientList = new List<Client>();
        }

        public void commandWorker(String command)
        {
            switch (command)
            {
                case "/start":
                    if (runServerForWork())
                    {
                        Console.WriteLine("Сервер запущен! Ожидание подключения...");
                        connectionListener();
                    }
                    else {
                        Console.WriteLine("Ошибка при запуске сервера!");
                    }
                    break;
                case "/exit":
                    stopServer();
                    break;
                default:
                    throw new CommandException("Command not in list!");
            }
        }

        public void messageWorker(Socket soc,String message, bool auth)
        {
            String cmd = message.Split('|')[0];
            switch (cmd)
            {
                case "/User/Disconnect":
                    disconnect(soc);
                    break;
                case "/User/Auth":
                    authorize(soc, message);
                    break;
                case "/msg":
                    clientList.ForEach(cli =>
                    {
                        if (cli.Socket == soc) {
                            sendMessageToAll(cli.Login + " (" + DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToLocalTime() + "): " + message.Split('|')[1]);
                        }
                    });
                    break;
            }
        }

#region "WorkControl"
        private bool runServerForWork() {
            try
            {
                if (ipPoint == null)ipPoint = new IPEndPoint(IPAddress.Parse(SERVERIP), PORT);
                if (socket == null) socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(ipPoint);
                socket.Listen(MAXCONNECTION);
                return true;
            }
            catch {
                return false;
            }
        }

        private bool stopServer() {
            try
            {
                waitcli = false;
                clientList.ForEach(cli => { if (disconnect(cli.Socket)) clientList.Remove(cli); });
            }
            catch {
                return false;
            }
            return true;
        }
        #endregion

#region "ConnectionControl"
        private void connectionListener() {
            Thread conThread = new Thread(new ThreadStart(listenThreadFunction));
            conThread.Start();
        }

        private void listenThreadFunction() {
            while (waitcli) {
                clientList.Add(new Client(socket.Accept(), this));
                Console.WriteLine("Клиент подключился!");
            }
        }

        private bool disconnect(Socket socket)
        {
            try
            {
                clientList.ForEach(cli =>
                {
                    if (cli.Socket == socket)
                    {
                        sendMessageToAll("Server:Пользователь " + cli.Login + " отключился");
                        Console.WriteLine(cli.UserName + " отключен!");
                    }
                });
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        #endregion

        #region "sendMessages"
        public bool sendMessage(Socket socket, String message) {
            try
            {
                Byte[] data = Encoding.Unicode.GetBytes(message);
                socket.Send(data);
            }
            catch {
                return false;
            }
            return true;
        }

        private bool sendMessageToAll(String message) {
            try
            {
                clientList.ForEach(cli => sendMessage(cli.Socket, message));
            }
            catch {
                return false;
            }
            return true;
        }

        private bool authorize(Socket socket, String msg) {
            String login = msg.Split('|')[1].Split(',')[0];
            String pass = msg.Split('|')[1].Split(',')[1];
            try
            {
                clientList.ForEach(cli => {
                    if (cli.Socket == socket){
                        cli.Login = login;
                        cli.Password = pass;
                        cli.Auth = true;
                    }
                });
            }
            catch { return false; }
            sendMessage(socket, "Server:Авторизация прошла успешно!");
            sendMessageToAll("Новый пользователь - " + login);
            return true;
        }
#endregion

    }
}
