using AssalceFolha.ScriptGenerator;

namespace AssalceFolha.Entity
{
    [TableName("TB_CONFIG_COBRANCA_PLANO")]
    public class ConfigCobrancaPlano : EntityBase<ConfigCobrancaPlano>
    {
        [TableField(true, IsIdentity = true, IsKey = true, NameField = "CD_CONFIG_COBRANCA_PLANO")]
        public int ID { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a matrícula !", NameField = "NR_MATRICULA")]
        public int Matricula { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a folha !", NameField = "NR_FOLHA")]
        public string Folha{ get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o tipo de cobrança !", NameField = "CD_TIPO_COBRANCA")]
        public int TipoCobrancaID { get; set; }

    }
}
