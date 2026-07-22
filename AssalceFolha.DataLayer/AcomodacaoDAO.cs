using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.Entity;

namespace AssalceFolha.DataLayer
{
    public class AcomodacaoDAO : EntidadeDAO<Acomodacao>
    {
        public Acomodacao Selecionar(string _descricao)
        {
            try
            {
                string _sql = " SELECT * FROM TB_ACOMODACAO WHERE DE_ACOMODACAO = '" + _descricao + "' ";
                return RetornarEntidadeDe(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
