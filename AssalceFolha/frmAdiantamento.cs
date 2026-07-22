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
    public partial class frmAdiantamento : _baseForm
    {
        public frmAdiantamento()
        {
            InitializeComponent();

            dtpDataInicial.Value = new AdiantamentoFAC().PrimeiraParcela();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {

                AdiantamentoFAC _adiantamentoFAC = new BusinessLayer.AdiantamentoFAC();
                Adiantamento _adiantamento = new Adiantamento()
                {
                    Matricula = ucAssociado1.Associado.Matricula,
                    Folha = ucAssociado1.Associado.Folha,
                    Data = DateTime.Now,
                    Parcelas = _util.ConvertInt(txtParcelas.Text),
                    Valor = _util.ConvertDouble(txtValor.Text),
                    ValorParcela = _adiantamentoFAC.CalcularParcela(_util.ConvertDouble(txtValor.Text), _util.ConvertInt(txtParcelas.Text))
                };

                string _extensoValor = _extenso.NumeroParaExtenso(_adiantamento.Valor);
                string _extensoParcelas = _extenso.NumeroParaExtenso(_adiantamento.Parcelas, false);
                string _extensoValorParcela = _extenso.NumeroParaExtenso(_adiantamento.ValorParcela);

                DialogResult result = MessageBox.Show("Confirma o adiantamento no valor R$ " + _adiantamento.Valor.ToString("#,##0.00") + " em " + _adiantamento.Parcelas.ToString() + " parcelas de R$ " + _adiantamento.ValorParcela.ToString("#,##0.00") + "  do associado " + ucAssociado1.Associado.Nome + " ?", "Inclusão Adiantamento", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result.Equals(DialogResult.No)) return;


                _adiantamento = _adiantamentoFAC.IncluirAlone(_adiantamento, _ambiente.UsuarioLogado);

                frmRelatorio _frm = new frmRelatorio(enumRelatorio.Adiantamento, _adiantamento);
                _frm.ShowDialog();

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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdiantamentoFAC _adiantamentoFAC = new BusinessLayer.AdiantamentoFAC();

            txtPrestacao.Text = _adiantamentoFAC.CalcularParcela(_util.ConvertDouble(txtValor.Text), _util.ConvertInt(txtParcelas.Text)).ToString("#,##0.00");
        }

        private void frmAdiantamento_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    if (this.GetNextControl(ActiveControl, true) != null)
                    {
                        e.Handled = true;
                        this.GetNextControl(ActiveControl, true).Focus();

                    }
                }            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
