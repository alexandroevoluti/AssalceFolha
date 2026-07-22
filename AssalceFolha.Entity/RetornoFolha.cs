using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.ScriptGenerator;

namespace AssalceFolha.Entity
{
    [TableName("TB_RETORNO_FOLHA")]
    public class RetornoFolha : EntityBase<RetornoFolha>
    {
        [TableField(true, IsIdentity = true, IsKey = true, NameField = "CD_RETORNO_FOLHA")]
        public int ID { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o ano !", NameField = "NR_ANO")]
        public int Ano { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o Mês !", NameField = "NR_MES")]
        public int Mes { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a matrícula !", NameField = "NR_MATRICULA")]
        public int Matricula { get; set; }

        [TableField(true, IsRequired = true, AllowZero =true, FillCritical = "Informe a folha !", NameField = "NR_FOLHA")]
        public int Folha { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o evento !", NameField = "CD_EVENTO")]
        public int ID_Evento { get; set; }

        [TableField(true, IsRequired = true, AllowZero =true, FillCritical = "Informe o valor !", NameField = "VR_RETORNO")]
        public double Valor { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o cpf !", NameField = "NR_CPF")]
        public string CPF { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o nome !", NameField = "DE_NOME")]
        public string Nome { get; set; }
    }
}
