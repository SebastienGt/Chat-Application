using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Serialization;
using Communication;

namespace Client
{
    public partial class FormMain : Form
    {
        string name = null;
        //Dictionary<string, Object> nowChatting = new Dictionary<string, Object>();
        //List<string> nowChatting = new List<string>();
        List<string> chat = new List<string>();
        Communication.Method Methods = new Communication.Method();

        Link link;

        // On set le nom de la fenetre d'avant

        public void SetName(string title)
        {
            this.Text = title;
            name = title;
        }

        public FormMain(Link lk)
        {
            InitializeComponent();
            this.link = lk;

            link.ctThread.Abort();
            link.ctThread = new Thread(getMessage);
            link.ctThread.Start();
        }

        private void msg()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(msg));
            else
                history.Text = history.Text + Environment.NewLine + " >> " + link.readData;
        }

        public void getUsers(List<string> parts)
        {
            this.Invoke((MethodInvoker)delegate
            {
                listClients.Items.Clear();
                for (int i = 1; i < parts.Count; i++)
                {
                    ListViewItem client = new ListViewItem();
                    client.Text = parts[i];
                    listClients.Items.Add(client);
                }
            });
        }
        public void getTopics(List<string> parts)
        {
            this.Invoke((MethodInvoker)delegate
            {
                ListTopics.Items.Clear();
                for (int i = 1; i < parts.Count; i++)
                {
                    ListTopics.Items.Add(parts[i]);
                    //ListViewItem item = new ListViewItem(parts[i]);
                    //ListTopics.Items.Add(item);
                }
            });
        }

        private void getMessage()
        {
            try
            {
                while (true)
                {
                    if (!SocketConnected(link.clientSocket))
                    {
                        indicator.BackColor = Color.Red;
                        MessageBox.Show("You've been Disconnected");
                        
                        link.ctThread.Abort();
                        link.clientSocket.Close();
                    }
                    List<string> parts = link.Get();
                    
                    switch (parts[0])
                    {
                        case "userList":
                            getUsers(parts);
                            break;

                        case "topicsList":
                            getTopics(parts);
                            break;

                        case "gChat":
                            link.readData = "" + parts[1];
                            msg();
                            break;

                        case "pChat":
                            managePrivateChat(parts);
                            break;

                        case "cTopic":
                            break;

                        case "joinTopic":
                            //MessageBox.Show("jointopic dans le main c'est reussi !");
                            break;

                        case "pTopic":
                            manageTopicChat(parts);
                            break;
                    }
                    chat.Clear();
                }
            }
            catch (Exception e)
            {
                indicator.BackColor = Color.Red;
                link.ctThread.Abort();
                link.clientSocket.Close();
            }
        }
        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                link.ctThread.Abort();
                link.clientSocket.Close();
            }
            catch (Exception ee) {
                MessageBox.Show("Ferme" + ee);
            }
            Application.ExitThread();
        }
        public void managePrivateChat(List<string> parts)
        {
            this.Invoke((MethodInvoker)delegate // To Write the Received data
            {
                if (parts[3].Equals("new"))
                {
                    FormPrivate privateC = new FormPrivate(parts[2], link.clientSocket, name);
                    //nowChatting.Add(parts[2]);
                    privateC.Text = "Private Chat with " + parts[2];
                    privateC.Show();
                }
                else
                {
                    if (Application.OpenForms["FormPrivate"] != null)
                    {
                        (Application.OpenForms["FormPrivate"] as FormPrivate).setHistory(parts[3]);
                    }
                }
            });
        }
        public void manageTopicChat(List<string> parts)
        {
            this.Invoke((MethodInvoker)delegate // To Write the Received data
            {
                if (parts[3].Equals("new"))
                {
                    FormTopic privateC = new FormTopic(parts[1], link.clientSocket, name);
                    //nowChatting.Add(parts[2]);
                    privateC.Text = "Topic : " + parts[2];
                    privateC.Show();
                }
                else
                {
                    if (Application.OpenForms["FormTopic"] != null)
                    {
                        (Application.OpenForms["FormTopic"] as FormTopic).setHistory(parts[2], parts[3]);
                    }
                }
            });
        }
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
        }

        private void privateChat(string clientName)
        {
            chat.Clear();
            chat.Add("pChat");
            chat.Add(clientName);
            chat.Add(name);
            chat.Add("new");

            byte[] outStream = Methods.ObjectToByteArray(chat);
            link.serverStream.Write(outStream, 0, outStream.Length);
            link.serverStream.Flush();

            FormPrivate privateChat = new FormPrivate(clientName, link.clientSocket, name);
            privateChat.Text = "Private Chat with " + clientName;
            privateChat.Show();
            chat.Clear();
        }

        private void joinTopic(string topicName)
        {
            chat.Clear();
            chat.Add("joinTopic");
            chat.Add(topicName);
            chat.Add(name);
            chat.Add("new");
            byte[] outStream = Methods.ObjectToByteArray(chat);
            link.serverStream.Write(outStream, 0, outStream.Length);
            link.serverStream.Flush();

            FormTopic topicChat = new FormTopic(topicName, link.clientSocket, name);
            topicChat.Text = "Topic Chat discussion of " + topicName;
            topicChat.Show();
            chat.Clear();
        }
        private void Clear_Chat()
        {
            history.Clear();
        }

        private void Create_Topic(string name)
        {
            chat.Add("cTopic");
            chat.Add(name);

            byte[] outStream = Methods.ObjectToByteArray(chat);
            link.serverStream.Write(outStream, 0, outStream.Length);
            link.serverStream.Flush();
            
            chat.Clear();
        }
        private void Send_Click(object sender, EventArgs e)
        {
            try
            {
                if (!input.Text.Equals(""))
                {
                    if (input.Text.StartsWith("/"))
                    {
                        if (input.Text.StartsWith("/create "))
                        {
                            string t = input.Text;
                            t = t.Substring(7, t.Length - 7);
                            Create_Topic(t);
                            input.Text = "";
                        }
                        else if (input.Text.StartsWith("/join "))
                        {
                            chat.Add("jTopic");
                            string t = input.Text;
                            t = t.Substring(5, t.Length - 5);
                            chat.Add(t);

                            byte[] outStream = Methods.ObjectToByteArray(chat);
                            link.serverStream.Write(outStream, 0, outStream.Length);
                            link.serverStream.Flush();
                            input.Text = "";
                            chat.Clear();
                        }
                        else if (input.Text.StartsWith("/private "))
                        {
                            string t = input.Text;
                            t = t.Substring(9, t.Length - 9);
                            string Username = t.Substring(0, t.Length);

                            MessageBox.Show("Nouveau chat avec " + Username);
                            input.Text = "";
                            privateChat(Username);
                        }
                        else if (input.Text.StartsWith("/clear"))
                        {
                            Clear_Chat();
                            input.Text = "";
                        }
                    }
                    else
                    {
                        chat.Add("gChat");
                        chat.Add(input.Text);
                        byte[] outStream = Methods.ObjectToByteArray(chat);

                        link.serverStream.Write(outStream, 0, outStream.Length);
                        link.serverStream.Flush();
                        input.Text = "";
                        chat.Clear();
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("" + er);
            }
        }

        private void ListTopics_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            String topicName = ListTopics.GetItemText(ListTopics.SelectedItem);
            joinTopic(topicName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormEnterTopic testDialog = new FormEnterTopic();

            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (testDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                Create_Topic(testDialog.Textb());
            }
            else
            {
                
            }
            testDialog.Dispose();
        }

        private void listClients_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string clientName = listClients.SelectedItems[0].Text;
            if (!clientName.Equals(name))
            {
                MessageBox.Show("Nouveau chat avec " + clientName);
                privateChat(clientName);
            }
            else
            {
                MessageBox.Show("You can't send private message to yourself !");
            }
        }

        private void history_TextChanged_1(object sender, EventArgs e)
        {
            history.SelectionStart = history.TextLength;
            history.ScrollToCaret();
        }
    }
}
