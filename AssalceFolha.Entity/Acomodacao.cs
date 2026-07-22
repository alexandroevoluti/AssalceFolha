using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.ScriptGenerator;

namespace AssalceFolha.Entity
{
    [TableName("TB_ACOMODACAO")]
    public class Acomodacao : EntityBase<Acomodacao>
    {
        [TableField(true, IsIdentity = true, IsKey = true, NameField = "CD_ACOMODACAO")]
        public int ID { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a descrição da acomodação !", NameField = "DE_ACOMODACAO")]
        public string Descricao { get; set; }
    }
}
