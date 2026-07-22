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
    public partial class frmLogin : Form
    {
        public Usuario Usuario { get; set; }
        public frmLogin()
        {
            InitializeComponent();            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                if (Environment.MachineName.Contains("ALEXANDRO"))
                {
                    Logar("Alexandro", "bruno");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Logar(txtLogin.Text, txtSenha.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { this.Cursor = Cursors.Default; }
        }

        private void Logar(string _usuario, string _senha)
        {
            UsuarioFAC _usuarioFAC = new UsuarioFAC();
            this.Usuario = _usuarioFAC.ValidarLogin(_usuario, _senha);
            _ambiente.UsuarioLogado = this.Usuario;

            Close();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
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

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            try
            {
                    if(!txtLogin.Text.Equals("") && !txtSenha.Text.Equals("")) Logar(txtLogin.Text, txtSenha.Text); ;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        
    }
}
