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

namespace AssalceFolha.DataLayer
{
    public class RetornoFolhaDAO : EntidadeDAO<RetornoFolha>
    {
        public List<RetornoFolha> Listar(int _ano, int _mes)
        {
            try
            {
                string _sql = " SELECT * FROM TB_RETORNO_FOLHA WHERE ANO = " + _ano.ToString() + " AND MES = " + _mes.ToString();
                return RetornarListaDe(_sql);
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
                string _sql = "SELECT COUNT(*) FROM TB_RETORNO_FOLHA WHERE NR_ANO = " + _ano.ToString() + " AND NR_MES = " + _mes + ";";

                return _util.ConvertInt(ExecutarSELECT_Escalar(_sql)) > 0;
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
                using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["STRConexao"].ConnectionString))
                {
                    if (con.State == ConnectionState.Open) con.Close();
                    con.Open();

                    MySqlTransaction tran = con.BeginTransaction();
                    try
                    {
                        string _procedure = "PR_GERA_SN";
                        List<MySqlParameter> _parametros = new List<MySqlParameter>();

                        MySqlParameter _parametro = new MySqlParameter();
                        _parametro.ParameterName = "VAR_MES";
                        _parametro.Value = _mes;
                        _parametros.Add(_parametro);

                        _parametro = new MySqlParameter();
                        _parametro.ParameterName = "VAR_ANO";
                        _parametro.Value = _ano;
                        _parametros.Add(_parametro);

                        _parametro = new MySqlParameter();
                        _parametro.ParameterName = "VAR_USUARIO_RESPONSAVEL";
                        _parametro.Value = _usuario;
                        _parametros.Add(_parametro);

                        ExecutarPROCEDURE(_procedure, _parametros, con, tran);

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
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }
    }        
}
