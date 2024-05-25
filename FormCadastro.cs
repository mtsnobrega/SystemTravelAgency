using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SystemTravelAgency.Cliente;

namespace SystemTravelAgency
{
    public partial class FormCadastro : Form
    {
        private Form frmAtivo;
        public FormCadastro()
        {
            InitializeComponent();
            GerarTabela();
            CarregarClientes();
        }

        private static List<Cliente> listaClientes = new List<Cliente>();

        private void CarregarClientes()
        {
            tabela.Items.Clear();

            foreach (Cliente novocliente in listaClientes)
            {
                ListViewItem item = new ListViewItem(new[]
                {
                    novocliente.id.ToString(),
                    novocliente.nome,
                    novocliente.celular,
                    novocliente.email,
                    novocliente.cpf,
                    novocliente.rg,
                    novocliente.datanasc,
                    novocliente.endereco,
                    novocliente.cep,
                    novocliente.estado,
                    novocliente.genero
                });
                tabela.Items.Add(item);
            }
        }

        public void LimparFormulario()
        {
            txtNOME.Clear();
            txtCELULAR.Clear();
            txtEMAIL.Clear();
            txtCPF.Clear();
            txtRG.Clear();
            txtENDERECO.Clear();
            txtCEP.Clear();
            txtESTADO.SelectedIndex = -1;
            txtGENERO.SelectedIndex = -1;
        }

        private void GerarTabela()
        {
            tabela.Columns.Add("ID", 50).TextAlign = HorizontalAlignment.Center;
            tabela.Columns.Add("Nome", 300).TextAlign = HorizontalAlignment.Center;
            tabela.Columns.Add("Celular", 100).TextAlign = HorizontalAlignment.Center;
            tabela.Columns.Add("E-mail", 300).TextAlign = HorizontalAlignment.Center;
            tabela.Columns.Add("CPF", 130).TextAlign = HorizontalAlignment.Center;
            tabela.Columns.Add("RG", 100).TextAlign = HorizontalAlignment.Center;
            tabela.Columns.Add("Data de Nascimento", 100).TextAlign = HorizontalAlignment.Center;
            tabela.Columns.Add("Endereço", 200).TextAlign = HorizontalAlignment.Center;
            tabela.Columns.Add("CEP", 100).TextAlign = HorizontalAlignment.Center;
            tabela.Columns.Add("Estado", 80).TextAlign = HorizontalAlignment.Center;
            tabela.Columns.Add("Genero", 100).TextAlign = HorizontalAlignment.Center;
            tabela.Columns.Add("Filhos", 70).TextAlign = HorizontalAlignment.Center;
            tabela.View = View.Details;
        }

        

        private void btnaddcliente_Click_1(object sender, EventArgs e)
        {
            DateTime data = datepicker.Value;

            int id = IDGenerator.GenerateID();
            string nome = txtNOME.Text;
            string celular = txtCELULAR.Text;
            string email = txtEMAIL.Text;
            string cpf = txtCPF.Text;
            string rg = txtRG.Text;
            string datanasc = data.ToShortDateString();
            string endereco = txtENDERECO.Text;
            string cep = txtCEP.Text;
            string estado = txtESTADO.Text;
            string genero = txtGENERO.Text;

            Cliente novocliente = new Cliente(id, nome, celular, email, cpf, rg, datanasc, endereco, cep, estado, genero);

            listaClientes.Add(novocliente);

            CarregarClientes();

            LimparFormulario();
        }
    }
}


