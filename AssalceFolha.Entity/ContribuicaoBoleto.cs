using AssalceFolha.ScriptGenerator;

namespace AssalceFolha.Entity
{
    [TableName("TB_CONTRIBUICAO_BOLETO")]
    public class ContribuicaoBoleto : EntityBase<ContribuicaoBoleto>
    {
        [TableField(true, IsIdentity = true, IsKey = true, NameField = "CD_CONTRIBUICAO_BOLETO")]
        public int ID { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a matrícula !", NameField = "NR_MATRICULA")]
        public int Matricula { get; set; }
        
        [TableField(true, IsRequired = true, FillCritical = "Informe o valor !", NameField = "VR_CONTRIBUICAO")]
        public double Valor { get; set; }
        
    }
}