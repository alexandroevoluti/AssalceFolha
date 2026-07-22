using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.DataLayer;
using AssalceFolha.Entity;
using AssalceFolha.ErrorHandling;
using MySql.Data.MySqlClient;
using AssalceFolha.DataLayer.DTO;
using AssalceFolha.Entity.DTO;

namespace AssalceFolha.BusinessLayer.DTO
{
    public class AcompanhamentoMensalDTOFAC
    {
        AcompanhamentoMensalDTODAO _acompanhamentoMensalDTODAO = new AcompanhamentoMensalDTODAO();

        public List<AcompanhamentoMensalDTO> Listar(int _competencia)
        {
            try
            {
                return _acompanhamentoMensalDTODAO.Listar(_competencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}

