

using AssalceFolha.ScriptGenerator;

namespace AssalceFolha.Entity
{
    [TableName("TB_MARGEM")]
    public class CargaMargem : EntityBase<CargaMargem>
    {
        [TableField(true, IsIdentity = true, IsKey = true, NameField = "CD_MARGEM")]
        public int ID { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o ano !", NameField = "NR_ANO")]
        public int Ano { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o Mês !", NameField = "NR_MES")]
        public int Mes { get; set; }

        [TableField(true, IsRequired = true, AllowZero =true, FillCritical = "Informe o códigoPF!", NameField = "CD_FP")]
        public int CodigoFP { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a matrícula !", NameField = "NR_MATRICULA")]
        public int Matricula { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a folha !", NameField = "NR_FOLHA")]
        public int Folha { get; set; }

        [TableField(true, AllowZero = true, IsRequired = true, FillCritical = "Informe o nome do associado !", NameField = "NM_ASSOCIADO")]
        public string Nome { get; set; }

        [TableField(true, AllowZero = true, IsRequired = true, FillCritical = "Informe o valor da margem !", NameField = "VR_MARGEM")]
        public double Margem{ get; set; }

    }
}
