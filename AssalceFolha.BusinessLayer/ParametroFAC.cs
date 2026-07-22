using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AssalceFolha.ErrorHandling;
using AssalceFolha.DataLayer;
using AssalceFolha.Entity;

namespace AssalceFolha.BusinessLayer
{
    public class ParametroFAC
    {
        ParametroDAO _parametroDAO = new ParametroDAO();

        public Parametro Selecionar(int _id)
        {
            try
            {
                return _parametroDAO.Selecionar(_id);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }
        public Parametro Selecionar(enumTipoParametro _tipoParamentro, DateTime _data)
        {
            try
            {
                return _parametroDAO.Selecionar(_tipoParamentro, _data);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public Parametro Selecionar(enumTipoParametro _tipoParamentro)
        {
            try
            {
                return _parametroDAO.Selecionar(_tipoParamentro, DateTime.Now);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public Parametro Salvar(Parametro _parametro)
        {
            try
            {
                if (_parametro.ID.Equals(0))
                {
                    return _parametroDAO.Incluir(_parametro);
                }
                else
                {
                    _parametroDAO.Alterar(_parametro);
                    return _parametro;
                }
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }
        public void Excluir(Parametro _parametro)
        {
            try
            {
                _parametroDAO.Excluir(_parametro);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }
        public List<Parametro> Listar()
        {
            try
            {
                return _parametroDAO.Listar();
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

    }
}
