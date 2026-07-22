using AssalceFolha.BusinessLayer;
using AssalceFolha.Entity;
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
    public partial class frmAlterarCPFHapVida : Form
    {
        public frmAlterarCPFHapVida()
        {
            InitializeComponent();
        }

        private void brnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                string _nome = txtNome.Text.Trim();
                string _ano = _util.SomenteNumeros(txtAno.Text);
                string _cpf = _util.SomenteNumeros( txtCPF.Text);

                if (_nome.Equals("") || _nome.Length < 3) throw new Exception("Informe o nome");
                if (!_util.ValidaData(_ano + "-01-01")) throw new Exception("Informe o ano");

                List<CobrancaHapVida> _lista = new CobrancaHapVidaFAC().Listar(_nome, _ano);

                if (_lista == null) throw new Exception("Nenhum registro encontrado para o ano informado !");

                var _listaDistinct = _lista.GroupBy(d => new { d.CPF, d.Beneficiario })
                                        .Select(m => new { m.Key.CPF, m.Key.Beneficiario }).ToList();

                dataGridView1.DataSource = _listaDistinct;
                dataGridView1.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void brnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count != 1) throw new Exception("Selecione o associado !");

                string _cpfAtual = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string _nome = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

                string _novoCPF = _util.SomenteNumeros( txtCPF.Text);

                if (!_util.ValidaCPF(_novoCPF)) throw new Exception("CPF inválido !");

                new CobrancaHapVidaFAC().AtualizarCPF(_cpfAtual, _nome, _novoCPF);

                MessageBox.Show("CPF atualizado !");

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmAlterarCPFHapVida_Load(object sender, EventArgs e)
        {
            try
            {
                txtAno.Text = (DateTime.Now.Year - 1).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
