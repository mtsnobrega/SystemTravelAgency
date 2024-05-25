using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            GerarTabelaCusto();
        }
        public void GerarTabelaCusto()
        {
            TabelaCusto.Columns.Add("Tipo de Custo", 80).TextAlign = HorizontalAlignment.Center;
            TabelaCusto.Columns.Add("Nome", 80).TextAlign = HorizontalAlignment.Center;
            TabelaCusto.Columns.Add("Valor", 80).TextAlign = HorizontalAlignment.Center;
            TabelaCusto.Columns.Add("Documento", 80).TextAlign = HorizontalAlignment.Center;
            
            TabelaCusto.View = View.Details;
        }
        private void btnaddcusto_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtveiculo.Text))
            {
                MessageBox.Show("Prencha os dados antes de contnuar");
            }
            else
            {
                Form FormPacotes3 = new FormPacotes3(this);
                FormPacotes3.ShowDialog();
            }
        }

        private void aviao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (aviao.SelectedItem != null && aviao.SelectedItem.ToString() == "Viagem Aérea")
            {
                txtveiculo.Text = "Avião";
                lblcustos.Text = "Sem custos Adicionais";
                lblcustoaviao.Text = "Custo Total da Viagem";
                lbltransladohotel.Text = "Translado + Hotel";
                lblcustohotel.Text = "Custo do Translado + Hotel";
                btnaddcusto.Enabled = false;
            }
            else if (aviao.SelectedItem != null && aviao.SelectedItem.ToString() == "Viagem Terrestre")
            {
                txtveiculo.Text = "Onibus";
                lblcustos.Text = "Custos Adicionais";
                lblcustoaviao.Text = "Custo Total da Viagem + Adicionais";
                lbltransladohotel.Text = "Endereço do Hotel";
                lblcustohotel.Text = "Custo do Hotel";
                btnaddcusto.Enabled = true;
            }
        }

        private void btncalc_Click(object sender, EventArgs e)
        {
            double custototalviagem;
            int quantpassagem;
            double lucro;

            double passageminimo;
            double lucrodesejado;
            double valortotallucro;
            double passagemlucro;
            double custohotel;

            if (txtveiculo.Text == "Avião")
            {
                if (string.IsNullOrWhiteSpace(txtqtdpassagem.Text) || string.IsNullOrWhiteSpace(txtcustototalviagem.Text)
                    || string.IsNullOrWhiteSpace(txtcustohotel.Text) || string.IsNullOrWhiteSpace(txtlucro.Text))
                {
                    MessageBox.Show("Prencha os dados antes de contnuar");
                }
                else
                {
                    
                    custototalviagem = double.Parse(txtcustototalviagem.Text);
                    quantpassagem = int.Parse(txtqtdpassagem.Text);
                    custohotel = double.Parse(txtcustohotel.Text);
                    lucro = double.Parse(txtlucro.Text);

                    custototalviagem = custototalviagem + custohotel;

                    passageminimo = custototalviagem / quantpassagem;

                    lucrodesejado = (custototalviagem * (lucro/100));

                    valortotallucro = custototalviagem + lucrodesejado;

                    passagemlucro = valortotallucro / quantpassagem;

                    

                    lblcusto_custoadicional.Text = custototalviagem.ToString("C2");
                    lblpassageminimo.Text = passageminimo.ToString("C2");
                    lblpassagelucro.Text = passagemlucro.ToString("C2");
                    lblvalortotallucro.Text = valortotallucro.ToString("C2");

                }

            }
            else if (txtveiculo.Text == "Onibus")
            {

                if (string.IsNullOrWhiteSpace(txtqtdpassagem.Text) || string.IsNullOrWhiteSpace(txtcustototalviagem.Text)
                    || string.IsNullOrWhiteSpace(txtcustohotel.Text) || string.IsNullOrWhiteSpace(txtlucro.Text))
                {
                    MessageBox.Show("Prencha os dados antes de contnuar");
                }
                else
                {
                    //Arrumar os caculos para viagem de onibus
                    custototalviagem = double.Parse(txtcustototalviagem.Text);
                    quantpassagem = int.Parse(txtqtdpassagem.Text);
                    custohotel = double.Parse(txtcustohotel.Text);
                    lucro = double.Parse(txtlucro.Text);

                    custototalviagem = custototalviagem + custohotel;




                    double tot = 0;
                    foreach (ListViewItem bola in TabelaCusto.Items)
                    {

                        double valorItem;

                        if (double.TryParse(bola.SubItems[2].Text, out valorItem))

                        // talvez usar a classe no lugar de variaveis
                        {
                            tot += valorItem;
                        }
                    }
                    custototalviagem = custototalviagem + tot;


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
            else
            {
                MessageBox.Show("Prencha os dados antes de contnuar");
            }


        }
        private void btcancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnlimpar_Click(object sender, EventArgs e)
        {
            TabelaCusto.Items.Clear();
            txtqtdpassagem.Clear();
            txtida.Clear();
            txthoraida.Clear();
            txtvolta.Clear();
            txthoravolta.Clear();
            txtenderecohotel.Clear();
            txtcustohotel.Clear();
            txtcustototalviagem.Clear();
            txtlucro.Clear();
            aviao.SelectedIndex = -1;
            comboBox1.SelectedIndex = -1;
            txtveiculo.Clear();
            lblcusto_custoadicional.Text = "R$";
            lblpassageminimo.Text = "R$";
            lblpassagelucro.Text = "R$";
            lblvalortotallucro.Text = "R$";
        }
    }
}
