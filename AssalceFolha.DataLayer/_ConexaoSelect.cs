using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using AssalceFolha.ErrorHandling;

namespace AssalceFolha.DataLayer
{
    public class _ConexaoSelect
    {
        private MySqlConnection _ConexaoDB_SELECT = null;
        private string _StringConexao = null;

        public _ConexaoSelect()
        {

        }

        private string StringConexao
        {
            get
            { 
                _StringConexao = ConfigurationManager.ConnectionStrings["STRConexao"].ConnectionString; 
                return (_StringConexao);
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
    }
}