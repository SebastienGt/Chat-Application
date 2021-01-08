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
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Xml.Serialization;
using Communication;

/*
 * DONE : Create topic
 * DONE : Join topic 
 * DONE : Send message to specific topic
 * DONE : Login of user
 * DONE : Private message
 */
namespace ForumAppProject
{
    public partial class Server : Form
    {
        TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 5000);
        TcpClient client;
        Dictionary<string, TcpClient> clientList = new Dictionary<string, TcpClient>();
        CancellationTokenSource cancellation = new CancellationTokenSource();
        List<string> chat = new List<string>();

        List<User> usersInfo = new List<User>();
        Dictionary<string, Topic> topics = new Dictionary<string, Topic>();
        Communication.Method Methods = new Communication.Method();

        public Server()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (Connection.Text == "Start")
            {
                Connection.Text = "Stop";
                cancellation = new CancellationTokenSource(); //resets the token when the server restarts
                startServer();
            }
            else if (Connection.Text == "Stop")
            {
                Connection.Text = "Start";
                Stop_Server();
            }
        }
        private void Stop_Server()
        {
            try
            {
                listener.Stop();
                updateUI("Server Stopped");
                foreach (var Item in clientList)
                {
                    TcpClient broadcastSocket;
                    broadcastSocket = (TcpClient)Item.Value;
                    broadcastSocket.Close();
                }
            }
            catch (SocketException er)
            {
            }
        }

        public async void startServer()
        {
            listener.Start();
            updateUI("Server Started at " + listener.LocalEndpoint);
            updateUI("Waiting for Clients");
            try
            {
                int counter = 0;
                while (true)
                {
                    counter++;
                    client = await Task.Run(() => listener.AcceptTcpClientAsync(), cancellation.Token);

                    /* get username */
                    byte[] Token = new byte[1000];
                    NetworkStream stre = client.GetStream(); //Gets The Stream of The Connection
                    stre.Read(Token, 0, Token.Length); //Receives Data 
                    List<string> parts = (List<string>)Methods.ByteArrayToObject(Token);
                    
                    string username = parts[1];
                    string pass = parts[2];

                    // To send the answer
                    List<string> Dat = new List<string>();

                    if (parts[0] == "login")
                    {
                        bool exist = false;
                        foreach (User u in usersInfo)
                        {
                            if (u.IsTheSame(username, pass))
                            {
                                exist = true;
                                updateUI("User " + username + " - succeed");
                                Dat.Add("Succeed");
                            }
                        }
                        if (exist == false)
                        {
                            updateUI("User " + username + " - tried to connect but password was incorrect");
                            // Si on a trouvé aucun compte correspondant
                            Dat.Add("Failed");
                            byte[] failed = new byte[1024];
                            failed = Methods.ObjectToByteArray(Dat);
                            stre.Write(failed, 0, failed.Length);
                            stre.Flush();
                            return;
                        }
                    }
                    else if (parts[0] == "register")
                    {
                        User user = new User(parts[1], parts[2], parts[3]);
                        updateUI("New user : " + username + " registered");
                        usersInfo.Add(user);
                        Dat.Add("Succeed");
                    }

                    /* add to dictionary, listbox and send userList  */
                    clientList.Add(username, client);
                    Listbox_Clients.Items.Add(username);
                    updateUI("Connected to user " + username + " - " + client.Client.RemoteEndPoint);
                    announce(username + " Joined ", username, false);

                    byte[] success = new byte[1024];
                    success = Methods.ObjectToByteArray(Dat);
                    stre.Write(success, 0, success.Length);
                    stre.Flush();

                    await Task.Delay(500).ContinueWith(t => sendUsersList());
                    await Task.Delay(500).ContinueWith(t => sendTopicsList());

                    var c = new Thread(() => ServerReceive(client, username));
                    c.Start();
                }
            }
            catch (Exception er)
            {
                listener.Stop();
            }
        }
        public void updateUI(String m)
        {
            this.Invoke((MethodInvoker)delegate // To Write the Received data
            {
                textBox1.AppendText(">>" + m + Environment.NewLine);
            });
        }

        public void announce(string msg, string uName, bool flag)
        {
            try
            {
                foreach (var Item in clientList)
                {
                    TcpClient broadcastSocket;
                    broadcastSocket = (TcpClient)Item.Value;
                    NetworkStream broadcastStream = broadcastSocket.GetStream();
                    Byte[] broadcastBytes = null;

                    if (flag)
                    {
                        chat.Add("gChat");
                        chat.Add(uName + " says : " + msg);
                        
                        broadcastBytes = Methods.ObjectToByteArray(chat);
                    }
                    else
                    {
                        chat.Add("gChat");
                        chat.Add(msg);
                        broadcastBytes = Methods.ObjectToByteArray(chat);
                    }
                    broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    broadcastStream.Flush();
                    chat.Clear();
                }
            }
            catch (Exception er)
            {

            }
        }  //end broadcast function

        public void ServerReceive(TcpClient clientn, String username)
        {
            byte[] data = new byte[1000];
            while (true)
            {
                try
                {
                    NetworkStream stream = clientn.GetStream(); //Gets The Stream of The Connection
                    stream.Read(data, 0, data.Length); //Receives Data 
                    List<string> parts = (List<string>)Methods.ByteArrayToObject(data);

                    switch (parts[0])
                    {
                        case "gChat":
                            this.Invoke((MethodInvoker)delegate // To Write the Received data
                            {
                                textBox1.Text += username + ": " + parts[1] + Environment.NewLine;
                            });
                            announce(parts[1], username, true);
                            break;

                        case "pChat":
                            privateChat(parts);
                            break;

                        case "cTopic":
                            CreateTopic(parts);
                            sendTopicsList();
                            break;

                        case "joinTopic":
                            string t = parts[1];
                            topics[t].AddUser(parts[2]);
                            joinTopic(parts);
                            updateUI("added to topic : " + parts[2]);
                            break;

                        case "pTopic":
                            joinTopic(parts);
                            break;
                    }
                    parts.Clear();
                }
                catch (Exception r)
                {
                    updateUI("Client Disconnected: " + username);
                    announce("Client Disconnected: " + username + "$", username, false);
                    clientList.Remove(username);

                    this.Invoke((MethodInvoker)delegate
                    {
                        Listbox_Clients.Items.Remove(username);
                    });
                    sendUsersList();
                    break;
                }
            }
        }
        private void CreateTopic(List<string> text)
        {
            topics.Add(text[1], new Topic(text[1]));

            updateUI("Topic added !" + text[1]);
            this.Invoke((MethodInvoker)delegate
            {
                Listbox_Topics.Items.Add(text[1]);
            });
        }
        private void privateChat(List<string> text)
        {
            try
            {
                byte[] byData = Methods.ObjectToByteArray(text);

                TcpClient workerSocket = null;
                workerSocket = (TcpClient)clientList.FirstOrDefault(x => x.Key == text[1]).Value; //find the client by username in dictionary

                NetworkStream stm = workerSocket.GetStream();
                stm.Write(byData, 0, byData.Length);
                stm.Flush();
            }
            catch (SocketException se)
            {
            }
        }
        private void joinTopic(List<string> text)
        {
            try
            {
                string k = text[1];
                foreach (string username in topics[k].users)
                {
                    byte[] byData = Methods.ObjectToByteArray(text);
                    TcpClient workerSocket = null;
                    workerSocket = clientList.FirstOrDefault(x => x.Key == username).Value; //find the client by username in dictionary

                    NetworkStream stm = workerSocket.GetStream();
                    stm.Write(byData, 0, byData.Length);
                    stm.Flush();
                }
            }
            catch (SocketException se)
            {
            }
        }
        public void sendUsersList()
        {
            try
            {
                byte[] userList = new byte[1024];
                string[] clist = Listbox_Clients.Items.OfType<string>().ToArray();

                List<string> users = new List<string>();

                users.Add("userList");
                foreach (String name in clist)
                {
                    users.Add(name);
                }
                userList = Methods.ObjectToByteArray(users);

                foreach (var Item in clientList)
                {
                    TcpClient broadcastSocket;
                    broadcastSocket = (TcpClient)Item.Value;
                    NetworkStream broadcastStream = broadcastSocket.GetStream();
                    broadcastStream.Write(userList, 0, userList.Length);
                    broadcastStream.Flush();
                    users.Clear();
                }
            }
            catch (SocketException se)
            {
            }
        }
        public void sendTopicsList()
        {
            try
            {
                byte[] topicsList = new byte[1024];
                string[] clist = Listbox_Topics.Items.OfType<string>().ToArray();

                List<string> topics = new List<string>();

                topics.Add("topicsList");
                foreach (String topic in clist)
                {
                    topics.Add(topic);
                }
                topicsList = Methods.ObjectToByteArray(topics);

                foreach (var Item in clientList)
                {
                    TcpClient broadcastSocket;
                    broadcastSocket = (TcpClient)Item.Value;
                    NetworkStream broadcastStream = broadcastSocket.GetStream();
                    broadcastStream.Write(topicsList, 0, topicsList.Length);
                    broadcastStream.Flush();
                    topics.Clear();
                }
            }
            catch (SocketException se)
            {
            }
        }

        void Listbox_Clients_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.Listbox_Clients.IndexFromPoint(e.Location);
            if (index == ListBox.NoMatches)
            {
                MessageBox.Show("Error : No match");
            }
            else
            {
                foreach (User u in usersInfo)
                {
                    if (u.GetName().Equals(Listbox_Clients.SelectedItem.ToString()))
                    {
                        MessageBox.Show("Username : " + u.GetName() + Environment.NewLine + "Pass : " + u.GetPass() + Environment.NewLine + "Mail : " + u.GetMail());
                    }
                }
            }
        }

        private void Listbox_Topics_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.Listbox_Topics.IndexFromPoint(e.Location);
            if (index == ListBox.NoMatches)
            {
                MessageBox.Show("Error : No match");
            }
            else
            {
                string k = "Topic : " + Listbox_Topics.SelectedItem.ToString() + Environment.NewLine + "Participating users : " + Environment.NewLine;
                
                foreach (string u in topics[/*index.ToString()*/Listbox_Topics.SelectedItem.ToString()].users)
                {
                    k = k + u + Environment.NewLine;
                }
                MessageBox.Show(k);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.TextLength;
            textBox1.ScrollToCaret();
        }
    }
}
