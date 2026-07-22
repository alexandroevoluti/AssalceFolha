using AssalceFolha.BusinessLayer;
using AssalceFolha.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AssalceFolha
{
    public partial class frmContribuicaoAssalce : Form
    {
        public frmContribuicaoAssalce()
        {
            InitializeComponent();
            CarregarDados();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                CarregarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CarregarDados()
        {

            List<ContribuicaoBoleto> _lista = new ContribuicaoBoletoFAC().Listar();

            int _cont = 0;
            dgDados.Rows.Clear();
            bool _adicionar = true;
            foreach (var item in _lista)
            {
                Associado _associado = new AssociadoFAC().SelecionarPorMatricula(item.Matricula.ToString());
                _adicionar = true;
                if (!txtFiltro.Text.Equals(""))
                {
                    int _matricula = _util.ConvertInt(txtFiltro.Text);
                    _adicionar = _associado.Nome.ToUpper().Contains(txtFiltro.Text.ToUpper());
                    if (_matricula != 0) _adicionar = _matricula.Equals(item.Matricula);

                }
                if (_adicionar)
                {
                    _cont++;
                    dgDados.Rows.Add(item.ID, _associado.Matricula, _associado.Nome, item.Valor.ToString("#,##0.00"));
                }
            };

            dgDados.Sort(dgDados.Columns["colNome"], System.ComponentModel.ListSortDirection.Ascending);

            lbQtde.Text = _cont.ToString() + " registros";
            lbQtde.Visible = true;

            txtCodigo.Text = "";
            txtMatricula.Text = "";
            txtValor.Text = "";


            //MessageBox.Show("Consulta concluída !");
        }

        private void btnSalvarItem_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult resultado = MessageBox.Show(
                      "Confirma a inclusão/aleração  do registro ?",
                      "Confirmação",
                      MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    ContribuicaoBoleto _contribuicao = new ContribuicaoBoleto();
                    _contribuicao.ID = _util.ConvertInt(txtCodigo.Text);
                    _contribuicao.Matricula = _util.ConvertInt(txtMatricula.Text);
                    _contribuicao.Valor = _util.ConvertDouble(txtValor.Text);

                    new ContribuicaoBoletoFAC().SalvarAlone(_contribuicao);

                    CarregarDados();
                    MessageBox.Show("Registro Salvo !");
                }

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExcluriItem_Click(object sender, EventArgs e)
        {
            try
            {
                ContribuicaoBoleto _contribuicao = new ContribuicaoBoletoFAC().Selecionar(_util.ConvertInt(txtCodigo.Text));
                if (_contribuicao == null) throw new Exception("Contribuição não encontrada  !");

                DialogResult resultado = MessageBox.Show(
                            "Confirma a exclusão do registro ?",
                            "Confirmação",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    new ContribuicaoBoletoFAC().Excluir(_contribuicao);
                    CarregarDados();
                    MessageBox.Show("Registro excluído !");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                int _id = _util.ConvertInt(dgDados.CurrentRow.Cells["ColID"].Value);
                var registro = new ContribuicaoBoletoFAC().Selecionar(_id);


                txtCodigo.Text = "";
                txtMatricula.Text = "";
                txtValor.Text = "";

                if (registro != null)
                {
                    txtCodigo.Text = registro.ID.ToString();
                    txtMatricula.Text = registro.Matricula.ToString();
                    txtValor.Text = registro.Valor.ToString("#,##0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                CarregarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
