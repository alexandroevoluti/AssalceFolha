using AssalceFolha.BusinessLayer;
using AssalceFolha.Entity;
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
    public partial class frmCadastroComanda : Form
    {
        public Compra Compra { get; set; }
        public Associado Associado { get; set; }

        public frmCadastroComanda(Associado _associado, Compra _compra)
        {
            InitializeComponent();

            Compra = _compra;
            Associado = _associado;

            btnExcluir.Visible = (_compra != null);
            btnSeparador.Visible = (_compra != null);

            if (_compra != null) CarregarDados();
        }

        private void CarregarDados()
        {
            try
            {

                LimparTela();

                if (Compra != null)
                {
                    Compra _compra = Compra;

                    txtCodigo.Text = _compra.ID.ToString();
                    ucConvenio1.Convenio = new ConvenioFAC().Selecionar(_compra.ID_Convenio);
                    txtAno.Text = _compra.Ano.ToString();
                    txtMes.Text = _compra.Mes.ToString("00");
                    dtCompra.Value = _util.ConvertDateTime(_compra.Data);
                    txtValor.Text = _compra.Valor.ToString("#,##0.00");
                    txtReferencia.Text = _compra.Referencia;

                    txtStatus.Text = _compra.Status;
                    txtResponsavel.Text = _compra.DataCadastro.ToString("dd/MM/yyyy HH:mm") + " - " + _compra.Usuario;
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
                txtAno.Text = "";
                txtMes.Text = "";
                txtReferencia.Text = "";
                dtCompra.Text = "";
                txtResponsavel.Text = "";
                txtStatus.Text = "";

                ucConvenio1.TipoConvenio = new TipoConvenioFAC().Selecionar(enumTipoConvenio.Compras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmCadastroCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("{tab}");
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

                DialogResult result = MessageBox.Show("Salvar registro ?", "Comanda", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result.Equals(DialogResult.No)) return;

                if (Compra == null)
                {
                    Compra = new Compra();
                    Compra.Matricula = Associado.Matricula;
                    Compra.Folha = Associado.Folha;
                }

                Compra.ID_Convenio = ucConvenio1.Convenio.ID;
                Compra.DE_Convenio = ucConvenio1.Convenio.Nome;
                Compra.Evento = ucConvenio1.Convenio.Evento;
                Compra.Ano = _util.ConvertInt(txtAno.Text);
                Compra.Mes = _util.ConvertInt(txtMes.Text);
                Compra.Data = dtCompra.Value;
                Compra.Valor = _util.ConvertDouble(txtValor.Text);
                Compra.Referencia = txtReferencia.Text;
                Compra.Status = "I";
                Compra.DataCadastro = DateTime.Now;
                Compra.Usuario = _ambiente.UsuarioLogado.Nome;

                new CompraFAC().SalvarAlone(Compra);

                MessageBox.Show("Registro Salvo !");

                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void frmCadastroCompra_Load(object sender, EventArgs e)
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Compra != null)
                {
                    Compra = new CompraFAC().Selecionar(Compra.ID);
                    Compra.Status = "*";
                    new CompraFAC().SalvarAlone(Compra);

                    this.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
