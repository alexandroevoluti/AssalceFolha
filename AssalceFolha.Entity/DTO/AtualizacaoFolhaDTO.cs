using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssalceFolha.Entity.DTO
{
    public class AtualizacaoFolhaDTO
    {
        public int Matricula { get; set; }
        public int Folha { get; set; }
        public string Nome { get; set; }
        public string Lotacao { get; set; }
    }
}
