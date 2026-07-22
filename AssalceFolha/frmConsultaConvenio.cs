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
    public partial class frmConsultaConvenio : Form
    {

        public Convenio Convenio { get; set; }

        public TipoConvenio TipoConvenio { get; set; }
        public frmConsultaConvenio(TipoConvenio _tipoConvenio)
        {
            InitializeComponent();

            TipoConvenio = _tipoConvenio;
        }

        private void Consulta()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (txtFiltro.Text.Trim().Equals("")) throw new Exception("Informe um filtro para a consulta !");
                dgDados.AutoGenerateColumns = false;

                List<Convenio> _lista = new ConvenioFAC().Listar(txtFiltro.Text, TipoConvenio);
                dgDados.DataSource = _lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Cursor = Cursors.Default;
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

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Consulta();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void dgDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Convenio = new ConvenioFAC().Selecionar(dgDados.SelectedRows[0].Cells[0].Value.ToString());

            this.Close();
        }

        private void frmConsultaAssociado_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
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
