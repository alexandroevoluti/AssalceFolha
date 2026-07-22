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
    public class FinanciamentoDAO : EntidadeDAO<Financiamento>
    {
        string _codigos = "640,641,667,669,674,750";
        
        public List<Financiamento> Listar(int _matricula, int _folha)
        {
            try
            {
                string _sql = " SELECT * FROM SCAEMP ";
                _sql += " WHERE FN_INT(EMPMAT) = " + _matricula.ToString();
                _sql += " AND FN_INT(FOLHA) = " + _folha.ToString();
                _sql += " AND NOT EVENTO IN(" + _codigos + ") ";
                _sql += " ORDER BY EMP_ANO_F,EMP_MES_F DESC ";
                
                return base.RetornarListaDe(_sql);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public List<Financiamento> Listar(Associado _associado)
        {
            try
            {
                string _sql = " SELECT * FROM SCAEMP ";
                _sql += " WHERE FN_INT(EMPMAT) = " + _associado.Matricula;
                _sql += " AND FN_INT(FOLHA) = " + _associado.Folha;
                _sql += " AND NOT EVENTO IN(" + _codigos + ") ";

                return base.RetornarListaDe(_sql);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        protected override Financiamento Montar(DataRow row)
        {
            Financiamento entidade = null;
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
