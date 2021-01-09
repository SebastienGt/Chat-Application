using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Communication;

namespace Client
{
    public partial class FormTopic : Form
    {
        TcpClient clientSocket = new TcpClient();
        List<string> users = new List<string>();
        NetworkStream serverStream = default(NetworkStream);
        List<string> chat = new List<string>();
        Method methods = new Method();
        string topicName;
        string name;

        public FormTopic()
        {
            InitializeComponent();
        }
        public FormTopic(string topicName, TcpClient c, String name)
        {
            InitializeComponent();
            clientSocket = c;
            this.topicName = topicName;
            this.name = name;

            serverStream = clientSocket.GetStream();
        }

        private void Send_Click(object sender, EventArgs e)
        {
            
        }

        private void Send_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!input.Text.Equals(""))
                {
                    chat.Clear();
                    chat.Add("pTopic");
                    chat.Add(topicName);
                    chat.Add(name);
                    chat.Add(input.Text);

                    byte[] outStream = methods.ObjectToByteArray(chat);

                    serverStream.Write(outStream, 0, outStream.Length);
                    serverStream.Flush();
                    chat.Clear();
                    this.Invoke((MethodInvoker)delegate // To Write the Received data
                    {
                        input.Text = "";
                    });
                }
            }
            catch (Exception er)
            {

            }
        }
        public void setHistory(string usersent, String message)
        {
            this.Invoke((MethodInvoker)delegate // To Write the Received data
            {
                history.Text = history.Text + Environment.NewLine + usersent + " : " + message;
            });
        }

        private void history_TextChanged(object sender, EventArgs e)
        {
            history.SelectionStart = history.TextLength;
            history.ScrollToCaret();
        }
    }
}
