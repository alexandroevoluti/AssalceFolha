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
    public partial class frmCadastroPlano : _baseForm
    {
        public Plano Plano { get; set; }
        public Associado Associado { get; set; }

        public frmCadastroPlano(Associado _associado, Plano _plano)
        {
            InitializeComponent();

            Plano = _plano;
            Associado = _associado;

            mskDataInicio.Text = _util.PrimeiroDiaMes().ToString("dd/MM/yyyy");

            btnExcluir.Visible = (_plano  != null);
            btnSeparador.Visible = (_plano != null);

            if (_plano != null) CarregarDados();
        }

        private void CarregarDados()
        {
            try
            {

                LimparTela();

                if (Plano != null)
                {
                    Plano _plano = Plano;

                    txtCodigo.Text = _plano.ID.ToString();
                    ucConvenio1.Convenio = _plano.Convenio;
                    txtUsuario.Text = _plano.UsuarioPlano;

                    if (_plano.Parentesco != null) cboParentesco.SelectedValue = _plano.Parentesco; 
                    if (_plano.TP != null) cboTipoUsuario.SelectedValue = _plano.TP;
                    if (_plano.Acomodacao != null) cboAcomodacao.SelectedValue = _plano.Acomodacao;
                    
                    txtValor.Text = _plano.Valor.ToString("#,##0.00");

                    if (_plano.DataNascimento != null) mskDatNascimento.Text =  _util.FormatarData(_plano.DataNascimento,_util.enumFormatoData.Data);

                    mskDataInicio.Text = _plano.DataInicio.ToShortDateString();
                    mskDataFim.Text =  _util.FormatarData( _plano.DataTermino, _util.enumFormatoData.Data);
                    txtStatus.Text = _plano.Status;
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
                txtCodigo.Text = "";
                ucConvenio1.Limpar();
                txtUsuario.Text = "";

                txtValor.Text = "";

                mskDatNascimento.Text = "";
                mskDataInicio.Text = _util.PrimeiroDiaMes().ToString("dd/MM/yyyy");
                mskDataFim.Text = "";
                txtStatus.Text = "";

                CarregarCombos();

                ucConvenio1.TipoConvenio = new TipoConvenioFAC().Selecionar(enumTipoConvenio.Planos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmCadastroPlano_KeyDown(object sender, KeyEventArgs e)
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

                if (Plano == null)
                {
                    Plano = new Plano();
                    Plano.Matricula = Associado.Matricula;
                    Plano.Folha = Associado.Folha;
                }

                Plano.Convenio = ucConvenio1.Convenio;
                Plano.Evento = ucConvenio1.Convenio.Evento;
                Plano.Nome = ucConvenio1.Convenio.Nome;


                Plano.Parentesco = cboParentesco.SelectedValue.ToString();
                Plano.Acomodacao = cboAcomodacao.SelectedValue.ToString();
                Plano.TP = cboTipoUsuario.SelectedValue.ToString();

                Plano.UsuarioPlano = txtUsuario.Text;
                Plano.DataNascimento = _util.ConvertDateTimeNullable(mskDatNascimento.Text);
                Plano.DataInicio = _util.ConvertDateTime(mskDataInicio.Text);
                Plano.DataTermino = _util.ConvertDateTimeNullable(mskDataFim.Text);
                Plano.Valor = _util.ConvertDouble(txtValor.Text);
            
                Plano.Status = "I";
                Plano.DataCadastro = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                Plano.Usuario = _ambiente.UsuarioLogado.Nome;

                new PlanoFAC().SalvarAlone(Plano);

                MessageBox.Show("Registro incluído !");

                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CarregarCombos()
        {
            try
            {
                var _listaAcomodacao = new AcomodacaoFAC().Listar();
                cboAcomodacao.DataSource = _listaAcomodacao;
                cboAcomodacao.DisplayMember = "DESCRICAO";
                cboAcomodacao.ValueMember = "DESCRICAO";

                var _listaTipoUsuario = new TipoUsuarioPlanoFAC().Listar();
                cboTipoUsuario.DataSource = _listaTipoUsuario;
                cboTipoUsuario.DisplayMember = "DESCRICAO";
                cboTipoUsuario.ValueMember = "SIGLA";

                var _listaParentesco = new ParentescoFAC().Listar();
                cboParentesco.DataSource = _listaParentesco;
                cboParentesco.DisplayMember = "DESCRICAO";
                cboParentesco.ValueMember = "DESCRICAO";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmCadastroPlano_Load(object sender, EventArgs e)
        {
            try
            {
                CarregarCombos();
                CarregarDados();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSair_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
