using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.Entity;
using MySql.Data.MySqlClient;

namespace AssalceFolha.DataLayer
{
    public class RelatoriosDAO : _BaseDAO
    {
        public DataSet Logo()
        {
            try
            {
                string _sql = "SELECT * FROM LOGOMARCA LIMIT 1";
                return ExecutarSELECT(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ConferenciaCargaArquivoFolha(int _competencia)
        {
            try
            {
                string _sql = "CALL assalce.PR_RELATORIO_CONFERENCIA_CARGA(" + _competencia.ToString() + ", '', '')";
                return ExecutarSELECT(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Mapa(int _competencia)
        {
            try
            {
                int _ano = _util.ConvertInt(_competencia.ToString().Trim().Substring(0, 4));
                int _mes = _util.ConvertInt(_competencia.ToString().Trim().Substring(4, 2));
                string _sql = "CALL PR_RELATORIO_MAPA( " + _ano.ToString() + ", " + _mes.ToString() + ") ";
                return ExecutarSELECT(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ConvenioCompetencia(Convenio _convenio, int _competencia)
        {
            try
            {
                DateTime _dtInicio = _util.PrimeiroDiaMes(_competencia);
                DateTime _dtFim = _util.UltimoDiaMes(_competencia);


                string _sql = " select * from VW_RELATORIO_CONVENIO_COMPETENCIAS ";
                _sql += " where CD_CONVENIO = " + _convenio.ID.ToString();
                _sql += " and  ST = 'I'";
                _sql += " AND IFNULL(DT_INICIO, '" + _dtFim.ToString("yyyy-MM-dd") + "') <= '" + _dtFim.ToString("yyyy-MM-dd") + "' ";
                _sql += " AND IFNULL(DT_FIM, '" + _dtInicio.ToString("yyyy-MM-dd") + "') >= '" + _dtInicio.ToString("yyyy-MM-dd") + "'";
                return ExecutarSELECT(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Aniversarios(int _competencia)
        {
            try
            {
                int _mes = _util.ConvertInt(_competencia.ToString().Trim().Substring(4, 2));

                string _sql = " select * from vw_relatorio_aniversariantes where mes = " + _mes.ToString() + "; ";
                return ExecutarSELECT(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ResumoConvenios(int _competencia)
        {
            try
            {
                int _ano = _util.ConvertInt(_competencia.ToString().Trim().Substring(0, 4));
                int _mes = _util.ConvertInt(_competencia.ToString().Trim().Substring(4, 2));

                string _sql = " SELECT * FROM VW_RELATORIO_CONVENIO WHERE ANO = " + _ano.ToString() + " AND MES = " + _mes.ToString() + "; ";
                return ExecutarSELECT(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet CriticaFolha(int _competencia, bool _somentePlanos = false, bool _todos = false)
        {
            try
            {
                int _ano = _util.ConvertInt(_competencia.ToString().Trim().Substring(0, 4));
                int _mes = _util.ConvertInt(_competencia.ToString().Trim().Substring(4, 2));

                List<MySqlParameter> _parametros = new List<MySqlParameter>();
                _parametros.Add(new MySqlParameter() { ParameterName = "VAR_ANO", Value = _ano });
                _parametros.Add(new MySqlParameter() { ParameterName = "VAR_MES", Value = _mes });
                _parametros.Add(new MySqlParameter() { ParameterName = "VAR_TODOS", Value = _todos });
                _parametros.Add(new MySqlParameter() { ParameterName = "VAR_SOMENTE_PLANO_SAUDE", Value = _somentePlanos });


                return ExecutarPROCEDURE_DS("PR_RELATORIO_CRITICA_FOLHA", _parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet EnvioFolha(int _competencia)
        {
            try
            {
                int _ano = _util.ConvertInt(_competencia.ToString().Trim().Substring(0, 4));
                int _mes = _util.ConvertInt(_competencia.ToString().Trim().Substring(4, 2));
                string _sql = "SELECT * FROM VW_RELATORIO_ENVIO_FOLHA WHERE NR_ANO =  " + _ano.ToString() + " AND NR_MES = " + _mes.ToString();

                return ExecutarSELECT(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet FechamentoMes(int _competencia)
        {
            try
            {

                string _sql = "SELECT * FROM VW_RELATORIO_FECHAMENTO_MES WHERE NR_COMPETENCIA =  " + _competencia.ToString();

                return ExecutarSELECT(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet RetornoFolha(int _competencia)
        {
            try
            {
                int _ano = _util.ConvertInt(_competencia.ToString().Trim().Substring(0, 4));
                int _mes = _util.ConvertInt(_competencia.ToString().Trim().Substring(4, 2));

                string _sql = "SELECT R.* FROM VW_RELATORIO_RETORNO_FOLHA R ";
                _sql += " WHERE R.NR_ANO = " + _ano.ToString();
                _sql += " AND R.NR_MES = " + _mes.ToString();

                return ExecutarSELECT(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ExtratoComanda(Associado _associado, int _competencia)
        {
            try
            {
                int _ano = _util.ConvertInt(_competencia.ToString().Trim().Substring(0, 4));
                int _mes = _util.ConvertInt(_competencia.ToString().Trim().Substring(4, 2));

                string _sql = "SELECT R.* FROM VW_RELATORIOS_EXTRATO_COMANDAS R ";
                _sql += " WHERE ANO = " + _ano.ToString();
                _sql += " AND MES = " + _mes.ToString();
                _sql += " AND MATRI = " + _associado.Matricula.ToString();

                return ExecutarSELECT(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ExtratoComandaAssociado(Associado _associado, int _competencia, bool _somenteAtivos = true)
        {
            try
            {
                int _ano = _util.ConvertInt(_competencia.ToString().Trim().Substring(0, 4));
                int _mes = _util.ConvertInt(_competencia.ToString().Trim().Substring(4, 2));

                List<MySqlParameter> _parametros = new List<MySqlParameter>();
                _parametros.Add(new MySqlParameter() { ParameterName = "VAR_MATRICULA", Value = _util.SomenteNumeros(_associado.Matricula) });
                _parametros.Add(new MySqlParameter() { ParameterName = "VAR_MES", Value = _mes });
                _parametros.Add(new MySqlParameter() { ParameterName = "VAR_ANO", Value = _ano});
                _parametros.Add(new MySqlParameter() { ParameterName = "VAR_ATIVOS", Value = _somenteAtivos });


                return ExecutarPROCEDURE_DS("PR_EXTRATO_COMANDAS", _parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DeclaracaoHapVida(Associado _associado, int _ano)
        {
            try
            {
                int _competenciaInicio = _ano * 100 + 1;
                int _competenciaFim = _ano * 100 + 12;

                string _credencialGrupo = new CobrancaHapVidaDAO().CredencialGrupo(_associado, _ano);

                List<MySqlParameter> _parametros = new List<MySqlParameter>();
                _parametros.Add(new MySqlParameter() { ParameterName = "VAR_CPF", Value = _util.SomenteNumeros( _associado.CPF)});
                _parametros.Add(new MySqlParameter() { ParameterName = "VAR_CREDENCIAL_GRUPO", Value = _credencialGrupo });
                _parametros.Add(new MySqlParameter() { ParameterName = "VAR_COMPETENCIA_INCIAL", Value = _competenciaInicio});
                _parametros.Add(new MySqlParameter() { ParameterName = "VAR_COMPETENCIA_FINAL", Value = _competenciaFim});


                return ExecutarPROCEDURE_DS("PR_RELATORIO_DECLARACAO_HAPVIDA", _parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ExtratoComanda(Associado _associado, int _competenciaInicial, int _competenciaFinal)
        {
            try
            {
                string _sql = "SELECT R.* FROM VW_RELATORIOS_EXTRATO_COMANDAS R ";
                _sql += " WHERE (ANO * 100) + MES BETWEEN " + _competenciaInicial.ToString() + " AND " + _competenciaFinal.ToString();
                _sql += " AND MATRI = " + _associado.Matricula.ToString();

                return ExecutarSELECT(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet DadosAssociados(Associado _associado)
        {
            try
            {
                string _sql = "SELECT R.* FROM VW_RELATORIO_DADOS_ASSOCIADO R ";
                _sql += " WHERE MATR = " + _associado.Matricula.ToString();

                return ExecutarSELECT(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ComparativoEnvioRetorno(Associado _associado, int _competenciaInicial, int _competenciaFinal)
        {
            try
            {
                string _sql = " SELECT * ";
                _sql += " FROM VW_RELATORIO_COMPARATIVO_ENVIO_RETORNO_FOLHA ";
                _sql += " WHERE NR_MATRICULA = " + _associado.Matricula.ToString();
                _sql += " AND NR_ANO *100 + NR_MES BETWEEN " + _competenciaInicial.ToString() + " AND " + _competenciaFinal.ToString();
                _sql += " ORDER BY NR_MATRICULA, NR_ANO, NR_MES, CD_EVENTO ";

                return ExecutarSELECT(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
