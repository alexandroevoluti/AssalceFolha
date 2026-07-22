using AssalceFolha.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssalceFolha.DataLayer
{
    public class SituacaoDAO : _BaseDAO
    {
        public List<Situacao> Listar()
        {
            try
            {
                List<Situacao> _lista = null;
                Situacao _situacao = new Situacao();
                string _sql = " select distinct SITUACAO from associados order by SITUACAO ";

                DataSet _ds = ExecutarSELECT(_sql);

                if (_ds.Tables[0].Rows.Count > 0)
                {
                    _lista = new List<Situacao>();

                    foreach (DataRow _row in _ds.Tables[0].Rows)
                    {
                        _lista.Add(Montar(_row));
                    }
                }

                return _lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Situacao Montar(DataRow _row)
        {
            try
            {
                Situacao _situacao = new Situacao();
                _situacao.ID = 0;
                _situacao.Descricao = _row[0].ToString();

                return _situacao;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
