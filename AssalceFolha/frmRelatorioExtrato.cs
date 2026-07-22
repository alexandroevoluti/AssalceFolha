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
    public partial class frmRelatorioExtrato : Form
    {
        public enumRelatorio Relatorio { get; set; }

        public frmRelatorioExtrato()
        {
            InitializeComponent();

            ucAssociado1.Focus();

        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Associado _associado = ucAssociado1.Associado;
                if (_associado == null) throw new Exception("Informe o associado !");
                if (!_util.ValidaData(dtpCompetencia.Value)) throw new Exception("Informe a competência !");

                int _competencia = _util.ConvertDataParaCompetencia(dtpCompetencia.Value);

                CarregarRelatorio(_associado, _competencia);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CarregarRelatorio(Associado _associado, int _competencia)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!_util.ValidaCompetencia(_competencia)) throw new Exception("Informe a competência !");

                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource reportDataSource = new ReportDataSource();

                DataSet _ds;

                reportViewer1.LocalReport.ReportPath = @".\Relatorios\relExtrato.rdlc";

                reportDataSource = new ReportDataSource();
                reportDataSource.Name = "dsDados";
                _ds = new RelatoriosFAC().ExtratoComandaAssociado(_associado, _competencia, rbtAtivos.Checked);
                reportDataSource.Value = _ds.Tables[0];
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                ReportParameter[] parameters = new ReportParameter[1];
                parameters[0] = new ReportParameter("Competencia", dtpCompetencia.Value.ToString("MM/yyyy"));

                this.reportViewer1.LocalReport.SetParameters(parameters);


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
