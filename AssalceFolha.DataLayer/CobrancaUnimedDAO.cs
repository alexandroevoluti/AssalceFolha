using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.Entity;
using System.Configuration;
using System.IO;
using MySql.Data.MySqlClient;
using AssalceFolha.ErrorHandling;
using System.Data;
using AssalceFolha.Entity.DTO;

namespace AssalceFolha.DataLayer
{
    public class CobrancaUnimedDAO : EntidadeDAO<CobrancaUnimed>
    {
        public List<CobrancaUnimed> Listar(int _competencia)
        {
            try
            {
                string _sql = " SELECT * FROM TB_COBRANCA_UNIMED WHERE NR_COMPETENCIA = " + _competencia.ToString();
                _sql += " ORDER BY NR_COMPETENCIA, DE_CREDENCIAL ";

                return RetornarListaDe(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarCPF(string _cpfAtual, string _nome, string _novoCPF)
        {
            try
            {
                string _sql = " UPDATE TB_COBRANCA_UNIMED  SET CPF = '{0}' WHERE CPF = '{1}'";
                _sql = string.Format(_sql, _novoCPF, _cpfAtual);

                ExecutarSQL(_sql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CobrancaUnimed> Listar(string _nome, string _ano)
        {
            try
            {
                string _inicio = _ano.Trim() + "01";
                string _fim = _ano.Trim() + "12";

                string _sql = " SELECT * FROM TB_COBRANCA_UNIMED ";
                _sql += " WHERE NR_COMPETENCIA BETWEEN " + _inicio + " and " + _fim;
                _sql += " AND NM_BENEFICIARIO LIKE '%" + _nome + "%'";
                _sql += " ORDER BY CPF, NM_BENEFICIARIO  ";

                return RetornarListaDe(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExisteEnvio(int _competencia)
        {
            try
            {
                string _sql = " SELECT * FROM TB_COBRANCA_UNIMED WHERE NR_COMPETENCIA = " + _competencia.ToString();
                return _util.ConvertInt(ExecutarSELECT_Escalar(_sql)) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ValoresCobrancaUNIMEDDTO> PesquisarValores(Associado _associao, int _ano)
        {
            try
            {

                List<ValoresCobrancaUNIMEDDTO> _lista = null;
                string _credencial = CredencialGrupo(_associao, _ano);

                string _sql = " SELECT NR_COMPETENCIA, SUM(VR_MENSALIDADE) VR_MENSALIDADE, SUM(VR_ADICIONAL) VR_ADICIONAL, SUM(VR_TAXA_ADESAO) VR_TAXA_ADESAO, SUM(VR_DESCONTO) VR_DESCONTO, SUM(VR_COBRADO) VR_COBRADO  ";
                _sql += " FROM TB_COBRANCA_UNIMED ";
                _sql += " WHERE SUBSTRING_INDEX(SUBSTRING_INDEX(DE_CREDENCIAL, '-', 1), ',', -1) = '{0}' ";
                _sql += " AND NR_COMPETENCIA BETWEEN {1} AND {2} ";
                _sql += " GROUP BY NR_COMPETENCIA";

                _sql = String.Format(_sql, _credencial, _ano * 100 + 1, _ano * 100 + 12);

                DataSet _ds = ExecutarSELECT(_sql);

                if (_ds.Tables[0].Rows.Count > 0)
                {
                    _lista = new List<ValoresCobrancaUNIMEDDTO>();

                    foreach (DataRow _row in _ds.Tables[0].Rows)
                    {
                        _lista.Add(new ValoresCobrancaUNIMEDDTO()
                        {
                            Competencia = _util.FormatarCompetencia(_util.ConvertInt(_row["NR_COMPETENCIA"])),
                            Mensalidade = _util.ConvertDouble(_row["VR_MENSALIDADE"]),
                            Adicional = _util.ConvertDouble(_row["VR_ADICIONAL"]),
                            TaxaAdesao = _util.ConvertDouble(_row["VR_TAXA_ADESAO"]),
                            Desconto = _util.ConvertDouble(_row["VR_DESCONTO"]),
                            ValorCobrado = _util.ConvertDouble(_row["VR_COBRADO"])
                        });
                    };
                }

                return _lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CredencialGrupo(Associado _associado, int _ano)
        {
            try
            {
                string _sql = " SELECT SUBSTRING_INDEX(SUBSTRING_INDEX(DE_CREDENCIAL, '-', 1), ',', -1) ";
                _sql += "FROM TB_COBRANCA_UNIMED ";
                _sql += "WHERE REPLACE(REPLACE(CPF, '.', ''), '-', '') = '{0}' ";
                _sql += "AND NR_COMPETENCIA BETWEEN {1} AND {2} ";
                _sql += "LIMIT 1 ";

                _sql = String.Format(_sql,
                    _util.SomenteNumeros(_associado.CPF),
                    _ano * 100 + 1,
                    _ano * 100 + 12);

                return (ExecutarSELECT_Escalar(_sql) ?? "").ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CobrancaUnimed> Incluir(List<CobrancaUnimed> _cobrancas, MySqlConnection con, MySqlTransaction tran)
        {
            try
            {
                List<CobrancaUnimed> _retorno = new List<CobrancaUnimed>();

                foreach (CobrancaUnimed item in _cobrancas)
                {
                    _retorno.Add(base.Incluir(item, con, tran));
                }


                return _retorno;
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

    }
}
