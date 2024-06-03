using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemTravelAgency
{
    public partial class FormPacotes : Form
    {
        public FormPacotes()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form FormPacotes2 = new FormPacotes2();
            FormPacotes2.ShowDialog();
        }

        private void BtnEcluirPacote_Click(object sender, EventArgs e)
        {
            Form FormPacote3 = new FormPacotes3();
            FormPacote3.ShowDialog();
        }

        public void PreencherDataGridViewPacotes(DataGridView dataGridViewpacotes)
        {
            try
            {
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBancoDados.conexaobanco);
                MysqlConexaoBanco.Open();

                string select = "SELECT DocPacote, TipoViagem, TipoVeiculo, TipoPassagem, QtdPassagem, EmbarqueIDA, DataIDA, HoraIDA, EmbarqueVOLTA," +
                    " DataVOLTA, HoraVolta, NomeHotel, TipoQuarto, ValorHotel, CustoViagem, Lucro, CustoTotalPacote, ValorPassagemLucro, ValorTotalLucro," +
                    " Motorista, Gasolina, Pedagio, Seguro, TarifaAerea FROM PacotesViagens;";

                MySqlCommand comandomysql = new MySqlCommand(select, MysqlConexaoBanco);

                MySqlDataAdapter adapter = new MySqlDataAdapter(comandomysql);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);
                dataGridViewpacotes.DataSource = dataTable;
                dataGridViewpacotes.Columns["DocPacote"].HeaderText = "Documento da Viagem";
                dataGridViewpacotes.Columns["TipoViagem"].HeaderText = "Tipo da Viagem";
                dataGridViewpacotes.Columns["TipoVeiculo"].HeaderText = "Tipo de Veiculo";
                dataGridViewpacotes.Columns["TipoPassagem"].HeaderText = "Tipo de Passagem";
                dataGridViewpacotes.Columns["QtdPassagem"].HeaderText = "Quantidade de Passagem";
                dataGridViewpacotes.Columns["EmbarqueIDA"].HeaderText = "Local de Embarque(IDA)";
                dataGridViewpacotes.Columns["DataIDA"].HeaderText = "Data do Embarque(IDA)";
                dataGridViewpacotes.Columns["HoraIDA"].HeaderText = "Hora do Embarque(IDA)";
                dataGridViewpacotes.Columns["EmbarqueVOLTA"].HeaderText = "Local do Embarque(Volta)";
                dataGridViewpacotes.Columns["DataVOLTA"].HeaderText = "Data do Embarque(Volta)";
                dataGridViewpacotes.Columns["HoraVolta"].HeaderText = "Hora do Embarque(Volta)";
                dataGridViewpacotes.Columns["NomeHotel"].HeaderText = "Endereço do Hotel";
                dataGridViewpacotes.Columns["TipoQuarto"].HeaderText = "Tipo de Quarto";// talvez trocar para outra coisa 
                dataGridViewpacotes.Columns["ValorHotel"].HeaderText = "Valor do Hotel/Translado)";
                dataGridViewpacotes.Columns["CustoViagem"].HeaderText = "Custo pela viagem";
                dataGridViewpacotes.Columns["Lucro"].HeaderText = "Lucro Desejado";
                dataGridViewpacotes.Columns["CustoTotalPacote"].HeaderText = "Custo da Viagem + Adicionais";

                dataGridViewpacotes.Columns["ValorPassagemLucro"].HeaderText = "Valor Por Passagem";
                dataGridViewpacotes.Columns["ValorTotalLucro"].HeaderText = "Valor ToTal a Receber";
                dataGridViewpacotes.Columns["Motorista"].HeaderText = "Custo Adcional Com Motorista";
                dataGridViewpacotes.Columns["Gasolina"].HeaderText = "Custo Adicional com Gasolina";
                dataGridViewpacotes.Columns["Pedagio"].HeaderText = "Custo Adicional com Pedágios";
                dataGridViewpacotes.Columns["Seguro"].HeaderText = "Custo Adicional com Seguro";
                dataGridViewpacotes.Columns["TarifaAerea"].HeaderText = "Custo Adicional com Tarifa Aerea";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao preencher o DataGridView com os clientes: " + ex.Message);
            }



        }

        private void Btnatualizarpacote_Click(object sender, EventArgs e)
        {
            PreencherDataGridViewPacotes(dataGridViewpacotes);
        }
    }
}
