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
    public class BancoDAO : EntidadeDAO<Banco>
    {
        string _codigos = "005,779,804,807,637";

        public List<Banco> Listar(int _matricula, int _folha)
        {
            try
            {
                string _sql = " SELECT * FROM SCAEMP ";
                _sql += " WHERE FN_INT(EMPMAT) = " + _matricula.ToString();
                _sql += " AND FN_INT(FOLHA) = " + _folha.ToString();
                _sql += " AND EVENTO IN(" + _codigos + ") ";
                _sql += " ORDER BY EMP_ANO_F,EMP_MES_F DESC ";

                return base.RetornarListaDe(_sql);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public List<Banco> Listar(Associado _associado)
        {
            try
            {
                string _sql = " SELECT * FROM SCAEMP ";
                _sql += " WHERE FN_INT(EMPMAT) = " + _associado.Matricula;
                _sql += " AND FN_INT(FOLHA) = " + _associado.Folha;
                _sql += " AND EVENTO IN(" + _codigos + ") ";

                return base.RetornarListaDe(_sql);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public List<Banco> Incluir(List<Banco> _bancos, MySqlConnection con, MySqlTransaction tran)
        {
            try
            {
                List<Banco> _retorno = new List<Banco>();

                foreach (Banco item in _bancos)
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

        protected override Banco Montar(DataRow row)
        {
            Banco entidade = null;
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
