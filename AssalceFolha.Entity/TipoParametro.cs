using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AssalceFolha.ScriptGenerator;

namespace AssalceFolha.Entity
{
    [TableName("TB_TIPO_PARAMETRO")]
    public class TipoParametro : EntityBase<TipoParametro>
    {
        [TableField(true, IsIdentity = true, IsKey = true, NameField = "CD_TIPO_PARAMETRO")]
        public int ID { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a descrição do parâmetro !", NameField = "DE_TIPO_PARAMETRO")]
        public string Descricao { get; set; }
    }
}
