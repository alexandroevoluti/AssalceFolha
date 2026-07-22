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

namespace AssalceFolha.Componentes
{
    public partial class ucConvenio : UserControl
    {
        private Convenio _convenio = new Convenio();

        public TipoConvenio TipoConvenio { get; set; }

        public Convenio Convenio
        {
            get { return _convenio; }
            set { _convenio = value;
                  txtConvenio.Text = value.ID;
                  txtEvento.Text = value.Evento;
                  txtNome.Text = value.Nome; }
        }

        public ucConvenio()
        {
            InitializeComponent();

            Convenio = new Convenio();
        }

        private void ucConvenio_KeyDown(object sender, KeyEventArgs e)
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

        private void txtConvenio_Leave(object sender, EventArgs e)
        {
            try
            {
                int _id = _util.ConvertInt(txtConvenio.Text);

                LimparTela();

                if (_id.Equals(0)) return;

                _convenio = new ConvenioFAC().Selecionar(_id.ToString(), TipoConvenio);
                if (_convenio == null)
                {
                    MessageBox.Show("Convênio não encontrado para o tipo de convêncio " + TipoConvenio.Descricao + " !");
                    return;
                }
                txtConvenio.Text = _convenio.ID;
                txtNome.Text = _convenio.Nome;
                txtEvento.Text = _convenio.Evento;
            }
            catch (Exception)
            {

                throw;
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

                MessageBox.Show(ex.Message); ;
            }
        }

        private void Consulta()
        {
            try
            {
                LimparTela();

                frmConsultaConvenio _form = new frmConsultaConvenio(TipoConvenio);
                _form.ShowDialog();

                txtConvenio.Text = "";
                txtNome.Text = "";
                txtEvento.Text = "";

                if (_form.Convenio != null)
                {
                    txtConvenio.Text = _util.PreencherConvenio(_form.Convenio.ID);
                    txtNome.Text = _form.Convenio.Nome;
                    txtEvento.Text = _form.Convenio.Evento;
                }
                _convenio = _form.Convenio;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Limpar()
        {
            try
            {
                LimparTela();
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
                _convenio = null;
                txtConvenio.Text = "";
                txtEvento.Text = "";
                txtNome.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtConvenio_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
