using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using AssalceFolha.ErrorHandling;

namespace AssalceFolha.DataLayer
{
    public class _Conexao
    {
        private static _Conexao _Instancia = null;
        private _Conexao _InstanciaSelect = null;
        private MySqlConnection _ConexaoDB_SELECT = null;
		private MySqlConnection _ConexaoDB = null;
		private MySqlTransaction _TransacaoDB = null;
		private string _StringConexao = null;
        private bool _flTransacao = false;
        private string _nmTransacao = null;

        private _Conexao()
        {
            
        }

        public static _Conexao Instancia()
        {
            if (_Instancia == null)
            {
                //lock (_Instancia)
                //{

                    if (_Instancia == null)
                    {
                        _Instancia = new _Conexao();
                    }
                //}
            }
            return(_Instancia);
        }

        public _Conexao InstanciaSelect()
        {
            _InstanciaSelect = new _Conexao();
            return (_InstanciaSelect);
        }

		private string StringConexao
		{
			get
			{
				if (_StringConexao == null)
				{
                    //string mysql
                    //connectionstring As String = String.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4};", "ServerName", 3306, "MyDatabase", "root", "password")
                    
                    
                    //_StringConexao = ConfigurationSettings.AppSettings["STRConexao"];
                    //if (_StringConexao == null)
                    //{
                        //_StringConexao = "server=SCQ002\\desenv;Trusted_Connection=no;database=DBSIREP;Integrated Security=yes;Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0";
                        _StringConexao = ConfigurationManager.ConnectionStrings["STRConexao"].ConnectionString;
                    //}
				}
				return(_StringConexao);
			}
		}

		public MySqlConnection Conexao
		{
			get
			{
				if (_ConexaoDB == null)
				{
					_ConexaoDB = new MySqlConnection (this.StringConexao);
					try
					{
						_ConexaoDB.Open();
					}
					catch (Exception ERRO)
					{
						_ConexaoDB = null;
                        LimparTransacao("");
                        ErrorHandle oTratarErro = ErrorHandle.Instancia();
                        oTratarErro.Erro(this, ERRO,"");
					}
				}
				return(_ConexaoDB);
			}
		}

        public MySqlConnection Conexao_SELECT
        {
            get
            {
                if (_ConexaoDB_SELECT == null)
                {
                    _ConexaoDB_SELECT = new MySqlConnection(this.StringConexao);
                    
                    try
                    {
                        _ConexaoDB_SELECT.Open();
                    }
                    catch (Exception ERRO)
                    {
                        _ConexaoDB_SELECT = null;
                        ErrorHandle oTratarErro = ErrorHandle.Instancia();
                        oTratarErro.Erro(this, ERRO,"");
                    }
                }
                return (_ConexaoDB_SELECT);
            }
        }

		public MySqlTransaction Transacao
		{
			get
			{
                if (_TransacaoDB == null && _flTransacao)
				{
					try
					{
						_TransacaoDB = this.Conexao.BeginTransaction();
					}
					catch(Exception ERRO)
					{
						FecharConexao(true);
                        ErrorHandle oTratarErro = ErrorHandle.Instancia();
                        oTratarErro.Erro(this, ERRO,"");
					}
				}
				return(_TransacaoDB);
			}
		}

		public void FecharConexao(bool _flERROouCOMMITouROLLBACK)
		{
			try
			{
                if (_ConexaoDB != null && (!_flTransacao || _flERROouCOMMITouROLLBACK))
				{
                    _ConexaoDB.Dispose();
                    _ConexaoDB.Close();
                    _ConexaoDB = null;
                    LimparTransacao("");
				}
			}
			catch(Exception ERRO)
			{
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ERRO,"");
			}
		}

        public void FecharConexao_SELECT()
        {
            try
            {
                if (_ConexaoDB_SELECT != null)
                {
                    _ConexaoDB_SELECT.Dispose();
                    _ConexaoDB_SELECT.Close();
                    _ConexaoDB_SELECT = null;
                }
            }
            catch (Exception ERRO)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ERRO,"");
            }
        }

        public void BeginTransaction(string pNomeTransacao)
        {
            if (!_flTransacao)
            {
                _flTransacao = true;
                _nmTransacao = pNomeTransacao;
            }
        }

        public void Commit(string pNomeTransacao)
		{
			if (_flTransacao && _nmTransacao.Equals(pNomeTransacao))
			{
				try
				{
                    LimparTransacao("Commit");
				}
				catch(Exception ERRO)
				{
                    LimparTransacao("Rollback");
					FecharConexao(true);
                    ErrorHandle oTratarErro = ErrorHandle.Instancia();
                    oTratarErro.Erro(this, ERRO,"");
				}
				finally
				{
					FecharConexao(true);
				}
			}
		}

        public void Rollback()
        {
            if (_flTransacao)
            {
                try
                {
                    LimparTransacao("Rollback");
                }
                catch (Exception ERRO)
                {
                    FecharConexao(true);
                    ErrorHandle oTratarErro = ErrorHandle.Instancia();
                    oTratarErro.Erro(this, ERRO,"");
                }
                finally
                {
                    FecharConexao(true);
                }
            }
        }

        private void LimparTransacao(string OP)
        {
            if (_TransacaoDB != null)
            {
                if (OP.Equals("Commit"))
                {
                    _TransacaoDB.Commit();
                }
                else if (OP.Equals("Rollback"))
                {
                    _TransacaoDB.Rollback();
                }
            }
            _TransacaoDB = null;
            _flTransacao = false;
            _nmTransacao = null;
        }
    }
}