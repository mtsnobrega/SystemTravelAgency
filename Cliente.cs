using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemTravelAgency
{
    public class Cliente
    {
        public static class IDGenerator
        {
            private static int currentID = 0;

            public static int GenerateID()
            {
                currentID++;
                return currentID;
            }
        }

        


        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }
        public string datanasc { get; set; }
        public string endereco { get; set; }
        public string cep { get; set; }
        public string estado { get; set; }
        public string celular { get; set; }
        public string genero { get; set; }
       
       


        public Cliente(int id, string nome, string celular, string email, string cpf, string rg, string datanasc, string endereco, string cep, string estado, string genero)
        {
            this.id = id;
            this.nome = nome;
            this.celular = celular;
            this.email = email;
            this.cpf = cpf;
            this.rg = rg;
            this.datanasc = datanasc;
            this.endereco = endereco;
            this.cep = cep;
            this.estado = estado;
            this.genero = genero;
        }

        
    }
    
}
