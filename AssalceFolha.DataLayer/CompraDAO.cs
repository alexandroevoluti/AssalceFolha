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
    public class CompraDAO : EntidadeDAO<Compra>
    {

        public List<Compra> Listar(Associado _associado, int _ano, int _mes, bool _somenteIncluidos)
        {
            try
            {
                string _sql = " SELECT * FROM SCAMOV WHERE CONVERT(MATRI,UNSIGNED INTEGER) = " + _associado.Matricula + " AND CONVERT(FOLHA,UNSIGNED INTEGER) = " + _associado.Folha + " AND ANO = " + _ano.ToString() + " AND MES = " + _mes.ToString();
                if (_somenteIncluidos) _sql += " AND ST = 'I' ";
                _sql += " ORDER BY ANO, MES, DATA, CONVENI ";
                return RetornarListaDe(_sql);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public List<Compra> Listar(DateTime _dtCadastro)
        {
            try
            {
                string _sql = " SELECT * FROM SCAMOV WHERE dtcad = '" + _dtCadastro.ToString("yyyy-MM-dd") + "' ";
                _sql += " ORDER BY COUNT ";
                return RetornarListaDe(_sql);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public List<Compra> Incluir(List<Compra> _compras, MySqlConnection con, MySqlTransaction tran)
        {
            try
            {
                List<Compra> _retorno = new List<Compra>();

                foreach (Compra item in _compras)
                {
                    _retorno.Add(base.Incluir(item, con, tran));
                }

                GravarTxtComandas();

                return _retorno;
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        private void GravarTxtComandas()
        {
            try
            {
                List<Compra> _lista = Listar(DateTime.Now);
                var _json = JsonConvert.SerializeObject(_lista);

                string _pasta = ConfigurationManager.AppSettings["FolderCompras"];

                string _arquivo = _pasta + @"\Compras" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

                System.IO.StreamWriter file = new System.IO.StreamWriter(_arquivo);
                file.WriteLine(_json);

                file.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExistirRegistro(Compra _Compra)
        {
            try
            {
                string _sql = "SELECT * FROM SCAMOV WHERE ANO = " + _Compra.Ano.ToString() + " AND MES = " + _Compra.Mes.ToString() + " AND USUARIO = '" + _Compra.Usuario + "' ";
                return ExistirRegistro(_sql);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public void ExcluirAlone(Compra _compra)
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
                        Compra entidade = _compra;
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
