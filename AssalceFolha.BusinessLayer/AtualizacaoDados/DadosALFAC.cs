using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.DataLayer.AtualizacaoDados;
using AssalceFolha.Entity;
using AssalceFolha.Entity.AtualizacaoDados;

namespace AssalceFolha.BusinessLayer.AtualizacaoDados
{
    public class DadosALFAC
    {
        DadosALDAO _dadosDAO = new DadosALDAO();

        public List<DadosAL> Listar()
        {
            try
            {
                return _dadosDAO.ListarDados();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DadosAL Seleiconar(string _matricula)
        {
            try
            {
                return _dadosDAO.SelecionarPorMatricula(_matricula);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Associado Atualizar(string _matricula)
        {
            try
            {
                DadosAL _dadosAL = new DadosALDAO().SelecionarPorMatricula(_matricula);
                Associado _associado = new AssociadoFAC().SelecionarPorMatricula(_matricula);

                if (_dadosAL == null) throw new Exception("Dados não encontrado para a matrícula informada !");
                if (_associado == null) throw new Exception("Associado não encontrado para a matrícula informada !");

                _associado = AtualizarAssociado(_dadosAL, _associado);

                return _associado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private Associado AtualizarAssociado(DadosAL _dadosAL, Associado _associado)
        {
            try
            {
                if (_dadosAL.MATR != _associado.Matricula) throw new Exception("Associado e dados AL com matrícula diferentes !");

                _associado.Folha = _dadosAL.FOLHA;
                _associado.Bairro = _dadosAL.BAIRRO;
                _associado.CargoFuncao = _dadosAL.CARFUN;
                _associado.Celular = _dadosAL.CELULAR;
                _associado.CEP = _dadosAL.CEP;
                _associado.Cidade = _dadosAL.CIDADE;
                _associado.Complemento = _dadosAL.COMPL;
                //_associado.CONJUGE = _dadosAL.CONJUGE;
                //_associado.exp = _dadosAL.DATA_EXP;
                _associado.CPF = _dadosAL.CPF;
                _associado.Email = _dadosAL.EMAIL;
                _associado.Endereco = _dadosAL.ENDERECO;
                _associado.DataAdmissao = _util.ConvertDateTimeNullable(_dadosAL.ENTROU_AL);
                _associado.Telefone = _dadosAL.FONE;
                if (_associado.Foto == null) _associado.Foto = _dadosAL.FOTO;
                _associado.Lotacao = _dadosAL.LOTACAO;
                _associado.Mae = _dadosAL.MAE;
                _associado.DataNascimento = _util.ConvertDateTime(_dadosAL.NASC);
                _associado.Naturalidade = _dadosAL.NATURALDE;
                _associado.Nome = _dadosAL.NOME;
                _associado.Numero = _dadosAL.NUM;
                _associado.OrgaoExpedidor = _dadosAL.ORG_EXP;
                _associado.Pai = _dadosAL.PAI;
                _associado.RG = _dadosAL.RG;
                //_associado. = _dadosAL.RG_UF;
                _associado.TipoSanguineo = _dadosAL.SANGUE;
                _associado.Sexo = _dadosAL.SEXO;
                _associado.UF = _dadosAL.UF;

                _associado.Situacao = new SituacaoALFAC().SelecionarPorMatricula(_associado.Matricula).SITUACAO;

                return new AssociadoFAC().SalvarAlone(_associado);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
