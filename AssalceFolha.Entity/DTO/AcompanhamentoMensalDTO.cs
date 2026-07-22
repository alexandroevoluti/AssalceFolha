using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.ScriptGenerator;

namespace AssalceFolha.Entity.DTO
{
    [TableName("PR_ACOMPANHAMENTO_MESNAL")]
    public class AcompanhamentoMensalDTO : EntityBase<AcompanhamentoMensalDTO>
    {
        [TableField(true, NameField = "DESCRICAO")]
        public string Descricao { get; set; }

        [TableField(true, NameField = "Usuario")]
        public string Usuario{ get; set; }

        [TableField(true, NameField = "QTDE")]
        public int QTDE{ get; set; }

    }
}
