using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Client
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        
        public static int level = 0;
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormLogin fLogin = new FormLogin();
            Boolean flag = true;
            Application.Run(fLogin);
            
            /*DialogResult dialogResult = fLogin.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                if (fLogin.Textb() != "")
                {
                    flag = false;
                    FormMain form = new FormMain();
                    //form.SetName(fLogin.Textb());
                    //form.Connect();
                    Application.Run(form);
                }
                else
                {
                    //fLogin.slblU("Please enter");
                    //MessageBox.Show("Please enter");
                }
                // ELSE On fait une verif
            }
            else if (dialogResult == DialogResult.No)
            {
                FormRegister formRegister = new FormRegister();
                if (formRegister.ShowDialog() == DialogResult.OK)
                {
                    FormMain form = new FormMain();
                    form.SetName(fLogin.Textb());
                    Application.Run(form);
                }
            }
            else
            {
                Application.Exit();
            }*/
        }
    }
}
