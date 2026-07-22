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
    public class CobrancaUnimedFAC
    {
        CobrancaUnimedDAO _CobrancaUnimedDAO = new CobrancaUnimedDAO();

        public CobrancaUnimed Selecionar(int _id)
        {
            try
            {
                return _CobrancaUnimedDAO.Selecionar(_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CobrancaUnimed> Listar()
        {
            try
            {
                return _CobrancaUnimedDAO.Listar();
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
                _CobrancaUnimedDAO.AtualizarCPF(_cpfAtual, _nome, _novoCPF);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CobrancaUnimed> Listar(string _nome, string _ano)
        {
            try
            {
                return _CobrancaUnimedDAO.Listar(_nome, _ano);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CobrancaUnimed> Listar(int _competencia)
        {
            try
            {
                return _CobrancaUnimedDAO.Listar(_competencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<ValoresCobrancaUnimedDTO> PesquisarValores(Associado _associao, int _ano)
        //{
        //    try
        //    {
        //        return _CobrancaUnimedDAO.PesquisarValores(_associao, _ano);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<CobrancaUnimed> IncluirAlone(List<CobrancaUnimed> _cobrancas)
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
                        var _retorno = _CobrancaUnimedDAO.Incluir(_cobrancas, con, tran);
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

        public CobrancaUnimed Salvar(CobrancaUnimed _CobrancaUnimed)
        {
            try
            {
                CobrancaUnimed entidade = _CobrancaUnimed;
                if (entidade.ID.Equals(0))
                {
                    entidade = _CobrancaUnimedDAO.Incluir(entidade);
                }
                else
                {
                    _CobrancaUnimedDAO.Alterar(entidade);
                }

                return entidade;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CobrancaUnimed> Salvar(List<CobrancaUnimed> _enviosFolha)
        {
            try
            {

                foreach (var _CobrancaUnimed in _enviosFolha)
                {
                    CobrancaUnimed entidade = _CobrancaUnimed;
                    if (entidade.ID.Equals(0))
                    {
                        entidade = _CobrancaUnimedDAO.Incluir(entidade);
                    }
                    else
                    {
                        _CobrancaUnimedDAO.Alterar(entidade);
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
                return _CobrancaUnimedDAO.ExisteEnvio(_competencia);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}

