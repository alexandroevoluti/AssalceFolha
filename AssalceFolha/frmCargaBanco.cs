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
    public partial class frmCargaBanco : _baseForm
    {
        public frmCargaBanco()
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
        }

        private void CarregarCombos()
        {
            try
            {
                List<Convenio> _lista = new ConvenioFAC().ListarCargaBanco();
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


        private List<Banco> CarregarArquivoMult7Excel(string _file)
        {
            string _strLog = "";

            try
            {
                List<Banco> _lista = new List<Banco>();

                Microsoft.Office.Interop.Excel.Workbook MyBook = null;
                Microsoft.Office.Interop.Excel.Application MyApp = null;
                Microsoft.Office.Interop.Excel.Worksheet MySheet = null;

                MyApp = new Microsoft.Office.Interop.Excel.Application();
                MyApp.Visible = false;
                MyBook = MyApp.Workbooks.Open(_file);
                MySheet = (Microsoft.Office.Interop.Excel.Worksheet)MyBook.Sheets[1]; // Explicit cast is not required here
                int lastRow = MySheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell).Row;

                int _convenioID = 806; //MULT7
                int _eventoID = 807; //MULT7

                string _convenioNome = "MULTI7";
                string _status = "I";
                string _usuario = _util.UsuarioLogado();


                for (int index = 2; index <= lastRow; index++)
                {
                    Application.DoEvents();

                    System.Array MyValues = (System.Array)MySheet.get_Range("A" + index.ToString(), "C" + index.ToString()).Cells.Value;

                    if (MyValues.GetValue(1, 1) != null && MyValues.GetValue(1, 2) != null)
                    {
                        string _cpf = MyValues.GetValue(1, 1).ToString();
                        Associado _associado = new AssociadoFAC().SelecionarPorCPF(_cpf);
                        if (_associado == null) throw new Exception("Cooperado não encontrado para o CPF: " + _cpf);

                        string _matricula = _associado.Matricula;
                        string _folha = _associado.Folha;
                        int _nrParcelas = _util.ConvertInt(MyValues.GetValue(1, 1).ToString());
                        double _valorParcelas = _util.ConvertDouble(MyValues.GetValue(1, 1).ToString());
                        double _valorEmprestimo = _util.ConvertDouble(MyValues.GetValue(1, 1).ToString());

                        DateTime _dataInicio = _util.ConvertDateTime(MyValues.GetValue(1, 2).ToString());
                        DateTime _dataFim = _util.ConvertDateTime(MyValues.GetValue(1, 2).ToString());

                        try
                        {
                            _lista.Add(Montar(_matricula, _folha, _convenioID, _eventoID, _convenioNome, _nrParcelas, _valorEmprestimo, _dataInicio, _dataFim, _valorParcelas, _status, DateTime.Now, _usuario));
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


        private Banco Montar(string _matricula, string _folha, int _convenioID, int _eventoID, string _convenioNome, int _nrParcelas, double _valorEmprestimo, DateTime _dataInicio, DateTime _dataFim, double _valorParcelas, string _status, DateTime _data, string _usuario)
        {
            try
            {
                if (_util.ConvertInt(_matricula) == 0) throw new Exception("Informe a matrícula !");

                Convenio _convenio = new ConvenioFAC().Selecionar(cboConvenio.SelectedValue.ToString());
                if (_convenio == null) throw new Exception("Informe o convênio !");

                return (new Banco()
                {
                    Matricula = _util.PreencherMatricula(_matricula),
                    Folha = _util.PreencherFolha(_folha),
                    ID_Convenio = _convenioID.ToString(),
                    Evento = _eventoID.ToString(),
                    Nome = _convenioNome,
                    Parcelas = _nrParcelas,
                    Valor = _valorEmprestimo,
                    DataInicio = _dataInicio,
                    DataTermino = _dataFim,
                    ValorParcela = _valorParcelas,
                    Status = _status,
                    DataCadastro = _data.ToString("yyyy-MM-dd HH:mm"),
                    Usuario = _usuario
                });
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
                List<Banco> _lista = new List<Banco>();

                if (_util.ConvertInt(cboConvenio.SelectedValue).Equals(0)) throw new Exception("Informe o convênio !");

                Convenio _convenio = new ConvenioFAC().Selecionar(cboConvenio.SelectedValue.ToString());
                if (_convenio == null) throw new Exception("Informe o convênio !");


                switch (cboConvenio.SelectedValue.ToString())
                {
                    case "806": //MULT7

                        if (rbExcel.Checked)
                            _lista = CarregarArquivoMult7Excel(lstFiles.SelectedItem.ToString());
                        //else
                        //    _lista = CarregarArquivoMult7(lstFiles.SelectedItem.ToString());

                        break;
                    default:
                        break;
                }

                List<Banco> _listaBanco = _lista;
                dgCompra.DataSource = _listaBanco;
                dgCompra.AutoResizeColumns();

                string _mensagem = _lista.Count().ToString("#,##0") + " registros lidos, valor total: " + _lista.Sum(x => x.ValorParcela).ToString("#,##0.00");

                Clipboard.SetText(_mensagem);

                MessageBox.Show(_mensagem);

                DialogResult result = MessageBox.Show("Gravar dados no banco ?", "Inclusão Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.Yes))
                {
                    new BancoFAC().IncluirAlone(_listaBanco);

                    MessageBox.Show("Carga concluída !" + Environment.NewLine + Environment.NewLine + _lista.Count().ToString("#,##0") + " registros lidos, valor total: " + _lista.Sum(x => x.ValorParcela).ToString("#,##0.00"));
                }
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
        
    }
}
