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
    public partial class frmCadastroFinanciamento : _baseForm
    {
        public Financiamento Financiamento { get; set; }
        public Associado Associado { get; set; }

        public frmCadastroFinanciamento(Associado _associado, Financiamento _financiamento)
        {
            InitializeComponent();

            Financiamento = _financiamento;
            Associado = _associado;

            btnExcluir.Visible = (_financiamento != null);
            btnSeparador.Visible = (_financiamento != null);

            if (_financiamento != null) CarregarDados();
        }

        private void CarregarDados()
        {
            try
            {

                LimparTela();

                if (Financiamento != null)
                {
                    Financiamento _financiamento = Financiamento;

                    txtCodigo.Text = _financiamento.ID.ToString();
                    ucConvenio1.Convenio = _financiamento.Convenio;
                    txtValor.Text = _financiamento.Valor.ToString("#,##0.00");
                    txtParcela.Text = _financiamento.Parcelas.ToString();
                    txtValorParcela.Text = _financiamento.ValorParcela.ToString("#,##0.00");
                    dtInicio.Value = _financiamento.DataInicio;
                    if (_financiamento.DataTermino != null) dtFim.Text = _util.FormatarData(_financiamento.DataTermino, _util.enumFormatoData.Data);
                    txtStatus.Text = _financiamento.Status;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LimparTela()
        {
            try
            {
                ucConvenio1.Limpar();
                txtCodigo.Text = "";
                txtValor.Text = "";
                txtParcela.Text = "";
                txtValorParcela.Text = "";
                dtInicio.Text = "";
                dtFim.Text = "";
                txtStatus.Text = "";

                ucConvenio1.TipoConvenio = new TipoConvenioFAC().Selecionar(enumTipoConvenio.Financiamentos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmCadastroFinanciamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //e.Handled = true;
                e.SuppressKeyPress = true;
                SendKeys.Send("{tab}");
                //if (this.GetNextControl(ActiveControl, true) != null)
                //{
                //    e.Handled = true;
                //    this.GetNextControl(ActiveControl, true).Focus();

                //}
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ValidaSituacaoAssociado(Associado _associado)
        {
            try
            {

                if (!_ambiente.UsuarioLogado.NivelSeguranca.Equals("ADM") && !_associado.Situacao.Equals("ASSOCIADO"))
                {
                    throw new Exception("Atenção ! O Associado não se encontra autorizado !");
                }

                if (!_ambiente.UsuarioLogado.NivelSeguranca.Equals("ADM") && !_associado.Situacao.IndexOf("BLOQ").Equals(-1))
                {
                    throw new Exception("Atenção ! O Associado não se encontra autorizado !");
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidaSituacaoAssociado(Associado);

                DialogResult result = MessageBox.Show("Salvar registro ?", "Financiemanto", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result.Equals(DialogResult.No)) return;

                if (Financiamento == null)
                {
                    Financiamento = new Financiamento();
                    Financiamento.Matricula = Associado.Matricula;
                    Financiamento.Folha = Associado.Folha;
                }

                Financiamento.Convenio = ucConvenio1.Convenio;
                Financiamento.Evento = ucConvenio1.Convenio.Evento;
                Financiamento.Nome = ucConvenio1.Convenio.Nome;
                Financiamento.DataInicio = dtInicio.Value;
                Financiamento.DataTermino = dtFim.Value;
                Financiamento.Valor = _util.ConvertDouble(txtValor.Text);
                Financiamento.Parcelas = _util.ConvertInt(txtParcela.Text);
                Financiamento.ValorParcela = _util.ConvertDouble(txtValorParcela.Text);
                Financiamento.Status = "I";
                Financiamento.DataCadastro = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                Financiamento.Usuario = _ambiente.UsuarioLogado.Nome;

                new FinanciamentoFAC().SalvarAlone(Financiamento);

                MessageBox.Show("Registro incluído !");

                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void frmCadastroFinanciamento_Load(object sender, EventArgs e)
        {
            try
            {
                CarregarDados();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtParcela_Leave(object sender, EventArgs e)
        {
            try
            {
                bool _alterar = true;
                int _parcelas = _util.ConvertInt(txtParcela.Text);

                if (Financiamento != null)
                {
                    _alterar = _parcelas != Financiamento.Parcelas;
                }

                if (_alterar)
                {
                    dtInicio.Value = DateTime.Now;
                    dtFim.Value = dtInicio.Value.AddMonths(_parcelas);
                }            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}
    }
}
