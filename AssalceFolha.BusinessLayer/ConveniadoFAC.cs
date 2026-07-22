using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.DataLayer;
using AssalceFolha.Entity;

namespace AssalceFolha.BusinessLayer
{
    public class ConveniadoFAC
    {
        ConveniadoDAO _conveniadoDAO = new ConveniadoDAO();

        public Conveniado Selecionar(int _id)
        {
            try
            {
                return _conveniadoDAO.Selecionar(_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<Conveniado> Listar()
        {
            try
            {
                return _conveniadoDAO.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Conveniado> Listar(int _id, string _nome)
        {
            try
            {
                return _conveniadoDAO.Listar(_id, _nome);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Conveniado Salvar(Conveniado _conveniado)
        {
            try
            {

                if (!_util.ValidaCnpjCPF(_conveniado.CNPJ)) throw new Exception("CNPJ/CPF inválido !");

                //if (!_util.ValidaCnpj(_conveniado.CNPJ) && (!_util.ValidaCPF(_conveniado.CNPJ))) throw new Exception("CNPJ inválido !");

                Conveniado _retorno = new ConveniadoDAO().Selecionar(_util.ConvertInt(_conveniado.ID));

                if (_retorno == null)
                {
                    _retorno = _conveniadoDAO.Incluir(_conveniado);
                }
                else
                {                    
                    _conveniadoDAO.Alterar(_conveniado);
                    _retorno = _conveniado;
                }

                return _retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(Conveniado _conveniado)
        {
            try
            {
                _conveniadoDAO.Excluir(_conveniado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
