using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.DataLayer;
using AssalceFolha.Entity;

namespace AssalceFolha.BusinessLayer
{
    public class ParentescoFAC
    {
        ParentescoDAO _parentescoDAO = new ParentescoDAO();

        public Parentesco Selecionar(int _id)
        {
            try
            {
                return _parentescoDAO.Selecionar(_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Parentesco Selecionar(string _descricao)
        {
            try
            {
                return _parentescoDAO.Selecionar(_descricao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Parentesco> Listar()
        {
            try
            {
                return _parentescoDAO.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Parentesco Salvar(Parentesco _parentesco)
        {
            try
            {
                Parentesco entidade = _parentesco;
                if (entidade.ID.Equals(0))
                {
                    entidade = _parentescoDAO.Incluir(entidade);
                }
                else
                {
                    _parentescoDAO.Alterar(entidade);
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
