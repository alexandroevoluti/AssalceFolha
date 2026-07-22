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
    public class AdiantamentoFAC
    {
        AdiantamentoDAO _adiantamentoDAO = new AdiantamentoDAO();

        public Adiantamento IncluirAlone(Adiantamento _adiantamento, Usuario _usuarioLogado)
        {
            try
            {
                ParametroFAC _parametroFAC = new ParametroFAC();
                SCAEMPFAC _SCAEMPFAC = new SCAEMPFAC();

                DateTime _dataParcela = PrimeiraParcela();
                DateTime _dataUltimaParcela = _dataParcela.AddMonths(_adiantamento.Parcelas - 1);

                Adiantamento _retorno = new Adiantamento();


                string _codConvenio = _parametroFAC.Selecionar(enumTipoParametro.ConvenioAdiantamento).Valor;
                Convenio _convenio = new ConvenioFAC().Selecionar(_codConvenio);

                using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["STRConexao"].ConnectionString))
                {
                    if (con.State == ConnectionState.Open) con.Close();
                    con.Open();
                    MySqlTransaction tran = con.BeginTransaction();
                    try
                    {
                        double _valorParcela = CalcularParcela(_adiantamento.Valor, _adiantamento.Parcelas);
                        _adiantamento.ValorParcela = _valorParcela;
                        _adiantamento.DataInicioPagamento = _util.PrimeiroDiaMes(_dataParcela);
                        _adiantamento.DataFimPagamento = _util.PrimeiroDiaMes(_dataUltimaParcela);
                        _adiantamento.Convenio = _convenio;

                        _retorno = _adiantamentoDAO.Incluir(_adiantamento, con, tran);

                        //INCLUIR SCAEMP
                        _SCAEMPFAC.IncluirAlone(_adiantamento, con, tran);

                        tran.Commit();

                        return _retorno;
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

        public DateTime PrimeiraParcela()
        {
            try
            {
                DateTime _dataParcela = DateTime.Now;
                ParametroFAC _parametroFAC = new ParametroFAC();
                int _diaFechamento = _util.ConvertInt(_parametroFAC.Selecionar(enumTipoParametro.DiaFechamentoAdiantamento).Valor);

                if (_dataParcela.Day > _diaFechamento) _dataParcela.AddMonths(1);

                return _dataParcela;

            }
            catch (Exception ex)
            {
                throw ex;
            }
}

public double CalcularParcela(double _valor, int _qtdeParcelas)
{
    try
    {
        Parametro _parametro = new ParametroFAC().Selecionar(enumTipoParametro.TaxaJurosAdiantamento);
        double _taxa = _util.ConvertDouble(_parametro.Valor);

        return Math.Round(_util.ParcelaFinanciamento(_valor, _taxa, _qtdeParcelas), 2);

    }
    catch (Exception ex)
    {
        throw ex;
    }
}
    }
}
