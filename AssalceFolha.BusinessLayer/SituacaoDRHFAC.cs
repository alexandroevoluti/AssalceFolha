using AssalceFolha.DataLayer;
using AssalceFolha.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssalceFolha.BusinessLayer
{
    public class SituacaoDRHFAC
    {
        SituacaoDRHDAO _situacaoDRHDAO = new SituacaoDRHDAO();

        public List<SituacaoDRH> Listar()
        {
            try
            {
                return _situacaoDRHDAO.Listar();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
