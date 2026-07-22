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
    public class RetornoFolhaFAC
    {
        RetornoFolhaDAO _retornoFolhaDAO = new RetornoFolhaDAO();

        public RetornoFolha Selecionar(int _id)
        {
            try
            {
                return _retornoFolhaDAO.Selecionar(_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RetornoFolha> Listar()
        {
            try
            {
                return _retornoFolhaDAO.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RetornoFolha> Listar(int _ano, int _mes)
        {
            try
            {
                return _retornoFolhaDAO.Listar(_ano, _mes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GravarSN(int _ano, int _mes, string _usuario)
        {
            try
            {
                if (!new EnvioFolhaFAC().ExisteEnvio(_ano, _mes)) throw new Exception("Envio não encontrado para a competência informada !");

                if (!new RetornoFolhaFAC().ExisteRegistros(_ano, _mes)) throw new Exception("Retorno não encontrado para a competência informada !");
                
                _retornoFolhaDAO.GravarSN(_ano, _mes, _usuario);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public RetornoFolha SalvarAlone(RetornoFolha _retornoFolha)
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

                        RetornoFolha _entidade = new RetornoFolha();
                        if (_entidade.ID.Equals(0))
                        {
                            _entidade = _retornoFolhaDAO.Incluir(_retornoFolha);
                        }
                        else
                        {
                            _retornoFolhaDAO.Alterar(_retornoFolha);
                        }

                        return _entidade;
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

        public List<RetornoFolha> Salvar(List<RetornoFolha> _criticasFolha)
        {
            try
            {
                List<RetornoFolha> _lista = new List<RetornoFolha>();

                foreach (RetornoFolha item in _criticasFolha)
                {
                    _lista.Add(SalvarAlone(item));
                }
                return _lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExisteRegistros(int _ano, int _mes)
        {
            try
            {
                return _retornoFolhaDAO.ExisteRegistros(_ano, _mes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
