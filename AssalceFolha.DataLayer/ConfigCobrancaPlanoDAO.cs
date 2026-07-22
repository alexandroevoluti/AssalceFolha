using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.Entity;
using AssalceFolha.ErrorHandling;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;


namespace AssalceFolha.DataLayer
{
    public class ConfigCobrancaPlanoDAO : EntidadeDAO<ConfigCobrancaPlano>
    {
        public ConfigCobrancaPlano SelecionarPorMatricula(int _matricula)
        {
            try
            {
                string _sql = " SELECT * FROM TB_CONFIG_COBRANCA_PLANO WHERE NR_MATRICULA = " + _matricula.ToString();

                return RetornarEntidadeDe(_sql);
            }
            catch
            {

                throw;
            }
        }

        public void ExcluirAlone(ConfigCobrancaPlano _entidade)
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
                        ConfigCobrancaPlano entidade = _entidade;
                        Excluir(entidade, con, tran);

                        tran.Commit();
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
