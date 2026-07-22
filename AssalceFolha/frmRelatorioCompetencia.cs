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
    public partial class frmRelatorioCompetencia : Form
    {

        public enumRelatorio Relatorio { get; set; }

        public frmRelatorioCompetencia(enumRelatorio _relatorio)
        {

            Relatorio = _relatorio;

            //dtpCompetencia.Focus();

            InitializeComponent();

            this.Text = new Enumerator<enumRelatorio>().EnumToString(_relatorio);
        }

        private void CarregarRelatorio()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int _competencia = _util.ConvertDataParaCompetencia(dtpCompetencia.Value);
                if (!_util.ValidaCompetencia(_competencia)) throw new Exception("Informe a competência !");

                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource reportDataSource = new ReportDataSource();

                DataSet _ds;
                ReportParameter[] parameters = new ReportParameter[1];

                switch (Relatorio)
                {
                    case enumRelatorio.ConferenciaCargaArquivoFolha:
                        this.reportViewer1.LocalReport.ReportPath = @".\Relatorios\relConferenciaCarga.rdlc";
                        this.reportViewer1.LocalReport.DataSources.Clear();

                        reportDataSource = new ReportDataSource();
                        reportDataSource.Name = "dsDados";
                        _ds = new RelatoriosFAC().ConferenciaCargaArquivoFolha(_competencia);
                        reportDataSource.Value = _ds.Tables[0];
                        this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                        break;
                    case enumRelatorio.MapaCSG:
                        this.reportViewer1.LocalReport.ReportPath = @".\Relatorios\relMapa.rdlc";
                        this.reportViewer1.LocalReport.DataSources.Clear();


                        reportDataSource = new ReportDataSource();
                        reportDataSource.Name = "dsDados";
                        _ds = new RelatoriosFAC().Mapa(_competencia);
                        reportDataSource.Value = _ds.Tables[0];
                        this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                        parameters = new ReportParameter[1];
                        parameters[0] = new ReportParameter("competencia", dtpCompetencia.Value.ToString("MM/yyyy"));
                        this.reportViewer1.LocalReport.SetParameters(parameters);

                        break;
                    case enumRelatorio.CriticaFolha:
                        this.reportViewer1.LocalReport.ReportPath = @".\Relatorios\relCriticaFolha.rdlc";
                        this.reportViewer1.LocalReport.DataSources.Clear();

                        reportDataSource = new ReportDataSource();
                        reportDataSource.Name = "dsDados";
                        _ds = new RelatoriosFAC().CriticaFolha(_competencia);
                        reportDataSource.Value = _ds.Tables[0];
                        this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                        break;
                    case enumRelatorio.RetornoFolha:
                        this.reportViewer1.LocalReport.ReportPath = @".\Relatorios\relRetornoFolha.rdlc";
                        this.reportViewer1.LocalReport.DataSources.Clear();

                        reportDataSource = new ReportDataSource();
                        reportDataSource.Name = "dsDados";
                        _ds = new RelatoriosFAC().CriticaFolha(_competencia);
                        reportDataSource.Value = _ds.Tables[0];
                        this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                        break;
                    case enumRelatorio.EnvioFolha:
                        this.reportViewer1.LocalReport.ReportPath = @".\Relatorios\relEnvioFolha.rdlc";
                        this.reportViewer1.LocalReport.DataSources.Clear();

                        reportDataSource = new ReportDataSource();
                        reportDataSource.Name = "dsDados";
                        _ds = new RelatoriosFAC().CriticaFolha(_competencia);
                        reportDataSource.Value = _ds.Tables[0];
                        this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                        parameters = new ReportParameter[1];
                        parameters[0] = new ReportParameter("Competencia", dtpCompetencia.Value.ToString("MM/yyyy"));
                        this.reportViewer1.LocalReport.SetParameters(parameters);

                        break;
                    case enumRelatorio.Aniversarios:
                        this.reportViewer1.LocalReport.ReportPath = @".\Relatorios\relAniversariantes.rdlc";
                        this.reportViewer1.LocalReport.DataSources.Clear();

                        reportDataSource = new ReportDataSource();
                        reportDataSource.Name = "dsDados";
                        _ds = new RelatoriosFAC().Aniversarios(_competencia);
                        reportDataSource.Value = _ds.Tables[0];
                        this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                        parameters = new ReportParameter[1];
                        parameters[0] = new ReportParameter("Competencia", dtpCompetencia.Value.ToString("MM/yyyy"));
                        this.reportViewer1.LocalReport.SetParameters(parameters);

                        break;
                    case enumRelatorio.MensagemAniversario:
                        
                        this.reportViewer1.LocalReport.ReportPath = @".\Relatorios\relMensagemAniversario.rdlc";
                        this.reportViewer1.LocalReport.DataSources.Clear();
                        this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);

                        reportDataSource = new ReportDataSource();
                        reportDataSource.Name = "dsDados";
                        _ds = new RelatoriosFAC().Aniversarios(_competencia);
                        reportDataSource.Value = _ds.Tables[0];
                        this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                        parameters = new ReportParameter[1];
                        parameters[0] = new ReportParameter("Competencia", dtpCompetencia.Value.ToString("MM/yyyy"));
                        this.reportViewer1.LocalReport.SetParameters(parameters);

                        break;
                    case enumRelatorio.ResumoConvenio:
                        this.reportViewer1.LocalReport.ReportPath = @".\Relatorios\relResumoConvenios.rdlc";
                        this.reportViewer1.LocalReport.DataSources.Clear();

                        reportDataSource = new ReportDataSource();
                        reportDataSource.Name = "dsDados";
                        _ds = new RelatoriosFAC().ResumoConvenios(_competencia);
                        reportDataSource.Value = _ds.Tables[0];
                        this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                        parameters = new ReportParameter[1];
                        parameters[0] = new ReportParameter("Competencia", dtpCompetencia.Value.ToString("MM/yyyy"));
                        this.reportViewer1.LocalReport.SetParameters(parameters);

                        break;


                    default:
                        break;
                }

                this.reportViewer1.ShowPrintButton = true;
                this.reportViewer1.RefreshReport();
            }
            catch (Exception)
            {

                throw;
            }
            finally { this.Cursor = Cursors.Default; }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            try
            {
                CarregarRelatorio();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
