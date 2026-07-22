using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AssalceFolha.ScriptGenerator;

namespace AssalceFolha.Entity
{
    [TableName("TB_PARAMETRO")]
    public class Parametro : EntityBase<Parametro>
    {
        [TableField(true, IsIdentity = true, IsKey = true, NameField = "CD_PARAMETRO")]
        public int ID { get; set; }

        #region TipoParametro
        private TipoParametro _tipoParametro;

        [TableField(true, NameField = "CD_TIPO_PARAMETRO")]
        public int ID_TipoParametro { get; set; }

        [TableField(false)]
        public TipoParametro TipoParametro
        {
            get { return _tipoParametro; }
            set
            {
                _tipoParametro = value;
                if (_tipoParametro != null) ID_TipoParametro = _tipoParametro.ID;
            }
        }
        #endregion

        #region enumTipoDadoParametro
        private enumTipoDadoParametro _tipoDado;

        [TableField(true, NameField = "CD_TIPO_DADO")]
        public int ID_enumTipoDadoParametro { get; set; }

        [TableField(false)]
        public enumTipoDadoParametro enumTipoDadoParametro
        {
            get { return _tipoDado; }
            set
            {
                _tipoDado = value;
                ID_enumTipoDadoParametro = new Enumerator<enumTipoDadoParametro>().EnumToInt( _tipoDado);
            }
        }
        #endregion

        [TableField(true, NameField = "VR_PARAMETRO")]
        public string Valor { get; set; }
        
    }
}
