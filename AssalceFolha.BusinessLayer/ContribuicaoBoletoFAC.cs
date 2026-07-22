using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.DataLayer;
using AssalceFolha.Entity;
using AssalceFolha.ErrorHandling;
using MySql.Data.MySqlClient;

namespace AssalceFolha.BusinessLayer
{
    public class ContribuicaoBoletoFAC
    {
        ContribuicaoBoletoDAO _ContribuicaoBoletoDAO = new ContribuicaoBoletoDAO();


        public ContribuicaoBoleto Selecionar(int _id)
        {
            try
            {
                return _ContribuicaoBoletoDAO.Selecionar(_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ContribuicaoBoleto> Listar()
        {
            try
            {
                return _ContribuicaoBoletoDAO.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(ContribuicaoBoleto _ContribuicaoBoleto)
        {
            try
            {
                _ContribuicaoBoletoDAO.ExcluirAlone(_ContribuicaoBoleto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ContribuicaoBoleto SalvarAlone(ContribuicaoBoleto _ContribuicaoBoleto)
        {
            try
            {

                Validar(_ContribuicaoBoleto);

                using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["STRConexao"].ConnectionString))
                {
                    if (con.State == ConnectionState.Open) con.Close();
                    con.Open();
                    MySqlTransaction tran = con.BeginTransaction();
                    try
                    {
                        ContribuicaoBoleto entidade = _ContribuicaoBoleto;
                        if (entidade.ID.Equals(0))
                        {
                            entidade = _ContribuicaoBoletoDAO.Incluir(entidade, con, tran);
                        }
                        else
                        {
                            _ContribuicaoBoletoDAO.Alterar(entidade, con, tran);
                        }

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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Validar(ContribuicaoBoleto _ContribuicaoBoleto)
        {
            try
            {

                Associado _associado = new AssociadoDAO().SelecionarPorMatricula(_ContribuicaoBoleto.Matricula.ToString());
                if (_associado == null) throw new Exception("Associado não encontrado para a matrícula informada ");

                if (_ContribuicaoBoleto.Valor <= 0) throw new Exception("Valor inválido ");

                var _contribuicaoBoletoBanco = new ContribuicaoBoletoDAO().SelecionarPorMatricula(_ContribuicaoBoleto.Matricula);
                if (_contribuicaoBoletoBanco != null) if (_contribuicaoBoletoBanco.ID != _ContribuicaoBoleto.ID) throw new Exception("Já existe contribuição para a matrícula !");
            }
            catch
            {

            }
        }
    }
}
