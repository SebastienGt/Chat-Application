using System;
using System.Collections.Generic;
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
    public class Link
    {
        public TcpClient clientSocket;
        public NetworkStream serverStream = default(NetworkStream);
        public string readData = null;

        public Thread ctThread;
        public Method Methods = new Method();

        List<string> chat = new List<string>();

        public void Connecting(string name, string pass)
        {
            clientSocket = new TcpClient();
            try
            {
                clientSocket.Connect("127.0.0.1", 5000);
                readData = "Connected to Server ";

                serverStream = clientSocket.GetStream();

                chat.Clear();
                chat.Add("login");
                chat.Add(name);
                chat.Add(pass);

                byte[] outStream = Methods.ObjectToByteArray(chat);
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();
                chat.Clear();
            }
            catch (Exception er)
            {
                MessageBox.Show("Server Not Started" + er);
            }
        }
        public void Connecting(string name, string pass, string mail)
        {
            clientSocket = new TcpClient();
            try
            {
                clientSocket.Connect("127.0.0.1", 5000);
                readData = "Connected to Server ";

                serverStream = clientSocket.GetStream();

                chat.Clear();
                chat.Add("register");
                chat.Add(name);
                chat.Add(pass);
                chat.Add(mail);

                byte[] outStream = Methods.ObjectToByteArray(chat);
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();
                chat.Clear();
            }
            catch (Exception er)
            {
                MessageBox.Show("Server Not Started" + er);
            }
        }
        public List<string> Get()
        {
            serverStream = clientSocket.GetStream();
            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);
            List<string> parts = null;

            if (!SocketConnected(clientSocket))
            {
                MessageBox.Show("You've been Disconnected");
                ctThread.Abort();
                clientSocket.Close();
            }
           
            parts = (List<string>)Methods.ByteArrayToObject(inStream);

            if (readData[0].Equals('\0'))
            {
                MessageBox.Show("Reconnect Again");
                readData = "Reconnect Again";
                ctThread.Abort();
                clientSocket.Close();
            }

            return parts;
        }

        public bool SocketConnected(TcpClient s) //check whether client is connected server
        {
            bool flag = false;
            try
            {
                bool part1 = s.Client.Poll(10, SelectMode.SelectRead);
                bool part2 = (s.Available == 0);
                if (part1 && part2)
                {
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Socket " + er);
                Console.WriteLine(er);
            }
            return flag;
        }
    }
}
