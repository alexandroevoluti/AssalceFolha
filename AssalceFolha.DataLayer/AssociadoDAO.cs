using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.Entity;
using AssalceFolha.ErrorHandling;
using MySql.Data.MySqlClient;

namespace AssalceFolha.DataLayer
{
    public class AssociadoDAO : EntidadeDAO<Associado>
    {

        public Associado SelecionarMatriculaAnterior(int _matricula)
        {
            try
            {
                string _sql;

                if (_matricula.Equals(0))
                    _sql = " SELECT * FROM ASSOCIADOS WHERE CONVERT(MATR,UNSIGNED INTEGER) = 0 ";
                else
                    _sql = " SELECT * FROM ASSOCIADOS WHERE CONVERT(MATR,UNSIGNED INTEGER) < " + _matricula.ToString() + " ORDER BY CONVERT(MATR,UNSIGNED INTEGER) DESC LIMIT 1 ";

                return base.RetornarEntidadeDe(_sql);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public bool AssociadoForaFolha(int _matricula)
        {
            try
            {
                string _sql;

                _sql = " SELECT * FROM ASSOCIADOS WHERE CONVERT(MATR,UNSIGNED INTEGER) = " + _matricula.ToString()  + " AND SITUACAO = 'FORA DE FOLHA' ";
                int _cont = _util.ConvertInt(ExecutarSELECT_Escalar(_sql));

                return _cont > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Associado SelecionarProximaMatricula(int _matricula)
        {
            try
            {
                string _sql = " SELECT * FROM ASSOCIADOS WHERE CONVERT(MATR,UNSIGNED INTEGER) > " + _matricula.ToString() + " ORDER BY CONVERT(MATR,UNSIGNED INTEGER) LIMIT 1 ";

                return base.RetornarEntidadeDe(_sql);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public Associado SelecionarPorMatricula(string _matricula)
        {
            try
            {
                string _sql = " SELECT * FROM ASSOCIADOS WHERE CONVERT(MATR,UNSIGNED INTEGER) = " + _util.ConvertInt(_matricula).ToString();

                return base.RetornarEntidadeDe(_sql);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public Associado SelecionarPorCPF(string _cpf)
        {
            try
            {
                string _sql = " SELECT * FROM ASSOCIADOS WHERE CPF = " + _util.SomenteNumeros(_cpf).ToString();

                return base.RetornarEntidadeDe(_sql);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public List<Associado> Listar(string _nome)
        {
            try
            {
                string _sql = " SELECT * FROM ASSOCIADOS WHERE NOME LIKE '%" + _nome.Trim().Replace(" ", "%") + "%' ";
                _sql += " ORDER BY NOME ";

                return base.RetornarListaDe(_sql);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public List<Associado> Listar(string _folhas, string _situacao, string _situacaoDRH, int _sexo, bool _incluirExclidos)
        {
            try
            {


                string _sql = " SELECT * FROM ASSOCIADOS ";
                _sql += " WHERE FOLHA IN (" + _folhas + ") ";
                if (_situacao != "") _sql += " AND SITUACAO IN (" + _situacao + ") ";
                if (_situacaoDRH != "") _sql += " AND SITDRH IN (" + _situacaoDRH + ") ";
                if (_sexo.Equals(1) || _sexo.Equals(2)) _sql += " AND sexo = '" + (_sexo.Equals(1) ? "M" : "F") + "'";
                if (!_incluirExclidos) _sql += " AND EXCLUSAO IS NULL";
                _sql += " ORDER BY NOME ";

                return base.RetornarListaDe(_sql);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public double TotalUtilizado(int _matricula, int _folha, int _mes, int _ano)
        {
            try
            {
                DateTime _data = new DateTime(_ano, _mes, 1);

                string _sql = " SELECT SUM(VALOR) AS TOTAL ";
                _sql += " FROM( ";
                _sql += " SELECT EMP_V_PARC AS VALOR, EMPMAT AS MATR, FOLHA ";
                _sql += " FROM SCAEMP ";
                _sql += " WHERE CONVERT(EMPMAT,UNSIGNED INTEGER) = " + _matricula.ToString();
                _sql += " AND CONVERT(FOLHA, UNSIGNED INTEGER) = " + _folha.ToString();
                _sql += " AND((((EMP_DAT_I <= '" + _data.ToString("yyyy-MM-dd") + "' AND EMP_DAT_F >= '" + _data.ToString("yyyy-MM-dd") + "') ";
                _sql += "     OR(EMP_DAT_I <= '" + _data.ToString("yyyy-MM-dd") + "' AND ISNULL(EMP_DAT_F)) ";
                _sql += "     OR(ISNULL(EMP_DAT_I)  AND EMP_DAT_F >= '" + _data.ToString("yyyy-MM-dd") + "') ";
                _sql += "     OR(ISNULL(EMP_DAT_I)  AND ISNULL(EMP_DAT_F))))  ";
                _sql += "     AND ST = 'I') ";
                _sql += " UNION ";
                _sql += " SELECT SUM(VALORDES) AS VALOR, MATRI AS MATR, FOLHA ";
                _sql += " FROM SCAMOV ";
                _sql += " WHERE CONVERT(MATRI,UNSIGNED INTEGER) = " + _matricula.ToString();
                _sql += " AND CONVERT(FOLHA,UNSIGNED INTEGER) = " + _folha.ToString();
                _sql += " AND MES = " + _mes.ToString();
                _sql += " AND ANO = " + _ano.ToString();
                _sql += " AND ST = 'I') RS1 ";

                return _util.ConvertDouble(ExecutarSELECT_Escalar(_sql));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public double TotalComanda(int _matricula, int _folha, int _mes, int _ano)
        {
            try
            {
                DateTime _data = new DateTime(_ano, _mes, 1);

                string _sql = " SELECT Sum(SCAMOV.VALORDES)AS EFETUADO ";
                _sql += " FROM SCAMOV ";
                _sql += " WHERE mes = " + _mes.ToString();
                _sql += " and ano =  " + _ano.ToString();
                _sql += " and(ST = 'I')  ";
                _sql += " and not INSTR('607,627', codconv) <> 0 ";
                _sql += " and CONVERT(MATRI,UNSIGNED INTEGER) = " + _matricula.ToString();
                _sql += " AND CONVERT(FOLHA,UNSIGNED INTEGER) = " + _folha.ToString();

                return _util.ConvertDouble(ExecutarSELECT_Escalar(_sql));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int TotalAssociados()
        {
            try
            {
                string _sql = " SELECT COUNT(*) QTDE FROM ASSOCIADOS ";

                return _util.ConvertInt(ExecutarSELECT_Escalar(_sql));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int TotalAtivos()
        {
            try
            {
                string _sql = " SELECT COUNT(*) AS ATIVOS ";
                _sql += " FROM ASSOCIADOS ";
                _sql += " WHERE INSTR('ASSOCIADO,BLOQUEADO,BLOQ. JUDICIAL', SITUACAO) ";

                return _util.ConvertInt(ExecutarSELECT_Escalar(_sql));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarFoto(Associado _associado)
        {
            try
            {
                string _sql = " UPDATE ASSOCIADOS SET FOTO = @FOTO WHERE MATR = @MATR AND FOLHA = @FOLHA ";

                List<MySqlParameter> _parametros = new List<MySqlParameter>();
                _parametros.Add(new MySqlParameter("@FOTO", _associado.Foto));
                _parametros.Add(new MySqlParameter("@MATR", _associado.Matricula));
                _parametros.Add(new MySqlParameter("@FOLHA", _associado.Folha));

                ExecutarSELECT_Escalar(_sql, _parametros);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public List<String> ListarSituacoes()
        {
            try
            {
                List<String> _lista = new List<string>();

                string _sql = " SELECT DISTINCT SITUACAO FROM ASSOCIADOS  ORDER BY SITUACAO";

                DataSet _ds = ExecutarSELECT(_sql);
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow _row in _ds.Tables[0].Rows) _lista.Add(_row["SITUACAO"].ToString());
                }

                return _lista;


            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public void AtualizarSituacao(Associado _associado, string _situacaoAnterior = null)
        {
            try
            {
                List<MySqlParameter> _parametros = new List<MySqlParameter>();

                string _sql = " UPDATE ASSOCIADOS SET SITUACAO = @SITUACAO ";

                if (_situacaoAnterior != null)
                { 
                    _sql += ", SITUACAO_ANTERIOR = @SITUACAO_ANTERIOR";
                    _parametros.Add(new MySqlParameter("@SITUACAO_ANTERIOR", _situacaoAnterior.Trim().ToUpper()));
                }
                _sql +=" WHERE MATR = @MATR AND FOLHA = @FOLHA ";

               
                _parametros.Add(new MySqlParameter("@SITUACAO", _associado.Situacao.Trim().ToUpper()));
                _parametros.Add(new MySqlParameter("@MATR", _associado.Matricula));
                _parametros.Add(new MySqlParameter("@FOLHA", _associado.Folha));

                ExecutarSELECT_Escalar(_sql, _parametros);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public void AtualizarLotacao(Associado _associado)
        {
            try
            {
                List<MySqlParameter> _parametros = new List<MySqlParameter>();

                string _sql = " UPDATE ASSOCIADOS SET LOTACAO = @LOTACAO ";                
                _sql += " WHERE MATR = @MATR ";


                _parametros.Add(new MySqlParameter("@LOTACAO", _associado.Lotacao.Trim().ToUpper()));
                _parametros.Add(new MySqlParameter("@MATR", _associado.Matricula));

                ExecutarSELECT_Escalar(_sql, _parametros);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public void AtualizarFolha(Associado _associado)
        {
            try
            {
                string _procedure = "PR_ALTERA_FOLHA";

                List<MySqlParameter> _parametros = new List<MySqlParameter>();
                _parametros.Add(new MySqlParameter("@VAR_MATRICULA", _util.PreencherMatricula(_associado.Matricula)));
                _parametros.Add(new MySqlParameter("@VAR_FOLHA", _util.PreencherFolha(_associado.Folha)));

                ExecutarPROCEDURE(_procedure, _parametros);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public void AtualizarSituacao(Associado _associado)
        {
            try
            {
                string _sql = " UPDATE ASSOCIADOS SET SITUACAO = UPPER('" + _associado.Situacao + "') WHERE MATR = " + _associado.Matricula.ToString();
                ExecutarSQL(_sql);

            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public bool Falecido(int _matricula)
        {
            string _sql = "SELECT COUNT(*) FROM ASSOCIADOS WHERE MATR = " + _matricula.ToString() + " AND SITUACAO = 'FALECIDO'";

            int _cont = _util.ConvertInt(ExecutarSELECT_Escalar(_sql));

            return _cont > 0;

        }

        protected override Associado Montar(DataRow row)
        {
            Associado entidade = null;
            try
            {
                entidade = base.Montar(row);
                entidade.Margem = new MargemDAO().Selecionar(_util.ConvertInt(entidade.Matricula), _util.ConvertInt(entidade.Folha));

            }
            catch (Exception e)
            {
                throw e;
            }
            return entidade;
        }

    }
}
