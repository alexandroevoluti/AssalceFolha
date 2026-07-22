using AssalceFolha.BusinessLayer;
using AssalceFolha.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace AssalceFolha
{
    public partial class frmConfigurarCobrancaPlano : Form
    {
        public frmConfigurarCobrancaPlano()
        {
            InitializeComponent();
            CarregarCombo();
            CarregarDados();
        }


        private void CarregarCombo()
        {
            var lista = Enum.GetValues(typeof(enumTipoCobranca)).Cast<enumTipoCobranca>()
                            .Select(e => new
                            {
                                Valor = (int)e,
                                Descricao = e.GetType()
                                             .GetField(e.ToString())
                                             .GetCustomAttribute<DescriptionAttribute>()?
                                             .Description ?? e.ToString()
                            })
                            .ToList();

            cboTipoCobranca.DataSource = lista;
            cboTipoCobranca.DisplayMember = "Descricao";
            cboTipoCobranca.ValueMember = "Valor";
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

            List<ConfigCobrancaPlano> _lista = new ConfigCobrancaPlanoFAC().Listar();

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
                    string _tipoCobranca = new Enumerator<enumTipoCobranca>().IntToString(item.TipoCobrancaID);
                    dgDados.Rows.Add(item.ID, _associado.Matricula, _associado.Folha, _associado.Nome,  _tipoCobranca);
                }
            };

            dgDados.Sort(dgDados.Columns["colNome"], System.ComponentModel.ListSortDirection.Ascending);

            lbQtde.Text = _cont.ToString() + " registros";
            lbQtde.Visible = true;

            txtCodigo.Text = "";
            txtMatricula.Text = "";
            txtNome.Text = "";

            CarregarCombo(); ;


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
                    Associado _associado = new AssociadoFAC().SelecionarPorMatricula(txtMatricula.Text);
                    if (_associado == null) throw new Exception("Matrícula não encontrada !");

                    ConfigCobrancaPlano _contribuicao = new ConfigCobrancaPlano();
                    _contribuicao.ID = _util.ConvertInt(txtCodigo.Text);
                    _contribuicao.Matricula = _util.ConvertInt(txtMatricula.Text);
                    _contribuicao.Folha = _associado.Folha.ToString();
                    _contribuicao.TipoCobrancaID = _util.ConvertInt(cboTipoCobranca.SelectedValue);

                    new ConfigCobrancaPlanoFAC().SalvarAlone(_contribuicao);

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
                ConfigCobrancaPlano _contribuicao = new ConfigCobrancaPlanoFAC().Selecionar(_util.ConvertInt(txtCodigo.Text));
                if (_contribuicao == null) throw new Exception("Contribuição não encontrada  !");

                DialogResult resultado = MessageBox.Show(
                            "Confirma a exclusão do registro ?",
                            "Confirmação",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    new ConfigCobrancaPlanoFAC().Excluir(_contribuicao);
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
                var registro = new ConfigCobrancaPlanoFAC().Selecionar(_id);


                txtCodigo.Text = "";
                txtMatricula.Text = "";
                CarregarCombo();

                if (registro != null)
                {
                    Associado _associado = new AssociadoFAC().SelecionarPorMatricula(registro.Matricula.ToString());

                    txtCodigo.Text = registro.ID.ToString();
                    txtMatricula.Text = registro.Matricula.ToString();
                    if (_associado!= null)
                    {
                        txtFolha.Text = _associado.Folha;
                        txtNome.Text = _associado.Nome;

                    }

                    cboTipoCobranca.SelectedValue = registro.TipoCobrancaID;
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

        private void txtFiltro_TextChanged(object sender, EventArgs e)
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

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
