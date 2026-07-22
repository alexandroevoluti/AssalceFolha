using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.DataLayer.AtualizacaoDados;
using AssalceFolha.Entity.AtualizacaoDados;

namespace AssalceFolha.BusinessLayer.AtualizacaoDados
{
    public class SituacaoALFAC
    {
        SituacaoALDAO _situacaoDAO = new SituacaoALDAO();

        public List<SituacaoAL> Listar()
        {
            try
            {
                return _situacaoDAO.ListarDados();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public SituacaoAL SelecionarPorMatricula(string _matricula)
        {
            try
            {
                return _situacaoDAO.SelecionarPorMatricula(_matricula);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
