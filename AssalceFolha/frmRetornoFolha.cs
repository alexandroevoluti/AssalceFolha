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
    public partial class frmRetornoFolha : _baseForm
    {
        public frmRetornoFolha()
        {
            InitializeComponent();

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

                _pasta += @"\" + _ano;

                switch (_util.ConvertInt(mskCompetencia.Text.Substring(0, 2)))
                {
                    case 1:
                        _pasta += @"\Janeiro" + _ano;
                        break;
                    case 2:
                        _pasta += @"\Fevereiro" + _ano;
                        break;
                    case 3:
                        _pasta += @"\Marco" + _ano;
                        break;
                    case 4:
                        _pasta += @"\Abril" + _ano;
                        break;
                    case 5:
                        _pasta += @"\Maio" + _ano;
                        break;
                    case 6:
                        _pasta += @"\Junho" + _ano;
                        break;
                    case 7:
                        _pasta += @"\Julho" + _ano;
                        break;
                    case 8:
                        _pasta += @"\Agosto" + _ano;
                        break;
                    case 9:
                        _pasta += @"\Setembro" + _ano;
                        break;
                    case 10:
                        _pasta += @"\Outubro" + _ano;
                        break;
                    case 11:
                        _pasta += @"\Novembro" + _ano;
                        break;
                    case 12:
                        _pasta += @"\Dezembro" + _ano;
                        break;
                    default:
                        break;
                }

                _pasta += @"\retorno";

                txtFile.Text = _pasta;
                CarregarFiles(_pasta);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CarregarFiles(string _folder)
        {
            lstFiles.Items.Clear();

            DirectoryInfo dinfo = new DirectoryInfo(_folder);


            FileInfo[] Files = dinfo.GetFiles("*.csv");

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

                int _competencia = _util.ConvertCompetenciaParaInteiro(mskCompetencia.Text);

                List<CriticaFolha> _listaCritica = new List<CriticaFolha>();
                List<RetornoFolha> _listaRetorno = new List<RetornoFolha>();
                int _count = 0;
                double _valor = 0;


                int _ano = _util.ConvertInt(mskCompetencia.Text.Substring(3, 4));
                int _mes = _util.ConvertInt(mskCompetencia.Text.Substring(0, 2));

                //if (rbCriticaFolha.Checked)
                //{
                //    _listaCritica = CarregarCriticaFolha(lstFiles.SelectedItem.ToString(), _mes, _ano);
                //    _count = _listaCritica.Count();
                //    _valor = _listaCritica.Sum(x => x.Valor);

                //    dgArquivo.DataSource = _listaCritica;
                //}
                //else if (rbRetornoFolha.Checked)
                //{
                    _listaRetorno = CarregarRetornoFolhaConsigFacil(lstFiles.SelectedItem.ToString(), _mes, _ano);
                    _count = _listaRetorno.Count();
                    _valor = _listaRetorno.Sum(x => x.Valor);

                    dgArquivo.DataSource = _listaRetorno;
                //}
                //else
                //{
                //    throw new Exception("Informe o tipo de arquivo !");
                //}

                //dgArquivo.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
                dgArquivo.AutoResizeColumns();

                Application.DoEvents();

                DialogResult result = MessageBox.Show("Gravar dados no banco ?", "Inclusão dados ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.Yes))
                {
                    progressBar.Visible = true;
                    progressBar.Value = 0;

                    //if (rbCriticaFolha.Checked)
                    //{
                    //    CriticaFolhaFAC _criticaFolhaFAC = new CriticaFolhaFAC();
                    //    AssociadoFAC _associadoFAC = new AssociadoFAC();

                    //    if (_criticaFolhaFAC.ExisteRegistros(_ano, _mes)) throw new Exception("Registros já importados para a competência informada !");

                    //    progressBar.Maximum = _listaCritica.Count();

                    //    foreach (var item in _listaCritica)
                    //    {
                    //        progressBar.Value++;
                    //        Application.DoEvents();

                    //        if (item.Critica.Trim().ToUpper().Equals("FORA DE FOLHA"))
                    //        {
                    //            Associado _associado = _associadoFAC.SelecionarPorMatricula(item.Matricula.ToString());
                    //            if (_associado!= null)
                    //            {
                    //                if (!_associado.Situacao.Trim().ToUpper().Equals("FORA DE FOLHA") && !_associado.Situacao.Trim().ToUpper().Equals("TERCEIRIZADO"))
                    //                {
                    //                    _associado.SituacaoAnterior = _associado.Situacao;
                    //                    _associado.Situacao = item.Critica;

                    //                    _associadoFAC.AtualizarSituacao(_associado, _associado.SituacaoAnterior);
                    //                }
                    //            }
                    //        }
                    //        else if(item.Critica.Trim().ToUpper().Equals("MUDOU PARA 04"))
                    //        {
                    //            Associado _associado = _associadoFAC.SelecionarPorMatricula(item.Matricula.ToString());
                    //            if (!_associado.Folha.Equals("04"))
                    //            {
                    //                _associado.Folha = "04";
                    //                _associadoFAC.AtualizarFolha(_associado);
                    //            }
                    //        }

                    //        _criticaFolhaFAC.SalvarAlone(item);
                    //    }
                    //}
                    //else
                    //{
                        RetornoFolhaFAC _retornoFolhaFAC = new RetornoFolhaFAC();

                        if (_retornoFolhaFAC.ExisteRegistros(_ano, _mes)) throw new Exception("Registros já importados para a competência informada !");

                        progressBar.Maximum = _listaRetorno.Count();

                        foreach (var item in _listaRetorno)
                        {
                            progressBar.Value++;
                            Application.DoEvents();

                            _retornoFolhaFAC.SalvarAlone(item);

                        }

                        result = MessageBox.Show("Gravar SNs ?", "Inclusão Dados ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result.Equals(DialogResult.Yes))
                        {
                            _retornoFolhaFAC.GravarSN(_ano, _mes, _ambiente.UsuarioLogado.Login);
                        }
                    }
                //}

                progressBar.Visible = false;

                MessageBox.Show(_count.ToString("#,##0") + " registros lidos, valor total: " + _valor.ToString("#,##0.00"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                progressBar.Visible = false;
            }
        }

        private List<RetornoFolha> CarregarRetornoFolha(string _file, int _mes, int _ano)
        {
            try
            {
                List<RetornoFolha> _lista = new List<RetornoFolha>();
                string[] lines = System.IO.File.ReadAllLines(_file);

                progressBar.Visible = true;
                progressBar.Maximum = lines.Count();
                progressBar.Value = 0;
                foreach (string line in lines)
                {
                    progressBar.Value++;
                    Application.DoEvents();

                    string[] _valorLinha = line.Split(';');

                    int _matricula = _util.ConvertInt(_valorLinha[0]);
                    int _folha = _util.ConvertInt(_valorLinha[1]);
                    int _idEvento = _util.ConvertInt(_valorLinha[2]);
                    double _valor = _util.ConvertDouble(_valorLinha[3]);
                    string _nome = _valorLinha[4];
                    string _cpf = _valorLinha[5];

                    _lista.Add(new RetornoFolha()
                    {
                        Matricula = _matricula,
                        Folha = _folha,
                        Ano = _ano,
                        Mes = _mes,
                        ID_Evento = _idEvento,
                        CPF = _cpf,
                        Nome = _nome,
                        Valor = _valor
                    });
                }

                return _lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { progressBar.Visible = false; }
        }

        private List<RetornoFolha> CarregarRetornoFolhaConsigFacil(string _file, int _mes, int _ano)
        {
            try
            {
                string _log = "";

                List<RetornoFolha> _lista = new List<RetornoFolha>();
                string[] lines = System.IO.File.ReadAllLines(_file);

                progressBar.Visible = true;
                progressBar.Maximum = lines.Count();
                progressBar.Value = 0;
                foreach (string line in lines)
                {
                    progressBar.Value++;
                    Application.DoEvents();

                    string[] _valorLinha = line.Split(';');

                    int _matricula = _util.ConvertInt(_valorLinha[0]);
                    string _cpf = _util.SomenteNumeros(_valorLinha[1]);
                    int _idEvento = _util.ConvertInt(_util.SomenteNumeros(_valorLinha[2]));
                    double _valor = _util.ConvertDouble(_valorLinha[3]);
                    
                    if (_matricula > 0)
                    {
                        Associado _associado = new AssociadoFAC().SelecionarPorMatricula(_matricula.ToString());
                        if (_associado == null)
                        {
                            _log += "Associado não encontrado ! Matrícula: " + _matricula.ToString() + " CPF: " + _util.FormatarCpf(_cpf) + Environment.NewLine;
                        }
                        else
                        {
                            _lista.Add(new RetornoFolha()
                            {
                                Matricula = _matricula,
                                Folha = _util.ConvertInt(_associado.Folha),
                                Ano = _ano,
                                Mes = _mes,
                                ID_Evento = _idEvento,
                                CPF = _cpf,
                                Nome = _associado.Nome,
                                Valor = _valor
                            });
                        }
                    }
                }

                if (_log != "") throw new Exception(_log);


                _lista = _lista
                        .GroupBy(r => new { r.Matricula, r.Folha, r.Nome, r.Ano, r.Mes, r.CPF, r.ID_Evento })
                        .Select(g => new RetornoFolha
                                {
                                Matricula = g.Key.Matricula,
                                Folha = g.Key.Folha,
                                Ano = g.Key.Ano,
                                Mes = g.Key.Mes,
                                ID_Evento = g.Key.ID_Evento,
                                CPF = g.Key.CPF,
                                Nome = g.Key.Nome,
                                Valor = g.Sum(x => x.Valor)
                            })
                        .ToList();


                return _lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { progressBar.Visible = false; }
        }

        private List<CriticaFolha> CarregarCriticaFolha(string _file, int _mes, int _ano)
        {
            try
            {
                List<CriticaFolha> _lista = new List<CriticaFolha>();
                string[] lines = System.IO.File.ReadAllLines(_file);

                progressBar.Visible = true;
                progressBar.Maximum = lines.Count();
                progressBar.Value = 0;
                foreach (string line in lines)
                {
                    progressBar.Value++;
                    Application.DoEvents();

                    string[] _valorLinha = line.Split(';');

                    int _matricula = _util.ConvertInt(line.Substring(0, 7).Trim());
                    int _folha = _util.ConvertInt(line.Substring(7, 3).Trim());
                    int _idEvento = _util.ConvertInt(line.Substring(10, 4).Trim());
                    double _valor = _util.ConvertDouble(line.Substring(14, 10).Trim());
                    string _referencia = line.Substring(24, 15).Trim();
                    string _critica = line.Substring(39).Trim();

                    _lista.Add(new CriticaFolha()
                    {
                        Ano = _ano,
                        Mes = _mes,
                        Matricula = _matricula,
                        Folha = _folha,
                        ID_Evento = _idEvento,
                        Referencia = _referencia,
                        Critica = _critica,
                        Valor = _valor
                    });

                }

                return _lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { progressBar.Visible = false; }
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

        private void btnConferencia_Click(object sender, EventArgs e)
        {
            try
            {

                //if (rbCriticaFolha.Checked)
                //{
                //    frmRelatorioCompetenciaPlano childForm = new frmRelatorioCompetenciaPlano(enumRelatorio.CriticaFolha);
                //    childForm.ShowDialog();
                //}
                //else
                //{
                    frmRelatorioCompetencia childForm = new frmRelatorioCompetencia(enumRelatorio.RetornoFolha);
                    childForm.ShowDialog();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmRetornoFolha_Load(object sender, EventArgs e)
        {

            //MessageBox.Show(Usuario.Login);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGravarSN_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int _ano = _util.ConvertInt(mskCompetencia.Text.Substring(3, 4));
                int _mes = _util.ConvertInt(mskCompetencia.Text.Substring(0, 2));

                DialogResult result = MessageBox.Show("Gravar SNs ?", "Inclusão Dados ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.Yes))
                {
                    new RetornoFolhaFAC().GravarSN(_ano, _mes, _ambiente.UsuarioLogado.Login);
                }

                MessageBox.Show("SNs geradas !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { this.Cursor = Cursors.Default; }
        }
    }
}
