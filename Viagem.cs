using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemTravelAgency
{

    public class CustoAdicional
    {
        public string CustoTipo { get; set; }
        public string CustoNome { get; set; }
        public string CustoDocs { get; set; }
        public double CustoValor { get; set; }

        public CustoAdicional(string CustoTipo, string CustoNome, string CustoDocs, double CustoValor)
        {
            this.CustoTipo = CustoTipo;
            this.CustoNome = CustoNome;
            this.CustoDocs = CustoDocs;
            this.CustoValor = CustoValor;
        }
    }
    public class Viagem : CustoAdicional
    {

        public string NomeEmpresaViagem { get; set; }
        public string PrecoTotal { get; set; }
        public string TipoPassagem {  get; set; }
        public int QtdPassagem { get; set; }
        public string EmbarqueIDA { get; set; }
        public string DataIDA { get; set; }
        public string HoraIDA { get; set; }
        public string EmbarqueVOLTA { get; set; }
        public string DataVOLTA { get; set; }
        public string HoraVolta { get; set; }
        public double ValorPassagem { get; set; }
        public string NomeHotel { get; set; }
        public double ValorHotel { get; set; }


        public Viagem(
                  string NomeEmpresaViagem, string PrecoTotal, string TipoPassagem, int QtdPassagem,
                  string EmbarqueIDA, string DataIDA, string HoraIDA, string EmbarqueVOLTA,
                  string DataVOLTA, string HoraVolta, string destino, double ValorPassagem, string NomeHotel, string CustoNome, double ValorHotel,
                  string CustoDocs, string CustoTipo, double CustoValor)
                  : base(CustoTipo, CustoNome, CustoDocs, CustoValor)
        {
            this.NomeEmpresaViagem = NomeEmpresaViagem;
            this.PrecoTotal = PrecoTotal;
            this.TipoPassagem = TipoPassagem;
            this.QtdPassagem = QtdPassagem;
            this.EmbarqueIDA = EmbarqueIDA;
            this.DataIDA = DataIDA;
            this.HoraIDA = HoraIDA;
            this.EmbarqueVOLTA = EmbarqueVOLTA;
            this.DataVOLTA = DataVOLTA;
            this.HoraVolta = HoraVolta;
            this.ValorPassagem = ValorPassagem;
            this.NomeHotel = NomeHotel;
            this.ValorHotel = ValorHotel;
        }

        public static class GerarIDViagem
        {
            private static int currentID = 0;
            public static int GenerateID()
            {
                return ++currentID;
            }
        }
    }


}
