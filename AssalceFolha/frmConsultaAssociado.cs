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
    public partial class frmConsultaAssociado : Form
    {

        public int Matricula { get; set; }
        public string Nome{ get; set; }

        public frmConsultaAssociado()
        {
            InitializeComponent();
        }

        private void Consulta()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (txtFiltro.Text.Trim().Equals("")) throw new Exception("Informe um filtro para a consulta !");
                dgDados.AutoGenerateColumns = false;

                List<Associado> _lista = new AssociadoFAC().Listar(txtFiltro.Text);
                dgDados.DataSource = _lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
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
            Matricula =  _util.ConvertInt( dgDados.SelectedRows[0].Cells[0].Value.ToString());
            Nome = dgDados.SelectedRows[0].Cells[1].Value.ToString();

            _ambiente.Associado = new AssociadoFAC().SelecionarPorMatricula(Matricula.ToString());

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
