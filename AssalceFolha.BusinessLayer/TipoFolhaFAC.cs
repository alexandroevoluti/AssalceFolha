using AssalceFolha.DataLayer;
using AssalceFolha.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssalceFolha.BusinessLayer
{
    public class TipoFolhaFAC
    {
        TipoFolhaDAO _tipoFolhaDAO = new TipoFolhaDAO();

        public List<TipoFolha> Listar()
        {
            try
            {
                return _tipoFolhaDAO.Listar();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
