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

namespace SystemTravelAgency
{

    public class Viagem
    {

        public string TipoViagem { get; set; }
        public string TipoVeiculo { get; set; }
        public string TipoPassagem { get; set; }
        public int QtdPassagem { get; set; }
        public string EmbarqueIDA { get; set; }
        public string DataIDA { get; set; }
        public string HoraIDA { get; set; }
        public string EmbarqueVOLTA { get; set; }
        public string DataVOLTA { get; set; }
        public string HoraVolta { get; set; }
        public string NomeHotel { get; set; }
        public string TipoQuarto { get; set; }
        public double ValorHotel { get; set; }
        public double CustoViagem { get; set; }
        public double Lucro { get; set; }
        public double CustoTotalPacote { get; set; }
        public double ValorMinimoPassagem { get; set; }
        public double ValorPassagemLucro { get; set; }
        public double ValorTotalLucro { get; set; }

        public string Motorista {  get; set; }
        public string Gasolina { get; set; }
        public string Pedagio { get; set; }
        public string Seguro { get; set; }
        public string TarifaAerea { get; set; }



        public Viagem(
                  string TipoViagem, string tipoVeiculo, string tipoPassagem, int qtdPassagem, string embarqueIDA, string dataIDA, string horaIDA,
                  string embarqueVOLTA, string dataVOLTA, string horaVolta, string nomeHotel, string tipoQuarto, double valorHotel, double custoViagem,
                  double lucro, double custoTotalPacote, double valorMinimoPassagem, double valorPassagemLucro, double valorTotalLucro, string motorista,
                  string gasolina, string pedagio, string seguro, string tarifaAerea)
        {
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
            this.ValorMinimoPassagem = valorMinimoPassagem;
            this.ValorPassagemLucro = valorPassagemLucro;
            this.ValorTotalLucro = valorTotalLucro;
            this.Motorista = motorista;
            this.Gasolina = gasolina;
            this.Pedagio = pedagio;
            this.Seguro = seguro;
            this.TarifaAerea = tarifaAerea;
        }

        public bool CadastrarViagemBancoDados()
        {
            try
            {
                //fazendo a conexão com o banco de dados e abrindo essa conexão com o comando open
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBancoDados.conexaobanco);
                MysqlConexaoBanco.Open();

                //Comando que esta inserindo que esta cadastrando informações de clientes 
                string insert = $"INSERT INTO tabela_viagens (TipoViagem, TipoVeiculo, TipoPassagem, QtdPassagem, EmbarqueIDA, DataIDA, HoraIDA, EmbarqueVOLTA, DataVOLTA, HoraVolta, NomeHotel, TipoQuarto, ValorHotel, CustoViagem, Lucro, CustoTotalPacote, ValorMinimoPassagem, ValorPassagemLucro, ValorTotalLucro, Motorista, Gasolina, Pedagio, Seguro, TarifaAerea) " +
                    $"VALUES ('{TipoViagem}', '{TipoVeiculo}', '{TipoPassagem}', {QtdPassagem}, '{EmbarqueIDA}', '{DataIDA}', '{HoraIDA}', '{EmbarqueVOLTA}', '{DataVOLTA}', '{HoraVolta}', '{NomeHotel}', '{TipoQuarto}', {ValorHotel}, {CustoViagem}, {Lucro}, {CustoTotalPacote}, {ValorMinimoPassagem}, {ValorPassagemLucro}, {ValorTotalLucro}, '{Motorista}', '{Gasolina}', '{Pedagio}', '{Seguro}', '{TarifaAerea}')";

                //enviando para o banco de dados o comando que esta inserindo no banco de dados
                MySqlCommand comandomysql = MysqlConexaoBanco.CreateCommand();
                comandomysql.CommandText = insert;

                comandomysql.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar no banco de dados. Contate o Suporte " + ex.Message);
                return false;
            }
        }



    }

    
   
    
}
