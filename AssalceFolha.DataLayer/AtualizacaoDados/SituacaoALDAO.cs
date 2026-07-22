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
    public class SituacaoALDAO : EntidadeDAO<SituacaoAL>
    {
        string _connectioString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = D:\Google Drive\Arquivos Bakup Assalce\Atualização Dados\asalce.accdb";

        public SituacaoAL SelecionarPorMatricula(string _matricula)
        {
            try
            {

                SituacaoAL _entidade = null;
                string _sql = " SELECT * FROM SITUACAO_AL WHERE VAL(MATR) = " + _matricula + " AND VAL(FOLHA) > 0 ";

                using (OleDbConnection _conn = new OleDbConnection(_connectioString))
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter(_sql, _conn);
                    DataSet _ds = new DataSet();
                    adapter.Fill(_ds, "Registros");

                    if (_ds.Tables[0].Rows.Count == 0) return null;

                    _entidade = new SituacaoAL();

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

        public List<SituacaoAL> ListarDados()
        {
            try
            {

                List<SituacaoAL> _lista = null;
                string _sql = " SELECT * FROM SITUACAO_AL ORDER BY MATR";

                using (OleDbConnection _conn = new OleDbConnection(_connectioString))
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter(_sql, _conn);
                    DataSet _ds = new DataSet();
                    adapter.Fill(_ds, "Registros");

                    if (_ds.Tables[0].Rows.Count == 0) return null;

                    _lista = new List<SituacaoAL>();

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
    }
}
