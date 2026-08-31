using AssalceFolha.BusinessLayer;
using AssalceFolha.Entity;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssalceFolha
{
    public partial class frmRelatorioConvenioCompetecia : Form
    {
        public enumRelatorio Relatorio { get; set; }

        public frmRelatorioConvenioCompetecia(enumRelatorio _relatorio)
        {
            Relatorio = _relatorio;

            InitializeComponent();


            // Dia 1 fixo: o formato "MM/yyyy" oculta o dia, e meses curtos gerariam data inexistente.
            dtCompetencia.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

           
            this.Text = new Enumerator<enumRelatorio>().EnumToString(_relatorio);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Convenio _convenio = ucConvenio1.Convenio;

                if (_convenio == null) throw new Exception("Informe o convênio !");
                if (!_util.ValidaData(dtCompetencia.Value)) throw new Exception("Informe a competência !");

                int _competencia = _util.ConvertDataParaCompetencia(dtCompetencia.Value);

                CarregarRelatorio(_convenio, _competencia);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CarregarRelatorio(Convenio _convenio, int _competencia)
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
                    case enumRelatorio.ConvenioCompetencia:
                        reportViewer1.LocalReport.ReportPath = @".\Relatorios\relConvenioCompetencia.rdlc";

                        reportDataSource = new ReportDataSource();
                        reportDataSource.Name = "dsConvenioMes";
                        _ds = new RelatoriosFAC().ConvenioCompetencia(_convenio, _competencia);
                        reportDataSource.Value = _ds.Tables[0];
                        this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                        ReportParameter[] parameters = new ReportParameter[2];
                        parameters[0] = new ReportParameter("Competencia", dtCompetencia.Value.ToString("MM/yyyy"));
                        parameters[1] = new ReportParameter("Convenio", _convenio.ID.ToString() + " - " + _convenio.Nome);

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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRelatorioConvenioCompetecia_Load(object sender, EventArgs e)
        {
            ucConvenio1.Focus();
        }
    }
}
