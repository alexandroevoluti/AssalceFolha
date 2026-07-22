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
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.Threading;

namespace AssalceFolha
{
    public partial class frmPrincipal : _baseForm
    {
        public frmPrincipal()
        {
            try
            {
                //Usuario = _usuario;

                InitializeComponent();
                CarregarCombos();
                lbMesAno.Text = _util.Hoje().ToString("MM   /   yyyy");

                statusStrip1.Items[0].Text = "F2 - Consulta Associados              F3 - Consultar Matrícula Anterior              F4 - Consultar Matrícula Posterior";

                if (_util.NomeServidor().Contains("localhost")) pnlDadosPessoais.BackColor = Color.OrangeRed;
                //txtMatricula.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CarregarCombos()
        {
            cboConvenio.DataSource = new ConvenioFAC().Listar();
            cboConvenio.ValueMember = "ID";
            cboConvenio.DisplayMember = "Nome";

            cboSituacao.Items.Clear();
            var _lista = new AssociadoFAC().ListarSituacoes();
            foreach (var item in _lista) if (!item.Trim().Equals("")) cboSituacao.Items.Add(item.ToUpper());

        }
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtMatricula_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMatricula_Leave(object sender, EventArgs e)
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
            try
            {
                AssociadoFAC _associadoFAC = new AssociadoFAC();

                Associado _associado = _associadoFAC.SelecionarPorMatricula(_util.ConvertInt(txtMatricula.Text).ToString("000000"));
                if (_associado == null && txtMatricula.Text.Trim() != "") throw new Exception("Associado não encotnrado !");
              //  if (_util.ConvertInt(_associado.Matricula).Equals(0) && txtMatricula.Text.Trim() != "") throw new Exception("Associado não encotnrado !");

                LimparTela();

                if (_associado.Folha != null)
                {
                    _ambiente.Associado = _associado;

                    txtMatricula.Text = _util.PreencherMatricula(_associado.Matricula);
                    txtFolha.Text = _util.PreencherFolha(_associado.Folha);
                    txtNome.Text = _associado.Nome;
                    txtCargoFuncao.Text = _associado.CargoFuncao;
                    txtSexo.Text = _associado.Sexo;
                    if (_associado.Foto != null) picFoto.Image = _util.ByteToImage(_associado.Foto);
                    txtEndereco.Text = _associado.Endereco;
                    txtNumero.Text = _associado.Numero;
                    txtComplemento.Text = _associado.Complemento;
                    txtCEP.Text = _associado.CEP;
                    txtBairro.Text = _associado.Bairro;
                    txtMunicipio.Text = _associado.Cidade;
                    txtNatural.Text = _associado.Naturalidade;
                    txtCelular.Text = _associado.Celular;
                    txtTelefone.Text = _associado.Telefone;
                    txtCPF.Text = _util.FormatarCpf(_associado.CPF);
                    txtIdentidade.Text = _associado.RG;
                    txtExpedicao.Text = _associado.OrgaoExpedidor;
                    txtAgencia.Text = _associado.Agencia;
                    txtConta.Text = _associado.Conta;
                    txtAdmissao.Text = _util.FormatarData(_associado.DataAssociado, _util.enumFormatoData.Data);
                    txtDataNascimento.Text = _util.FormatarData(_associado.DataNascimento, _util.enumFormatoData.Data);
                    txtLotacao.Text = _associado.Lotacao;
                    txtEmail.Text = _associado.Email;
                    txtDataAdmissao.Text = _util.FormatarData(_associado.DataAdmissao, _util.enumFormatoData.Data);
                    txtTituloEleitor.Text = _associado.Titulo;
                    txtPisPasep.Text = _associado.PisPasep;
                    txtTipoSanguineo.Text = _associado.TipoSanguineo;
                    txtDataExclusao.Text = _util.FormatarData(_associado.DataExclusao, _util.enumFormatoData.Data);
                    txtNomePai.Text = _associado.Pai;
                    txtNomeMae.Text = _associado.Mae;
                    txtSenha.Text = _associado.Senha;
                    txtCartao.Text = _associado.Cartao;

                    cboAutorizacao.SelectedItem = _associado.Autoriza;
                    cboSituacao.SelectedItem = _associado.Situacao;
                    cboSituacaoDRH.SelectedItem = _associado.SituacaoDRH;

                    DateTime _hoje = _util.Hoje();

                    txtMes.Text = _hoje.Month.ToString("00");
                    txtAno.Text = _hoje.Year.ToString();

                    int _ano = _hoje.Year;

                    int _diaViradaMes = _util.ConvertInt(new ParametroFAC().Selecionar(enumTipoParametro.DiaViradaMes).Valor);
                    int _mes = _hoje.Month + (_hoje.Day >= _diaViradaMes ? 1 : 0);
                    if (_mes > 12)
                    {
                        _mes = 1;
                        _ano++;
                    }
                    txtMesConsulta.Text = _mes.ToString("00");
                    txtAnoConsulta.Text = _ano.ToString();


                    txtTotalUtilizado.Text = _associadoFAC.TotalUtilizado(_util.ConvertInt(_associado.Matricula), _util.ConvertInt(_associado.Folha), _hoje.Month, _hoje.Year).ToString("#,##0.00");
                    txtTotalComanda.Text = _associadoFAC.TotalComanda(_util.ConvertInt(_associado.Matricula), _util.ConvertInt(_associado.Folha), _hoje.Month, _hoje.Year).ToString("#,##0.00");
                    txtLimiteComandas.Text = _associado.Limite.ToString("#,##0.00");
                    txtLimiteFarmicias.Text = _associado.Farmacia.ToString("#,##0.00");

                    txtMargemDRH.Text = "";
                    if (_associado.Margem != null) txtMargemDRH.Text = _associado.Margem.ValorMargem.ToString("#,##0.00");

                    CarregarCompras();
                    CarregarFinanciamentos();
                    CarregarPlanos();
                    CarregarBancos();

                    if (tabControl1.SelectedIndex.Equals(0)) txtCodConvenio.Focus();
                    //if (tabControl1.SelectedIndex.Equals(1)) txtCodConvenioFinanciamento.Focus();
                    if (tabControl1.SelectedIndex.Equals(2)) txtCodConvenio.Focus();
                    if (tabControl1.SelectedIndex.Equals(3)) txtCodConvenio.Focus();

                    if (cboSituacao.SelectedItem != null)
                    {
                        cboSituacao.BackColor = (cboSituacao.SelectedItem.ToString().IndexOf("BLOQ").Equals(-1) ? Color.White : Color.Red);
                        cboSituacao.ForeColor = (cboSituacao.SelectedItem.ToString().IndexOf("BLOQ").Equals(-1) ? Color.Black : Color.White);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CarregarCompras()
        {
            try
            {
                dgCompras.AutoGenerateColumns = false;

                Associado _associado = new AssociadoFAC().SelecionarPorMatricula(txtMatricula.Text);

                CompraFAC _CompraFAC = new CompraFAC();

                int _mes = _util.ConvertInt(txtMesConsulta.Text);
                int _ano = _util.ConvertInt(txtAnoConsulta.Text);

                List<Compra> _compras = _CompraFAC.Listar(_associado, _ano, _mes, false);

                lbMov.Text = "0";
                if (_compras != null) lbMov.Text = _compras.Count().ToString();

                dgCompras.DataSource = _compras;
                dgCompras.Refresh();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CarregarFinanciamentos()
        {
            try
            {
                dgFinanciamentos.AutoGenerateColumns = false;

                Associado _associado = new AssociadoFAC().SelecionarPorMatricula(txtMatricula.Text);

                FinanciamentoFAC _financiamentoFAC = new FinanciamentoFAC();

                int _mes = _util.ConvertInt(txtMesConsulta.Text);
                int _ano = _util.ConvertInt(txtAnoConsulta.Text);

                List<Financiamento> _financiamentos = _financiamentoFAC.Listar(_associado);
                if (ckAtivosFinanciamentos.Checked && _financiamentos != null)
                {
                    _financiamentos = _financiamentos.Where(x => x.Status.Trim().Equals("I") && (x.DataInicio == null || x.DataInicio <= DateTime.Now) && (x.DataTermino == null || x.DataTermino >= DateTime.Now)).ToList();
                }
                lbValorHapVida.Text = "0";
                lbValorUnimed.Text = "0";

                //if (_financiamentos != null) lbMov.Text = _compras.Count().ToString();

                dgFinanciamentos.DataSource = _financiamentos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CarregarPlanos()
        {
            try
            {
                dgPlanos.AutoGenerateColumns = false;

                Associado _associado = new AssociadoFAC().SelecionarPorMatricula(txtMatricula.Text);

                PlanoFAC _planoFAC = new PlanoFAC();

                int _mes = _util.ConvertInt(txtMesConsulta.Text);
                int _ano = _util.ConvertInt(txtAnoConsulta.Text);

                List<Plano> _planos = _planoFAC.Listar(_associado);

                if (ckAtivosPlanos.Checked && _planos != null) _planos = _planos.Where(x => x.Status.Trim().Equals("I") && (x.DataInicio == null || x.DataInicio <= DateTime.Now) && (x.DataTermino == null || x.DataTermino >= DateTime.Now)).ToList();

                dgPlanos.DataSource = _planos;
                dgPlanos.Refresh();

                lbValorHapVida.Text = _planoFAC.TotalHapVida(_util.ConvertInt(_associado.Matricula), _util.ConvertInt(_associado.Folha)).ToString("#,##0.00");
                lbValorUnimed.Text = _planoFAC.TotalUnimed(_util.ConvertInt(_associado.Matricula), _util.ConvertInt(_associado.Folha)).ToString("#,##0.00");

                //for (int i = 0; i < dgPlanos.Rows.Count; i++)
                //{
                //    Convenio _convenio = new ConvenioFAC().Selecionar(dgPlanos.Rows[i].Cells[0].Value.ToString());
                //    dgPlanos.Rows[i].Cells[3].Value = _convenio.Nome;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CarregarBancos()
        {
            try
            {
                dgBancos.AutoGenerateColumns = false;

                Associado _associado = new AssociadoFAC().SelecionarPorMatricula(txtMatricula.Text);

                BancoFAC _bancoFAC = new BancoFAC();

                int _mes = _util.ConvertInt(txtMesConsulta.Text);
                int _ano = _util.ConvertInt(txtAnoConsulta.Text);

                List<Banco> _bancos = _bancoFAC.Listar(_associado);

                if (ckAtivosBancos.Checked) _bancos = _bancos.Where(x => x.Status.Trim().Equals("I") && (x.DataInicio == null || x.DataInicio <= DateTime.Now) && (x.DataTermino == null || x.DataTermino >= DateTime.Now)).ToList();

                dgBancos.DataSource = _bancos;
                dgBancos.Refresh();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LimparTela()
        {
            try
            {
                _ambiente.Associado = null;

                txtMatricula.Text = "";
                txtFolha.Text = "";
                txtNome.Text = "";
                txtSexo.Text = "";
                picFoto.Image = null;
                txtEndereco.Text = "";
                txtNumero.Text = "";
                txtComplemento.Text = "";
                txtCEP.Text = "";
                txtBairro.Text = "";
                txtMunicipio.Text = "";
                txtNatural.Text = "";
                txtCelular.Text = "";
                txtTelefone.Text = "";
                txtCPF.Text = "";
                txtIdentidade.Text = "";
                txtExpedicao.Text = "";
                txtAgencia.Text = "";
                txtConta.Text = "";
                txtAdmissao.Text = "";
                txtDataNascimento.Text = "";
                txtLotacao.Text = "";
                txtEmail.Text = "";
                txtDataAdmissao.Text = "";
                txtTituloEleitor.Text = "";
                txtPisPasep.Text = "";
                txtTipoSanguineo.Text = "";
                txtDataExclusao.Text = "";
                txtNomePai.Text = "";
                txtNomeMae.Text = "";
                txtSenha.Text = "";
                txtCartao.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void frmPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    if (this.GetNextControl(ActiveControl, true) != null)
                    {
                        e.Handled = true;
                        this.GetNextControl(ActiveControl, true).Focus();

                    }
                }
                if (e.KeyCode == Keys.F2)
                {
                    Consulta();
                }
                if (e.KeyCode == Keys.F3)
                {
                    ConsultaAnterior();
                }
                if (e.KeyCode == Keys.F4)
                {
                    ConsultaProxima();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtMatricula_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                Consulta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Consulta()
        {
            try
            {
                frmConsultaAssociado _form = new frmConsultaAssociado();
                _form.ShowDialog();

                txtMatricula.Text = _form.Matricula.ToString("000000");
                CarregarDados();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ConsultaAnterior()
        {
            try
            {
                Associado _associado = new AssociadoFAC().SelecionarMatriculaAnterior(_util.ConvertInt(txtMatricula.Text));
                txtMatricula.Text = _associado.Matricula;
                CarregarDados();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ConsultaProxima()
        {
            try
            {
                Associado _associado = new AssociadoFAC().SelecionarProximaMatricula(_util.ConvertInt(txtMatricula.Text));
                txtMatricula.Text = _associado.Matricula;
                CarregarDados();

            }
            catch (Exception)
            {

                throw;
            }
        }


        private void txtCodConvenio_Leave(object sender, EventArgs e)
        {
            int _cdConvenio = _util.ConvertInt(txtCodConvenio.Text);
            if (_cdConvenio.Equals(0)) return;

            txtCodConvenio.Text = _cdConvenio.ToString("000");

            TipoConvenio _tipoConvenio = new TipoConvenioFAC().Selecionar(enumTipoConvenio.Compras);

            Convenio _convenio = new ConvenioFAC().Selecionar(_cdConvenio.ToString(), _tipoConvenio);
            if (_convenio == null)
            {
                MessageBox.Show("Convênio não encontrado !");
                return;
            }

            DateTime _data = _util.Hoje();

            cboConvenio.SelectedValue = _convenio.ID;
            txtEvento.Text = _convenio.Evento;
            txtMes.Text = _data.Month.ToString("00");
            txtAno.Text = _data.Year.ToString();
            mskDataCompra.Text = _data.ToShortDateString();
            txtValorCompra.Focus();

        }

        private void txtMesConsulta_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CarregarCompras();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtAnoConsulta_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CarregarCompras();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtParcelaCompra_Leave(object sender, EventArgs e)
        {
            try
            {
                SalvarComanda();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SalvarComanda()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CompraFAC _CompraFAC = new CompraFAC();
                Compra _Compra = new Compra();
                List<Compra> _movimentos = new List<Compra>();
                DialogResult dialogResult;
                double _total = 0;
                double _valorCompra = _util.ConvertDouble(txtValorCompra.Text);
                int _totalParcelas = _util.ConvertInt(txtParcelaCompra.Text);
                Convenio _convenio = new ConvenioFAC().Selecionar(txtCodConvenio.Text);
                string _mensagem = "";

                int _mes = _util.ConvertInt(txtMesConsulta.Text);
                int _ano = _util.ConvertInt(txtAnoConsulta.Text);

                if (_mes < 1 || _mes > 12) throw new Exception("Informe o Mês !");
                if (_ano < 2017 || _ano > 2100) throw new Exception("Informe o Ano !");

                DateTime _dtCompetencia = new DateTime(_ano, _mes, 1);

                if (_convenio == null) throw new Exception("Informe o convênio !");

                Associado _associado = new AssociadoFAC().SelecionarPorMatricula(txtMatricula.Text);
                if (_associado == null) throw new Exception("Informe o associado !");

                if (!_util.ValidaData(mskDataCompra.Text)) throw new Exception("Informe a data da compra !");

                if (_valorCompra < 1) throw new Exception("Informe o valor da compra !");

                ValidaSituacaoAssociado(_associado);

                AssociadoFAC _associadoFAC = new AssociadoFAC();

                if (txtParcelaCompra.Text != "")
                {
                    if (_util.ConvertInt(txtParcelaCompra.Text) > _convenio.ParcelamentoMaximo && _convenio.Parcelado == "S")
                    {
                        txtParcelaCompra.Focus();
                        txtParcelaCompra.Text = "";
                        throw new Exception("Atenção ! número de parcelas deve ser de no máximo: " + _convenio.ParcelamentoMaximo.ToString() + " !");
                    }
                }

                if (txtParcelaCompra.Text == "") txtParcelaCompra.Text = "1";
                _totalParcelas = _util.ConvertInt(txtParcelaCompra.Text);
                _total = _associadoFAC.TotalUtilizado(_util.ConvertInt(_associado.Matricula), _util.ConvertInt(_associado.Folha), _mes, _ano) + (_valorCompra * _totalParcelas);

                // CRITICA A MARGEM                                    
                if (_ambiente.UsuarioLogado.NivelSeguranca != "ADM")
                {
                    // QDO EXISTIR LIMITE mes anterior e margem negativa

                    if (_total > _associado.Limite)
                    {
                        txtParcelaCompra.Text = "";
                        txtCodConvenio.Text = "";
                        txtCodConvenio.Focus();

                        throw new Exception("Atenção Margem Excedida de R$ " + (_total - _associado.Limite).ToString("#,##0.00"));
                    }
                }
                //fim de teste de margem

                // se passou margem entao

                for (int i = 1; i < _totalParcelas + 1; i++)
                {
                    _Compra = new Compra();
                    _Compra.Matricula = _util.PreencherMatricula(_associado.Matricula);
                    _Compra.Folha = _associado.Folha;
                    _Compra.ID_Convenio = _util.PreencherConvenio(_convenio.ID);
                    _Compra.DE_Convenio = _convenio.Nome;
                    _Compra.Evento = _convenio.Evento;
                    _Compra.Valor = _valorCompra;
                    _Compra.Mes = _dtCompetencia.Month;
                    _Compra.Ano = _dtCompetencia.Year;
                    _Compra.Data = _util.ConvertDateTime(mskDataCompra.Text);
                    _Compra.Referencia = i.ToString() + "/" + _totalParcelas;
                    _Compra.DataCadastro = DateTime.Today;
                    _Compra.Usuario = _ambiente.UsuarioLogado.Login;
                    _Compra.Status = "I";

                    _movimentos.Add(_Compra);

                    if (_convenio.Parcelado == "S") _dtCompetencia = _dtCompetencia.AddMonths(1);
                }


                if (_totalParcelas > 1)
                {
                    if (_convenio.Parcelado.ToUpper() == "N")
                    {
                        _mensagem = "Confirma emissão de " + _totalParcelas.ToString() + " comandas para este mês ?";
                    }
                    else
                    {
                        _mensagem = "Confirma parcelamento de " + _totalParcelas.ToString() + " comandas ?";
                    }

                    dialogResult = MessageBox.Show(_mensagem, "Impressão de comanda", MessageBoxButtons.YesNo);
                    if (dialogResult.Equals(DialogResult.No)) return;
                }


                //INCLUIR MOVIMENTOS 
                _movimentos = _CompraFAC.IncluirAlone(_movimentos);

                CarregarCompras();

                //IMPRIMIR COMANDAS
                ImprimiComanda(_movimentos);

                DateTime _data = _util.Hoje();

                txtCodConvenio.Text = "";
                cboConvenio.SelectedValue = "0";
                txtEvento.Text = "";
                txtMes.Text = _data.Month.ToString("00");
                txtAno.Text = _data.Year.ToString();
                mskDataCompra.Text = "";
                txtValorCompra.Text = "";
                txtParcelaCompra.Text = "";

                txtParcelaCompra.Leave -= txtParcelaCompra_Leave;
                txtCodConvenio.Focus();
                txtParcelaCompra.Leave += txtParcelaCompra_Leave;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { this.Cursor = Cursors.Default; }
        }

        private void txtMatricula_Enter(object sender, EventArgs e)
        {
            txtMatricula.SelectionStart = 0;
            txtMatricula.SelectionLength = txtMatricula.Text.Length;
        }

        private void txtMatricula_MouseClick(object sender, MouseEventArgs e)
        {
            txtMatricula_Enter(sender, e);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Confirma a alteração dos dados dos associados ?", "Alteração de Associado", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Salvar();
            }
        }

        private void Salvar()
        {
            try
            {
                AssociadoFAC _associadoFAC = new AssociadoFAC();

                Associado _associado = MontarObjeto();
                if (_associado == null) throw new Exception("Associado não encontrado para a matrícula informada !");

                _associadoFAC.SalvarAlone(_associado);

                MessageBox.Show("Cadastro atualizado !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Associado MontarObjeto()
        {
            try
            {
                Associado _associado = new AssociadoFAC().SelecionarPorMatricula(txtMatricula.Text);
                if (_associado == null) return null;

                //txtMatricula.Text = _util.PreencherMatricula(_associado.Matricula);
                //txtFolha.Text = _util.PreencherFolha(_associado.Folha);
                _associado.Nome = txtNome.Text;
                _associado.CargoFuncao = txtCargoFuncao.Text;
                _associado.Sexo = txtSexo.Text;
                _associado.Foto = _util.ImageToByte(picFoto.Image);
                _associado.Endereco = txtEndereco.Text;
                _associado.Numero = txtNumero.Text;
                _associado.Complemento = txtComplemento.Text;
                _associado.CEP = txtCEP.Text;
                _associado.Bairro = txtBairro.Text;
                _associado.Cidade = txtMunicipio.Text;
                _associado.Naturalidade = txtNatural.Text;
                _associado.Celular = txtCelular.Text;
                _associado.Telefone = txtTelefone.Text;
                _associado.CPF = _util.SomenteNumeros(txtCPF.Text);
                _associado.RG = txtIdentidade.Text;
                _associado.OrgaoExpedidor = txtExpedicao.Text;
                _associado.Agencia = txtAgencia.Text;
                _associado.Conta = txtConta.Text;
                _associado.DataAssociado = _util.ConvertDateTime(txtAdmissao.Text);
                _associado.DataNascimento = _util.ConvertDateTime(txtDataNascimento.Text);
                _associado.Lotacao = txtLotacao.Text;
                _associado.Email = txtEmail.Text;
                _associado.DataAdmissao = _util.ConvertDateTimeNullable(txtDataAdmissao.Text);
                _associado.Titulo = txtTituloEleitor.Text;
                _associado.PisPasep = txtPisPasep.Text;
                _associado.TipoSanguineo = txtTipoSanguineo.Text;
                _associado.DataExclusao = _util.ConvertDateTimeNullable(txtDataExclusao.Text);
                _associado.Pai = txtNomePai.Text;
                _associado.Mae = txtNomeMae.Text;
                _associado.Senha = txtSenha.Text;
                _associado.Cartao = txtCartao.Text;

                _associado.Autoriza = cboAutorizacao.SelectedItem.ToString();
                _associado.Situacao = cboSituacao.SelectedItem.ToString();
                _associado.SituacaoDRH = cboSituacaoDRH.SelectedItem.ToString();

                return _associado;


                //CarregarDados();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnComanda_Click(object sender, EventArgs e)
        {
            try
            {
                Convenio _convenio = new ConvenioFAC().Selecionar(txtCodConvenio.Text);
                Compra _movimento = new Compra()
                {
                    Ano = _util.ConvertInt(txtAnoConsulta.Text),
                    Mes = _util.ConvertInt(txtMesConsulta.Text),
                    ID_Convenio = _convenio.ID,
                    DE_Convenio = _convenio.Nome,
                    Evento = _convenio.Evento,
                    Matricula = txtMatricula.Text,
                    Folha = txtFolha.Text,
                    Referencia = "1/1",
                    Valor = _util.ConvertDouble(txtValorCompra.Text)
                };

                List<Compra> _movimentos = new List<Compra>();
                _movimentos.Add(_movimento);
                ImprimiComanda(_movimentos);

                //frmRelatorio _frm = new frmRelatorio(Usuario, enumRelatorio.Comanda, _competencia, _movimento);
                //_frm.ShowDialog();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ImprimiComanda(List<Compra> _movimentos)
        {

            foreach (Compra _movimento in _movimentos)
            {
                int _competencia = _util.ConvertInt(_movimento.Ano) * 100 + _util.ConvertInt(_movimento.Mes);

                ReportViewer reportViewer1 = new ReportViewer();

                LocalReport _report = new LocalReport();
                _report.ReportPath = @".\Relatorios\relComanda.rdlc";

                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "dsLogo";
                DataSet _ds = new RelatoriosFAC().Logo();
                reportDataSource.Value = _ds.Tables[0];
                _report.DataSources.Add(reportDataSource);

                Associado _associado = new AssociadoFAC().SelecionarPorMatricula(_movimento.Matricula);

                ReportParameter[] parameters = new ReportParameter[12];
                parameters[0] = new ReportParameter("Nome", _associado.Nome);
                parameters[1] = new ReportParameter("Matricula", _associado.Matricula);
                parameters[2] = new ReportParameter("Valor", _movimento.Valor.ToString("#,##0.00"));
                parameters[3] = new ReportParameter("Referencia", _movimento.Referencia);
                parameters[4] = new ReportParameter("Convenio", _movimento.ID_Convenio);
                parameters[5] = new ReportParameter("Evento", _movimento.Evento);
                parameters[6] = new ReportParameter("NomeConvenio", _movimento.DE_Convenio);
                parameters[7] = new ReportParameter("Competencia", _util.ConvertInteiroParaCompetencia(_competencia));
                parameters[8] = new ReportParameter("CodigoBarras", _movimento.Matricula + _movimento.ID_Convenio + "1111");
                parameters[9] = new ReportParameter("EmitidoPor", _ambiente.UsuarioLogado.Nome);

                string _texto = "Sr(a). " + _associado.Nome + ", Matrícula: " + _util.PreencherMatricula(_associado.Matricula) + ", efetuar compra de R$ " + _movimento.Valor.ToString("#,##0.00") + "(" + _extenso.NumeroParaExtenso(_movimento.Valor) + "), ";
                _texto += "junto a empresa conveniada: (" + _movimento.Referencia + ") - [" + _movimento.ID_Convenio + "] - [" + _movimento.Evento + "] - [" + _movimento.DE_Convenio + "].";

                parameters[10] = new ReportParameter("Texto", _texto);

                parameters[11] = new ReportParameter("IDComanda", _movimento.ID.ToString());

                _report.SetParameters(parameters);
                _report.Refresh();

                _printRDLC _print = new _printRDLC();
                _print.Run(_report);

                //reportViewer1.LocalReport.ReportPath= _report.ReportPath;
                //reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                //reportViewer1.LocalReport.SetParameters(parameters);
                //reportViewer1.LocalReport.Refresh();

                //reportViewer1.PrintDialog();
            }

        }

        private void picFoto_Click(object sender, EventArgs e)
        {

        }

        private void btnNovoFinanceiamento_Click(object sender, EventArgs e)
        {
            try
            {
                Associado _associado = new AssociadoFAC().SelecionarPorMatricula(txtMatricula.Text);
                if (_associado == null) throw new Exception("Informe o associado !");

                ValidaSituacaoAssociado(_associado);

                frmCadastroFinanciamento _form = new AssalceFolha.frmCadastroFinanciamento(_associado, null);
                _form.ShowDialog();

                CarregarFinanciamentos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ValidaSituacaoAssociado(Associado _associado)
        {
            try
            {
                if (!_ambiente.UsuarioLogado.NivelSeguranca.Equals("ADM") && !_associado.Situacao.IndexOf("BLOQ").Equals(-1))
                {
                    throw new Exception("Atenção ! O Associado não se encontra autorizado !");
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void dgFinanciamentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int _id = _util.ConvertInt(dgFinanciamentos.SelectedRows[0].Cells["colId"].Value);

                Financiamento _financiamento = new FinanciamentoFAC().Selecionar(_id);

                Associado _associado = new AssociadoFAC().SelecionarPorMatricula(txtMatricula.Text);
                if (_associado == null) throw new Exception("Informe o associado !");

                frmCadastroFinanciamento _form = new AssalceFolha.frmCadastroFinanciamento(_associado, _financiamento);
                _form.ShowDialog();

                CarregarFinanciamentos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void dgPlanos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int _id = _util.ConvertInt(dgPlanos.SelectedRows[0].Cells["colIdPlano"].Value);

                Plano _plano = new PlanoFAC().Selecionar(_id);

                Associado _associado = new AssociadoFAC().SelecionarPorMatricula(txtMatricula.Text);
                if (_associado == null) throw new Exception("Informe o associado !");

                frmCadastroPlano _form = new AssalceFolha.frmCadastroPlano(_associado, _plano);
                _form.ShowDialog();

                CarregarPlanos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNovoPlano_Click(object sender, EventArgs e)
        {
            try
            {
                Associado _associado = new AssociadoFAC().SelecionarPorMatricula(txtMatricula.Text);
                if (_associado == null) throw new Exception("Informe o associado !");

                ValidaSituacaoAssociado(_associado);

                frmCadastroPlano _form = new AssalceFolha.frmCadastroPlano(_associado, null);
                _form.ShowDialog();

                CarregarPlanos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ckAtivosFinanciamentos_Click(object sender, EventArgs e)
        {
            try
            {
                CarregarFinanciamentos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ckAtivosPlanos_Click(object sender, EventArgs e)
        {
            try
            {
                CarregarPlanos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ckAtivosBancos_Click(object sender, EventArgs e)
        {
            try
            {
                CarregarBancos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNovoBanco_Click(object sender, EventArgs e)
        {
            try
            {
                Associado _associado = new AssociadoFAC().SelecionarPorMatricula(txtMatricula.Text);
                if (_associado == null) throw new Exception("Informe o associado !");

                ValidaSituacaoAssociado(_associado);

                frmCadastroBancos _form = new AssalceFolha.frmCadastroBancos(_associado, null);
                _form.ShowDialog();

                CarregarBancos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void dgBancos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgBancos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int _id = _util.ConvertInt(dgBancos.SelectedRows[0].Cells["colIdBanco"].Value);

                Banco _banco = new BancoFAC().Selecionar(_id);

                Associado _associado = new AssociadoFAC().SelecionarPorMatricula(txtMatricula.Text);
                if (_associado == null) throw new Exception("Informe o associado !");

                frmCadastroBancos _form = new AssalceFolha.frmCadastroBancos(_associado, _banco);
                _form.ShowDialog();

                CarregarBancos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgPlanos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int _id = _util.ConvertInt(dgPlanos.SelectedRows[0].Cells["colIDPlano"].Value);

                Plano _plano = new PlanoFAC().Selecionar(_id);

                Associado _associado = new AssociadoFAC().SelecionarPorMatricula(txtMatricula.Text);
                if (_associado == null) throw new Exception("Informe o associado !");

                frmCadastroPlano _form = new AssalceFolha.frmCadastroPlano(_associado, _plano);
                _form.ShowDialog();

                CarregarPlanos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCapturaFoto_Click(object sender, EventArgs e)
        {
            try
            {
                frmCapturaImagem _form = new frmCapturaImagem();
                _form.ShowDialog();

                if (_form.Foto == null && _form.ExcluirFoto)
                {
                    AssociadoFAC _associadoFAC = new AssociadoFAC();

                    Associado _associado = _associadoFAC.SelecionarPorMatricula(txtMatricula.Text);
                    if (_associado == null) throw new Exception("Associado não encontrado !");
                    _associado.Foto = null;
                    _associadoFAC.AtualizarFoto(_associado);
                    picFoto.Image = null;

                }
                else if (_form.Foto != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Confirma a atualização da foto ?", "Atualizar foto", MessageBoxButtons.YesNo);
                    if (dialogResult.Equals(DialogResult.Yes))
                    {
                        AssociadoFAC _associadoFAC = new AssociadoFAC();

                        Associado _associado = _associadoFAC.SelecionarPorMatricula(txtMatricula.Text);
                        if (_associado == null) throw new Exception("Associado não encontrado !");
                        _associado.Foto = _util.ImageToByte(_form.Foto);
                        _associadoFAC.AtualizarFoto(_associado);
                        picFoto.Image = _form.Foto;

                        MessageBox.Show("Foto atuallizada !");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtParcelaCompra_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgCompras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    CompraFAC _compraFAC = new CompraFAC();

            //    int _id = _util.ConvertInt(dgCompras.SelectedRows[0].Cells["colIDCompras"].Value);

            //    Compra _compra = _compraFAC.Selecionar(_id);

            //    Associado _associado = new AssociadoFAC().SelecionarPorMatricula(txtMatricula.Text);
            //    if (_associado == null) throw new Exception("Informe o associado !");

            //    DialogResult dialogResult = MessageBox.Show("Confirma a exlusão da compra ?", "Exclusão compra", MessageBoxButtons.YesNo);
            //    if (dialogResult.Equals(DialogResult.Yes))
            //    {
            //        _compraFAC.Excluir(_compra);

            //        CarregarCompras();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            try
            {
                int _id = _util.ConvertInt(dgCompras.SelectedRows[0].Cells["colIDCompras"].Value);

                Compra _compra = new CompraFAC().Selecionar(_id);

                Associado _associado = new AssociadoFAC().SelecionarPorMatricula(txtMatricula.Text);
                if (_associado == null) throw new Exception("Informe o associado !");

                frmCadastroComanda _form = new AssalceFolha.frmCadastroComanda(_associado, _compra);
                _form.ShowDialog();

                CarregarCompras();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmPrincipal_Activated(object sender, EventArgs e)
        {
            txtMatricula.Focus();
        }

        private void picFoto_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                switch (e.Button)
                {
                    case MouseButtons.Right:
                        Associado _associado = new AssociadoFAC().SelecionarPorMatricula(txtMatricula.Text);
                        if (_associado != null)
                        {
                            if (_associado.Foto != null)
                            {
                                frmZoomFoto _form = new frmZoomFoto(_util.ByteToImage(_associado.Foto));
                                _form.ShowDialog();
                            }
                        }
                        break;
                    case MouseButtons.Left:
                        using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
                        {
                            openFileDialog1.Filter = "JPG Files|*.jpg";
                            openFileDialog1.Title = "Selecionar Foto";

                            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                byte[] _foto = _util.ImageToByte(openFileDialog1.FileName, 65);
                                picFoto.Image = _util.ByteToImage(_foto);
                            }
                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtMesConsulta_Enter(object sender, EventArgs e)
        {
            txtMesConsulta.SelectionStart = 0;
            txtMesConsulta.SelectionLength = txtMesConsulta.Text.Length;
        }

        private void txtMesConsulta_MouseClick(object sender, MouseEventArgs e)
        {
            txtMesConsulta_Enter(sender, e);
        }
    }
}
