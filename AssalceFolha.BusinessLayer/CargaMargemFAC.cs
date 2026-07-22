using AssalceFolha.DataLayer;
using AssalceFolha.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssalceFolha.BusinessLayer
{
    public class CargaMargemFAC
    {
        CargaMargemDAO _cargaMargemDAO = new CargaMargemDAO();

        public CargaMargem Selecionar(int _id)
        {
            try
            {
                return _cargaMargemDAO.Selecionar(_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CargaMargem> Listar()
        {
            try
            {
                return _cargaMargemDAO.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CargaMargem> Listar(int _ano, int _mes)
        {
            try
            {
                return _cargaMargemDAO.Listar(_ano, _mes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CargaMargem Salvar(CargaMargem _cargaMargem)
        {
            try
            {
                CargaMargem entidade = _cargaMargem;
                if (entidade.ID.Equals(0))
                {
                    entidade = _cargaMargemDAO.Incluir(entidade);
                }
                else
                {
                    _cargaMargemDAO.Alterar(entidade);
                }

                return entidade;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CargaMargem> Salvar(List<CargaMargem> _margens)
        {
            try
            {

                foreach (var _cargaMargem in _margens)
                {
                    CargaMargem entidade = _cargaMargem;
                    if (entidade.ID.Equals(0))
                    {
                        entidade = _cargaMargemDAO.Incluir(entidade);
                    }
                    else
                    {
                        _cargaMargemDAO.Alterar(entidade);
                    }
                }

                return _margens;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExisteCarga(int _ano, int _mes)
        {
            try
            {
                return _cargaMargemDAO.ExisteCarga(_ano, _mes);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CargaMargem AtualizarMargem(CargaMargem item, Associado _associado)
        {
            try
            {
                List<CargaMargem> _listaNaoEncontrado = new List<CargaMargem>();


                int _ano = item.Ano;
                int _mes = item.Mes;

                AssociadoDAO _associadoDAO = new AssociadoDAO();

                if (_associado == null) _associado = _associadoDAO.SelecionarPorMatricula(item.Matricula.ToString());

                if (_associado != null)
                {
                    if (item.Folha != _util.ConvertInt(_associado.Folha))
                    {
                        _associado.Folha = item.Folha.ToString("00");
                        _associadoDAO.AtualizarFolha(_associado);
                    }
                    if (!_associado.Situacao.Equals("TERCEIRIZADO"))
                    {
                        if (item.Margem < 0 && _associado.Situacao != "BLOQUEADO")
                        {
                            _associado.SituacaoAnterior = _associado.Situacao;
                            _associado.Situacao = "BLOQUEADO";

                            _associadoDAO.AtualizarSituacao(_associado, _associado.SituacaoAnterior);
                        }
                        else if (item.Margem > 0 && _associado.Situacao == "BLOQUEADO")
                        {
                            _associado.Situacao = _associado.SituacaoAnterior ?? "ASSOCIADO";
                            if (_associado.Situacao == "BLOQUEADO") _associado.Situacao = "ASSOCIADO";
                            _associadoDAO.AtualizarSituacao(_associado);
                        }
                        if (_associado.Situacao == "FORA DE FOLHA")
                        {
                            _associado.Situacao = _associado.SituacaoAnterior ?? "ASSOCIADO";
                            _associadoDAO.AtualizarSituacao(_associado);
                        }
                    }

                    AlterarMargem(_associado, item.Margem);
                }

                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AtualizarForaDeFolha(int _ano, int _mes)
        {
            try
            {
                _cargaMargemDAO.AtualizarForaDeFolha(_ano, _mes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void AlterarMargem(Associado _associado, double _valorMargem)
        {
            try
            {
                MargemFAC _margemFAC = new MargemFAC();
                Margem _margem = _margemFAC.Selecionar(_util.ConvertInt(_associado.Matricula));

                if (_margem == null) _margem = new Margem();

                _margem.Matricula = _associado.Matricula;
                _margem.Folha = _associado.Folha;
                _margem.ValorMargem = _valorMargem;


                _margemFAC.Salvar(_margem);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
