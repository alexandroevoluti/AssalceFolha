using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.ScriptGenerator;

namespace AssalceFolha.Entity
{
    [TableName("SCAMOV")]
    public class Compra : EntityBase<Compra>
    {
        [TableField(true, IsIdentity = true, IsKey = true, NameField = "COUNT")]
        public int ID { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a matrícula !", NameField = "MATRI")]
        public string Matricula { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a folha !", NameField = "FOLHA")]
        public string Folha { get; set; }

        [TableField(true, NameField = "DATA")]
        public DateTime? Data { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o código do convênio !", NameField = "CODCONV")]
        public string ID_Convenio { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o nome do convênio !", NameField = "CONVENI")]
        public string DE_Convenio { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o evento !", NameField = "EVENTO")]
        public string Evento { get; set; }

        [TableField(true, IsRequired = true, AllowZero = false, FillCritical = "Informe o valor !", NameField = "VALORDES")]
        public Double Valor { get; set; }

        [TableField(true, NameField = "REFER")]
        public string Referencia { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o mês !", NameField = "MES")]
        public int Mes { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o ano !", NameField = "ANO")]
        public int Ano { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o status !", NameField = "ST")]
        public string Status{ get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a data do cadastro !", NameField = "DTCAD")]
        public DateTime DataCadastro { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o usuário responsável pelo cadastro !", NameField = "USUARIO")]
        public string Usuario { get; set; }

    }
}
