using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.ScriptGenerator;

namespace AssalceFolha.Entity
{
    [TableName("MARGEM")]
    public class Margem : EntityBase<Margem>
    {
        [TableField(true, IsIdentity = true, IsKey = true, NameField = "CD_MARGEM")]
        public int ID { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a matrícula !", NameField = "MATR")]
        public string Matricula { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a folha !", NameField = "FOLHA")]
        public string Folha { get; set; }

        [TableField(true, NameField = "MBRUTA")]
        public double MargemBruta { get; set; }

        [TableField(true, NameField = "NOME")]
        public string Nome { get; set; }

        [TableField(true, NameField = "DESCONTOS")]
        public double ValorDescontos { get; set; }

        [TableField(true,AllowZero =true, IsRequired = true, FillCritical = "Informe a margem !", NameField = "MARGEM")]
        public double ValorMargem{ get; set; }

        [TableField(true, NameField = "LIMITE")]
        public double? ValorLimite { get; set; }


    }
}
