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
using AssalceFolha.BusinessLayer;
using AssalceFolha.Entity;

namespace AssalceFolha
{
    public partial class frmCargaArquivosFolha : _baseForm
    {
        public frmCargaArquivosFolha()
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
            CarregarResumo();

            mskCompetencia.Text = DateTime.Now.ToString("MM/yyyy");

            PreencherPasta();
            //CarregarAssociados();
        }

        private void PreencherPasta()
        {
            try
            {
                String _pasta = ConfigurationManager.AppSettings["FolderArquivosFolha"];
                String _ano = mskCompetencia.Text;
                _ano = _ano.Substring(3, 4);
                int _mes = _util.ConvertInt(mskCompetencia.Text.Substring(0, 2));

                _pasta += @"\" + _ano;

                string _competencia = @"\" + _ano.ToString() + _mes.ToString("00") + "_";

                switch (_mes)
                {
                    case 1:
                        _pasta += _competencia + "Janeiro";
                        break;
                    case 2:
                        _pasta += _competencia + "Fevereiro";
                        break;
                    case 3:
                        _pasta += _competencia + "Marco";
                        break;
                    case 4:
                        _pasta += _competencia + "Abril";
                        break;
                    case 5:
                        _pasta += _competencia + "Maio";
                        break;
                    case 6:
                        _pasta += _competencia + "Junho";
                        break;
                    case 7:
                        _pasta += _competencia + "Julho";
                        break;
                    case 8:
                        _pasta += _competencia + "Agosto";
                        break;
                    case 9:
                        _pasta += _competencia + "Setembro";
                        break;
                    case 10:
                        _pasta += _competencia + "Outubro";
                        break;
                    case 11:
                        _pasta += _competencia + "Novembro";
                        break;
                    case 12:
                        _pasta += _competencia + "Dezembro";
                        break;
                    default:
                        break;
                }

                txtFile.Text = _pasta;
                CarregarFiles(_pasta);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void CarregarAssociados()
        {

            List<Associado> _lista = new AssociadoFAC().Listar("");
            CarregarResumo();
        }

        private void CarregarCombos()
        {
            try
            {
                List<Convenio> _lista = new ConvenioFAC().ListarCarga();
                _lista.Add(new Convenio() { ID = "0", Nome = "(( Selecione Convênio ))" });

                cboConvenio.DataSource = _lista;
                cboConvenio.DisplayMember = "Nome";
                cboConvenio.ValueMember = "ID";

                cboConvenio.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                throw ex;
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


            FileInfo[] Files = dinfo.GetFiles("*.txt");
            if (rbExcel.Checked) Files = dinfo.GetFiles("*.xlsx");

            foreach (FileInfo file in Files)
            {
                lstFiles.Items.Add(file.FullName);
            }

        }


        private List<RegistroFarmacia> CarregarArquivoMeninoJesus(string _file)
        {
            string _strLog = "";

            try
            {
                List<RegistroFarmacia> _lista = new List<RegistroFarmacia>();
                string[] lines = System.IO.File.ReadAllLines(_file);

                Convenio _convenio = new ConvenioFAC().Selecionar(cboConvenio.SelectedValue.ToString());

                progressBar.Maximum = lines.Count();
                progressBar.Value = 0;
                progressBar.Visible = true;


                foreach (string line in lines)
                {
                    progressBar.Value++;
                    Application.DoEvents();

                    Application.DoEvents();

                    if (!line.Trim().Equals(""))
                    {
                        string _matricula = line.Substring(0, 7).Trim().PadLeft(6, '0');
                        string _nome = null;
                        DateTime? _data = _util.ConvertDateTimeNullable(line.Substring(7, 24));
                        string _valor = line.Substring(31, 10);
                        string _referencia = (_convenio.Parcelado.Equals("N") ? "1/1" : "");


                        try
                        {
                            _lista.Add(Montar(_matricula, _data, _referencia, _nome, _valor));
                        }
                        catch (Exception ex)
                        {
                            _strLog += ex.Message + Environment.NewLine;
                        }
                    }
                }

                if (!_strLog.Equals("")) throw new Exception(_strLog);

                return _lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { progressBar.Visible = false; }
        }

        private List<RegistroFarmacia> CarregarArquivoSantaBranca(string _file)
        {
            string _strLog = "";

            try
            {
                List<RegistroFarmacia> _lista = new List<RegistroFarmacia>();
                string[] lines = System.IO.File.ReadAllLines(_file);

                foreach (string line in lines)
                {
                    Application.DoEvents();

                    if (!line.Trim().Equals(""))
                    {
                        string[] _valorLinha = line.Split(';');

                        string _matricula = _valorLinha[0];
                        string _nome = null;
                        DateTime? _data = DateTime.Now;
                        string _valor = _valorLinha[1];
                        string _referencia = "";

                        try
                        {
                            _lista.Add(Montar(_matricula, _data, _referencia, _nome, _valor));
                        }
                        catch (Exception ex)
                        {
                            _strLog += ex.Message + Environment.NewLine;
                        }
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

        private List<RegistroFarmacia> CarregarArquivoSantaBranca_V2(string _file)
        {
            string _strLog = "";

            try
            {
                List<RegistroFarmacia> _lista = new List<RegistroFarmacia>();
                string[] lines = System.IO.File.ReadAllLines(_file);

                foreach (string line in lines)
                {
                    Application.DoEvents();

                    if (!line.Trim().Equals(""))
                    {
                        int _matricula = 0;

                        int.TryParse(line.Substring(0, 10), out _matricula);

                        if (_matricula > 0)
                        {                       
                            string _nome = null;
                            DateTime? _data = DateTime.Now;
                            string _valor = line.Substring(101, 10);
                            string _referencia = "";

                            try
                            {
                                _lista.Add(Montar(_matricula.ToString(), _data, _referencia, _nome, _valor));
                            }
                            catch (Exception ex)
                            {
                                _strLog += ex.Message + Environment.NewLine;
                            }
                        }
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

        private List<RegistroFarmacia> CarregarArquivoDoseCerta(string _file)
        {
            string _strLog = "";

            try
            {
                List<RegistroFarmacia> _lista = new List<RegistroFarmacia>();
                string[] lines = System.IO.File.ReadAllLines(_file);

                progressBar.Maximum = lines.Count();
                progressBar.Value = 0;
                progressBar.Visible = true;
                foreach (string line in lines)
                {
                    progressBar.Value++;
                    Application.DoEvents();

                    if (!line.Trim().Equals(""))
                    {
                        //string[] _valorLinha = line.Split(' ');

                        if (line.Trim().Length > 21)
                        {
                            string _matricula = line.Substring(0, 10);
                            string _nome = null;
                            DateTime? _data = _util.ConvertDateTime(line.Substring(10, 10));
                            //DateTime? _data = _util.UltimoDiaMes(_util.ConvertCompetenciaParaInteiro(mskCompetencia.Text));
                            string _valor = line.Substring(21);
                            string _referencia = "";

                            try
                            {
                                if (_util.ValidaInt(_matricula) && _util.ValidaData(_data) && _util.ValidaDouble(_valor))
                                {
                                    var _item = Montar(_matricula, _data, _referencia, _nome, _valor);
                                    _lista.Add(_item);
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

                return _lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { progressBar.Visible = false; }
        }

        private List<RegistroFarmacia> CarregarArquivoDoseCertaExcel(string _file)
        {
            string _strLog = "";

            try
            {
                List<RegistroFarmacia> _lista = new List<RegistroFarmacia>();

                Microsoft.Office.Interop.Excel.Workbook MyBook = null;
                Microsoft.Office.Interop.Excel.Application MyApp = null;
                Microsoft.Office.Interop.Excel.Worksheet MySheet = null;

                MyApp = new Microsoft.Office.Interop.Excel.Application();
                MyApp.Visible = false;
                MyBook = MyApp.Workbooks.Open(_file);
                MySheet = (Microsoft.Office.Interop.Excel.Worksheet)MyBook.Sheets[1]; // Explicit cast is not required here
                int lastRow = MySheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell).Row;

                for (int index = 2; index <= lastRow; index++)
                {
                    Application.DoEvents();

                    System.Array MyValues = (System.Array)MySheet.get_Range("A" + index.ToString(), "C" + index.ToString()).Cells.Value;

                    if (MyValues.GetValue(1, 1) != null && MyValues.GetValue(1, 2) != null)
                    {
                        string _matricula = MyValues.GetValue(1, 1).ToString();
                        string _nome = "";
                        DateTime? _data = _util.ConvertDateTimeNullable(MyValues.GetValue(1, 2).ToString());
                        string _valor = MyValues.GetValue(1, 3).ToString();
                        string _referencia = "";//MyValues.GetValue(1, 5).ToString().Replace("0", "");


                        try
                        {
                            _lista.Add(Montar(_matricula, _data, _referencia, _nome, _valor));
                        }
                        catch (Exception ex)
                        {
                            _strLog += ex.Message + Environment.NewLine;
                        }
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

        private List<RegistroFarmacia> CarregarArquivoSantaBrancaExcel(string _file)
        {
            string _strLog = "";

            try
            {
                List<RegistroFarmacia> _lista = new List<RegistroFarmacia>();

                Microsoft.Office.Interop.Excel.Workbook MyBook = null;
                Microsoft.Office.Interop.Excel.Application MyApp = null;
                Microsoft.Office.Interop.Excel.Worksheet MySheet = null;

                MyApp = new Microsoft.Office.Interop.Excel.Application();
                MyApp.Visible = false;
                MyBook = MyApp.Workbooks.Open(_file);
                MySheet = (Microsoft.Office.Interop.Excel.Worksheet)MyBook.Sheets[1]; // Explicit cast is not required here
                int lastRow = MySheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell).Row;

                for (int index = 1; index <= lastRow; index++)
                {
                    Application.DoEvents();

                    System.Array MyValues = (System.Array)MySheet.get_Range("A" + index.ToString(), "B" + index.ToString()).Cells.Value;

                    if (MyValues.GetValue(1, 1) != null && MyValues.GetValue(1, 2) != null)
                    {
                        string _matricula = MyValues.GetValue(1, 1).ToString();
                        string _nome = "";
                        DateTime? _data = _util.Hoje();
                        string _valor = MyValues.GetValue(1, 2).ToString();
                        string _referencia = "";//MyValues.GetValue(1, 5).ToString().Replace("0", "");


                        try
                        {
                            _lista.Add(Montar(_matricula, _data, _referencia, _nome, _valor));
                        }
                        catch (Exception ex)
                        {
                            _strLog += ex.Message + Environment.NewLine;
                        }
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
        private List<RegistroFarmacia> CarregarArquivoPortugal(string _file)
        {
            string _strLog = "";

            try
            {
                List<RegistroFarmacia> _lista = new List<RegistroFarmacia>();
                string[] lines = System.IO.File.ReadAllLines(_file);

                foreach (string line in lines)
                {
                    Application.DoEvents();

                    if (!line.Trim().Equals(""))
                    {
                        string _matricula = line.Substring(0, 6).Trim().PadLeft(6, '0');
                        string _nome = null;
                        DateTime? _data = _util.ConvertDateTimeNullable(line.Substring(7, 11));
                        string _valor = line.Substring(28, 9).Trim().Replace(".", ",");
                        string _referencia = line.Substring(58).Trim();
                        if (_referencia.Trim().Equals("1")) _referencia = "1/1";


                        try
                        {
                            _lista.Add(Montar(_matricula, _data, _referencia, _nome, _valor));
                        }
                        catch (Exception ex)
                        {
                            _strLog += ex.Message + Environment.NewLine;
                        }
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

        private List<RegistroFarmacia> CarregarArquivoPortugalExcel(string _file)
        {
            string _strLog = "";

            try
            {
                List<RegistroFarmacia> _lista = new List<RegistroFarmacia>();

                Microsoft.Office.Interop.Excel.Workbook MyBook = null;
                Microsoft.Office.Interop.Excel.Application MyApp = null;
                Microsoft.Office.Interop.Excel.Worksheet MySheet = null;

                MyApp = new Microsoft.Office.Interop.Excel.Application();
                MyApp.Visible = false;
                MyBook = MyApp.Workbooks.Open(_file);
                MySheet = (Microsoft.Office.Interop.Excel.Worksheet)MyBook.Sheets[1]; // Explicit cast is not required here
                int lastRow = MySheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell).Row;

                for (int index = 2; index <= lastRow; index++)
                {
                    Application.DoEvents();

                    System.Array MyValues = (System.Array)MySheet.get_Range("A" + index.ToString(), "E" + index.ToString()).Cells.Value;

                    if (MyValues.GetValue(1, 1) != null && MyValues.GetValue(1, 2) != null && MyValues.GetValue(1, 4) != null && MyValues.GetValue(1, 5) != null)
                    {
                        string _matricula = MyValues.GetValue(1, 1).ToString();
                        string _nome = "";
                        DateTime? _data = _util.ConvertDateTimeNullable(MyValues.GetValue(1, 2).ToString());
                        string _valor = MyValues.GetValue(1, 4).ToString();
                        string _referencia = MyValues.GetValue(1, 5).ToString().Replace("0", "");


                        try
                        {
                            _lista.Add(Montar(_matricula, _data, _referencia, _nome, _valor));
                        }
                        catch (Exception ex)
                        {
                            _strLog += ex.Message + Environment.NewLine;
                        }
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


        private List<RegistroFarmacia> CarregarArquivoTeleJuca(string _file)
        {
            string _strLog = "";

            try
            {
                List<RegistroFarmacia> _lista = new List<RegistroFarmacia>();
                string[] lines = System.IO.File.ReadAllLines(_file);

                foreach (string line in lines)
                {
                    //Application.DoEvents();

                    if (!line.Trim().Equals(""))
                    {
                        string[] _valorLinha = line.Split(';');

                        string _matricula = line.Substring(0, 15).Trim().PadLeft(6, '0');
                        string _nome = line.Substring(15, 35);
                        DateTime? _data = null;
                        string _valor = line.Substring(50, 12);
                        string _referencia = "";

                        //string _matricula = _valorLinha[0];
                        //string _nome = "";
                        //DateTime _data = _util.ConvertDateTime(_valorLinha[2]);
                        //string _valor = _valorLinha[3];
                        //string _referencia = _valorLinha[1];

                        //Associado _associado = null;
                        //if (!_util.ConvertInt(_matricula).Equals(0)) _associado = new AssociadoFAC().SelecionarPorMatricula(_matricula);

                        try
                        {
                            _lista.Add(Montar(_matricula, _data, _referencia, _nome, _valor));
                        }
                        catch (Exception ex)
                        {
                            _strLog += ex.Message + Environment.NewLine;
                        }
                    }
                }

                if (!_strLog.Equals("")) throw new Exception(_strLog);

                return _lista;
            }
            catch (Exception ex)
            {
                Clipboard.SetText(_strLog);
                throw ex;
            }
        }

        private List<RegistroFarmacia> CarregarArquivoTeleJucaExcel(string _file)
        {
            string _strLog = "";

            try
            {
                List<RegistroFarmacia> _lista = new List<RegistroFarmacia>();

                Microsoft.Office.Interop.Excel.Workbook MyBook = null;
                Microsoft.Office.Interop.Excel.Application MyApp = null;
                Microsoft.Office.Interop.Excel.Worksheet MySheet = null;

                MyApp = new Microsoft.Office.Interop.Excel.Application();
                MyApp.Visible = false;
                MyBook = MyApp.Workbooks.Open(_file);
                MySheet = (Microsoft.Office.Interop.Excel.Worksheet)MyBook.Sheets[1]; // Explicit cast is not required here
                int lastRow = MySheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell).Row;

                for (int index = 1; index <= lastRow; index++)
                {
                    Application.DoEvents();

                    System.Array MyValues = (System.Array)MySheet.get_Range("A" + index.ToString(), "I" + index.ToString()).Cells.Value;

                    if (MyValues.GetValue(1, 1) != null)
                    {
                        string _matricula = MyValues.GetValue(1, 1).ToString();
                        //string _nome = MyValues.GetValue(1, 2).ToString();
                        string _nome = "";

                        //DateTime _refer = _util.ConvertDateTime(MyValues.GetValue(1, 6).ToString());
                        //string _referencia = _refer.Day.ToString() + "/" + _refer.Month.ToString();
                        //string _referencia = MyValues.GetValue(1, 6).ToString();

                        string _referencia = "";

                        //DateTime? _data = _util.ConvertDateTimeNullable(MyValues.GetValue(1, 7).ToString());
                        DateTime? _data = DateTime.Now;

                        //string _valor = MyValues.GetValue(1, 9).ToString();
                        string _valor = MyValues.GetValue(1, 2).ToString();


                        try
                        {
                            _lista.Add(Montar(_matricula, _data, _referencia, _nome, _valor));
                        }
                        catch (Exception ex)
                        {
                            _strLog += ex.Message + Environment.NewLine;
                        }
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

        private RegistroFarmacia Montar(string _matricula, DateTime? _data, string _referencia, string _nome, string _valor)
        {
            try
            {
                DateTime _dtInicio = _util.ConvertDateTime("20/" + mskCompetencia.Text).AddMonths(-1); ;
                DateTime _dtFim = _util.ConvertDateTime("20/" + mskCompetencia.Text);

                //if (_util.ValidaData(_data))
                //{
                //    if (_data < _dtInicio || _data > _dtFim) throw new Exception("Data invalida para a competência: " + _data.ToString());
                //}

                if (_util.ConvertInt(_matricula) == 0) throw new Exception("Informe a matrícula !");

                Associado _associado = new AssociadoFAC().SelecionarPorMatricula(_matricula);
                if (_associado == null) throw new Exception("Matrícula não encontrada: " + _matricula);

                Convenio _convenio = new ConvenioFAC().Selecionar(cboConvenio.SelectedValue.ToString());
                if (_convenio == null) throw new Exception("Informe o convênio !");

                if (_util.ConvertDouble(_valor) <= 0) throw new Exception("Informe o valor ! Matrícula: " + _matricula);

                return (new RegistroFarmacia() { Matricula = _matricula, Data = _data, Referencia = _referencia, Nome = _nome, Associado = _associado, Convenio = _convenio, Valor = _valor });

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lstFiles_DoubleClick(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnCarga_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                int _competencia = _util.ConvertCompetenciaParaInteiro(mskCompetencia.Text);
                List<RegistroFarmacia> _lista = new List<RegistroFarmacia>();

                if (_util.ConvertInt(cboConvenio.SelectedValue).Equals(0)) throw new Exception("Informe o convênio !");

                Convenio _convenio = new ConvenioFAC().Selecionar(cboConvenio.SelectedValue.ToString());
                if (_convenio == null) throw new Exception("Informe o convênio !");


                switch (cboConvenio.SelectedValue.ToString())
                {
                    case "079": //TELEJUCA

                        //MessageBox.Show("Lembrar da parcela da 001069-07 MARIA DE FATIMA AMARAL DA SILVA");

                        if (rbExcel.Checked)
                            _lista = CarregarArquivoTeleJucaExcel(lstFiles.SelectedItem.ToString());
                        else
                            _lista = CarregarArquivoTeleJuca(lstFiles.SelectedItem.ToString());

                        break;
                    case "004": //MENINO JESUS
                        if (rbText.Checked)
                            _lista = CarregarArquivoMeninoJesus(lstFiles.SelectedItem.ToString());
                        break;
                    case "001": //FARMACIA PORTUGAL
                        if (rbExcel.Checked)
                            _lista = CarregarArquivoPortugalExcel(lstFiles.SelectedItem.ToString());
                        else
                            _lista = CarregarArquivoPortugal(lstFiles.SelectedItem.ToString());
                        break;
                    case "321": //FARMACIA DOSE CERTA
                        if (rbText.Checked)
                            _lista = CarregarArquivoDoseCerta(lstFiles.SelectedItem.ToString());
                        else
                            _lista = CarregarArquivoDoseCertaExcel(lstFiles.SelectedItem.ToString());
                        break;
                    case "200": //FARMACIA SANTA BRANCA
                        if (rbExcel.Checked)
                            _lista = CarregarArquivoSantaBrancaExcel(lstFiles.SelectedItem.ToString());
                        else
                            _lista = CarregarArquivoSantaBranca_V2(lstFiles.SelectedItem.ToString());
                        break;
                        
                    default:
                        break;
                }

                List<Compra> _listaCompra = new CompraFAC().Montar(_competencia, _lista);
                dgCompra.DataSource = _listaCompra;
                dgCompra.AutoResizeColumns();

                string _mensagem = _lista.Count().ToString("#,##0") + " registros lidos, valor total: " + _lista.Sum(x => Double.Parse(x.Valor)).ToString("#,##0.00");

                Clipboard.SetText(_mensagem);

                MessageBox.Show(_mensagem);

                DialogResult result = MessageBox.Show("Gravar dados no banco ?", "Inclusão Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.Yes))
                {
                    new CompraFAC().IncluirAlone(_listaCompra);

                    MessageBox.Show("Carga concluída !" + Environment.NewLine + Environment.NewLine + _lista.Count().ToString("#,##0") + " registros lidos, valor total: " + _lista.Sum(x => Double.Parse(x.Valor)).ToString("#,##0.00"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CarregarResumo();

                Cursor.Current = Cursors.Default;
            }
        }

        private void CarregarResumo()
        {
            int _competencia = _util.ConvertCompetenciaParaInteiro(mskCompetencia.Text);
            if (_competencia.Equals(0)) _competencia = DateTime.Now.Year * 100 + DateTime.Now.Month;

            DataSet _ds = new ConvenioFAC().ListarResumoCarga(_competencia.ToString());
            dgResumo.DataSource = _ds.Tables[0];
            //dgResumo.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            dgResumo.AutoResizeColumns();
        }

        private void rbExcel_CheckedChanged(object sender, EventArgs e)
        {
            rbText.Checked = !rbExcel.Checked;
            txtFile.Text = "";
            lstFiles.Items.Clear();

            PreencherPasta();
        }

        private void rbText_CheckedChanged(object sender, EventArgs e)
        {
            rbExcel_CheckedChanged(sender, e);
        }


        private void btnConferencia_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!_util.ValidaCompetencia(mskCompetencia.Text)) throw new Exception("Informe a competência !");

                int _competencia = _util.ConvertCompetenciaParaInteiro(mskCompetencia.Text);

                frmRelatorio _form = new AssalceFolha.frmRelatorio(enumRelatorio.ConferenciaCargaArquivoFolha, _competencia);
                _form.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { Cursor.Current = Cursors.Default; }

        }

        private void btCargaResumo_Click(object sender, EventArgs e)
        {
            try
            {
                CarregarResumo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
