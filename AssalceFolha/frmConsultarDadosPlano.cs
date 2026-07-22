using AssalceFolha.BusinessLayer;
using AssalceFolha.Entity;
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
    public partial class frmConsultarDadosPlano : Form
    {
        public frmConsultarDadosPlano()
        {
            InitializeComponent();
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CarregarDados();

                MessageBox.Show("Consulta concluída !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { this.Cursor = Cursors.Default; }
        }


        private void CarregarDados()
        {
            try
            {
                DataSet _ds = new DataSet();

                string _data = _util.PrimeiroDiaMes().ToString("yyyy-MM-dd");

                string _sql = "SELECT * ";
                _sql += " FROM VW_DADOS_PLANO";
                _sql += " WHERE IFNULL(EMP_DAT_I, '" + _data + "') <= '" + _data + "' ";
                _sql += " AND IFNULL(EMP_DAT_F, '" + _data + "') >= '" + _data + "' ";

                _ds = new ConsultaFAC().GerarDados(_sql);

                dgDados.DataSource = _ds.Tables[0];
                dgDados.AutoResizeColumns();

                lbQtde.Text = _ds.Tables[0].Rows.Count.ToString() + " registros";
                lbQtde.Visible = true;                
            }
            catch (Exception ex)
            {
                throw ex;
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


                app.Visible = false;

                int _lidos = 0;

                Progresso.Maximum = dgDados.Rows.Count;
                Progresso.Value = _lidos;
                Progresso.Visible = true;


                //worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;

                worksheet.Name = "Exported from gridview";

                for (int i = 1; i < dgDados.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dgDados.Columns[i - 1].HeaderText;
                }


                for (int i = 0; i < dgDados.Rows.Count; i++)
                {
                    Progresso.Value++;

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

                app.Visible = true;

                //     app.Quit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { Progresso.Visible = false; }
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ExportaExcel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { this.Cursor = Cursors.Default; }
        }

        private void btnSair_Click_1(object sender, EventArgs e)
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

        private void frmConsultarDadosPlano_Load(object sender, EventArgs e)
        {
            try
            {
                CarregarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
