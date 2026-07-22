using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.BusinessLayer;
using AssalceFolha.DataLayer;
using AssalceFolha.Entity;

namespace AssalceFolha.BusinessLayer
{
    public class RelatoriosFAC
    {
        RelatoriosDAO _relatoriosDAO = new RelatoriosDAO();

        public DataSet Logo()
        {
            try
            {
                return _relatoriosDAO.Logo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ConferenciaCargaArquivoFolha(int _competencia)
        {
            try
            {
                return _relatoriosDAO.ConferenciaCargaArquivoFolha(_competencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Mapa(int _competencia)
        {
            try
            {
                return _relatoriosDAO.Mapa(_competencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ConvenioCompetencia(Convenio _convenio, int _competencia)
        {
            try
            {
                return _relatoriosDAO.ConvenioCompetencia(_convenio, _competencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Aniversarios(int _competencia)
        {
            try
            {
                return _relatoriosDAO.Aniversarios(_competencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ResumoConvenios(int _competencia)
        {
            try
            {
                return _relatoriosDAO.ResumoConvenios(_competencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet CriticaFolha(int _competencia, bool _somentePlanos = false, bool _todos = false)
        {
            try
            {
                return _relatoriosDAO.CriticaFolha(_competencia, _somentePlanos, _todos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet EnvioFolha(int _competencia)
        {
            try
            {
                return _relatoriosDAO.EnvioFolha(_competencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet FechamentoMes(int _competencia)
        {
            try
            {
                return _relatoriosDAO.FechamentoMes(_competencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet RetornoFolha(int _competencia)
        {
            try
            {
                return _relatoriosDAO.RetornoFolha(_competencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ExtratoComanda(Associado _associado, int _competencia)
        {
            try
            {
                return _relatoriosDAO.ExtratoComanda(_associado, _competencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ExtratoComandaAssociado(Associado _associado, int _competencia, bool _somenteAtivos)
        {
            try
            {
                return _relatoriosDAO.ExtratoComandaAssociado(_associado, _competencia, _somenteAtivos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DeclaracaoHapVida(Associado _associado, int _ano)
        {
            try
            {
                return _relatoriosDAO.DeclaracaoHapVida(_associado, _ano);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ExtratoComanda(Associado _associado, int _competenciaInicial, int _competenciaFinal)
        {
            try
            {
                return _relatoriosDAO.ExtratoComanda(_associado, _competenciaInicial, _competenciaFinal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DadosAssociados(Associado _associado)
        {
            try
            {
                return _relatoriosDAO.DadosAssociados(_associado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ComparativoEnvioRetorno(Associado _associado, int  _competenciaInicial, int _competenciaFinal)
        {
            try
            {
                return _relatoriosDAO.ComparativoEnvioRetorno(_associado, _competenciaInicial, _competenciaFinal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
