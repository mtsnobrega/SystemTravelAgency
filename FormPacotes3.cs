using MySql.Data.MySqlClient;
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
    public partial class FormPacotes3 : Form
    {
        public FormPacotes3()
        {
            InitializeComponent();
            Btnexcluir.Enabled = false;
        }

        private void Btnpesquisarpacote_Click(object sender, EventArgs e)
        {
            try
            {
                Viagem pacotecadastrado = new Viagem();
                pacotecadastrado.DocPacote = txtdocpacote.Text;

                MySqlDataReader reader = pacotecadastrado.LocalizarPacote();

                if (reader != null)
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        txtviagemBD.Text = reader["TipoViagem"].ToString();
                        txtveiculoBD.Text = reader["TipoVeiculo"].ToString();
                        txttipoviagem.Text = reader["TipoPassagem"].ToString();
                        BDembarqueida.Text = reader["EmbarqueIDA"].ToString();

                        DateTime dataembarque = reader.GetDateTime(reader.GetOrdinal("DataIDA"));
                        BDdataida.Text = dataembarque.ToString("dd-MM-yyyy");

                        BDhoraida.Text = reader["HoraIDA"].ToString();
                        BDembarquevolta.Text = reader["EmbarqueVOLTA"].ToString();

                        DateTime dataembarquevolta = reader.GetDateTime(reader.GetOrdinal("DataVOLTA"));
                        BDdatavolta.Text = dataembarquevolta.ToString("dd-MM-yyyy");

                        BDhoravolta.Text = reader["HoraVolta"].ToString();
                        BDenderecohotel.Text = reader["NomeHotel"].ToString();
                        BDcafe.Text = reader["TipoQuarto"].ToString();
                        BDqtdpassagem.Text = reader["QtdPassagem"].ToString();
                        BDpassagemvalor.Text = reader["ValorPassagemLucro"].ToString();
                        BDlucro.Text = reader["Lucro"].ToString();
                        BDvalorviagem.Text = reader["CustoViagem"].ToString();
                        BDvalohotel.Text = reader["ValorHotel"].ToString();
                        BDmotorista.Text = reader["Motorista"].ToString();
                        BDgasolina.Text = reader["Gasolina"].ToString();
                        BDpedagio.Text = reader["Pedagio"].ToString();
                        BDseguro.Text = reader["Seguro"].ToString();
                        BDtarifa.Text = reader["TarifaAerea"].ToString();
                        BDcustototal.Text = reader["CustoTotalPacote"].ToString();
                        BDreceber.Text = reader["ValorTotalLucro"].ToString();


                        Btnexcluir.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Esse Pacote de Viagem Não foi cadastrado");
                    }
                }
                else
                {
                    MessageBox.Show("Esse Pacote de Viagem Não foi cadastrado");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro no Banco de Dados Solicitar Suporte" + ex.Message);
            }
        }

        private void Btnexcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtdocpacote.Text))
                {
                    Viagem pacotecadastrado = new Viagem();
                    pacotecadastrado.DocPacote = txtdocpacote.Text;


                    if (pacotecadastrado.DeletarPacotedoBanco())
                    {
                        MessageBox.Show("Cliente Excluido com Sucesso");
                        txtdocpacote.Clear();
                        txtviagemBD.Clear();
                        txtveiculoBD.Clear();
                        txttipoviagem.Clear();
                        BDembarqueida.Clear();
                        BDdataida.Clear();
                        BDhoraida.Clear();
                        BDembarquevolta.Clear();
                        BDdatavolta.Clear();
                        BDhoravolta.Clear();
                        BDenderecohotel.Clear();
                        BDcafe.Clear();
                        BDqtdpassagem.Clear();
                        BDpassagemvalor.Clear();
                        BDlucro.Clear();
                        BDvalorviagem.Clear();
                        BDvalohotel.Clear();
                        BDmotorista.Clear();
                        BDgasolina.Clear();
                        BDpedagio.Clear();
                        BDseguro.Clear();
                        BDtarifa.Clear();
                        BDcustototal.Clear();
                        BDreceber.Clear();
                        Btnexcluir.Enabled = false;

                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir Cliente");
                    }
                }
                else
                {
                    MessageBox.Show("Insira um Documento Valido antes de Excluir um Pacote");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Falha no banco de dados, contate o suporte " + ex.Message);
            }
        }
        private void Btncancelarpesquisa_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
