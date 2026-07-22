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
    public partial class frmCadastroUsuario : Form
    {
        UsuarioFAC _usuarioFAC = new UsuarioFAC();

        public frmCadastroUsuario()
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
                int _codigo = 0;
                int.TryParse(txtCodigo.Text, out _codigo);

                LimparTela();

                if (!_codigo.Equals(0))
                {
                    txtCodigo.Text = _codigo.ToString();
                    Usuario _usuario = _usuarioFAC.Selecionar(_codigo);

                    if (_usuario == null)
                    {
                        MessageBox.Show("Nenhume registro encontrado !");
                        return;
                    }

                    txtCodigo.Text = _usuario.ID.ToString();
                    txtNome.Text = _usuario.Nome;
                    ckAtivo.Checked = _usuario.Ativo.Equals("S");
                    txtNome.Text = _usuario.Nome;
                    cboNivelSeguranca.SelectedValue = _usuario.NivelSeguranca;
                    txtLogin.Text = _usuario.Login;
                    txtSenha.Text = _usuarioFAC.Descriptografa(_usuario.Senha);
                    txtResenha.Text = _usuarioFAC.Descriptografa(_usuario.Resenha);
                    txtDataCadastro.Text = _util.FormatarData(_usuario.Data, _util.enumFormatoData.Data);

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
                txtNome.Text = "";
                ckAtivo.Checked = false;
                txtNome.Text = "";
                txtLogin.Text = "";
                txtSenha.Text = "";
                txtResenha.Text = "";
                txtDataCadastro.Text = "";

                CarregarCombos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CarregarCombos()
        {
            try
            {
                var _lista = new Enumerator<enumNivelSeguranca>().GetAll().ToList();

                cboNivelSeguranca.DataSource = _lista;
                cboNivelSeguranca.DisplayMember = "Value";
                cboNivelSeguranca.ValueMember = "Value";
                cboNivelSeguranca.SelectedValue = "0";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btLimparTela_Click(object sender, EventArgs e)
        {
            try
            {
                LimparTela();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Excluir()
        {
            try
            {
                int _codigo = 0;
                int.TryParse(txtCodigo.Text, out _codigo);

                Usuario _usuario = new UsuarioFAC().Selecionar(_codigo);
                if (_usuario == null) throw new Exception("Usuario não encontrado !");

                if (MessageBox.Show("Confirma a exclusão do Usuario !", "Exclusão", MessageBoxButtons.YesNo).Equals(DialogResult.No)) return;

                _usuarioFAC.Excluir(_usuario);

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
                var _lista = _usuarioFAC.Listar(txtFiltro.Text).ToList();
                if (_lista != null) _lista = _lista.OrderBy(x => x.Nome.ToUpper().Trim()).ToList();

                lstUsuarios.DataSource = _lista;
                lstUsuarios.DisplayMember = "Nome";
                lstUsuarios.ValueMember = "ID";
                lstUsuarios.SelectedIndex = -1;
                if (lstUsuarios.Items.Count > 0) lstUsuarios.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                PreencherLista();
                if (lstUsuarios.Items.Count > 0) lstUsuarios.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lstUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!lstUsuarios.SelectedIndex.Equals(-1))
                {
                    txtCodigo.Text = lstUsuarios.SelectedValue.ToString();
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

                int _codigo = _util.ConvertInt(txtCodigo.Text);

                Usuario _usuario = new Usuario()
                {
                    ID = _codigo.ToString(),
                    Nome = txtNome.Text,
                    Login = txtLogin.Text,
                    NivelSeguranca = cboNivelSeguranca.SelectedValue.ToString(),
                    Senha = _usuarioFAC.Criptografa(txtSenha.Text),
                    Resenha = _usuarioFAC.Criptografa(txtResenha.Text),
                    Data = DateTime.Now,
                    Ativo = (ckAtivo.Checked ? "S" : "N")
                };

                _usuario = _usuarioFAC.Salvar(_usuario);

                txtCodigo.Text = _usuario.ID.ToString();

                MessageBox.Show("Resgistro salvo!");

                PreencherLista();
                LimparTela();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Crítica");
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCadastroUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
