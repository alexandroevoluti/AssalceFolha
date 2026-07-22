using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.DataLayer;
using AssalceFolha.Entity;
using AssalceFolha.ErrorHandling;
using MySql.Data.MySqlClient;

namespace AssalceFolha.BusinessLayer
{
    public class BancoFAC
    {
        BancoDAO _bancoDAO = new BancoDAO();

        public Banco Selecionar(int _id)
        {
            try
            {
                return _bancoDAO.Selecionar(_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Banco> Listar()
        {
            try
            {
                return _bancoDAO.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Banco> Listar(int _matricula, int _folha)
        {
            try
            {
                return _bancoDAO.Listar(_matricula, _folha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Banco> Listar(Associado _associado)
        {
            try
            {
                return _bancoDAO.Listar(_associado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Banco Salvar(Banco _banco)
        {
            try
            {
                Banco entidade = _banco;
                if (entidade.ID.Equals(0))
                {
                    entidade = _bancoDAO.Incluir(entidade);
                }
                else
                {
                    _bancoDAO.Alterar(entidade);
                }

                return entidade;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Banco SalvarAlone(Banco _banco)
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
                        Banco entidade = _banco;
                        if (entidade.ID.Equals(0))
                        {
                            entidade = _bancoDAO.Incluir(entidade, con, tran);
                        }
                        else
                        {
                            _bancoDAO.Alterar(entidade, con, tran);
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

        public List<Banco> IncluirAlone(List<Banco> _movimentos)
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
                        return _bancoDAO.Incluir(_movimentos, con, tran);
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
