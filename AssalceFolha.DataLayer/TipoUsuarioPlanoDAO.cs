using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.Entity;

namespace AssalceFolha.DataLayer
{
    public class TipoUsuarioPlanoDAO : EntidadeDAO<TipoUsuarioPlano>
    {
        public TipoUsuarioPlano Selecionar(string _sigla)
        {
            try
            {
                string _sql = " SELECT * FROM TB_TIPO_USUARIO_PLANO WHERE DE_SIGLA = '" + _sigla + "' ";
                return RetornarEntidadeDe(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
