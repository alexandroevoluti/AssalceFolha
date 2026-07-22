using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.DataLayer;
using AssalceFolha.Entity;

namespace AssalceFolha.BusinessLayer
{
    public class MargemFAC
    {
        MargemDAO _margemDAO = new MargemDAO();

        public Margem Selecionar(int _matricula, int _folha)
        {
            try
            {
                return _margemDAO.Selecionar(_matricula, _folha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Margem Selecionar(int _matricula)
        {
            try
            {
                return _margemDAO.Selecionar(_matricula);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Margem Salvar(Margem _margem)
        {
            try
            {
                return _margemDAO.Salvar(_margem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
