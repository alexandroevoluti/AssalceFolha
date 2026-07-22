using AssalceFolha.BusinessLayer;
using AssalceFolha.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssalceFolha
{
    public partial class frmCargaMargem : Form
    {
        public frmCargaMargem()
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

        private void frmCargaMargem_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime _data = DateTime.Now;
                if (_data.Day > 25) _data = _data.AddMonths(1);

                dtpCompetencia.Value = _data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSelecionarPasta_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = ConfigurationManager.AppSettings["FolderArquivosFolha"];
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = folderBrowserDialog1.SelectedPath;
                CarregarFiles(txtFile.Text);
            }
        }

        private void CarregarFiles(string _folder)
        {
            lstFiles.Items.Clear();

            DirectoryInfo dinfo = new DirectoryInfo(_folder);

            FileInfo[] Files = dinfo.GetFiles("*.xlsx");

            foreach (FileInfo file in Files)
            {
                lstFiles.Items.Add(file.FullName);
            }

            Files = dinfo.GetFiles("*.xls");

            foreach (FileInfo file in Files)
            {
                lstFiles.Items.Add(file.FullName);
            }
        }

        private void btnCarga_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                int _competencia = _util.ConvertCompetenciaParaInteiro(dtpCompetencia.Value.ToString("MM/yyyy"));
                List<CargaMargem> _lista = new List<CargaMargem>();

                _lista = CarregarArquivoExcel(lstFiles.SelectedItem.ToString());

                dgCompra.DataSource = _lista;
                dgCompra.AutoResizeColumns();

                string _mensagem = _lista.Count().ToString("#,##0") + " registros lidos, valor total: " + _lista.Sum(x => x.Margem).ToString("#,##0.00");

                Clipboard.SetText(_mensagem);

                MessageBox.Show(_mensagem);

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

        private List<CargaMargem> CarregarArquivoExcel(string _file)
        {
            string _strLog = "";

            try
            {
                List<CargaMargem> _lista = new List<CargaMargem>();
                CargaMargem _carga = new CargaMargem();
                CargaMargemFAC _cargaMargemFAC = new CargaMargemFAC();
                AssociadoFAC _associadoFAC = new AssociadoFAC();
                Associado _associado = new Associado();

                if (!_util.ValidaCompetencia(dtpCompetencia.Value.ToString("MM/yyyy"))) throw new Exception("Informe a competência");

                int _competencia = _util.ConvertCompetenciaParaInteiro(dtpCompetencia.Value.ToString("MM/yyyy"));
                int _ano = _util.PrimeiroDiaMes(_competencia).Year;
                int _mes = _util.PrimeiroDiaMes(_competencia).Month;

                if (_cargaMargemFAC.ExisteCarga(_ano, _mes)) throw new Exception("Já existe carga de margem realizada para a competência !");


                Microsoft.Office.Interop.Excel.Workbook MyBook = null;
                Microsoft.Office.Interop.Excel.Application MyApp = null;
                Microsoft.Office.Interop.Excel.Worksheet MySheet = null;

                MyApp = new Microsoft.Office.Interop.Excel.Application();
                MyApp.Visible = false;
                MyBook = MyApp.Workbooks.Open(_file);
                MySheet = (Microsoft.Office.Interop.Excel.Worksheet)MyBook.Sheets[1]; // Explicit cast is not required here
                int lastRow = MySheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell).Row;

                int _lidos = 0;

                Progresso.Maximum = lastRow;
                Progresso.Value = _lidos;
                Progresso.Visible = true;


                for (int index = 2; index <= lastRow; index++)
                {
                    _lidos++;

                    if ((_lidos % 25).Equals(0))
                    {
                        Progresso.Value = _lidos;
                        Application.DoEvents();
                    }

                    System.Array MyValues = (System.Array)MySheet.get_Range("A" + index.ToString(), "F" + index.ToString()).Cells.Value;

                    if (MyValues.GetValue(1, 1) != null)
                    {

                        //string _codigoFolha = "0";
                        //string _matricula = MyValues.GetValue(1, 1).ToString();
                        //string _folha = MyValues.GetValue(1, 2).ToString();
                        //string _nome = MyValues.GetValue(1, 3).ToString();
                        //string _margem = MyValues.GetValue(1, 4).ToString();

                        string _codigoFolha = MyValues.GetValue(1, 1).ToString();
                        string _matricula = MyValues.GetValue(1, 2).ToString();
                        string _folha = MyValues.GetValue(1, 3).ToString();
                        string _nome = MyValues.GetValue(1, 4).ToString();
                        string _margem = MyValues.GetValue(1, 5).ToString();

                        _associado = _associadoFAC.SelecionarPorMatricula(_matricula);

                        if (_associado != null)
                        {
                            try
                            {
                                _carga = new CargaMargem()
                                {
                                    Ano = _ano,
                                    Mes = _mes,
                                    CodigoFP = _util.ConvertInt(_codigoFolha),
                                    Matricula = _util.ConvertInt(_matricula),
                                    Folha = _util.ConvertInt(_folha),
                                    Nome = _nome,
                                    Margem = _util.ConvertDouble(_margem),

                                };


                                if (!_carga.Matricula.Equals(0) && !_carga.Folha.Equals(0))
                                {
                                    _lista.Add(_carga);
                                    _cargaMargemFAC.Salvar(_carga);
                                    _cargaMargemFAC.AtualizarMargem(_carga, _associado);
                                }
                            }
                            catch (Exception ex)
                            {
                                _strLog += ex.Message + Environment.NewLine;
                            }
                        }
                    }
                }

                if (!_strLog.Equals("")) throw new Exception(_strLog);

                _cargaMargemFAC.AtualizarForaDeFolha(_ano, _mes);

                return _lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { Progresso.Visible = false; }
        }
    }
}
