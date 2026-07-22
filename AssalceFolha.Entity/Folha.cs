using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.ScriptGenerator;

namespace AssalceFolha.Entity
{
    [TableName("TB_FOLHA")]
    public class Folha : EntityBase<Folha>
    {
        [GeneratorKey(ScriptGenerator.TypeGeneratorKey.Natural)]
        [TableField(true, IsKey = true, NameField = "CD_FOLHA")]
        public int ID{ get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a folha !", NameField = "DE_FOLHA")]
        public string Nome { get; set; }
        
    }
}

