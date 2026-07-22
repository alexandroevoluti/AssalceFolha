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

namespace AssalceFolha
{
    public partial class MDIAssalce : Form
    {
        private int childFormNumber = 0;
        public Usuario Usuario { get; set; }

        public MDIAssalce()
        {
            try
            {
                InitializeComponent();

                if (this.Usuario == null)
                {
                    frmLogin childForm = new frmLogin();
                    //childForm.MdiParent = this;
                    childForm.ShowDialog();

                    if (childForm.Usuario == null)
                    {
                        Close();
                    }
                    else
                    {
                        this.Usuario = childForm.Usuario;

                        statusStrip.Items[0].Alignment = ToolStripItemAlignment.Right;
                        statusStrip.Items[0].Text = _util.NomeServidor() + " - " + _util.NomeBanco();

                        statusStrip.Items[1].Alignment = ToolStripItemAlignment.Right;
                        statusStrip.Items[1].Text = Usuario.Nome;

                        AssociadoFAC _associadoFAC = new AssociadoFAC();
                        statusStrip.Items[2].Alignment = ToolStripItemAlignment.Right;
                        statusStrip.Items[2].Text = "Total Associados " + _associadoFAC.TotalAssociados().ToString("#,##0");

                        statusStrip.Items[3].Alignment = ToolStripItemAlignment.Right;
                        statusStrip.Items[3].Text = "Total Ativos " + _associadoFAC.TotalAtivos().ToString("#,##0"); ;

                        frmPrincipal childForm2 = new frmPrincipal();
                        childForm2.MdiParent = this;
                        childForm2.WindowState = FormWindowState.Normal;
                        childForm2.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }


        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                frmPrincipal childForm = new frmPrincipal();
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }

        private void mnuFecharMes_Click(object sender, EventArgs e)
        {
            try
            {
                frmFechamentoMes childForm = new frmFechamentoMes();
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }

        private void mnuCargaArquivosConvênios_Click(object sender, EventArgs e)
        {
            try
            {
                frmCargaArquivosFolha childForm = new frmCargaArquivosFolha();
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void retornoFolhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmRetornoFolha childForm = new frmRetornoFolha();
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }

        private void mapaCSGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmRelatorioCompetencia childForm = new frmRelatorioCompetencia(enumRelatorio.MapaCSG);
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }

        private void envioMensalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmRelatorioCompetencia childForm = new frmRelatorioCompetencia(enumRelatorio.EnvioFolha);
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }

        private void extratoDeComandasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //frmRelatorioAssociadoCompetencia childForm = new frmRelatorioAssociadoCompetencia(enumRelatorio.ExtratoComandas);
                frmRelatorioAssociadoPeriodo childForm = new frmRelatorioAssociadoPeriodo(enumRelatorio.ExtratoComandas);
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }

        private void atualizaFotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmAtualizaFoto childForm = new frmAtualizaFoto();
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }

        private void atualizaFolhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmAtualizaFolha childForm = new frmAtualizaFolha();
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }

        private void principalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmPrincipal childForm = new frmPrincipal();
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }

        private void aniversariantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmRelatorioCompetencia childForm = new frmRelatorioCompetencia(enumRelatorio.Aniversarios);
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }

        private void adiantamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdiantamento childForm = new frmAdiantamento();
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }

        private void cargaArquivoEnvioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmTmpCargaArquivoEnvio childForm = new frmTmpCargaArquivoEnvio();
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmCadastroUsuario childForm = new frmCadastroUsuario();
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }

        private void mensagemAniversárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmRelatorioCompetencia childForm = new frmRelatorioCompetencia(enumRelatorio.MensagemAniversario);
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }

        private void resumoConvêniosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmRelatorioCompetencia childForm = new frmRelatorioCompetencia(enumRelatorio.ResumoConvenio);
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }

        private void atualizarFolhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAtualizaFolha childForm = new frmAtualizaFolha();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void atualizaçãoDadosAssociadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAtualizacaoDadosAssociados childForm = new frmAtualizacaoDadosAssociados();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void convêniosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroConvenio childForm = new frmCadastroConvenio();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void dadosAssociadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmRelatorioAssociado childForm = new frmRelatorioAssociado(enumRelatorio.DadosAssociado);
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }

        private void listarAssociadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmListarAssociados childForm = new frmListarAssociados();
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }

        private void comparativoEnvioXRetornoFolhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmRelatorioAssociadoPeriodo childForm = new frmRelatorioAssociadoPeriodo(enumRelatorio.ComparativoEnvioRetornoFolha);
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }


        private void inclusãoDeModalidadeClubeDoVôleiToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                frmRelatorioAssociado childForm = new frmRelatorioAssociado(enumRelatorio.InclusaoModalidadeClubeDoVolei);
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }

        private void tMPCargaArquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmtmpCargaDados childForm = new frmtmpCargaDados();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void cargaMargemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCargaMargem childForm = new frmCargaMargem();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsulta childForm = new frmConsulta();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void trataArquivoDeEnvioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTrataArquivoFolha childForm = new frmTrataArquivoFolha();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void atualizaSituaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAtualizaSituacao childForm = new frmAtualizaSituacao();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void cargaCobrançaHapVidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCargaCobrancaHapVida childForm = new frmCargaCobrancaHapVida();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void declaraçãoHapVidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelatorioDeclaracaoHapVida childForm = new frmRelatorioDeclaracaoHapVida(enumRelatorio.DeclaracaoHapVida);
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void cargaBancosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmCargaBanco childForm = new frmCargaBanco();
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }

        private void convênioNaCompetênciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmRelatorioConvenioCompetecia childForm = new frmRelatorioConvenioCompetecia(enumRelatorio.ConvenioCompetencia);
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }

        private void extratoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmRelatorioExtrato childForm = new frmRelatorioExtrato();
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }

        private void acompanhamentoMensalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmAcompanhamentoMensal childForm = new frmAcompanhamentoMensal();
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }

        private void tMPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmAtualizaFolhaEmMassa childForm = new frmAtualizaFolhaEmMassa();
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }

        private void consultaSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmConsultaSQL childForm = new frmConsultaSQL();
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }

        private void dadosPlanoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmConsultarDadosPlano childForm = new frmConsultarDadosPlano();
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }

        private void contribuiçãoBoletoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmContribuicaoAssalce childForm = new frmContribuicaoAssalce();
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }

        private void configuraçãoCobrançaPlanoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmConfigurarCobrancaPlano childForm = new frmConfigurarCobrancaPlano();
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Assalce");
            }
        }
    }
}
