using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssalceFolha.Entity
{
    public class RegistroFarmacia
    {
        public string Matricula { get; set; }
        public Associado Associado { get; set; }
        public Convenio Convenio { get; set; }
        public string Nome { get; set; }
        public string Referencia { get; set; }
        public DateTime? Data { get; set; }
        public string Valor { get; set; }
    }
}
