using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.ScriptGenerator;

namespace AssalceFolha.Entity
{
    [TableName("SCAEMP")]
    public class Plano : EntityBase<Plano>
    {
        [TableField(true, IsIdentity = true, IsKey = true, NameField = "ID")]
        //[TableField(false)]
        public int ID { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a matrícula !", NameField = "EMPMAT")]
        public string Matricula { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a folha !", NameField = "FOLHA")]
        public string Folha { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o evento !", NameField = "EVENTO")]
        public string Evento { get; set; }

        #region Convenio
        private Convenio _convenio;

        [TableField(true, IsRequired = true, FillCritical = "Informe o convênio !", NameField = "EMPCNV")]
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

        [TableField(true, IsRequired = true, FillCritical = "Informe o nome do convênio !", NameField = "EMPDSC")]
        public string Nome { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a data de incício !", NameField = "EMP_DAT_I")]
        public DateTime DataInicio { get; set; }

        [TableField(true, NameField = "EMP_DAT_F")]
        public DateTime? DataTermino { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o valor da parcela !", NameField = "EMP_V_PARC")]
        public double Valor { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o usuário do plano !", NameField = "USU_PLANO")]
        public string UsuarioPlano { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o parentesco do usuário !", NameField = "PARENTESCO")]
        public string Parentesco { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o tipo do usuário !", NameField = "TP")]
        public string TP { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a acomodação !", NameField = "ACOMODACAO")]
        public string Acomodacao { get; set; }

        [TableField(true, NameField = "NASC")]
        public DateTime? DataNascimento { get; set; }


        [TableField(true, IsRequired = true, FillCritical = "Informe o status !", NameField = "ST")]
        public string Status { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a data do cadastro !", NameField = "DTCAD")]
        public string DataCadastro { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o usuário !", NameField = "USUARIO")]
        public string Usuario { get; set; }        
    }
}
