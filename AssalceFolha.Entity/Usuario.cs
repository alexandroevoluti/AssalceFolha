using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.ScriptGenerator;

namespace AssalceFolha.Entity
{
    [TableName("USUARIOS")]
    public class Usuario: EntityBase<Usuario>
    {
        [TableField(true, IsIdentity = true, IsKey = true, NameField = "CD_USUSARIO")]
        public string ID { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o  nome!", NameField = "USUARIO")]
        public string Nome { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o  login !", NameField = "Login")]
        public string Login { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o  nível de segurança !", NameField = "NIVSEG")]
        public string NivelSeguranca { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a senha !", NameField = "SENHA")]
        public string Senha { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a resenha !", NameField = "RESENHA")]
        public string Resenha { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a data !", NameField = "DATA")]
        public DateTime Data { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o status !", NameField = "ATIVO")]
        public string Ativo { get; set; }

    }
}
