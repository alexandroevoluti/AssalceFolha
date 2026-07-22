using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.Entity.AtualizacaoDados;

namespace AssalceFolha.DataLayer.AtualizacaoDados
{
    public class DadosALDAO : EntidadeDAO<DadosAL>
    {
        string _connectioString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = D:\Google Drive\Arquivos Bakup Assalce\Atualização Dados\asalce.accdb";

        public List<DadosAL> ListarDados()
        {
            try
            {

                List<DadosAL> _lista = null;
                string _sql = " SELECT * FROM SERVIDORES_ASALCE ORDER BY MATR";

                using (OleDbConnection _conn = new OleDbConnection(_connectioString))
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter(_sql, _conn);
                    DataSet _ds = new DataSet();
                    adapter.Fill(_ds, "Registros");

                    if (_ds.Tables[0].Rows.Count == 0) return null;

                    _lista = new List<DadosAL>();

                    foreach (DataRow row in _ds.Tables[0].Rows)
                    {
                        _lista.Add(Montar(row));
                    }
                }

                return _lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DadosAL SelecionarPorMatricula(string _matricula)
        {
            try
            {

                DadosAL _entidade = null;
                string _sql = " SELECT * FROM SERVIDORES_ASALCE WHERE MATR = '" + _matricula.ToString() + "' ORDER BY MATR";

                using (OleDbConnection _conn = new OleDbConnection(_connectioString))
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter(_sql, _conn);
                    DataSet _ds = new DataSet();
                    adapter.Fill(_ds, "Registros");

                    if (_ds.Tables[0].Rows.Count == 0) return null;

                    _entidade = new DadosAL();

                    foreach (DataRow row in _ds.Tables[0].Rows)
                    {
                        _entidade = Montar(row);
                    }
                }

                return _entidade;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
