using AssalceFolha.BusinessLayer;
using AssalceFolha.DataLayer;
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
    public partial class frmtmpCargaDados : Form
    {
        public frmtmpCargaDados()
        {
            InitializeComponent();
        }

        private void btnCarga_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                int _idRow;

                Cursor.Current = Cursors.WaitCursor;

                List<Dados> _lista = new List<Dados>();
                _lista = CarregarDados();

                foreach (var _linha in _lista)
                {

                    dgArquivo.Rows.Add();
                    _idRow = dgArquivo.Rows.Count - 1;

                    dgArquivo.Rows[_idRow].Cells[0].Value = _linha.Matricula;
                    dgArquivo.Rows[_idRow].Cells[1].Value = _linha.Folha;
                    dgArquivo.Rows[_idRow].Cells[2].Value = _linha.Nome;
                    dgArquivo.Rows[_idRow].Cells[3].Value = _linha.Tipo;
                    dgArquivo.Rows[_idRow].Cells[4].Value = _linha.Valor.ToString("#,##0.00");
                }

                string _sql = "";

                string _matricula = "";
                string _folha = "";
                double _valor = 0;

                foreach (var _linha in _lista)
                {
                    if (_matricula.Equals(""))
                    {
                        _matricula = _linha.Matricula;
                        _folha = _linha.Folha;
                    }
                    if (_matricula != _linha.Matricula)
                    {
                        GravaRegistro(_matricula, _folha, _valor);

                        _matricula = _linha.Matricula;
                        _folha = _linha.Folha;
                        _valor = 0;
                    }

                    _valor += Math.Round(_linha.Valor, 2);
                }

                if (!_matricula.Equals(""))
                {
                    GravaRegistro(_matricula, _folha, _valor);
                }

                MessageBox.Show("Carga concluída !" + Environment.NewLine + Environment.NewLine + _lista.Count().ToString("#,##0") + " registros lidos, valor total: " + _lista.Sum(x => x.Valor).ToString("#,##0.00"));

                //DialogResult result = MessageBox.Show("Gravar dados no banco ?", "Inclusão Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                //if (result.Equals(DialogResult.Yes))
                //{
                //    new CompraFAC().IncluirAlone(_listaCompra);

                //    MessageBox.Show("Carga concluída !" + Environment.NewLine + Environment.NewLine + _lista.Count().ToString("#,##0") + " registros lidos, valor total: " + _lista.Sum(x => Double.Parse(x.Valor)).ToString("#,##0.00"));
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void GravaRegistro(string _matricula, string _folha, double _valor)
        {
            try
            {
                string _cod = "139";
                string _evento = "641";
                //string _nmEvento = "DEBITO HAP VIDA";
                string _nmEvento = "DÉBITO UNIMED";
                string _dtInicio = "2021-01-01";
                string _dtFim = "2021-06-30";
                string _Usuario = "CARGA_UNIMED_5043";
                //string _Usuario= "Carga_HapVida";
                //double _valorcompetencia = _valor * 2;
                double _valorcompetencia = _valor;

                _matricula = _util.PreencherString(_matricula, "0", _util.enumDirecao.Esquerda, 6);
                _folha = _util.PreencherString(_folha, "0", _util.enumDirecao.Esquerda, 2);

                string _sql = " INSERT INTO SCAEMP(EMPMAT, FOLHA, EMPCNV, EVENTO, EMPDSC, EMP_DAT_I, EMP_DAT_F, EMP_V_PARC, ST, DTCAD, USUARIO) ";
                _sql += " SELECT '" + _matricula + "', '" + _folha + "', "+ _cod + ", " + _evento + ", '" + _nmEvento + "', '" + _dtInicio + "', '" + _dtFim + "', " + _valorcompetencia.ToString("###0.00").Replace(",", ".") + ", 'I', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "', '" + _Usuario + "' ";

                new _ImportDadosDAO().ExecutarSELECT_Escalar(_sql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Dados> CarregarDados()
        {
            try
            {
                List<Dados> _lista = new List<Dados>();
                Dados _dados = new Dados();
                Microsoft.Office.Interop.Excel.Workbook MyBook = null;
                Microsoft.Office.Interop.Excel.Application MyApp = null;
                Microsoft.Office.Interop.Excel.Worksheet MySheet = null;

                MyApp = new Microsoft.Office.Interop.Excel.Application();
                MyApp.Visible = false;
                MyBook = MyApp.Workbooks.Open(txtArquivo.Text);
                MySheet = (Microsoft.Office.Interop.Excel.Worksheet)MyBook.Sheets[1]; // Explicit cast is not required here
                int lastRow = MySheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell).Row;

                for (int index = 2; index <= lastRow; index++)
                {
                    Application.DoEvents();

                    System.Array MyValues = (System.Array)MySheet.get_Range("A" + index.ToString(), "G" + index.ToString()).Cells.Value;

                    if (MyValues.GetValue(1, 1) != null && MyValues.GetValue(1, 7) != null)
                    {
                        if (_util.ValidaInt(MyValues.GetValue(1, 1).ToString()) && _util.ValidaDouble(MyValues.GetValue(1, 7).ToString()))
                        {
                            _dados = new Dados();

                            _dados.Matricula = MyValues.GetValue(1, 1).ToString();
                            _dados.Nome = MyValues.GetValue(1, 2).ToString();
                            _dados.Tipo = MyValues.GetValue(1, 3).ToString();
                            _dados.Valor = Math.Round(_util.ConvertDouble(MyValues.GetValue(1, 7).ToString()), 2);

                            Associado _associado = new AssociadoFAC().SelecionarPorMatricula(_dados.Matricula.ToString());
                            if (_associado == null) throw new Exception("Associado não encontrado para a matrícula " + _dados.Matricula);

                            _dados.Folha = _associado.Folha;

                            _lista.Add(_dados);
                        }
                    }
                }

                return _lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private struct Dados
        {
            public string Matricula;
            public string Folha;
            public string Nome;
            public string Tipo;
            public double Valor;
        }

        private void frmtmpCargaDados_Load(object sender, EventArgs e)
        {
            txtArquivo.Text = @"D:\Projetos\Assalce_Docs\EMPRESA 1898 ASSALCE_20210111.R1xlsx.xlsx"; ;
        }
    }
}
