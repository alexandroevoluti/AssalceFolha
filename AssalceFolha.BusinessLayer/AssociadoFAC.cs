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
    public class AssociadoFAC
    {
        AssociadoDAO _associadoDAO = new AssociadoDAO();

        public List<String> ListarSituacoes()
        {
            try
            {
                return _associadoDAO.ListarSituacoes();


            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public void AtualizarSituacao(Associado _associado, string _situacaoAnterior = null)
        {
            try
            {
                _associadoDAO.AtualizarSituacao(_associado, _situacaoAnterior);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public Associado SelecionarPorCPF(string _cpf)
        {
            try
            {
                return _associadoDAO.SelecionarPorCPF(_cpf);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public Associado SelecionarPorMatricula(string _matricula)
        {
            try
            {
                return _associadoDAO.SelecionarPorMatricula(_matricula);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public List<Associado> Listar(string _nome)
        {
            try
            {
                return _associadoDAO.Listar(_nome);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public List<Associado> Listar(string _folhas, string _situacao, string _situacaoDRH, int _sexo, bool _incluirExclidos)
        {
            try
            {
                return _associadoDAO.Listar(_folhas, _situacao, _situacaoDRH, _sexo, _incluirExclidos);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public Associado SelecionarMatriculaAnterior(int _matricula)
        {
            try
            {
                return _associadoDAO.SelecionarMatriculaAnterior(_matricula);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public Associado SelecionarProximaMatricula(int _matricula)
        {
            try
            {
                return _associadoDAO.SelecionarProximaMatricula(_matricula);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public Associado Salvar(Associado _associado)
        {
            try
            {
                Associado entidade = _associado;

                _associado.DataCadastro = DateTime.Now;
                _associado.Usuario = _ambiente.UsuarioLogado.Nome;

                //ValidaEntidade(entidade);

                if (entidade.ID.Equals(0))
                {
                    entidade = _associadoDAO.Incluir(entidade);
                }
                else
                {
                    _associadoDAO.Alterar(entidade);
                }

                return entidade;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Associado SalvarAlone(Associado _associado)
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
                        Associado entidade = _associado;

                        _associado.DataCadastro = DateTime.Now;
                        _associado.Usuario = _ambiente.UsuarioLogado.Nome;

                        Associado _associadoBanco = SelecionarPorMatricula(_associado.Matricula);
                        //ValidaEntidade(entidade);

                        if (_associadoBanco == null)
                        {
                            entidade = _associadoDAO.Incluir(entidade, con, tran);
                        }
                        else
                        {
                            _associadoDAO.Alterar(entidade, con, tran);
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

        public double TotalUtilizado(int _matricula, int _folha, int _mes, int _ano)
        {
            try
            {
                return _associadoDAO.TotalUtilizado(_matricula, _folha, _mes, _ano);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public double TotalComanda(int _matricula, int _folha, int _mes, int _ano)
        {
            try
            {
                return _associadoDAO.TotalComanda(_matricula, _folha, _mes, _ano);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }
        public int TotalAtivos()
        {
            try
            {
                return _associadoDAO.TotalAtivos();
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }
        public int TotalAssociados()
        {
            try
            {
                return _associadoDAO.TotalAssociados();
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public void AtualizarFoto(Associado _associado)
        {
            try
            {
                _associadoDAO.AtualizarFoto(_associado);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public void AtualizarSituacao(Associado _associado)
        {
            try
            {
                _associadoDAO.AtualizarSituacao(_associado);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public void AtualizarFolha(Associado _associado)
        {
            try
            {
                _associadoDAO.AtualizarFolha(_associado);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public void AtualizarLotacao(Associado _associado)
        {
            try
            {
                _associadoDAO.AtualizarLotacao(_associado);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }
    }
}
