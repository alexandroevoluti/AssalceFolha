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
    public class SCAEMPFAC
    {
        SCAEMPDAO _SCAEMPDAO = new SCAEMPDAO();

        public SCAEMP Selecionar(int _id)
        {
            try
            {
                return _SCAEMPDAO.Selecionar(_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SCAEMP> Listar()
        {
            try
            {
                return _SCAEMPDAO.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SCAEMP> Listar(int _matricula, int _folha)
        {
            try
            {
                return _SCAEMPDAO.Listar(_matricula, _folha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SCAEMP> Listar(Associado _associado)
        {
            try
            {
                return _SCAEMPDAO.Listar(_associado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public SCAEMP IncluirAlone(Adiantamento _adiantamento, MySqlConnection con, MySqlTransaction tran)
        {
            try
            {



                SCAEMP _SCAEMP = new SCAEMP()
                {
                    ID = 0,
                    Matricula = _adiantamento.Matricula,
                    Folha = _adiantamento.Folha,
                    Evento = "779",
                    ID_Convenio = _adiantamento.ID_Convenio,
                    Nome = _adiantamento.Convenio.Nome,
                    Parcelas = _adiantamento.Parcelas,
                    Valor = _adiantamento.Valor,
                    DataInicio = _adiantamento.DataInicioPagamento,
                    DataTermino = _adiantamento.DataFimPagamento,
                    ValorParcela = _adiantamento.ValorParcela,
                    Status = "I",
                    DataCadastro = _adiantamento.DataInformacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    Usuario = _adiantamento.LoginResponsavelInformacao,
                    UsuarioPlano = null,
                    Parentesco = null,
                    TP = null,
                    Acomodacao = null,
                    DataNascimento = null,
                    MesInicio = null,
                    AnoInicio = null,
                    MesFim = null,
                    AnoFim = null,
                    TIPO = null,
                    MES = null,
                    ANO = null
                };

                return _SCAEMPDAO.Incluir(_SCAEMP, con, tran);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SCAEMP SalvarAlone(SCAEMP _SCAEMP)
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
                        SCAEMP entidade = _SCAEMP;
                        if (entidade.ID.Equals(0))
                        {
                            entidade = _SCAEMPDAO.Incluir(entidade);
                        }
                        else
                        {
                            _SCAEMPDAO.Alterar(entidade);
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
    }
}
