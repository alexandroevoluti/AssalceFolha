using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssalceFolha.Entity.DTO
{
    public class ValoresCobrancaUNIMEDDTO
    {
        public string Competencia { get; set; }
        public double Mensalidade { get; set; }
        public double Adicional { get; set; }
        public double TaxaAdesao { get; set; }
        public double Desconto { get; set; }
        public double ValorCobrado { get; set; }
    }
}
