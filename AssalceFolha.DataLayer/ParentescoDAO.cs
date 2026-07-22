using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.Entity;

namespace AssalceFolha.DataLayer
{
    public class ParentescoDAO : EntidadeDAO<Parentesco>
    {
        public Parentesco Selecionar(string _descricao)
        {
            try
            {
                string _sql = " SELECT * FROM TB_PARENTESCO WHERE DE_PARENTESCO = '" + _descricao + "' ";
                return RetornarEntidadeDe(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
    }
}
