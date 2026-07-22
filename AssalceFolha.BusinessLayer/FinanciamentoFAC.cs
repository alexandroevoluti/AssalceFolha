using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.DataLayer;
using AssalceFolha.Entity;
using AssalceFolha.ErrorHandling;
using MySql.Data.MySqlClient;

namespace AssalceFolha.BusinessLayer
{
    public class FinanciamentoFAC
    {
        FinanciamentoDAO _financiamentoDAO = new FinanciamentoDAO();

        public Financiamento Selecionar(int _id)
        {
            try
            {
                return _financiamentoDAO.Selecionar(_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Financiamento> Listar()
        {
            try
            {
                return _financiamentoDAO.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Financiamento> Listar(int _matricula, int _folha)
        {
            try
            {
                return _financiamentoDAO.Listar(_matricula, _folha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Financiamento> Listar(Associado _associado)
        {
            try
            {
                return _financiamentoDAO.Listar(_associado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Financiamento SalvarAlone(Financiamento _financiamento)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["STRConexao"].ConnectionString))
                {
                    if (con.State == ConnectionState.Open) con.Close();
                    con.Open();
                    MySqlTransaction tran = con.BeginTransaction();
                    try
                    {
                        Financiamento entidade = _financiamento;
                        if (entidade.ID.Equals(0))
                        {
                            entidade = _financiamentoDAO.Incluir(entidade, con, tran);
                        }
                        else
                        {
                            _financiamentoDAO.Alterar(entidade, con, tran);
                        }

                        return entidade;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        ErrorHandle oTratarErro = ErrorHandle.Instancia();
                        oTratarErro.Erro(this, ex, ""); throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
