using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatServer
{
    class Client
    {
        private Socket socket;
        private String login, pass, username;
        private bool authorized = false;
        private int messagebytes;
        private byte[] getbytes = new byte[256];
        private ServerHandler server;

        public Socket Socket { get => socket; set => socket = value; }
        public String UserName { get => (username == null) ? login : username; set => username = value; }
        public String Login { get => login; set => login = value; }
        public String Password { get => pass; set => pass = value; }
        public bool Auth { get => authorized; set => authorized= value; }

        public Client(Socket socket, ServerHandler server) {
            this.socket = socket;
            this.server = server;
            server.sendMessage(socket, "Server:Подключение прошло успешно!");
            Thread conThread = new Thread(new ThreadStart(messageListener));
            conThread.Start();
        }

        private void messageListener() {
            StringBuilder builder = new StringBuilder();
            while (true) {
                do {
                    messagebytes = socket.Receive(getbytes);
                    builder.Append(Encoding.Unicode.GetString(getbytes, 0, messagebytes));
                } while (socket.Available > 0);
                server.messageWorker(socket,builder.ToString(), Auth);
                if (builder.ToString().Equals("/User/Disconnect")) break;
                builder.Clear();
            }
        }


    }
}
