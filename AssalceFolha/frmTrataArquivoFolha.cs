using AssalceFolha.BusinessLayer;
using AssalceFolha.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssalceFolha
{

    public partial class frmTrataArquivoFolha : Form
    {
        private struct Dados
        {
            public string Matricula;
            public string Folha;
            public string Evento;
            public double Valor;
            public string Referencia;
            public string Critica;
            public string Linha;
        }

        public frmTrataArquivoFolha()
        {
            InitializeComponent();
        }

        private void btnCarga_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            int _idRow;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                List<Dados> _lista = new List<Dados>();
                _lista = CarregarDados();

                dgArquivo.Rows.Clear();

                foreach (var _linha in _lista)
                {

                    dgArquivo.Rows.Add();
                    _idRow = dgArquivo.Rows.Count - 1;

                    dgArquivo.Rows[_idRow].Cells[0].Value = _linha.Matricula;
                    dgArquivo.Rows[_idRow].Cells[1].Value = _linha.Folha;
                    dgArquivo.Rows[_idRow].Cells[2].Value = _linha.Evento;
                    dgArquivo.Rows[_idRow].Cells[3].Value = _linha.Valor.ToString("#,##0.00");
                    dgArquivo.Rows[_idRow].Cells[4].Value = _linha.Referencia;
                    dgArquivo.Rows[_idRow].Cells[5].Value = _linha.Critica;
                }

                MessageBox.Show("Carga concluída !");


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

        private List<Dados> CarregarDados()
        {

            string _file = txtArquivo.Text;

            string _strLog = "";

            try
            {
                List<Dados> _lista = new List<Dados>();
                string[] lines = System.IO.File.ReadAllLines(_file);

                int _competencia = _util.ConvertCompetenciaParaInteiro(mskCompetencia.Text);

                foreach (string line in lines)
                {
                    Application.DoEvents();

                    if (!line.Trim().Equals(""))
                    {
                        string _matricula = line.Substring(0, 7).Trim().PadLeft(6, '0');
                        string _folha = line.Substring(8, 2).Trim().PadLeft(2, '0');
                        string _evento = line.Substring(10, 4).Trim();
                        string _valor = line.Substring(15, 10);
                        string _refer = line.Substring(25);

                        CriticaFolha _critica = new CriticaFolhaFAC().SelecionarCritica(_competencia, _matricula);
                        string _criticaMatricula = "";
                        if (_critica != null) _criticaMatricula = _critica.Critica;

                        try
                        {
                            _lista.Add(new Dados()
                            {
                                Matricula = _matricula,
                                Folha = _folha,
                                Evento = _evento,
                                Valor = _util.ConvertDouble(_valor),
                                Referencia = _refer,
                                Critica = _criticaMatricula,
                                Linha = line
                            });
                        }
                        catch (Exception ex)
                        {
                            _strLog += ex.Message + Environment.NewLine;
                        }
                    }
                }

                var _listaValida = _lista.Where(x => !x.Critica.Trim().ToUpper().Equals("FORA DE FOLHA")).ToList();

                string _pasta = @"D:\temp\Assalce";

                string _arquivo = _pasta + @"\ASS" + _competencia.ToString() + ".txt";

                int _cont = 0;
                while (File.Exists(_arquivo))
                {
                    _cont++;
                    _arquivo = _pasta + @"\ASS" + _competencia.ToString() + "_" + _cont.ToString("00") + ".txt";
                }

                StringBuilder sConteudo = new StringBuilder();

                foreach (Dados item in _lista)
                {
                    sConteudo.AppendLine(item.Linha);
                }

                System.IO.File.WriteAllText(_arquivo, sConteudo.ToString());

                MessageBox.Show( _arquivo);


                if (!_strLog.Equals("")) throw new Exception(_strLog);

                return _lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public string GerarArquivo(List<Dados> _lista, int _competencia)
        //{
        //    try
        //    {
        //        string _pasta = "D:\temp\Assalce";

        //        string _arquivo = _pasta + @"\ASS" + _competencia.ToString() + ".txt";

        //        int _cont = 0;
        //        while (File.Exists(_arquivo))
        //        {
        //            _cont++;
        //            _arquivo = _pasta + @"\ASS" + _competencia.ToString() + "_" + _cont.ToString("00") + ".txt";
        //        }

        //        StringBuilder sConteudo = new StringBuilder();

        //        foreach (Dados  item in _lista)
        //        {
        //            sConteudo.AppendLine(item.Linha);
        //        }

        //        System.IO.File.WriteAllText(_arquivo, sConteudo.ToString());

        //        return _arquivo;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


    }
}
