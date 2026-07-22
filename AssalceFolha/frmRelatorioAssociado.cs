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
    public partial class frmRelatorioAssociado : Form
    {
        public enumRelatorio Relatorio { get; set; }

        public frmRelatorioAssociado(enumRelatorio _relatorio)
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

                CarregarRelatorio(_associado);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CarregarRelatorio(Associado _associado)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource reportDataSource = new ReportDataSource();

                DataSet _ds;

                switch (Relatorio)
                {
                    case enumRelatorio.DadosAssociado:
                        reportViewer1.LocalReport.ReportPath = @".\Relatorios\relDadosAssociado.rdlc";

                        reportDataSource = new ReportDataSource();
                        reportDataSource.Name = "dsDados";
                        _ds = new RelatoriosFAC().DadosAssociados(_associado);
                        reportDataSource.Value = _ds.Tables[0];
                        this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                        
                        break;
                    case enumRelatorio.InclusaoModalidadeClubeDoVolei:
                        reportViewer1.LocalReport.ReportPath = @".\Relatorios\relInclusaoModalidadeClubeDoVolei.rdlc";

                        reportDataSource = new ReportDataSource();
                        reportDataSource.Name = "dsDados";
                        _ds = new RelatoriosFAC().DadosAssociados(_associado);
                        reportDataSource.Value = _ds.Tables[0];
                        this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

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
