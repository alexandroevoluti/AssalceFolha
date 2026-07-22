using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.ScriptGenerator;

namespace AssalceFolha.Entity
{
    [TableName("SCACNV")]
    public class Conveniado : EntityBase<Conveniado>
    {
        [GeneratorKey(TypeGeneratorKey.Natural)]
        [TableField(true, IsRequired = true, IsKey = true, FillCritical = "Informe o código !", NameField = "CNVCOD")]
        //[TableField(true, IsIdentity = true, NameField = "CNVCOD")]
        public string ID { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o  nome do conveniado !", NameField = "CNVRAZ")]
        public string Nome { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o  endereço do conveniado !", NameField = "CNVEND")]
        public string Endereco { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o  bairro do conveniado !", NameField = "CNVBAI")]
        public string Bairro { get; set; }

        [TableField(true, NameField = "CNVCID")]
        public string Cidade { get; set; }

        [TableField(true, NameField = "CNVEST")]
        public string Estado { get; set; }

        [TableField(true, NameField = "CNVCEP")]
        public string CEP { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o telefone do conveniado !", NameField = "CNVFON")]
        public string Telefone { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o contato do conveniado !", NameField = "CNVCON")]
        public string Contato { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o parcelamento do conveniado  !", NameField = "CNVCPG")]
        public string Ativo { get; set; }

        [TableField(true, IsRequired = true,AllowZero =false, FillCritical = "Informe a verba do conveniado  !", NameField = "CNVVRB")]
        public string Verba { get; set; }
        
        [TableField(true, IsRequired = true, FillCritical = "Informe a taxa do conveniado !", NameField = "CNVTXA")]
        public double Taxa{ get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o CNPJ do conveniado !", NameField = "CNVCGC")]
        public string CNPJ{ get; set; }

        [TableField(false)]
        public Convenio Convenio { get; set; }
    }
}
