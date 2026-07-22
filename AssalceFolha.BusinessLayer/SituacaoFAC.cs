using AssalceFolha.DataLayer;
using AssalceFolha.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssalceFolha.BusinessLayer
{
    public class SituacaoFAC
    {
        SituacaoDAO _situacaoDAO = new SituacaoDAO();

        public List<Situacao> Listar()
        {
            try
            {
                return _situacaoDAO.Listar();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
