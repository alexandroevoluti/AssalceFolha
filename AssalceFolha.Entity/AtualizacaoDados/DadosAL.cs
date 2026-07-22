using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.ScriptGenerator;

namespace AssalceFolha.Entity.AtualizacaoDados
{
    [TableName("TMP")]
    public class DadosAL : EntityBase<DadosAL>
    {
        [TableField(true, NameField = "MATR")]
        public string MATR { get; set; }
        [TableField(true, NameField = "FOLHA")]
        public string FOLHA { get; set; }
        [TableField(true, NameField = "NOME")]
        public string NOME { get; set; }
        [TableField(true, NameField = "CARFUN")]
        public string CARFUN { get; set; }
        [TableField(true, NameField = "LOTACAO")]
        public string LOTACAO { get; set; }
        [TableField(true, NameField = "NASC")]
        public string NASC { get; set; }
        [TableField(true, NameField = "ENTROU_AL")]
        public string ENTROU_AL { get; set; }
        [TableField(true, NameField = "SANGUE")]
        public string SANGUE { get; set; }
        [TableField(true, NameField = "SEXO")]
        public string SEXO { get; set; }
        [TableField(true, NameField = "CPF")]
        public string CPF { get; set; }
        [TableField(true, NameField = "RG")]
        public string RG { get; set; }
        [TableField(true, NameField = "ORG_EXP")]
        public string ORG_EXP { get; set; }
        [TableField(true, NameField = "RG_UF")]
        public string RG_UF { get; set; }
        [TableField(true, NameField = "DATA_EXP")]
        public string DATA_EXP { get; set; }
        [TableField(true, NameField = "NATURALDE")]
        public string NATURALDE { get; set; }
        [TableField(true, NameField = "PAI")]
        public string PAI { get; set; }
        [TableField(true, NameField = "MAE")]
        public string MAE { get; set; }
        [TableField(true, NameField = "CONJUGE")]
        public string CONJUGE { get; set; }
        [TableField(true, NameField = "ENDERECO")]
        public string ENDERECO { get; set; }
        [TableField(true, NameField = "NUM")]
        public string NUM { get; set; }
        [TableField(true, NameField = "COMPL")]
        public string COMPL { get; set; }
        [TableField(true, NameField = "BAIRRO")]
        public string BAIRRO { get; set; }
        [TableField(true, NameField = "CEP")]
        public string CEP { get; set; }
        [TableField(true, NameField = "CIDADE")]
        public string CIDADE { get; set; }
        [TableField(true, NameField = "UF")]
        public string UF { get; set; }
        [TableField(true, NameField = "FONE")]
        public string FONE { get; set; }
        [TableField(true, NameField = "CELULAR")]
        public string CELULAR { get; set; }
        [TableField(true, NameField = "EMAIL")]
        public string EMAIL { get; set; }
        [TableField(true, NameField = "FOTO")]
        public byte[] FOTO { get; set; }      

    }
}
