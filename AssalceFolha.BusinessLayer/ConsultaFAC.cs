using AssalceFolha.DataLayer;
using AssalceFolha.Entity;
using System.Data;

namespace AssalceFolha.BusinessLayer
{
    public class ConsultaFAC
    {
        ConsultaDAO _consultaDAO = new ConsultaDAO();

        public DataSet GerarDados(enumConsulta _consulta, int _competencia, int _ano)
        {
            return _consultaDAO.GerarDados(_consulta, _competencia, _ano);
        }
        public DataSet GerarDados(string _sql)
        {
            return _consultaDAO.GerarDados(_sql);
        }
    }
}
