using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AssalceFolha.BusinessLayer;
using AssalceFolha.Entity;

namespace AssalceFolha
{
    public partial class frmCadastroConvenio : Form
    {
        ConveniadoFAC _conveniadoFAC = new ConveniadoFAC();

        public frmCadastroConvenio()
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

            try
            {
                InitializeComponent();
                PreencherLista();
                LimparTela();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sbConsultar()
        {
            try
            {
                int _codigo = _util.ConvertInt(txtCodigo.Text);
                LimparTela();

                if (!_codigo.Equals(0))
                {
                    txtCodigo.Text = _codigo.ToString();
                    Conveniado _conveniado = _conveniadoFAC.Selecionar(_codigo);

                    if (_conveniado == null)
                    {
                        MessageBox.Show("Nenhume registro encontrado !");
                        return;
                    }

                    txtCodigo.Text = _conveniado.ID.ToString();
                    ckAtivo.Checked = _conveniado.Ativo.Equals("S");
                    txtNome.Text = _conveniado.Nome;
                    txtCNPJ.Text = _util.FormatarCnpj(_conveniado.CNPJ);
                    txtNome.Text = _conveniado.Nome;
                    txtEndereco.Text = _conveniado.Endereco;
                    txtBairro.Text = _conveniado.Bairro;
                    txtCEP.Text = _conveniado.CEP;
                    txtCidade.Text = _conveniado.Cidade;
                    txtEstado.Text = _conveniado.Estado;
                    txtTelefone.Text = _conveniado.Telefone;
                    txtContato.Text = _conveniado.Contato;
                    txtTaxa.Text = _conveniado.Taxa.ToString();
                    txtVerba.Text = _conveniado.Verba;
                    if (_conveniado.Convenio != null)
                    {
                        if (_conveniado.Convenio.Parcelado == null) _conveniado.Convenio.Parcelado = "N";
                        ckParcelado.Checked = _conveniado.Convenio.Parcelado.Equals("S");
                        txtMaximoParcelas.Text = _conveniado.Convenio.ParcelamentoMaximo.ToString();
                        txtCodEvento.Text = _conveniado.Convenio.Evento;
                        txtDiaVencto.Text = _conveniado.Convenio.DiaVencimento.ToString();
                        txtDescEventoDRH.Text = _conveniado.Convenio.NomeConvenio;
                    }
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
                txtCodigo.Enabled = false;
                txtCodigo.Text = "";
                ckAtivo.Checked = false;
                txtCNPJ.Text = "";
                txtNome.Text = "";
                txtEndereco.Text = "";
                txtBairro.Text = "";
                txtCEP.Text = "";
                txtCidade.Text = "FORTALEZA";
                txtEstado.Text = "CE";
                txtTelefone.Text = "";
                txtContato.Text = "";
                txtTaxa.Text = "5";
                txtVerba.Text = "664";
                ckParcelado.Checked = false;
                txtMaximoParcelas.Text = "";
                txtCodEvento.Text = "664";
                txtDiaVencto.Text = "";
                txtDescEventoDRH.Text = "ASSALCE I I - PARCELAMENTO";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private void btLimparTela_Click(object sender, EventArgs e)
        {

        }

        private void Excluir()
        {
            try
            {
                int _codigo = 0;
                int.TryParse(txtCodigo.Text, out _codigo);

                Conveniado _conveniado = new ConveniadoFAC().Selecionar(_codigo);
                if (_conveniado == null) throw new Exception("Conveniado não encontrado !");

                if (MessageBox.Show("Confirma a exclusão do Conveniado !", "Exclusão", MessageBoxButtons.YesNo).Equals(DialogResult.No)) return;

                _conveniadoFAC.Excluir(_conveniado);

                PreencherLista();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void PreencherLista()
        {
            try
            {
                var _lista = new _domainFAC().Convenio(_util.ConvertInt(txtFiltro.Text), txtFiltro.Text);

                //var _lista = _conveniadoFAC.Listar(_util.ConvertInt(txtFiltro.Text), txtFiltro.Text);
                if (_lista != null) _lista = _lista.OrderBy(x => x.Nome.ToUpper().Trim()).ToList();

                lstConveniados.DataSource = _lista;
                lstConveniados.DisplayMember = "Nome";
                lstConveniados.ValueMember = "ID";
                lstConveniados.SelectedIndex = -1;
                if (lstConveniados.Items.Count > 0) lstConveniados.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void lstConveniados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!lstConveniados.SelectedIndex.Equals(-1))
                {
                    txtCodigo.Text = lstConveniados.SelectedValue.ToString();
                    sbConsultar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                Conveniado _conveniado = _conveniadoFAC.Salvar(MontarObjeto());

                txtCodigo.Text = _conveniado.ID.ToString();

                MessageBox.Show("Resgistro salvo!");

                PreencherLista();
                LimparTela();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Crítica");
            }
            finally { Cursor = Cursors.Default;}
        }

        private Conveniado MontarObjeto()
        {
            try
            {
                int _codigo = _util.ConvertInt(txtCodigo.Text);
                Conveniado _conveniado = _conveniadoFAC.Selecionar(_codigo);

                if (_conveniado != null && txtCodigo.Enabled) throw new Exception("Já existe um conveniado para o código informado !");
                if (_conveniado == null) _conveniado = new Conveniado();

                _conveniado.ID = _util.PreencherString(_codigo, "0", _util.enumDirecao.Esquerda, 3); ;
                _conveniado.Ativo = (ckAtivo.Checked ? "S" : "N");
                _conveniado.Nome = txtNome.Text.ToUpper();
                _conveniado.CNPJ = _util.SomenteNumeros(txtCNPJ.Text);
                _conveniado.Endereco = txtEndereco.Text.ToUpper();
                _conveniado.Bairro = txtBairro.Text.ToUpper();
                _conveniado.CEP = txtCEP.Text;
                _conveniado.Cidade = txtCidade.Text.ToUpper();
                _conveniado.Estado = txtEstado.Text.ToUpper();
                _conveniado.Telefone = txtTelefone.Text;
                _conveniado.Contato = txtContato.Text.ToUpper();
                _conveniado.Taxa = _util.ConvertDouble(txtTaxa.Text);
                _conveniado.Verba = null;
                if (!txtVerba.Text.Trim().Equals("")) _conveniado.Verba = _util.PreencherString(txtVerba.Text,"0",_util.enumDirecao.Esquerda, 3);

                if (_conveniado.Convenio == null) _conveniado.Convenio = new Convenio();
                _conveniado.Convenio.ID = _conveniado.ID;
                _conveniado.Convenio.Nome = _conveniado.Nome;
                _conveniado.Convenio.Ativo = _conveniado.Ativo;

                _conveniado.Convenio.Parcelado = (ckParcelado.Checked?"S":"N");
                _conveniado.Convenio.ParcelamentoMaximo = _util.ConvertInt(txtMaximoParcelas.Text.ToString());
                _conveniado.Convenio.Evento = null;
                if (!txtCodEvento.Text.Trim().Equals("")) _conveniado.Convenio.Evento = _util.PreencherString(txtCodEvento.Text, "0", _util.enumDirecao.Esquerda, 3); 
                _conveniado.Convenio.DiaVencimento = _util.ConvertIntNullable(txtDiaVencto.Text);
                _conveniado.Convenio.NomeConvenio = txtDescEventoDRH.Text.ToUpper();
                
                return _conveniado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                PreencherLista();
                if (lstConveniados.Items.Count > 0) lstConveniados.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                LimparTela();
                txtCodigo.Enabled = true;
                txtCodigo.Text = new ConvenioFAC().ProximoID().ToString();
                ckAtivo.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

