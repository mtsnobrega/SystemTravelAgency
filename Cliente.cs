using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemTravelAgency
{
    public class Cliente
    {
        public string id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Datanasc { get; set; }
        public string Endereco { get; set; }
        public string Numerocasa { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Celular { get; set; }
        public string Genero { get; set; }

        

        public Cliente(string nome, string celular, string email, string cpf, string rg, string datanasc, string endereco, string numerocasa, string cep, string estado, string genero)
        {
            this.Nome = nome;
            this.Celular = celular;
            this.Email = email;
            this.Cpf = cpf;
            this.Rg = rg;
            this.Datanasc = datanasc;
            this.Endereco = endereco;
            this.Numerocasa = numerocasa;
            this.Cep = cep;
            this.Estado = estado;
            this.Genero = genero;
        }

        public Cliente() : this(null, null, null, null, null, null, null, null, null, null, null)
        {
            // Não é necessário adicionar código aqui, pois o construtor já chama o construtor original
            
        }

        //Realizando o CRUD com MYSQL - é uma sequência de funções de um sistema que trabalha com banco de dados,
        //C - Create
        //R - Read
        //U - Update
        //D - Delet


        // Criando a função CREAT - É o conceito de criação ou cadastro 
        public bool CadastrarClienteBancoDados()
        {
            try
            {
                //fazendo a conexão com o banco de dados e abrindo essa conexão com o comando open
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBancoDados.conexaobanco);
                MysqlConexaoBanco.Open();

                //Comando que esta inserindo que esta cadastrando informações de clientes 
                string insert = $"insert into clientes(nome,email,cpf,rg,datanasc,endereco,numerocasa,cep,estado,celular,genero)" +
                    $"values('{Nome}', '{Email}', '{Cpf}', '{Rg}', '{Datanasc}', '{Endereco}', '{Numerocasa}', '{Cep}', '{Estado}', '{Celular}', '{Genero}')";

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

        //Criando a função Read - Solicitando os dados que serão "lidos" no sistema
        public MySqlDataReader LocalizarCliente()
        {
            try
            {
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBancoDados.conexaobanco);
                MysqlConexaoBanco.Open();

                string select = $"select nome,email,cpf,rg,datanasc,endereco,numerocasa,cep,estado,celular,genero from clientes where cpf = @Cpf;";

                MySqlCommand comandomysql = new MySqlCommand(select, MysqlConexaoBanco);
                comandomysql.Parameters.AddWithValue("@cpf", Cpf);

                MySqlDataReader reader = comandomysql.ExecuteReader();
                return reader;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao pesquisar no banco de dados" + ex.Message);
                return null;
            }
        }

        public bool DeletardoBanco()
        {
            try
            {
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBancoDados.conexaobanco);
                MysqlConexaoBanco.Open();

                string delete = "delete from clientes where cpf = @Cpf;";

                MySqlCommand comandomysql = new MySqlCommand(delete, MysqlConexaoBanco);
                comandomysql.Parameters.AddWithValue("@cpf", Cpf);

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
