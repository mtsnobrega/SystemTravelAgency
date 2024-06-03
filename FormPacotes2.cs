using K4os.Compression.LZ4.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SystemTravelAgency
{
    public partial class FormPacotes2 : Form
    {
        public FormPacotes2()
        {
            InitializeComponent();
        }
        private void Aviao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (aviao.SelectedItem != null && aviao.SelectedItem.ToString() == "Viagem Aérea")
            {
                txtveiculo.Text = "Avião";
                lblcustoaviao.Text = "Custo Total da Viagem";
                lbltransladohotel.Text = "Translado + Hotel";
                lblcustohotel.Text = "Custo do Translado + Hotel";
                checkcombustivelvalor.Checked = false;
                checkcombustivelvalor.Enabled = false;

                checkmotorista.Checked = false;
                checkmotorista.Enabled = false;

                checkpedagiovalor.Checked = false;
                checkpedagiovalor.Enabled = false;

                checkservicovalor.Enabled = true;
            }
            else if (aviao.SelectedItem != null && aviao.SelectedItem.ToString() == "Viagem Terrestre")
            {
                txtveiculo.Text = "Ônibus";
                lblcustoaviao.Text = "Custo Total da Viagem + Adicionais";
                lbltransladohotel.Text = "Endereço do Hotel";
                lblcustohotel.Text = "Custo do Hotel";
                checkcombustivelvalor.Enabled = true;
                checkmotorista.Enabled = true;
                checkpedagiovalor.Enabled = true;

                checkservicovalor.Checked = false;
                checkservicovalor.Enabled = false;
            }
        }

        private void calculageraal()
        {
            decimal custoviagem;
            decimal quantpassagem;
            decimal lucro;

            decimal passageminimo;
            decimal lucrodesejado;
            decimal valortotallucro;
            decimal passagemlucro;
            decimal custohotel;

            decimal custototalviagem;

            if (txtveiculo.Text == "Avião")
            {
                decimal aviaoseguro = 0;
                decimal aviaotaxa = 0;

                if (checksegurovalor.Checked == true)
                {
                    if (string.IsNullOrWhiteSpace(txtsegurovalor.Text))
                    {
                        MessageBox.Show("Preencha o valor Referente ao custo Adicional - SEGURO");
                    }
                    else
                    {
                        txtsegurovalor.Text = txtsegurovalor.Text.Replace('.', ',');
                        if (!decimal.TryParse(txtsegurovalor.Text, out decimal resultadoDouble))
                        {
                            MessageBox.Show("Preencha o valor referente ao custo Adicional - SEGURO");
                        }
                        else
                        {
                            aviaoseguro = resultadoDouble;
                        }
                    }
                }
                else
                {
                    aviaoseguro = 0;
                }
                //verificando custo de tarifas aereas
                if (checkservicovalor.Checked == true)
                {
                    if (string.IsNullOrWhiteSpace(txtservicovalor.Text))
                    {
                        MessageBox.Show("Preencha o Valor Referente ao Custo Adicional - TAXA AÉREA");
                    }
                    else
                    {
                        txtservicovalor.Text = txtservicovalor.Text.Replace('.', ',');
                        if (!decimal.TryParse(txtservicovalor.Text, out decimal resultadoDouble1))
                        {
                            MessageBox.Show("Preencha o Valor Referente ao Custo Adicional - TAXA AÉREA");
                        }
                        else
                        {
                            aviaotaxa = resultadoDouble1;
                        }
                    }
                }
                else
                {
                    aviaotaxa = 0;
                }


                if (string.IsNullOrWhiteSpace(txtqtdpassagem.Text) || string.IsNullOrWhiteSpace(txtcustototalviagem.Text)
                    || string.IsNullOrWhiteSpace(txtcustohotel.Text) || string.IsNullOrWhiteSpace(txtlucro.Text))
                {
                    MessageBox.Show("Não é possivél Fornecer um Valor se os Campos estiverem Vazios");
                }
                else
                {
                    txtcustototalviagem.Text = txtcustototalviagem.Text.Replace(".", ",");
                    txtcustohotel.Text = txtcustohotel.Text.Replace(".", ",");
                    if (!int.TryParse(txtqtdpassagem.Text, out int quantidadePassagem) || !decimal.TryParse(txtcustohotel.Text, out decimal custodohotel) ||
                        !decimal.TryParse(txtcustototalviagem.Text, out decimal custoviage) || !int.TryParse(txtlucro.Text, out int lucrando))
                    {
                        
                        MessageBox.Show("Preencha corretamente os campos: Quantidade de passagens, Lucro Desejado(Decimal), Custos Referentes ao Hotel e a Viagem");
                    }
                    else
                    {
                        if (quantidadePassagem <= 0)
                        {
                            MessageBox.Show("A quantida de Passagens Deve ser Igual ou Superior a 1");
                        }
                        else
                        {
                            quantpassagem = quantidadePassagem;
                            custoviagem = custoviage;
                            custohotel = custodohotel;
                            lucro = lucrando;

                            custototalviagem = custoviagem + custohotel + aviaoseguro + aviaotaxa;

                            passageminimo = custototalviagem / quantpassagem;

                            lucrodesejado = (custototalviagem * (lucro / 100));

                            valortotallucro = custototalviagem + lucrodesejado;

                            passagemlucro = valortotallucro / quantpassagem;

                            lblcusto_custoadicional.Text = custototalviagem.ToString("C2");
                            lblpassageminimo.Text = passageminimo.ToString("C2");
                            lblpassagelucro.Text = passagemlucro.ToString("C2");
                            lblvalortotallucro.Text = valortotallucro.ToString("C2");
                        }
                        
                    }
                }
            }

            else if (txtveiculo.Text == "Ônibus")
            {

                decimal moto = 0;
                decimal gasosa = 0;
                decimal roubo = 0;
                decimal segurobusao = 0;

                //custo do motorista
                if (checkmotorista.Checked == true)
                {
                    if (string.IsNullOrWhiteSpace(txtmotoristavalor.Text))
                    {
                        MessageBox.Show("Preencha o Valor Referente ao Custo Adicional - MOTORISTA");
                    }
                    else
                    {
                        txtmotoristavalor.Text = txtmotoristavalor.Text.Replace('.', ',');
                        if (!decimal.TryParse(txtmotoristavalor.Text, out decimal resultadomoto))
                        {
                            MessageBox.Show("Preencha o valor Referente ao Custo Adicional - MOTORISTA");
                        }
                        else
                        {
                            moto = resultadomoto;
                        }
                    }
                }
                else
                {
                    moto = 0;
                }

                //custo da gasolina
                if (checkcombustivelvalor.Checked == true)
                {
                    if (string.IsNullOrWhiteSpace(txtcombustivelvalor.Text))
                    {
                        MessageBox.Show("Preencha o Valor Referente ao Custo Adicional - COMBUSTÍVEL");
                    }
                    else
                    {
                        txtcombustivelvalor.Text = txtcombustivelvalor.Text.Replace('.', ',');
                        if (!decimal.TryParse(txtcombustivelvalor.Text, out decimal resultadogasosa))
                        {
                            MessageBox.Show("Preencha o Valor Referente ao Custo Adicional - COMBUSTÍVEL");
                        }
                        else
                        {
                            gasosa = resultadogasosa;
                        }
                    }
                }
                else
                {
                    gasosa = 0;
                }

                //custo do pedagio
                if (checkpedagiovalor.Checked == true)
                {
                    if (string.IsNullOrWhiteSpace(txtpedagiovalor.Text))
                    {
                        MessageBox.Show("Preencha o Valor Referente ao Custo Adicional - PEDÁGIO");
                    }
                    else
                    {
                        txtpedagiovalor.Text = txtpedagiovalor.Text.Replace('.', ',');
                        if (!decimal.TryParse(txtpedagiovalor.Text, out decimal resultadopedagio))
                        {
                            MessageBox.Show("Preencha o Valor Referente ao Custo Adicional - PEDÁGIO");
                        }
                        else
                        {
                            roubo = resultadopedagio;
                        }
                    }
                }
                else
                {
                    roubo = 0;
                }

                //custo seguro busao
                if (checksegurovalor.Checked == true)
                {
                    if (string.IsNullOrWhiteSpace(txtsegurovalor.Text))
                    {
                        MessageBox.Show("Preencha o Valor Referente ao Custo Adicional - SEGURO");
                    }
                    else
                    {
                        txtsegurovalor.Text = txtsegurovalor.Text.Replace('.', ',');
                        if (!decimal.TryParse(txtsegurovalor.Text, out decimal resultadosegurobus))
                        {
                            MessageBox.Show("Preencha o Valor Referente ao Custo Adicional - SEGURO");
                        }
                        else
                        {
                            segurobusao = resultadosegurobus;
                        }
                    }
                }
                else
                {
                    segurobusao = 0;
                }

                if (string.IsNullOrWhiteSpace(txtqtdpassagem.Text) || string.IsNullOrWhiteSpace(txtcustototalviagem.Text)
                    || string.IsNullOrWhiteSpace(txtcustohotel.Text) || string.IsNullOrWhiteSpace(txtlucro.Text))
                {
                    MessageBox.Show("Não é possivél fornecer um valor se os campos estiverem vazios");
                }
                else
                {
                    txtcustototalviagem.Text = txtcustototalviagem.Text.Replace(".", ",");
                    txtcustohotel.Text = txtcustohotel.Text.Replace(".", ",");
                    if (!int.TryParse(txtqtdpassagem.Text, out int quantidadePassagem) || !decimal.TryParse(txtcustohotel.Text, out decimal custodohotel) ||
                        !decimal.TryParse(txtcustototalviagem.Text, out decimal custoviage) || !int.TryParse(txtlucro.Text, out int lucrando))
                    {
                        MessageBox.Show("Preencha corretamente os campos: Quantidade de passagens, Lucro Desejado(Decimal), Custos Referentes ao Hotel e a Viagem");
                    }
                    else
                    {
                        if (quantidadePassagem <= 0)
                        {
                            MessageBox.Show("A quantida de Passagens Deve ser Igual ou Superior a 1");
                        }
                        else
                        {
                            quantpassagem = quantidadePassagem;
                            custoviagem = custoviage;
                            custohotel = custodohotel;
                            lucro = lucrando;

                            custototalviagem = custoviagem + custohotel + moto + gasosa + roubo + segurobusao;

                            passageminimo = custototalviagem / quantpassagem;

                            lucrodesejado = (custototalviagem * (lucro / 100));

                            valortotallucro = custototalviagem + lucrodesejado;

                            passagemlucro = valortotallucro / quantpassagem;

                            lblcusto_custoadicional.Text = custototalviagem.ToString("C2");
                            lblpassageminimo.Text = passageminimo.ToString("C2");
                            lblpassagelucro.Text = passagemlucro.ToString("C2");
                            lblvalortotallucro.Text = valortotallucro.ToString("C2");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Insira as infromações do Pacote Antes de Realizar um Cálculo");
            }
        }
        private void Btncalc_Click(object sender, EventArgs e)
        {
            calculageraal();
        }
        private void Btcancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void limpatudo()
        {
            txtdocpacote.Clear();
            aviao.SelectedIndex = -1;
            txtveiculo.Clear();
            txttipoviagem.SelectedIndex = -1;
            txtqtdpassagem.Clear();
            txtida.Clear();
            txthoraida.Clear();
            txtvolta.Clear();
            txthoravolta.Clear();
            txtenderecohotel.Clear();
            Tipoquarto.SelectedIndex = -1;
            txtcustohotel.Clear();
            checkmotorista.Checked = false;
            checkcombustivelvalor.Checked = false;
            checkpedagiovalor.Checked = false;
            checksegurovalor.Checked = false;
            checkservicovalor.Checked = false;
            txtcustototalviagem.Clear();
            txtlucro.Clear();
            lblcusto_custoadicional.Text = "R$";
            lblpassageminimo.Text = "R$";
            lblpassagelucro.Text = "R$";
            lblvalortotallucro.Text = "R$";
        }
        private void Btnlimpar_Click(object sender, EventArgs e)
        {
            limpatudo();
        }

        public string semcusto = "Sem Custo Adicional";

        private void checkmotorista_CheckedChanged(object sender, EventArgs e)
        {
            //txtmotoristavalor.Text = semcusto;
            if (checkmotorista.Checked == true)
            {
                txtmotoristavalor.Clear();
                txtmotoristavalor.ReadOnly = false;
            }
            else
            {
                txtmotoristavalor.ReadOnly = true;
                txtmotoristavalor.Text = semcusto; 
            }
            
        }

        private void checkcombustivelvalor_CheckedChanged(object sender, EventArgs e)
        {
           
            if (checkcombustivelvalor.Checked == true)
            {
                txtcombustivelvalor.Clear();
                txtcombustivelvalor.ReadOnly = false;
            }
            else
            {
                txtcombustivelvalor.ReadOnly = true;

                txtcombustivelvalor.Text = semcusto;
            }
        }

        private void checkpedagiovalor_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkpedagiovalor.Checked == true)
            {
                txtpedagiovalor.Clear();
                txtpedagiovalor.ReadOnly = false;
            }
            else
            {
                txtpedagiovalor.ReadOnly = true;
                txtpedagiovalor.Text = semcusto;
               
            }

        }

        private void checksegurovalor_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checksegurovalor.Checked == true)
            {
                txtsegurovalor.Clear();
                txtsegurovalor.ReadOnly = false;
            }
            else
            {
                txtsegurovalor.ReadOnly = true;
                txtsegurovalor.Text = semcusto;
            }
        }

        private void checkservicovalor_CheckedChanged(object sender, EventArgs e)
        {
           
            if (checkservicovalor.Checked == true)
            {
                txtservicovalor.Clear();
                txtservicovalor.ReadOnly = false;

            }
            else
            {
                txtservicovalor.ReadOnly = true;
                txtservicovalor.Text = semcusto;
                
            }
        }

        private void btnsalvapacote_Click(object sender, EventArgs e)
        {
            DateTime idadata = dataida.Value.Date;
            DateTime voltadata = datavolta.Value.Date;
            calculageraal();
            try
            {
                if (string.IsNullOrWhiteSpace(txtdocpacote.Text) || string.IsNullOrWhiteSpace(txttipoviagem.Text) || string.IsNullOrWhiteSpace(txttipoviagem.Text) || 
                    string.IsNullOrWhiteSpace(txtida.Text) || string.IsNullOrWhiteSpace(txthoraida.Text) || string.IsNullOrWhiteSpace(txtvolta.Text) || 
                    string.IsNullOrWhiteSpace(txthoravolta.Text) || string.IsNullOrWhiteSpace(txtenderecohotel.Text) || string.IsNullOrWhiteSpace(Tipoquarto.Text) ||
                    lblcusto_custoadicional.Text == "R$" || lblpassageminimo.Text == "R$" || lblpassagelucro.Text == "R$" || lblvalortotallucro.Text == "R$" ||  !txthoraida.MaskFull || !txthoravolta.MaskFull)
                {
                    MessageBox.Show("Preencha todos os campos corretamente");
                    //limpatudo();
                }
                else
                {
                    string DocPacote = txtdocpacote.Text;
                    string TipoViagem = aviao.Text;
                    string tipoVeiculo = txtveiculo.Text;
                    string tipoPassagem = txttipoviagem.Text;
                    string qtdPassagem = txtqtdpassagem.Text;
                    string embarqueIDA = txtida.Text;
                    string dataIDA = idadata.ToString("yyyy-MM-dd");
                    string horaIDA = txthoraida.Text;
                    string embarqueVOLTA = txtvolta.Text;
                    string dataVOLTA = voltadata.ToString("yyyy-MM-dd");
                    string horaVolta = txthoravolta.Text;
                    string nomeHotel = txtenderecohotel.Text;
                    string tipoQuarto = Tipoquarto.Text;
                    string valorHotel = txtcustohotel.Text;
                    string custoViagem = txtcustototalviagem.Text;
                    string lucro = txtlucro.Text;
                    string custoTotalPacote = lblcusto_custoadicional.Text;
                    string valorPassagemLucro = lblpassagelucro.Text;
                    string valorTotalLucro = lblvalortotallucro.Text;
                    string motorista = ("R$ " + txtmotoristavalor.Text);
                    string gasolina = ("R$ " + txtcombustivelvalor.Text);
                    string pedagio = ("R$ " + txtpedagiovalor.Text);
                    string seguro = ("R$ " + txtsegurovalor.Text);
                    string tarifaAerea = ("R$ " + txtservicovalor.Text);

                    Viagem novopacote = new Viagem(
                        DocPacote, TipoViagem, tipoVeiculo, tipoPassagem, qtdPassagem, embarqueIDA, dataIDA, horaIDA, embarqueVOLTA, dataVOLTA, horaVolta, nomeHotel,
                        tipoQuarto, valorHotel, custoViagem, lucro, custoTotalPacote, valorPassagemLucro, valorTotalLucro, motorista, gasolina,
                        pedagio, seguro, tarifaAerea);

                    if (novopacote.CadastrarViagemBancoDados())
                    {
                        limpatudo();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao cadastrar no banco de dados, contate o suporte ");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao Cadastrar Pacote de Viagem no Banco de dados" + ex.Message);
            }
            
        }

        private void txthoraida_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
             
            string hora  = txthoraida.Text.Replace(":", "");
            if (hora.Length != 4 || !int.TryParse(hora, out int time) || time < 0 || time > 2359)
            {
                MessageBox.Show("Por favor, insira uma hora válida entre 00:00 e 23:59.");
                txthoraida.Clear();
            }
        }

        private void txthoravolta_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            string hora = txthoravolta.Text.Replace(":", "");
            if (hora.Length != 4 || !int.TryParse(hora, out int time) || time < 0 || time > 2359)
            {
                MessageBox.Show("Por favor, insira uma hora válida entre 00:00 e 23:59.");
                txthoravolta.Clear();
            }
        } 
    }
    
}
