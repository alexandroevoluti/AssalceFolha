using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.DataLayer;
using AssalceFolha.Entity;
using AssalceFolha.ErrorHandling;

namespace AssalceFolha.BusinessLayer
{
    public class FolhaFAC
    {
        FolhaDAO _folhaDAO = new FolhaDAO();

        public Folha Seleiconar(int _id)
        {
            try
            {
                return _folhaDAO.Selecionar(_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Folha> Listar()
        {
            try
            {
                return _folhaDAO.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
