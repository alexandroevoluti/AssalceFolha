using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AssalceFolha.BusinessLayer;
using AssalceFolha.Entity;

namespace AssalceFolha
{
    public partial class frmTmpCargaArquivoEnvio : Form
    {
        public frmTmpCargaArquivoEnvio()
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

            // Dia 1 fixo: o formato "MM/yyyy" oculta o dia, e meses curtos gerariam data inexistente.
            dtpCompetencia.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime _data = dtpCompetencia.Value;
                int _ano = _data.Year;
                int _mes = _data.Month;

                EnvioFolhaFAC _envioFolhaFAC = new EnvioFolhaFAC();

                if (_envioFolhaFAC.ExisteEnvio(_ano, _mes)) throw new Exception("Envio já gravado para a competência !");

                List<EnvioFolha> _lista = new List<EnvioFolha>();

                this.Cursor = Cursors.WaitCursor;

                string[] lines = System.IO.File.ReadAllLines(txtArquivo.Text);

                foreach (string line in lines)
                {
                    Application.DoEvents();

                    string[] _valorLinha = line.Split(';');

                    int _matricula = _util.ConvertInt(line.Substring(0, 7).Trim());
                    int _folha = _util.ConvertInt(line.Substring(7, 3).Trim());
                    int _idEvento = _util.ConvertInt(line.Substring(10, 4).Trim());
                    double _valor = _util.ConvertDouble(line.Substring(14, 10).Trim());
                    string _referencia = line.Substring(24, 14).Trim();

                    _lista.Add(new EnvioFolha()
                    {
                        Ano = _ano,
                        Mes = _mes,
                        Matricula = _matricula,
                        Folha = _folha,
                        Evento = _idEvento,
                        Referencia = _referencia,
                        Valor = _valor
                    });
                }

                _envioFolhaFAC.Salvar(_lista);

                MessageBox.Show("Carga concluída !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { this.Cursor = Cursors.Default;}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime _data = dtpCompetencia.Value;
                int _ano = _data.Year;
                int _mes = _data.Month;

                RetornoFolhaFAC _retornoFolhaFAC = new RetornoFolhaFAC();

                if (_retornoFolhaFAC.ExisteRegistros(_ano, _mes)) throw new Exception("Retorno já gravado para a competência !");

                List<RetornoFolha> _lista = new List<RetornoFolha>();

                this.Cursor = Cursors.WaitCursor;

                string[] lines = System.IO.File.ReadAllLines(txtArquivoRetorno.Text);

                foreach (string line in lines)
                {
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
                        Ano = _ano,
                        Mes = _mes,
                        Matricula = _matricula,
                        Folha = _folha,
                        ID_Evento = _idEvento,
                        Valor = _valor,
                        Nome = _nome,
                        CPF = _cpf
                    });
                }

                _retornoFolhaFAC.Salvar(_lista);

                MessageBox.Show("Carga concluída !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { this.Cursor = Cursors.Default; }
        }
    }
}

