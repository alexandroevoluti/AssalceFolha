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
    public partial class frmCargaCobrancaHapVida : _baseForm
    {
        public frmCargaCobrancaHapVida()
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
            CarregarCombos();

            mskCompetencia.Text = DateTime.Now.ToString("MM/yyyy");
        }

        private void CarregarCombos()
        {
            try
            {


                var _lista = new Enumerator<enumPlanoHapVida>().GetAll().ToList();

                cboPlano.DataSource = _lista;
                cboPlano.DisplayMember = "Value";
                cboPlano.ValueMember = "key";
                cboPlano.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void CarregarFiles(string _folder)
        {
            lstFiles.Items.Clear();

            DirectoryInfo dinfo = new DirectoryInfo(_folder);


            FileInfo[] Files = dinfo.GetFiles("*.txt");
            Files = dinfo.GetFiles("*.csv");

            foreach (FileInfo file in Files)
            {
                lstFiles.Items.Add(file.FullName);
            }

        }

        private List<CobrancaHapVida> CarregarArquivoExcel(string _file)
        {
            string _strLog = "";

            try
            {
                List<CobrancaHapVida> _lista = new List<CobrancaHapVida>();

                Microsoft.Office.Interop.Excel.Workbook MyBook = null;
                Microsoft.Office.Interop.Excel.Application MyApp = null;
                Microsoft.Office.Interop.Excel.Worksheet MySheet = null;

                MyApp = new Microsoft.Office.Interop.Excel.Application();
                MyApp.Visible = false;
                MyBook = MyApp.Workbooks.Open(_file);
                MySheet = (Microsoft.Office.Interop.Excel.Worksheet)MyBook.Sheets[1]; // Explicit cast is not required here
                int lastRow = MySheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell).Row;

                for (int index = 9; index <= lastRow; index++)
                {
                    Application.DoEvents();

                    System.Array MyValues = (System.Array)MySheet.get_Range("A" + index.ToString(), "S" + index.ToString()).Cells.Value;

                    if (MyValues.GetValue(1, 1) != null && MyValues.GetValue(1, 2) != null && MyValues.GetValue(1, 4) != null && MyValues.GetValue(1, 5) != null)
                    {

                        CobrancaHapVida _cobranca = new CobrancaHapVida()
                        {
                            ID = 0,
                            PlanoID = _util.ConvertInt(cboPlano.SelectedValue),
                            Competencia = _util.ConvertCompetenciaParaInteiro(mskCompetencia.Text),
                            Credencial = MyValues.GetValue(1, 4).ToString(),
                            MatriculaHapVida = _util.ConvertInt(MyValues.GetValue(1, 5).ToString()),

                            CPF = MyValues.GetValue(1, 6).ToString(),

                            Beneficiario = MyValues.GetValue(1, 7).ToString(),

                            Mae = MyValues.GetValue(1, 8).ToString(),
                            DataNascimento = _util.ConvertDateTime(MyValues.GetValue(1, 9).ToString()),
                            DataInicio = _util.ConvertDateTime(MyValues.GetValue(1, 10).ToString()),
                            Idade = _util.ConvertInt(MyValues.GetValue(1, 11).ToString()),
                            Parentesco = MyValues.GetValue(1, 12).ToString(),

                            Plano = MyValues.GetValue(1, 13).ToString(),
                            AC = _util.ConvertInt(MyValues.GetValue(1, 14).ToString()),

                            Mensalidade = _util.ConvertDouble(MyValues.GetValue(1, 15).ToString()),
                            Adicional = _util.ConvertDouble(MyValues.GetValue(1, 16).ToString()),
                            TaxaAdesao = _util.ConvertDouble(MyValues.GetValue(1, 17).ToString()),
                            Desconto = _util.ConvertDouble(MyValues.GetValue(1, 18).ToString()),
                            Cobrado = _util.ConvertDouble(MyValues.GetValue(1, 19).ToString())
                        };

                        _lista.Add(_cobranca);
                    }
                }

                if (!_strLog.Equals("")) throw new Exception(_strLog);

                return _lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<CobrancaHapVida> CarregarArquivoCSV(string _file, int _competencia)
        {
            string _strLog = "";

            try
            {

                int _planoID = _util.ConvertInt(cboPlano.SelectedValue);

                List<CobrancaHapVida> _lista = new List<CobrancaHapVida>();
                string[] lines = System.IO.File.ReadAllLines(_file);

                foreach (string line in lines)
                {
                    Application.DoEvents();

                    if (!line.Trim().Equals(""))
                    {
                        string[] _valorLinha = line.Split(';');

                        if (_valorLinha.Length.Equals(19) && _valorLinha[0].Trim().Equals(cboPlano.Text))
                        {
                            CobrancaHapVida _cobranca = new CobrancaHapVida();
                            _cobranca.ID = 0;
                            _cobranca.PlanoID = _planoID;
                            _cobranca.Competencia = _competencia;
                            _cobranca.Credencial = _valorLinha[3];
                            _cobranca.MatriculaHapVida = 0; // _util.ConvertInt(_valorLinha[4]);
                            _cobranca.CPF = _valorLinha[5];
                            _cobranca.Beneficiario = _valorLinha[6];
                            _cobranca.Mae = _valorLinha[7];
                            _cobranca.DataNascimento = _util.ConvertDateTime(_valorLinha[8]);
                            _cobranca.DataInicio = _util.ConvertDateTime(_valorLinha[9]);
                            _cobranca.Idade = _util.ConvertInt(_valorLinha[10]);
                            _cobranca.Parentesco = _valorLinha[11];
                            _cobranca.Plano = _valorLinha[12];
                            _cobranca.AC = _util.ConvertInt(_valorLinha[13]);
                            _cobranca.Mensalidade = _util.ConvertDouble(_valorLinha[14])/100;
                            _cobranca.Adicional = _util.ConvertDouble(_valorLinha[15]) / 100;
                            _cobranca.TaxaAdesao = _util.ConvertDouble(_valorLinha[16]) / 100;
                            _cobranca.Desconto = _util.ConvertDouble(_valorLinha[17]) / 100;
                            _cobranca.Cobrado = _util.ConvertDouble(_valorLinha[18]) / 100;

                            _lista.Add(_cobranca);
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

        private void btnSelecionarPasta_Click_1(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = ConfigurationManager.AppSettings["FolderArquivosFolha"];
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = folderBrowserDialog1.SelectedPath;
                CarregarFiles(txtFile.Text);
            }
        }

        private void btnCarga_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                int _competencia = _util.ConvertCompetenciaParaInteiro(mskCompetencia.Text);
                List<CobrancaHapVida> _lista = new List<CobrancaHapVida>();

                if (_util.ConvertInt(cboPlano.SelectedValue).Equals(0)) throw new Exception("Informe o plano !");

                enumPlanoHapVida _plano = new Enumerator<enumPlanoHapVida>().IntToEnum(_util.ConvertInt(cboPlano.SelectedValue));
                if (_plano == 0) throw new Exception("Informe o plano !");
                _lista = CarregarArquivoCSV(lstFiles.SelectedItem.ToString(), _competencia);

                dgCompra.DataSource = _lista;
                dgCompra.AutoResizeColumns();

                string _mensagem = _lista.Count().ToString("#,##0") + " registros lidos";

                Clipboard.SetText(_mensagem);

                MessageBox.Show(_mensagem);

                DialogResult result = MessageBox.Show("Gravar dados no banco ?", "Inclusão Conbrança", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.Yes))
                {
                    new CobrancaHapVidaFAC().IncluirAlone(_lista);

                    MessageBox.Show("Carga concluída !" + Environment.NewLine + Environment.NewLine + _lista.Count().ToString("#,##0") + " registros lidos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
