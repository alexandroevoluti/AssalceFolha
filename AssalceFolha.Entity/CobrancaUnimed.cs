using AssalceFolha.ScriptGenerator;
using System;

namespace AssalceFolha.Entity
{
    [TableName("TB_COBRANCA_Unimed")]
    public class CobrancaUnimed : EntityBase<CobrancaUnimed>
    {
        [TableField(true, IsIdentity = true, IsKey = true, NameField = "CD_COBRANCA_UNIMED")]
        public int ID { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o plano !", NameField = "CD_PLANO")]
        public int PlanoID { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a competência!", NameField = "NR_COMPETENCIA")]
        public int Competencia { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a credencial !", NameField = "DE_CREDENCIAL")]
        public string Credencial { get; set; }

        [TableField(true, NameField = "NR_MATRICULA")]
        public int MatriculaUnimed { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a credencial !", NameField = "CPF")]
        public string CPF { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o nome do beneficiário!", NameField = "NM_BENEFICIARIO")]
        public string Beneficiario { get; set; }

        [TableField(true, NameField = "NM_MAE")]
        public string Mae { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a data de nascimento !", NameField = "DT_NASCIMENTO")]
        public DateTime DataNascimento { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a data de início !", NameField = "DT_INICIO")]
        public DateTime DataInicio { get; set; }

        [TableField(true, NameField = "NR_IDADE")]
        public int Idade { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o parentesco !", NameField = "DE_PARENTESCO")]
        public string Parentesco { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o plano !", NameField = "DE_PLANO")]
        public string Plano { get; set; }

        [TableField(true, NameField = "NR_AC")]
        public int AC { get; set; }

        [TableField(true, NameField = "VR_MENSALIDADE")]
        public double Mensalidade { get; set; }

        [TableField(true, NameField = "VR_ADICIONAL")]
        public double Adicional { get; set; }

        [TableField(true, NameField = "VR_TAXA_ADESAO")]
        public double TaxaAdesao { get; set; }

        [TableField(true, NameField = "VR_DESCONTO")]
        public double Desconto { get; set; }

        [TableField(true, NameField = "VR_COBRADO")]
        public double Cobrado { get; set; }

    }
}
