using AssalceFolha.BusinessLayer;
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
    public partial class frmAtualizaFolhaEmMassa : Form
    {
        public frmAtualizaFolhaEmMassa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<AtualizacaoFolhaDTO> _lista = new List<AtualizacaoFolhaDTO>();

            _lista = CarregarArquivoExcel(txtArquivo.Text);


        }

        private List<AtualizacaoFolhaDTO> CarregarArquivoExcel(string _file)
        {
            string _strLog = "";

            try
            {
                List<AtualizacaoFolhaDTO> _lista = new List<AtualizacaoFolhaDTO>();
                AtualizacaoFolhaDTO _carga = new AtualizacaoFolhaDTO();

                AssociadoFAC _associadoFAC = new AssociadoFAC();
                Associado _associado = new Associado();
                
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

                    System.Array MyValues = (System.Array)MySheet.get_Range("A" + index.ToString(), "D" + index.ToString()).Cells.Value;

                    if (MyValues.GetValue(1, 1) != null)
                    {
                        string _nome = MyValues.GetValue(1, 1).ToString();
                        int _matricula = _util.ConvertInt(MyValues.GetValue(1, 2).ToString());
                        int _folha = _util.ConvertInt(MyValues.GetValue(1, 3).ToString());                        
                        string _lotacao = MyValues.GetValue(1, 4).ToString();

                        _associado = _associadoFAC.SelecionarPorMatricula(_matricula.ToString());

                        if (_associado != null)
                        {
                            try
                            {
                                _carga = new AtualizacaoFolhaDTO()
                                {                                    
                                    Matricula = _util.ConvertInt(_matricula),
                                    Folha = _util.ConvertInt(_folha),
                                    Nome = _nome,
                                    Lotacao = _lotacao,

                                };


                                if (!_carga.Matricula.Equals(0) && !_carga.Folha.Equals(0))
                                {
                                    _lista.Add(_carga);

                                    AtualizarDados(_carga, _associado);
                                }
                            }
                            catch (Exception ex)
                            {
                                _strLog += ex.Message + Environment.NewLine;
                            }
                        }
                    }
                }


                MyApp.Workbooks.Close();

                if (!_strLog.Equals("")) throw new Exception(_strLog);

             

                return _lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { Progresso.Visible = false; }
        }


        private void AtualizarDados(AtualizacaoFolhaDTO _carga, Associado _associado)
        {
            try
            {
                AssociadoFAC _associadoFAC = new AssociadoFAC();

                if (_associado.Situacao == "FORA DE FOLHA")
                {
                    

                    _associado.Situacao = _associado.SituacaoAnterior ?? "ASSOCIADO";
                    if (_associado.Situacao == "FORA DE FOLHA") _associado.Situacao = "ASSOCIADO";
                    _associadoFAC.AtualizarSituacao(_associado);
                }

                if (!_util.ConvertInt( _associado.Folha).Equals(_carga.Folha))
                {
                    _associado.Folha = _carga.Folha.ToString("000");
                    _associadoFAC.AtualizarFolha(_associado);
                }

                _associado.Lotacao = _carga.Lotacao.Trim();
                _associadoFAC.AtualizarLotacao(_associado);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
