using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.DataLayer;
using AssalceFolha.Entity;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using AssalceFolha.ErrorHandling;
using AssalceFolha.Entity.DTO;

namespace AssalceFolha.BusinessLayer
{
    public class CobrancaHapVidaFAC
    {
        CobrancaHapVidaDAO _cobrancaHapVidaDAO = new CobrancaHapVidaDAO();

        public CobrancaHapVida Selecionar(int _id)
        {
            try
            {
                return _cobrancaHapVidaDAO.Selecionar(_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CobrancaHapVida> Listar()
        {
            try
            {
                return _cobrancaHapVidaDAO.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarCPF(string _cpfAtual, string _nome, string _novoCPF)
        {
            try
            {
                _cobrancaHapVidaDAO.AtualizarCPF(_cpfAtual, _nome, _novoCPF);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CobrancaHapVida> Listar(string _nome, string _ano)
        {
            try
            {
                return _cobrancaHapVidaDAO.Listar(_nome, _ano);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CobrancaHapVida> Listar(int _competencia)
        {
            try
            {
                return _cobrancaHapVidaDAO.Listar(_competencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ValoresCobrancaHapVidaDTO> PesquisarValores(Associado _associao, int _ano)
        {
            try
            {
                return _cobrancaHapVidaDAO.PesquisarValores(_associao, _ano);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CobrancaHapVida> IncluirAlone(List<CobrancaHapVida> _cobrancas)
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
                        var _retorno = _cobrancaHapVidaDAO.Incluir(_cobrancas, con, tran);
                        tran.Commit();

                        return _retorno;

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

        public CobrancaHapVida Salvar(CobrancaHapVida _cobrancaHapVida)
        {
            try
            {
                CobrancaHapVida entidade = _cobrancaHapVida;
                if (entidade.ID.Equals(0))
                {
                    entidade = _cobrancaHapVidaDAO.Incluir(entidade);
                }
                else
                {
                    _cobrancaHapVidaDAO.Alterar(entidade);
                }

                return entidade;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CobrancaHapVida> Salvar(List<CobrancaHapVida> _enviosFolha)
        {
            try
            {

                foreach (var _cobrancaHapVida in _enviosFolha)
                {
                    CobrancaHapVida entidade = _cobrancaHapVida;
                    if (entidade.ID.Equals(0))
                    {
                        entidade = _cobrancaHapVidaDAO.Incluir(entidade);
                    }
                    else
                    {
                        _cobrancaHapVidaDAO.Alterar(entidade);
                    }
                }

                return _enviosFolha;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExisteEnvio(int _competencia)
        {
            try
            {
                return _cobrancaHapVidaDAO.ExisteEnvio(_competencia);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    
    }
}

