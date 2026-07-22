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
    public partial class frmRelatorioAssociadoCompetencia : Form
    {
        public enumRelatorio Relatorio { get; set; }

        public frmRelatorioAssociadoCompetencia(enumRelatorio _relatorio)
        {

            Relatorio = _relatorio;

            

            InitializeComponent();

            ucAssociado1.Focus();

            this.Text = new Enumerator<enumRelatorio>().EnumToString(_relatorio);
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

                switch (Relatorio)
                {
                    case enumRelatorio.ExtratoComandas:
                        reportViewer1.LocalReport.ReportPath = @".\Relatorios\relExtratoComanda.rdlc";

                        reportDataSource = new ReportDataSource();
                        reportDataSource.Name = "dsDados";
                        _ds = new RelatoriosFAC().ExtratoComanda(_associado, _competencia);
                        reportDataSource.Value = _ds.Tables[0];
                        this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                        
                        ReportParameter[] parameters = new ReportParameter[1];
                        parameters[0] = new ReportParameter("competencia", dtpCompetencia.Value.ToString("MM/yyyy"));

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

        private void frmRelatorioAssociadoCompetencia_Load(object sender, EventArgs e)
        {

        }
    }
}
