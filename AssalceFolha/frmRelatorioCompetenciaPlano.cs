using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using AssalceFolha.BusinessLayer;
using AssalceFolha.Entity;
using Microsoft.Reporting.WinForms;

namespace AssalceFolha
{
    public partial class frmRelatorioCompetenciaPlano : Form
    {

        public enumRelatorio Relatorio { get; set; }

        public frmRelatorioCompetenciaPlano(enumRelatorio _relatorio)
        {

            Relatorio = _relatorio;

            //dtpCompetencia.Focus();

            InitializeComponent();

            // Dia 1 fixo: o formato "MM/yyyy" oculta o dia, e meses curtos gerariam data inexistente.
            dtpCompetencia.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

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
                
                switch (Relatorio)
                {                    
                    case enumRelatorio.CriticaFolha:
                        this.reportViewer1.LocalReport.ReportPath = @".\Relatorios\relCriticaFolha.rdlc";
                        this.reportViewer1.LocalReport.DataSources.Clear();

                        reportDataSource = new ReportDataSource();
                        reportDataSource.Name = "dsDados";
                        _ds = new RelatoriosFAC().CriticaFolha(_competencia, ckSomentePlanos.Checked, !ckSomenteNovos.Checked);
                        reportDataSource.Value = _ds.Tables[0];
                        this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                        List<ReportParameter> parameters = new List<ReportParameter>();
                        parameters.Add(new ReportParameter("Todos", (ckSomenteNovos.Checked? "Matrículas que não constavam na crítica do mês anterior": " ")));
                        parameters.Add( new ReportParameter("SomentePlano", (ckSomentePlanos.Checked ? "Somente eventos de plano de saúde" : " ")));

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
