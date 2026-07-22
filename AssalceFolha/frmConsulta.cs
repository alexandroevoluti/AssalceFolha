using AssalceFolha.BusinessLayer;
using AssalceFolha.Entity;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AssalceFolha
{
    public partial class frmConsulta : Form
    {
        public frmConsulta()
        {
            InitializeComponent();
        }

        private void frmConsulta_Load(object sender, EventArgs e)
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

        private void CarregarCombos()
        {
            try
            {
                var _lista = new Enumerator<enumConsulta>().GetAll().ToList();

                cboConsulta.DataSource = _lista;
                cboConsulta.DisplayMember = "Value";
                cboConsulta.ValueMember = "key";
                cboConsulta.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cboConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExibiParametros();
        }

        private void ExibiParametros()
        {
            try
            {
                pnlCompetencia.Visible = false;
                pnlAno.Visible = false;

                enumConsulta _consulta = new Enumerator<enumConsulta>().IntToEnum(_util.ConvertInt(cboConsulta.SelectedValue));

                switch (_consulta)
                {
                    case enumConsulta.SNPlanoSaude:
                        pnlCompetencia.Visible = true;
                        break;
                    case enumConsulta.SNCompetencia:
                        pnlCompetencia.Visible = true;
                        break;
                    case enumConsulta.SNTerceirizados:
                        pnlCompetencia.Visible = true;
                        break;
                    case enumConsulta.TerceirizadosComFarmacia:
                        pnlCompetencia.Visible = true;
                        break;
                    case enumConsulta.ResumoComandasAno:
                        pnlAno.Visible = true;
                        mskAno.Text = DateTime.Now.Year.ToString();
                        break;
                    case enumConsulta.SNComFarmacia:
                        pnlCompetencia.Visible = true;
                        break;
                    case enumConsulta.ResumoConsignacoes:
                        pnlCompetencia.Visible = true;
                        break;
                    default:
                        break;
                }

                lbQtde.Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataSet CarregarConsulta()
        {
            try
            {

                enumConsulta _consulta = new Enumerator<enumConsulta>().IntToEnum(_util.ConvertInt(cboConsulta.SelectedValue));

                DataSet _ds = new DataSet();
                int _competencia = dtpCompetencia.Value.Year * 100 + dtpCompetencia.Value.Month;
                int _ano = _util.ConvertInt(mskAno);
                if (_ano.Equals(0))
                {
                    mskAno.Text = DateTime.Now.Year.ToString();
                    _ano = DateTime.Now.Year;
                }

                _ds = new ConsultaFAC().GerarDados(_consulta, _competencia, _ano);
                

                return _ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet _ds = CarregarConsulta();


                dgDados.DataSource = _ds.Tables[0];
                dgDados.AutoResizeColumns();

                lbQtde.Text = _ds.Tables[0].Rows.Count.ToString() + " registros";
                lbQtde.Visible = true;

                MessageBox.Show("Consulta concluída !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                ExportaExcel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExportaExcel()
        {
            try
            {

                //DataSet _ds = CarregarConsulta();

                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;


                app.Visible = true;

                //worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;

                worksheet.Name = "Exported from gridview";

                for (int i = 1; i < dgDados.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dgDados.Columns[i - 1].HeaderText;
                }


                for (int i = 0; i < dgDados.Rows.Count; i++)
                {
                    for (int j = 0; j < dgDados.Columns.Count; j++)
                    {
                        if (_util.ValidaDouble(dgDados.Rows[i].Cells[j].Value.ToString()))
                        {
                            worksheet.Cells[i + 2, j + 1] = _util.ConvertDoubleNullable(dgDados.Rows[i].Cells[j].Value.ToString());
                        }
                        else if (_util.ValidaData(dgDados.Rows[i].Cells[j].Value.ToString()))
                        {
                            worksheet.Cells[i + 2, j + 1] = _util.ConvertDateTimeNullable(dgDados.Rows[i].Cells[j].Value.ToString());
                        }
                        else
                        {
                            worksheet.Cells[i + 2, j + 1] = dgDados.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }

                Microsoft.Office.Interop.Excel.Range usedrange = worksheet.UsedRange;

                usedrange.Columns.AutoFit();
                usedrange.Rows.AutoFit();



                //     app.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
