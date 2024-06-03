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
    public partial class Home : Form
    {
        private Form frmAtivo;
        public Home()
        {
            InitializeComponent();
        }
        private void FormShow(Form frm)
        {
            FormAtivoFechar();
            frmAtivo = frm;
            frm.TopLevel = false;
            panelform.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }


        private void FormAtivoFechar()
        {
            if (frmAtivo != null)
            {
                frmAtivo.Hide();
            }
        }
        private void ActiveButton(Button frmAtivo)
        {
            foreach (Control botao in panelbotoes.Controls)
                botao.ForeColor = Color.White;

            frmAtivo.ForeColor = Color.Gray;
        }

        private void btncadastro_Click(object sender, EventArgs e)
        {
            ActiveButton(btnCadastro);
            FormShow(new FormCadastro());
        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {

            ActiveButton(btnHome);
            FormAtivoFechar();

        }

      

        private void btnViagens_Click(object sender, EventArgs e)
        {
            ActiveButton(btnViagens);
            FormShow(new FormViagens());
        }

        private void btnPacotes_Click(object sender, EventArgs e)
        {
            ActiveButton(btnPacotes);
            FormShow(new FormPacotes());
        }

        private void btnVC_Click(object sender, EventArgs e)
        {
            //ActiveButton(btnVC);
            //FormShow(new FormVendas());
            MessageBox.Show("Este Modulo está em Desenvolvimento\n Em Breve...");

        }

        private void btnDash_Click(object sender, EventArgs e)
        {
            //ActiveButton(btnDash);
            //FormShow(new FormDash());
            MessageBox.Show("Este Modulo está em Desenvolvimento\n Em Breve...");
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
