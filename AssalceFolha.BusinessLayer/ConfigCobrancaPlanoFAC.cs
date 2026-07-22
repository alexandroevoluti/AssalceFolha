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
    public class ConfigCobrancaPlanoFAC
    {
        ConfigCobrancaPlanoDAO _ConfigCobrancaPlanoDAO = new ConfigCobrancaPlanoDAO();


        public ConfigCobrancaPlano Selecionar(int _id)
        {
            try
            {
                return _ConfigCobrancaPlanoDAO.Selecionar(_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ConfigCobrancaPlano> Listar()
        {
            try
            {
                return _ConfigCobrancaPlanoDAO.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(ConfigCobrancaPlano _ConfigCobrancaPlano)
        {
            try
            {
                _ConfigCobrancaPlanoDAO.ExcluirAlone(_ConfigCobrancaPlano);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ConfigCobrancaPlano SalvarAlone(ConfigCobrancaPlano _ConfigCobrancaPlano)
        {
            try
            {

                Validar(_ConfigCobrancaPlano);

                using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["STRConexao"].ConnectionString))
                {
                    if (con.State == ConnectionState.Open) con.Close();
                    con.Open();
                    MySqlTransaction tran = con.BeginTransaction();
                    try
                    {
                        ConfigCobrancaPlano entidade = _ConfigCobrancaPlano;
                        if (entidade.ID.Equals(0))
                        {
                            entidade = _ConfigCobrancaPlanoDAO.Incluir(entidade, con, tran);
                        }
                        else
                        {
                            _ConfigCobrancaPlanoDAO.Alterar(entidade, con, tran);
                        }

                        tran.Commit();
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

        private void Validar(ConfigCobrancaPlano _ConfigCobrancaPlano)
        {
            try
            {

                Associado _associado = new AssociadoDAO().SelecionarPorMatricula(_ConfigCobrancaPlano.Matricula.ToString());
                if (_associado == null) throw new Exception("Associado não encontrado para a matrícula informada ");
                
                var _ConfigCobrancaPlanoBanco = new ConfigCobrancaPlanoDAO().SelecionarPorMatricula(_ConfigCobrancaPlano.Matricula);
                if (_ConfigCobrancaPlanoBanco != null) if (_ConfigCobrancaPlanoBanco.ID != _ConfigCobrancaPlano.ID) throw new Exception("Já existe configuração para a matrícula !");

                if (_ConfigCobrancaPlanoBanco.TipoCobrancaID.Equals(0)) throw new Exception("Informe o tipo de cobrança !");

            }
            catch
            {

            }
        }
    }
}
