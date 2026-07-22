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
    public class CriticaFolhaFAC
    {
        CriticaFolhaDAO _criticaFolhaDAO = new CriticaFolhaDAO();


        public CriticaFolha SelecionarCritica(int _competencia, string _matricula)
        {
            try
            {
                return _criticaFolhaDAO.SelecionarCritica(_competencia, _matricula);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CriticaFolha Selecionar(int _id)
        {
            try
            {
                return _criticaFolhaDAO.Selecionar(_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CriticaFolha> Listar()
        {
            try
            {
                return _criticaFolhaDAO.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CriticaFolha> Listar(int _ano, int _mes)
        {
            try
            {
                return _criticaFolhaDAO.Listar(_ano, _mes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CriticaFolha SalvarAlone(CriticaFolha _criticaFolha)
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

                        CriticaFolha _entidade = new CriticaFolha();
                        if (_entidade.ID.Equals(0))
                        {
                            _entidade = _criticaFolhaDAO.Incluir(_criticaFolha);
                        }
                        else
                        {
                            _criticaFolhaDAO.Alterar(_criticaFolha);
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

        public List<CriticaFolha> Salvar(List<CriticaFolha> _criticasFolha)
        {
            try
            {
                List<CriticaFolha> _lista = new List<CriticaFolha>();

                foreach (CriticaFolha item in _criticasFolha)
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
                return _criticaFolhaDAO.ExisteRegistros(_ano, _mes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
