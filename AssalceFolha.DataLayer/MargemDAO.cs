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
    public class MargemDAO : EntidadeDAO<Margem>
    {

        public Margem Selecionar(int _matricula, int _folha)
        {
            try
            {
                string _sql = " SELECT * FROM MARGEM WHERE CONVERT(MATR,UNSIGNED INTEGER) = " + _matricula.ToString() + " and CONVERT(FOLHA,UNSIGNED INTEGER) = " + _folha.ToString();

                return base.RetornarEntidadeDe(_sql);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public override Margem Selecionar(int _matricula)
        {
            try
            {
                string _sql = " SELECT * FROM MARGEM WHERE CONVERT(MATR,UNSIGNED INTEGER) = " + _matricula.ToString();

                return base.RetornarEntidadeDe(_sql);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public Margem Salvar(Margem _margem)
        {
            try
            {
                
                if (_margem.ID.Equals(0))
                {
                    return Incluir(_margem);
                }
                else
                {
                    Alterar(_margem);
                    return _margem;
                }                

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
