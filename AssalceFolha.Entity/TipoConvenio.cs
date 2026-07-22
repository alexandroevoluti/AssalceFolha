using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AssalceFolha.ScriptGenerator;

namespace AssalceFolha.Entity
{
    [TableName("TB_TIPO_CONVENIO")]
    public class TipoConvenio : EntityBase<TipoConvenio>
    {
        [TableField(true, IsIdentity = true, IsKey = true, NameField = "CD_TIPO_CONVENIO")]
        public int ID { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a descrição do tipo de convênio !", NameField = "DE_TIPO_CONVENIO")]
        public string Descricao { get; set; }
    }
}
