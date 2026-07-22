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
using AssalceFolha.BusinessLayer.AtualizacaoDados;
using AssalceFolha.Entity;
using AssalceFolha.Entity.AtualizacaoDados;

namespace AssalceFolha
{
    public partial class frmAtualizacaoDadosAssociados : Form
    {
        List<DadosAL> _listaDados = null;

        public frmAtualizacaoDadosAssociados()
        {
            InitializeComponent();

            _listaDados = new DadosALFAC().Listar();
            dgDados.DataSource = _listaDados;
            dgDados.Refresh();
            dgDados.AutoResizeColumns();

            List<SituacaoAL> _listaSituacao = new SituacaoALFAC().Listar();
            dgSituacao.DataSource = _listaSituacao;
            dgSituacao.Refresh();
            dgSituacao.AutoResizeColumns();

            lbTotal.Text = "Dados lidos: " + _listaDados.Count.ToString() + "  Situações lidas: " + _listaSituacao.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _filtro = textBox1.Text;
            List<DadosAL> _resultado = _listaDados.Where(x => x.NOME.ToUpper().Contains(_filtro.ToUpper())).OrderBy(x => x.NOME).ToList();
            dgDados.DataSource = _resultado;
            dgDados.Refresh();
            dgDados.AutoResizeColumns();
        }

        private void dgDados_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AssociadoFAC _associadoFAC = new AssociadoFAC();

            Associado _associado = ucAssociado1.Associado;
            picFoto.Image = _util.ByteToImage(_associado.Foto);

            DadosAL _dadosAL = new DadosALFAC().Seleiconar(ucAssociado1.Associado.Matricula);
            picFotoAL.Image = _util.ByteToImage(_dadosAL.FOTO);

            if (_util.ByteToImage(_dadosAL.FOTO) != null)
            {
                _associado.Foto = _dadosAL.FOTO;
                _associadoFAC.AtualizarFoto(_associado);

                picFoto.Image = _util.ByteToImage(_associado.Foto);
            }

        }

        protected void ucAssociado1_txtMatriculaLeave(object sender, EventArgs e)
        {
            Associado _associado = ucAssociado1.Associado;
            picFoto.Image = _util.ByteToImage(_associado.Foto);

            DadosAL _dadosAL = new DadosALFAC().Seleiconar(ucAssociado1.Associado.Matricula);
            if (_dadosAL.FOTO != null) picFotoAL.Image = _util.ByteToImage(_dadosAL.FOTO);
            txtFolhaAL.Text = _dadosAL.FOLHA;
        }

        private Associado ConsultaAssociado()
        {
            try
            {
                if (ucAssociado1.Associado == null) throw new Exception("Associado não encontrado para a matrícula informada !");

                picFoto.Image = _util.ByteToImage(ucAssociado1.Associado.Foto);

                DadosAL _dadosAL = new DadosALFAC().Seleiconar(ucAssociado1.Associado.Matricula);
                picFotoAL.Image = _util.ByteToImage(_dadosAL.FOTO);

                return ucAssociado1.Associado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAtualizarTodosDados_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucAssociado1.Associado == null) throw new Exception("Associado não encontrado para a matrícula informada !");

                new DadosALFAC().Atualizar(ucAssociado1.Associado.Matricula);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                Associado _associado = new Associado();
                AssociadoFAC _associadoFAC = new AssociadoFAC();

                DialogResult dialogResult = MessageBox.Show("Confirma a atualização da foto de todos os associados ?", "Atualizar foto", MessageBoxButtons.YesNo);
                if (dialogResult.Equals(DialogResult.Yes))
                {
                    List<DadosAL> _dadosAL = new DadosALFAC().Listar();

                    int _cont = 0;
                    int _total = _dadosAL.Count();

                    foreach (var _dadoAL in _dadosAL)
                    {
                        _cont++;
                        lbCont.Text = _cont.ToString("0000") + "/" + _total.ToString("0000");
                        Application.DoEvents();

                        _associado = _associadoFAC.SelecionarPorMatricula(_dadoAL.MATR);
                        if (_associado != null)
                        {
                            if (_associado.Foto == null && _dadoAL.FOTO != null)
                            {
                                _associado.Foto = _util.ImageToByte(_util.ByteToImage(_dadoAL.FOTO), 65);
                                _associadoFAC.AtualizarFoto(_associado);
                            }
                        }
                    }
                }

                MessageBox.Show("Fotos atualizadas !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
