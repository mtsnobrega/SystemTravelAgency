using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemTravelAgency
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnfechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //O botão está funcionando como "fechar" do programa
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string user = txtuser.Text;
            string passwd = txtpasswd.Text;
            try
            {
                if (user == "ParaisoTropical" && passwd == "@melhorsistema")
                {
                    Home form2 = new Home();
                    form2.Show();
                    this.Hide();
                    //Funcionando, levando ao form "Home"

                }
                else if (user == passwd)
                {
                    MessageBox.Show("Nome de Usuario e Senha NÂO podem ser iguais");
                    //MELHORAR A MENSAGEM DE ERRO
                }
                else
                {
                    MessageBox.Show("Nome de Usuario ou Senha incorretos");
                    //MELHORAR A MENSAGEM DE ERRO
                }

            }
            catch (Exception)
            {

                throw;
            }
            
                



            
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                txtpasswd.PasswordChar = '\0';
            else
                txtpasswd.PasswordChar = '*';
        }
    }
}
