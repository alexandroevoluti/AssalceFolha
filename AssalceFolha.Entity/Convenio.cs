using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.ScriptGenerator;

namespace AssalceFolha.Entity
{
    [TableName("SCAVER")]
    public class Convenio : EntityBase<Convenio>
    {
        [GeneratorKey(TypeGeneratorKey.Natural)]
        [TableField(true, IsRequired = true, IsKey = true, FillCritical = "Informe o código !", NameField = "VERCOD")]
        public string ID { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o  nome!", NameField = "VERRAZ")]
        public string Nome { get; set; }

        [TableField(true, IsRequired = true, AllowZero = false, FillCritical = "Informe o  evento !", NameField = "VEREVT")]
        public string Evento { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a consignação DRH !", NameField = "VERDSC")]
        public string NomeConvenio { get; set; }

        [TableField(true, NameField = "DIAVENC")]
        public int? DiaVencimento { get; set; }

        [TableField(true, NameField = "MAXPARC")]
        public int? ParcelamentoMaximo { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a situação do parcelamento !", NameField = "PARCELADO")]
        public string Parcelado { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o status do convênio!", NameField = "ATIVO")]
        public string Ativo { get; set; }

        [TableField(false)]
        public string UsuarioCarga { get; set; }

    }
}
