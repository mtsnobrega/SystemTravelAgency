using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemTravelAgency
{
    static class ConexaoBancoDados
    {
        private const string servidor = "localhost";
        private const string bancodados = "dbclientes";
        private const string usuario = "root";
        private const string senha = "#Zoro13chibumbo#";

        static public string conexaobanco = $"server={servidor}; user id={usuario}; database={bancodados}; password={senha}";
    }
}
