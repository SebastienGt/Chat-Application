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
        //Thread ctThread;
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
            //ctThread = new Thread(getMessage);
            //ctThread.Start();
        }
        /*public void getMessage()
        {
            try
            {
                while (true)
                {
                    byte[] inStream = new byte[10025];
                    serverStream.Read(inStream, 0, inStream.Length);

                    if (!SocketConnected(clientSocket))
                    {
                        MessageBox.Show("You've been Disconnected");
                        indicator.BackColor = Color.Red;
                        ctThread.Abort();
                        clientSocket.Close();
                        //btnConnect.Enabled = true;
                    }
                    
                    List<string> parts = (List<string>)ByteArrayToObject(inStream);
                    MessageBox.Show(parts[0]);

                    if (parts.Count >= 3)
                    {
                        if (parts[2].Equals(friend))
                        {
                            setHistory(parts[3]);
                        }
                    }

                    if (parts[0].Equals('\0'))
                    {
                        setHistory("Client Left");
                        MessageBox.Show("Client left");
                        ctThread.Abort();
                        clientSocket.Close();
                        break;
                    }
                    parts.Clear();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("FormPrivate exception l80 " + e);
                indicator.BackColor = Color.Red;
                ctThread.Abort();
                clientSocket.Close();
                //btnConnect.Enabled = true;
            }
        }
        */
        /*
        bool SocketConnected(TcpClient s) //check whether client is connected server
        {
            bool flag = false;
            try
            {
                bool part1 = s.Client.Poll(10, SelectMode.SelectRead);
                bool part2 = (s.Available == 0);
                if (part1 && part2)
                {
                    indicator.BackColor = Color.Red;
                    this.Invoke((MethodInvoker)delegate // cross threads
                    {
                        //btnConnect.Enabled = true;
                    });
                    flag = false;
                }
                else
                {
                    indicator.BackColor = Color.Green;
                    flag = true;
                }
            }
            catch (Exception er)
            {
                Console.WriteLine(er);
            }
            return flag;
        }*/

        public void setHistory(String message)
        {
            this.Invoke((MethodInvoker)delegate // To Write the Received data
            {
                history.Text = history.Text + Environment.NewLine + friend + " : " + message;
            });
        }
        private void history_TextChanged(object sender, EventArgs e)
        {
            history.SelectionStart = history.TextLength;
            history.ScrollToCaret();
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
