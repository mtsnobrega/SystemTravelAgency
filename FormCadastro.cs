using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViaCep;
using static SystemTravelAgency.Cliente;

namespace SystemTravelAgency
{
    public partial class FormCadastro : Form
    {
        public FormCadastro()
        {
            InitializeComponent();
            BtnAniversario.Enabled = false;
        }
  
        //Metodo para limpar formuulario de cadastro
        public void LimparFormulario()
        {
            txtNOME.Clear();
            txtCELULAR.Clear();
            txtEMAIL.Clear();
            txtCPF.Clear();
            txtRG.Clear();
            txtENDERECO.Clear();
            txtN.Clear();
            txtCEP.Clear();
            txtESTADO.Clear();
            txtCidade.Clear();
            txtGENERO.SelectedIndex = -1;
        }

        private void Btnaddcliente_Click_1(object sender, EventArgs e)
        {
            DateTime data = datepicker.Value.Date;
            
            try
            {
                //uma função do c# que verifica se os campos de texto ou se a string é nula, vazia ou consiste apenas de espaços em branco
                if (string.IsNullOrWhiteSpace(txtNOME.Text) || string.IsNullOrWhiteSpace(txtEMAIL.Text) || string.IsNullOrWhiteSpace(txtCPF.Text)||
                    string.IsNullOrWhiteSpace(txtRG.Text) || string.IsNullOrWhiteSpace(txtCELULAR.Text) || string.IsNullOrWhiteSpace(txtGENERO.Text)||
                    string.IsNullOrWhiteSpace(txtENDERECO.Text) || string.IsNullOrWhiteSpace(txtN.Text) || string.IsNullOrWhiteSpace(txtCEP.Text)||
                    string.IsNullOrWhiteSpace(txtESTADO.Text))
                {
                    MessageBox.Show("Preencha Todos os Campos Corretamente");
                    LimparFormulario();
                }
                else
                {
                    string nome = txtNOME.Text;
                    string celular = txtCELULAR.Text;
                    string email = txtEMAIL.Text;
                    string cpf = txtCPF.Text;
                    string rg = txtRG.Text;
                    string datanasc = data.ToString("yyyy-MM-dd");
                    string endereco = txtENDERECO.Text;
                    string numerocasa = txtN.Text;
                    string cep = txtCEP.Text;
                    string estado = txtESTADO.Text;
                    string genero = txtGENERO.Text;

                    Cliente novocliente = new Cliente(nome, celular, email, cpf, rg, datanasc, endereco, numerocasa, cep, estado, genero);

                    if (novocliente.CadastrarClienteBancoDados())
                    {
                        MessageBox.Show($"O cliente {nome} de CPF:{cpf} Foi Cadastrado");
                    }
                    else
                    {
                        MessageBox.Show("Erro ao cadastrar no banco de dados, contate o suporte ");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao Cadastrar Cliente" + ex.Message);
            }

            LimparFormulario();
        }

        private void Btngerenciar_Click(object sender, EventArgs e)
        {
            Form FormCadastro2 = new FormCadastro2();
            FormCadastro2.ShowDialog();
        }

        public void PreencherDataGridViewClientes(DataGridView dataGridViewClientes)
        {
            try
            {
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBancoDados.conexaobanco);
                MysqlConexaoBanco.Open();
                
                string select = "SELECT nome, email, cpf, rg, datanasc, endereco, numerocasa, cep, estado, celular, genero FROM clientes;";
                MySqlCommand comandomysql = new MySqlCommand(select, MysqlConexaoBanco);

                MySqlDataAdapter adapter = new MySqlDataAdapter(comandomysql);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewClientes.DataSource = dataTable;
                dataGridViewClientes.Columns["nome"].HeaderText = "Nome";
                dataGridViewClientes.Columns["email"].HeaderText = "Email";
                dataGridViewClientes.Columns["cpf"].HeaderText = "CPF";
                dataGridViewClientes.Columns["rg"].HeaderText = "RG";
                dataGridViewClientes.Columns["datanasc"].HeaderText = "Data de Nascimento";
                dataGridViewClientes.Columns["endereco"].HeaderText = "Endereço";
                dataGridViewClientes.Columns["numerocasa"].HeaderText = "Número";
                dataGridViewClientes.Columns["cep"].HeaderText = "CEP";
                dataGridViewClientes.Columns["estado"].HeaderText = "Estado";
                dataGridViewClientes.Columns["celular"].HeaderText = "Celular";
                dataGridViewClientes.Columns["genero"].HeaderText = "Gênero";

                BtnAniversario.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao preencher o DataGridView com os clientes: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PreencherDataGridViewClientes(dataGridViewClientes);
        }

        private void BtnAniversario_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow linha in dataGridViewClientes.Rows)
            {
                // Verifica se a linha não é uma linha nova
                if (!linha.IsNewRow)
                {
                    // Acessa a quarta coluna (índice 3) da linha atual, que contém a data de nascimento
                    var mesnasc = linha.Cells[4].Value;
                       
                    if (mesnasc != null && DateTime.TryParse(mesnasc.ToString(), out DateTime nascido))
                    {
                        // variavel recebe o valor da data de nascimento e compara com o mes atual
                        if (nascido.Month == DateTime.Today.Month)
                        {
                            // marca a linha do datagrid para mostrar que a pessoa faz aniversario no mes atual
                            linha.DefaultCellStyle.BackColor = Color.LightGreen;
                        }
                    }
                    else
                    {
                    }
                }
            }
        }
        
        private async void VerificarCep_Click(object sender, EventArgs e)
        {
            string cep = txtCEP.Text.Trim();
            if (string.IsNullOrWhiteSpace(txtCEP.Text))
            {
                MessageBox.Show("insira um cep valido");
                return;
            }
            else
            {
                try
                {
                    //API RESTful disponibilizada pelo ViaCep
                    ViaCepClient client = new ViaCepClient();
                    CancellationToken cancellationToken = new CancellationToken();
                    var address = await client.SearchAsync(cep, cancellationToken);

                    if (address == null || string.IsNullOrEmpty(address.Street))
                    {
                        MessageBox.Show($"O CEP: {cep}, não foi Localizado/Não Existe.");
                        return;
                    }

                    txtCidade.Text = address.City ?? string.Empty;
                    txtENDERECO.Text = address.Street ?? string.Empty;
                    txtESTADO.Text = address.StateInitials ?? string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao pesquisar Cep na APi " + ex.Message);
                }
            } 
        }
    }
}


