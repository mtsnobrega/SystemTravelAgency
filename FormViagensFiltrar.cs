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
    public partial class FormViagensFiltrar : Form
    {
        public FormViagensFiltrar()
        {
            InitializeComponent();
        }

        private void LimparPesquisa()
        {
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
        }

        private void BtnPesquisarpacotes_Click(object sender, EventArgs e)
        {
            //LimparPesquisa();
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
                       
                    }
                    else
                    {
                        MessageBox.Show("aaaaaaEsse Pacote de Viagem Não foi cadastrado");
                    }
                }
                else
                {
                    MessageBox.Show("Esse Pacote de Viagem Não foi cadastrado");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Essa bosta nã funcionou" + ex.Message);
            }
        }

        private void BtnLimpartudo_Click(object sender, EventArgs e)
        {
            LimparPesquisa();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
