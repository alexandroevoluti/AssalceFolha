using AssalceFolha.BusinessLayer;
using AssalceFolha.Entity;
using AssalceFolha.ScriptGenerator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace AssalceFolha
{
    public partial class frmListarAssociados : Form
    {
        public frmListarAssociados()
        {
            InitializeComponent();

            PreencherListas();
        }


        private void PreencherListas()
        {
            try
            {
                cblFolha.Items.Clear();
                cblSituacao.Items.Clear();
                cblSituacaoDRH.Items.Clear();
                cblCampos.Items.Clear();

                List<TipoFolha> _listaFolha = new TipoFolhaFAC().Listar();
                foreach (var item in _listaFolha) cblFolha.Items.Add(item.Descricao);

                List<Situacao> _listaSituacao = new SituacaoFAC().Listar();
                foreach (var item in _listaSituacao) cblSituacao.Items.Add(item.Descricao);

                List<SituacaoDRH> _listaSituacaoDRH = new SituacaoDRHFAC().Listar();
                foreach (var item in _listaSituacaoDRH) cblSituacaoDRH.Items.Add(item.Descricao);

                List<string> _campos = CamposAssociados();
                _campos = _campos.OrderBy(x => x).ToList();
                foreach (var item in _campos) cblCampos.Items.Add(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnGerarExcelListagem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string _folhas = FolhasSelecionadas();

                if (_folhas.Equals("")) throw new Exception("Informe as folhas !");

                string _situacao = SituacoesSelecionadas();
                if (_situacao.Equals("")) throw new Exception("Informe as stiruações  !");

                string _situacaoDRH = SituacoesDRHSelecionadas();
                if (_situacaoDRH.Equals("")) throw new Exception("Informe as stiruações DRH !");

                int _sexo = (rbMasculino.Checked ? 1 : (rbFeminino.Checked ? 2 : 3));
                bool _incluiExcluidos = ckExcluidos.Checked;
                List<Associado> _associados = new AssociadoFAC().Listar(_folhas, _situacao, _situacaoDRH, _sexo, _incluiExcluidos);

                if (_associados == null) throw new Exception("Nenhum associado encontrado para os parâmetros informados !");


                GerarExcelListagem(_folhas, _situacao, _situacaoDRH, _associados);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GerarExcelListagem(string _folhas, string _situacoes, string _situacoesDRH, List<Associado> _associados)
        {
            try
            {
                int _inicioAssociados = 6;

                int _lidos = 0;

                Progresso.Maximum = _associados.Count;
                Progresso.Value = _lidos;
                Progresso.Visible = true;

                Microsoft.Office.Interop.Excel.Application excel;
                Microsoft.Office.Interop.Excel.Workbook worKbooK;
                Microsoft.Office.Interop.Excel.Worksheet worKsheeT;
                Microsoft.Office.Interop.Excel.Range celLrangE;

                try
                {
                    excel = new Microsoft.Office.Interop.Excel.Application();
                    excel.Visible = false;
                    excel.DisplayAlerts = false;
                    worKbooK = excel.Workbooks.Add(Type.Missing);


                    worKsheeT = (Microsoft.Office.Interop.Excel.Worksheet)worKbooK.ActiveSheet;
                    worKsheeT.Name = "Listagem";// + _folhas;

                    worKsheeT.Range[worKsheeT.Cells[1, 1], worKsheeT.Cells[1, 3]].Merge();
                    worKsheeT.Cells[1, 1] = "Folhas " + _folhas;
                    worKsheeT.Cells.Font.Size = 15;

                    worKsheeT.Range[worKsheeT.Cells[2, 1], worKsheeT.Cells[2, 3]].Merge();
                    worKsheeT.Cells[2, 1] = "Situações: " + _situacoes;
                    worKsheeT.Cells.Font.Size = 15;

                    worKsheeT.Range[worKsheeT.Cells[3, 1], worKsheeT.Cells[3, 3]].Merge();
                    worKsheeT.Cells[3, 1] = "Situações DRH: " + _situacoesDRH;
                    worKsheeT.Cells.Font.Size = 15;

                    worKsheeT.Range[worKsheeT.Cells[4, 1], worKsheeT.Cells[4, 3]].Merge();
                    worKsheeT.Cells[4, 1] = "Total Associados: " + _associados.Count.ToString("#,##0");
                    worKsheeT.Cells.Font.Size = 15;


                    int rowcount = _inicioAssociados;
                    int colcount = 0;

                    List<string> _campos = CamposAssociados();

                    foreach (string _campo in _campos)
                    {
                        if (Selecionado(_campo))
                        {
                            colcount++;
                            worKsheeT.Cells[rowcount, colcount] = _campo;
                            worKsheeT.Cells.Font.Color = System.Drawing.Color.Black;
                        }
                    }

                    Type _typeObj = new Associado().GetType();

                    foreach (Associado _associado in _associados)
                    {
                        colcount = 0;
                        rowcount++;

                        _lidos++;
                        Progresso.Value = _lidos;
                        Application.DoEvents();

                        foreach (PropertyInfo propertyInfo in _typeObj.GetProperties())
                        {
                            foreach (object attr in propertyInfo.GetCustomAttributes(true))
                            {
                                if (attr.GetType() == typeof(TableField))
                                {
                                    if (((TableField)attr).IsTableField)
                                    {
                                        if (Selecionado(propertyInfo.Name))
                                        {
                                            colcount++;
                                            worKsheeT.Cells[rowcount, colcount] = (propertyInfo.GetValue(_associado) == null ? "" : propertyInfo.GetValue(_associado).ToString());
                                            worKsheeT.Cells.Font.Color = System.Drawing.Color.Black;
                                        }

                                    }
                                }
                            }
                        }
                    }

                    celLrangE = worKsheeT.Range[worKsheeT.Cells[1, 1], worKsheeT.Cells[rowcount, colcount]];
                    celLrangE.WrapText = true;
                    celLrangE.EntireColumn.AutoFit();
                    celLrangE.EntireRow.AutoFit();

                    celLrangE = worKsheeT.Range[worKsheeT.Cells[_inicioAssociados, 1], worKsheeT.Cells[rowcount, colcount]];
                    Microsoft.Office.Interop.Excel.Borders border = celLrangE.Borders;
                    border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    border.Weight = 2d;

                    celLrangE.RowHeight = 57.75;
                    celLrangE.HorizontalAlignment = -4108;
                    celLrangE.VerticalAlignment = -4108;
                    celLrangE.WrapText = false;
                    celLrangE.Orientation = 0;
                    celLrangE.AddIndent = false;
                    celLrangE.IndentLevel = 0;
                    celLrangE.ShrinkToFit = false;
                    celLrangE.ReadingOrder = -5002;
                    celLrangE.MergeCells = false;

                    celLrangE.EntireColumn.AutoFit();

                    excel.Visible = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                finally
                {
                    worKsheeT = null;
                    celLrangE = null;
                    worKbooK = null;

                    Progresso.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool Selecionado(string _nomeCampo)
        {
            try
            {
                var _listaCamposSelecionados = CamposSelecionadas();

                int _cont = _listaCamposSelecionados.IndexOf("'" + _nomeCampo.Trim() + "'");
                
                return _cont>=0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<string> CamposAssociados()
        {
            try
            {
                List<string> _campos = new List<string>();

                Type _typeObj = new Associado().GetType();

                foreach (PropertyInfo propertyInfo in _typeObj.GetProperties())
                {
                    foreach (object attr in propertyInfo.GetCustomAttributes(true))
                    {
                        if (attr.GetType() == typeof(TableField))
                        {
                            if (((TableField)attr).IsTableField)
                            {
                                _campos.Add(propertyInfo.Name);
                            }
                        }
                    }
                }

                return _campos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnGerarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string _folhas = FolhasSelecionadas();

                if (_folhas.Equals("")) throw new Exception("Informe as folhas !");

                string _situacao = SituacoesSelecionadas();
                if (_situacao.Equals("")) throw new Exception("Informe as stiruações  !");

                string _situacaoDRH = SituacoesDRHSelecionadas();
                if (_situacaoDRH.Equals("")) throw new Exception("Informe as stiruações DRH !");

                int _sexo = (rbMasculino.Checked ? 1 : (rbFeminino.Checked ? 2 : 3));
                bool _incluirExclidos = ckExcluidos.Checked;

                List<Associado> _associados = new AssociadoFAC().Listar(_folhas, _situacao, _situacaoDRH, _sexo, _incluirExclidos);

                if (_associados == null) throw new Exception("Nenhum associado encontrado para os parâmetros informados !");

                GerarExcel(_folhas, _situacao, _situacaoDRH, _associados);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { this.Cursor = Cursors.Default; }
        }


        private void GerarExcel(string _folhas, string _situacoes, string _situacoesDRH, List<Associado> _associados)
        {
            try
            {
                int _inicioAssociados = 6;

                int _lidos = 0;

                Progresso.Maximum = _associados.Count;
                Progresso.Value = _lidos;
                Progresso.Visible = true;

                Microsoft.Office.Interop.Excel.Application excel;
                Microsoft.Office.Interop.Excel.Workbook worKbooK;
                Microsoft.Office.Interop.Excel.Worksheet worKsheeT;
                Microsoft.Office.Interop.Excel.Range celLrangE;

                try
                {
                    excel = new Microsoft.Office.Interop.Excel.Application();
                    excel.Visible = false;
                    excel.DisplayAlerts = false;
                    worKbooK = excel.Workbooks.Add(Type.Missing);


                    worKsheeT = (Microsoft.Office.Interop.Excel.Worksheet)worKbooK.ActiveSheet;
                    worKsheeT.Name = "Folhas ";// + _folhas;

                    worKsheeT.Range[worKsheeT.Cells[1, 1], worKsheeT.Cells[1, 3]].Merge();
                    worKsheeT.Cells[1, 1] = "Folhas " + _folhas;
                    worKsheeT.Cells.Font.Size = 15;

                    worKsheeT.Range[worKsheeT.Cells[2, 1], worKsheeT.Cells[2, 3]].Merge();
                    worKsheeT.Cells[2, 1] = "Situações: " + _situacoes;
                    worKsheeT.Cells.Font.Size = 15;

                    worKsheeT.Range[worKsheeT.Cells[3, 1], worKsheeT.Cells[3, 3]].Merge();
                    worKsheeT.Cells[3, 1] = "Situações DRH: " + _situacoesDRH;
                    worKsheeT.Cells.Font.Size = 15;

                    worKsheeT.Range[worKsheeT.Cells[4, 1], worKsheeT.Cells[4, 3]].Merge();
                    worKsheeT.Cells[4, 1] = "Total Associados: " + _associados.Count.ToString("#,##0");
                    worKsheeT.Cells.Font.Size = 15;


                    int rowcount = _inicioAssociados;
                    int colcount = 0;

                    foreach (Associado _associado in _associados)
                    {
                        colcount++;
                        _lidos++;
                        Progresso.Value = _lidos;
                        Application.DoEvents();

                        if (colcount > 3)
                        {
                            rowcount += 1;
                            colcount = 1;
                        }

                        worKsheeT.Cells[rowcount, colcount] = _associado.Matricula + " - " + _associado.Nome;
                        worKsheeT.Cells.Font.Color = System.Drawing.Color.Black;

                    }

                    celLrangE = worKsheeT.Range[worKsheeT.Cells[1, 1], worKsheeT.Cells[rowcount, 3]];
                    celLrangE.WrapText = true;
                    celLrangE.EntireColumn.AutoFit();
                    celLrangE.EntireRow.AutoFit();

                    celLrangE = worKsheeT.Range[worKsheeT.Cells[_inicioAssociados, 1], worKsheeT.Cells[rowcount, 3]];
                    Microsoft.Office.Interop.Excel.Borders border = celLrangE.Borders;
                    border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    border.Weight = 2d;

                    celLrangE.RowHeight = 57.75;
                    celLrangE.HorizontalAlignment = -4108;
                    celLrangE.VerticalAlignment = -4108;
                    celLrangE.WrapText = false;
                    celLrangE.Orientation = 0;
                    celLrangE.AddIndent = false;
                    celLrangE.IndentLevel = 0;
                    celLrangE.ShrinkToFit = false;
                    celLrangE.ReadingOrder = -5002;
                    celLrangE.MergeCells = false;

                    celLrangE.EntireColumn.AutoFit();

                    //worKbooK.SaveAs("d:\temp\teste.xlsx");
                    //worKbooK.Close();
                    //excel.Quit();

                    excel.Visible = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                finally
                {
                    worKsheeT = null;
                    celLrangE = null;
                    worKbooK = null;

                    Progresso.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string FolhasSelecionadas()
        {
            try
            {
                List<int> _retorno = new List<int>();
                foreach (var item in cblFolha.CheckedItems) _retorno.Add(_util.ConvertInt(item.ToString().Replace("Folha ", "")));

                return String.Join(", ", _retorno.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string SituacoesSelecionadas()
        {
            try
            {
                List<string> _retorno = new List<string>();
                foreach (var item in cblSituacao.CheckedItems) _retorno.Add("'" + item.ToString() + "'");

                return String.Join(", ", _retorno.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string CamposSelecionadas()
        {
            try
            {
                List<string> _retorno = new List<string>();
                foreach (var item in cblCampos.CheckedItems) _retorno.Add("'" + item.ToString() + "'");

                return String.Join(", ", _retorno.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string SituacoesDRHSelecionadas()
        {
            try
            {
                List<string> _retorno = new List<string>();
                foreach (var item in cblSituacaoDRH.CheckedItems) _retorno.Add("'" + item.ToString() + "'");

                return String.Join(", ", _retorno.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ckTodasFolhas_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < cblFolha.Items.Count; i++)
                {
                    cblFolha.SetItemChecked(i, ckTodasFolhas.Checked);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ckTodasSituacoes_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < cblSituacao.Items.Count; i++)
                {
                    cblSituacao.SetItemChecked(i, ckTodasSituacoes.Checked);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ckTodasSituacoesDRH_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < cblSituacaoDRH.Items.Count; i++)
                {
                    cblSituacaoDRH.SetItemChecked(i, ckTodasSituacoesDRH.Checked);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ckTodosCampos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < cblCampos.Items.Count; i++)
                {
                    cblCampos.SetItemChecked(i, ckTodosCampos.Checked);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
