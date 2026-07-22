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
    public class PlanoFAC
    {
        PlanoDAO _planoDAO = new PlanoDAO();

        public Plano Selecionar(int _id)
        {
            try
            {
                return _planoDAO.Selecionar(_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Plano> Listar()
        {
            try
            {
                return _planoDAO.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Plano> Listar(int _matricula, int _folha)
        {
            try
            {
                return _planoDAO.Listar(_matricula, _folha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Plano> Listar(Associado _associado)
        {
            try
            {
                return _planoDAO.Listar(_associado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public double TotalHapVida(int _matricula, int _folha)
        {
            try
            {
                return _planoDAO.TotalConvenio(_matricula, _folha, 667);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public double TotalUnimed(int _matricula, int _folha)
        {
            try
            {
                return _planoDAO.TotalConvenio(_matricula, _folha, 641);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public double TotalConvenio(int _matricula, int _folha, int _idConvenio)
        {
            try
            {
                return _planoDAO.TotalConvenio(_matricula, _folha, _idConvenio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Plano SalvarAlone(Plano _plano)
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

                        Plano entidade = _plano;

                        ValidaEntidade(entidade);

                        if (entidade.ID.Equals(0))
                        {
                            entidade = _planoDAO.Incluir(entidade);
                        }
                        else
                        {
                            _planoDAO.Alterar(entidade);
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

        private void ValidaEntidade(Plano entidade)
        {
            try
            {
                _util.ValidarPeriodo(entidade.DataInicio.ToShortDateString(), _util.FormatarData(entidade.DataTermino, _util.enumFormatoData.Data), false);

                if (entidade.DataNascimento > DateTime.Now) throw new Exception("Data de nascimento inválida !");

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
