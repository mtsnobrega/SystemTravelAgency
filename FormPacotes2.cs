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
           
        }
   
        private void Btnaddcusto_Click(object sender, EventArgs e)
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
                txtveiculo.Text = "Onibus";
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

        private void Btncalc_Click(object sender, EventArgs e)
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





                    custototalviagem = custototalviagem; //+ tot;


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
        private void Btcancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btnlimpar_Click(object sender, EventArgs e)
        {
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

        public string semcusto = "Sem Custo Adicional";

        private void checkmotorista_CheckedChanged(object sender, EventArgs e)
        {
            txtmotoristavalor.Text = semcusto;
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
    }
    
}
