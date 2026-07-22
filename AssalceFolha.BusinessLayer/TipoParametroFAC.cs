using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AssalceFolha.ErrorHandling;
using AssalceFolha.DataLayer;
using AssalceFolha.Entity;

namespace AssalceFolha.BusinessLayer
{
    public class TipoParametroFAC
    {
        TipoParametroDAO _tipoParametroDAO = new TipoParametroDAO();

        public TipoParametro Selecionar(int _id)
        {
            try
            {
                return _tipoParametroDAO.Selecionar(_id);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public TipoParametro Salvar(TipoParametro _tipoParametro)
        {
            try
            {
                if (_tipoParametro.ID.Equals(0))
                {
                    return _tipoParametroDAO.Incluir(_tipoParametro);
                }
                else
                {
                    _tipoParametroDAO.Alterar(_tipoParametro);
                    return _tipoParametro;
                }
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }
        public void Excluir(TipoParametro _tipoParametro)
        {
            try
            {
                _tipoParametroDAO.Excluir(_tipoParametro);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }
        public List<TipoParametro> Listar()
        {
            try
            {
                return _tipoParametroDAO.Listar();
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

    }
}
