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
    public partial class frmFechamentoMes : _baseForm
    {
        public frmFechamentoMes()
        {
            try
            {
                if (!new UsuarioFAC().AcessoAdministrativo(_ambiente.UsuarioLogado))
                {
                    throw new Exception("Usuário não tem permissão para acessar essa funcionalidade !");
                }
            }
            catch (Exception)
            {
                throw;
            }

            InitializeComponent();

            // Dia 1 fixo: o formato "MM/yyyy" oculta o dia, e meses curtos gerariam data inexistente.
            dtpCompetencia.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        private void btnFecharMes_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirma o fechamento da competência " + dtpCompetencia.Value.ToString("MM/yyyy"), "Confirmação", MessageBoxButtons.YesNo).Equals(DialogResult.No)) return;

                EnvioFolhaFAC _envioFolhaFAC = new EnvioFolhaFAC();

                this.Cursor = Cursors.WaitCursor;

                int _ano = dtpCompetencia.Value.Year;
                int _mes = dtpCompetencia.Value.Month;

                if (_envioFolhaFAC.ExisteEnvio(_ano, _mes)) throw new Exception("Já existe envio para a competência informada !");

                string _arquivo = _envioFolhaFAC.FechamentoMes(_ano, _mes);

                ExibirRelatorio();

                this.Cursor = Cursors.Default;
                MessageBox.Show("Fechamento do mês concluído !" + Environment.NewLine + "Arquivo gerado: " + _arquivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { this.Cursor = Cursors.Default; }
        }

        private void ExibirRelatorio()
        {
            this.reportViewer1.LocalReport.ReportPath = @".\Relatorios\relEnvioFolha.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();

            int _competencia = dtpCompetencia.Value.Year * 100 + dtpCompetencia.Value.Month;

            
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "dsDados";
            DataSet _ds = new RelatoriosFAC().EnvioFolha(_competencia);
            reportDataSource.Value = _ds.Tables[0];
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("Competencia", dtpCompetencia.Value.ToString("MM/yyyy"));

            this.reportViewer1.LocalReport.SetParameters(parameters);

            this.reportViewer1.RefreshReport();

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGerarArquivo_Click(object sender, EventArgs e)
        {
            try
            {

                string _arquivo  = new EnvioFolhaFAC().GerarArquivo(_util.ConvertCompetenciaParaInteiro(dtpCompetencia.Value.ToString("MM/yyyy")));

                MessageBox.Show("Arquivo gerado !" + Environment.NewLine + _arquivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExibirRelatorioFechamento()
        {
            this.reportViewer1.LocalReport.ReportPath = @".\Relatorios\relFechamentoMes.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();

            int _competencia = dtpCompetencia.Value.Year * 100 + dtpCompetencia.Value.Month;

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "dsDados";
            DataSet _ds = new RelatoriosFAC().FechamentoMes(_competencia);
            reportDataSource.Value = _ds.Tables[0];
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("Competencia", dtpCompetencia.Value.ToString("MM/yyyy"));

            this.reportViewer1.LocalReport.SetParameters(parameters);

            this.reportViewer1.RefreshReport();

        }

        private void btnRelFechamentoMes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                ExibirRelatorioFechamento();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { this.Cursor = Cursors.Default; }
        }
    }
}
