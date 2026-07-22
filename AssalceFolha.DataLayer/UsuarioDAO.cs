using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.Entity;
using AssalceFolha.ErrorHandling;

namespace AssalceFolha.DataLayer
{
    public class UsuarioDAO : EntidadeDAO<Usuario>
    {
        public Usuario Selecionar(string _login)
        {
            try
            {
                string _sql;
               _sql = " SELECT * FROM USUARIOS WHERE LOGIN = '" + _login.ToString() + "' ";

                return base.RetornarEntidadeDe(_sql);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }
    }
}
