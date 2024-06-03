using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Forms;
using System.Runtime.InteropServices.ComTypes;
using Org.BouncyCastle.Bcpg;
using Mysqlx.Crud;

namespace SystemTravelAgency
{

    public class Viagem
    {
        public string DocPacote {  get; set; }
        public string TipoViagem { get; set; }
        public string TipoVeiculo { get; set; }
        public string TipoPassagem { get; set; }
        public string QtdPassagem { get; set; }
        public string EmbarqueIDA { get; set; }
        public string DataIDA { get; set; }
        public string HoraIDA { get; set; }
        public string EmbarqueVOLTA { get; set; }
        public string DataVOLTA { get; set; }
        public string HoraVolta { get; set; }
        public string NomeHotel { get; set; }
        public string TipoQuarto { get; set; }
        public string ValorHotel { get; set; }
        public string CustoViagem { get; set; }
        public string Lucro { get; set; }
        public string CustoTotalPacote { get; set; }
        public string ValorPassagemLucro { get; set; }
        public string ValorTotalLucro { get; set; }

        public string Motorista {  get; set; }
        public string Gasolina { get; set; }
        public string Pedagio { get; set; }
        public string Seguro { get; set; }
        public string TarifaAerea { get; set; }



        public Viagem(
                  string DocPacote, string TipoViagem, string tipoVeiculo, string tipoPassagem, string qtdPassagem, string embarqueIDA, string dataIDA,
                  string horaIDA, string embarqueVOLTA, string dataVOLTA, string horaVolta, string nomeHotel, string tipoQuarto, string valorHotel, string custoViagem,
                  string lucro, string custoTotalPacote, string valorPassagemLucro, string valorTotalLucro, string motorista,
                  string gasolina, string pedagio, string seguro, string tarifaAerea)
        {
            this.DocPacote = DocPacote;
            this.TipoViagem = TipoViagem;
            this.TipoVeiculo = tipoVeiculo;
            this.TipoPassagem = tipoPassagem;
            this.QtdPassagem = qtdPassagem;
            this.EmbarqueIDA = embarqueIDA;
            this.DataIDA = dataIDA;
            this.HoraIDA = horaIDA;
            this.EmbarqueVOLTA = embarqueVOLTA;
            this.DataVOLTA = dataVOLTA;
            this.HoraVolta = horaVolta;
            this.NomeHotel = nomeHotel;
            this.TipoQuarto = tipoQuarto;
            this.ValorHotel = valorHotel;
            this.CustoViagem = custoViagem;
            this.Lucro = lucro;
            this.CustoTotalPacote = custoTotalPacote;
            this.ValorPassagemLucro = valorPassagemLucro;
            this.ValorTotalLucro = valorTotalLucro;
            this.Motorista = motorista;
            this.Gasolina = gasolina;
            this.Pedagio = pedagio;
            this.Seguro = seguro;
            this.TarifaAerea = tarifaAerea;


        }

        public Viagem() : this(null, null, null, null,null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null)
        {
            // Não é necessário adicionar código aqui, pois o construtor já chama o construtor original

        }

        public bool CadastrarViagemBancoDados()
        {
            try
            {

                //fazendo a conexão com o banco de dados e abrindo essa conexão com o comando open
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBancoDados.conexaobanco);
                MysqlConexaoBanco.Open();

                
                string checkQuery = "SELECT COUNT(*) FROM PacotesViagens WHERE DocPacote = @DocPacote";

                using (MySqlCommand checkBD = new MySqlCommand(checkQuery, MysqlConexaoBanco))
                {
                    checkBD.Parameters.AddWithValue("@DocPacote", DocPacote);

                    int count = Convert.ToInt32(checkBD.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Esse pacote já existe");
                        return true;
                    }
                }
                
                string insert = $"INSERT INTO PacotesViagens (DocPacote,TipoViagem, TipoVeiculo, TipoPassagem, QtdPassagem, EmbarqueIDA, DataIDA, HoraIDA, EmbarqueVOLTA," +
                $" DataVOLTA, HoraVolta, NomeHotel, TipoQuarto, ValorHotel, CustoViagem, Lucro, CustoTotalPacote," +
                $"ValorPassagemLucro, ValorTotalLucro, Motorista, Gasolina, Pedagio, Seguro, TarifaAerea) " +

                $"VALUES ('{DocPacote}', '{TipoViagem}', '{TipoVeiculo}', '{TipoPassagem}', '{QtdPassagem}', '{EmbarqueIDA}', '{DataIDA}', '{HoraIDA}', '{EmbarqueVOLTA}'," +
                $"'{DataVOLTA}', '{HoraVolta}', '{NomeHotel}', '{TipoQuarto}', '{ValorHotel}', '{CustoViagem}', '{Lucro}', '{CustoTotalPacote}'," +
                $"'{ValorPassagemLucro}', '{ValorTotalLucro}', '{Motorista}', '{Gasolina}', '{Pedagio}', '{Seguro}', '{TarifaAerea}')";

                //enviando para o banco de dados o comando que esta inserindo no banco de dados
                MySqlCommand comandomysql = MysqlConexaoBanco.CreateCommand();
                comandomysql.CommandText = insert;

                comandomysql.ExecuteNonQuery();
                MessageBox.Show($"O Pacode de Viagem de {DocPacote}, foi cadastrado com sucesso");
                return true;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar no banco de dados. Contate o Suporte " + ex.Message);
                return false;
            }
        }

      

        public MySqlDataReader LocalizarPacote()
        {
            try
            {
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBancoDados.conexaobanco);
                MysqlConexaoBanco.Open();
                string select = $"select DocPacote, TipoViagem, TipoVeiculo, TipoPassagem, QtdPassagem, EmbarqueIDA," +
                    $" DataIDA, HoraIDA, EmbarqueVOLTA, DataVOLTA, HoraVolta, NomeHotel, TipoQuarto, ValorHotel," +
                    $" CustoViagem, Lucro, CustoTotalPacote, ValorPassagemLucro, ValorTotalLucro," +
                    $" Motorista, Gasolina, Pedagio, Seguro, TarifaAerea from PacotesViagens where DocPacote = @DocPacote;";

                MySqlCommand comandomysql = new MySqlCommand(select, MysqlConexaoBanco);
                comandomysql.Parameters.AddWithValue("@DocPacote", DocPacote);

                MySqlDataReader reader = comandomysql.ExecuteReader();
                return reader;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao pesquisar no banco de dados" + ex.Message);
                return null;
            }
        }

        public bool AtualizarPacote()
        {
            try
            {
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBancoDados.conexaobanco);
                MysqlConexaoBanco.Open();

                string update = $"update PacotesViagens set QtdPassagem = @QtdPassagem where DocPacote = @DocPacote";

                

                MySqlCommand comandomysql = MysqlConexaoBanco.CreateCommand();
                comandomysql.CommandText = update;

                comandomysql.Parameters.AddWithValue("@QtdPassagem", QtdPassagem);
                comandomysql.Parameters.AddWithValue("@DocPacote", DocPacote);

                comandomysql.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar Pacote no Banco de Dados");
                return false;
            }
        }



        public bool DeletarPacotedoBanco()
        {
            try
            {
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBancoDados.conexaobanco);
                MysqlConexaoBanco.Open();

                string delete = "delete from PacotesViagens where DocPacote = @DocPacote;";

                MySqlCommand comandomysql = new MySqlCommand(delete, MysqlConexaoBanco);
                comandomysql.Parameters.AddWithValue("@DocPacote", DocPacote);

                comandomysql.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao se comunicar com o banco de dados, contate o suprte " + ex.Message);
                return false;
            }

        }
    }


    
   
    
}
