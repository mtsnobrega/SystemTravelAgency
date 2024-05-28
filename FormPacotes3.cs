using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemTravelAgency
{
    public partial class FormPacotes3 : Form
    {
        private FormPacotes2 _fp2;

        public FormPacotes3(FormPacotes2 fp2)
        {
            InitializeComponent();
            _fp2 = fp2; // Usar a instância existente de FormPacotes2
        }

        private void BtnAddCusto_Click(object sender, EventArgs e)
        {
            // Validação dos campos
            if (string.IsNullOrWhiteSpace(txtTipoCusto.Text) ||
                string.IsNullOrWhiteSpace(txtnNomeCusto.Text) ||
                string.IsNullOrWhiteSpace(txtDocs.Text) ||
                string.IsNullOrWhiteSpace(txtValorCusto.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            // Conversão segura do valor
            if (!double.TryParse(txtValorCusto.Text, out double custoValor))
            {
                MessageBox.Show("Por favor, insira um valor válido para o custo.");
                return;
            }

            // Coletar dados dos campos de texto
            string CustoTipo = txtTipoCusto.Text;
            string CustoNome = txtnNomeCusto.Text;
            string CustoDocs = txtDocs.Text;
            double CustoValor = double.Parse(txtValorCusto.Text);

            // Criar novo objeto CustoAdicional
          


            // Criar um novo item de ListView

           

            // Fechar o formulário atual
            this.Close();
        }
        private void Btncancelarcusto_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtTipoCusto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if((txtTipoCusto.SelectedItem != null))
            {

                if(txtTipoCusto.SelectedItem.ToString() != "Motorista" && txtTipoCusto.SelectedItem.ToString() != "Seguro")
                {
                    label3.Text = "Doc. não necessário";
                    txtDocs.Text = "Doc. não necessário";
                    txtDocs.Enabled = false;
                }
                else
                {
                    label3.Text = "Documento";
                    txtDocs.Enabled = true;
                }

            }
        }
    }
}
