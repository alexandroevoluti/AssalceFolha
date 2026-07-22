using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.DataLayer;
using AssalceFolha.Entity;

namespace AssalceFolha.BusinessLayer
{
    public class TipoUsuarioPlanoFAC
    {
        TipoUsuarioPlanoDAO _tipoUsuarioPlanoDAO = new TipoUsuarioPlanoDAO();

        public TipoUsuarioPlano Selecionar(int _id)
        {
            try
            {
                return _tipoUsuarioPlanoDAO.Selecionar(_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TipoUsuarioPlano Selecionar(string _descricao)
        {
            try
            {
                return _tipoUsuarioPlanoDAO.Selecionar(_descricao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TipoUsuarioPlano> Listar()
        {
            try
            {
                return _tipoUsuarioPlanoDAO.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TipoUsuarioPlano Salvar(TipoUsuarioPlano _tipoUsuarioPlano)
        {
            try
            {
                TipoUsuarioPlano entidade = _tipoUsuarioPlano;
                if (entidade.ID.Equals(0))
                {
                    entidade = _tipoUsuarioPlanoDAO.Incluir(entidade);
                }
                else
                {
                    _tipoUsuarioPlanoDAO.Alterar(entidade);
                }

                return entidade;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
