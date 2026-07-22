using AssalceFolha.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssalceFolha.DataLayer
{
    public class TipoFolhaDAO: _BaseDAO
    {
        public List<TipoFolha> Listar()
        {
            try
            {
                List<TipoFolha> _lista = null;
                TipoFolha _tipoFolha = new TipoFolha();
                string _sql = " select distinct folha from associados order by folha";

                DataSet _ds = ExecutarSELECT(_sql);

                if (_ds.Tables[0].Rows.Count >0)
                {
                    _lista = new List<TipoFolha>();

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

        private TipoFolha Montar(DataRow _row)
        {
            try
            {
                TipoFolha _tipoFolha = new TipoFolha();
                _tipoFolha.ID = _util.ConvertInt(_row[0].ToString());
                _tipoFolha.Descricao = "Folha " + _tipoFolha.ID.ToString("00");

                return _tipoFolha;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
