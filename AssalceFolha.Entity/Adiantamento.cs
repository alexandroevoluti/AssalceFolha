using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.ScriptGenerator;

namespace AssalceFolha.Entity
{
    [TableName("TB_ADIANTAMENTO")]
    public class Adiantamento : EntityBase<Adiantamento>
    {
        [TableField(true, IsIdentity = true, IsKey = true, NameField = "CD_ADIANTAMENTO")]
        public int ID { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a matrícula !", NameField = "NR_MATRICULA")]
        public string Matricula { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a folha !", NameField = "NR_FOLHA")]
        public string Folha { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a data do adiantamento !", NameField = "DT_ADIANTAMENTO")]
        public DateTime Data { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a quantidade de parcelas do adiantamento !", NameField = "NR_PARCELAS")]
        public int Parcelas { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o valor do adiantamento !", NameField = "VR_ADIANTAMENTO")]
        public double Valor { get; set; }

        #region Convenio
        private Convenio _convenio;

        [TableField(true, IsRequired = true, FillCritical = "Informe o convênio !", NameField = "CD_CONVENIO")]
        public string ID_Convenio { get; set; }

        [TableField(false)]
        public Convenio Convenio
        {
            get { return _convenio; }
            set
            {
                _convenio = value;
                if (_convenio != null) ID_Convenio = _convenio.ID;
            }
        }
        #endregion

        [TableField(true, IsRequired = true, FillCritical = "Informe o valor da parcela !", NameField = "VR_PARCELA")]
        public double ValorParcela { get; set; }

        
        [TableField(true, IsRequired = true, FillCritical = "Data de início do pagamento não informada!", NameField = "DT_INICIO_PAGAMENTO")]
        public DateTime DataInicioPagamento { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Data final do pagamento não informada!", NameField = "DT_FIM_PAGAMENTO")]
        public DateTime DataFimPagamento { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Data de inclusão não informada!", NameField = "DT_RESPONSAVEL_INFORMACAO")]
        public DateTime DataInformacao { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Login do responsável pela inclusão não informado", NameField = "LG_RESPONSAVEL_INFORMACAO")]
        public string LoginResponsavelInformacao { get; set; }

    }
}
