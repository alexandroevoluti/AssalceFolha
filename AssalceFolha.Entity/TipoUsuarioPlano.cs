using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.ScriptGenerator;

namespace AssalceFolha.Entity
{
    [TableName("TB_TIPO_USUARIO_PLANO")]
    public class TipoUsuarioPlano : EntityBase<TipoUsuarioPlano>
    {
        [TableField(true, IsIdentity = true, IsKey = true, NameField = "CD_TIPO_USUARIO_PLANO")]
        public int ID { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a descrição do tipo de usuário !", NameField = "DE_TIPO_USUARIO_PLANO")]
        public string Descricao { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a sigla do tipo de usuário !", NameField = "DE_SIGLA")]
        public string Sigla { get; set; }
    }

}
