using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.Entity;
using System.Configuration;
using System.IO;
using MySql.Data.MySqlClient;

namespace AssalceFolha.DataLayer
{
    public class CargaMargemDAO : EntidadeDAO<CargaMargem>
    {
        public List<CargaMargem> Listar(int _ano, int _mes)
        {
            try
            {
                string _sql = " SELECT * FROM TB_MARGEM WHERE NR_ANO = " + _ano.ToString() + " AND NR_MES = " + _mes.ToString();
                _sql += " ORDER BY NR_ANO, NR_MES, NR_MATRICULA ";

                return RetornarListaDe(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExisteCarga(int _ano, int _mes)
        {
            try
            {
                string _sql = " SELECT COUNT(*) FROM TB_MARGEM  WHERE NR_ANO = " + _ano.ToString() + " AND NR_MES = " + _mes.ToString();
                return _util.ConvertInt(ExecutarSELECT_Escalar(_sql)) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void AtualizarForaDeFolha(int _ano,int _mes)
        {
            try
            {
                string _sql = " UPDATE ASSOCIADOS SET ";
                _sql += "      SITUACAO_ANTERIOR = SITUACAO, ";
                _sql += "      SITUACAO = @SITUACAO ";
                _sql += " WHERE SITUACAO != 'FORA DE FOLHA' ";
                _sql += " AND SITUACAO != 'FALECIDO' ";
                _sql += " AND SITUACAO != 'TERCEIRIZADO' ";
                _sql += " AND MATR NOT IN(SELECT NR_MATRICULA FROM TB_MARGEM WHERE NR_ANO = @ANO AND NR_MES = @MES)";

                List<MySqlParameter> _parametros = new List<MySqlParameter>();
                _parametros.Add(new MySqlParameter("@ANO", _ano));
                _parametros.Add(new MySqlParameter("@MES", _mes));
                _parametros.Add(new MySqlParameter("@SITUACAO", "FORA DE FOLHA"));
                
                ExecutarSELECT_Escalar(_sql, _parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
