using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.Entity;

namespace AssalceFolha.DataLayer
{
    public class CriticaFolhaDAO : EntidadeDAO<CriticaFolha>
    {
        public List<CriticaFolha> Listar(int _ano, int _mes)
        {
            try
            {
                string _sql = " SELECT * FROM TB_CRITICA_FOLHA WHERE ANO = " + _ano.ToString() + " AND MES = " + _mes.ToString();
                return RetornarListaDe(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CriticaFolha SelecionarCritica(int _competencia, string _matricula)
        {
            try
            {

                string _sql = " SELECT * FROM TB_CRITICA_FOLHA WHERE NR_MATRICULA = "  + _matricula + " AND (NR_ANO * 100) + NR_MES = " + (_competencia-1).ToString();
                return RetornarEntidadeDe(_sql);
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
                string _sql = "SELECT COUNT(*) FROM TB_CRITICA_FOLHA WHERE NR_ANO = " + _ano.ToString() + " AND NR_MES = " + _mes + ";";

                return _util.ConvertInt(ExecutarSELECT_Escalar(_sql)) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
