using AssalceFolha.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssalceFolha.DataLayer
{
    public class SituacaoDRHDAO : _BaseDAO
    {
        public List<SituacaoDRH> Listar()
        {
            try
            {
                List<SituacaoDRH> _lista = null;
                SituacaoDRH _situacaoDRH = new SituacaoDRH();
                string _sql = " select distinct SITDRH from associados order by SITDRH ";

                DataSet _ds = ExecutarSELECT(_sql);

                if (_ds.Tables[0].Rows.Count > 0)
                {
                    _lista = new List<SituacaoDRH>();

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

        private SituacaoDRH Montar(DataRow _row)
        {
            try
            {
                SituacaoDRH _situacaoDRH = new SituacaoDRH();
                _situacaoDRH.ID = 0;
                _situacaoDRH.Descricao = _row[0].ToString();

                return _situacaoDRH;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
