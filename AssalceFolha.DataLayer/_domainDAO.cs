using AssalceFolha.Entity;
using AssalceFolha.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssalceFolha.DataLayer
{
    public class _domainDAO : EntidadeDAO<_domain> 
    {
        
        public List<_domain> Convenio(int _id = 0, string _filtro = "")
        {
            try
            {
                string _sql = " SELECT CNVCOD ID, CNVRAZ NOME FROM SCACNV ";

                string _condicao = " WHERE ";

                if (_id > 0)
                {
                    _sql += _condicao + " CNVCOD = " + _id.ToString();
                    _condicao = " OR ";
                }
                if (!_filtro.Trim().Equals("")) _sql += _condicao + " CNVRAZ LIKE '%" + _filtro + "%' ";

                return Listar(_sql, false);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

        private List<_domain> Listar(string _sql, bool _incluirItemSelecionar = true, bool _incluirItemTodos = false)
        {
            try
            {
                List<_domain> _lista = new List<_domain>();

                if (_incluirItemSelecionar) _lista.Add(new _domain() { ID = 0, Nome = " (( SELECIONAR )) " });
                if (_incluirItemTodos) _lista.Add(new _domain() { ID = 0, Nome = " TODOS " });

                DataSet _ds = ExecutarSELECT(_sql);
                foreach (DataRow _row in _ds.Tables[0].Rows)
                {
                    _domain _item = new _domain()
                    {
                        ID = _util.ConvertInt(_row["ID"]),
                        Nome = _row["NOME"].ToString()
                    };

                    _lista.Add(_item);
                }

                return _lista.OrderBy(x => x.Nome).ToList();

            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }
    }
}
