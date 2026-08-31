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
    public partial class frmRelatorioAssociadoPeriodo : Form
    {
        public enumRelatorio Relatorio { get; set; }

        public frmRelatorioAssociadoPeriodo(enumRelatorio _relatorio)
        {

            Relatorio = _relatorio;
            
            InitializeComponent();

            ucAssociado1.Focus();

            // Dia 1 fixo: o formato "MM/yyyy" oculta o dia, e meses curtos gerariam data inexistente.
            DateTime _inicial = DateTime.Now.AddMonths(-6);

            dtpCompetenciaInicial.Value = new DateTime(_inicial.Year, _inicial.Month, 1);
            dtpCompetenciaFinal.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);


            this.Text = new Enumerator<enumRelatorio>().EnumToString(_relatorio);
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Associado _associado = ucAssociado1.Associado;
                if (_associado == null) throw new Exception("Informe o associado !");
                if (!_util.ValidaData(dtpCompetenciaInicial.Value)) throw new Exception("Informe a competência inicial !");
                if (!_util.ValidaData(dtpCompetenciaFinal.Value)) throw new Exception("Informe a competência final !");

                int _competenciaInicial = _util.ConvertDataParaCompetencia(dtpCompetenciaInicial.Value);
                int _competenciaFinal = _util.ConvertDataParaCompetencia(dtpCompetenciaFinal.Value);

                if (_competenciaInicial > _competenciaFinal) throw new Exception("Competência inicial maior que competência final !");

                CarregarRelatorio(_associado, _competenciaInicial, _competenciaFinal);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CarregarRelatorio(Associado _associado, int _competenciaInicial, int _competenciaFinal)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!_util.ValidaCompetencia(_competenciaInicial)) throw new Exception("Informe a competência !");
                if (!_util.ValidaCompetencia(_competenciaFinal)) throw new Exception("Informe a competência !");
                if (_competenciaInicial > _competenciaFinal) throw new Exception("Competência inicial maior que competência final !");

                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource reportDataSource = new ReportDataSource();

                DataSet _ds;
                List<ReportParameter> parameters = new List<ReportParameter>();

                switch (Relatorio)
                {
                    case enumRelatorio.ComparativoEnvioRetornoFolha:

                        reportViewer1.LocalReport.ReportPath = @".\Relatorios\relComparativoEnvioRetorno.rdlc";

                        reportDataSource = new ReportDataSource();
                        reportDataSource.Name = "dsDados";
                        _ds = new RelatoriosFAC().ComparativoEnvioRetorno(_associado, _competenciaInicial, _competenciaFinal);
                        reportDataSource.Value = _ds.Tables[0];
                        this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                        
                        parameters.Add(new ReportParameter("Periodo", dtpCompetenciaInicial.Value.ToString("MM/yyyy") + " a " + dtpCompetenciaFinal.Value.ToString("MM/yyyy")));
                        parameters.Add(new ReportParameter("Associado", _associado.Matricula + " - " + _associado.Folha + " - " + _associado.Nome));
                        parameters.Add(new ReportParameter("Situacao", _associado.Situacao));
                        parameters.Add(new ReportParameter("Telefone",  (String.IsNullOrEmpty(_associado.Telefone)?"Não Informado": _associado.Telefone) + "    Celular: " + _associado.Celular));
                        this.reportViewer1.LocalReport.SetParameters(parameters);

                        break;
                    case enumRelatorio.ExtratoComandas:
                        reportViewer1.LocalReport.ReportPath = @".\Relatorios\relExtratoComanda.rdlc";

                        reportDataSource = new ReportDataSource();
                        reportDataSource.Name = "dsDados";
                        _ds = new RelatoriosFAC().ExtratoComanda(_associado, _competenciaInicial, _competenciaFinal);
                        reportDataSource.Value = _ds.Tables[0];
                        this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                        parameters.Add(new ReportParameter("competencia", dtpCompetenciaInicial.Value.ToString("MM/yyyy") + " a " + dtpCompetenciaFinal.Value.ToString("MM/yyyy")));

                        this.reportViewer1.LocalReport.SetParameters(parameters);

                        break;
                    default:
                        break;
                }

                this.reportViewer1.ShowPrintButton = true;
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { this.Cursor = Cursors.Default; }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
