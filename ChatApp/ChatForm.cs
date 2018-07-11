using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp
{
    public partial class ChatForm : Form
    {
        private String message;
        private Client client;
        public ChatForm()
        {
            InitializeComponent();
            
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            if (client != null)
            {
                if (client.isConnected) {
                    if (client.disconnect())
                    {
                        authMenuItem.Visible = false;
                        messageWaiter.CancelAsync();
                        client = null;
                        connectBtn.Text = "Connect";
                    }
                    else {
                        MessageBox.Show("Ошибка при отключении от сервера", "Ошибка", MessageBoxButtons.OK);
                    }
                    
                }
            }
            else
            {
                if (hostTextBox.Text.Equals("") || int.Parse(portNumBox.Text) == 0)
                {
                    MessageBox.Show("Обязательно введите Host и Port!", "Ошибка", MessageBoxButtons.OK);
                }
                else
                {
                    try
                    {
                        client = new Client(hostTextBox.Text, int.Parse(portNumBox.Text),this);
                        client.connect();
                        authMenuItem.Visible = true;
                        connectBtn.Text = "Disconnect";

                        messageWaiter.RunWorkerAsync();
                    }
                    catch {}
                }
            }
        }

        private void sendMsgBtn_Click(object sender, EventArgs e)
        {
            client.sendMessage("/msg|" + msgTextBox.Text);
            msgTextBox.Clear();
        }

        private void messageWaiter_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true) {
                if (!e.Cancel) { try { message = client.messageListener(); messageWaiter.ReportProgress(10); } catch { }}
            }
        }

        private void messageWaiter_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 10) {
                if (message.StartsWith("Server:"))
                {
                    if (chatBox.Text.Equals(""))
                    {
                        chatBox.Text = message;
                    }
                    else
                    {
                        chatBox.Text = chatBox.Text + "\n" + message;
                    }
                }
                else
                {
                    
                }
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                client.Login = loginTextBox.Text;
                client.sendMessage("/User/Auth|" + loginTextBox.Text + "," + passTextBox.Text);
            }
            catch { }
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            authMenuItem.Visible = false;
        }
    }
}
