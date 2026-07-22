using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.Entity;
using AssalceFolha.ErrorHandling;
using MySql.Data.MySqlClient;

namespace AssalceFolha.DataLayer
{
    public class ConveniadoDAO : EntidadeDAO<Conveniado>
    {
        public List<Conveniado> Listar(int _id, string _nome)
        {
            try
            {
                string _sql = " SELECT * FROM SCACNV ";
                _sql += " WHERE CNVRAZ like '%" + _nome + "%' ";
                if (!_id.Equals(0)) _sql += " OR FN_INT(CNVCOD) = " + _id.ToString();
                _sql += " ORDER BY CNVRAZ ";

                return base.RetornarListaDe(_sql);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        public override Conveniado Incluir(Conveniado entidade)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["STRConexao"].ConnectionString))
                {
                    if (con.State == ConnectionState.Open) con.Close();
                    con.Open();

                    MySqlTransaction tran = con.BeginTransaction();
                    try
                    {
                        entidade = base.Incluir(entidade, con, tran);
                        entidade.Convenio = new ConvenioDAO().Incluir(entidade.Convenio, con, tran);

                        tran.Commit();

                        return entidade;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        ErrorHandle oTratarErro = ErrorHandle.Instancia();
                        oTratarErro.Erro(this, ex, ""); throw ex;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override void Alterar(Conveniado entidade)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["STRConexao"].ConnectionString))
                {
                    if (con.State == ConnectionState.Open) con.Close();
                    con.Open();

                    MySqlTransaction tran = con.BeginTransaction();
                    try
                    {
                        base.Alterar(entidade, con, tran);

                        if (new ConvenioDAO().Selecionar(entidade.ID) == null)
                            new ConvenioDAO().Incluir(entidade.Convenio, con, tran);
                        else
                            new ConvenioDAO().Alterar(entidade.Convenio, con, tran);

                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        ErrorHandle oTratarErro = ErrorHandle.Instancia();
                        oTratarErro.Erro(this, ex, ""); throw ex;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected override Conveniado Montar(DataRow row)
        {
            Conveniado entidade = null;
            try
            {
                entidade = base.Montar(row);
                entidade.Convenio = new ConvenioDAO().Selecionar(entidade.ID);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entidade;
        }

    }
}
