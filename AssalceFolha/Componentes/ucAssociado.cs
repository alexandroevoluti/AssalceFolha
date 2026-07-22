using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AssalceFolha.Entity;
using AssalceFolha.BusinessLayer;

namespace AssalceFolha
{
    public partial class ucAssociado : UserControl
    {
        public event EventHandler txtMatriculaLeave;

        public Associado Associado { get; set; }

        public ucAssociado()
        {
            InitializeComponent();
        }

        private void txtMatricula_Leave(object sender, EventArgs e)
        {
            try
            {
                ConsultaAssociado();

                if (this.txtMatriculaLeave != null) this.txtMatriculaLeave(this, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Associado ConsultaAssociado()
        {
            try
            {
                int _matricula = _util.ConvertInt(txtMatricula.Text);
                Associado = null;

                Associado _associado = new AssociadoFAC().SelecionarPorMatricula(_matricula.ToString());
                txtNome.Text = "";
                txtFolha.Text = "";

                if (_associado == null) throw new Exception("Associado não encontrado para a matrícula informada !");

                Associado = _associado;
                _ambiente.Associado = Associado;

                CarregarDados(_associado);

                return _associado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CarregarDados(Associado _associado)
        {
            try
            {
                txtNome.Text = "";
                txtFolha.Text = "";

                if (_associado != null)
                {
                    if (_util.ConvertInt( _associado.Matricula ) > 0)
                    {
                        txtMatricula.Text = _util.PreencherMatricula(_associado.Matricula);
                        txtNome.Text = _associado.Nome;
                        txtFolha.Text = _util.PreencherFolha(_associado.Folha);
                        Associado = _associado;
                        _ambiente.Associado = _associado;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                Consulta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Consulta()
        {
            try
            {
                frmConsultaAssociado _form = new frmConsultaAssociado();
                _form.ShowDialog();

                Associado = new AssociadoFAC().SelecionarPorMatricula(_form.Matricula.ToString());

                txtMatricula.Text = _form.Matricula.ToString("000000");
                txtNome.Text = _form.Nome;
                txtFolha.Text = Associado.Folha;



            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ucAssociado_Load(object sender, EventArgs e)
        {
            try
            {
                Associado = null;
                if(_ambiente.Associado != null) Associado = new AssociadoFAC().SelecionarPorMatricula(_ambiente.Associado.Matricula);
                CarregarDados(Associado);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}