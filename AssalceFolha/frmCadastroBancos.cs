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
    public partial class frmCadastroBancos : _baseForm
    {
        public Banco Banco { get; set; }
        public Associado Associado { get; set; }

        public frmCadastroBancos(Associado _associado, Banco _banco)
        {
            InitializeComponent();
            
            Banco = _banco;
            Associado = _associado;

            btnExcluir.Visible = (_banco != null);
            btnSeparador.Visible = (_banco != null);

            if (_banco != null) CarregarDados();
        }

        private void CarregarDados()
        {
            try
            {

                LimparTela();

                if (Banco != null)
                {
                    Banco _banco = Banco;

                    txtCodigo.Text = _banco.ID.ToString();
                    ucConvenio1.Convenio = _banco.Convenio;
                    txtValor.Text = _banco.Valor.ToString("#,##0.00");
                    txtParcela.Text = _banco.Parcelas.ToString();
                    txtValorParcela.Text = _banco.ValorParcela.ToString("#,##0.00");
                    dtInicio.Value = _banco.DataInicio;
                    if (_banco.DataTermino != null) dtFim.Text = _util.FormatarData(_banco.DataTermino, _util.enumFormatoData.Data);
                    txtStatus.Text = _banco.Status;
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

                dtInicio.Value = _util.PrimeiroDiaMes();
                dtFim.Value = _util.PrimeiroDiaMes();

                txtStatus.Text = "";

                ucConvenio1.TipoConvenio = new TipoConvenioFAC().Selecionar(enumTipoConvenio.Bancos);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmCadastroBanco_KeyDown(object sender, KeyEventArgs e)
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidaSituacaoAssociado(Associado);

                DialogResult result = MessageBox.Show("Salvar registro ?", "Financiemanto", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result.Equals(DialogResult.No)) return;

                if (Banco == null)
                {
                    Banco = new Banco();
                    Banco.Matricula = Associado.Matricula;
                    Banco.Folha = Associado.Folha;
                }

                Banco.Convenio = ucConvenio1.Convenio;
                Banco.Evento = ucConvenio1.Convenio.Evento;
                Banco.Nome = ucConvenio1.Convenio.Nome;
                Banco.DataInicio = dtInicio.Value;
                Banco.DataTermino = dtFim.Value;
                Banco.Valor = _util.ConvertDouble(txtValor.Text);
                Banco.Parcelas = _util.ConvertInt(txtParcela.Text);
                Banco.ValorParcela = _util.ConvertDouble(txtValorParcela.Text);
                Banco.Status = "I";
                Banco.DataCadastro = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                Banco.Usuario = _ambiente.UsuarioLogado.Nome;

                new BancoFAC().SalvarAlone(Banco);

                MessageBox.Show("Registro incluído !");

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

        private void frmCadastroBanco_Load(object sender, EventArgs e)
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
                int _parcelas = _util.ConvertInt(txtParcela.Text);


                dtInicio.Value = _util.PrimeiroDiaMes();
                dtFim.Value = dtInicio.Value.AddMonths(_parcelas - 1);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btCalculaDataFinal_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_util.ValidaData(dtInicio.Text)) throw new Exception("Informe a data inicial !");
                if (!_util.ValidaInt(txtParcela.Text)) throw new Exception("Informe a quantidade de parcelas !");

                DateTime _data = _util.ConvertDateTime(dtInicio.Text);
                int _qtdeParcelas = _util.ConvertInt(txtParcela.Text);

                dtFim.Value= _util.ConvertDateTime(_data.AddMonths(_qtdeParcelas - 1));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
