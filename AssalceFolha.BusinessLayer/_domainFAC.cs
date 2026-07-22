using AssalceFolha.DataLayer;
using AssalceFolha.Entity;
using AssalceFolha.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssalceFolha.BusinessLayer
{
    public class _domainFAC
    {
        _domainDAO _domain_DAO = new _domainDAO();

        public List<_domain> Convenio(int _id = 0, string _filtro = "")
        {
            try
            {
                return _domain_DAO.Convenio(_id, _filtro);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }
    }
}
