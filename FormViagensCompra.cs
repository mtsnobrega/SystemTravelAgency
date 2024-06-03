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
    public partial class FormViagensCompra : Form
    {
        public FormViagensCompra()
        {
            InitializeComponent();
            BtnComprarPacote.Enabled = false;    
        }

        public FormViagensCompra(string nome, string email, string celular, string cpf, string rg, string data, string cep,string numero, string endereco, string estado, string genero)
        {
            InitializeComponent();

            txtnomeBD.Text = nome;
            txtemailBD.Text = email;
            txtcelularBD.Text = celular;
            txtcpfBD.Text = cpf;
            txtrgBD.Text = rg;
            txtdataBD.Text = data;
            txtcepBD.Text = cep;
            txtnBd.Text = numero;
            txtenderecoBD.Text = endereco;
            txtestadoBD.Text = estado;
            txtgeneroBD.Text = genero;

        }


        private void BtnPesquisarpacotes_Click(object sender, EventArgs e)
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
                    }
                    else
                    {
                        MessageBox.Show("Esse Pacote de Viagem Não foi cadastrado");
                        limparcompra();
                    }
                }
                else
                {
                    MessageBox.Show("Esse Pacote de Viagem Não foi cadastrado");
                    limparcompra();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro no Banco de dados entrar em contato com o suporte" + ex.Message);
            }
        }


        decimal desconto = 0;
        public void BtnCupon_Click(object sender, EventArgs e)
        {
            //Verificando se a data de aniversario bate com o mes atual para o cliente ganhar desconto
            string datanascimento = txtdataBD.Text;
            if (datanascimento != null && DateTime.TryParse(datanascimento.ToString(), out DateTime mesniver))
            {
                if (mesniver.Month == DateTime.Today.Month)
                {
                    desconto = 0.10m;
                    TxtCupom.Text = "Aniversário";
                }
                else
                {
                    TxtCupom.Text = "Cupom Indisp.";
                    desconto = 0;
                }
            }
            else
            {
                desconto = 0;
            }
        }
        int passagenscliente;
        int Passagensdiponivel;


        public void calcularcompra()
        {
           
            if (string.IsNullOrWhiteSpace(TxtClientePassagens.Text) || string.IsNullOrWhiteSpace(BDqtdpassagem.Text))
            {
                MessageBox.Show("Insira um valor antes de pesquisar");
            }
            else
            {
                if (!int.TryParse(TxtClientePassagens.Text, out int valor))
                {
                    MessageBox.Show("Insira uma Quantidade Valida de Passagens");
                    TxtClientePassagens.Clear();
                }
                else
                {
                    passagenscliente = valor;
                    Passagensdiponivel = int.Parse(BDqtdpassagem.Text);
                    if (passagenscliente > Passagensdiponivel)
                    {
                        MessageBox.Show("A Quantidade de Passagens é Superior a Quantidade de Passagens Disponiveis");
                    }
                    else
                    {
                        string passagemvalor = BDpassagemvalor.Text.Replace("R$", "").Replace(".", ""); ;//valor da passagem da viage e Tirando o R$ e o ponto para realizar operações

                        decimal valorpassagem = decimal.Parse(passagemvalor);//Convertendo a string do valor da para decimal

                        decimal valordodesconto = valorpassagem * desconto;//valor total do desconto em cima do valor da passagem

                        //passagenscliente = int.Parse(TxtClientePassagens.Text);//Quantidade de passagens do cliente

                        decimal descontoporpassagem = passagenscliente * valordodesconto; //Valor do desconto com base na quantidade de passagens

                        decimal ValorPagar = ((passagenscliente * valorpassagem) - descontoporpassagem);

                        TxtvaloraPagar.Text = ValorPagar.ToString("C2");

                        BtnComprarPacote.Enabled = true;
                    }
                }
            }
        }
        
        private void BtnVerificarValor_Click(object sender, EventArgs e)
        {
            calcularcompra();
        }


        private void BtnComprarPacote_Click_1(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TxtClientePassagens.Text) || string.IsNullOrWhiteSpace(BDqtdpassagem.Text) || string.IsNullOrWhiteSpace(metodopagamento.Text))
            {
                MessageBox.Show("Insira um valor antes de pesquisar");
            }
            else
            {
                calcularcompra();
                if (!int.TryParse(TxtClientePassagens.Text, out int valor) || passagenscliente > Passagensdiponivel || passagenscliente <= 0)
                {
                    MessageBox.Show("Insira uma Quantidade Valida de Passagens");
                    TxtClientePassagens.Clear();
                }
                else
                {
                    
                    string dinheirogasto = TxtvaloraPagar.ToString();
                    int quantidadePassagem = int.Parse(BDqtdpassagem.Text);
                    int passagemcompra = int.Parse(TxtClientePassagens.Text);
                    int novaquantidade = quantidadePassagem - passagemcompra;

                    if (novaquantidade <= 0)
                    {
                        Viagem Pacotecadastrado = new Viagem();
                        Pacotecadastrado.DocPacote = txtdocpacote.Text;

                        if (Pacotecadastrado.DeletarPacotedoBanco())
                        {
                            MessageBox.Show($"Compra do Pacote foi Processada");
                        }
                        else
                        {
                            MessageBox.Show("Compra NÃO Processada");
                        }
                    }
                    else
                    {
                        Viagem Pacotecadastrado = new Viagem();
                        Pacotecadastrado.DocPacote = txtdocpacote.Text;


                        Pacotecadastrado.QtdPassagem = novaquantidade.ToString();
                        //MessageBox.Show(novaquantidade.ToString());

                        if (Pacotecadastrado.AtualizarPacote())
                        {
                            MessageBox.Show($"Compra do Pacote foi Processada:");
                        }
                        else
                        {
                            MessageBox.Show("Compra NÃO Processada");
                        }
                    }

                    limparcompra();
                }
            }
        }
        private void BtnCancelaCompra_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void limparcompra()
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
            TxtCupom.Clear();
            BDqtdpassagem.Clear();
            BDpassagemvalor.Clear();
            TxtClientePassagens.Clear();
            TxtvaloraPagar.Clear();
            metodopagamento.SelectedIndex = -1;
            BtnComprarPacote.Enabled = false;
        }

        private void TxtClientePassagens_TextChanged(object sender, EventArgs e)
        {
            TxtvaloraPagar.Clear();
        }
    }
}
