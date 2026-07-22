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
    public partial class frmAtualizaFolha : Form
    {
        public frmAtualizaFolha()
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Associado _associado = ucAssociado1.Associado;

            MessageBox.Show(_associado.Nome);
        }

        private void CarregarCombos()
        {
            try
            {
                List<Folha> _lista = new FolhaFAC().Listar();
                
                cboNovaFolha.DataSource = _lista.OrderBy(x=>x.ID).ToList();
                cboNovaFolha.DisplayMember = "Nome";
                cboNovaFolha.ValueMember = "ID";                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Associado _associado = ucAssociado1.Associado;
                Folha _folha = new FolhaFAC().Seleiconar(_util.ConvertInt(cboNovaFolha.SelectedValue));

                if (_associado == null) throw new Exception("Informe o associado !");
                if (_folha == null) throw new Exception("Informe a folha !");

                DialogResult result = MessageBox.Show("Confirma a mudança da folha do associado " + _associado.Nome + " para a folha '" + _folha.Nome + "' ?", "Inclusão Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.Yes))
                {
                    _associado.Folha = _folha.ID.ToString("000");

                    new AssociadoFAC().AtualizarFolha(_associado);
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmAtualizaFolha_Load(object sender, EventArgs e)
        {
            try
            {
                CarregarCombos();
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
    }
}
