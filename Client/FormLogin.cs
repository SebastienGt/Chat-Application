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


namespace Client
{
    public partial class FormLogin : Form
    {
        Link link = new Link();
        string username = null;
        
        public FormLogin()
        {
            InitializeComponent();
        }

        public string Textb()
        {
            return textBox1.Text;
        }

        private void getMessage()
        {
            try
            {
                while (true)
                {
                    List<string> succeed = link.Get();

                    switch (succeed[0])
                    {
                        case "Succeed":
                            this.Invoke((MethodInvoker)delegate
                            {
                                LoginSucceed();
                            });
                            break;

                        case "Failed":
                            MessageBox.Show("The account does not exist");
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show("GetMessageLogin " + e);
                //link.ctThread.Abort();
                //Console.WriteLine(e);
            }
        }

        private void Register_Click(object sender, EventArgs e)
        {
            FormRegister formRegister = new FormRegister();

            if (formRegister.ShowDialog() == DialogResult.OK)
            {
                if (formRegister.GetUsername() == "" || formRegister.GetPass() == "" || formRegister.GetMail() == "")
                {
                    MessageBox.Show("Please enter all box !");
                }
                else
                {
                    username = formRegister.GetUsername();
                    link.Connecting(formRegister.GetUsername(), formRegister.GetPass(), formRegister.GetMail());
                    link.ctThread = new Thread(getMessage);
                    link.ctThread.Start();
                }
            }
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Des informations sont manquantes !");
            }
            else
            {
                username = Textb();
                link.Connecting(textBox1.Text, textBox2.Text);
                link.ctThread = new Thread(getMessage);
                link.ctThread.Start();
            }
        }
        public void LoginSucceed()
        {
            FormMain form = new FormMain(link);
            form.SetName(username);
            form.Location = this.Location;
            form.StartPosition = FormStartPosition.Manual;
            form.FormClosing += delegate { this.Close(); };
            form.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
