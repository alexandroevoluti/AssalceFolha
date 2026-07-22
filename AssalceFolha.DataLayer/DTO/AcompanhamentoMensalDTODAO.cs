using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.Entity;
using AssalceFolha.ErrorHandling;
using MySql.Data.MySqlClient;
using AssalceFolha.Entity.DTO;

namespace AssalceFolha.DataLayer.DTO
{
    public class AcompanhamentoMensalDTODAO : EntidadeDAO<AcompanhamentoMensalDTO>
    {
        public List<AcompanhamentoMensalDTO> Listar(int _competencia)
        {
            try
            {
                string _procedure = "PR_ACOMPANHAMENTO_MESNAL";

                List<MySqlParameter> _parametros = new List<MySqlParameter>();
                _parametros.Add(new MySqlParameter("@VAR_COMPETENCIA", _competencia));

                DataSet _ds = ExecutarPROCEDURE_DS(_procedure, _parametros);

                return base.RetornarListaDe(_ds);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }
        
    }
}
