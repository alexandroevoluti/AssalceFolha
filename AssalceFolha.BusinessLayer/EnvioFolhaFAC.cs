using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.DataLayer;
using AssalceFolha.Entity;

namespace AssalceFolha.BusinessLayer
{
    public class EnvioFolhaFAC
    {
        EnvioFolhaDAO _envioFolhaDAO = new EnvioFolhaDAO();

        public EnvioFolha Selecionar(int _id)
        {
            try
            {
                return _envioFolhaDAO.Selecionar(_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EnvioFolha> Listar()
        {
            try
            {
                return _envioFolhaDAO.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EnvioFolha> Listar(int _ano, int _mes)
        {
            try
            {
                return _envioFolhaDAO.Listar(_ano, _mes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EnvioFolha Salvar(EnvioFolha _envioFolha)
        {
            try
            {
                EnvioFolha entidade = _envioFolha;
                if (entidade.ID.Equals(0))
                {
                    entidade = _envioFolhaDAO.Incluir(entidade);
                }
                else
                {
                    _envioFolhaDAO.Alterar(entidade);
                }

                return entidade;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EnvioFolha> Salvar(List<EnvioFolha> _enviosFolha)
        {
            try
            {

                foreach (var _envioFolha in _enviosFolha)
                {
                    EnvioFolha entidade = _envioFolha;
                    if (entidade.ID.Equals(0))
                    {
                        entidade = _envioFolhaDAO.Incluir(entidade);
                    }
                    else
                    {
                        _envioFolhaDAO.Alterar(entidade);
                    }
                }

                return _enviosFolha;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExisteEnvio(int _ano, int _mes)
        {
            try
            {
                return _envioFolhaDAO.ExisteEnvio(_ano, _mes);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string FechamentoMes(int _ano, int _mes)
        {
            try
            {
                return _envioFolhaDAO.FechamentoMes(_ano, _mes);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public string GerarArquivo(int _competencia)
        {
            try
            {
                int _ano = _util.ConvertInt(_competencia.ToString().Substring(0,4));
                int _mes = _util.ConvertInt(_competencia.ToString().Substring(4, 2));


                //ESTA SENDO MARCADO COMO FORA DE FOLHA NA PROCEDURE DE FECHAMENTO DA FOLHA
                //_envioFolhaDAO.MarcarForaFolha(_ano, _mes);

                List<EnvioFolha> _lista = Listar(_ano, _mes);

                if (_lista == null) throw new Exception("Nenhum envio encontrado para a competência informada !");

                return _envioFolhaDAO.GerarArquivo(_ano, _mes, _lista);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
