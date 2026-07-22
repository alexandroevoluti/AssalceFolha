using AssalceFolha.BusinessLayer.DTO;
using AssalceFolha.Entity;
using AssalceFolha.Entity.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssalceFolha
{
    public partial class frmAcompanhamentoMensal : Form
    {
        public frmAcompanhamentoMensal()
        {
            InitializeComponent();
        }

        private void frmAcompanhamentoMensal_Load(object sender, EventArgs e)
        {
            Consulta();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
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
                this.Cursor = Cursors.WaitCursor;

                if (dtpCompetencia.Text.Trim().Equals("")) throw new Exception("Informe a competência para a consulta !");

                int _competencia = _util.ConvertCompetenciaParaInteiro(dtpCompetencia.Text);

                dgDados.AutoGenerateColumns = false;

                List<AcompanhamentoMensalDTO> _lista = new AcompanhamentoMensalDTOFAC().Listar(_competencia);
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

        private void dtpCompetencia_ValueChanged(object sender, EventArgs e)
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
    }
}
