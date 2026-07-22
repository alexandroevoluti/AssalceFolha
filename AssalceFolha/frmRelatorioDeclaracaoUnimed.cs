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
using AssalceFolha.Entity.DTO;

namespace AssalceFolha
{
    public partial class frmRelatorioDeclaracaoUnimed : Form
    {
        public enumRelatorio Relatorio { get; set; }

        public frmRelatorioDeclaracaoUnimed(enumRelatorio _relatorio)
        {

            Relatorio = _relatorio;

            InitializeComponent();

            ucAssociado1.Focus();

            this.WindowState = FormWindowState.Maximized;

            this.Text = new Enumerator<enumRelatorio>().EnumToString(_relatorio);
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Associado _associado = ucAssociado1.Associado;
                if (_associado == null) throw new Exception("Informe o associado !");
                if (!_util.ValidaData(txtAno.Text + "-01-01")) throw new Exception("Informe o ano !");

                int _ano = _util.ConvertInt(txtAno.Text);

                CarregarLista(_associado, _ano);
                CarregarRelatorio(_associado, _ano);

            }
            catch (Exception ex)
            {
                string _mensagem = ex.Message;
                if (ex.InnerException != null) _mensagem += " -- > " + ex.InnerException.Message;

                MessageBox.Show(ex.Message);
            }
        }

        private void CarregarLista(Associado _associado, int _ano)
        {
            try
            {
                List<ValoresCobrancaHapVidaDTO> _lista = new CobrancaHapVidaFAC().PesquisarValores(_associado, _ano);

                dgvDados.DataSource = _lista;
                dgvDados.AutoResizeColumns();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CarregarRelatorio(Associado _associado, int _ano)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource reportDataSource = new ReportDataSource();

                DataSet _ds;

                switch (Relatorio)
                {
                    case enumRelatorio.DeclaracaoHapVida:
                        reportViewer1.LocalReport.ReportPath = @".\Relatorios\relDeclaracaoHapVida.rdlc";

                        reportDataSource = new ReportDataSource();
                        reportDataSource.Name = "dsDados";
                        _ds = new RelatoriosFAC().DeclaracaoHapVida(_associado, _ano);
                        reportDataSource.Value = _ds.Tables[0];
                        this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                        ReportParameter[] parameters = new ReportParameter[4];
                        parameters[0] = new ReportParameter("Nome", _associado.Nome);
                        parameters[1] = new ReportParameter("CPF", _util.FormatarCpf(_associado.CPF));
                        parameters[2] = new ReportParameter("Data", "Fortaleza, " + DateTime.Now.Day.ToString("00") + " de " + new Enumerator<enumMes>().IntToString(DateTime.Now.Month) + " de " + DateTime.Now.Year.ToString("0000"));
                        parameters[3] = new ReportParameter("AnoCalendario", _ano.ToString());

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
            txtAno.Text = (DateTime.Now.Year - 1).ToString();
            btnAlterarCPF.Visible = (_ambiente.UsuarioLogado.Nome.ToUpper().Contains("KADU") || _ambiente.UsuarioLogado.Nome.ToUpper().Contains("ALEXANDRO"));
        }

        private void brnAlterarCPF_Click(object sender, EventArgs e)
        {
            frmAlterarCPFHapVida _form = new frmAlterarCPFHapVida();
            _form.ShowDialog();

        }
    }
}
