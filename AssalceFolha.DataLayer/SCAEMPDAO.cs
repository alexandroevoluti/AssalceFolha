using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.Entity;
using AssalceFolha.ErrorHandling;

namespace AssalceFolha.DataLayer
{
    public class SCAEMPDAO : EntidadeDAO<SCAEMP>
    {
       public List<SCAEMP> Listar(int _matricula, int _folha)
        {
            try
            {
                string _sql = " SELECT * FROM SCAEMP ";
                _sql += " WHERE FN_INT(EMPMAT) = " + _matricula.ToString();
                _sql += " AND FN_INT(FOLHA) = " + _folha.ToString();
                _sql += " ORDER BY EMP_ANO_F,EMP_MES_F DESC ";

                return base.RetornarListaDe(_sql);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public List<SCAEMP> Listar(Associado _associado)
        {
            try
            {
                string _sql = " SELECT * FROM SCAEMP ";
                _sql += " WHERE FN_INT(EMPMAT) = " + _associado.Matricula;
                _sql += " AND FN_INT(FOLHA) = " + _associado.Folha;

                return base.RetornarListaDe(_sql);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        protected override SCAEMP Montar(DataRow row)
        {
            SCAEMP entidade = null;
            try
            {
                entidade = base.Montar(row);
                entidade.Convenio = new ConvenioDAO().Selecionar(entidade.ID_Convenio);

            }
            catch (Exception e)
            {
                throw e;
            }
            return entidade;
        }

    }
}
