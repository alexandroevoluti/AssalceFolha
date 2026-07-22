using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AssalceFolha.Entity;
using AssalceFolha.ErrorHandling;

namespace AssalceFolha.DataLayer
{
    public class ParametroDAO : EntidadeDAO<Parametro>
    {
        public Parametro Selecionar(enumTipoParametro  _tipoParametro, DateTime _data)
        {
            try
            {
                string _sql = " SELECT * FROM TB_PARAMETRO ";
                _sql += " WHERE CD_TIPO_PARAMETRO = " + ((int)_tipoParametro).ToString();
                _sql += " AND DT_INICIO_VIGENCIA <= '" + _data.ToString("yyyy-MM-dd") + "' ";
                _sql += " AND IF(DT_FIM_VIGENCIA IS NULL, '" + _data.ToString("yyyy-MM-dd") + "', DT_FIM_VIGENCIA) <= '" + _data.ToString("yyyy-MM-dd") + "' ";

                return base.RetornarEntidadeDe(_sql);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }
    }
}

