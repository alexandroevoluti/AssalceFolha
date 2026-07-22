using AssalceFolha.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssalceFolha.DataLayer
{
    public class ConsultaDAO:_BaseDAO
    {

        public DataSet GerarDados(string _sql)
        {
            try
            {
                return ExecutarSELECT(_sql);            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GerarDados(enumConsulta _consulta, int _competencia, int _ano)
        {
            string _sql = "";

            switch (_consulta)
            {
                case enumConsulta.SNPlanoSaude:
                    //_sql = "SELECT * FROM VW_RELATORIO_SN_PLANO_SAUDE WHERE DIFERENCA <> 0 AND  NR_ANO * 100 + NR_MES = " + _competencia.ToString() + " ORDER BY NR_MATRICULA ";

                    _sql = " SELECT * FROM ";
                    _sql += " (SELECT M.MATRI, A.FOLHA, A.NOME, A.CELULAR, A.FONE, A.SITUACAO, MAX(IFNULL(FC_VALOR_PLANO(M.MATRI, " + _competencia.ToString() + "),0)) VR_PLANO, SUM(M.VALORDES) VR_SN ";
                    _sql += " FROM SCAMOV M ";
                    _sql += " JOIN ASSOCIADOS A ON M.MATRI = A.MATR ";
                    _sql += " WHERE M.CONVENI = 'S.N.' ";
                    _sql += " AND M.ST = 'I' ";
                    _sql += " AND (M.ANO * 100) + M.MES = " + _competencia.ToString();
                    _sql += " AND A.SITUACAO != 'FALECIDO' ";
                    _sql += " GROUP BY M.MATRI, A.FOLHA, A.NOME, A.CELULAR, A.FONE) as T ";
                    _sql += " WHERE T.VR_PLANO > 0 "; 


                    break;
                case enumConsulta.SNCompetencia:
                    _sql = " SELECT M.MATRI, A.FOLHA, A.NOME, A.CELULAR, A.FONE, A.SITUACAO, MAX(IFNULL(FC_VALOR_PLANO(M.MATRI, " + _competencia.ToString() + "),0)) VR_PLANO, SUM(M.VALORDES) VR_SN ";
                    _sql += " FROM SCAMOV M ";
                    _sql += " JOIN ASSOCIADOS A ON M.MATRI = A.MATR ";
                    _sql += " WHERE M.CONVENI = 'S.N.' ";
                    _sql += " AND M.ST = 'I' ";
                    _sql += " AND (M.ANO * 100) + M.MES = " + _competencia.ToString();
                    //_sql += " AND A.SITUACAO != 'FALECIDO' ";
                    _sql += " AND A.SITUACAO in('ASSOCIADO','BLOQUEADO') ";
                    _sql += " AND(EXISTS(SELECT * ";
                    _sql += "              FROM SCAMOV ";
                    _sql += "              WHERE MATRI = M.MATRI ";
                    _sql += "              AND ST = 'I' ";
                    _sql += "              AND ANO * 100 + MES = " + _competencia.ToString();
                    _sql += "              AND EVENTO <> 913) ";
                    _sql += "   OR ";
                    _sql += "   EXISTS( ";
                    _sql += "  SELECT * ";
                    _sql += " FROM SCAEMP ";
                    _sql += " WHERE EMPMAT = M.MATRI ";
                    _sql += " AND ST = 'I' ";
                    _sql += " AND(YEAR(EMP_DAT_I) * 100 + MONTH(EMP_DAT_I) <= " + _competencia.ToString() + " OR EMP_DAT_I IS NULL) ";
                    _sql += " AND(YEAR(EMP_DAT_F) * 100 + MONTH(EMP_DAT_F) >= " + _competencia.ToString() + " OR EMP_DAT_F IS NULL)) ";
                    _sql += " ) ";
                    _sql += " GROUP BY M.MATRI, A.FOLHA, A.NOME, A.CELULAR, A.FONE ";

                    break;
                case enumConsulta.SNTerceirizados:
                    _sql = " SELECT A.MATR, A.FOLHA, A.NOME, A.FONE, A.CELULAR, A.SITUACAO, M.CONVENI, M.VALORDES VR_SN ";
                    _sql += " FROM SCAMOV M ";
                    _sql += " JOIN ASSOCIADOS A ON M.MATRI = A.MATR ";
                    _sql += " WHERE M.ANO * 100 + M.MES = " + _competencia.ToString();
                    _sql += " AND M.CONVENI = 'S.N.' ";
                    _sql += " AND M.ST = 'I' ";
                    _sql += " AND(A.SITUACAO = 'TERCEIRIZADO' OR A.SITUACAO_ANTERIOR = 'TERCEIRIZADO') ";
                    _sql += " ORDER BY A.MATR";
                    
                    break;
                case enumConsulta.TerceirizadosComFarmacia:
                    _sql = "  SELECT A.MATR, A.FOLHA, A.NOME , A.SITUACAO, M.CODCONV, M.CONVENI, SUM(VALORDES) VALORTOTAL ";
                    _sql += " FROM SCAMOV M ";
                    _sql += " JOIN ASSOCIADOS A ON M.MATRI = A.MATR ";
                    _sql += " WHERE ANO *100 + MES = " + _competencia.ToString();
                    _sql += " AND A.SITUACAO = 'TERCEIRIZADO' ";
                    _sql += " AND ( M.CODCONV IN(648, 410, 004, 321, 418, 450) ";
                    _sql += "       OR ";
                    _sql += "      CONVENI LIKE '%FARMACIA%') ";
                    _sql += " GROUP BY A.MATR, A.FOLHA, A.NOME , A.SITUACAO, M.CODCONV, M.CONVENI ";                    
                    _sql += " ORDER BY A.NOME";

                    break;
                case enumConsulta.ResumoComandasAno:
                    _sql = "  SELECT A.MATR, A.FOLHA, A.NOME, CONCAT(RIGHT(CONCAT('00',TRIM(M.MES)),2), '/', TRIM(M.ANO)) COMPETENCIA, SUM(VALORDES) VALOR ";
                    _sql += " FROM SCAMOV M ";
                    _sql += " JOIN ASSOCIADOS A ON M.MATRI = A.MATR ";
                    _sql += " WHERE M.ANO = " + _ano.ToString();
                    _sql += " AND ST = 'I' ";
                    _sql += " GROUP BY A.MATR, A.FOLHA, A.NOME, CONCAT(RIGHT(CONCAT('00',TRIM(M.MES)),2), '/', TRIM(M.ANO))";
                    _sql += " ORDER BY A.MATR, CONCAT(RIGHT(CONCAT('00',TRIM(M.MES)),2), '/', TRIM(M.ANO)) ";
                    break;
                case enumConsulta.SNComFarmacia:
                    _sql = "  SELECT * ";
                    _sql += " FROM ( ";
                    _sql += "         SELECT M.MATRI, A.FOLHA, A.NOME, A.CELULAR, A.FONE, A.SITUACAO, SUM(M.VALORDES) VR_SN ";
                    _sql += "           FROM SCAMOV M ";
                    _sql += "           JOIN ASSOCIADOS A ON M.MATRI = A.MATR ";
                    _sql += "           WHERE M.CONVENI = 'S.N.' ";
                    _sql += "           AND M.ST = 'I' ";
                    _sql += "           AND(M.ANO * 100) + M.MES = " + _competencia.ToString();
                    _sql += "           GROUP BY M.MATRI, A.FOLHA, A.NOME, A.CELULAR, A.FONE) AS T ";
                    _sql += "           WHERE EXISTS (SELECT * ";
                    _sql += "                           FROM SCAMOV MF ";
                    _sql += "                           WHERE MF.MATRI = T.MATRI ";
                    _sql += "                           AND(MF.ANO * 100) + MF.MES = " + _competencia.ToString();
                    _sql += " AND ( MF.CODCONV IN(648, 410, 004, 321, 418, 450) ";
                    _sql += "       OR ";
                    _sql += "      MF.CONVENI LIKE '%FARMACIA%') ";
                    _sql += ")";
                    _sql += " ORDER BY T.NOME";

                    break;
                case enumConsulta.ResumoConsignacoes:

                    DateTime _data = _util.PrimeiroDiaMes(_competencia);
                    _sql = "  CALL assalce.PR_RESUMO_CONSIGNACOES({0}, {1}); ";

                    _sql = String.Format(_sql, _data.Month, _data.Year);

                    break;
                default:
                    break;
            }

            return ExecutarSELECT(_sql);
        }
    }
}
