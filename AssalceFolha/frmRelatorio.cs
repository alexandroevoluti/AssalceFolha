using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AssalceFolha.BusinessLayer;
using AssalceFolha.Entity;
using Microsoft.Reporting.WinForms;

namespace AssalceFolha
{
    public partial class frmRelatorio : _baseForm
    {
        public Usuario Usuario{ get; set; }

        public frmRelatorio(enumRelatorio _relatorio, int _competencia, Compra _movimento = null)
        {
            InitializeComponent();

            CarregarRelatorio(_relatorio, _competencia, _movimento);
        }

        public frmRelatorio(enumRelatorio _relatorio, Adiantamento _adiantamento)
        {
            InitializeComponent();

            CarregarRelatorio(_relatorio, 0, null, _adiantamento);
        }

        private void CarregarRelatorio(enumRelatorio _relatorio, int _competencia, Compra _movimento, Adiantamento _adiantamento = null)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource reportDataSource = new ReportDataSource();
            DataSet _ds;
            ReportParameter[] parameters;
            Associado _associado;

            switch (_relatorio)
            {
                case enumRelatorio.ConferenciaCargaArquivoFolha:
                    reportViewer1.LocalReport.ReportPath = @".\Relatorios\relConferenciaCarga.rdlc";

                    reportDataSource = new ReportDataSource();
                    reportDataSource.Name = "dsDados";
                    _ds = new RelatoriosFAC().ConferenciaCargaArquivoFolha(_competencia);
                    reportDataSource.Value = _ds.Tables[0];
                    reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                    break;
                case enumRelatorio.MapaCSG:
                    reportViewer1.LocalReport.ReportPath = @".\Relatorios\relMapa.rdlc";

                    reportDataSource = new ReportDataSource();
                    reportDataSource.Name = "dsDados";
                    _ds = new RelatoriosFAC().Mapa(_competencia);
                    reportDataSource.Value = _ds.Tables[0];
                    reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                    break;
                case enumRelatorio.Comanda:
                    
                    reportViewer1.LocalReport.ReportPath = @".\Relatorios\relComanda.rdlc";

                    reportDataSource = new ReportDataSource();
                    reportDataSource.Name = "dsLogo";
                    _ds = new RelatoriosFAC().Logo();
                    reportDataSource.Value = _ds.Tables[0];
                    reportViewer1.LocalReport.DataSources.Add(reportDataSource);


                    _associado = new AssociadoFAC().SelecionarPorMatricula(_movimento.Matricula);

                    parameters = new ReportParameter[10];
                    parameters[0] = new ReportParameter("Nome", _associado.Nome);
                    parameters[1] = new ReportParameter("Matricula", _associado.Matricula);
                    parameters[2] = new ReportParameter("Valor", _movimento.Valor.ToString("#,##0.00"));
                    parameters[3] = new ReportParameter("Referencia", _movimento.Referencia);
                    parameters[4] = new ReportParameter("Convenio", _movimento.ID_Convenio);
                    parameters[5] = new ReportParameter("Evento", _movimento.Evento);
                    parameters[6] = new ReportParameter("NomeConvenio", _movimento.DE_Convenio);
                    parameters[7] = new ReportParameter("Competencia", _competencia.ToString());
                    parameters[8] = new ReportParameter("CodigoBarras", _movimento.Matricula + _movimento.ID_Convenio + "1111");
                    parameters[9] = new ReportParameter("EmitidoPor", Usuario.Nome);

                    reportViewer1.LocalReport.SetParameters(parameters);

                    //reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                    break;
                case enumRelatorio.Adiantamento:

                    reportViewer1.LocalReport.ReportPath = @".\Relatorios\relAdiantamento.rdlc";

                    reportDataSource = new ReportDataSource();
                    reportDataSource.Name = "dsLogo";
                    _ds = new RelatoriosFAC().Logo();
                    reportDataSource.Value = _ds.Tables[0];
                    reportViewer1.LocalReport.DataSources.Add(reportDataSource);


                    _associado = new AssociadoFAC().SelecionarPorMatricula(_adiantamento.Matricula);

                    parameters = new ReportParameter[9];
                    parameters[0] = new ReportParameter("Nome", _associado.Nome);
                    parameters[1] = new ReportParameter("Matricula", _associado.Matricula);
                    parameters[2] = new ReportParameter("CPF", (_associado.CPF==null?" ":_util.FormatarCpf(_associado.CPF)));
                    parameters[3] = new ReportParameter("Valor", _adiantamento.Valor.ToString("#,##0.00"));
                    parameters[4] = new ReportParameter("Extenso", _extenso.NumeroParaExtenso(_adiantamento.Valor));
                    parameters[5] = new ReportParameter("Parcelas", _adiantamento.Parcelas.ToString());
                    parameters[6] = new ReportParameter("ExtensoParcelas", _extenso.NumeroParaExtenso(_adiantamento.Parcelas, false));
                    parameters[7] = new ReportParameter("ValorParcela", _adiantamento.ValorParcela.ToString("#,##0.00"));
                    parameters[8] = new ReportParameter("ExtensoValorParcela", _extenso.NumeroParaExtenso(_adiantamento.ValorParcela));

                    reportViewer1.LocalReport.SetParameters(parameters);

                    //reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                    break;
                default:
                    break;
            }
                        
            reportViewer1.ShowPrintButton = true;
            reportViewer1.LocalReport.Refresh();
        }

        private void Relatorio_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
