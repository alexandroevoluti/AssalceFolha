using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using AssalceFolha.Entity;
using AssalceFolha.ErrorHandling;
using System.Configuration;

namespace AssalceFolha.DataLayer
{
    public class _BaseDAO
    {
        private const string _NivelIsolamento = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; ";
        private const string _timeZone = "SET time_zone = '-03:00'; ";

        private void SetTimeZone(MySqlConnection _conn)
        {
            try
            {
                MySqlCommand lComando = new MySqlCommand(_timeZone, _conn);
                lComando.CommandTimeout = _conn.ConnectionTimeout;

                lComando.ExecuteNonQuery();
            }
            catch (Exception ERRO)
            {                
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ERRO, "");
            }
        }

        public void ExecutarSQL(string pSQL)
        {
            
            _Conexao o_Conexao = _Conexao.Instancia();
            MySqlCommand lComando = new MySqlCommand(pSQL.ToLower(), o_Conexao.Conexao);
            lComando.Transaction = o_Conexao.Transacao;

            try
            {
                SetTimeZone(o_Conexao.Conexao);
                lComando.ExecuteNonQuery();
            }
            catch (Exception ERRO)
            {
                o_Conexao.FecharConexao(true);
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ERRO,"");
            }
            finally
            {
                o_Conexao.FecharConexao(false);
            }
        }

        public void ExecutarSQL(string pSQL, MySqlConnection con, MySqlTransaction tran)
        {
            MySqlCommand lComando = new MySqlCommand(pSQL, con);
            lComando.CommandTimeout = con.ConnectionTimeout;

            lComando.Transaction = tran;

            try
            {
                SetTimeZone(con);
                lComando.ExecuteNonQuery();
            }
            catch (Exception ERRO)
            {
                throw ERRO;
            }
        }

        public void ExecutarSQL(string pSQL, IList listaParametro)
        {
            _Conexao o_Conexao = _Conexao.Instancia();
            MySqlCommand lComando = new MySqlCommand(pSQL.ToLower(), o_Conexao.Conexao);
            lComando.CommandTimeout = o_Conexao.Conexao.ConnectionTimeout;

            MySqlParameter oParametro;

            try
            {
                foreach (MySqlParameter oParametro_TEMP in listaParametro)
                {
                    oParametro = oParametro_TEMP;
                    if (oParametro.Value == null)
                    {
                        oParametro.Value = DBNull.Value;
                    }

                    lComando.Parameters.Add(oParametro);
                }

                lComando.Transaction = o_Conexao.Transacao;

                SetTimeZone(o_Conexao.Conexao);

                lComando.ExecuteNonQuery();

            }
            catch (Exception ERRO)
            {
                o_Conexao.FecharConexao(true);
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ERRO,"");
            }
            finally
            {
                o_Conexao.FecharConexao(false);
            }
        }

        public void ExecutarSQL(string pSQL, IList listaParametro, MySqlConnection con, MySqlTransaction tran)
        {
            MySqlCommand lComando = new MySqlCommand(pSQL, con);
            lComando.CommandTimeout = con.ConnectionTimeout;

            SetTimeZone(con);
            MySqlParameter oParametro;

            try
            {
                foreach (MySqlParameter oParametro_TEMP in listaParametro)
                {
                    oParametro = oParametro_TEMP;
                    if (oParametro.Value == null)
                    {
                        oParametro.Value = DBNull.Value;
                    }

                    lComando.Parameters.Add(oParametro);
                }

                lComando.Transaction = tran;

                lComando.ExecuteNonQuery();

            }
            catch (Exception ERRO)
            {
                throw ERRO;
            }
        }

        public DataSet ExecutarSELECT(string pSQL, bool _lower = true)
        {
            DataSet lDS = new DataSet();

            try
            {
                using (MySqlConnection o_Conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["STRConexao"].ConnectionString))
                {
                    o_Conexao.Open();

                    SetTimeZone(o_Conexao);

                    string _sql = _NivelIsolamento + (_lower? pSQL.ToLower(): pSQL);

                    MySqlDataAdapter lDA = new MySqlDataAdapter(_sql, o_Conexao);
                    lDA.SelectCommand.CommandTimeout = o_Conexao.ConnectionTimeout;
                    lDA.Fill(lDS);

                    lDA.Dispose();

                    o_Conexao.Close();
                    o_Conexao.Dispose();
                }
            }
            catch (Exception ERRO)
            {
                //o_Conexao.FecharConexao_SELECT();
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ERRO, "");
            }
            finally
            {
                //o_Conexao.FecharConexao_SELECT();
            }

            return (lDS);
        }

        public bool TestaConexao()
        {
            try
            {
                using (MySqlConnection o_Conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["STRConexao"].ConnectionString))
                {
                    if (o_Conexao.State == ConnectionState.Open) o_Conexao.Close();

                    o_Conexao.Open();
                    
                    var _teste = o_Conexao.State == ConnectionState.Open;

                    o_Conexao.Close();
                    o_Conexao.Dispose();

                    return _teste;
                }
            }
            catch
            {
                return false;
            }
        }

        public DateTime HorarioBanco()
        {
            try
            {
                using (MySqlConnection o_Conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["STRConexao"].ConnectionString))
                {
                    if (o_Conexao.State == ConnectionState.Open) o_Conexao.Close();

                    o_Conexao.Open();

                    DateTime _data = _util.ConvertDateTime(ExecutarSELECT_Escalar(" SELECT NOW() "));
                    o_Conexao.Close();
                    o_Conexao.Dispose();

                    o_Conexao.Close();
                    o_Conexao.Dispose();

                    return _data;
                    //return _util.ConvertDateTime(ExecutarSELECT_Escalar(" SELECT NOW() "));
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object ExecutarSELECT_Escalar(string pSQL, IList listaParametro)
        {
            //_ConexaoSelect o_Conexao = new _ConexaoSelect(); ;
            object oRETORNO = null;
            try
            {
                using (MySqlConnection o_Conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["STRConexao"].ConnectionString))
                {
                    o_Conexao.Open();

                    MySqlCommand lComando = new MySqlCommand(_NivelIsolamento + pSQL.ToLower(), o_Conexao);
                    lComando.CommandTimeout = o_Conexao.ConnectionTimeout;

                    MySqlParameter oParametro;


                    foreach (MySqlParameter oParametro_TEMP in listaParametro)
                    {
                        oParametro = oParametro_TEMP;
                        if (oParametro.Value == null)
                        {
                            oParametro.Value = DBNull.Value;
                        }

                        lComando.Parameters.Add(oParametro);
                    }

                    SetTimeZone(o_Conexao);
                    oRETORNO = lComando.ExecuteScalar();

                    o_Conexao.Close();
                    o_Conexao.Dispose();
                }
            }
            catch (Exception ERRO)
            {
                //o_Conexao.FecharConexao_SELECT();
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ERRO, "");
            }
            finally
            {
                //o_Conexao.FecharConexao_SELECT();
            }

            return oRETORNO;
        }

        public object ExecutarSELECT_Escalar(string pSQL)
        {
            object oRETORNO = null;
            //_ConexaoSelect o_Conexao = new _ConexaoSelect(); ;
            try
            {
                using (MySqlConnection o_Conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["STRConexao"].ConnectionString))
                {
                    o_Conexao.Open();

                    MySqlCommand lComando = new MySqlCommand(_NivelIsolamento + pSQL.ToLower(), o_Conexao);
                    lComando.CommandTimeout = o_Conexao.ConnectionTimeout;

                    SetTimeZone(o_Conexao);

                    oRETORNO = lComando.ExecuteScalar();

                    o_Conexao.Close();
                    o_Conexao.Dispose();
                }
            }
            catch (Exception ERRO)
            {
                //o_Conexao.FecharConexao_SELECT();
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ERRO, "");
            }
            finally
            {
                // o_Conexao.FecharConexao_SELECT();
            }


            return oRETORNO;
        }
        public void ExecutarPROCEDURE(string pNomeProcedure, IList listaParametro)
        {
            try
            {
                //_Conexao o_Conexao = _Conexao.Instancia();
                using (MySqlConnection o_Conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["STRConexao"].ConnectionString))
                {
                    o_Conexao.Open();

                    MySqlCommand lComando = new MySqlCommand(pNomeProcedure.ToLower(), o_Conexao);
                    lComando.CommandTimeout = o_Conexao.ConnectionTimeout;

                    MySqlParameter oParametro;


                    foreach (MySqlParameter oParametro_TEMP in listaParametro)
                    {
                        oParametro = oParametro_TEMP;
                        if (oParametro.Value == null)
                        {
                            oParametro.Value = DBNull.Value;
                        }

                        lComando.Parameters.Add(oParametro);
                    }

                    lComando.CommandType = CommandType.StoredProcedure;

                    SetTimeZone(o_Conexao);

                    lComando.ExecuteNonQuery();

                    o_Conexao.Close();
                    o_Conexao.Dispose();
                }
            }
            catch (Exception ERRO)
            {
                //o_Conexao.FecharConexao_SELECT();
                //o_Conexao.FecharConexao(true);
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ERRO, "Procedure: " + pNomeProcedure);
            }
            finally
            {
                //o_Conexao.FecharConexao(false);
            }
        }

        public void ExecutarPROCEDURE(string pNomeProcedure, IList listaParametro, MySqlConnection con, MySqlTransaction tran)
        {
            try
            {
                    MySqlCommand lComando = new MySqlCommand(pNomeProcedure.ToLower(), con);
                lComando.CommandTimeout = con.ConnectionTimeout;

                MySqlParameter oParametro;
                
                    lComando.Transaction = tran;

                    foreach (MySqlParameter oParametro_TEMP in listaParametro)
                    {
                        oParametro = oParametro_TEMP;
                        if (oParametro.Value == null)
                        {
                            oParametro.Value = DBNull.Value;
                        }

                        lComando.Parameters.Add(oParametro);
                    }

                    lComando.CommandType = CommandType.StoredProcedure;

                    SetTimeZone(con);

                    lComando.ExecuteNonQuery();
                
            }
            catch (Exception ERRO)
            {
                //o_Conexao.FecharConexao_SELECT();
                //o_Conexao.FecharConexao(true);
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ERRO, "Procedure: " + pNomeProcedure);
            }
            finally
            {
                //o_Conexao.FecharConexao(false);
            }
        }

        public DataSet ExecutarPROCEDURE_DS(string pNomeProcedure, IList listaParametro)
        {
            try
            {
                //_Conexao o_Conexao = _Conexao.Instancia();
                using (MySqlConnection o_Conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["STRConexao"].ConnectionString))
                {
                    o_Conexao.Open();

                    MySqlCommand lComando = new MySqlCommand(pNomeProcedure, o_Conexao);
                    lComando.CommandTimeout = o_Conexao.ConnectionTimeout;

                    MySqlParameter oParametro;


                    foreach (MySqlParameter oParametro_TEMP in listaParametro)
                    {
                        oParametro = oParametro_TEMP;
                        if (oParametro.Value == null)
                        {
                            oParametro.Value = DBNull.Value;
                        }

                        lComando.Parameters.Add(oParametro);
                    }

                    lComando.CommandType = CommandType.StoredProcedure;

                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = lComando;
                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    o_Conexao.Close();

                    return ds;
                }
            }
            catch (Exception)
            {
                throw;
                //o_Conexao.FecharConexao_SELECT();
                //o_Conexao.FecharConexao(true);
                //ErrorHandle oTratarErro = ErrorHandle.Instancia();
                //oTratarErro.Erro(this, ERRO, "");
            }
            finally
            {
                //o_Conexao.FecharConexao(false);
            }
        }

        private string MontarNomeTransacao()
        {
            string lTRANSACAO;

            System.Diagnostics.StackFrame stack = new System.Diagnostics.StackFrame(2);
            lTRANSACAO = this.ToString() + " - " + stack.GetMethod().ToString();

            return lTRANSACAO;
        }
        public void BEGIN_TRANSACTION()
        {
            _Conexao o_Conexao = _Conexao.Instancia();
            o_Conexao.BeginTransaction(MontarNomeTransacao());
        }
        public void COMMIT()
        {
            try
            {
                _Conexao o_Conexao = _Conexao.Instancia();
                o_Conexao.Commit(MontarNomeTransacao());
            }
            catch (Exception ERRO)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ERRO,"");
            }
        }
        public void ROLLBACK()
        {
            try
            {
                _Conexao o_Conexao = _Conexao.Instancia();
                o_Conexao.Rollback();
            }
            catch (Exception ERRO)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ERRO,"");
            }
        }
        //// #################################################################################################
        //// #################################################################################################
        //// CONTROLE DE LOG
        //// #################################################################################################
        //// #################################################################################################
        //private LOG_Tabela _BaseDAO_oLOG_Tabela = null;
        //private string _BaseDAO_NomeTabelaLogada;

        //public string BaseDAO_NomeTabelaLogada
        //{
        //    get { return _BaseDAO_NomeTabelaLogada; }
        //    set { _BaseDAO_NomeTabelaLogada = value; }
        //}
        //public LOG_Tabela BaseDAO_TabelaLogada()
        //{
        //    if (_BaseDAO_oLOG_Tabela == null)
        //    {
        //        LOG_TabelaDAO oLOG_TabelaDAO = new LOG_TabelaDAO();
        //        _BaseDAO_oLOG_Tabela = oLOG_TabelaDAO.Selecionar(_BaseDAO_NomeTabelaLogada);
        //    }

        //    return _BaseDAO_oLOG_Tabela;
        //}
        //// #################################################################################################
        //// #################################################################################################
        //// FIM CONTROLE DE LOG
        //// #################################################################################################
        //// #################################################################################################
    }
}
