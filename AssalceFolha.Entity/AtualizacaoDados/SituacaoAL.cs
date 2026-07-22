using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.ScriptGenerator;

namespace AssalceFolha.Entity.AtualizacaoDados
{
    [TableName("TMP")]
    public class SituacaoAL : EntityBase<SituacaoAL>
    {
        [TableField(true, NameField = "MATR")]
        public string MATR { get; set; }
        [TableField(true, NameField = "FOLHA")]
        public string FOLHA { get; set; }
        [TableField(true, NameField = "SITUACAO")]
        public string SITUACAO { get; set; }
        [TableField(true, NameField = "EM_FP")]
        public string EM_FP { get; set; }
    }
}
