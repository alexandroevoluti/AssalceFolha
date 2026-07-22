using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AssalceFolha.ErrorHandling;
using AssalceFolha.DataLayer;
using AssalceFolha.Entity;

namespace AssalceFolha.BusinessLayer
{
    public class TipoConvenioFAC
    {
        TipoConvenioDAO _tipoConvenioDAO = new TipoConvenioDAO();

        public TipoConvenio Selecionar(enumTipoConvenio _enumTipoConvenio)
        {
            try
            {
                int _id = new Enumerator<enumTipoConvenio>().EnumToInt(_enumTipoConvenio);
                return _tipoConvenioDAO.Selecionar(_id);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public TipoConvenio Selecionar(int _id)
        {
            try
            {
                return _tipoConvenioDAO.Selecionar(_id);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public TipoConvenio Salvar(TipoConvenio _tipoConvenio)
        {
            try
            {
                if (_tipoConvenio.ID.Equals(0))
                {
                    return _tipoConvenioDAO.Incluir(_tipoConvenio);
                }
                else
                {
                    _tipoConvenioDAO.Alterar(_tipoConvenio);
                    return _tipoConvenio;
                }
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }
        public void Excluir(TipoConvenio _tipoConvenio)
        {
            try
            {
                _tipoConvenioDAO.Excluir(_tipoConvenio);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }
        public List<TipoConvenio> Listar()
        {
            try
            {
                return _tipoConvenioDAO.Listar();
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

    }
}
