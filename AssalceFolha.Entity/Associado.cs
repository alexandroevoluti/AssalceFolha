using System;
using AssalceFolha.ScriptGenerator;

namespace AssalceFolha.Entity
{
    [TableName("ASSOCIADOS")]
    public class Associado: EntityBase<Associado>
    {
        //[TableField(true, IsIdentity = true, IsKey = true, NameField = "ID")]
        [TableField(false)]
        public int ID { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a matrícula !", NameField = "MATR")]
        public string Matricula { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a folha !", NameField = "FOLHA")]
        public string Folha { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o nome !", NameField = "NOME")]
        public string Nome { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a lotação !", NameField = "LOTACAO")]
        public string Lotacao { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o cargo ou função !", NameField = "CARFUN")]
        public string CargoFuncao { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a data de nascimento !", NameField = "NASC")]
        public DateTime DataNascimento { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a naturalidade !", NameField = "NATURALDE")]
        public string Naturalidade { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o sexo !", NameField = "SEXO")]
        public string Sexo { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o cpf !", NameField = "CPF")]
        public string CPF { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a identidade !", NameField = "RG")]
        public string RG { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o orgão expedidor !", NameField = "ORG_EXP")]
        public string OrgaoExpedidor { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o nome do pai !", NameField = "PAI")]
        public string Pai { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o nome da mãe !", NameField = "MAE")]
        public string Mae{ get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o endereço !", NameField = "ENDERECO")]
        public string Endereco { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o número !", NameField = "NUM")]
        public string Numero { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o complemento !", NameField = "COMPL")]
        public string Complemento{ get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o bairro !", NameField = "BAIRRO")]
        public string Bairro { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o CEP !", NameField = "CEP")]
        public string CEP { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a cidade !", NameField = "CIDADE")]
        public string Cidade { get; set; }

        [TableField(true, NameField = "UF")]
        public string UF { get; set; }

        [TableField(true, NameField = "FONE")]
        public string Telefone { get; set; }

        [TableField(true, NameField = "CELULAR")]
        public string Celular { get; set; }

        [TableField(true, NameField = "AGENCIA")]
        public string Agencia { get; set; }

        [TableField(true, NameField = "CONTA")]
        public string Conta { get; set; }

        [TableField(true, NameField = "SENHA")]
        public string Senha { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a situação !", NameField = "SITUACAO")]
        public string Situacao{ get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a situação DRH !", NameField = "SITDRH")]
        public string SituacaoDRH{ get; set; }

        [TableField(true, NameField = "ASSOCIADO")]
        public DateTime? DataAssociado { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o email !", NameField = "EMAIL")]
        public string Email { get; set; }

        [TableField(true, NameField = "CARTAO")]
        public string Cartao { get; set; }

        [TableField(true, NameField = "TITULO")]
        public string Titulo { get; set; }

        [TableField(true, NameField = "PISPASEP")]
        public string PisPasep { get; set; }

        [TableField(true, NameField = "DTENTRAAL")]
        public DateTime? DataAdmissao{ get; set; }

        [TableField(true, NameField = "TIPOSANG")]
        public string TipoSanguineo { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a data do cadastro !", NameField = "DTCADASTRO")]
        public DateTime DataCadastro{ get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o usuário !", NameField = "USUARIO")]
        public string Usuario { get; set; }

        [TableField(true, NameField = "FARMACIA")]
        public double Farmacia { get; set; }

        [TableField(true, NameField = "COMPRAS")]
        public double Compras { get; set; }

        [TableField(true, NameField = "LIMITE")]
        public double Limite { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a foto  !", NameField = "FOTO")]
        public byte[] Foto { get; set; }

        [TableField(true, NameField = "TERCEIROS")]
        public byte[] Terceiros { get; set; }

        [TableField(true, NameField = "EXCLUSAO")]
        public DateTime? DataExclusao { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe o autorização !", NameField = "AUTORIZA")]
        public string Autoriza { get; set; }

        [TableField(true, IsRequired = true, FillCritical = "Informe a situação !", NameField = "SITUACAO_ANTERIOR")]
        public string SituacaoAnterior { get; set; }

        [TableField(false)]
        public Margem Margem{ get; set; }

    }
}
