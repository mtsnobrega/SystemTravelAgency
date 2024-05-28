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
    public partial class FormCadastro2 : Form
    {
        public FormCadastro2()
        {
            InitializeComponent();
            Btnexcluir.Enabled = false;
           
        }
       
        private void Btnpesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente clientecadastrado = new Cliente();
                clientecadastrado.Cpf = txtpesquisaBD.Text;

                MySqlDataReader reader = clientecadastrado.LocalizarCliente();

                if(reader != null)
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        txtnomeBD.Text = reader["nome"].ToString();
                        txtemailBD.Text = reader["email"].ToString();
                        txtcpfBD.Text = reader["cpf"].ToString();
                        txtrgBD.Text = reader["rg"].ToString();

                        DateTime dataNascimento = reader.GetDateTime(reader.GetOrdinal("datanasc"));
                        txtdataBD.Text = dataNascimento.ToString("dd-MM-yyyy");

                        txtenderecoBD.Text = reader["endereco"].ToString();
                        txtnBd.Text = reader["numerocasa"].ToString();
                        txtcepBD.Text = reader["cep"].ToString();
                        txtestadoBD.Text = reader["estado"].ToString();
                        txtcelularBD.Text = reader["celular"].ToString();
                        txtgeneroBD.Text = reader["genero"].ToString();

                        lblsituacao.Text = "Cliente Já Cadastrado";
                        lblsituacao.ForeColor = Color.Green;

                        Btnexcluir.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Cliente não ola mundo Cadastrado");
                    }
                }
                else
                {
                    MessageBox.Show("Cliente não Cadastrado");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Essa bosta nã funcionou" + ex.Message);
            }
        }

        private void Btnexcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtpesquisaBD.Text))
                {
                    Cliente clientecadastrado = new Cliente();
                    clientecadastrado.Cpf = txtpesquisaBD.Text;

                   
                    if (clientecadastrado.DeletardoBanco())
                    {
                        MessageBox.Show("Cliente Excluido com Sucesso");
                        txtpesquisaBD.Clear();
                        txtnomeBD.Clear();
                        txtemailBD.Clear();
                        txtcpfBD.Clear();
                        txtrgBD.Clear();
                        txtdataBD.Clear();
                        txtenderecoBD.Clear();
                        txtnBd.Clear();
                        txtcepBD.Clear();
                        txtestadoBD.Clear();
                        txtcelularBD.Clear();
                        txtgeneroBD.Clear();
                        lblsituacao.Text = "";
                        Btnexcluir.Enabled = false;

                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir Cliente");
                    }
                }
                else
                {
                    MessageBox.Show("Insira um CPF valido para excluir um cliente");
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

