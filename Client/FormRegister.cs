using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FormRegister : Form
    {
        
        public FormRegister()
        {
            InitializeComponent();
        }
        public string GetUsername()
        {
            return PeudoBox.Text;
        }
        public string GetPass()
        {
            return PassBox.Text;
        }
        public string GetMail()
        {
            return MailBox.Text;
        }
        private void PeudoBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void MailBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PassBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
