using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatApp
{
    public class Client
    {
        private String host;
        private String username;
        private int port;
        private Socket socket;
        private bool connected = false;
        private ChatForm frm;


        public String Login { get => username; set => username = value; }
        public int Port { get => port; set => port = value; }
        public String Host { get => host; set => host = value; }
        public Socket Socket { get => socket; set => socket = value; }
        public bool isConnected { get => connected; }

        public Client(String host, int port, ChatForm form)
        {
            this.host = host;
            this.port = port;
            this.frm = form;
        }

        public bool connect() {
            try
            {
                if (socket == null) socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(host,port);
                connected = true;
                return true;
            }
            catch
            {
                connected = false;
                return false;
            }
        }

        public bool disconnect() {
            try
            {
                sendMessage("/User/Disconnect");
                connected = false;
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch { return false; }
            return true;
        }


        public void sendMessage(String msg) {
            try{socket.Send(Encoding.Unicode.GetBytes(msg));}
            catch { }
        }

        public String messageListener()
        {
            String res = "";
            StringBuilder builder = new StringBuilder();
            int messagebytes;
            byte[] getbytes = new byte[256];
            while (true)
            {
                do
                {
                    try
                    {
                        messagebytes = socket.Receive(getbytes);
                        builder.Append(Encoding.Unicode.GetString(getbytes, 0, messagebytes));
                    }
                    catch (Exception e) {
                        break;
                    }
                } while (socket.Available > 0);

                res = builder.ToString();
                builder.Clear();
                return res;
            }
        }


    }
}
