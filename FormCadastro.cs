using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SystemTravelAgency.Cliente;

namespace SystemTravelAgency
{
    public partial class FormCadastro : Form
    {
        //private Form frmAtivo;
        public FormCadastro()
        {
            InitializeComponent();
            //GerarGrid();
            PreencherDataGridViewClientes(dataGridViewClientes);
        }
        /*
        private void GerarGrid()
        {
            dataGridViewClientes.Columns.Add("id", "Id");
            dataGridViewClientes.Columns.Add("nome", "Nome");
            dataGridViewClientes.Columns.Add("email", "Email");
            dataGridViewClientes.Columns.Add("cpf", "CPF");
            dataGridViewClientes.Columns.Add("rg", "RG");
            dataGridViewClientes.Columns.Add("datanasc", "Data de Nascimento");
            dataGridViewClientes.Columns.Add("endereco", "Endereço");
            dataGridViewClientes.Columns.Add("numerocasa", "Número da Casa");
            dataGridViewClientes.Columns.Add("cep", "CEP");
            dataGridViewClientes.Columns.Add("estado", "Estado");
            dataGridViewClientes.Columns.Add("celular", "Celular");
            dataGridViewClientes.Columns.Add("genero", "Gênero");
        }
        */

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
            txtESTADO.SelectedIndex = -1;
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
                    MessageBox.Show("Preencha todos os campos corretamente");
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
                        MessageBox.Show($"O cliente {nome} de CPF:{cpf} foi cadastrado");
                    }
                    else
                    {
                        MessageBox.Show("Erro ao cadastrar no banco de dados, contate o suporte ");
                    }

                    //listaClientes.Add(novocliente);
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

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewClientes.Rows)
            {
                // Verifica se a linha não é uma linha nova
                if (!row.IsNewRow)
                {
                    // Acessa a quarta coluna (índice 3) da linha atual, que contém a data de nascimento
                    var cellValue = row.Cells[4].Value;

                    if (cellValue != null && DateTime.TryParse(cellValue.ToString(), out DateTime birthDate))
                    {
                        // Compara o mês e o dia da data de nascimento com a data de hoje
                        if (birthDate.Month == DateTime.Today.Month && birthDate.Day == DateTime.Today.Day)
                        {
                            // É o aniversário da pessoa hoje
                            Console.WriteLine($"Hoje é aniversário de uma pessoa na linha {row.Index}!");

                            // Exemplo: Marcar a linha com uma cor diferente para destacar
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                        }
                    }
                    else
                    {
                        // Lida com valores de data inválidos ou nulos
                        Console.WriteLine($"Data de nascimento inválida na linha {row.Index}");
                    }
                }
            }
        }
    }
}


