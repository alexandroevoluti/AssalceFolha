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
    public partial class frmAtualizaFoto : Form
    {
        public frmAtualizaFoto()
        {
            try
            {
                //if (!new UsuarioFAC().AcessoAdministrativo(_ambiente.UsuarioLogado))
                //{
                //    throw new Exception("Usuário não tem permissão para acessar essa funcionalidade !");
                //}
            }
            catch (Exception)
            {
                throw;
            }

            InitializeComponent();
        }
        
        private void picFoto_Click(object sender, EventArgs e)
        {
            try
            {
                SelecionarArquivo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SelecionarArquivo()
        {
            try
            {
                using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
                {
                    openFileDialog1.Filter = "JPG Files|*.jpg; *.jpeg; *.png;";

                    openFileDialog1.Title = "Selecionar Foto";

                    if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        byte[] _foto = _util.ImageToByte(openFileDialog1.FileName, 65);
                        picFoto.Image = _util.ByteToImage(_foto);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Associado ConsultaAssociado()
        {
            try
            {
                if (ucAssociado1.Associado == null) throw new Exception("Associado não encontrado para a matrícula informada !");

                picFoto.Image = _util.ByteToImage(ucAssociado1.Associado.Foto);

                return ucAssociado1.Associado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAtualizaFoto_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Associado _associado = ucAssociado1.Associado;
                if (_associado == null) throw new Exception("Informe o associado");

                Image _imgfoto = picFoto.Image;

                byte[] _foto = _util.ImageToByte(_imgfoto);
                _associado.Foto = _foto;

                new AssociadoFAC().AtualizarFoto(_associado);

                this.Cursor = Cursors.Default;
                MessageBox.Show("Foto atualizada !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { this.Cursor = Cursors.Default; }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSeleiconarArquivo_Click(object sender, EventArgs e)
        {
            try
            {
                SelecionarArquivo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCapturaFoto_Click(object sender, EventArgs e)
        {
            try
            {
                frmCapturaImagem _form = new frmCapturaImagem();
                _form.ShowDialog();
                picFoto.Image = _form.Foto;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void frmAtualizaFoto_Load(object sender, EventArgs e)
        {
            ucAssociado1.txtMatriculaLeave += new EventHandler(ucAssociado1_txtMatriculaLeave);

            if (ucAssociado1.Associado != null) picFoto.Image = _util.ByteToImage(ucAssociado1.Associado.Foto);
        }

        protected void ucAssociado1_txtMatriculaLeave(object sender, EventArgs e)
        {
            Associado _associado = ucAssociado1.Associado;
            picFoto.Image = _util.ByteToImage(_associado.Foto);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _util.EnviarEnailGoogle("alexandrosilveira@gmail.com", "Teste envio", "Teste de envio pelo C#");
        }

        private void btnExcluirFoto_Click(object sender, EventArgs e)
        {
            try
            {
                Associado _associado = ucAssociado1.Associado;
                if (_associado == null) throw new Exception("Informe o associado");

                DialogResult dialogResult = MessageBox.Show("Confirma a exclusão da foto do associado ?", "Excluir foto", MessageBoxButtons.YesNo);
                if (dialogResult.Equals(DialogResult.Yes))
                {
                    this.Cursor = Cursors.WaitCursor;

                    AssociadoFAC _associadoFAC = new AssociadoFAC();

                    if (_associado == null) throw new Exception("Associado não encontrado !");
                    _associado.Foto = null;
                    _associadoFAC.AtualizarFoto(_associado);

                    MessageBox.Show("Foto excluída !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { this.Cursor = Cursors.Default; }
        }
    }
}
