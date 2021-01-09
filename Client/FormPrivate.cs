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

using System.IO;

namespace Client
{
    public partial class FormPrivate : Form
    {
        TcpClient clientSocket = new TcpClient();
        String friend, myName;
        NetworkStream serverStream = default(NetworkStream);
        List<string> chat = new List<string>();
        Method methods = new Method();


        public FormPrivate()
        {
            InitializeComponent();
        }
        public FormPrivate(String friend, TcpClient c, String name)
        {
            InitializeComponent();
            clientSocket = c;
            this.friend = friend;
            this.myName = name;

            serverStream = clientSocket.GetStream();
        }
        public void setHistory(String message)
        {
            this.Invoke((MethodInvoker)delegate // To Write the Received data
            {
                history.Text = history.Text + Environment.NewLine + friend + " : " + message;
            });
        }

        private void history_TextChanged_1(object sender, EventArgs e)
        {
            history.SelectionStart = history.TextLength;
            history.ScrollToCaret();
        }

        private void Send_Click(object sender, EventArgs e)
        {
            try
            {
                if (!input.Text.Equals(""))
                {
                    chat.Clear();
                    chat.Add("pChat");
                    chat.Add(friend);
                    chat.Add(myName);
                    chat.Add(input.Text);

                    byte[] outStream = methods.ObjectToByteArray(chat);

                    serverStream.Write(outStream, 0, outStream.Length);
                    serverStream.Flush();
                    chat.Clear();
                    this.Invoke((MethodInvoker)delegate // To Write the Received data
                    {
                        history.Text = history.Text + Environment.NewLine + "Me : " + input.Text;
                        input.Text = "";
                    });
                }
            }
            catch (Exception er)
            {
                clientSocket.Close();
                this.Close();
            }
        }
    }
}
