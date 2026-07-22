using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.DataLayer;
using AssalceFolha.Entity;

namespace AssalceFolha.BusinessLayer
{
    public class AcomodacaoFAC
    {
        AcomodacaoDAO _acomodacaoDAO = new AcomodacaoDAO();

        public Acomodacao Selecionar(int _id)
        {
            try
            {
                return _acomodacaoDAO.Selecionar(_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Acomodacao Selecionar(string _descricao)
        {
            try
            {
                return _acomodacaoDAO.Selecionar(_descricao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Acomodacao> Listar()
        {
            try
            {
                return _acomodacaoDAO.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Acomodacao Salvar(Acomodacao _acomodacao)
        {
            try
            {
                Acomodacao entidade = _acomodacao;
                if (entidade.ID.Equals(0))
                {
                    entidade = _acomodacaoDAO.Incluir(entidade);
                }
                else
                {
                    _acomodacaoDAO.Alterar(entidade);
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
