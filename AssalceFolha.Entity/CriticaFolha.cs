using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.ScriptGenerator;

namespace AssalceFolha.Entity
{
    [TableName("TB_CRITICA_FOLHA")]
    public class CriticaFolha : EntityBase<CriticaFolha>
    {
        [TableField(true, IsIdentity = true, IsKey = true, NameField = "CD_CRITICA_FOLHA")]
        public int ID { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o ano !", NameField = "NR_ANO")]
        public int Ano { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o Mês !", NameField = "NR_MES")]
        public int Mes { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a matrícula !", NameField = "NR_MATRICULA")]
        public int Matricula { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a folha !", NameField = "NR_FOLHA")]
        public int Folha { get; set; }

        [TableField(true, NameField = "CD_EVENTO")]
        public int ID_Evento { get; set; }

        [TableField(true, NameField = "VALOR")]
        public double Valor { get; set; }

        [TableField(true, NameField = "DE_REFERENCIA")]
        public string Referencia { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a crítica !", NameField = "DE_CRITICA")]
        public string Critica{ get; set; }
    }
}
