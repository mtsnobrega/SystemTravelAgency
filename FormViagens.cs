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

namespace SystemTravelAgency
{
    public partial class FormViagens : Form
    {
        public FormViagens()
        {
            InitializeComponent();
            PreencherDataGridViewPacotesDisponiveis(DataGridViewPacotesDisponiveis);
            BtnComprarpacote.Enabled = false;
        }
        public void PreencherDataGridViewPacotesDisponiveis(DataGridView DataGridViewPacotesDisponiveis)
        {
            try
            {
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBancoDados.conexaobanco);
                MysqlConexaoBanco.Open();

                string select = "SELECT DocPacote, TipoVeiculo, QtdPassagem, EmbarqueIDA, DataIDA, HoraIDA, EmbarqueVOLTA," +
                    " DataVOLTA, HoraVolta, NomeHotel, TipoQuarto, ValorPassagemLucro  FROM PacotesViagens;";//TipoPassagem

                MySqlCommand comandomysql = new MySqlCommand(select, MysqlConexaoBanco);

                MySqlDataAdapter adapter = new MySqlDataAdapter(comandomysql);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);
                DataGridViewPacotesDisponiveis.DataSource = dataTable;
                DataGridViewPacotesDisponiveis.Columns["DocPacote"].HeaderText = "Documento da Viagem";
                DataGridViewPacotesDisponiveis.Columns["ValorPassagemLucro"].HeaderText = "Valor Por Passagem";
                DataGridViewPacotesDisponiveis.Columns["QtdPassagem"].HeaderText = "Quantidade de Passagem";
                //DataGridViewPacotesDisponiveis.Columns["TipoPassagem"].HeaderText = "Tipo de Passagem";
                DataGridViewPacotesDisponiveis.Columns["TipoVeiculo"].HeaderText = "Tipo de Veiculo";
                DataGridViewPacotesDisponiveis.Columns["EmbarqueIDA"].HeaderText = "Local de Embarque(IDA)";
                DataGridViewPacotesDisponiveis.Columns["EmbarqueVOLTA"].HeaderText = "Local do Embarque(Retorno)";
                DataGridViewPacotesDisponiveis.Columns["DataIDA"].HeaderText = "Data do Embarque(IDA)";
                DataGridViewPacotesDisponiveis.Columns["HoraIDA"].HeaderText = "Hora do Embarque(IDA)";
                
                DataGridViewPacotesDisponiveis.Columns["DataVOLTA"].HeaderText = "Data do Embarque(Retorno)";
                DataGridViewPacotesDisponiveis.Columns["HoraVolta"].HeaderText = "Hora do Embarque(Retorno)";
                DataGridViewPacotesDisponiveis.Columns["NomeHotel"].HeaderText = "Endereço do Hotel";
                DataGridViewPacotesDisponiveis.Columns["TipoQuarto"].HeaderText = "Facilidades";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao preencher o DataGridView com os clientes: " + ex.Message);
            }
        }

        private void BtnAtualizarLista_Click(object sender, EventArgs e)
        {
            PreencherDataGridViewPacotesDisponiveis(DataGridViewPacotesDisponiveis);
        }

        private void BtnFIltrar_Click(object sender, EventArgs e)
        {
            Form FormFiltrar = new FormViagensFiltrar();
            FormFiltrar.ShowDialog();
        }

        private void BtnComprarpacote_Click(object sender, EventArgs e)
        {

            try
            {
                Cliente clientecadastrado = new Cliente();
                clientecadastrado.Cpf = txtpesquisaBD.Text;

                MySqlDataReader reader = clientecadastrado.LocalizarCliente();

                if (reader != null)
                {
                    if (reader.HasRows)
                    {

                        reader.Read();
                        string nome = reader["nome"].ToString();
                        string email = reader["email"].ToString();
                        string celular = reader["celular"].ToString();
                        string cpf = reader["cpf"].ToString();
                        string rg = reader["rg"].ToString();
                        string cep = reader["cep"].ToString();
                        string numero = reader["numerocasa"].ToString();
                        string endereco = reader["endereco"].ToString();
                        string estado = reader["estado"].ToString();
                        string genero = reader["genero"].ToString(); 

                        DateTime dataNascimento = reader.GetDateTime(reader.GetOrdinal("datanasc"));
                        string data = dataNascimento.ToString("dd-MM-yyyy");
                     
                        FormViagensCompra FormCompra = new FormViagensCompra(nome, email, celular, cpf, rg, data, cep, numero, endereco, estado, genero);
                        FormCompra.ShowDialog();
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception)
            {

                throw;
            } 
        }

        private void BtnPesquisarCpf_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente clientecadastrado = new Cliente();
                clientecadastrado.Cpf = txtpesquisaBD.Text;

                MySqlDataReader reader = clientecadastrado.LocalizarCliente();

                if (reader != null && reader.HasRows)
                {
                    Lblsituacaocliente.Text = "Cliente Cadastrado";
                    Lblsituacaocliente.ForeColor = Color.White;
                    BtnComprarpacote.Enabled = true;  
                }
                else
                {
                    Lblsituacaocliente.Text = "Cliente Não Cadastrado";
                    Lblsituacaocliente.ForeColor = Color.Yellow;
                   
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro No Banco de Dados" + ex.Message);
            }
        }
    }
}
