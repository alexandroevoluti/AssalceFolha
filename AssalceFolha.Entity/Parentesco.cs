using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.ScriptGenerator;

namespace AssalceFolha.Entity
{
    [TableName("TB_PARENTESCO")]
    public class Parentesco : EntityBase<Parentesco>
    {
        [TableField(true, IsIdentity = true, IsKey = true, NameField = "CD_PARENTESCO")]
        public int ID { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a descrição do parentesco !", NameField = "DE_PARENTESCO")]
        public string Descricao{ get; set; }        
    }
}
